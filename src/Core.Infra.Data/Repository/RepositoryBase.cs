using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Infra
{
    public class RepositoryBase<TEntity, TContext, TKey> : IRepositoryBase<TEntity, TKey>
        where TContext : DbContext
        where TEntity : EntityBase<TKey>
    {
        public readonly TContext _context;
        public RepositoryBase(TContext context) => _context = context;

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        
        public void Remove(TKey id)
        {
            var entityToDelete = _context.Set<TEntity>().FirstOrDefault(e => e.Id.Equals(id));
            if (entityToDelete != null)
            {
                _context.Set<TEntity>().Remove(entityToDelete);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().AddAsync(entity);
        }

        public TEntity Get(TKey id)
        {
            return _context.Set<TEntity>().FirstOrDefault(e => e.Id.Equals(id));
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAllNoTracking()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).AsQueryable().ToListAsync();
        }
        
        public void SaveChanges() => _context.SaveChanges();

        public void SaveChangesAsync() => _context.SaveChangesAsync();

    }
}
