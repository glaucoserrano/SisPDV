using Microsoft.EntityFrameworkCore;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Entities;
using SisPDV.Infrastructure.Persistence;

namespace SisPDV.Application.Services
{
    public class UserMenuService : IUserMenuService
    {
        private readonly PDVDbContext _context;

        public UserMenuService(PDVDbContext context)
        {
            _context = context;
        }

        public async Task<List<int>> GetUserMenuAsync(int userId)
        {
            return await _context.userMenu
                .Where(um => um.UserId == userId)
                .Select(um => um.MenuId)
                .ToListAsync();
        }

        public async Task SaveUserPermissionAsync(int userId, List<int> selectedMenusId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            var existing = _context.userMenu.Where(user => user.UserId == userId);
            _context.userMenu.RemoveRange(existing);

            var newPermissions = selectedMenusId.Select(mid => new UserMenu
            {
                UserId = userId,
                MenuId = mid
            });

            await _context.userMenu.AddRangeAsync(newPermissions);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

        }
    }
}
