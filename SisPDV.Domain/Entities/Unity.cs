using SisPDV.Domain.Entities.Base;

namespace SisPDV.Domain.Entities
{
    public class Unity : AuditableEntity
    {
        public int Id { get; set; }
        public string Acronym { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
