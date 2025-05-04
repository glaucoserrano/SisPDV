using Microsoft.EntityFrameworkCore;
using SisPDV.APP.Login;
using SisPDV.Application.Services;
using SisPDV.Infrastructure.Persistence;
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
            var options = new DbContextOptionsBuilder<PDVDbContext>()
                .UseNpgsql(connectionString)
                .Options;
            var dbContext = new PDVDbContext(options);

            var userService = new UserService(dbContext);

            WindowsForms.Application.Run(new LoginForm(userService));
        }
    }
}