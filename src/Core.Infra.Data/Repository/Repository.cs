using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Infra
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TContext : DbContext
        where TEntity : Entity
    {
        public readonly TContext _context;
        public Repository(TContext context) => _context = context;

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
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
