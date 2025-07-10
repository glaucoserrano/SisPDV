namespace SisPDV.Application.DTOs.Stock
{
    public class ProductStockSearchDTO
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public string SupplierCode { get; set; } = string.Empty;
    }
}
