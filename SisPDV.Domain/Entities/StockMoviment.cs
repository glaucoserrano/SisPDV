using SisPDV.Domain.Entities.Base;
using SisPDV.Domain.Enum;

namespace SisPDV.Domain.Entities
{
    public class StockMovement : AuditableEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public DateTime Date { get; set; }
        public Decimal Quantity { get; set; }
        public StockMovementType Type { get; set; } // Entrada, Saída, Ajuste
        public string? Notes { get; set; }
        public string? DocumentNumber { get; set; } // NF, Cupom etc
        public string? Origin { get; set; } // Manual, XML, Ajuste
    }

}
