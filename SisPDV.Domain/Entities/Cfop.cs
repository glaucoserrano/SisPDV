using SisPDV.Domain.Entities.Base;

namespace SisPDV.Domain.Entities
{
    public class Cfop : AuditableEntity
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
        public string? Notes { get; set; } = string.Empty;
    }
}
