using JobTrackerApplication.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackerApplication.DAL.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly DatabaseContext _dbContext;
        public RepositoryBase(DatabaseContext dbContex)
        {
            this._dbContext = dbContex;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public IQueryable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }


    }
}
