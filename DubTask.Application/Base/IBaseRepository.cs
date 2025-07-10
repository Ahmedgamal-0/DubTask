using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task SaveChangesAsync();
    }
}
