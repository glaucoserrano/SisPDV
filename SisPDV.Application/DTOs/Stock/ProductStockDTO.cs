namespace SisPDV.Application.DTOs.Stock
{
    public class ProductStockDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
        public decimal minQuantity { get; set; }
        public decimal maxQuantity { get; set; }
        public string? Location { get; set; }
    }
}
