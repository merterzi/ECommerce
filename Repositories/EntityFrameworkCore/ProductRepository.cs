using Entities;
using Repositories.Context;
using Repositories.Contracts;

namespace Repositories.EntityFrameworkCore
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
