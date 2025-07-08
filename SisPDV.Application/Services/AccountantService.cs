using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.Accountant;
using SisPDV.Application.DTOs.Category;
using SisPDV.Application.DTOs.Cfop;
using SisPDV.Application.DTOs.Validation;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Entities;
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

        public async Task<AccountantDTO?> GetByIdAsync(int id)
        {
            var accountant = await _context.accountants.FindAsync(id);

            if (accountant == null)
                return new AccountantDTO { };

            return new AccountantDTO
            {
                Id = accountant.Id,
                Name = accountant.Name,
                CRC = accountant.CRC,
                CPF = accountant.CPF,
                CNPJ = accountant.CNPJ,
                Email = accountant.Email!,
                Phone = accountant.Phone!,

                Street = accountant.Address!,
                Number = accountant.Number!,
                District = accountant.Neighborhood!,
                City = accountant.City!,
                State = accountant.State!,
                ZipCode = accountant.CEP!,
                IsActive = accountant.Active,

            };
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
            return _context
                .accountants
                .AsNoTracking()
                .Where(c => c.Active)
                .OrderBy(c => c.Name)
                .Select(c => new AccountantDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    CRC = c.CRC,
                    CPF = c.CPF,
                    CNPJ = c.CNPJ,
                    Email = c.Email!,
                    Phone = c.Phone!,

                    Street = c.Address!,
                    Number = c.Number!,
                    District = c.Neighborhood!,
                    City = c.City!,
                    State = c.State!,
                    ZipCode = c.CEP!,
                    IsActive = c.Active,
                })
                .ToListAsync();
        }

        public async Task SaveAsync(AccountantDTO request)
        {
            using var transactions = await _context.Database.BeginTransactionAsync();
            try
            {
                var existing = await _context.accountants.FindAsync(request.Id);
                if (existing == null)
                {
                    //Nova Category
                    var accountant = new Accountant
                    {
                        Name = request.Name,
                        CRC = request.CRC,
                        CPF = request.CPF,
                        CNPJ = request.CNPJ,
                        Email = request.Email,
                        Phone = request.Phone,

                        Address = request.Street,
                        Number = request.Number,
                        Neighborhood = request.District,
                        City =request.City,
                        State = request.State,
                        CEP = request.ZipCode,
                        Active = request.IsActive,
                    };

                    await _context.accountants.AddAsync(accountant);
                }
                else
                {
                    existing.Name = request.Name;
                    existing.CRC = request.CRC;
                    existing.CPF = request.CPF;
                    existing.CNPJ = request.CNPJ;
                    existing.Email = request.Email;
                    existing.Phone = request.Phone;

                    existing.Address = request.Street;
                    existing.Number = request.Number;
                    existing.Neighborhood = request.District;
                    existing.City = request.City;
                    existing.State = request.State;
                    existing.CEP = request.ZipCode;
                    existing.Active = request.IsActive;

                    _context.accountants.Update(existing);
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

        public async Task<List<AccountantDTO>> SearchAsync(string search, int statusFilter)
        {
            search = search?.Trim() ?? "";

            var query = _context.accountants.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c =>
                    EF.Functions.ILike(c.Name, $"%{search}%"));
            }

            if (statusFilter == 0)
            {
                query = query.Where(c => c.Active);
            }
            else if (statusFilter == 1)
            {
                query = query.Where(c => !c.Active);
            }

            return await query.
                OrderBy(c => c.Name).
                Select(c => new AccountantDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    CNPJ = c.CNPJ,
                    CPF = c.CPF
                })
                .ToListAsync();
        }

        public Task<ValidationResults> ValidateAsync(AccountantDTO request)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(request.Name))
                errors.Add("O Nome do Contador é obrigatório.");
            
            if (string.IsNullOrWhiteSpace(request.CPF.Replace(".","").Replace("-","")))
                errors.Add("O Cpf do Contador é obrigatório.");

            if (string.IsNullOrWhiteSpace(request.CRC))
                errors.Add("O CRC do Contador é obrigatório.");



            var result = new ValidationResults
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };

            return Task.FromResult(result);
        }

    }
}
