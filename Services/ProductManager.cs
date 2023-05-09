using AutoMapper;
using Entities.DTOs;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.Extensions.Caching.Memory;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly ICategoryService _categoryService;

        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache memoryCache, ICategoryService categoryService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _memoryCache = memoryCache;
            _categoryService = categoryService;
        }

        public async Task<ProductDto> AddProductAsync(ProductDtoForInsertion productDto)
        {
            _memoryCache.Remove("products");
            _memoryCache.Remove("product");

            var category = await _categoryService.GetCategoryByIdAsync(productDto.CategoryId, false);
            var product = _mapper.Map<Product>(productDto);
            await _unitOfWork.Product.AddAsync(product);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task DeleteProductAsync(int id, bool trackChanges)
        {
            _memoryCache.Remove("products");
            _memoryCache.Remove("product");
            var product = await GetProductByIdAndCheckExistsAsync(id, trackChanges);
            _unitOfWork.Product.Remove(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task<(IEnumerable<ProductDto> products, MetaData metaData)> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges)
        {
            if (!_memoryCache.TryGetValue("products", out (IEnumerable<ProductDto> products, MetaData metaData) result))
            {
                var productsWithMetaData = await _unitOfWork.Product.GetAllProductsAsync(productParameters, trackChanges);
                var productDto = _mapper.Map<IEnumerable<ProductDto>>(productsWithMetaData);
                _memoryCache.Set<(IEnumerable<ProductDto> products,
                    MetaData metaData)>("products", (productDto, productsWithMetaData.MetaData),
                    DateTime.Now.AddMinutes(1));
            }
            result = _memoryCache.Get<(IEnumerable<ProductDto> products, MetaData metaData)>("products");
            return (result.products, result.metaData);
        }

        public async Task<IEnumerable<ProductDetailsDto>> GetAllProductsWithDetailsAsync(bool trackChanges)
        {
            var products = await _unitOfWork.Product.GetAllProductsWithDetailsAsync(trackChanges);
            var productsDto = _mapper.Map<IEnumerable<ProductDetailsDto>>(products);
            return productsDto;
        }

        public async Task<ProductDto> GetProductByIdAsync(int id, bool trackChanges)
        {
            var product = await GetProductByIdAndCheckExistsAsync(id, trackChanges);
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public async Task UpdateProductAsync(int id, ProductDtoForUpdate productDto, bool trackChanges)
        {
            _memoryCache.Remove("products");
            _memoryCache.Remove("product");

            var category = await _categoryService.GetCategoryByIdAsync(productDto.CategoryId, false);
            var product = await GetProductByIdAndCheckExistsAsync(id, trackChanges);
            product = _mapper.Map<Product>(productDto);
            _unitOfWork.Product.Update(product);
            await _unitOfWork.SaveAsync();
        }

        private async Task<Product> GetProductByIdAndCheckExistsAsync(int id, bool trackChanges)
        {
            var product = await _unitOfWork.Product.GetByConditionAsync(p => p.Id == id, trackChanges);
            if (product is null)
                throw new ProductNotFoundException(id);
            return product;
        }

    }
}
