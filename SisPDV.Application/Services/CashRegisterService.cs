using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.Cash;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Entities;
using SisPDV.Domain.Enum;
using SisPDV.Domain.Helpers;
using SisPDV.Infrastructure.Globals;
using SisPDV.Infrastructure.Persistence;

namespace SisPDV.Application.Services
{
    public class CashRegisterService : ICashRegisterService
    {
        private readonly PDVDbContext _context;

        public CashRegisterService(PDVDbContext context)
        {
            _context = context;
        }

        public async Task<CashRegisterDTO?> CanOpenCashRegisterAsync(int cashNumber)
        {
            var lastCash = await _context.cashRegisters
                .Where(c => c.cashNumber == cashNumber)
                .OrderByDescending(c => c.openingDateTime)
                .FirstOrDefaultAsync();

            if (lastCash == null)
                return null;

            return new CashRegisterDTO
            {
                Id = lastCash.Id,
                CashNumber = lastCash.cashNumber,
                OpenDate = lastCash.openingDateTime,
                CloseDate = lastCash.closingDateTime,
                OpeningAmount = lastCash.openingAmount
            };
        }

        public async Task<CashRegisterDTO?> GetTodayCashOpeningAsync(int cashNumber)
        {
            var today = DateTime.UtcNow.Date;

            var opening = await _context.cashRegisters
                .Where(c => c.cashNumber == cashNumber && c.openingDateTime.Date == today || c.closingDateTime == DateTime.MinValue)
                .OrderByDescending(c => c.openingDateTime)
                .FirstOrDefaultAsync();

            if (opening == null)
                return null;

            return new CashRegisterDTO
            {
                Id = opening.Id,
                CashNumber = opening.cashNumber,
                OpeningAmount = opening.openingAmount,
                OpenDate = opening.openingDateTime,
            };

        }

        public async Task<CashRegisterDTO> OpenCashRegisterAsync(int cashNumber, decimal openingAmount, string origin)
        {
            using var transactions = await _context.Database.BeginTransactionAsync();
            try
            {
                var today = DateTime.UtcNow;

                //verifica se já existe o caixa aberto
                var alreadyOpen = await _context.cashRegisters
                    .AnyAsync(c => c.cashNumber == cashNumber && c.openingDateTime == today && c.closingDateTime == DateTime.MinValue);
                if (alreadyOpen)
                    throw new InvalidOperationException("Já existe um caixa aberto para o número informado.");

                //cria registro para o caixa
                var cashRegister = new CashRegister
                {
                    cashNumber = cashNumber,
                    openingDateTime = today,
                    openingAmount = PriceConverter.ToCents(openingAmount),
                };
                await _context.cashRegisters.AddAsync(cashRegister);
                await _context.SaveChangesAsync();

                //cria a movimentação de abertura do caixa
                var movement = new CashMovement
                {
                    CashRegisterId = cashRegister.Id,
                    Amount = PriceConverter.ToCents(openingAmount),
                    Type = (int)CashMovementType.Opening,
                    Origin = origin,
                    MovementDateTime = today,
                };

                await _context.cashMovements.AddAsync(movement);
                await _context.SaveChangesAsync();
                await transactions.CommitAsync();

                CashRegisterStatus.IsOpen = true;
                CashRegisterStatus.CashNumber = cashNumber;
                CashRegisterStatus.CashRegisterId = cashRegister.Id;
                CashRegisterStatus.OpenDate = cashRegister.openingDateTime;
                CashRegisterStatus.StatusMessage = $"Caixa aberto em {cashRegister.openingDateTime.ToLocalTime():dd/MM/yyyy HH:mm}";

                return new CashRegisterDTO
                {
                    Id = cashRegister.Id,
                    CashNumber = cashRegister.cashNumber,
                    OpenDate = cashRegister.openingDateTime,
                    OpeningAmount = cashRegister.openingAmount,
                    amount = PriceConverter.FromCents(cashRegister.openingAmount)
                };
            }
            catch
            {
                await transactions.RollbackAsync();
                throw;
            }
        }
    }
}
