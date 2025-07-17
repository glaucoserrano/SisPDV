using Microsoft.Extensions.DependencyInjection;
using SisPDV.APP.Factory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisPDV.APP.Factory.Service
{
    public class UserNameScopedFormFactory<TForm> : IUserNameScopedFormFactory<TForm>
        where TForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public UserNameScopedFormFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TForm Create(string userName)
        {
            var form = _serviceProvider.GetRequiredService<TForm>();

            var method = typeof(TForm).GetMethod("Initialize", new[] { typeof(string) });

            if (method == null)
            {
                throw new InvalidOperationException($"O formulário {typeof(TForm).Name} precisa ter um método Initialize(int)");
            }
            method.Invoke(form, new object[] { userName });

            return form;
        }
    }
}
