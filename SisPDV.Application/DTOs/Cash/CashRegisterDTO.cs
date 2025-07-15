namespace SisPDV.Application.DTOs.Cash
{
    public class CashRegisterDTO
    {
        public int Id { get; set; }
        public int CashNumber { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public int OpeningAmount { get; set; } // Em centavos
        public decimal amount { get; set; } // em real, para exibição na tela
    }
}
