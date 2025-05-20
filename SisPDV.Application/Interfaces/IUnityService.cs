using SisPDV.Application.DTOs.Unities;

namespace SisPDV.Application.Interfaces
{
    public interface IUnityService
    {
        Task<List<UnityDTO>> GetUnityAsync();
    }
}
