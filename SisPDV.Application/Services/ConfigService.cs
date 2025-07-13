using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.Cash;
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
        private readonly IEncryptionService _encryptionServices;
        
        public ConfigService(PDVDbContext context)
        {
            _context = context;
            _printerSectorService = new PrinterSectorsService(context);
            _encryptionServices = new EncryptionService(context);
        }

        public async Task<ConfigDTO> GetConfigAsync()
        {
            var entity = await _context.configs.FirstOrDefaultAsync();

            var config = new ConfigDTO()
            {
                DigitalCertificate = entity!.DigitalCertificate,
                PasswordCertificate = string.IsNullOrWhiteSpace(entity.PasswordCertificate)
                            ? string.Empty
                            : await _encryptionServices.DecryptAsync(entity.PasswordCertificate), // Helper que criamos
                CertificateA1 = entity.CertificateA1,

                // NFC-e
                NFCeEnabled = entity.NFCeEnabled,
                VersionDF = entity.VersionDF,
                Model = entity.Model,
                Serial = entity.Serial,
                InitialNumber = entity.InitialNumber,
                Environment = entity.Environment,
                CSC = entity.CSC,
                CSCId = entity.CSCId,
                Print = entity.Print,
                TypeEmission = entity.TypeEmission,
                XMLPath = entity.XMLPath,

                // NF-e
                NFeEnabled = entity.NFeEnabled,
                NFeVersionDF = entity.NFeVersionDF,
                NFeModel = entity.NFeModel,
                NFeSerial = entity.NFeSerial,
                NFeInitialNumber = entity.NFeInitialNumber,
                NFeXmlPath = entity.NFeXmlPath,
                NFeEnvironment = entity.NFeEnvironment,
                NFePrint = entity.NFePrint,
                NFeSavePDF = entity.NFeSavePDF,
                NFeDestinationEmail = entity.NFeDestinationEmail,
                NFeFinality = entity.NFeFinality,
                NFePresenceIndicator = entity.NFePresenceIndicator,
                NFePaymentForm = entity.NFePaymentForm,

                // Gerais
                UseStockControl = entity.UseStockControl,
                SalesZeroStock = entity.SalesZeroStock,
                OrderPrint = entity.OrderPrint,
                BackupPath = entity.BackupPath,
                AutoCloseOrder = entity.AutoCloseOrder,
                UsePrintSector = entity.UsePrintSector
            };
            return config;
        }

        public async Task<(ConfigDTO, List<PrintSectorsDTO>)> GetFullConfigAsync()
        {
            var entity = await _context.configs.FirstOrDefaultAsync();
            var printerSectors = await _context.printsectors.ToListAsync();

            if (entity is null)
                return (new ConfigDTO(), new List<PrintSectorsDTO>());

            var config = new ConfigDTO()
            {
                DigitalCertificate = entity.DigitalCertificate,
                PasswordCertificate = string.IsNullOrWhiteSpace(entity.PasswordCertificate)
             ? string.Empty
             : await _encryptionServices.DecryptAsync(entity.PasswordCertificate), // Helper que criamos
                CertificateA1 = entity.CertificateA1,

                // NFC-e
                NFCeEnabled = entity.NFCeEnabled,
                VersionDF = entity.VersionDF,
                Model = entity.Model,
                Serial = entity.Serial,
                InitialNumber = entity.InitialNumber,
                Environment = entity.Environment,
                CSC = entity.CSC,
                CSCId = entity.CSCId,
                Print = entity.Print,
                TypeEmission = entity.TypeEmission,
                XMLPath = entity.XMLPath,

                // NF-e
                NFeEnabled = entity.NFeEnabled,
                NFeVersionDF = entity.NFeVersionDF,
                NFeModel = entity.NFeModel,
                NFeSerial = entity.NFeSerial,
                NFeInitialNumber = entity.NFeInitialNumber,
                NFeXmlPath = entity.NFeXmlPath,
                NFeEnvironment = entity.NFeEnvironment,
                NFePrint = entity.NFePrint,
                NFeSavePDF = entity.NFeSavePDF,
                NFeDestinationEmail = entity.NFeDestinationEmail,
                NFeFinality = entity.NFeFinality,
                NFePresenceIndicator = entity.NFePresenceIndicator,
                NFePaymentForm = entity.NFePaymentForm,

                // Gerais
                UseStockControl = entity.UseStockControl,
                SalesZeroStock = entity.SalesZeroStock,
                OrderPrint = entity.OrderPrint,
                BackupPath = entity.BackupPath,
                AutoCloseOrder = entity.AutoCloseOrder,
                UsePrintSector = entity.UsePrintSector
            };

            var printers = printerSectors.Select(p => new PrintSectorsDTO
            {
                Id = p.Id,
                SectorName = p.SectorName,
                PrinterName = p.PrinterName,
                NumberOfCopies = p.NumberOfCopies,
                Active = p.Active,
                IsDefault = p.IsDefault
            }).ToList();

            return (config, printers);
        }

        public async Task<List<PrintSectorsDTO>> GetPrinterSectorAsync()
        {
            var printerSectors = await _context.printsectors.ToListAsync();

            var printers = printerSectors.Select(p => new PrintSectorsDTO
            {
                Id = p.Id,
                SectorName = p.SectorName,
                PrinterName = p.PrinterName,
                NumberOfCopies = p.NumberOfCopies,
                Active = p.Active,
                IsDefault = p.IsDefault
            }).ToList();

            return (printers);
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
                configs.PasswordCertificate = await _encryptionServices.EncryptAsync(request.PasswordCertificate);
                configs.CertificateA1 = request.CertificateA1;

                configs.NFCeEnabled = request.NFCeEnabled;
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
                configs.UsePrintSector = request.UsePrintSector;

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

                await File.WriteAllTextAsync(pathJson, newJson); // <- Esta linha grava o arquivo

                if (requestPrintSector.Count > 0)
                {
                    var printerSectorsValidation = await _printerSectorService.Validate(requestPrintSector);

                    if (!printerSectorsValidation.IsValid)
                        return printerSectorsValidation;

                    await _printerSectorService.SaveAsync(requestPrintSector);
                }
                var configValidation = await Validate(requestConfig);

                if (!configValidation.IsValid)
                    return configValidation;

                
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

            if(request.CertificateA1)
            { 
                if (string.IsNullOrWhiteSpace(request.DigitalCertificate))
                    errors.Add("O campo 'Certificado Digital' é obrigatório.");

                if (string.IsNullOrWhiteSpace(request.PasswordCertificate))
                    errors.Add("O campo 'Senha do Certificado' é obrigatório.");
            }
            // NFC-e
            if (request.NFCeEnabled)
            {
                
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
            }
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
