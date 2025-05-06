using SisPDV.Application.DTOs.Users;
using SisPDV.Domain.Entities;

namespace SisPDV.Application.Interfaces
{
    public interface IUserService
    {
        Task<User?> AuthenticateUserAsync(string login, string password);
        Task CreateUserAsync(UserRegisterDTO request);

        Task<List<UserSearchResponseDTO>> FilterUsersAsync(string? name, string? login, bool active);
        Task<User?> GetById(int id);
        Task UpdateUserAsync(UserUpdateDTO request);
    }
}
