using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SisPDV.Infrastructure.Persistence;

namespace SisPDV.Infrastructure.Factory
{
    public class PDVDbContextFactory : IDesignTimeDbContextFactory<PDVDbContext>
    {
        public PDVDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<PDVDbContext>();
            var connectionString = "Host=localhost;Port=5432;Database=SisPDV;Username=postgres;Password=postgres";

            optionBuilder.UseNpgsql(connectionString);

            return new PDVDbContext(optionBuilder.Options);
        }
    }
}
