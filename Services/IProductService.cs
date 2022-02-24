using Day11.DTO;
using Day11.Entities;

namespace Day11.Services
{
    public interface IProductService
    {
        Task<Product> AddProduct(ProductDTO product);

        Task<Product> EditProduct(int id, ProductDTO product);

        Task DeleteProduct(int id);

        Task<List<Product>> GetAllProducts();

        Task<Product> GetProductById(int id);
    }
}