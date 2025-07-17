using Microsoft.Extensions.DependencyInjection;
using SisPDV.APP.Factory.Interface;

namespace SisPDV.APP.Factory.Service
{
    public class FormFactory<TForm> : IFormFactory<TForm> where TForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public FormFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public Form Create()
        {
            return _serviceProvider.GetRequiredService<TForm>();
        }
    }
}
