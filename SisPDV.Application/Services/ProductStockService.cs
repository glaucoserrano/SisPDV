using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.Stock;
using SisPDV.Application.DTOs.Validation;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Entities;
using SisPDV.Infrastructure.Persistence;

namespace SisPDV.Application.Services
{
    public class ProductStockService : IProductStockService
    {
        private readonly PDVDbContext _context;

        public ProductStockService(PDVDbContext context)
        {
            _context = context;
        }

        public async Task<ProductStockDTO> GetByProductIdAsync(int ProductId)
        {
            var productStock = await _context
                .productStock.AsNoTracking()
                .Include(p => p.Product)
                .FirstOrDefaultAsync(p => p.ProductId == ProductId);
            if (productStock == null)
                return new ProductStockDTO();

            return new ProductStockDTO
            {
                Id = productStock.Id,
                ProductId = productStock.ProductId,
                minQuantity = productStock.MinimumQuantity,
                maxQuantity = productStock.MaximumQuantity,
                Location = productStock.Location,
                ProductDescription = productStock.Product.Description,
            };
        }

        public async Task<List<ProductStockDTO>> GetProductStockAsync()
        {
            var result = await _context.productStock
                .Include(ps => ps.Product)
                .OrderBy(ps => ps.Product.Description)
                .Select(ps => new ProductStockDTO
                {
                    Id = ps.Id,
                    ProductId = ps.ProductId,
                    ProductDescription = ps.Product.Description,
                    minQuantity = ps.MinimumQuantity,
                    maxQuantity = ps.MaximumQuantity,
                    Location = ps.Location
                })
            .ToListAsync();

            return result;
        }

        public async Task SaveAsync(ProductStockDTO request)
        {
            using var transactions = await _context.Database.BeginTransactionAsync();

            try
            {
                var existingProductStock = await _context.productStock.FindAsync(request.Id);

                if (existingProductStock == null)
                {
                    // Novo cadastro
                    var newProductStock = new ProductStock
                    {
                        ProductId = request.ProductId,
                        MinimumQuantity = request.minQuantity,
                        MaximumQuantity = request.maxQuantity,
                        Location = request.Location
                    };
                    await _context.productStock.AddAsync(newProductStock);
                }
                else
                {
                    existingProductStock.Location = request.Location;
                    existingProductStock.MaximumQuantity = request.maxQuantity;
                    existingProductStock.MinimumQuantity = request.minQuantity;

                    _context.productStock.Update(existingProductStock);
                }
                await _context.SaveChangesAsync();
                await transactions.CommitAsync();
            }
            catch
            {
                await transactions.RollbackAsync();
                throw;
            }
        }

        public Task<ValidationResults> ValidateAsync(ProductStockDTO request)
        {
            var errors = new List<string>();

            if (request.ProductId == 0)
                errors.Add("É necessário selecionar um produto");


            var result = new ValidationResults
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };

            return Task.FromResult(result);
        }
        public async Task<List<ProductStockDTO>> SearchAsync(string search)
        {
            var query = _context.productStock
                .Include(ps => ps.Product)
                .Where(ps => ps.Product.UseStockControl);

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(ps =>
                    ps.Product.Description.ToLower().Contains(search.ToLower()) ||
                    ps.Product.Barcode!.ToLower().Contains(search.ToLower()) ||
                    ps.Product.RefSupplier!.ToLower().Contains(search.ToLower()) ||
                    ps.Product.Id.ToString() == search
                );
            }

            var result = await query
                .OrderBy(p => p.Product.Description)
                .Select(ps => new ProductStockDTO
                {
                    Id = ps.Id,
                    ProductId = ps.ProductId,
                    ProductDescription = ps.Product.Description,
                    minQuantity = ps.MinimumQuantity,
                    maxQuantity = ps.MaximumQuantity,
                    Location = ps.Location
                })
                .ToListAsync();

            return result;
        }
    }
}
