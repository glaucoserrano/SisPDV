using SisPDV.Application.DTOs.Accountant;
using SisPDV.Application.ExternalInterfaces;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Helpers;

namespace SisPDV.APP.Accountant
{
    public partial class AccountantForm : Form
    {
        private readonly ICepService _cepService;
        private readonly IAccountantService _accountantService;

        private int _accountantid;
        public AccountantForm(ICepService cepService, IAccountantService accountantService)
        {
            InitializeComponent();
            _cepService = cepService;
            _accountantService = accountantService;
        }
        private async void AccountantForm_Load(object sender, EventArgs e)
        {
            _accountantid = 0;
            rbAll.Checked = true;
            configGridAccountants();
            await LoadAccountantAsync();
        }

        private async Task LoadAccountantAsync()
        {
            try
            {
                var accountants = await _accountantService.GetAccountantAsync();
                dgvAccountants.DataSource = accountants;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar Categorias:{ex.Message}", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void configGridAccountants()
        {
            dgvAccountants.ReadOnly = true;
            dgvAccountants.AutoGenerateColumns = false;
            dgvAccountants.AllowUserToAddRows = false;
            dgvAccountants.AllowUserToDeleteRows = false;
            dgvAccountants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAccountants.MultiSelect = false;
            dgvAccountants.RowHeadersVisible = false;

            dgvAccountants.Columns.Clear();

            dgvAccountants.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "Id",
                DataPropertyName = "Id",
                Visible = false
            });

            dgvAccountants.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "Nome",
                DataPropertyName = "Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvAccountants.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCPF",
                HeaderText = "CPF",
                DataPropertyName = "CPF",
                Width = 120
            });

            dgvAccountants.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCNPJ",
                HeaderText = "CNPJ",
                DataPropertyName = "CNPJ",
                Width = 140
            });
        }
        private async void txtCEP_Leave(object sender, EventArgs e)
        {
            var cep = FormatHelper.OnlyNumber(txtCEP.Text);
            if (cep.Length > 0)
            {
                var cepDto = await _cepService.GetCepsync(cep);

                if (cepDto == null) return;

                txtStreet.Text = cepDto.logradouro;
                txtCity.Text = cepDto.localidade;
                txtDistrict.Text = cepDto.bairro;
                txtUF.Text = cepDto.uf;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var request = MapFormToDTO();
            var result = await validateData(request);

            if (!result)
                return;

            await _accountantService.SaveAsync(request);

            if (_accountantid == 0)
            {
                MessageBox.Show("Cadastro salvo com sucesso", "Sis_PDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cadastro alterado com sucesso", "Sis_PDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            cleanData();
            await LoadAccountantAsync();
        }

        private async Task<bool> validateData(AccountantDTO request)
        {
            var validate = await _accountantService.ValidateAsync(request);

            if (!validate.IsValid)
            {
                MessageBox.Show(string.Join("\n", validate.Errors), "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private AccountantDTO MapFormToDTO()
        {
            return new AccountantDTO
            {
                Id = _accountantid,
                Name = txtAccontant.Text.Trim(),
                CRC = txtCRC.Text.Trim(),
                CPF = txtCPF.Text.Trim(),
                CNPJ = txtCNPJ.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),

                Street = txtStreet.Text.Trim(),
                Number = txtNumber.Text.Trim(),
                District = txtDistrict.Text.Trim(),
                City = txtCity.Text.Trim(),
                State = txtUF.Text.Trim(),
                ZipCode = txtCEP.Text.Trim(),
                IsActive = chkActive.Checked,

            };
        }

        private async void dgvAccountants_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var id = (int)dgvAccountants.Rows[e.RowIndex].Cells["colId"].Value;

                var accountant = await _accountantService.GetByIdAsync(id);

                if (accountant != null)
                {
                    txtAccontant.Text = accountant.Name;
                    txtCRC.Text = accountant.CRC;
                    txtCPF.Text = accountant.CPF;
                    txtCNPJ.Text = accountant.CNPJ;
                    txtEmail.Text = accountant.Email;
                    txtPhone.Text = accountant.Phone;

                    txtStreet.Text = accountant.Street;
                    txtNumber.Text = accountant.Number;
                    txtDistrict.Text = accountant.District;
                    txtCity.Text = accountant.City;
                    txtUF.Text = accountant.State;
                    txtCEP.Text = accountant.ZipCode;
                    chkActive.Checked = accountant.IsActive;


                    _accountantid = id;
                }
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            cleanData();
        }
        private void cleanData()
        {
            txtAccontant.Text = "";
            txtCRC.Text = "";
            txtCPF.Text = "";
            txtCNPJ.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";

            txtStreet.Text = "";
            txtNumber.Text = "";
            txtDistrict.Text = "";
            txtCity.Text = "";
            txtUF.Text = "";
            txtCEP.Text = "";
            chkActive.Checked = true;


            _accountantid = 0;
        }
        private async Task LoadAsyncSearchAccountant()
        {
            var search = txtSearch.Text;
            var statusFilter = GetStatusFilter();

            var list = await _accountantService.SearchAsync(search, statusFilter);

            dgvAccountants.DataSource = list;
        }

        private int GetStatusFilter()
        {
            if (rbActive.Checked) return 0; //ativo
            if (rbInactive.Checked) return 1; //inativo
            return -1; //todos
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            await LoadAsyncSearchAccountant();
        }

        private async void rbActive_CheckedChanged(object sender, EventArgs e)
        {
            await LoadAsyncSearchAccountant();
        }

        private async void rbInactive_CheckedChanged(object sender, EventArgs e)
        {
            await LoadAsyncSearchAccountant();
        }

        private async void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            await LoadAsyncSearchAccountant();
        }
    }
}
