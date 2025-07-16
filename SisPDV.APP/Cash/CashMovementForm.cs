using SisPDV.APP.Helpers;
using SisPDV.Application.DTOs.Cash;
using SisPDV.Application.DTOs.Stock;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Enum;
using SisPDV.Domain.Helpers;
using SisPDV.Infrastructure.Globals;
using System.Text;
using System.Threading.Tasks;

namespace SisPDV.APP.Cash
{
    public partial class CashMovementForm : Form
    {
        private CashMovementType _cashMovementType;
        private readonly string? _userName;
        private readonly ICashMovementService _cashMovementService;
        public CashMovementForm(ICashMovementService cashMovementService, string? userName)
        {
            InitializeComponent();
            _cashMovementService = cashMovementService;
            _userName = userName;
        }

        private void rdoCashWithdrawal_CheckedChanged(object sender, EventArgs e)
        {
            btnMovementCash.IconChar = FontAwesome.Sharp.IconChar.MinusSquare;
            btnMovementCash.IconColor = Color.DarkRed;
            btnMovementCash.Text = "Sangria";
            _cashMovementType = CashMovementType.Exit; // Sangria
        }
        private void rdoCashSupply_CheckedChanged(object sender, EventArgs e)
        {
            btnMovementCash.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            btnMovementCash.IconColor = Color.DarkGreen;
            btnMovementCash.Text = "Suprimento";
            _cashMovementType = CashMovementType.Entry; // Suprimento
        }
        private void CashMovementForm_Load(object sender, EventArgs e)
        {
            ReportTextHelper.ConfigureReceiptPreview(rtbReceiptPreview);
            txtDate.Text = DateTime.UtcNow.Date.ToString("dd/MM/yyyy");
            txtCashNumber.Text = CashNumberHelper.GetPDVNumber();
            lblStatus.Text = CashRegisterStatus.StatusMessage;
            _cashMovementType = CashMovementType.Entry; // Padrão para Suprimento
            if( CashRegisterStatus.IsOpen)
            {
                rdoCashSupply.Enabled = true;
                rdoCashWithdrawal.Enabled = true;
            }
            else
            {
                rdoCashSupply.Enabled = false;
                rdoCashWithdrawal.Enabled = false;
                btnMovementCash.Enabled = false;
            }
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustDecimal(txtValue.Text, e.KeyChar))
                e.Handled = true;
        }

        private async void btnMovementCash_Click(object sender, EventArgs e)
        {
            try
            {
                var request = MapFormToDTO();

                var result = await ValidateData(request);

                if (!result)
                {
                    return;
                }
                await _cashMovementService.SaveCashMovementAsync(request);

                MessageBox.Show("Movimento de caixa registrado com sucesso!", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Information);

                rtbReceiptPreview.Clear();
                ShowMovementReceipt(request);
                cleanData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registrar movimento de caixa: {ex.Message}", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cleanData()
        {
            txtValue.Clear();
            txtNote.Clear();
            rdoCashSupply.Checked = true;
        }

        private void ShowMovementReceipt(CashMovementDTO result)
        {
            var sb = new StringBuilder();
            if(result.Type == CashMovementType.Entry)
            {
                sb.AppendLine(ReportTextHelper.CenterLine("=== SUPRIMENTO DE CAIXA ==="));
            }
            else if(result.Type == CashMovementType.Exit)
            {
                sb.AppendLine(ReportTextHelper.CenterLine("=== SANGRIA DE CAIXA ==="));
            }
            sb.AppendLine(ReportTextHelper.CenterLine($"Caixa: {CashNumberHelper.GetPDVNumber()}"));
            sb.AppendLine(ReportTextHelper.CenterLine($"Data: {txtDate.Text:dd/MM/yyyy HH:mm}"));
            sb.AppendLine(ReportTextHelper.CenterLine($"Valor : R$ {PriceConverter.FromCents(result.Amount):N2}"));
            sb.AppendLine(ReportTextHelper.CenterLine($"Observação : {result.Description}"));
            sb.AppendLine(ReportTextHelper.CenterLine("=========================="));
            sb.AppendLine(ReportTextHelper.CenterLine($"Operador: {_userName}"));
            sb.AppendLine(ReportTextHelper.CenterLine("Sistema SisPDV"));

            rtbReceiptPreview.Text = sb.ToString();
        }
        private async Task<bool> ValidateData(CashMovementDTO request)
        {
            var validate = await _cashMovementService.ValidateAsync(request);

            if (!validate.IsValid)
            {
                MessageBox.Show(string.Join("\n", validate.Errors), "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private CashMovementDTO MapFormToDTO()
        {
            return new CashMovementDTO
            {
                CashRegisterId = CashRegisterStatus.CashRegisterId!.Value,
                
                Type = _cashMovementType,
                Amount = PriceConverter.ToCents(Decimal.TryParse(txtValue.Text, out var amount) ? amount : 0),
                Description = txtNote.Text.Trim(),
                Origin = nameof(CashMovementForm)
            };
        }
    }
}
