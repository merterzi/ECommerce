using Entities.DTOs;
using Entities.RequestFeatures;

namespace Services.Contracts
{
    public interface IProductService
    {
        Task<(IEnumerable<ProductDto> products, MetaData metaData)> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges);
        Task<ProductDto> GetProductByIdAsync(int id, bool trackChanges);
        Task<ProductDto> AddProductAsync(ProductDtoForInsertion productDto);
        Task DeleteProductAsync(int id, bool trackChanges);
        Task UpdateProductAsync(int id, ProductDtoForUpdate productDto, bool trackChanges);
        Task<IEnumerable<ProductDto>> GetAllProductsWithDetails(bool trackChanges);
    }
}
