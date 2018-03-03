using Events.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;

namespace Events.Repository.Bases
{
    public abstract class RepositoryBase<TEntity, TPk> : IRepository<TEntity, TPk> where TEntity : class
    {


        public readonly DbContextBase _dbContext;

        public RepositoryBase(DbContextBase dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public List<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where<TEntity>(predicate).ToList();

        }

        public TEntity Get(TPk id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }
        

        public List<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }
        public List<TEntity> GetAllWithInclude(params String[] paths)
        {
            DbQuery<TEntity> list = null;
            for (int i = 0; i < paths.Length; i++)
            {
                list = _dbContext.Set<TEntity>().Include(paths[i]);
            }
            return list.ToList();
        }

        public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(List<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public EntityState GetState(TEntity entity)
        {
            return _dbContext.Entry<TEntity>(entity).State;
        }



        public void SetState(TEntity entity, EntityState entityState)
        {
            _dbContext.Entry<TEntity>(entity).State = entityState;
        }

        public int GetCount()
        {
            return _dbContext.Set<TEntity>().Count();
        }

        public void Update(TEntity entity)
        {
            SetState(entity, EntityState.Modified);

        }

        public List<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate, params string[] paths)
        {
            IQueryable<TEntity> list = _dbContext.Set<TEntity>().Where(predicate);
            for (int i = 0; i < paths.Length; i++)
            {
                list = list.Include(paths[i]);
            }
            return list.ToList();
        }

       
    }

}
