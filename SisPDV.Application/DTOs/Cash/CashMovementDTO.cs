using SisPDV.Application.DTOs.PaymentMethod;
using SisPDV.Domain.Enum;

namespace SisPDV.Application.DTOs.Cash
{
    public class CashMovementDTO
    {
        public int Id { get; set; }
        public int? CashRegisterId { get; set; }
        public CashMovementType Type { get; set; } // 3 - Suprimento, 4 - Sangria
        public int Amount { get; set; } // em centavos
        public string Description { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public int? PaymentMethodId { get; set; }
        public DateTime MovementDateTime { get; set; } = DateTime.UtcNow;
        public PaymentMethodDTO? PaymentMethod { get; set; }
    }
}
