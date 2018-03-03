

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Events.Repository.Interfaces
{
   
        public interface IRepository<TEntity, in TPk> where TEntity : class
        {
            List<TEntity> GetAll();
            List<TEntity> GetAllWithInclude(params string[] paths);
            List<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate, params string[] paths);
            TEntity Get(TPk id);
            List<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
            void Add(TEntity entity);
            void Remove(TEntity entity);
            void Update(TEntity entity);
            void RemoveRange(List<TEntity> entities);
            EntityState GetState(TEntity entity);
            void SetState(TEntity entity, EntityState entityState);
            int GetCount();
        }
   
}
