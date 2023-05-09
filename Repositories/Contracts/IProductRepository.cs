using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<PagedList<Product>> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges);
        Task<IEnumerable<Product>> GetAllProductsWithDetailsAsync(bool trackChanges);
    }
}
