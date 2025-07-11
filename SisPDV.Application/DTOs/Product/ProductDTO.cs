using SisPDV.Domain.Enum;

namespace SisPDV.Application.DTOs.Product
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public bool Active { get; set; }

        public int ProductTypeId { get; set; }
        public string ProductType { get; set; } = string.Empty;
        public string? NCM { get; set; }
        public string? CEST { get; set; }

        public int? CfopId { get; set; }
        public string Cfop { get; set; } = string.Empty;
        public int? CategoryId { get; set; }
        public int? UnityId { get; set; }
        public string Unity { get; set; } = string.Empty;

        
        public string? Notes { get; set; }

        // Preços (em reais, convertidos para centavos ao salvar)
        public decimal? CostPrice { get; set; }
        public decimal? Price { get; set; }
        public decimal? ProfitMargin { get; set; }

        // Estoque
        public bool UseStockControl { get; set; }
        public bool AllowZeroStockSale { get; set; }
        public string? StockLocation { get; set; }

        // Impressora setor
        public bool PrintInSector { get; set; }
        public int? SectorPrinterId { get; set; }

        // Imagem
        public string? ImagePath { get; set; }

        public bool Weighing { get; set; } 
        public bool Fractional { get; set; } 
        public bool Service { get; set; }
        public string RefSupplier { get; set; } = string.Empty;
        public decimal? minQuantity { get; set; }
        public decimal? maxQuantity { get; set; }
        public string? Location { get; set; } = string.Empty;
        public decimal? Stock { get; set; }

    }
}
