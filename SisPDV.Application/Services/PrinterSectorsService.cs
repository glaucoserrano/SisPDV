using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.Config.PrintSector;
using SisPDV.Application.DTOs.Validation;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Entities;
using SisPDV.Infrastructure.Persistence;


namespace SisPDV.Application.Services
{
    public class PrinterSectorsService : IPrinterSerctorsServices
    {
        private readonly PDVDbContext _context;
        
        public PrinterSectorsService(PDVDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RemovePrintSectors(int id)
        {
            using var transactions = await _context!.Database.BeginTransactionAsync();
            var sector = await _context.printsectors.FirstOrDefaultAsync(p => p.Id == id);

            if ( sector == null )
            {
                return false;
            }
            try
            {
                _context.printsectors.Remove(sector);
                await _context.SaveChangesAsync();
                await transactions.CommitAsync();

                return true;
            }
            catch
            {
                await transactions.RollbackAsync();
                return false;
            }

        }

        public async Task SaveAsync(List<PrintSectorsDTO> request)
        {
            using var transactions = await _context!.Database.BeginTransactionAsync();

            try
            {
                //remove todas imnpressoras
                var existing = _context.printsectors.ToList();
                _context.printsectors.RemoveRange(existing);

                //Salva novamente 
                var printerSectors = request.Select(request => new PrintSector
                {
                    SectorName = request.SectorName,
                    PrinterName = request.PrinterName,
                    NumberOfCopies = request.NumberOfCopies,
                    Active = request.Active,
                    IsDefault = request.IsDefault
                }).ToList();

                await _context.printsectors.AddRangeAsync(printerSectors);
                await _context.SaveChangesAsync();
                await transactions.CommitAsync();

            }
            catch
            {
                await transactions.RollbackAsync();
                throw;
            }


        }

        public Task<ValidationResults> Validate(List<PrintSectorsDTO> request)
        {
            var errors = new List<string>();

            if (request.Count == 0)
                errors.Add("Adicione pelo menos um setor de impressão.");

            if (request.Count(p => p.IsDefault) > 1)
                errors.Add("Apenas um setor pode ser definido como padrão.");

            foreach (var dto in request)
            {
                if (string.IsNullOrEmpty(dto.SectorName))
                    errors.Add("Nome do setor não pode ser vazio.");

                if (string.IsNullOrEmpty(dto.PrinterName))
                    errors.Add($"O setor '{dto.SectorName}' não possui uma impressora definida.");

                if (dto.NumberOfCopies < 1)
                    errors.Add($"O setor '{dto.SectorName}' deve ter ao menos 1 via.");
            }

            var validate = new ValidationResults
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };

            return Task.FromResult(validate);


        }
    }
}
