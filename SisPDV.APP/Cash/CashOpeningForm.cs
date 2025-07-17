using SisPDV.APP.Helpers;
using SisPDV.Application.DTOs.Cash;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Helpers;
using SisPDV.Infrastructure.Globals;
using System.Text;

namespace SisPDV.APP.Cash
{
    public partial class CashOpeningForm : Form
    {
        private string _userName;

        private readonly ICashRegisterService _cashRegisterService;
        public CashOpeningForm(ICashRegisterService cashRegisterService)
        {
            InitializeComponent();
            _cashRegisterService = cashRegisterService;
        }
        public void Initialize(string userName)
        {
            _userName = userName;
        }

        private async void CashOpeningForm_Load(object sender, EventArgs e)
        {
            ReportTextHelper.ConfigureReceiptPreview(rtbReceiptPreview);
            txtDate.Text = DateTime.UtcNow.Date.ToString("dd/MM/yyyy");
            txtCashNumber.Text = CashNumberHelper.GetPDVNumber();
            lblStatus.Text = CashRegisterStatus.StatusMessage;
            await LoadCashOpeningIfExistsAsync();



            if (CashRegisterStatus.IsOpen)
            {
                btnOpenCash.IconChar = FontAwesome.Sharp.IconChar.Lock;
                btnOpenCash.IconColor = Color.DarkRed;
                btnOpenCash.Enabled = false;
                txtOpeningValue.Enabled = false;
            }
            else
            {
                btnOpenCash.IconChar = FontAwesome.Sharp.IconChar.Unlock;
                btnOpenCash.IconColor = Color.DarkGreen;
                btnOpenCash.Enabled = true;
                txtOpeningValue.Enabled = true;
            }
        }

        private async Task LoadCashOpeningIfExistsAsync()
        {
            var opening = await _cashRegisterService.GetTodayCashOpeningAsync(
                cashNumber: int.TryParse(txtCashNumber.Text, out var cashNumber) ? cashNumber : 0);
            if (opening != null)
            {
                // Preenche os campos com os dados da abertura existente
                txtOpeningValue.Text = PriceConverter.FromCents(opening.OpeningAmount).ToString("N2");
                txtOpeningValue.Enabled = false;

                // Mostra o espelho do cupom de abertura
                ShowOpeningReceipt(opening);

                // Desabilita botão de abrir caixa
                btnOpenCash.Enabled = false;
            }
            else
            {
                txtOpeningValue.Text = "";
                txtOpeningValue.Enabled = true;
                btnOpenCash.Enabled = true;
                rtbReceiptPreview.Clear();
            }
        }

        private void txtOpeningValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustDecimal(txtOpeningValue.Text, e.KeyChar))
                e.Handled = true;
        }

        private async void btnOpenCash_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await _cashRegisterService.OpenCashRegisterAsync(
                    cashNumber: int.TryParse(txtCashNumber.Text, out var cashNumber) ? cashNumber : 0,
                    openingAmount: decimal.TryParse(txtOpeningValue.Text, out var openingAmount) ? openingAmount : 0,
                    origin: nameof(CashOpeningForm)
                    );
                MessageBox.Show($"Caixa aberto com sucesso!\nNúmero do Caixa: {result.CashNumber}\nValor de Abertura: {PriceConverter.FromCents(result.OpeningAmount)}", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (CashRegisterStatus.IsOpen)
                {
                    btnOpenCash.IconChar = FontAwesome.Sharp.IconChar.Lock;
                    btnOpenCash.IconColor = Color.DarkRed;
                    btnOpenCash.Enabled = false;
                }
                ShowOpeningReceipt(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir o caixa: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowOpeningReceipt(CashRegisterDTO result)
        {
            var sb = new StringBuilder();

            sb.AppendLine(ReportTextHelper.CenterLine("=== ABERTURA DE CAIXA ==="));
            sb.AppendLine(ReportTextHelper.CenterLine($"Caixa: {result.CashNumber}"));
            sb.AppendLine(ReportTextHelper.CenterLine($"Data: {result.OpenDate.ToLocalTime():dd/MM/yyyy HH:mm}"));
            sb.AppendLine(ReportTextHelper.CenterLine($"Valor Inicial: R$ {PriceConverter.FromCents(result.OpeningAmount):N2}"));
            sb.AppendLine(ReportTextHelper.CenterLine("=========================="));
            sb.AppendLine(ReportTextHelper.CenterLine($"Operador: {_userName}"));
            sb.AppendLine(ReportTextHelper.CenterLine("Sistema SisPDV"));

            rtbReceiptPreview.Text = sb.ToString();
        }
    }
}
