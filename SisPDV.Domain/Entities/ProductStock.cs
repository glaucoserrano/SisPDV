using SisPDV.Domain.Entities.Base;

namespace SisPDV.Domain.Entities
{
    public class ProductStock : AuditableEntity
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public decimal Quantity { get; set; }
        public decimal MinimumQuantity { get; set; }
        public decimal MaximumQuantity { get; set; }
        public string? Location { get; set; }
    }
}
