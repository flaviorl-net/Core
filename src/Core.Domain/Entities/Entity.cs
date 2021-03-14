using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public abstract class Entity : ISelfValidator
    {
        [NotMapped]
        public ValidationResult ValidationResult { get; private set; }

        public abstract ValidationResult IsValid();
    }
}
