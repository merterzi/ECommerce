using Entities.DTOs;
using Entities.Models;

namespace Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(bool trackChanges);
        Task<ProductDto> GetProductByIdAsync(int id, bool trackChanges);
        Task<ProductDto> AddProductAsync(ProductDtoForInsertion productDto);
        Task DeleteProductAsync(int id, bool trackChanges);
        Task UpdateProductAsync(int id, ProductDtoForUpdate productDto, bool trackChanges);
    }
}
