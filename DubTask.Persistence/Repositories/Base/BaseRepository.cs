using DubTask.Application.Base;
using DubTask.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Persistence.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task AddAsync(T entity) =>
           await _dbSet.AddAsync(entity);

        public virtual async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync() =>
        await _dbSet.ToListAsync();

        public virtual async Task<T?> GetByIdAsync(int id) =>
            await _dbSet.FindAsync(id);

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) =>
            await _dbSet.Where(predicate).ToListAsync();
        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();

        public virtual async Task<IReadOnlyList<T>> ListAllAsync() =>
            await _dbSet.ToListAsync();
    }
}

