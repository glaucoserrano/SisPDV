using SisPDV.APP.Helpers;
using SisPDV.Application.DTOs.Company;
using SisPDV.Application.DTOs.Order;
using SisPDV.Application.DTOs.Product;
using SisPDV.Application.Helper;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Helpers;
using SisPDV.Infrastructure.Globals;
using SisPDV.Infrastructure.Service;
using System.Text;
using System.Threading.Tasks;

namespace SisPDV.APP.Order
{
    public partial class OrderForm : Form
    {
        private readonly IProductService _productService;
        private readonly ICurrentUserService _currentUserService;
        private readonly ICompanyService _companyService;
        private readonly IOrderService _orderService;


        private decimal? originalItemTotal = null;
        private ListBox lstSuggestions = new ListBox();
        private CompanyDTO? actualCompany;
        private string currentOrderId;
        private int _currentOrderId = 0;
        private int _productId = 0;

        public OrderForm(
            IProductService productService,
            ICurrentUserService currentUserService,
            ICompanyService companyService,
            IOrderService orderService)
        {
            InitializeComponent();
            _productService = productService;
            _currentUserService = currentUserService;
            _companyService = companyService;
            _orderService = orderService;
        }
        private void OrderForm_Load(object sender, EventArgs e)
        {
            ReportTextHelper.ConfigureReceiptPreview(rtbFiscalMirror);
            InitializeSuggestionBox();
            _ = SetupAutoCompleteAsync();

            btnNewOrder.Focus();
            lblCurrentUser.Text = _currentUserService.CurrentUser ?? "Usuário Desconhecido";
            lblCurrentUser.Text += $" - {DateTime.Now:dd/MM/yyyy HH:mm}";
            lblCurrentUser.Text += $" - Caixa n° {CashNumberHelper.GetPDVNumber()}";
            _ = loadCompanyName();
        }

