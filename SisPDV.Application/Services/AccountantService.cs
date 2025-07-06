using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.Accountant;
using SisPDV.Application.DTOs.Category;
using SisPDV.Application.DTOs.Validation;
using SisPDV.Application.Interfaces;
using SisPDV.Infrastructure.Persistence;

namespace SisPDV.Application.Services
{
    public class AccountantService : IAccountantService
    {
        private readonly PDVDbContext _context;

        public AccountantService(PDVDbContext context)
        {
            _context = context;
        }

        public Task<AccountantDTO?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AccountantDTO>> GetAccountantAsync()
        {
            return _context
                .accountants
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .Select(c => new AccountantDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    CNPJ = c.CNPJ,
                    CPF = c.CPF
                })
                .ToListAsync();
        }

        public Task<List<AccountantDTO>> GetAccountantActiveAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(AccountantDTO request)
        {
            throw new NotImplementedException();
        }

        public Task<List<AccountantDTO>> SearchAsync(string search, int statusFilter)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResults> ValidateAsync(AccountantDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
