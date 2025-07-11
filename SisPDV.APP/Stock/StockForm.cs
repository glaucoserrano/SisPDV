using SisPDV.APP.Helpers;
using SisPDV.Application.DTOs.Stock;
using SisPDV.Application.Helper;
using SisPDV.Application.Interfaces;

namespace SisPDV.APP.Stock
{
    public partial class StockForm : Form
    {
        private readonly IProductService _productService;
        private readonly IProductStockService _productStockService;


        private int _productStockId;
        private int _currentStockId;
        private ListBox lstSuggestions = new ListBox();

        public StockForm(IProductService productService, IProductStockService productStockService)
        {
            InitializeComponent();
            _productService = productService;
            _productStockService = productStockService;
        }

        private void StockForm_Load(object sender, EventArgs e)
        {
            _productStockId = 0;
            loadGridStock();
            InitializeSuggestionBox();
            _ = SetupAutoCompleteAsync();
            _ = LoadProductStockAsync();
        }

        private async Task SetupAutoCompleteAsync()
        {
            await ProductAutoCompleteHelper.SetupAsync(
                txtProductSearch,
                lstSuggestions,
                async () =>
                {
                    var products = await _productService.GetProductsForStockAsync();

                    return products.Select(p => new ProductAutoCompleteItem
                    {
                        Id = p.Id,
                        Display = $"{p.Description}",
                        Code = p.Code.ToString(),
                        Barcode = p.Barcode ?? "",
                        SupplierCode = p.SupplierCode ?? ""
                    }).ToList();
                },
                async productId => await LoadProductStockByProductId(productId)
            );
        }

        private async Task LoadProductStockByProductId(int productId)
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

                // 2. Buscar estoque
                var stock = await _productStockService.GetByProductIdAsync(productId);

                if (stock != null)
                {
                    txtMinStock.Text = stock.minQuantity.ToString();
                    txtMaxStock.Text = stock.maxQuantity.ToString();
                    txtLocation.Text = stock.Location;
                }
                else
                {
                    // Produto ainda não tem estoque cadastrado
                    txtMinStock.Text = "0";
                    txtMaxStock.Text = "0";
                    txtLocation.Text = "";
                }

                //3.Salvar o ID do estoque(para edição)
                _currentStockId = stock?.Id ?? 0;
                _productStockId = product.Id;
                txtMinStock.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados do produto: " + ex.Message);
            }
        }
        private void loadGridStock()
        {
            dgvStock.ReadOnly = true;
            dgvStock.AutoGenerateColumns = false;
            dgvStock.AllowUserToAddRows = false;
            dgvStock.AllowUserToDeleteRows = false;
            dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStock.MultiSelect = false;
            dgvStock.RowHeadersVisible = false;
            dgvStock.Columns.Clear();

            dgvStock.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProductStockId",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Visible = false
            });

            dgvStock.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProductId",
                HeaderText = "ID",
                DataPropertyName = "ProductId",
                Visible = false
            });

            dgvStock.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDescription",
                HeaderText = "Produto",
                DataPropertyName = "ProductDescription",
                Width = 300
            });

            dgvStock.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMinQty",
                HeaderText = "Estoque Mínimo",
                DataPropertyName = "MinQuantity",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvStock.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaxQty",
                HeaderText = "Estoque Máximo",
                DataPropertyName = "MaxQuantity",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvStock.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLocation",
                HeaderText = "Localização",
                DataPropertyName = "Location",
                Width = 200
            });
        }
        private void InitializeSuggestionBox()
        {
            lstSuggestions = new ListBox
            {
                Visible = false,
                Width = txtProductSearch.Width,
                Height = 100
            };

            lstSuggestions.Click += async (s, e) =>
            {
                if (lstSuggestions.SelectedItem is ProductAutoCompleteItem selected)
                {
                    txtProductSearch.Text = selected.Display;
                    lstSuggestions.Visible = false;
                    txtMinStock.Focus();
                    await LoadProductStockByProductId(selected.Id);
                }
            };

            this.Controls.Add(lstSuggestions);
            lstSuggestions.BringToFront();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var request = MapFormToDTO();
            var result = await validateData(request);

            if (!result)
                return;

            await _productStockService.SaveAsync(request);

            if (_currentStockId == 0)
            {
                MessageBox.Show("Cadastro salvo com sucesso", "Sis_PDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cadastro alterado com sucesso", "Sis_PDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            cleanData();
            await LoadProductStockAsync();
        }

        private async Task LoadProductStockAsync()
        {
            var productStockList = await _productStockService.GetProductStockAsync();
            dgvStock.DataSource = productStockList;
        }

        private void cleanData()
        {
            txtProductSearch.Clear();
            txtMinStock.Clear();
            txtMaxStock.Clear();
            txtLocation.Clear();
            _currentStockId = 0;
            _productStockId = 0;
            lstSuggestions.Visible = false;
        }

        private async Task<bool> validateData(ProductStockDTO request)
        {
            var validate = await _productStockService.ValidateAsync(request);

            if (!validate.IsValid)
            {
                MessageBox.Show(string.Join("\n", validate.Errors), "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private ProductStockDTO MapFormToDTO()
        {
            return new ProductStockDTO
            {
                Id = _currentStockId,
                ProductId = _productStockId,
                maxQuantity = TryParseHelper.SafeParseDecimal(txtMaxStock.Text, "MaxStock"),
                minQuantity = TryParseHelper.SafeParseDecimal(txtMinStock.Text, "MinStock"),
                Location = txtLocation.Text
            };
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            cleanData();
        }

        private async void dgvStock_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var id = (int)dgvStock.Rows[e.RowIndex].Cells["colProductStockId"].Value;
                var productId = (int)dgvStock.Rows[e.RowIndex].Cells["colProductId"].Value;

                var productStock = await _productStockService.GetByProductIdAsync(productId);

                if (productStock != null)
                {
                    txtProductSearch.Text = productStock.ProductDescription;
                    txtMinStock.Text = productStock.minQuantity.ToString();
                    txtMaxStock.Text = productStock.maxQuantity.ToString();
                    txtLocation.Text = productStock.Location;

                    _currentStockId = id;
                    _productStockId = productId;
                    lstSuggestions.Visible = false;
                }
            }
        }
        private async Task LoadFilteredStockGridAsync(string searchTerm)
        {
            var list = await _productStockService.SearchAsync(searchTerm);
            dgvStock.DataSource = list;
        }

        private async void txtProductSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtProductSearch.Text.Trim();
            await LoadFilteredStockGridAsync(searchTerm);
        }
    }
}
