using Entities.Models;
using System.Linq.Expressions;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>
        where T : BaseEntity, new()
    {
        IQueryable<T> GetAll(bool trackChanges);
        IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> filter, bool trackChanges);
        Task<T> GetByConditionAsync(Expression<Func<T, bool>> filter, bool trackChanges);
        Task AddAsync(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
