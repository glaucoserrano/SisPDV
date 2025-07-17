using SisPDV.APP.Factory.Interface;
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
        private readonly IConfigService _configServices;
        private readonly IMainFormFactory _mainFormFactory;

        public LoginForm(
            IUserService userService, 
            ICurrentUserService currentUserService,
            IConfigService configService,
            IMainFormFactory mainFormFactory)
        {
            InitializeComponent();
            _userService = userService;
            _currentUserService = currentUserService;
            _configServices = configService;
            _mainFormFactory = mainFormFactory;
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

                    var mainForm = _mainFormFactory.Create(userAuth.Id, userAuth.Name);

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
