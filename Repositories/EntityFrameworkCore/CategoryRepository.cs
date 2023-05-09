using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Contracts;

namespace Repositories.EntityFrameworkCore
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ECommerceDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesWithDetailsAsync(bool trackChanges) =>
            !trackChanges
            ? await _context.Categories.Include(c => c.Products).AsNoTracking().ToListAsync()
            : await _context.Categories.Include(c => c.Products).ToListAsync();


    }
}
