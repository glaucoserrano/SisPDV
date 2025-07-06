using SisPDV.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisPDV.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;
        public string? Barcode { get; set; }

        public int ProductTypeId { get; set; }
        public ProductTypes ProductType { get; set; } = null!;

        public int? UnityId { get; set; }
        public Unity Unity { get; set; } = null!;

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public string? NCM { get; set; }
        public string? CEST { get; set; }

        public int? CfopId { get; set; }
        public Cfop? Cfop { get; set; }

        public int? Price { get; set; }
        public int? CostPrice { get; set; }
        public decimal? MarginProfit { get; set; }

        public bool Active { get; set; } = true;

        public bool UsePrinterSector { get; set; }
        public int? PrinterSectorId { get; set; }
        
        [ForeignKey("PrinterSectorId")]
        public PrintSector? PrinterSector { get; set; }

        public string? ImagePath { get; set; }

        public string? Notes { get; set; }

        // Configurações específicas
        public bool UseStockControl { get; set; } = true;
        public bool AllowZeroStockSale { get; set; } = false;

        public bool Weighing { get; set; } 
        public bool Fractional { get; set; } 
        public bool Service { get; set; } 
        public string RefSupplier { get; set; } = string.Empty;
    }
}
