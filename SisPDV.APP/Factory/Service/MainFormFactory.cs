using Microsoft.Extensions.DependencyInjection;
using SisPDV.APP.Factory.Interface;
using SisPDV.APP.Main;

namespace SisPDV.APP.Factory.Service
{
    public class MainFormFactory : IMainFormFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public MainFormFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public MainForm Create(int userId, string userName)
        {
            var mainForm = _serviceProvider.GetRequiredService<MainForm>();
            mainForm.Initialize(userId, userName);
            return mainForm;
        }
    }
}
