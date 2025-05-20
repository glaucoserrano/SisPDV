using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.Cfop;
using SisPDV.Application.DTOs.Unities;
using SisPDV.Application.Interfaces;
using SisPDV.Infrastructure.Persistence;

namespace SisPDV.Application.Services
{
    public class UnityService : IUnityService
    {
        private readonly PDVDbContext _context;

        public UnityService(PDVDbContext context)
        {
            _context = context;
        }

        public async Task<List<UnityDTO>> GetUnityAsync()
        {
            return await _context
                .unities
                .AsNoTracking()
                .OrderBy(c => c.Description)
                .Select(c => new UnityDTO
                {
                    Id = c.Id,
                    Description = c.Description
                })
                .ToListAsync();
        }
    }
}
