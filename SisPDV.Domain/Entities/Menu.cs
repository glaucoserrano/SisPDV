using SisPDV.Domain.Entities.Base;

namespace SisPDV.Domain.Entities
{
    public class Menu : AuditableEntity
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? FormName { get; set; } = string.Empty ;
        public int Order { get; set; }
        public bool Visible { get; set; } = true;

        public Menu? Parent { get; set; }
        public ICollection<Menu>? Children { get; set; }
    }
}
