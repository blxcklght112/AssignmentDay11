using Day11.Entities;
using Day11.DTO;
using Day11.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day11.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("/add-product")]
        public async Task<Product> AddProduct(ProductDTO product)
        {
            return await _productService.AddProduct(product);
        }

        [HttpPut("/edit-product")]
        public async Task<Product> EditProduct(int id, ProductDTO product)
        {
            return await _productService.EditProduct(id, product);
        }

        [HttpDelete("/delete-product")]
        public async Task DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);
        }

        [HttpGet("/get-all-products")]
        public async Task<List<Product>> GetAllProducts()
        {
            return await _productService.GetAllProducts();
        }

        [HttpGet("/get-product-by-id")]
        public async Task<Product> GetProductById(int id)
        {
            return await _productService.GetProductById(id);
        }
    }
}