using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SisPDV.APP.Accountant;
using SisPDV.APP.Cash;
using SisPDV.APP.Categories;
using SisPDV.APP.CFOP;
using SisPDV.APP.CompanyMenu;
using SisPDV.APP.ConfigMenu;
using SisPDV.APP.Factory.Interface;
using SisPDV.APP.Factory.Service;
using SisPDV.APP.Login;
using SisPDV.APP.Main;
using SisPDV.APP.PaymentMethod;
using SisPDV.APP.PermissionMenu;
using SisPDV.APP.PersonMenu;
using SisPDV.APP.ProductMenu;
using SisPDV.APP.Products.TypeProductsMenu;
using SisPDV.APP.Stock;
using SisPDV.APP.User;
using SisPDV.Application.ExternalInterfaces;
using SisPDV.Application.ExternalServices;
using SisPDV.Application.Interfaces;
using SisPDV.Application.Services;
using SisPDV.Infrastructure.Persistence;
using SisPDV.Infrastructure.Service;
using System.Configuration;

namespace SisPDV.APP.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static IServiceProvider Configure()
        {
            var service = new ServiceCollection();

            var connectionString = ConfigurationManager.ConnectionStrings["PDVDb"].ConnectionString;
            
            service.AddScoped<ICurrentUserService, CurrentUserService>();


            service.AddDbContext<PDVDbContext>(option =>
            {
                option.UseNpgsql(connectionString);
            });


            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IMenuService, MenuService>();
            service.AddScoped<IUserMenuService, UserMenuService>();
            service.AddScoped<ICompanyService, CompanyService>();
            service.AddScoped<IPrinterSerctorsServices, PrinterSectorsService>();
            service.AddScoped<IConfigService, ConfigService>();
            service.AddScoped<IPersonService, PersonService>();
            service.AddScoped<IProductTypeService, ProductTypeService>();
            service.AddScoped<ICfopService, CfopService>();
            service.AddScoped<IUnityService, UnityService>();
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<IAccountantService, AccountantService>();
            service.AddScoped<IPaymentMethodService, PaymentMethodService>();
            service.AddScoped<IProductStockService, ProductStockService>();
            service.AddScoped<IStockMovementService, StockMovementService>();
            service.AddScoped<ICashRegisterService, CashRegisterService>();
            service.AddScoped <ICashMovementService, CashMovementService>();

            service.AddScoped <ICnpjService, CnpjService>();
            service.AddScoped <ICepService, CepService>();

            service.AddScoped<IMainFormFactory, MainFormFactory>();
            service.AddScoped(typeof(IUserScopedFormFactory<>), typeof(UserScopedFormFactory<>));
            service.AddScoped(typeof(IUserNameScopedFormFactory<>), typeof(UserNameScopedFormFactory<>));


            service.AddScoped<LoginForm>();
            service.AddScoped<MainForm>();

            service.AddTransient<UserChangePassword>();
            service.AddTransient<UserAddForm>();
            service.AddTransient<CompanyForm>();
            service.AddTransient<CFOPForm>();
            service.AddTransient<ConfigForm>();
            service.AddTransient<PermissionMenuForm>();
            service.AddTransient<ProductForm>();
            service.AddTransient<CategoriesForm>();
            service.AddTransient<PersonForm>();
            service.AddTransient<TypeProductsForm>();
            service.AddTransient<AccountantForm>();
            service.AddTransient<PaymentMethodForm>();
            service.AddTransient<StockForm>();
            service.AddTransient<StockEntryForm>();
            service.AddTransient<CashClosingForm>();
            service.AddTransient<CashMovementForm>();
            service.AddTransient<CashOpeningForm>();


            service.AddScoped(typeof(IUserScopedFormFactory<>), typeof(UserScopedFormFactory<>));
            service.AddScoped(typeof(IUserNameScopedFormFactory<>), typeof(UserNameScopedFormFactory<>));

            service.AddScoped(typeof(IFormFactory<>), typeof(FormFactory<>));

            return service.BuildServiceProvider();
        }
    }
}
