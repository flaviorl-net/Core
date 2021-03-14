using System.Collections.Generic;
using System.Linq;

namespace Core.Domain
{
    public class ValidationResult
    {
        private readonly List<ValidationError> _errors = new List<ValidationError>();

        public string Message { get; set; }
        public bool IsValid { get { return _errors.Count == 0; } }
        public IEnumerable<ValidationError> Errors { get { return this._errors; } }

        public void AddError(ValidationError error)
        {
            _errors.Add(error);
        }

        public void RemoveError(ValidationError error)
        {
            if (_errors.Contains(error))
                _errors.Remove(error);
        }

        public void AddError(params ValidationResult[] validationResult)
        {
            if (validationResult == null) return;

            foreach (var itemValidationResult in validationResult.Where(result => result != null))
                this._errors.AddRange(itemValidationResult.Errors);
        }
    }
}
