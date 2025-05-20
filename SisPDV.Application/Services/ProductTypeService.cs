using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.ProductType;
using SisPDV.Application.DTOs.Validation;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Entities;
using SisPDV.Infrastructure.Persistence;

namespace SisPDV.Application.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly PDVDbContext _context;

        public ProductTypeService(PDVDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductTypeDTO>> GetProductTypesAsync()
        {
            return await _context
                .productTypes
                .AsNoTracking()
                .OrderBy(p => p.Type)
                .Select(p => new ProductTypeDTO
                {
                    Id = p.Id,
                    Type = p.Type,
                    NCM = p.NCM,
                    IVA = p.IVA,
                    CfopId = p.CfopId,
                    Origin = p.Origin,
                    CST_CSOSN = p.CST_CSOSN,
                    CST_ICMS = p.CST_ICMS,
                    CST_PIS = p.CST_PIS,
                    CST_COFINS = p.CST_COFINS,
                    Notes = p.Notes
                })
                .ToListAsync();
        }

        public Task<ValidationResults> ValidateAsync(ProductTypeDTO resquest)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(resquest.Type))
                errors.Add("O campo 'Tipo' é obrigatório.");

            if (string.IsNullOrWhiteSpace(resquest.NCM))
                errors.Add("O campo 'NCM' é obrigatório.");

            if (resquest.CfopId == 0)
                errors.Add("O campo 'CFOP' é obrigatório.");

            if (!resquest.Origin.HasValue)
                errors.Add("O campo 'Origem' é obrigatório.");

            if (!resquest.CST_CSOSN.HasValue)
                errors.Add("O campo 'CST/CSOSN' é obrigatório.");

            if (!resquest.CST_PIS.HasValue)
                errors.Add("O campo 'CST PIS' é obrigatório.");

            if (!resquest.CST_COFINS.HasValue)
                errors.Add("O campo 'CST COFINS' é obrigatório.");

            var result = new ValidationResults
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };

            return Task.FromResult(result);
        }

        public async Task SaveAsync(ProductTypeDTO request)
        {
            using var transactions = await _context.Database.BeginTransactionAsync();

            try
            {
                var existingProductType = await _context.productTypes.FindAsync(request.Id);

                if (existingProductType == null)
                {
                    // Novo cadastro
                    var newProductType = new ProductTypes
                    {
                        Type = request.Type,
                        NCM = request.NCM,
                        IVA = request.IVA,
                        CfopId = request.CfopId,
                        Origin = request.Origin,
                        CST_CSOSN = request.CST_CSOSN,
                        CST_ICMS = request.CST_ICMS,
                        CST_PIS = request.CST_PIS,
                        CST_COFINS = request.CST_COFINS,
                        Notes = request.Notes
                    };

                    await _context.productTypes.AddAsync(newProductType);
                }
                else
                {
                    existingProductType.Type = request.Type;
                    existingProductType.NCM = request.NCM;
                    existingProductType.IVA = request.IVA;
                    existingProductType.CfopId = request.CfopId;
                    existingProductType.Origin = request.Origin;
                    existingProductType.CST_CSOSN = request.CST_CSOSN;
                    existingProductType.CST_ICMS = request.CST_ICMS;
                    existingProductType.CST_PIS = request.CST_PIS;
                    existingProductType.CST_COFINS = request.CST_COFINS;
                    existingProductType.Notes = request.Notes;

                    _context.productTypes.Update(existingProductType);
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

        public async Task<ProductTypeDTO> GetByIdAsync(int id)
        {
            var entity = await _context.productTypes.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            if (entity == null)
                return null;

            return new ProductTypeDTO
            {
                Id = entity.Id,
                Type = entity.Type,
                NCM = entity.NCM,
                IVA = entity.IVA,
                CfopId = entity.CfopId,
                Origin = entity.Origin,
                CST_CSOSN = entity.CST_CSOSN,
                CST_ICMS = entity.CST_ICMS,
                CST_PIS = entity.CST_PIS,
                CST_COFINS = entity.CST_COFINS,
                Notes = entity.Notes
            };
        }
    }
}
