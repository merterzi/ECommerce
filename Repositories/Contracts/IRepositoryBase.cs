    using Entities;
using System.Linq.Expressions;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>
        where T : BaseEntity, new()
    {
        IQueryable<T> GetAll(bool trackChanges);
        IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> filter, bool trackChanges);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
