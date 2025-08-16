using SisPDV.APP.Helpers;
using SisPDV.Application.Interfaces;

namespace SisPDV.APP.Order
{
    public partial class OrderForm : Form
    {
        private readonly IProductService _productService;

        private decimal? originalItemTotal = null;
        private ListBox lstSuggestions = new ListBox();
        public OrderForm(IProductService productService)
        {
            InitializeComponent();
            _productService = productService;
        }
        private void OrderForm_Load(object sender, EventArgs e)
        {
            InitializeSuggestionBox();
            _ = SetupAutoCompleteAsync();

            btnNewOrder.Focus();
        }
        private async Task SetupAutoCompleteAsync()
        {
            await ProductAutoCompleteHelper.SetupAsync(
                txtProduct,
                lstSuggestions,
                async () =>
                {
                    var products = await _productService.GetProductsForOrderAsync();

                    return products.Select(p => new ProductAutoCompleteItem
                    {
                        Id = p.Id,
                        Display = $"{p.Description}",
                        Code = p.Code.ToString(),
                        Barcode = p.Barcode ?? "",
                        SupplierCode = p.SupplierCode ?? ""
                    }).ToList();
                },
                async productId => await LoadProductByProductId(productId)
            );
        }
        private void InitializeSuggestionBox()
        {
            lstSuggestions = new ListBox
            {
                Visible = false,
                Width = txtProduct.Width,
                Height = 100
            };

            lstSuggestions.Click += async (s, e) =>
            {
                if (lstSuggestions.SelectedItem is ProductAutoCompleteItem selected)
                {
                    txtProduct.Text = selected.Display;
                    lstSuggestions.Visible = false;
                    txtProduct.Focus();
                    await LoadProductByProductId(selected.Id);
                }
            };

            this.Controls.Add(lstSuggestions);
            lstSuggestions.BringToFront();
        }
        private async Task LoadProductByProductId(int productId)
        {
            try
            {
                //1.Buscar dados do produto
                var product = await _productService.GetByIdAsync(productId);
                if (product == null)
                {
                    MessageBox.Show("Produto não encontrado.");
                    return;
                }
                txtUnitPrice.Text = product.Price?.ToString("F2") ?? "0.00";
                txtQuantity.Text = "1"; // Definindo quantidade padrão como 1
                txtItemDiscount.Text = "0,00";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados do produto: " + ex.Message);
            }
        }
        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            enabledFields(true);
            
        }
        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            enabledFields(false);
            btnNewOrder.Focus();
        }

        private void enabledFields(bool enable)
        {
            grbProducts.Enabled = enable;
            btnSwap.Enabled = enable;
            btnCancelProduct.Enabled = enable;
            btnCloseOrder.Enabled = enable;
            btnNewOrder.Enabled = !enable;
            btnNewOrder.Visible = !enable;
            btnCancelOrder.Visible = enable;
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            if (txtUnitPrice.Text == "0.00" || string.IsNullOrEmpty(txtUnitPrice.Text))
            {
                return;
            }
            if (decimal.TryParse(txtQuantity.Text, out decimal quantity) &&
                decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice))
            {
                decimal total = quantity * unitPrice;
                txtItemTotal.Text = total.ToString("F2");
            }
            else
            {
                MessageBox.Show("Quantidade ou preço inválidos.");
                txtItemTotal.Text = "0,00";
            }
        }

        private void txtUnitPrice_Leave(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "0" || string.IsNullOrEmpty(txtQuantity.Text))
            {
                return;
            }
            if (decimal.TryParse(txtQuantity.Text, out decimal quantity) &&
                decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice))
            {
                decimal total = quantity * unitPrice;
                txtItemTotal.Text = total.ToString("F2");
            }
            else
            {
                MessageBox.Show("Quantidade ou preço inválidos.");
                txtItemTotal.Text = "0,00";
            }
        }

        private void txtItemDiscount_Leave(object sender, EventArgs e)
        {
            string input = txtItemDiscount.Text.Trim();


            // Se ainda não guardamos o valor original, salva o primeiro valor exibido
            if (originalItemTotal == null && decimal.TryParse(txtItemTotal.Text, out decimal currentTotal))
            {
                originalItemTotal = currentTotal;
            }

            // Sempre volta para o valor original antes de aplicar o novo desconto
            decimal total = originalItemTotal ?? 0;

            if (total <= 0)
            {
                MessageBox.Show("Total inválido.");
                txtItemDiscount.Text = "0,00";
                return;
            }

            decimal discountValue = 0;

            try
            {
                if (input.EndsWith("%"))
                {
                    string percentStr = input.Replace("%", "").Trim();

                    if (decimal.TryParse(percentStr, out decimal percent))
                    {
                        discountValue = (percent / 100m) * total;
                    }
                    else
                    {
                        throw new Exception("Percentual inválido.");
                    }
                }
                else
                {
                    if (decimal.TryParse(input, out decimal fixedValue))
                    {
                        discountValue = Math.Round(fixedValue, 2);
                    }
                    else
                    {
                        throw new Exception("Valor de desconto inválido.");
                    }
                }

                if (discountValue < 0 || discountValue > total)
                {
                    MessageBox.Show("Desconto inválido.");
                    txtItemDiscount.Text = "0,00";
                    return;
                }

                decimal finalTotal = total - discountValue;
                txtItemTotal.Text = finalTotal.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtItemDiscount.Text = "0,00";
                txtItemTotal.Text = total.ToString("F2");
            }
        }
    }
}
