using SisPDV.APP.Accountant;
using SisPDV.APP.Categories;
using SisPDV.APP.CFOP;
using SisPDV.APP.CompanyMenu;
using SisPDV.APP.ConfigMenu;
using SisPDV.APP.Helpers;
using SisPDV.APP.PaymentMethod;
using SisPDV.APP.PermissionMenu;
using SisPDV.APP.PersonMenu;
using SisPDV.APP.ProductMenu;
using SisPDV.APP.Products.TypeProductsMenu;
using SisPDV.APP.Stock;
using SisPDV.APP.User;
using SisPDV.Application.DTOs.Menus;
using SisPDV.Application.ExternalInterfaces;
using SisPDV.Application.Interfaces;
using System.Reflection;
using WindowsForms = System.Windows.Forms;

namespace SisPDV.APP.Main
{
    public partial class MainForm : Form
    {
        private readonly IUserService _userService;
        private readonly IMenuService _menuService;
        private readonly IUserMenuService _userMenuService;
        private readonly ICompanyService _companyService;
        private readonly IPrinterSerctorsServices _printerSectorsServices;
        private readonly IConfigService _configServices;
        private readonly ICnpjService _cnpjService;
        private readonly ICepService _cepService;
        private readonly IPersonService _personService;
        private readonly IProductTypeService _productTypeService;
        private readonly ICfopService _cfopService;
        private readonly IUnityService _unityService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IAccountantService _accountantService;
        private readonly IPaymentMethodService _paymentMethodService;
        private readonly IProductStockService _productStockService;
        private readonly IStockMovementService _stockMovementService;

        private readonly int? _userID;
        private readonly string? _userName;


        public MainForm(
            int? userId,
            string? userName,
            IUserService userService,
            IMenuService menuService,
            IUserMenuService userMenuService,
            ICnpjService cnpjService,
            ICepService cepService,
            ICompanyService companyService,
            IPrinterSerctorsServices printerSectorsServices,
            IConfigService configServices,
            IPersonService personService,
            IProductTypeService productTypeService,
            ICfopService cfopService,
            IUnityService unityService,
            IProductService productService,
            ICategoryService categoryService,
            IAccountantService accountantService,
            IPaymentMethodService paymentMethodService,
            IProductStockService productStockService,
            IStockMovementService stockMovementService
           )
        {
            InitializeComponent();
            _userID = userId;
            _userName = userName;
            _userService = userService;
            _menuService = menuService;
            _userMenuService = userMenuService;
            _cnpjService = cnpjService;
            _cepService = cepService;
            _companyService = companyService;
            _printerSectorsServices = printerSectorsServices;
            _configServices = configServices;
            _personService = personService;
            _productTypeService = productTypeService;
            _cfopService = cfopService;
            _unityService = unityService;
            _productService = productService;
            _categoryService = categoryService;
            _accountantService = accountantService;
            _paymentMethodService = paymentMethodService;
            _productStockService = productStockService;
            _stockMovementService = stockMovementService;

            string? version = Assembly.
                GetExecutingAssembly().
                GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                .InformationalVersion.Split('+')[0];

            this.Text = $"SisPDV - Sistema de Vendas versão: {version}";
            sslUser.Text = $"Usuário: {_userName} - Caixa {GetPDVNumber()} - Data/Hora {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}";
            
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
        }
        private static string GetPDVNumber()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            var cashNumber = CashNumberHelper.GetCashNumber(path);

            if(cashNumber == 0 )
                return "Não configurado";

            return cashNumber.ToString() ?? "Não configurado";

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
            if(sender is ToolStripMenuItem menuItem && menuItem.Tag is string formName)
            {
                Form? form = formName switch
                {
                    "UserAddForm" => new UserAddForm(_userService),
                    "UserChangePassword" => new UserChangePassword(_userID, _userService),
                    "PermissionMenuForm" => new PermissionMenuForm(_userService, _menuService, _userMenuService),
                    "CompanyForm" => new CompanyForm(_cnpjService, _cepService, _companyService, _userID, _userService),
                    "ConfigForm" => new ConfigForm(_printerSectorsServices, _configServices),
                    "PersonForm" => new PersonForm(_cepService, _personService),
                    "TypeProductsForm" => new TypeProductsForm(_companyService, _productTypeService, _cfopService),
                    "ProductForm" => new ProductForm(
                        _productTypeService,
                        _cfopService,
                        _companyService,
                        _unityService,
                        _configServices,
                        _productService,
                        _categoryService),
                    "CFOPForm" => new CFOPForm(_cfopService),
                    "CategoriesForm" => new CategoriesForm(_categoryService),
                    "AccountantForm" => new AccountantForm(_cepService, _accountantService),
                    "PaymentMethodForm" => new PaymentMethodForm(_paymentMethodService),
                    "StockForm" => new StockForm(_productService, _productStockService),
                    "StockEntryForm" => new StockEntryForm(_productService, _stockMovementService, _productStockService),
                    _ => null
                };
                form?.ShowDialog();
            }
        }
    }
}
