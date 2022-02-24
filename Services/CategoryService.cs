using Day11.DTO;
using Day11.Entities;
using Day11.DB;
using Microsoft.EntityFrameworkCore;

namespace Day11.Services
{
    public class CategoryService : ICategoryService
    {
        private StoreContext _storeContext;

        public CategoryService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<Category> AddCategory(CategoryDTO category)
        {
            var item = new Category
            {
                CategoryName = category.CategoryName
            };

            var addingItem = await _storeContext.Categories.AddAsync(item);

            await _storeContext.SaveChangesAsync();

            return addingItem.Entity;
        }

        public async Task<Category> EditCategory(int id, CategoryDTO category)
        {
            var item = await _storeContext.Categories.FindAsync(id);
            if (item != null)
            {
                item.CategoryName = category.CategoryName;

                await _storeContext.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task DeleteCategory(int id)
        {
            var item = await _storeContext.Categories.FindAsync(id);
            if (item != null)
            {
                _storeContext.Remove(item);
                
                await _storeContext.SaveChangesAsync();
            }
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _storeContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var item = await _storeContext.Categories.FindAsync(id);
            if (item != null)
            {
                return item;
            }
            return null;
        }
    }
}