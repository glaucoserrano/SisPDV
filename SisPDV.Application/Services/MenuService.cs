using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.Menus;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Entities;
using SisPDV.Infrastructure.Persistence;

namespace SisPDV.Application.Services
{
    public class MenuService : IMenuService
    {
        private readonly PDVDbContext _context;

        public MenuService(PDVDbContext context)
        {
            _context = context;
        }

        public async Task<List<MenuDTO>> GetAllMenuAsync()
        {
            return await _context.menus
                .Where(menu => menu.Visible)
                .Select(menu => new MenuDTO
                {
                    Id = menu.Id,
                    Title = menu.Title,
                    ParentId = menu.ParentId,
                    Order = menu.Order,
                    FormName = menu.FormName
                })
                .OrderBy(menu => menu.ParentId)
                .ThenBy(menu => menu.Order)
                .ToListAsync();
        }

        public async Task<List<MenuDTO>> GetMenusUserIdAsync(int userId)
        {
            var menus = await (from m in _context.menus
                               join um in _context.userMenu on m.Id equals um.MenuId
                               where um.UserId == userId && m.Visible
                               select new MenuDTO
                               {
                                   Id = m.Id,
                                   ParentId = m.ParentId,
                                   Title = m.Title,
                                   FormName = m.FormName,
                                   Order = m.Order
                               })
                               .OrderBy(m => m.ParentId)
                               .ThenBy(m => m.Order)
                               .ToListAsync();
            return menus;
        }
    }
}
