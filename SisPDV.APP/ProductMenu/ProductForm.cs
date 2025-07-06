using SisPDV.APP.Helpers;
using SisPDV.Application.DTOs.Category;
using SisPDV.Application.DTOs.Cfop;
using SisPDV.Application.DTOs.Company;
using SisPDV.Application.DTOs.Config.PrintSector;
using SisPDV.Application.DTOs.Person;
using SisPDV.Application.DTOs.Product;
using SisPDV.Application.DTOs.ProductType;
using SisPDV.Application.DTOs.Unities;
using SisPDV.Application.Helper;
using SisPDV.Application.Interfaces;
using SisPDV.Application.Services;
using SisPDV.Domain.Entities;
using SisPDV.Domain.Enum;
using SisPDV.Domain.Helpers;
using System.Threading.Tasks;

namespace SisPDV.APP.ProductMenu
{
    public partial class ProductForm : Form
    {
        private readonly IProductTypeService _productTypeServices;
        private readonly ICfopService _cfopService;
        private readonly ICompanyService _companyService;
        private readonly IUnityService _unityService;
        private readonly IConfigService _configServices;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        private bool _updatingPrice = false;
        private bool _updatingMargin = false;

        private CompanyDTO? _company;
        private string _imagePath = string.Empty;
        private int _productId = 0;
        private bool _isEditing = false;
        public ProductForm(
            IProductTypeService productTypeService,
            ICfopService cfopService,
            ICompanyService companyService,
            IUnityService unityService,
            IConfigService configServices,
            IProductService productService,
            ICategoryService categoryService)
        {

            InitializeComponent();
            _cfopService = cfopService;
            _productTypeServices = productTypeService;
            _companyService = companyService;
            _unityService = unityService;
            _configServices = configServices;
            _productService = productService;
            _categoryService = categoryService;
        }

        private async void ProductForm_Load(object sender, EventArgs e)
        {
            _company = await _companyService.GetAsync();
            await LoadComboProductType();
            await LoadComboCfops();
            await LoadCombosUnity();
            await LoadComboCategory();
            LoadEnumCombo();
            gbStock.Enabled = SystemConfig.UseStockControl;
            chkStockControlled.Checked = SystemConfig.UseStockControl;
            chkAllowZeroStockSale.Checked = SystemConfig.SalesZeroStock;
            gbPrinters.Enabled = SystemConfig.UsePrintSector;
            if (SystemConfig.UsePrintSector)
            {
                await LoadComboPrinterSector();
            }
            EnabledPrintFields(false);
            ConfigProductGrid();
            _productId = 0;
        }

        private async Task LoadComboCategory()
        {
            var categories = await _categoryService.GetCategoriesActiveAsync();

            if(categories.Count == 0 || categories == null)
            {
                cmbCategory.Enabled = false;
            }
            else
            {
                await ComboHelper.LoadComboBoxAsync(
                cmbCategory,
                () => _categoryService.GetCategoriesActiveAsync(),
                nameof(CategoryDTO.Description),
                nameof(CategoryDTO.Id),
                defaultDisplay: "Selecione",
                defaultValue: 0);
            }
        }

        private void ConfigProductGrid()
        {
            dgvProducts.ReadOnly = true;
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.Columns.Clear();

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "Código",
                DataPropertyName = "Id",
                Width = 80,
                Visible = false
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDescription",
                HeaderText = "Descrição",
                DataPropertyName = "Description",
                Width = 350
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colType",
                HeaderText = "Tipo",
                DataPropertyName = "ProductType",
                Width = 220
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colUnity",
                HeaderText = "Unidade",
                DataPropertyName = "Unity",
                Width = 100,
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrice",
                HeaderText = "Preço",
                DataPropertyName = "Price",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "C2", // Mostra como moeda com 2 casas decimais, ex: R$ 12,50
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCFOP",
                HeaderText = "Cfop",
                DataPropertyName = "Cfop",
                Width = 108,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
        }

        private void EnabledPrintFields(bool enabled)
        {
            cmbPrintSector.Enabled = enabled;
            chkAutoPrint.Enabled = enabled;
            chkShowInOrder.Enabled = enabled;
        }

