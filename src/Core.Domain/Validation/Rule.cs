using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class Rule<TEntity> : IRule<TEntity>
    {
        private readonly ISpecification<TEntity> _specificationRule;
        public string ErrorMessage { get; private set; }

        public Rule(ISpecification<TEntity> rule, string errorMessage)
        {
            this._specificationRule = rule;
            this.ErrorMessage = errorMessage;
        }

        public bool Validate(TEntity entity)
        {
            return this._specificationRule.IsSatisfiedBy(entity);
        }
    }
}
