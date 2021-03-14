using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Domain
{
    public interface IRepositoryBase<TEntity, TKey> : IDisposable where TEntity : EntityBase<TKey>
    {
        void Add(TEntity entity);
        void AddAsync(TEntity entity);

        void Remove(TEntity entity);
        void Remove(TKey id);

        void Update(TEntity entity);

        TEntity Get(TKey id);
        Task<TEntity> GetAsync(TKey id);

        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> GetAllNoTracking();

        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> predicate);

        void SaveChanges();
        void SaveChangesAsync();
    }
}
