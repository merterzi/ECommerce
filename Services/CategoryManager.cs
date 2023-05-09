using AutoMapper;
using Entities.DTOs;
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

        public async Task<CategoryDto> AddCategoryAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _unitOfWork.Category.AddAsync(category);
            await _unitOfWork.SaveAsync();
            return categoryDto;
        }

        public async Task DeleteCategoryAsync(int id, bool trackChanges)
        {
            var category = await GetByCategoryIdAndCheckExistsAsync(id, trackChanges);
            _unitOfWork.Category.Remove(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges)
        {
            var categories = await _unitOfWork.Category.GetAll(trackChanges).ToListAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<IEnumerable<CategoryDetailsDto>> GetAllCategoriesWithDetailsAsync(bool trackChanges)
        {
            var categories = await _unitOfWork.Category.GetAllCategoriesWithDetailsAsync(trackChanges);
            return _mapper.Map<IEnumerable<CategoryDetailsDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id, bool trackChanges)
        {
            var category = await GetByCategoryIdAndCheckExistsAsync(id, trackChanges);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task UpdateCategoryAsync(int id, CategoryDto categoryDto, bool trackChanges)
        {
            var category = await GetByCategoryIdAndCheckExistsAsync(id, trackChanges);
            category = _mapper.Map<Category>(categoryDto);
            _unitOfWork.Category.Update(category);
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
