namespace SisPDV.Application.DTOs.Config.PrintSector
{
    public class PrintSectorsDTO
    {
        public int Id { get; set; }
        public string SectorName { get; set; } = string.Empty;
        public string PrinterName { get; set; } = string.Empty;
        public int NumberOfCopies { get; set; } = 1;
        public bool Active { get; set; } = true;
        public bool IsDefault { get; set; } = false;
    }
}
