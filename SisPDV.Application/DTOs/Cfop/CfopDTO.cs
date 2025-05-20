namespace SisPDV.Application.DTOs.Cfop
{
    public class CfopDTO
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }

        public string Display => $"{Code} - {Description}";
    }
}
