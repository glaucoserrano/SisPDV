namespace SisPDV.Application.DTOs.Cash
{
    public class CashRegisterDTO
    {
        public int Id { get; set; }
        public int CashNumber { get; set; }
        public DateTimeKind OpenDate { get; set; }
        public DateTimeKind? CloseDate { get; set; }
        public int OpeningAmount { get; set; } // Em centavos
    }
}
