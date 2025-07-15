using SisPDV.APP.Main;
using SisPDV.Application.ExternalInterfaces;
using SisPDV.Application.Helper;
using SisPDV.Application.Interfaces;
using SisPDV.Infrastructure.Service;
using System.Runtime.CompilerServices;
using WindowsForms = System.Windows.Forms;

namespace SisPDV.APP.Login
{
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMenuService _menuService;
        private readonly IUserMenuService _userMenuService;
        private readonly ICnpjService _cnpjService;
        private readonly ICepService _cepService;
        private readonly ICompanyService _companyServices;
        private readonly IPrinterSerctorsServices _printerSectorsServices;
        private readonly IConfigService _configServices;
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
        private readonly ICashRegisterService _cashRegisterService;
        private readonly ICashMovementService _cashMovementService;

        public LoginForm(
            IUserService userService, 
            ICurrentUserService currentUserService,
            IMenuService menuService,
            IUserMenuService userMenuService,
            ICnpjService cnpjService,
            ICepService cepService,
            ICompanyService companyServices,
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
            IStockMovementService stockMovementService,
            ICashRegisterService cashRegisterService,
            ICashMovementService cashMovementService)
        {
            InitializeComponent();
            _userService = userService;
            _currentUserService = currentUserService;
            _menuService = menuService;
            _userMenuService = userMenuService;
            _cnpjService = cnpjService;
            _cepService = cepService;
            _companyServices = companyServices;
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
            _cashRegisterService = cashRegisterService;
            _cashMovementService = cashMovementService;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                if (DataValidations())
                {
                    var userAuth = await _userService.AuthenticateUserAsync(
                        login: txtUser.Text.ToLower(),
                        password: txtPassword.Text);

                    if (userAuth == null)
                    {
                        MessageBox.Show("Usuário ou Senha Inválido", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var config = await _configServices.GetConfigAsync();
                    SystemConfig.Load(config);

                    _currentUserService.CurrentUser = userAuth!.Name;
                    var mainForm = new MainForm(
                        userId: userAuth?.Id, 
                        userName: userAuth?.Name, 
                        userService: _userService, 
                        menuService: _menuService,
                        userMenuService: _userMenuService,
                        cnpjService: _cnpjService,
                        cepService: _cepService,
                        companyService: _companyServices,
                        printerSectorsServices: _printerSectorsServices,
                        configServices: _configServices,
                        personService: _personService,
                        productTypeService: _productTypeService,
                        cfopService: _cfopService,
                        unityService: _unityService,
                        productService: _productService,
                        categoryService: _categoryService,
                        accountantService: _accountantService,
                        paymentMethodService: _paymentMethodService,
                        productStockService: _productStockService,
                        stockMovementService: _stockMovementService,
                        cashRegisterService: _cashRegisterService,
                        cashMovementService: _cashMovementService);
                    mainForm.WindowState = FormWindowState.Maximized;

                    mainForm.FormClosed += (s, e) => this.Close();
                    mainForm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool DataValidations()
        {
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("Preencha o usuário", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUser.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Preencha a senha", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return false;

            }
            return true;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            this.CleanData();
        }

        private void CleanData()
        {
            txtPassword.Text = "";
            txtUser.Text = "";
            txtUser.Focus();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.PerformClick();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtUser.Text.Length == 0 || txtPassword.Text.Length == 0)
            {
                WindowsForms.Application.Exit();
            }
        }
    }
}
