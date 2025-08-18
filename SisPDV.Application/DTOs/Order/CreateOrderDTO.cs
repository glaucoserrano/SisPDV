namespace SisPDV.Application.DTOs.Order
{
    public class CreateOrderDTO
    {
        public string OrderNumber { get; set; } = string.Empty; // Gerado automaticamente
        public int Id { get; set; } // ID do pedido, gerado automaticamente
        public int? CustomerId { get; set; }
        public int? TableId { get; set; }
        public int? CommandId { get; set; }
        public bool IsNFCe { get; set; } = true; // padrão NFC-e
        public string Origin { get; set; } = "PDV"; // origem da tela
        public string? Notes { get; set; }
        public string Status { get; set; } = "Open"; // Status inicial do pedido, pode ser Open, Closed, Canceled
    }
}
