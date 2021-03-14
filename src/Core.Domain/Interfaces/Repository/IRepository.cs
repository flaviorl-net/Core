using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity entity);
        void AddAsync(TEntity entity);

        void Remove(TEntity entity);
        
        void Update(TEntity entity);

        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> GetAllNoTracking();

        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> predicate);

        void SaveChanges();
        void SaveChangesAsync();
    }
}
