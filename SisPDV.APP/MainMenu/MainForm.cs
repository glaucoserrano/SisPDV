using Microsoft.Extensions.DependencyInjection;
using SisPDV.APP.Accountant;
using SisPDV.APP.Cash;
using SisPDV.APP.Categories;
using SisPDV.APP.CFOP;
using SisPDV.APP.CompanyMenu;
using SisPDV.APP.ConfigMenu;
using SisPDV.APP.Factory.Interface;
using SisPDV.APP.Factory.Service;
using SisPDV.APP.Helpers;
using SisPDV.APP.PaymentMethod;
using SisPDV.APP.PermissionMenu;
using SisPDV.APP.PersonMenu;
using SisPDV.APP.ProductMenu;
using SisPDV.APP.Products.TypeProductsMenu;
using SisPDV.APP.Stock;
using SisPDV.APP.User;
using SisPDV.Application.DTOs.Menus;
using SisPDV.Application.Interfaces;
using SisPDV.Infrastructure.Globals;
using System.Reflection;
using WindowsForms = System.Windows.Forms;

namespace SisPDV.APP.Main
{
    public partial class MainForm : Form
    {
        private readonly IUserService _userService;
        private readonly IMenuService _menuService;
        private readonly IServiceProvider _serviceProvider;
        private readonly ICompanyService _companyService;
        private readonly ICashRegisterService _cashRegisterService;

        private int? _userID;
        private string? _userName;

        private readonly Dictionary<string, Func<Form>> _formFactories;


