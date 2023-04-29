using Entities.Models;

namespace Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges);
        Task<Product> GetProductByIdAsync(int id, bool trackChanges);
        Task<Product> AddProductAsync(Product product);
        Task DeleteProductAsync(int id, bool trackChanges);
        Task UpdateProductAsync(int id, Product product, bool trackChanges);
    }
}
