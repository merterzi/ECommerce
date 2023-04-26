using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Contracts;
using System.Linq.Expressions;

namespace Repositories.EntityFrameworkCore
{
    public class RepositoryBase<T> : IRepositoryBase<T>
        where T : BaseEntity, new()
    {
        private readonly ECommerceDbContext _context;

        public RepositoryBase(ECommerceDbContext context)
        {
            _context = context;
        }

        public void Add(T entity) => _context.Set<T>().Add(entity);

        public IQueryable<T> GetAll(bool trackChanges) =>
            !trackChanges
            ? _context.Set<T>().AsNoTracking()
            : _context.Set<T>();

        public IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> filter, bool trackChanges) =>
            !trackChanges
            ? _context.Set<T>().Where(filter).AsNoTracking()
            : _context.Set<T>().Where(filter);

        public void Remove(T entity) => _context.Set<T>().Remove(entity);

        public void Update(T entity) => _context.Set<T>().Update(entity);
    }
}
