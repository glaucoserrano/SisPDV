using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.Cash;
using SisPDV.Application.DTOs.Validation;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Entities;
using SisPDV.Domain.Enum;
using SisPDV.Infrastructure.Persistence;

namespace SisPDV.Application.Services
{
    public class CashMovementService : ICashMovementService
    {
        private readonly PDVDbContext _context;

        public CashMovementService(PDVDbContext context)
        {
            _context = context;
        }

        public async Task SaveCashMovementAsync(CashMovementDTO request)
        {
            using var transactions = await _context.Database.BeginTransactionAsync();
            try
            {
                var cashRegister = await _context.cashRegisters
                    .FirstOrDefaultAsync(c => c.Id == request.CashRegisterId);

                if (cashRegister == null)
                    throw new Exception("Caixa não encontrado.");

                var movement = new CashMovement
                {
                    CashRegisterId = request.CashRegisterId,
                    MovementDateTime = DateTime.UtcNow,
                    Type = request.Type,
                    Amount = request.Amount,
                    Description = request.Description,
                    Origin = request.Origin
                };

                _context.cashMovements.Add(movement);
                await _context.SaveChangesAsync();
                await transactions.CommitAsync();
            }
            catch
            {
                await transactions.RollbackAsync();
                throw;
            }
        }
        public Task<ValidationResults> ValidateAsync(CashMovementDTO request)
        {
            var errors = new List<string>();

            if (request.Amount <= 0)
                errors.Add("O valor do movimento é obrigatório e deve ser maior que zero.");

            if (string.IsNullOrWhiteSpace(request.Description) || request.Description.Trim().Length < 15)
                errors.Add("A justificativa é obrigatória e deve conter no mínimo 15 caracteres.");

            var result = new ValidationResults
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };

            return Task.FromResult(result);
        }
    }
}
