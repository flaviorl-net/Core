using System.Collections.Generic;

namespace Core.Domain
{
    public abstract class FiscalBase<TEntity> : IFiscal<TEntity> where TEntity : class
    {
        private readonly Dictionary<string, IRule<TEntity>> _validations = new Dictionary<string, IRule<TEntity>>();

        protected virtual void AddRule(string ruleName, IRule<TEntity> rule)
        {
            _validations.Add(ruleName, rule);
        }

        protected virtual void RemoveRule(string ruleName)
        {
            _validations.Remove(ruleName);
        }

        public virtual ValidationResult Validate(TEntity entity)
        {
            var result = new ValidationResult();
            foreach (var x in _validations.Keys)
            {
                var rule = _validations[x];
                if (!rule.Validate(entity))
                    result.AddError(new ValidationError(rule.ErrorMessage));
            }

            return result;
        }

        protected IRule<TEntity> GetRule(string ruleName)
        {
            IRule<TEntity> rule;
            _validations.TryGetValue(ruleName, out rule);
            return rule;
        }
    }
}
