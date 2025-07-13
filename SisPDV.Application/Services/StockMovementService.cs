using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.Stock;
using SisPDV.Application.DTOs.Validation;
using SisPDV.Application.Helper;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Entities;
using SisPDV.Domain.Enum;
using SisPDV.Infrastructure.Persistence;

namespace SisPDV.Application.Services
{
    public class StockMovementService : IStockMovementService
    {
        private readonly PDVDbContext _context;
        private readonly StockManager _stockManager;

        public StockMovementService(PDVDbContext context)
        {
            _context = context;
            _stockManager = new StockManager(context);
        }

        public async Task SaveAsync(StockMovementDTO request)
        {
            using var transactions = await _context.Database.BeginTransactionAsync();

            try
            {
                await _stockManager.ApplyMovementAsync(request);
                await _context.SaveChangesAsync();
                await transactions.CommitAsync();
            }
            catch
            {
                await transactions.RollbackAsync();
                throw;
            }
        }

        public Task<ValidationResults> ValidateAsync(StockMovementDTO request)
        {
            var errors = new List<string>();

            if (request.ProductId <= 0)
                errors.Add("Produto não selecionado.");

            if (request.Quantity <= 0)
                errors.Add("A quantidade deve ser maior que zero.");

            if (!Enum.IsDefined(typeof(StockMovementType), request.Type))
                errors.Add("Tipo de movimentação inválido.");

            if (string.IsNullOrWhiteSpace(request.Notes) || request.Notes.Trim().Length < 15)
                errors.Add("A justificativa deve conter ao menos 15 caracteres.");

            if (string.IsNullOrWhiteSpace(request.Origin))
                errors.Add("Origem da movimentação não informada.");

            var result =  new ValidationResults
                {
                    IsValid = errors.Count == 0,
                    Errors = errors
                };
            return Task.FromResult(result);
        }
        public async Task<List<StockMovementDTO>> SearchAsync(string search)
        {
            var query = _context.stockMovements
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
                .OrderByDescending(p => p.Date)
                .OrderBy(p => p.Id)
                .Select(ps => new StockMovementDTO
                {
                    Id = ps.Id,
                    ProductId = ps.ProductId,
                    ProductDescription = ps.Product.Description,
                    Quantity = ps.Quantity,
                    Date = ps.Date,
                    Type = ps.Type,
                    TypeDescription = EnumHelper.GetEnumDescription<StockMovementType>(ps.Type)
                })
                .ToListAsync();

            return result;
        }

        public async Task<StockMovementDTO> GetByIdAsync(int Id)
        {
            var stockMovement = await _context
                .stockMovements
                .Include(sm => sm.Product)
                .FirstOrDefaultAsync(sm => sm.Id == Id);

            var result = new StockMovementDTO
            {
                Id = stockMovement!.Id,
                ProductId = stockMovement.ProductId,
                ProductDescription = stockMovement.Product.Description,
                Quantity = stockMovement.Quantity,
                Date = stockMovement.Date,
                Type = stockMovement.Type,
                Notes = stockMovement.Notes != null ? stockMovement.Notes : "",
                DocumentNumber = stockMovement.DocumentNumber != null ? stockMovement.DocumentNumber : "",
            };

            return result;
        }
    }
}
