using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductDto> AddProductAsync(ProductDtoForInsertion productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _unitOfWork.Product.AddAsync(product);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task DeleteProductAsync(int id, bool trackChanges)
        {
            var product = await _unitOfWork.Product.GetByConditionAsync(p => p.Id == id, trackChanges);
            if (product is null)
                throw new Exception("The product could not found.");

            _unitOfWork.Product.Remove(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(bool trackChanges)
        {
            var products = await _unitOfWork.Product.GetAll(trackChanges).ToListAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id, bool trackChanges)
        {
            var product = await _unitOfWork.Product.GetByConditionAsync(p => p.Id == id, trackChanges);
            if (product is null)
                throw new Exception("The product could not found");

            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateProductAsync(int id, ProductDtoForUpdate productDto, bool trackChanges)
        {
            var product = await _unitOfWork.Product.GetByConditionAsync(p => p.Id == id, trackChanges);
            if (product is null)
                throw new Exception("The product could not found");

            product = _mapper.Map<Product>(productDto);
            _unitOfWork.Product.Update(product);
        }
    }
}
