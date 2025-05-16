using SisPDV.Domain.Entities.Base;
using SisPDV.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace SisPDV.Domain.Entities
{
    public class ProductTypes : AuditableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Type { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? NCM { get; set; }

        public decimal? IVA { get; set; }

        [MaxLength(10)]
        public string? CFOP { get; set; }

        public ProductOrigin? Origin { get; set; }
        public CSOSN? CST_CSOSN { get; set; }
        public CST_ICMS? CST_ICMS { get; set; }
        public CST_PIS? CST_PIS { get; set; }
        public CST_COFINS? CST_COFINS { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; }
    }
}
