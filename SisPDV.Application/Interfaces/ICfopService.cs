using SisPDV.Application.DTOs.Cfop;

namespace SisPDV.Application.Interfaces
{
    public interface ICfopService
    {
        Task<List<CfopDTO>> GetCfopAsync();
    }
}
