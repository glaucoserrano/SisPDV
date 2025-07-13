using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.Cash;
using SisPDV.Application.Interfaces;
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
    }
}
