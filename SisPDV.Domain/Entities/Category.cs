using SisPDV.Domain.Entities.Base;

namespace SisPDV.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
