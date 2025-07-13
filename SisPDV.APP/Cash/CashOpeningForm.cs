using SisPDV.APP.Helpers;
using SisPDV.Domain.Helpers;
using SisPDV.Infrastructure.Globals;

namespace SisPDV.APP.Cash
{
    public partial class CashOpeningForm : Form
    {
        public CashOpeningForm()
        {
            InitializeComponent();
        }

        private void CashOpeningForm_Load(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.UtcNow.Date.ToString("dd/MM/yyyy");
            txtCashNumber.Text = CashNumberHelper.GetPDVNumber();
            lblStatus.Text = CashRegisterStatus.StatusMessage;

            if (CashRegisterStatus.IsOpen)
            {
                btnOpenCash.IconChar = FontAwesome.Sharp.IconChar.Unlock;
            }
        }

        private void txtOpeningValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustDecimal(txtOpeningValue.Text, e.KeyChar))
                e.Handled = true;
        }
    }
}
