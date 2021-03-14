using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public interface IServiceBase<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        void Add(TEntity entity);
        ValidationResult AddWithValidation(TEntity entity);
        void Remove(TEntity entity);
        void Remove(TKey id);
        void Update(TEntity entity);

        TEntity Get(TKey id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
    }
}