        private async Task LoadComboPrinterSector()
        {
            await ComboHelper.LoadComboBoxAsync(
                cmbPrintSector,
                () => _configServices.GetPrinterSectorAsync(),
                nameof(PrintSectorsDTO.SectorName),
                nameof(PrintSectorsDTO.Id),
                defaultDisplay: "Selecione",
                defaultValue: 0);
        }

        private async Task LoadCombosUnity()
        {
            await ComboHelper.LoadComboBoxAsync(
                cmbUnity,
                () => _unityService.GetUnityAsync(),
                nameof(UnityDTO.Description),
                nameof(UnityDTO.Id),
                defaultDisplay: "Selecione",
                defaultValue: 0);
        }

        private void LoadEnumCombo()
        {
            if (_company!.TaxRegime == TaxRegime.SimplesNacional)
            {
                LoadEnumToComboHelper.LoadEnumToComboBox<CSOSN>(cmbCSTCSOSN, addDefaultItem: true,
                    defaultText: "00 - Selecione", defaultValue: 0);
            }
            else
            {
                LoadEnumToComboHelper.LoadEnumToComboBox<CST_ICMS>(cmbCSTCSOSN, addDefaultItem: true,
                    defaultText: "00 - Selecione", defaultValue: 0);
            }

            LoadEnumToComboHelper.LoadEnumToComboBox<Status>(cmbSearchStatus, addDefaultItem: true,
                    defaultText: "Todos", defaultValue: -1);
        }

        private async Task LoadComboCfops()
        {
            await ComboHelper.LoadComboBoxAsync(
                cmbCFOP,
                () => _cfopService.GetCfopsActiveAsync(),
                nameof(CfopDTO.Display),
                nameof(CfopDTO.Id),
                defaultDisplay: "Selecione",
                defaultValue: 0);

            await ComboHelper.LoadComboBoxAsync(
                cmbSearchCFOP,
                () => _cfopService.GetCfopsActiveAsync(),
                nameof(CfopDTO.Display),
                nameof(CfopDTO.Id),
                defaultDisplay: "Selecione",
                defaultValue: 0);
        }

        private async Task LoadComboProductType()
        {
            await ComboHelper.LoadComboBoxAsync(
                cmbProductType,
                () => _productTypeServices.GetProductTypesAsync(),
                nameof(ProductTypeDTO.Type),
                nameof(ProductTypeDTO.Id),
                defaultDisplay: "Selecione",
                defaultValue: 0);

            await ComboHelper.LoadComboBoxAsync(
                cmbSearchProductType,
                () => _productTypeServices.GetProductTypesAsync(),
                nameof(ProductTypeDTO.Type),
                nameof(ProductTypeDTO.Id),
                defaultDisplay: "Selecione",
                defaultValue: 0);
        }