        public MainForm(
            IUserService userService,
            IMenuService menuService,
            IServiceProvider serviceProvider,
            ICompanyService companyService,
            ICashRegisterService cashRegisterService,
            IUserScopedFormFactory<UserChangePassword> changePasswordFactory,
            IUserScopedFormFactory<CompanyForm> companyFormFactory,
            IUserNameScopedFormFactory<CashClosingForm> cashClosingFactory,
            IUserNameScopedFormFactory<CashMovementForm> CashMovementFactory,
            IUserNameScopedFormFactory<CashOpeningForm> cashOpeningFactory
           )
        {
            InitializeComponent();
            _userService = userService;
            _menuService = menuService;
            _serviceProvider = serviceProvider;
            _companyService = companyService;
            _cashRegisterService = cashRegisterService;
            _formFactories = new Dictionary<string, Func<Form>>
            {
                {"UserAddForm", () => _serviceProvider.GetRequiredService<UserAddForm>() },
                { "CFOPForm", () => _serviceProvider.GetRequiredService<CFOPForm>() },
                { "ConfigForm", () => _serviceProvider.GetRequiredService<ConfigForm>() },
                { "PermissionMenuForm", () => _serviceProvider.GetRequiredService<PermissionMenuForm>() },
                { "ProductForm", () => _serviceProvider.GetRequiredService<ProductForm>() },
                { "CategoriesForm", () => _serviceProvider.GetRequiredService<CategoriesForm>() },
                { "PersonForm", () => _serviceProvider.GetRequiredService<PersonForm>() },
                { "TypeProductsForm", () => _serviceProvider.GetRequiredService<TypeProductsForm>() },
                { "AccountantForm", () => _serviceProvider.GetRequiredService<AccountantForm>() },
                { "PaymentMethodForm", () => _serviceProvider.GetRequiredService<PaymentMethodForm>() },
                { "StockForm", () => _serviceProvider.GetRequiredService<StockForm>() },
                { "StockEntryForm", () => _serviceProvider.GetRequiredService<StockEntryForm>() },

                { "UserChangePassword", () => changePasswordFactory.Create(_userID ?? 0) },
                { "CompanyForm", () => companyFormFactory.Create(_userID ?? 0) },
                { "CashClosingForm", () => cashClosingFactory.Create(_userName ?? "") },
                { "CashMovementForm", () => CashMovementFactory.Create(_userName ?? "") },
                { "CashOpeningForm", () => cashOpeningFactory.Create(_userName ?? "") }
            };

            string? version = Assembly.
                GetExecutingAssembly().
                GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                .InformationalVersion.Split('+')[0];

            this.Text = $"SisPDV - Sistema de Vendas versão: {version}";
            sslUser.Text = $"Usuário: {_userName} - Caixa {GetPDVNumber()} - Data/Hora {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}";
            
        }
        public void Initialize(int userId, string userName)
        {
            _userID = userId;
            _userName = userName;
        }
        private async void MainForm_Load(object sender, EventArgs e)
        {
            var empresa = await _companyService.GetAsync();
            var hash = await _companyService.GetCnpjHashAsync();
            
            if(empresa != null)
            {
                var cnpjValidate = await _companyService.ValidateHash(empresa.CNPJ, hash);

                if (!cnpjValidate)
                {
                    MessageBox.Show("Sistema inválido ou violado. CNPJ não corresponde.", "SisPDV", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    WindowsForms.Application.Exit();
                }
            }
            
            await LoadMenuAsync();
            await CheckCashStatusAsync();
            UpdateFooterCashStatus();

        }
        private void UpdateFooterCashStatus()
        {
            sslUser.Text += $" - Status do Caixa: {CashRegisterStatus.StatusMessage}";
        }
        private async Task CheckCashStatusAsync()
        {
            var cashNumber = Convert.ToInt32(CashNumberHelper.GetPDVNumber());

            var lastCash = await _cashRegisterService.CanOpenCashRegisterAsync(cashNumber);

            if (lastCash is null)
            {
                CashRegisterStatus.IsOpen = false;
                CashRegisterStatus.StatusMessage = "Caixa nunca foi aberto.";
                return;
            }

            if (lastCash.CloseDate == DateTime.MinValue && lastCash.OpenDate.Date == DateTime.Today.Date)
            {
                CashRegisterStatus.IsOpen = true;
                CashRegisterStatus.CashRegisterId = lastCash.Id;
                CashRegisterStatus.OpenDate = lastCash.OpenDate;
                CashRegisterStatus.StatusMessage = $"Caixa aberto em {lastCash.OpenDate.ToLocalTime():dd/MM/yyyy HH:mm}";
            }
            else if (lastCash.CloseDate == DateTime.MinValue && lastCash.OpenDate < DateTime.UtcNow)
            {
                CashRegisterStatus.IsOpen = true;
                CashRegisterStatus.CashRegisterId = lastCash.Id;
                CashRegisterStatus.OpenDate = lastCash.OpenDate;
                CashRegisterStatus.StatusMessage = $"Caixa de {lastCash.OpenDate:dd/MM} não foi fechado!";
            }
            else
            {
                CashRegisterStatus.IsOpen = false;
                CashRegisterStatus.StatusMessage = $"Caixa fechado em {lastCash.CloseDate?.ToLocalTime():dd/MM/yyyy HH:mm}";
            }
        }

        private static string GetPDVNumber()
        {
            var cashNumber = CashNumberHelper.GetPDVNumber();

            return cashNumber;
        }

        private async Task LoadMenuAsync()
        {
            var user = await _userService.GetById(_userID);

            var menus = user!.Login == "admin" ?
                await _menuService.GetAllMenuAsync() :
                await _menuService.GetMenusUserIdAsync(user.Id);

            var ordernedMenus = menus.OrderBy(m => m.Order).ToList();
            var rootMenus = ordernedMenus.Where(m => m.ParentId == null);

            foreach (var root in rootMenus)
            {
                var rootItem = new ToolStripMenuItem(root.Title);
                rootItem.Tag = root.FormName;

                AddChild(rootItem, root.Id, ordernedMenus);

                MainMenuStrip!.Items.Add(rootItem);
            }
            var configMenu = MainMenuStrip!.Items.Cast<ToolStripMenuItem>()
                .FirstOrDefault(m => m.Text == "Configurações");

            if(configMenu != null)
            {
                var changePwd = new ToolStripMenuItem("Alterar Senha")
                {
                    Tag = "UserChangePassword"
                };
                changePwd.Click += MenuItem_Click;
                configMenu.DropDownItems.Add(changePwd);
            }
        }
        private void AddChild(ToolStripMenuItem parentItem, int parentId, List<MenuDTO> ordernedMenus)
        {
            var children = ordernedMenus
                .Where(m => m.ParentId == parentId)
                .OrderBy(m => m.Order);

            foreach (var child in children)
            {
                var childItem = new ToolStripMenuItem(child.Title)
                {
                    Tag = child.FormName
                };

                childItem.Click += MenuItem_Click;

                AddChild(childItem, child.Id, ordernedMenus);

                parentItem.DropDownItems.Add(childItem);
            }
        }
        
        private void MenuItem_Click(Object? sender, EventArgs e)
        {
            if(sender is ToolStripMenuItem menuItem && menuItem.Tag is string formTypeName)
            {
                // Primeiro tenta resolver via dicionário (forms com parâmetros)
                if (_formFactories.TryGetValue(formTypeName, out var formResolver))
                {
                    var form = formResolver();
                    form.ShowDialog();
                    return;
                }

                // Se não estiver no dicionário, tenta resolver via factory genérica (sem parâmetros)
                var type = Type.GetType(formTypeName);
                if (type == null)
                {
                    MessageBox.Show("Formulário não encontrado: " + formTypeName);
                    return;
                }

                var factoryType = typeof(IFormFactory<>).MakeGenericType(type);
                var factory = _serviceProvider.GetService(factoryType) as dynamic;

                if (factory is not null)
                {
                    Form form = factory.Create();
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Erro ao carregar formulário: " + formTypeName);
                }
            }
        }
    }
}
