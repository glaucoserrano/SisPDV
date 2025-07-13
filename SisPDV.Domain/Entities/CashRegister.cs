using SisPDV.Domain.Entities.Base;

namespace SisPDV.Domain.Entities
{
    public class CashRegister : AuditableEntity
    {
        public int Id { get; set; }
        public int cashNumber { get; set; } // Número do Caixa
        public DateTimeKind openingDateTime { get; set; } // Data e hora de abertura do caixa
        public DateTimeKind closingDateTime { get; set; } // Data e hora de fechamento do caixa
        public int openingAmount { get; set; } // Valor de abertura do caixa -- em centavos
        public int closingAmount { get; set; } // Valor de fechamento do caixa -- em centavos
        public bool IsOpen { get; set; } = true; // Indica se o caixa está aberto ou fechado
    }
}
