using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Service<TEntity> : IDisposable, IService<TEntity>
        where TEntity : Entity
    {
        private readonly IRepository<TEntity> _repository;
        public Service(IRepository<TEntity> repository) => _repository = repository;

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
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

        public IEnumerable<TEntity> GetAll() =>
            _repository.GetAll();

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate) =>
            _repository.Get(predicate);
    }
}
