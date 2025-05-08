using SisPDV.Application.DTOs.Cep;

namespace SisPDV.Application.ExternalInterfaces
{
    public interface ICepService
    {
        Task<CepResponseDto?> GetCepsync(string cep);
    }
}
