using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            await _unitOfWork.Category.AddAsync(category);
            await _unitOfWork.SaveAsync();
            return category;
        }

        public async Task DeleteCategoryAsync(int id, bool trackChanges)
        {
            var category = await GetByCategoryIdAndCheckExistsAsync(id, trackChanges);
            _unitOfWork.Category.Remove(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
        {
            return await _unitOfWork.Category.GetAll(trackChanges).ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id, bool trackChanges)
        {
            var category = await GetByCategoryIdAndCheckExistsAsync(id, trackChanges);
            return category;
        }

        public async Task UpdateCategoryAsync(int id, Category category, bool trackChanges)
        {
            var entity = await GetByCategoryIdAndCheckExistsAsync(id, trackChanges);
            _mapper.Map(entity, category);
            _unitOfWork.Category.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        private async Task<Category> GetByCategoryIdAndCheckExistsAsync(int id, bool trackChanges)
        {
            var category = await _unitOfWork.Category.GetByConditionAsync(c => c.Id == id, trackChanges);
            if (category is null)
                throw new CategoryNotFoundException(id);
            return category;
        }
    }
}
