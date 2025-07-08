using SisPDV.APP.Helpers;
using SisPDV.Application.DTOs.PaymentMethod;
using SisPDV.Application.Interfaces;
using SisPDV.Application.Services;
using SisPDV.Domain.Enum;
using System.Threading.Tasks;

namespace SisPDV.APP.PaymentMethod
{
    public partial class PaymentMethodForm : Form
    {
        private readonly IPaymentMethodService _paymentMethodService;
        private int _paymentMethodId;

        public PaymentMethodForm(IPaymentMethodService paymentMethodService)
        {
            InitializeComponent();
            _paymentMethodService = paymentMethodService;
        }

        private async void PaymentMethodForm_Load(object sender, EventArgs e)
        {
            _paymentMethodId = 0;
            rbAll.Checked = true;
            configGridPaymentMethod();
            await LoadPaymentMethodAsync();
            LoadComboBox();
        }
        private async Task LoadPaymentMethodAsync()
        {
            try
            {
                var paymentMethods = await _paymentMethodService.GetPaymentMethodAsync();
                dgvPayments.DataSource = paymentMethods;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar Formas de Pagamento:{ex.Message}", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void configGridPaymentMethod()
        {
            dgvPayments.ReadOnly = true;
            dgvPayments.AutoGenerateColumns = false;
            dgvPayments.AllowUserToAddRows = false;
            dgvPayments.AllowUserToDeleteRows = false;
            dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayments.MultiSelect = false;
            dgvPayments.RowHeadersVisible = false;

            dgvPayments.Columns.Clear();

            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "Id",
                DataPropertyName = "Id",
                Visible = false
            });

            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDescription",
                HeaderText = "Descrição",
                DataPropertyName = "Description",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSefazCodeDescription",
                HeaderText = "Codigo Sefaz",
                DataPropertyName = "SefazCodeDescription",
                Width = 140
            });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSefazCode",
                HeaderText = "Codigo Sefaz",
                DataPropertyName = "SefazCode",
                Width = 140,
                Visible = false
            });
        }

        private void LoadComboBox()
        {
            LoadEnumToComboHelper.LoadEnumToComboBox<SefazPaymentCode>(cmbSefazCode, true, "00 - Selecione");
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var request = MapFormToDTO();
            var result = await validateData(request);

            if (!result)
                return;

            await _paymentMethodService.SaveAsync(request);

            if (_paymentMethodId == 0)
            {
                MessageBox.Show("Cadastro salvo com sucesso", "Sis_PDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cadastro alterado com sucesso", "Sis_PDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            cleanData();
            await LoadPaymentMethodAsync();
        }

        private void cleanData()
        {
            _paymentMethodId = 0;
            txtDescription.Text = string.Empty;

            if (cmbSefazCode.Items.Count > 0)
                cmbSefazCode.SelectedIndex = 0;

            chkActive.Checked = true;

            // Opcional: volta o foco para o primeiro campo
            txtDescription.Focus();
        }

        private async Task<bool> validateData(PaymentMethodDTO request)
        {
            var validate = await _paymentMethodService.ValidateAsync(request);

            if (!validate.IsValid)
            {
                MessageBox.Show(string.Join("\n", validate.Errors), "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private PaymentMethodDTO MapFormToDTO()
        {
            return new PaymentMethodDTO
            {
                Id = _paymentMethodId,
                Description = txtDescription.Text.Trim(),
                SefazCode = Enum.TryParse<SefazPaymentCode>(cmbSefazCode.SelectedValue?.ToString(), out var sefazCode) ? sefazCode : 0,
                IsActive = chkActive.Checked,
            };
        }
        private async void dgvPayments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var id = (int)dgvPayments.Rows[e.RowIndex].Cells["colId"].Value;

                var paymentMethod = await _paymentMethodService.GetByIdAsync(id);

                if (paymentMethod != null)
                {
                    txtDescription.Text = paymentMethod.Description;
                    cmbSefazCode.SelectedIndex = (int)paymentMethod.SefazCode;
                    chkActive.Checked = paymentMethod.IsActive;


                    _paymentMethodId = id;
                }
            }
        }
        private async Task LoadAsyncSearchPaymentMethod()
        {
            var search = txtSearch.Text;
            var statusFilter = GetStatusFilter();

            var list = await _paymentMethodService.SearchAsync(search, statusFilter);

            dgvPayments.DataSource = list;
        }

        private int GetStatusFilter()
        {
            if (rbActive.Checked) return 0; //ativo
            if (rbInactive.Checked) return 1; //inativo
            return -1; //todos
        }
        private void btnClean_Click(object sender, EventArgs e)
        {
            cleanData();
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            await LoadAsyncSearchPaymentMethod();
        }

        private async void rbActive_CheckedChanged(object sender, EventArgs e)
        {
            await LoadAsyncSearchPaymentMethod();
        }

        private async void rbInactive_CheckedChanged(object sender, EventArgs e)
        {
            await LoadAsyncSearchPaymentMethod();
        }

        private async void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            await LoadAsyncSearchPaymentMethod();
        }
    }
}
