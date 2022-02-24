using Day11.DTO;
using Day11.Entities;
using Day11.DB;
using Microsoft.EntityFrameworkCore;

namespace Day11.Services
{
    public class ProductService : IProductService
    {
        private StoreContext _storeContext;

        public ProductService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        
        public async Task<Product> AddProduct(ProductDTO product)
        {
            using var transaction = _storeContext.Database.BeginTransaction();
            try
            {
                var addingItem = await _storeContext.Products.AddAsync(
                    new Product
                    {
                        ProductName = product.ProductName,
                        Manufacture = product.Manufacture,
                        CategoryId = product.CategoryId
                    });

                await _storeContext.SaveChangesAsync();
                await transaction.CommitAsync();

                return addingItem.Entity;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<Product> EditProduct(int id, ProductDTO product)
        {
            using var transaction = _storeContext.Database.BeginTransaction();
            try
            {
                var foundCategory = await _storeContext.Categories.FindAsync(product.CategoryId);
                if (foundCategory != null)
                {
                    var foundProduct = await _storeContext.Products.FindAsync(id);
                    if (foundProduct != null)
                    {
                        foundProduct.ProductName = product.ProductName;
                        foundProduct.Manufacture = product.Manufacture;
                        foundCategory.CategoryId = foundCategory.CategoryId;

                        await _storeContext.SaveChangesAsync();
                        await transaction.CommitAsync();

                        return foundProduct;
                    }
                }
                return null;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task DeleteProduct(int id)
        {
            using var transaction = _storeContext.Database.BeginTransaction();
            try
            {
                var item = await _storeContext.Products.FindAsync(id);
                if (item != null)
                {
                    _storeContext.Products.Remove(item);

                    await _storeContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _storeContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            var item = await _storeContext.Products.FindAsync(id);
            if (item != null)
            {
                return item;
            }
            return null;
        }
    }
}