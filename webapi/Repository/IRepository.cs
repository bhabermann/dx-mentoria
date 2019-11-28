using System;
using System.Collections.Generic;

namespace webapi.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> function);
        void Insert(TEntity entity);
        void Update(Predicate<TEntity> function, TEntity entity);
        void Delete(Func<TEntity, bool> function);
    }
}
