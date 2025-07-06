using SisPDV.Domain.Enum;

namespace SisPDV.Application.DTOs.Product
{
    public class SearchFilterProductsDTO
    {
        public string? Description { get; set; } = string.Empty;
        public int? ProductTypeId { get; set; }
        public int? CfopId { get; set; }
        public int? Status { get; set; }
    }
}
