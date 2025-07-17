using Microsoft.Extensions.DependencyInjection;
using SisPDV.APP.Helpers;
using SisPDV.APP.Infrastructure.IoC;
using SisPDV.APP.Login;
using SisPDV.Application.Services;
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

            var serviceProvider = DependencyInjection.Configure();

            ValidadateForNames.ValidateFormNames(serviceProvider);
            var loginForm = serviceProvider.GetRequiredService<LoginForm>();

            WindowsForms.Application.Run(loginForm);
        }
    }
}