        private async Task loadCompanyName()
        {
            actualCompany = await _companyService.GetAsync();

            rtbCompanyName.SelectionAlignment = HorizontalAlignment.Center;
            rtbCompanyName.Text = actualCompany!.CompanyName ?? "Nome da Empresa Não Configurado";
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
                txtItemTotal.Text = product.Price?.ToString("F2") ?? "0.00";
                _productId = product.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados do produto: " + ex.Message);
            }
        }
        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            enabledFields(true);
            _ = startNewOrder();

        }

        private async Task startNewOrder()
        {
            try
            {
                var isNfce = SystemConfig.Current.NFCeEnabled;
                var newOrder = new CreateOrderDTO
                {
                    OrderNumber = await OrderNumberHelper.GenerateNextOrderNumberAsync(),
                    IsNFCe = isNfce
                };

                var order = await _orderService.CreateAsync(newOrder);

                if (order == null)
                {
                    MessageBox.Show("Erro ao iniciar novo pedido.");
                    return;
                }
                _currentOrderId = order.Id;
                currentOrderId = order.OrderNumber;
                rtbFiscalMirror.Text = GenerateNewOrder(order);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao iniciar novo pedido: " + ex.Message);
                return;
            }
        }
        private string GenerateNewOrder(CreateOrderDTO newOrder)
        {
            const int lineWidth = 65; // largura em caracteres
            int productWidth = 45;
            int qtyWidth = 5;
            int priceWidth = 15;
            var sb = new StringBuilder();


            sb.AppendLine(ReportTextHelper.CenterLine("=== NOVO PEDIDO ===", lineWidth));
            sb.AppendLine(new string('-', lineWidth));
            sb.AppendLine(ReportTextHelper.CenterLine($"EMPRESA: {actualCompany!.CompanyName}", lineWidth));
            sb.AppendLine(ReportTextHelper.CenterLine($"DATA: {DateTime.Now:dd/MM/yyyy HH:mm}", lineWidth));
            sb.AppendLine(new string('-', lineWidth));
            sb.AppendLine(ReportTextHelper.CenterLine($"N° PEDIDO: {newOrder.OrderNumber}", lineWidth));

            if (newOrder.TableId.HasValue)
                sb.AppendLine(ReportTextHelper.CenterLine($"MESA: {newOrder.TableId.Value}", lineWidth));

            if (newOrder.CustomerId.HasValue)
                sb.AppendLine(ReportTextHelper.CenterLine($"CLIENTE: {newOrder.CustomerId.Value}", lineWidth));

            sb.AppendLine(new string('-', lineWidth));
            sb.AppendLine(ReportTextHelper.CenterLine($"CAIXA: {CashNumberHelper.GetPDVNumber()}", lineWidth));
            sb.AppendLine(ReportTextHelper.CenterLine($"OPERADOR: {_currentUserService.CurrentUser}", lineWidth));
            sb.AppendLine(new string('-', lineWidth));

            // Cabeçalho
            string headerProduct = "Produto".PadRight(productWidth);
            string headerQty = "Qtd".PadLeft(qtyWidth);
            string headerPrice = "Total".PadLeft(priceWidth);

            sb.AppendLine($"{headerProduct}{headerQty}{headerPrice}");
            sb.AppendLine(new string('-', lineWidth)); // linha separadora
            
            return sb.ToString();
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

                        discountValue = Math.Round((percent / 100m) * total, 2);

                        txtItemDiscount.Text = discountValue.ToString("F2"); 
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

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustNumbers(e.KeyChar))
                e.Handled = true;
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustDecimal(txtUnitPrice.Text, e.KeyChar))
                e.Handled = true;
        }

        private void txtItemTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustDecimal(txtItemTotal.Text, e.KeyChar))
                e.Handled = true;
        }

        private void txtItemDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustDiscount(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '%' && txtItemDiscount.Text.Contains("%"))
            {
                e.Handled = true; // Impede mais de um símbolo de porcentagem
            }
        }
        private async void btnAddItem_Click(object sender, EventArgs e)
        {
            var request = MapFormToDTO();

            var results = await validateData(request);

            if (!results)
                return;

            var Items = await _orderService.AddItemsAsync(request);

            rtbFiscalMirror.Text += AddItemInReport(Items);

            lblDiscountTotal.Text = $"Desconto: R$ {PriceConverter.FromCents(Items.DiscountTotal).ToString("F2")}";
            lblSubtotal.Text = $"SubTotal: R$ {PriceConverter.FromCents(Items.subTotal).ToString("F2")}";
            lblTotal.Text = $"Total: R$ {PriceConverter.FromCents(Items.totalAmount).ToString("F2")}";

            cleanDataItem();
        }

        private void cleanDataItem()
        {
            txtProduct.Clear();
            txtQuantity.Clear();
            txtItemDiscount.Clear();
            txtItemTotal.Clear();
            txtUnitPrice.Clear();
            txtNotes.Clear();
            lstSuggestions.Visible = false;
            _productId = 0;
        }

        private string AddItemInReport(AddOrderItemsDTO request)
        {
            var sb = new StringBuilder();

            // Definir larguras fixas para cada coluna
            int productWidth = 45;
            int qtyWidth = 5;
            int priceWidth = 15;

            // Nome do produto alinhado à esquerda
            string product = txtProduct.Text.Length > productWidth
                ? txtProduct.Text.Substring(0, productWidth) // corta se for muito longo
                : txtProduct.Text.PadRight(productWidth);

            // Quantidade alinhada à direita
            string qty = request.Quantity.ToString().PadLeft(qtyWidth);

            // Preço alinhado à direita
            string price = PriceConverter.FromCents(request.Total).ToString("F2").PadLeft(priceWidth);

            // Monta linha
            sb.AppendLine($"{product}{qty}{price}");

            return sb.ToString();

        }

        private async Task<bool> validateData(AddOrderItemsDTO request)
        {
            var validateData = await _orderService.ValidateAsync(request);

            if (!validateData.IsValid)
            {
                MessageBox.Show(string.Join("\n", validateData.Errors), "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private AddOrderItemsDTO MapFormToDTO()
        {
            return new AddOrderItemsDTO
            {
                OrderId = _currentOrderId,
                ProductId = _productId,
                Quantity = int.TryParse(txtQuantity.Text, out var quantity) ? quantity : 0,
                UnitPrice = PriceConverter.ToCents(decimal.TryParse(txtUnitPrice.Text, out var unitPrice) ? unitPrice : 0),
                Discount = PriceConverter.ToCents(decimal.TryParse(txtItemDiscount.Text, out var discount) ? discount : 0),
                Total = PriceConverter.ToCents(decimal.TryParse(txtItemTotal.Text, out var total) ? total : 0),
                Notes = txtNotes.Text.Trim(),
                Origin = "PDV"
            };
        }
    }
}
