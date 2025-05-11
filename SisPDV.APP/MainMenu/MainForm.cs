using SisPDV.APP.CompanyMenu;
using SisPDV.APP.Config;
using SisPDV.APP.ConfigMenu;
using SisPDV.APP.PermissionMenu;
using SisPDV.APP.User;
using SisPDV.Application.ExternalInterfaces;
using SisPDV.Application.Interfaces;
using System.Reflection;
using System.Text.Json;
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
            IConfigService configServices)
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

            string? version = Assembly.
                GetExecutingAssembly().
                GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                .InformationalVersion.Split('+')[0];

            this.Text = $"SisPDV - Sistema de Vendas versão: {version}";
            sslUser.Text = $"Usuário: {_userName} - Caixa {GetPDVNumber()} - Data/Hora {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}";
            _menuService = menuService;
            _cepService = cepService;
            _companyService = companyService;
            _printerSectorsServices = printerSectorsServices;
            _configServices = configServices;
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
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config-caixa.json");
            if (!File.Exists(path))
                return "Não configurado";

            var json = File.ReadAllText(path);
            var config = JsonSerializer.Deserialize<PDVConfig>(json);
            return config?.numberPDV.ToString() ?? "Não configurado";
        }

        private async Task LoadMenuAsync()
        {
            var user = await _userService.GetById(_userID);

            var menus = user!.Login == "admin" ?
                await _menuService.GetAllMenuAsync() :
                await _menuService.GetMenusUserIdAsync(user.Id);

            var rootMenus = menus.Where(m => m.ParentId == null).OrderBy(m => m.Order);

            foreach( var root in rootMenus)
            {
                var rootMenuItem = new ToolStripMenuItem(root.Title);
                MainMenuStrip!.Items.Add(rootMenuItem);

                var childMenus = menus.Where(m => m.ParentId == root.Id).OrderBy(m => m.Order);

                foreach(var child in childMenus)
                {
                    var menuItem = new ToolStripMenuItem(child.Title);
                    menuItem.Tag = child.FormName;
                    menuItem.Click += MenuItem_Click;
                    rootMenuItem.DropDownItems.Add(menuItem);
                }
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
                    "ConfigForm" => new ConfigForm(_printerSectorsServices,_configServices),
                    _ => null
                };
                form?.ShowDialog();
            }
        }
    }
}
