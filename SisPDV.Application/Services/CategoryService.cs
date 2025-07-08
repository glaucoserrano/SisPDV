using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.Category;
using SisPDV.Application.DTOs.Cfop;
using SisPDV.Application.DTOs.Validation;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Entities;
using SisPDV.Infrastructure.Persistence;

namespace SisPDV.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly PDVDbContext _context;

        public CategoryService(PDVDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryDTO?> GetByIdAsync(int id)
        {
            var category = await _context.categories.FindAsync(id);

            if (category == null)
                return new CategoryDTO { };

            return new CategoryDTO
            {
                Id = category.Id,
                Description = category.Description,
                Active = category.Active
            };
        }

        public Task<List<CategoryDTO>> GetCagoriesAsync()
        {
            return _context
                .categories
                .AsNoTracking()
                .OrderBy(c => c.Description)
                .Select(c => new CategoryDTO
                {
                    Id = c.Id,
                    Description = c.Description,
                    Active = c.Active
                })
                .ToListAsync();
        }

        public async Task SaveAsync(CategoryDTO request)
        {
            using var transactions = await _context.Database.BeginTransactionAsync();
            try
            {
                var existing = await _context.categories.FindAsync(request.Id);
                if (existing == null)
                {
                    //Nova Category
                    var category = new Category
                    {
                        Description = request.Description!,
                        Active = request.Active,
                    };

                    await _context.categories.AddAsync(category);
                }
                else
                {
                    existing.Description = request.Description!;
                    existing.Active = request.Active;

                    _context.categories.Update(existing);
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

        public async Task<List<CategoryDTO>> SearchAsync(string search, int statusFilter)
        {
            search = search?.Trim() ?? "";

            var query = _context.categories.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c =>
                    EF.Functions.ILike(c.Description, $"%{search}%"));
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
                OrderBy(c => c.Description).
                Select(c => new CategoryDTO
                {
                    Id = c.Id,
                    Description = c.Description,
                    Active = c.Active
                })
                .ToListAsync();
        }

        public Task<ValidationResults> ValidateAsync(CategoryDTO request)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(request.Description))
                errors.Add("A Descrição da categoria é obrigatória.");

            var result = new ValidationResults
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };

            return Task.FromResult(result);
        }
        public Task<List<CategoryDTO>> GetCategoriesActiveAsync()
        {
            return _context
                .categories
                .AsNoTracking()
                .Where(c => c.Active)
                .OrderBy(c => c.Description)
                .Select(c => new CategoryDTO
                {
                    Id = c.Id,
                    Description = c.Description,
                    Active = c.Active
                })
                .ToListAsync();
        }
    }
}
