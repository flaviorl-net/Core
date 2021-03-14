using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public interface IService<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);
        ValidationResult AddWithValidation(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
    }
}
