using Microsoft.EntityFrameworkCore;
using SVPT.WebAPI.Repository.Contracts;
using SVPT.WebAPI.Store.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Repository
{
    public abstract class DbRepositoryBase<T> : IDbRepositoryBase<T> where T : class
    {
        protected SVTPDbContext _dbContext;

        public DbRepositoryBase(SVTPDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public SVTPDbContext SVTPDbContext
        {
            get
            {
                return _dbContext;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool trackChanges = false)
        {
            return !trackChanges ? await _dbContext.Set<T>().AsNoTracking().ToListAsync() : await _dbContext.Set<T>().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> whereExpression, bool trackChanges = false)
        {
            return !trackChanges ? await _dbContext.Set<T>().Where(whereExpression).AsNoTracking().ToListAsync()
                : await _dbContext.Set<T>().Where(whereExpression).ToListAsync();
        }
        public async Task<IEnumerable<T>> GetByConditionIncludeAsync(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> includeExpression, bool trackChanges = false)
        {
            return !trackChanges ? await _dbContext.Set<T>().Where(whereExpression).Include(includeExpression).AsNoTracking().ToListAsync()
                : await _dbContext.Set<T>().Where(whereExpression).Include(includeExpression).ToListAsync();
        }
        public async Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges = false)
        {
            return !trackChanges ? await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression)
                : await _dbContext.Set<T>().FirstOrDefaultAsync(expression);
        }
        public async Task<bool> IsEntityExistAsync(Expression<Func<T, bool>> expression, bool trackChanges = false)
        {
            return !trackChanges ? await _dbContext.Set<T>().AsNoTracking().AnyAsync(expression)
                : await _dbContext.Set<T>().AnyAsync(expression);
        }
        public void Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }
        public void CreateBulk(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
        }
        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }
        public void DeleteBulk(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }
    }
}
