using SisPDV.Application.DTOs.Cnpj;

namespace SisPDV.Application.ExternalInterfaces
{
    public interface ICnpjService
    {
        Task<CnpjResponseDTO?> GetCNPJAsync(string cnpj);
    }
}
