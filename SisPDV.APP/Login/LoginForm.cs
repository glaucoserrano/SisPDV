using SisPDV.Application.Interfaces;
using System.Threading.Tasks;

namespace SisPDV.APP.Login
{
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;
        public LoginForm(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var userAuth = await _userService.AuthenticateUserAsync(login: txtUser.Text, password: txtPassword.Text);

            if(userAuth == null)
            {
                MessageBox.Show("Usuário ou Senha Inválido");
            }


            this.CleanData();
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
    }
}
