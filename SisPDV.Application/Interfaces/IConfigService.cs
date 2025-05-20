using SisPDV.Application.DTOs.Config;
using SisPDV.Application.DTOs.Config.PrintSector;
using SisPDV.Application.DTOs.Validation;

namespace SisPDV.Application.Interfaces
{
    public interface IConfigService
    {
        Task<ValidationResults> Validate(ConfigDTO request);
        Task SaveAsync(ConfigDTO request);
        Task<ValidationResults> SaveAsyncConfig(int cashNumber, List<PrintSectorsDTO> requestPrintSector,
            ConfigDTO requestConfig, string pathSystem);
        Task<(ConfigDTO, List<PrintSectorsDTO>)> GetFullConfigAsync();
        Task<ConfigDTO> GetConfigAsync();
        Task<List<PrintSectorsDTO>> GetPrinterSectorAsync();
    }
}
