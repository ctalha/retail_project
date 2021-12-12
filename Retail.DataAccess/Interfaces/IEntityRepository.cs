using Retail.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Retail.DataAccess.Interfaces
{
    public interface IEntityRepository<TEntity>
        where TEntity : class,IEntity, new()
    {
        public Task<TEntity> AddAsync(TEntity entity);
        public Task<TEntity> UpdateAsync(TEntity entity);
        public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        public Task<bool> DeleteAsync(TEntity entity);
        public Task<bool> DeleteByIdAsync(TEntity entity);
        public Task<bool> DeleteMultipleRowsAsync(List<TEntity> entities);
    }
}
