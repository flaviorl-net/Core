using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class ServiceBase<TEntity, TKey> : IDisposable, IServiceBase<TEntity, TKey>
        where TEntity : EntityBase<TKey>
    {
        private readonly IRepositoryBase<TEntity, TKey> _repository;
        public ServiceBase(IRepositoryBase<TEntity, TKey> repository) => _repository = repository;

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
            _repository.SaveChanges();
        }
        
        public void Remove(TKey id)
        {
            _repository.Remove(id);
            _repository.SaveChanges();
        }
        
        public void Dispose()
        {
            _repository.Dispose();
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
            _repository.SaveChanges();
        }
        
        public void Add(TEntity entity)
        {
            _repository.Add(entity);
            _repository.SaveChanges();
        }
        
        public ValidationResult AddWithValidation(TEntity entity)
        {
            var validation = entity.IsValid();
            if (validation.IsValid)
            {
                _repository.Add(entity);
                _repository.SaveChanges();
                return validation;
            }
            return validation;
        }

        public TEntity Get(TKey id) =>
            _repository.Get(id);

        public IEnumerable<TEntity> GetAll() =>
            _repository.GetAll();

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate) =>
            _repository.Get(predicate);
    }
}
