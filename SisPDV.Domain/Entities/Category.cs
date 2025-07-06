using SisPDV.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace SisPDV.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(60)]
        public string Description { get; set; } = string.Empty;

        public bool Active { get; set; } = true;
    }
}
