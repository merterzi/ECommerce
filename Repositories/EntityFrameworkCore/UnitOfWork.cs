using Repositories.Context;
using Repositories.Contracts;

namespace Repositories.EntityFrameworkCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceDbContext _context;

        public UnitOfWork(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
