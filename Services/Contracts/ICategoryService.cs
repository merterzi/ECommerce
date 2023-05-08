using Entities.DTOs;
using Entities.Models;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);
        Task<Category> GetCategoryByIdAsync(int id, bool trackChanges);
        Task<Category> AddCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id, bool trackChanges);
        Task UpdateCategoryAsync(int id, Category category, bool trackChanges);
    }
}
