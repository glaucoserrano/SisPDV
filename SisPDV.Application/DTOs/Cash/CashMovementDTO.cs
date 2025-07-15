namespace SisPDV.Application.DTOs.Cash
{
    public class CashMovementDTO
    {
        public int CashRegisterId { get; set; }
        public int Type { get; set; } // 3 - Suprimento, 4 - Sangria
        public int Amount { get; set; } // em centavos
        public string Description { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public int? PaymentMethodId { get; set; }
    }
}
