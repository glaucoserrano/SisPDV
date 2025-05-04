using SisPDV.Domain.Entities;

namespace SisPDV.Application.Interfaces
{
    public interface IUserService
    {
        Task<User?> AuthenticateUserAsync(string login, string password);
    }
}
