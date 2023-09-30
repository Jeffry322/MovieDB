using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class, IAggregateRoot
    {
        Task<T> GetByIdAsync(int id);
        Task<T> FirstOrDeffaultAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> ListAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
