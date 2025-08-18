namespace SisPDV.Application.DTOs.Order
{
    public class AddOrderItemsDTO
    {
        public int OrderId { get; set; } // FK para Order
        public int ProductId { get; set; } // Produto vendido
        public int Quantity { get; set; } // Quantidade
        public int UnitPrice { get; set; } // Preço unitário em centavos
        public int Discount { get; set; } // Desconto do item em centavos
        public int Total { get; set; } // Total do item com desconto
        public int? totalAmount { get; set; }
        public int? subTotal { get; set; }
        public int? DiscountTotal { get; set; }
        public string? Notes { get; set; } // Observações do pedido
        public string Origin { get; set; } = "PDV"; 

    }
}
