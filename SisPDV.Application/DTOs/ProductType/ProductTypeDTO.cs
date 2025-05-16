using SisPDV.Domain.Enum;

namespace SisPDV.Application.DTOs.ProductType
{
    public class ProductTypeDTO
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string? NCM { get; set; }
        public decimal? IVA { get; set; }
        public string? CFOP { get; set; }
        public ProductOrigin? Origin { get; set; }
        public CSOSN? CST_CSOSN { get; set; }
        public CST_ICMS? CST_ICMS { get; set; }
        public CST_PIS? CST_PIS { get; set; }
        public CST_COFINS? CST_COFINS { get; set; }
        public string? Notes { get; set; }
        public TaxRegime? TaxRegime { get; set; }

    }
}
