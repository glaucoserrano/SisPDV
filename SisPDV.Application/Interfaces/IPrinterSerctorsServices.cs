using SisPDV.Application.DTOs.Config.PrintSector;
using SisPDV.Application.DTOs.Validation;

namespace SisPDV.Application.Interfaces
{
    public interface IPrinterSerctorsServices
    {
        Task<ValidationResults> Validate(List<PrintSectorsDTO> request);
        Task SaveAsync(List<PrintSectorsDTO> request);
    }
}
