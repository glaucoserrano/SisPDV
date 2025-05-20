using Microsoft.EntityFrameworkCore;
using SisPDV.APP.Login;
using SisPDV.Application.ExternalServices;
using SisPDV.Application.Services;
using SisPDV.Infrastructure.Persistence;
using SisPDV.Infrastructure.Service;
using System.Configuration;
using WindowsForms = System.Windows.Forms;

namespace SisPDV.APP
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var connectionString = ConfigurationManager.ConnectionStrings["PDVDb"].ConnectionString;
            var currentUserService = new CurrentUserService();
            
            var options = new DbContextOptionsBuilder<PDVDbContext>()
                .UseNpgsql(connectionString)
                .Options;

            using( var dbContext = new PDVDbContext(options, currentUserService))
            {

                var userService = new UserService(dbContext);
                var menuService = new MenuService(dbContext);
                var userMenuService = new UserMenuService(dbContext);
                var companyService = new CompanyService(dbContext);
                var printerSectorService = new PrinterSectorsService(dbContext);
                var configService = new ConfigService(dbContext);
                var PersonService = new PersonService(dbContext);
                var productTypeService = new ProductTypeService(dbContext);
                var cfopService = new CfopService(dbContext);
                var unityService = new UnityService(dbContext);
            


            var cnpjService = new CnpjService();
            var cepService = new CepService();
            

            WindowsForms.Application.Run(new LoginForm(
                userService,
                currentUserService,
                menuService,
                userMenuService,
                cnpjService,
                cepService,
                companyService,
                printerSectorService,
                configService,
                PersonService,
                productTypeService,
                cfopService,
                unityService));
            }
        }
    }
}