using Microsoft.EntityFrameworkCore;
using SisPDV.Domain.Entities;

namespace SisPDV.Infrastructure.Persistence.Seed
{
    public static class ModelBuilderExtensions
    {
        public static void SeedMenus(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>().HasData(
                new Menu
                {
                    Id = 1,
                    ParentId = null,
                    Title = "Configurações",
                    FormName = null,
                    Order = 1,
                    Visible = true,
                    CreatedBy = "System"
                },
                new Menu
                {
                    Id = 2,
                    ParentId = 1,
                    Title = "Cadastro de Usuário",
                    FormName = "UserAddForm",
                    Order = 1,
                    Visible = true,
                    CreatedBy = "System"
                },
                new Menu
                {
                    Id = 3,
                    ParentId = 1,
                    Title = "Alterar Senha",
                    FormName = "UserChangePassword",
                    Order = 2,
                    Visible = true,
                    CreatedBy = "System"
                },
                new Menu
                {
                    Id = 4,
                    ParentId = 1,
                    Title = "Permissão de Usuário",
                    FormName = "PermissionMenuForm",
                    Order = 3,
                    Visible = true,
                    CreatedBy = "System"
                },
                new Menu
                {
                    Id = 5,
                    ParentId = 1,
                    Title = "Cadastro da Empresa",
                    FormName = "CompanyForm",
                    Order = 4,
                    Visible = true,
                    CreatedBy = "System"
                },
                new Menu
                {
                    Id = 6,
                    ParentId = 1,
                    Title = "Configurações",
                    FormName = "ConfigForm",
                    Order = 5,
                    Visible = true,
                    CreatedBy = "System"
                },
                new Menu
                {
                    Id = 7,
                    ParentId = null,
                    Title = "Cadastro",
                    FormName = null,
                    Order = 6,
                    Visible = true,
                    CreatedBy = "System"
                },
                new Menu
                {
                    Id = 8,
                    ParentId = 7,
                    Title = "Cadastro de Pessoas (Cliente, Fornecedor, Transportadora)",
                    FormName = "PersonForm",
                    Order = 6,
                    Visible = true,
                    CreatedBy = "System"
                }
            );
        }
    }
}
