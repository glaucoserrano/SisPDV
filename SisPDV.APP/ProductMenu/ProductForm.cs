using SisPDV.APP.Helpers;
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
        private bool _updatingPrice = false;
        private bool _updatingMargin = false;

        private CompanyDTO? _company;
        public ProductForm(
            IProductTypeService productTypeService,
            ICfopService cfopService,
            ICompanyService companyService,
            IUnityService unityService,
            IConfigService configServices,
            IProductService productService)
        {

            InitializeComponent();
            _cfopService = cfopService;
            _productTypeServices = productTypeService;
            _companyService = companyService;
            _unityService = unityService;
            _configServices = configServices;
            _productService = productService;
        }

        private async void ProductForm_Load(object sender, EventArgs e)
        {
            _company = await _companyService.GetAsync();
            await LoadComboProductType();
            await LoadComboCfops();
            await LoadCombosUnity();
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
                LoadEnumToComboHelper.LoadEnumToComboBox<CSOSN>(cmbCSTCSOSN,addDefaultItem: true,
                    defaultText:"00 - Selecione",defaultValue: 0);
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
                () => _cfopService.GetCfopAsync(),
                nameof(CfopDTO.Display),
                nameof(CfopDTO.Id),
                defaultDisplay: "Selecione",
                defaultValue: 0);

            await ComboHelper.LoadComboBoxAsync(
                cmbSearchCFOP,
                () => _cfopService.GetCfopAsync(),
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
                txtProductId.Enabled = false;
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
                Type = cmbProductType.SelectedItem?.ToString() ?? "",
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
                SectorPrinterId = (int?)(cmbPrintSector.SelectedValue ?? null),
                //ImagePath = txtImagePath.Text.Trim()
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
    }
}
