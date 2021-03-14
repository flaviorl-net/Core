using Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Interfaces
{
    public interface IAppService<TEntity, TKey> where TEntity : EntityBase<TKey>
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
