using SisPDV.Domain.Entities.Base;

namespace SisPDV.Domain.Entities
{
    public class User : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public bool Active { get; set; } = false;

    }
}
