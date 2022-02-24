using Day11.Services;
using Day11.DTO;
using Day11.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Day11.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("/add-category")]
        public async Task<Category> AddCategory(CategoryDTO category)
        {
            return await _categoryService.AddCategory(category);
        }

        [HttpPut("/edit-category")]
        public async Task<Category> EditCategory(int id, CategoryDTO category)
        {
            return await _categoryService.EditCategory(id, category);
        }

        [HttpDelete("/delete-category")]
        public async Task DeleteCategory(int id)
        {
            await _categoryService.DeleteCategory(id);
        }

        [HttpGet("/get-all-categories")]
        public async Task<List<Category>> GetAllCategories()
        {
            return await _categoryService.GetAllCategories();
        }

        [HttpGet("/get-category-by-id")]
        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryService.GetCategoryById(id);
        }
    }
}