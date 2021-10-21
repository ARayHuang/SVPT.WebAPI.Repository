using SVPT.WebAPI.Store.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Repository.Contracts
{
    public interface IDbRepositoryBase<T>
    {
        SVTPDbContext SVTPDbContext { get;  }
        Task<IEnumerable<T>> GetAllAsync(bool trackChanges);
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges);
        Task<IEnumerable<T>> GetByConditionIncludeAsync(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> includeExpression, bool trackChanges = false);
        Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges);
        Task<bool> IsEntityExistAsync(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void CreateBulk(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void DeleteBulk(IEnumerable<T> entities);
    }
}
