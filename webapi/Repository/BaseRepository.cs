using System;
using System.Collections.Generic;
using System.Linq;

namespace webapi.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity:class
    {
        protected IList<TEntity> _entities;

        public BaseRepository(IList<TEntity> entities)
        {
            _entities = entities;
        }

        public void Delete(Func<TEntity, bool> function)
        {
            var entities =  Get(function);
            entities.ToList().ForEach(x =>
            {
                _entities.Remove(x); 
            });
            
        }
        public void Update(Predicate<TEntity> function,TEntity entity)
        {
            var index = _entities.ToList().FindIndex(function);
            _entities[index] = entity;

        }

        public IEnumerable<TEntity> Get()
        {
            return _entities;
        }
        public IEnumerable<TEntity> Get(Func<TEntity,bool> function)
        {
            return _entities.ToList().Where(function).ToList();
        }

        public void Insert(TEntity entity)
        {
            _entities.Add(entity);
        }
    }
}
