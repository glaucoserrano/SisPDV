using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.Cfop;
using SisPDV.Application.DTOs.Validation;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Entities;
using SisPDV.Infrastructure.Persistence;

namespace SisPDV.Application.Services
{
    public class CfopService : ICfopService
    {
        private readonly PDVDbContext _context;
        public CfopService(PDVDbContext context)
        {
            _context = context;
        }
        public Task<List<CfopDTO>> GetCfopAsync()
        {
            return _context
                .cfops
                .AsNoTracking()
                .OrderBy(c => c.Code)
                .Select(c => new CfopDTO
                {
                    Id = c.Id,
                    Code = c.Code,
                    Description = c.Description,
                    Active = c.Active
                })
                .ToListAsync();
        }

        public async Task<ValidationResults> ValidateAsync(CfopDTO request)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(request.Code))
                errors.Add("O Código do CFOP é obrigatório.");

            if (string.IsNullOrWhiteSpace(request.Description))
                errors.Add("A Descrição do CFOP é obrigatória.");

            //Verifica se ja existe um código de CFOP registrado
            var exists = await _context.cfops.AnyAsync(c => c.Code == request.Code && c.Id != request.Id);

            if (exists)
                errors.Add("Já existe um CFOP cadastrado com esse código.");

            var result = new ValidationResults
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };

            return result;
        }
        public async Task SaveAsync(CfopDTO request)
        {
            using var transactions = await _context.Database.BeginTransactionAsync();
            try {
                var existing = await _context.cfops.FindAsync(request.Id);
                if (existing == null)
                {
                    //Novo Cfop
                    var cfop = new Cfop
                    {
                        Code = request.Code!,
                        Description = request.Description!,
                        Notes = request.Note,
                        Active = request.Active,
                    };

                    await _context.cfops.AddAsync(cfop);
                }
                else
                {
                    existing.Code = request.Code!;
                    existing.Description = request.Description!;
                    existing.Notes = request.Note;
                    existing.Active = request.Active;

                    _context.cfops.Update(existing);
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

        public async Task<CfopDTO> GetByIdAsync(int id)
        {
            var cfop = await _context.cfops.FindAsync(id);

            if (cfop == null)
                return new CfopDTO { };

            return new CfopDTO
            {
                Id = cfop.Id,
                Code = cfop.Code,
                Description = cfop.Description,
                Note = cfop.Notes,
                Active = cfop.Active
            };

        }

        public async Task<List<CfopDTO>> SearchAsync(string search, int statusFilter)
        {
            search = search?.Trim() ?? "";

            var query = _context.cfops.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c =>
                    EF.Functions.ILike(c.Code, $"%{search}%") ||
                    EF.Functions.ILike(c.Description, $"%{search}%"));
            }

            if(statusFilter == 0)
            {
                query = query.Where(c => c.Active);
            }
            else if(statusFilter == 1)
            {
                query = query.Where(c => !c.Active);
            }

            return await query.
                OrderBy(c => c.Code).
                Select(c => new CfopDTO
                {
                    Id = c.Id,
                    Code = c.Code,
                    Description = c.Description,
                    Active = c.Active
                })
                .ToListAsync();
        }

        public Task<List<CfopDTO>> GetCfopsActiveAsync()
        {
            return _context
                .cfops
                .AsNoTracking()
                .Where( c=> c.Active)
                .OrderBy(c => c.Code)
                .Select(c => new CfopDTO
                {
                    Id = c.Id,
                    Code = c.Code,
                    Description = c.Description,
                    Active = c.Active
                })
                .ToListAsync();
        }
    }
}
