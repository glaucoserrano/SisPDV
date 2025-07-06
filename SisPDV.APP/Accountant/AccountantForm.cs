using SisPDV.Application.DTOs.Accountant;
using SisPDV.Application.ExternalInterfaces;
using SisPDV.Application.Interfaces;
using SisPDV.Application.Services;
using SisPDV.Domain.Helpers;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
                txtCityCode.Text = cepDto.ibge;
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
        }

        private async Task<bool> validateData(AccountantDTO request)
        {
            var validate = await _accountantService.ValidateAsync(request);

            if (!validate.IsValid)
            {
                MessageBox.Show(string.Join("\n", validate.Errors), "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true; ;
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
    }
}
