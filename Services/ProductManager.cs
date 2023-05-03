using AutoMapper;
using Entities.DTOs;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
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
            var product = await GetProductByIdAndCheckExistsAsync(id, trackChanges);
            _unitOfWork.Product.Remove(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task<(IEnumerable<ProductDto> products, MetaData metaData)> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges)
        {
            var productsWithMetaData = await _unitOfWork.Product.GetAllProductsAsync(productParameters, trackChanges);
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(productsWithMetaData);
            return (productDto, productsWithMetaData.MetaData);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id, bool trackChanges)
        {
            var product = await GetProductByIdAndCheckExistsAsync(id, trackChanges);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateProductAsync(int id, ProductDtoForUpdate productDto, bool trackChanges)
        {
            var product = await GetProductByIdAndCheckExistsAsync(id, trackChanges);
            product = _mapper.Map<Product>(productDto);
            _unitOfWork.Product.Update(product);
            await _unitOfWork.SaveAsync();
        }

        private async Task<Product> GetProductByIdAndCheckExistsAsync(int id, bool trackChanges)
        {
            var product = await _unitOfWork.Product.GetByConditionAsync(p => p.Id == id, trackChanges);
            if (product is null)
                throw new ProductNotFoundException();
            return product;
        }
    }
}
