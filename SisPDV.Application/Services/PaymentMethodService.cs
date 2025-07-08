using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.PaymentMethod;
using SisPDV.Application.DTOs.Validation;
using SisPDV.Application.Helper;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Entities;
using SisPDV.Domain.Enum;
using SisPDV.Infrastructure.Persistence;

namespace SisPDV.Application.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly PDVDbContext _context;

        public PaymentMethodService(PDVDbContext context)
        {
            _context = context;
        }
        public async Task<PaymentMethodDTO?> GetByIdAsync(int id)
        {
            var paymentMethod = await _context.paymentMethods.FindAsync(id);

            if (paymentMethod == null)
                return new PaymentMethodDTO { };

            return new PaymentMethodDTO
            {
                Id = paymentMethod.Id,
                Description = paymentMethod.Description,
                SefazCode = (SefazPaymentCode) paymentMethod.SefazCode,
                IsActive = paymentMethod.IsActive
            };
        }

        public Task<List<PaymentMethodDTO>> GetPaymentMethodActiveAsync()
        {
            return _context
                .paymentMethods
                .AsNoTracking()
                .Where(c => c.IsActive)
                .OrderBy(c => c.Description)
                .Select(c => new PaymentMethodDTO
                {
                    Id = c.Id,
                    Description = c.Description,
                    SefazCode = (SefazPaymentCode) c.SefazCode,
                    IsActive = c.IsActive
                })
                .ToListAsync();
            
        }

        public Task<List<PaymentMethodDTO>> GetPaymentMethodAsync()
        {
            return _context
                .paymentMethods
                .AsNoTracking()
                .OrderBy(c => c.Description)
                .Select(c => new PaymentMethodDTO
                {
                    Id = c.Id,
                    Description = c.Description,
                    SefazCodeDescription = EnumHelper.GetEnumDescription((SefazPaymentCode)c.SefazCode),
                    SefazCode = (SefazPaymentCode) c.SefazCode
                })
                .ToListAsync();
        }

        public async Task SaveAsync(PaymentMethodDTO request)
        {
            using var transactions = await _context.Database.BeginTransactionAsync();
            try
            {
                var existing = await _context.paymentMethods.FindAsync(request.Id);
                if (existing == null)
                {
                    //Nova Category
                    var paymentMethod = new PaymentMethod
                    {
                        Description = request.Description,
                        SefazCode = request.SefazCode,
                        IsActive = request.IsActive
                    };

                    await _context.paymentMethods.AddAsync(paymentMethod);
                }
                else
                {
                    existing.Description = request.Description;
                    existing.SefazCode = request.SefazCode;
                    existing.IsActive = request.IsActive;

                    _context.paymentMethods.Update(existing);
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

        public async Task<List<PaymentMethodDTO>> SearchAsync(string search, int statusFilter)
        {
            search = search?.Trim() ?? "";

            var query = _context.paymentMethods.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c =>
                    EF.Functions.ILike(c.Description, $"%{search}%"));
            }

            if (statusFilter == 0)
            {
                query = query.Where(c => c.IsActive);
            }
            else if (statusFilter == 1)
            {
                query = query.Where(c => !c.IsActive);
            }

            return await query.
                OrderBy(c => c.Description).
                Select(c => new PaymentMethodDTO
                {
                    Id = c.Id,
                    Description = c.Description,
                    SefazCodeDescription = EnumHelper.GetEnumDescription((SefazPaymentCode)c.SefazCode),
                    SefazCode = (SefazPaymentCode)c.SefazCode
                })
                .ToListAsync();
        }

        public Task<ValidationResults> ValidateAsync(PaymentMethodDTO request)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(request.Description))
                errors.Add("A descrição da forma de pagamento é obrigatória.");

            if (request.SefazCode == 0)
                errors.Add("O código SEFAZ é obrigatório.");

            var result = new ValidationResults
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };

            return Task.FromResult(result);

        }
    }
}
