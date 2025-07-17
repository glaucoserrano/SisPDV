using Microsoft.Extensions.DependencyInjection;
using SisPDV.APP.Factory.Interface;

namespace SisPDV.APP.Factory.Service
{
    public class UserScopedFormFactory<TForm> : IUserScopedFormFactory<TForm>
        where TForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public UserScopedFormFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TForm Create(int userId)
        {
            var form = _serviceProvider.GetRequiredService<TForm>();

            var method = typeof(TForm).GetMethod("Initialize", new[] {typeof(int) });

            if(method == null)
            {
                throw new InvalidOperationException($"O formulário {typeof(TForm).Name} precisa ter um método Initialize(int)");
            }
            method.Invoke(form, new object[] { userId });

            return form;
        }
    }
}
