using Microsoft.EntityFrameworkCore;
using SisPDV.Domain.Entities;
using SisPDV.Domain.Entities.Base;
using SisPDV.Domain.Helpers;
using SisPDV.Infrastructure.Service;

namespace SisPDV.Infrastructure.Persistence
{
    public class PDVDbContext : DbContext
    {
        private readonly ICurrentUserService _currentUser;
        public PDVDbContext(DbContextOptions<PDVDbContext> options, ICurrentUserService currentUser) : base(options)
        {
            _currentUser = currentUser;
        }
        public DbSet<User> users { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<AuditableEntity>();

            foreach(var entry in entries)
            {
                var now = DateTime.UtcNow;
                
                if(entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = now;
                    entry.Entity.CreatedBy = _currentUser.CurrentUser;
                }
                else if(entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = now;
                    entry.Entity.UpdatedBy = _currentUser.CurrentUser;
                }

            }
            
            return await base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var admin = new User
            {
                Id = 1,
                Name = "Admin",
                Login = "admin",
                Password = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                Active = true
            };
            modelBuilder.Entity<User>().HasData(admin);
        }

    }
}
