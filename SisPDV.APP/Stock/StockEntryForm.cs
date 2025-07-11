using SisPDV.APP.Helpers;
using SisPDV.Application.DTOs.Stock;
using SisPDV.Application.Interfaces;
using SisPDV.Application.Services;
using SisPDV.Domain.Enum;
using System.Threading.Tasks;


namespace SisPDV.APP.Stock
{
    public partial class StockEntryForm : Form
    {
        private readonly IProductService _productService;
        private readonly IStockMovementService _stockMovementService;
        private readonly IProductStockService _productStockService;
        private ListBox lstSuggestions = new ListBox();

        private int _productId;
        private int _currentStockMovementId;
        public StockEntryForm(IProductService productService, 
            IStockMovementService stockMovementService,
            IProductStockService productStockService)
        {
            InitializeComponent();
            _productService = productService;
            _stockMovementService = stockMovementService;
            _productStockService = productStockService;
        }

        private void StockEntryForm_Load(object sender, EventArgs e)
        {
            _productId = 0;
            _currentStockMovementId = 0;
            txtProductSearch.Focus();
            lblCurrentStock.Text = "Estoque Atual: 0";
            LoadComboBox();
            LoadStockMovementGrid();
            InitializeSuggestionBox();
            _ = SetupAutoCompleteAsync();
        }

        private void InitializeSuggestionBox()
        {
            lstSuggestions = new ListBox
            {
                Visible = false,
                Width = txtProductSearch.Width,
                Height = 100
            };

            lstSuggestions.Click += (s, e) =>
            {
                if (lstSuggestions.SelectedItem is ProductAutoCompleteItem selected)
                {
                    txtProductSearch.Text = selected.Display;
                    lstSuggestions.Visible = false;
                    txtQuantity.Focus();
                }
            };
            this.Controls.Add(lstSuggestions);
            lstSuggestions.BringToFront();
        }

        private void LoadStockMovementGrid()
        {
            dgvMovements.ReadOnly = true;
            dgvMovements.AutoGenerateColumns = false;
            dgvMovements.AllowUserToAddRows = false;
            dgvMovements.AllowUserToDeleteRows = false;
            dgvMovements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovements.MultiSelect = false;
            dgvMovements.RowHeadersVisible = false;
            dgvMovements.Columns.Clear();
            dgvMovements.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                DataPropertyName = "Id",
                HeaderText = "ID",
                Visible = false
            });

            dgvMovements.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProduct",
                DataPropertyName = "ProductDescription",
                HeaderText = "Produto"
            });

            dgvMovements.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colType",
                DataPropertyName = "TypeDescription",
                HeaderText = "Tipo"
            });

            dgvMovements.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colQuantity",
                DataPropertyName = "Quantity",
                HeaderText = "Quantidade",
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvMovements.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDate",
                DataPropertyName = "Date",
                HeaderText = "Data",
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvMovements.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDocument",
                DataPropertyName = "DocumentNumber",
                HeaderText = "Documento",
                Visible = false
            });
        }

        private void LoadComboBox()
        {
            LoadEnumToComboHelper.LoadEnumToComboBox<StockMovementType>(cmbMovementType);
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
                async productId => await LoadStockMovementByProductId(productId)
            );
        }

        private async Task LoadStockMovementByProductId(int productId)
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
                _productId = product.Id;
                txtQuantity.Focus();

                var quantity = await _productStockService.GetByProductIdAsync(productId);

                lblCurrentStock.Text = $"Estoque Atual: {quantity.Quantity}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados do produto: " + ex.Message);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var request = MapFormToDTO();

            var result = await ValidateData(request);

            if (!result)
                return;

            await _stockMovementService.SaveAsync(request);

            if (_currentStockMovementId == 0)
            {
                MessageBox.Show("Cadastro salvo com sucesso", "Sis_PDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            cleanData();

        }

        private void cleanData()
        {
            txtProductSearch.Clear();
            _productId = 0;
            _currentStockMovementId = 0;

            txtQuantity.Text = "0";
            cmbMovementType.SelectedIndex = 0;

            txtNotes.Clear();
            lstSuggestions.Visible = false;

            lblCurrentStock.Text = "Estoque Atual: 0";
            txtProductSearch.Focus();

            dtpDate.Text = DateTime.UtcNow.ToString();
        }

        private async Task<bool> ValidateData(StockMovementDTO request)
        {
            var validate = await _stockMovementService.ValidateAsync(request);

            if (!validate.IsValid)
            {
                MessageBox.Show(string.Join("\n", validate.Errors), "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private StockMovementDTO MapFormToDTO()
        {
            return new StockMovementDTO
            {
                ProductId = _productId,
                Quantity = int.TryParse(txtQuantity.Text, out var quantity) ? quantity : 0,
                Type = (StockMovementType)cmbMovementType.SelectedValue!,
                Notes = txtNotes.Text.Trim(),
                Origin = "StockMovementForm",
                Date = DateTime.TryParse(dtpDate.Text, out var date)
                        ? DateTime.SpecifyKind(date, DateTimeKind.Utc)
                        : DateTime.UtcNow
            };
        }
        private async Task LoadFilteredStockGridAsync(string searchTerm)
        {
            var list = await _stockMovementService.SearchAsync(searchTerm);
            dgvMovements.DataSource = list;
        }
        private async void txtProductSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtProductSearch.Text.Trim();
            if (string.IsNullOrEmpty(txtProductSearch.Text))
            {
                dgvMovements.DataSource = null;
                return;
            }
            await LoadFilteredStockGridAsync(searchTerm);

        }
    }
}
