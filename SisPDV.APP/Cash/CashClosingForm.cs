using SisPDV.APP.Helpers;
using SisPDV.Application.DTOs.Cash;
using SisPDV.Application.Helper;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Entities;
using SisPDV.Domain.Enum;
using SisPDV.Domain.Helpers;
using SisPDV.Infrastructure.Globals;
using System.Text;
using System.Threading.Tasks;

namespace SisPDV.APP.Cash
{
    public partial class CashClosingForm : Form
    {
        private readonly string? _userName;
        private int _totalInClosed;
        private List<CashMovementDTO> _movements = new List<CashMovementDTO>();

        private readonly ICashRegisterService _cashRegisterService;
        private readonly ICashMovementService _cashMovementService;
        public CashClosingForm(ICashRegisterService cashRegisterService, string? userName, ICashMovementService cashMovementService)
        {
            InitializeComponent();
            _cashRegisterService = cashRegisterService;
            _userName = userName;
            _cashMovementService = cashMovementService;
        }

        private async void CashClosingForm_Load(object sender, EventArgs e)
        {
            ReportTextHelper.ConfigureReceiptPreview(rtbPreview);

            txtCashNumber.Text = CashNumberHelper.GetPDVNumber();
            lblStatus.Text = CashRegisterStatus.StatusMessage;

            if (CashRegisterStatus.IsOpen)
            {
                btnCloseCash.IconChar = FontAwesome.Sharp.IconChar.Unlock;
                btnCloseCash.IconColor = Color.DarkGreen;
            }
            else
            {
                btnCloseCash.IconChar = FontAwesome.Sharp.IconChar.Lock;
                btnCloseCash.IconColor = Color.DarkRed;
                btnCloseCash.Enabled = false;
            }

            var cashStatus = await _cashRegisterService.GetTodayCashOpeningAsync(
                    cashNumber: int.TryParse(txtCashNumber.Text, out var cashNumber) ? cashNumber : 0);


            if (cashStatus != null)
            {
                txtDate.Text = cashStatus?.OpenDate.ToString("dd/MM/yyyy");
                var movements = await _cashMovementService.GetTodayMovementsAsync(cashStatus.Id);

                var summaryByType = movements
                    .GroupBy(m => m.Type)
                    .Select(g => new
                    {
                        Tipo = EnumHelper.GetEnumDescription(g.Key),
                        Valor = PriceConverter.FromCents(g.Sum(m => m.Amount))
                    }).ToList();

                dgvSummaryByType.DataSource = summaryByType;

                // Preencher o grid de resumo por forma de pagamento
                var summaryByPayment = movements
                    .Where(m => m.PaymentMethodId != null)
                    .GroupBy(m => m.PaymentMethod!.Description)
                    .Select(g => new
                    {
                        FormaPagamento = g.Key,
                        Valor = PriceConverter.FromCents(g.Sum(m => m.Amount))
                    }).ToList();

                dgvSummaryByPayment.DataSource = summaryByPayment;

                // Total no caixa: soma dos valores (Abertura + Entrada + Vendas) - Saídas
                var total = movements
                    .Where(m => m.Type != CashMovementType.Exit)
                    .Sum(m => m.Amount)
                    - movements
                    .Where(m => m.Type == CashMovementType.Exit)
                    .Sum(m => m.Amount);

                txtTotalInCash.Text = PriceConverter.FromCents(total).ToString("N2");
                _totalInClosed = total;

                // Gerar preview do fechamento
                rtbPreview.Text = GenerateClosingPreview(cashStatus, movements, total);
                _movements = movements;
            }
            else
            {
                txtDate.Text = DateTime.UtcNow.Date.ToString("dd/MM/yyyy");
            }
        }
        private string GenerateClosingPreview(CashRegisterDTO cashStatus, List<CashMovementDTO> movements, int total)
        {
            var sb = new StringBuilder();

            sb.AppendLine(ReportTextHelper.CenterLine("=== FECHAMENTO ==="));
            sb.AppendLine(ReportTextHelper.CenterLine("-------------------------------------"));
            sb.AppendLine(ReportTextHelper.CenterLine($"CAIXA: {cashStatus.CashNumber}"));
            sb.AppendLine(ReportTextHelper.CenterLine($"DATA ABERTURA: {cashStatus.OpenDate:dd/MM/yyyy HH:mm}"));
            sb.AppendLine(ReportTextHelper.CenterLine($"OPERADOR: {_userName}"));
            sb.AppendLine(ReportTextHelper.CenterLine("-------------------------------------"));

            var groupedTypes = movements
                .GroupBy(m => m.Type)
                .Select(g => new
                {
                    Type = EnumHelper.GetEnumDescription(g.Key),
                    Total = PriceConverter.FromCents(g.Sum(m => m.Amount))
                });

            foreach (var item in groupedTypes)
                sb.AppendLine(ReportTextHelper.CenterLine($"{item.Type,-20} R$ {item.Total,10:N2}"));

            sb.AppendLine(ReportTextHelper.CenterLine("-------------------------------------"));

            sb.AppendLine(ReportTextHelper.CenterLine($"TOTAL EM CAIXA:     R$ {PriceConverter.FromCents(_totalInClosed):N2}"));
            sb.AppendLine(ReportTextHelper.CenterLine("-------------------------------------"));
            sb.AppendLine(ReportTextHelper.CenterLine($"DATA FECHAMENTO: {DateTime.Now:dd/MM/yyyy HH:mm}"));
            sb.AppendLine(ReportTextHelper.CenterLine("SISTEMA SisPDV"));

            return sb.ToString();
        }

        private void txtTotalInCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustDecimal(txtTotalInCash.Text, e.KeyChar))
                e.Handled = true;
        }

        private async void btnCloseCash_Click(object sender, EventArgs e)
        {
            try
            {
                var request = MapFromDTO();

                var result = await ValidateData(request);
                if(!result)
                    return;

                var closing = await _cashRegisterService.CloseCashRegisterAsync(request);

                MessageBox.Show($"Caixa fechado com sucesso!\nNúmero do Caixa: {closing.CashNumber}", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!CashRegisterStatus.IsOpen)
                {
                    btnCloseCash.IconChar = FontAwesome.Sharp.IconChar.Lock;
                    btnCloseCash.IconColor = Color.DarkRed;
                    btnCloseCash.Enabled = false;
                }
                rtbPreview.Text = GenerateClosingPreview(closing, _movements, PriceConverter.ToCents(closing.amount));
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Erro ao fechar caixa: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private CashMovementDTO MapFromDTO()
        {
            return new CashMovementDTO
            {
                CashRegisterId = CashRegisterStatus.CashRegisterId!.Value,

                Type = CashMovementType.Closing,
                Amount = PriceConverter.ToCents(Decimal.TryParse(txtTotalInCash.Text, out var amount) ? amount : 0),
                Description = $"Fechamento do caixa.",
                Origin = nameof(CashClosingForm)
            };
        }
    }
}
