
using System.Linq.Expressions;

namespace Infrastructure.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<T> Get(int id);
        Task<T> Get(Expression<Func<T, bool>> predicate);
        IAsyncEnumerable<T> GetAll();
        IAsyncEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        IAsyncEnumerable<T> Pagination(int page, int pageSize);
        IAsyncEnumerable<T> Pagination(int page, int pageSize, Expression<Func<T, bool>> predicate);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
