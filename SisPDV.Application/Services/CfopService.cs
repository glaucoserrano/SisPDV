using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.Cfop;
using SisPDV.Application.Interfaces;
using SisPDV.Infrastructure.Persistence;

namespace SisPDV.Application.Services
{
    public class CfopService : ICfopService
    {
        private readonly PDVDbContext _context;
        public CfopService(PDVDbContext context)
        {
            _context = context;
        }
        public Task<List<CfopDTO>> GetCfopAsync()
        {
            return _context
                .cfops
                .AsNoTracking()
                .OrderBy(c => c.Code)
                .Select(c => new CfopDTO
                {
                    Id = c.Id,
                    Code = c.Code,
                    Description = c.Description
                })
                .ToListAsync();
        }
    }
}
