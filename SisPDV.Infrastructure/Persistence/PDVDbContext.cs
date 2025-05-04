using Microsoft.EntityFrameworkCore;
using SisPDV.Domain.Entities;
using SisPDV.Domain.Helpers;

namespace SisPDV.Infrastructure.Persistence
{
    public class PDVDbContext : DbContext
    {
        public PDVDbContext(DbContextOptions<PDVDbContext> options) : base(options)
        {
        }
        public DbSet<User> users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var admin = new User
            {
                Id = 1,
                Name = "Admin",
                Login = "Admin",
                Password = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                Active = true
            };
            modelBuilder.Entity<User>().HasData(admin);
        }

    }
}
