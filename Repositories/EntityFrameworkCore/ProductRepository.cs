using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Contracts;

namespace Repositories.EntityFrameworkCore
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ECommerceDbContext context) : base(context)
        {
        }

        public async Task<PagedList<Product>> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges)
        {
            var products = await GetAll(trackChanges).ToListAsync();
            return PagedList<Product>.ToPagedList(products, productParameters.PageNumber, productParameters.PageSize);
        }
    }
}
