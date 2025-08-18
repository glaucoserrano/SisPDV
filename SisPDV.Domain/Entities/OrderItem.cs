using SisPDV.Domain.Entities.Base;

namespace SisPDV.Domain.Entities
{
    public class OrderItem : AuditableEntity
    {
        public int Id { get; set; } // PK
        public int OrderId { get; set; } // FK para Order
        public int ProductId { get; set; } // Produto vendido
        public int Quantity { get; set; } // Quantidade
        public int UnitPrice { get; set; } // Preço unitário em centavos
        public int Discount { get; set; } // Desconto do item em centavos
        public int Total { get; set; } // Total do item com desconto
        public string? Notes { get; set; } // Observações do pedido
        public string? SupplierReference { get; set; } // Código do fornecedor, se houver
        public string Origin { get; set; } = "PDV"; // Origem do pedido: PDV, Mobile, Web

        // Navegação
        public virtual Order Order { get; set; } = null!;
    }
}
