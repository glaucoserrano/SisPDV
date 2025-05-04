using Microsoft.EntityFrameworkCore;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Entities;
using SisPDV.Domain.Helpers;
using SisPDV.Infrastructure.Persistence;

namespace SisPDV.Application.Services
{
    public class UserService : IUserService
    {
        private readonly PDVDbContext _context;
        public UserService(PDVDbContext context)
        {
            _context = context;
        }

        public async Task<User?> AuthenticateUserAsync(string login, string password)
        {
            var passwordHash = PasswordHelper.ComputeSha256Hash(rawData: password);

            return await _context.users.FirstOrDefaultAsync(
                user => user.Login == login &&
                user.Password == passwordHash &&
                user.Active);
        }
    }
}
