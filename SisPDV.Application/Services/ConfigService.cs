using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.CashConfig;
using SisPDV.Application.DTOs.Config;
using SisPDV.Application.DTOs.Config.PrintSector;
using SisPDV.Application.DTOs.Validation;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Entities;
using SisPDV.Infrastructure.Persistence;
using System.Text.Json;

namespace SisPDV.Application.Services
{
    public class ConfigService : IConfigService
    {
        private readonly PDVDbContext _context;
        private readonly IPrinterSerctorsServices _printerSectorService;
        
        public ConfigService(PDVDbContext context)
        {
            _context = context;
            _printerSectorService = new PrinterSectorsService(context);
        }

        public async  Task SaveAsync(ConfigDTO request)
        {
            var transactions = await _context.Database.BeginTransactionAsync();

            try
            {
                var configs = await _context.configs.FirstOrDefaultAsync();

                if(configs == null)
                {
                    configs = new Config();
                    _context.configs.Add(configs);
                }

                // Mapeia os campos do DTO para entidade
                configs.DigitalCertificate = request.DigitalCertificate;
                configs.PasswordCertificate = request.PasswordCertificate;
                configs.CertificateA1 = request.CertificateA1;

                configs.VersionDF = request.VersionDF;
                configs.Model = request.Model;
                configs.Serial = request.Serial;
                configs.InitialNumber = request.InitialNumber;
                configs.Environment = request.Environment;
                configs.CSC = request.CSC;
                configs.CSCId = request.CSCId;
                configs.Print = request.Print;
                configs.TypeEmission = request.TypeEmission;
                configs.XMLPath = request.XMLPath;

                configs.NFeEnabled = request.NFeEnabled;
                configs.NFeVersionDF = request.NFeVersionDF;
                configs.NFeModel = request.NFeModel;
                configs.NFeSerial = request.NFeSerial;
                configs.NFeInitialNumber = request.NFeInitialNumber;
                configs.NFeXmlPath = request.NFeXmlPath;
                configs.NFeEnvironment = request.NFeEnvironment;
                configs.NFePrint = request.NFePrint;
                configs.NFeSavePDF = request.NFeSavePDF;
                configs.NFeDestinationEmail = request.NFeDestinationEmail;
                configs.NFeFinality = request.NFeFinality;
                configs.NFePresenceIndicator = request.NFePresenceIndicator;
                configs.NFePaymentForm = request.NFePaymentForm;

                configs.UseStockControl = request.UseStockControl;
                configs.SalesZeroStock = request.SalesZeroStock;
                configs.OrderPrint = request.OrderPrint;
                configs.BackupPath = request.BackupPath;
                configs.AutoCloseOrder = request.AutoCloseOrder;

                await _context.SaveChangesAsync();
                await transactions.CommitAsync();

            }
            catch
            {
                await transactions.RollbackAsync();
                throw;
            }
        }

        public async  Task<ValidationResults> SaveAsyncConfig(
            int cashNumber, 
            List<PrintSectorsDTO> requestPrintSector, 
            ConfigDTO requestConfig, 
            string pathSystem)
        {
            
            try
            {

                var pathJson = Path.Combine(pathSystem, "configs.json");

                CashConfigDTO cashConfig;
                if (File.Exists(pathJson))
                {
                    var json = await File.ReadAllTextAsync(pathJson);
                    cashConfig = JsonSerializer.Deserialize<CashConfigDTO>(json) ?? new CashConfigDTO();
                }
                else
                {
                    cashConfig = new CashConfigDTO();
                }
                cashConfig.CashNumber = cashNumber;

                var newJson = JsonSerializer.Serialize(cashConfig, new JsonSerializerOptions
                {
                    WriteIndented = true,
                });

                var printerSectorsValidation = await _printerSectorService.Validate(requestPrintSector);

                if (!printerSectorsValidation.IsValid)
                    return printerSectorsValidation;

                var configValidation = await Validate(requestConfig);

                if (!printerSectorsValidation.IsValid)
                    return printerSectorsValidation;

                await _printerSectorService.SaveAsync(requestPrintSector);
                await SaveAsync(requestConfig);

                var result = new ValidationResults
                {
                    IsValid = true
                };

                return result;

            }
            catch
            {
                throw;
            }
        }

        public Task<ValidationResults> Validate(ConfigDTO request)
        {
            var errors = new List<String>();

            if (string.IsNullOrWhiteSpace(request.DigitalCertificate))
                errors.Add("O campo 'Certificado Digital' é obrigatório.");

            if (string.IsNullOrWhiteSpace(request.PasswordCertificate))
                errors.Add("O campo 'Senha do Certificado' é obrigatório.");

            // NFC-e
            if (string.IsNullOrWhiteSpace(request.VersionDF))
                errors.Add("Versão da NFC-e é obrigatória.");

            if (request.Serial <= 0)
                errors.Add("Série da NFC-e inválida.");

            if (request.InitialNumber < 0)
                errors.Add("Número inicial da NFC-e inválido.");

            if (string.IsNullOrWhiteSpace(request.CSC))
                errors.Add("CSC é obrigatório.");

            if (string.IsNullOrWhiteSpace(request.CSCId))
                errors.Add("ID do CSC é obrigatório.");

            if (string.IsNullOrWhiteSpace(request.XMLPath))
                errors.Add("Caminho XML NFC-e é obrigatório.");

            // NF-e
            if (request.NFeEnabled)
            {
                if (string.IsNullOrWhiteSpace(request.NFeVersionDF))
                    errors.Add("Versão da NF-e é obrigatória.");

                if (request.NFeSerial <= 0)
                    errors.Add("Série da NF-e inválida.");

                if (request.NFeInitialNumber < 0)
                    errors.Add("Número inicial da NF-e inválido.");

                if (string.IsNullOrWhiteSpace(request.NFeXmlPath))
                    errors.Add("Caminho XML da NF-e é obrigatório.");
            }
            var result = new ValidationResults
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };

            return Task.FromResult(result);
        }

    }
}
