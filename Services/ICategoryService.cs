using Day11.Entities;
using Day11.DTO;

namespace Day11.Services
{
    public interface ICategoryService
    {
        Task<Category> AddCategory(CategoryDTO category);

        Task<Category> EditCategory(int id, CategoryDTO category);

        Task DeleteCategory(int id);

        Task<List<Category>> GetAllCategories();

        Task<Category> GetCategoryById(int id);
    }
}