using SisPDV.Application.DTOs.Cfop;
using SisPDV.Application.DTOs.Validation;

namespace SisPDV.Application.Interfaces
{
    public interface ICfopService
    {
        Task<List<CfopDTO>> GetCfopAsync();
        Task<List<CfopDTO>> GetCfopsActiveAsync();
        Task<ValidationResults> ValidateAsync(CfopDTO request);
        Task SaveAsync(CfopDTO request);
        Task<CfopDTO> GetByIdAsync(int id);
        Task<List<CfopDTO>> SearchAsync(string search, int statusFilter);
    }
}
