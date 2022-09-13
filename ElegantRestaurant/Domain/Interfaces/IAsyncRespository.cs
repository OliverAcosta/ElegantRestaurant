using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAsyncRepository<T>
    {
        Task<T> Get(int id);
        Task<T> Get(Expression<Func<T, bool>> predicate);
        IAsyncEnumerable<T> GetAll();
        IAsyncEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
