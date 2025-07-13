using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.Stock;
using SisPDV.Domain.Entities;
using SisPDV.Domain.Enum;
using SisPDV.Infrastructure.Persistence;

namespace SisPDV.Application.Services
{
    public class StockManager
    {
        private readonly PDVDbContext _context;

        public StockManager(PDVDbContext context)
        {
            _context = context;
        }
        public async Task<decimal> ApplyMovementAsync(StockMovementDTO request)
        {
            var productStock = await _context.productStock
                .FirstOrDefaultAsync(p => p.ProductId == request.ProductId);

            if (productStock == null)
            {
                productStock = new ProductStock
                {
                    ProductId = request.ProductId,
                    MinimumQuantity = 0,
                    MaximumQuantity = 0,
                    Location = string.Empty,
                    Quantity = 0
                };

                await _context.productStock.AddAsync(productStock);
            }

            var newQty = request.Type switch
            {
                StockMovementType.Entry => productStock.Quantity + request.Quantity,
                StockMovementType.Exit => productStock.Quantity - request.Quantity,
                StockMovementType.Adjustment => request.Quantity,
                _ => productStock.Quantity
            };

            productStock.Quantity = newQty;

            var movement = new StockMovement
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                Type = request.Type,
                Notes = request.Notes,
                Origin = request.Origin,
                DocumentNumber = request.DocumentNumber,
                Date = DateTime.SpecifyKind(request.Date, DateTimeKind.Utc),
            };

            await _context.stockMovements.AddAsync(movement);

            return newQty;
        }

    }
}
