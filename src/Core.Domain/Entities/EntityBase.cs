using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public abstract class EntityBase<TKey> : ISelfValidator
    {
        [Key]
        public TKey Id { get; set; }
        
        [NotMapped]
        public ValidationResult ValidationResult { get; private set; }

        public abstract ValidationResult IsValid();
    }
}
