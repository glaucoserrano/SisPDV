using SisPDV.Domain.Entities.Base;

namespace SisPDV.Domain.Entities
{
    public class CashRegister : AuditableEntity
    {
        public int Id { get; set; }
        public int cashNumber { get; set; } // Número do Caixa
        public DateTime openingDateTime { get; set; } // Data e hora de abertura do caixa
        public DateTime closingDateTime { get; set; } // Data e hora de fechamento do caixa
        public int openingAmount { get; set; } // Valor de abertura do caixa -- em centavos
        public int? ClosingInformedAmount { get; set; } // Valor informado no fechamento (centavos)
        public int? ClosingExpectedAmount { get; set; } // Valor calculado pelo sistema (centavos)
        public int? ClosingDifferenceAmount { get; set; } // Diferença (informado - esperado)
        public bool IsOpen { get; set; } = true; // Indica se o caixa está aberto ou fechado
    }
}
