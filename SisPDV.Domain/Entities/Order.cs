using SisPDV.Domain.Entities.Base;

namespace SisPDV.Domain.Entities
{
    public class Order : AuditableEntity
    {
        public int Id { get; set; } // PK
        public string OrderNumber { get; set; } = string.Empty;// Número do pedido no PDV
        public string? NFCeNumber { get; set; } // Número da NFC-e emitida, se houver
        public int? CustomerId { get; set; } // Cliente vinculado (nullable)
        public int? TableId { get; set; } // Mesa, se houver
        public int? CommandId { get; set; } // Comanda, se houver
        public int SubTotal { get; set; } // Subtotal em centavos
        public int DiscountAmount { get; set; } // Desconto total em centavos
        public int TotalAmount { get; set; } // Total final em centavos
        public string Status { get; set; } = "Open"; // Ex: Open, Closed, Canceled
        public bool IsNFCe { get; set; } // True se for NFC-e, False se NF-e
        public string? Notes { get; set; } // Observações do pedido
        public int? PaymentMethodId { get; set; } // Forma de pagamento, preenchido no fechamento
        public DateTime? ClosedAt { get; set; } // Data de fechamento, nullable
        public string Origin { get; set; } = "PDV"; // Origem do pedido: PDV, Mobile, Web

        // Navegação
        public virtual ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        public virtual PaymentMethod? PaymentMethod { get; set; } // Navegação para a forma de pagamento
    }
}
