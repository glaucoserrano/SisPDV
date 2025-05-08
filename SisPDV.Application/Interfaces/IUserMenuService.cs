namespace SisPDV.Application.Interfaces
{
    public interface IUserMenuService
    {
        Task<List<int>> GetUserMenuAsync(int userId);
        Task SaveUserPermissionAsync(int userId, List<int> selectedMenusId);
    }
}
