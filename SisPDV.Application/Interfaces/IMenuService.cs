using SisPDV.Application.DTOs.Menus;

namespace SisPDV.Application.Interfaces
{
    public interface IMenuService
    {
        Task<List<MenuDTO>> GetAllMenuAsync();

        Task<List<MenuDTO>> GetMenusUserIdAsync(int userId);
    }
}
