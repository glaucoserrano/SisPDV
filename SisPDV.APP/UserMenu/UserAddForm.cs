using SisPDV.Application.DTOs.Users;
using SisPDV.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisPDV.APP.User
{
    public partial class UserAddForm : Form
    {
        private readonly IUserService _userService;
        private int _editingUserId;
        public UserAddForm(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            this.CleanData();
        }
        private void CleanData()
        {
            txtName.Text = "";
            txtName.Focus();
            txtUser.Text = "";
            txtPassword.Text = "";
            txtPassword.Enabled = true;
            chkActive.Checked = true;
            btnSave.Text = "   Salvar";
            _editingUserId = 0;

        }
        private bool DataValidations()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Preencher o nome.", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("Preencher o usuário.", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUser.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Preencher a senha.", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (DataValidations())
            {
                try
                {
                    await SaveUserAsync();
                    CleanData();
                }
                catch (Exception ex) 
                {
                    MessageBox.Show($"Erro ao salvar usuário: {ex.Message}", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task SaveUserAsync()
        {
            if(_editingUserId == 0)
                {
                    var request = new UserRegisterDTO
                    {
                        Name = txtName.Text,
                        Login = txtUser.Text,
                        Password = txtPassword.Text,
                        Active = chkActive.Checked
                    };

                    await _userService.CreateUserAsync(request: request);
                    MessageBox.Show("Usuário criado com sucesso!", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var requestUpdate = new UserUpdateDTO
                    {
                        Id = _editingUserId,
                        Name = txtName.Text,
                        Login = txtUser.Text,
                        Active = chkActive.Checked
                    };

                    await _userService.UpdateUserAsync(request: requestUpdate);
                    MessageBox.Show("Usuário alterado com sucesso!", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            dgvSearch.DataSource = null;

            var users = await _userService.FilterUsersAsync(
                name: txtSearchName.Text,
                login: txtSearchLogin.Text,
                active: chkSearchActive.Checked);

            configureDataGrid();

            dgvSearch.DataSource = users.
                Select(user => new
                {
                    user.Id,
                    user.Name,
                    user.Login,
                    Ativo = user.Active ? "Sim" : "Não"
                })
                .ToList();

        }

        private void configureDataGrid()
        {
            //dgvSearch.AutoGenerateColumns = false;
            dgvSearch.Columns.Clear();

            var colId = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                Name = "Id",
                Visible = false
            };
            dgvSearch.Columns.Add(colId);

            //name
            dgvSearch.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                Name = "Nome"
            });

            // Login
            dgvSearch.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Login",
                Name = "Login"
            });

            // Ativo
            dgvSearch.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Ativo",
                Name = "Ativo"
            });

        }

        private async void dgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvSearch.Rows[e.RowIndex];
                var userId = (int)row.Cells["Id"].Value;

                var user = await _userService.GetById(userId);

                if (user != null)
                {
                    txtName.Text = user.Name;
                    txtUser.Text = user.Login;
                    txtPassword.Text = user.Password;
                    txtPassword.Enabled = false;
                    chkActive.Checked = user.Active;

                    _editingUserId = user.Id;

                    btnSave.Text = "   Alterar";

                    tabControl.SelectedTab = tabRegister;
                }
            }
        }
    }
}