        private void cmbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductType.SelectedItem is ProductTypeDTO selectedType)
            {
                LoadDefaultValuesFromProductType(selectedType);
            }
        }
        private void LoadDefaultValuesFromProductType(ProductTypeDTO selectedType)
        {
            cmbCFOP.SelectedValue = selectedType.CfopId;
            txtNCM.Text = selectedType.NCM;
            if (_company!.TaxRegime == TaxRegime.SimplesNacional)
            {
                cmbCSTCSOSN.SelectedValue = selectedType.CST_CSOSN.HasValue ? (int)selectedType.CST_CSOSN.Value : 0;
            }
            else
            {
                cmbCSTCSOSN.SelectedValue = selectedType.CST_ICMS.HasValue ? (int)selectedType.CST_ICMS.Value : 0;
            }
            if (selectedType.Id != 0)
            {
                txtProductId.Enabled = false;
                _isEditing = true;
            }
            else
            {
                txtProductId.Enabled = true;
                _isEditing = false;
            }

        }

        private void chkPrintersSector_CheckedChanged(object sender, EventArgs e)
        {
            EnabledPrintFields(chkPrintersSector.Checked);
        }

        private void txtProductId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustNumbers(e.KeyChar))
                e.Handled = true;
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustNumbers(e.KeyChar))
                e.Handled = true;
        }

        private void txtCostPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustDecimal(txtCostPrice.Text, e.KeyChar))
                e.Handled = true;
        }

        private void txtSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustDecimal(txtSalePrice.Text, e.KeyChar))
                e.Handled = true;
        }

        private void txtNCM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustNumbers(e.KeyChar))
                e.Handled = true;
        }
        private void txtCEST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustNumbers(e.KeyChar))
                e.Handled = true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var request = MapFormToDTO();

            var results = await validateData(request);

            if (!results)
                return;

            await _productService.SaveAsync(request);

            if (_productId == 0)
            {
                MessageBox.Show("Cadastro salvo com sucesso", "Sis_PDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cadastro alterado com sucesso", "Sis_PDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            CleanData();
        }

        private async Task<bool> validateData(ProductDTO request)
        {
            var validateData = await _productService.ValidateAsync(request);

            if (!validateData.IsValid)
            {
                MessageBox.Show(string.Join("\n", validateData.Errors), "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private ProductDTO MapFormToDTO()
        {
            return new ProductDTO
            {
                Id = int.TryParse(txtProductId.Text, out var id) ? id : 0,
                Description = txtDescription.Text.Trim(),
                Barcode = txtBarCode.Text.Trim(),
                ProductTypeId = (int)(cmbProductType.SelectedValue ?? 0),
                RefSupplier = txtRefSupplier.Text.Trim(),
                Active = chkAticve.Checked,

                NCM = txtNCM.Text.Trim(),
                CEST = txtCEST.Text.Trim(),
                CfopId = (int)(cmbCFOP.SelectedValue ?? 0),
                UnityId = (int)(cmbUnity.SelectedValue ?? 0),
                CategoryId = (int?)(cmbCategory.SelectedValue ?? null),

                Weighing = chkWeighing.Checked,
                Fractional = chkFractional.Checked,
                Service = chkService.Checked,
                Notes = txtNotes.Text.Trim(),

                // Conversão para decimal (antes de virar int no helper)
                CostPrice = TryParseHelper.SafeParseDecimal(txtCostPrice.Text, "Preço de Custo"),

                Price = TryParseHelper.SafeParseDecimal(txtSalePrice.Text, "Preço de Venda"),
                ProfitMargin = TryParseHelper.SafeParseDecimal(txtProfitMargin.Text, "Margem de Lucro"),

                UseStockControl = chkStockControlled.Checked,
                AllowZeroStockSale = chkAllowZeroStockSale.Checked,


                PrintInSector = chkPrintersSector.Checked,
                SectorPrinterId = chkPrintersSector.Checked &&
                  cmbPrintSector.SelectedValue is int sectorId &&
                  sectorId > 0
                    ? sectorId
                    : null,

                ImagePath = _imagePath
            };
        }

        private void txtProfitMargin_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSalePrice.Text))
                _updatingPrice = false;

            if (_updatingPrice) return;

            if (decimal.TryParse(txtCostPrice.Text, out var cost) &&
                decimal.TryParse(txtProfitMargin.Text, out var profit))
            {
                _updatingMargin = true;
                var price = cost + (cost * (profit / 100));
                txtSalePrice.Text = price.ToString("N2");
                _updatingPrice = false;
            }
        }

        private void txtSalePrice_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProfitMargin.Text))
                _updatingMargin = false;

            if (_updatingMargin) return;

            if (decimal.TryParse(txtCostPrice.Text, out var cost) &&
                decimal.TryParse(txtSalePrice.Text, out var sale) && cost > 0)
            {
                _updatingPrice = true;
                var margin = ((sale - cost) / cost) * 100;
                txtProfitMargin.Text = margin.ToString("N2");
                _updatingMargin = false;
            }
        }
        private void btnAddImage_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new()
            {
                Filter = "Imagens (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _imagePath = FileUploadHelper.UploadImage(sourcePath: openFileDialog.FileName, destinationFolder: @"\images\products");
                pbProductImage.Image = Image.FromFile(_imagePath);
            }
        }
        private void CleanData()
        {
            txtProductId.Text = "";
            txtProductId.Enabled = true;
            _productId = 0;
            txtDescription.Clear();
            cmbProductType.SelectedIndex = 0;
            txtNCM.Clear();
            txtCEST.Clear();
            cmbCFOP.SelectedIndex = 0;
            cmbUnity.SelectedIndex = 0;
            txtBarCode.Text = "";
            txtRefSupplier.Text = "";
            chkAticve.Checked = true;
            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;
            else
                cmbCategory.SelectedItem = null;

            chkWeighing.Checked = false;
            chkFractional.Checked = false;
            chkService.Checked = false;

            txtCostPrice.Text = "0,00";
            txtSalePrice.Text = "0,00";
            txtProfitMargin.Text = "0,00";

            chkStockControlled.Checked = false;
            chkAllowZeroStockSale.Checked = false;

            chkPrintersSector.Checked = false;
            cmbPrintSector.SelectedIndex = 0;

            txtNotes.Clear();

            // Resetar imagem
            pbProductImage.Image = null;
            _imagePath = string.Empty;

            // Se desejar, também pode desmarcar campos extras, focar no primeiro campo, etc.
            txtDescription.Focus();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            CleanData();
        }
        private async Task LoadProductAsync(string searchTerm)
        {
            var product = await _productService.GetBySearchTermAsync(searchTerm);
            if (product == null)
            {
                MessageBox.Show("Produto não encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CleanData();
                return;
            }

            // Preencher campos (igual fizemos antes)
            txtProductId.Text = product.Id.ToString();
            _productId = product.Id;
            txtDescription.Text = product.Description;
            txtBarCode.Text = product.Barcode;
            txtRefSupplier.Text = product.RefSupplier;
            txtNCM.Text = product.NCM;
            txtCEST.Text = product.CEST;
            txtNotes.Text = product.Notes;
            chkAticve.Checked = product.Active;

            cmbProductType.SelectedValue = product.ProductTypeId;
            cmbCFOP.SelectedValue = product.CfopId;
            cmbUnity.SelectedValue = product.UnityId;
            cmbCategory.SelectedValue = product.CategoryId ?? -1;

            txtCostPrice.Text = product.CostPrice?.ToString("N2");
            txtSalePrice.Text = product.Price?.ToString("N2");
            txtProfitMargin.Text = product.ProfitMargin?.ToString("N2");

            chkStockControlled.Checked = product.UseStockControl;
            chkAllowZeroStockSale.Checked = product.AllowZeroStockSale;
            chkWeighing.Checked = product.Weighing;
            chkFractional.Checked = product.Fractional;
            chkService.Checked = product.Service;

            chkPrintersSector.Checked = product.PrintInSector;
            cmbPrintSector.SelectedValue = product.SectorPrinterId ?? -1;

            // Imagem
            if (!string.IsNullOrEmpty(product.ImagePath))
            {
                var fullImagePath = product.ImagePath;
                pbProductImage.Image = File.Exists(fullImagePath) ? Image.FromFile(fullImagePath) : null;
                _imagePath = fullImagePath;
            }
            else
            {
                pbProductImage.Image = null;
                _imagePath = string.Empty;
            }
        }

        private async void txtProductId_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtProductId.Text))
                await LoadProductAsync(txtProductId.Text.Trim());
        }

        private async void txtBarCode_Leave(object sender, EventArgs e)
        {
            if (_isEditing) return;
            if (!string.IsNullOrWhiteSpace(txtBarCode.Text))
                await LoadProductAsync(txtBarCode.Text.Trim());
        }

        private async void txtRefSupplier_Leave(object sender, EventArgs e)
        {
            if (_isEditing) return;
            if (!string.IsNullOrWhiteSpace(txtRefSupplier.Text))
                await LoadProductAsync(txtRefSupplier.Text.Trim());
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var filter = new SearchFilterProductsDTO
            {
                Description = txtSearchProductDescription.Text.Trim(),
                ProductTypeId = cmbSearchProductType.SelectedValue is int typeId && typeId > 0 ? typeId : null,
                CfopId = cmbSearchCFOP.SelectedValue is int cfopId && cfopId > 0 ? cfopId : null,
                Status = (int?)cmbSearchStatus.SelectedValue
            };

            var list = await _productService.SearchAsync(filter);

            dgvProducts.DataSource = list;
        }

        private async void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                await LoadProductAsync(dgvProducts.Rows[e.RowIndex].Cells["colId"].Value.ToString()!);
                tabControl.SelectedTab = tabRegister;
            }
        }
    }
}
