namespace SisPDV.Application.DTOs.PrinterSector
{
    public class PrinterSectorsDTO
    {
        public string SectorName { get; set; } = string.Empty;
        public string PrinterName { get; set; } = string.Empty;
        public int NumberOfCopies { get; set; } = 1;
        public bool Active { get; set; } = true;
        public bool IsDefault { get; set; } = false;
    }
}
