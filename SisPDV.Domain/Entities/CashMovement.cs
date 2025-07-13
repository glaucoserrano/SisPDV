using SisPDV.Domain.Entities.Base;

namespace SisPDV.Domain.Entities
{
    public class CashMovement : AuditableEntity
    {
        public int Id { get; set; }
        public int? CashRegisterId { get; set; } // Foreign key to CashRegister
        public DateTime MovementDateTime { get; set; } = DateTime.UtcNow;// Data e hora do movimento
        public int Type { get; set; } // Tipo do movimento (1 - Abertura, 2 - Fechamento, 3 - Entrada, 4 - Saída, 5 - Venda)
        public int Amount { get; set; } // Valor do movimento -- em centavos
        public string Description { get; set; } = string.Empty; // Descrição do movimento
        public string Origin { get; set; } = string.Empty; // Indica tela da movimentação
        public int? paymentMethodId { get; set; } // Foreign key to PaymentMethod

        // Navigation property
        public virtual CashRegister? CashRegister { get; set; } // Caixa associado ao movimento
        public virtual PaymentMethod? PaymentMethod { get; set; } // Método de pagamento associado ao movimento
    }
}
