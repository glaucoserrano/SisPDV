using SisPDV.Application.Interfaces;
using System.Threading.Tasks;

namespace SisPDV.APP.User
{
    public partial class UserChangePassword : Form
    {
        private readonly int? _userId;
        private readonly IUserService _userService;
        public UserChangePassword(int? userId, IUserService userService)
        {
            InitializeComponent();
            _userId = userId;
            _userService = userService;
        }

        private async void UserChangePassword_Load(object sender, EventArgs e)
        {
            var user = await _userService.GetById(_userId);

            if (user!.Login.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("A Senha do usuário ADMIN não pode ser alterada", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            txtLogin.Text = user.Login;
            txtLogin.Enabled = false;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (validateData())
            {
                try
                {
                    await _userService.ChangeUserPassword(login: txtLogin.Text, oldPassword: txtOldPassword.Text, newPassword: txtNewPassword.Text);
                    MessageBox.Show("Senha alterada com sucesso!", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Erro ao alterar senha: {ex.Message}", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool validateData()
        {
            if(string.IsNullOrEmpty(txtOldPassword.Text) || string.IsNullOrEmpty(txtNewPassword.Text))
            {
                MessageBox.Show("Todos os campos são obrigatórios.", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtOldPassword.Text.Equals(txtNewPassword.Text))
            {
                MessageBox.Show("A nova senha deve ser diferente da antiga.", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
