using SisPDV.Domain.Enum;

namespace SisPDV.Application.DTOs.Product
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;
        public string? NCM { get; set; }
        public string? CEST { get; set; }

        public int CfopId { get; set; }
        public int? CategoryId { get; set; }
        public int? UnityId { get; set; }

        
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
    }
}
