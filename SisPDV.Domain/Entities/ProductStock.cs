namespace SisPDV.Domain.Entities
{
    public class ProductStock
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public decimal Quantity { get; set; }
        public decimal MinimumQuantity { get; set; }
        public decimal MaximumQuantity { get; set; }

        public string? Location { get; set; }

        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }
}
