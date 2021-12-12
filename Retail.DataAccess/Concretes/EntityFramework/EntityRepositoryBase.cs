using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Retail.DataAccess.Concretes.EntityFramework;
using Retail.DataAccess.Interfaces;
using Retail.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Retail.DataAcces.Conretes.EntityFramework
{
    public class EntityRepositoryBase<TEntity,TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                await context.AddAsync(entity);
                var result = await context.SaveChangesAsync();
                
                return entity;
            }
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Remove(entity);
                var result = await context.SaveChangesAsync();
                return result > 0 ? true : false;
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                var result = await context.Set<TEntity>().SingleOrDefaultAsync(filter);
                return result;
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                var result =  filter == null
                    ? await context.Set<TEntity>().ToListAsync()
                    : await context.Set<TEntity>().Where(filter).ToListAsync();
                return result;
            }
               
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<bool> DeleteByIdAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Attach(entity);
                context.Remove(entity);
                var result = context.SaveChangesAsync();
                return await result > 0 ? true : false;
            }
        }

        public async Task<bool> DeleteMultipleRowsAsync(List<TEntity> entities)
        {
            using (TContext context =  new TContext())
            {
                context.RemoveRange(entities);
                var result = context.SaveChangesAsync();
                return await result > 0 ? true : false;
            }
        }
    }
}
