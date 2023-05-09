using Entities.DTOs;
using Entities.Models;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges);
        Task<CategoryDto> GetCategoryByIdAsync(int id, bool trackChanges);
        Task<CategoryDto> AddCategoryAsync(CategoryDto categoryDto);
        Task DeleteCategoryAsync(int id, bool trackChanges);
        Task UpdateCategoryAsync(int id, CategoryDto categoryDto, bool trackChanges);
        Task<IEnumerable<CategoryDetailsDto>> GetAllCategoriesWithDetailsAsync(bool trackChanges);
    }
}
