namespace SisPDV.Infrastructure.Globals
{
    public static class CashRegisterStatus
    {
        public static bool IsOpen { get; set; }
        public static int? CashRegisterId { get; set; }
        public static DateTimeKind? OpenDate { get; set; }
        public static int CashNumber { get; set; }
        public static string StatusMessage { get; set; } = "Não verificado.";
    }
}
