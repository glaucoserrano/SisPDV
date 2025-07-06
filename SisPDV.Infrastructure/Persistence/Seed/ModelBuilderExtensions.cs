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
                },
                new Menu
                {
                    Id = 9,
                    ParentId = 7,
                    Title = "Tipo de Produtos",
                    FormName = "TypeProductsForm",
                    Order = 7,
                    Visible = true,
                    CreatedBy = "System"
                },
                new Menu
                {
                    Id = 10,
                    ParentId = 7,
                    Title = "Cadastro de Produtos",
                    FormName = "ProductForm",
                    Order = 8,
                    Visible = true,
                    CreatedBy = "System"
                },
                new Menu
                {
                    Id = 11,
                    ParentId = 7,
                    Title = "Outros Cadastros",
                    FormName = null,
                    Order = 9,
                    Visible = true,
                    CreatedBy = "System"
                },
                new Menu
                {
                    Id = 12,
                    ParentId = 11,
                    Title = "CFOP",
                    FormName = "CFOPForm",
                    Order = 9,
                    Visible = true,
                    CreatedBy = "System"
                },
                new Menu
                {
                    Id = 13,
                    ParentId = 11,
                    Title = "Categorias",
                    FormName = "CategoriesForm",
                    Order = 10,
                    Visible = true,
                    CreatedBy = "System"
                },
                new Menu
                {
                    Id = 14,
                    ParentId = 11,
                    Title = "Contador",
                    FormName = "AccountantForm",
                    Order = 11,
                    Visible = true,
                    CreatedBy = "System"
                }
            );
        }
        public static void SeedCfops(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cfop>().HasData(
                new Cfop
                {
                    Id = 1,
                    Code = "5102",
                    Description = "Venda de mercadoria adquirida ou recebida de terceiros",
                    CreatedBy = "System"
                },
                new Cfop
                {
                    Id = 2,
                    Code = "5101",
                    Description = "Venda de produção do estabelecimento",
                    CreatedBy = "System"
                },
                new Cfop
                {
                    Id = 3,
                    Code = "5405",
                    Description = "Venda de mercadoria adquirida de terceiros, com ST",
                    CreatedBy = "System"
                }
            );
        }
        public static void SeedUnitys(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unity>().HasData(
                new Unity
                {
                    Id = 1,
                    Acronym = "UN",
                    Description = "Unidade",
                    CreatedBy = "System"
                },
                new Unity
                {
                    Id = 2,
                    Acronym = "KG",
                    Description = "Quilograma",
                    CreatedBy = "System"
                },
                new Unity
                {
                    Id = 3,
                    Acronym = "LT",
                    Description = "Litro",
                    CreatedBy = "System"
                },
                new Unity
                {
                    Id = 4,
                    Acronym = "PC",
                    Description = "Peça",
                    CreatedBy = "System"
                },
                new Unity
                {
                    Id = 5,
                    Acronym = "CX",
                    Description = "Caixa",
                    CreatedBy = "System"
                },
                new Unity
                {
                    Id = 6,
                    Acronym = "MT",
                    Description = "Metro",
                    CreatedBy = "System"
                },
                new Unity
                {
                    Id = 7,
                    Acronym = "DZ",
                    Description = "Dúzia",
                    CreatedBy = "System"
                },
                new Unity
                {
                    Id = 8,
                    Acronym = "SC",
                    Description = "Saco",
                    CreatedBy = "System"
                }
            );
        }
    }
}
