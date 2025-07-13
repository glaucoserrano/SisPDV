using SisPDV.Domain.Enum;

namespace SisPDV.Application.DTOs.Stock
{
    public class StockMovementDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal StockQuantity { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public StockMovementType Type { get; set; }
        public string TypeDescription { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public DateTime Date { get; set; } // Opcional, pode ser null e preenchido no serviço
    }
}
