using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SisPDV.Infrastructure.Persistence;
using SisPDV.Infrastructure.Service;

namespace SisPDV.Infrastructure.Factory
{
    public class PDVDbContextFactory : IDesignTimeDbContextFactory<PDVDbContext>
    {
        public PDVDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<PDVDbContext>();
            var connectionString = "Host=localhost;Port=5432;Database=SisPDV;Username=postgres;Password=postgres";

            optionBuilder.UseNpgsql(connectionString);
            var currentUserService = new CurrentUserService { CurrentUser = "MigrationTool" };

            return new PDVDbContext(optionBuilder.Options,currentUserService);
        }
    }
}
