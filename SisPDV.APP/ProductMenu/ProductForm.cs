using SisPDV.APP.Helpers;
using SisPDV.Application.DTOs.Cfop;
using SisPDV.Application.DTOs.Company;
using SisPDV.Application.DTOs.Config.PrintSector;
using SisPDV.Application.DTOs.ProductType;
using SisPDV.Application.DTOs.Unities;
using SisPDV.Application.Helper;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Entities;
using SisPDV.Domain.Enum;

namespace SisPDV.APP.ProductMenu
{
    public partial class ProductForm : Form
    {
        private readonly IProductTypeService _productTypeServices;
        private readonly ICfopService _cfopService;
        private readonly ICompanyService _companyService;
        private readonly IUnityService _unityService;
        private readonly IConfigService _configServices;


        private CompanyDTO? _company;
        public ProductForm(
            IProductTypeService productTypeService,
            ICfopService cfopService,
            ICompanyService companyService,
            IUnityService unityService,
            IConfigService configServices)
        {

            InitializeComponent();
            _cfopService = cfopService;
            _productTypeServices = productTypeService;
            _companyService = companyService;
            _unityService = unityService;
            _configServices = configServices;
        }

        private async void ProductForm_Load(object sender, EventArgs e)
        {
            _company = await _companyService.GetAsync();
            await LoadComboProductType();
            await LoadComboCfops();
            await LoadCombosUnity();
            LoadEnumCombo();
            gbStock.Enabled = SystemConfig.UseStockControl;
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
                LoadEnumToComboHelper.LoadEnumToComboBox<CSOSN>(cmbCSTCSOSN);
            }
            else
            {
                LoadEnumToComboHelper.LoadEnumToComboBox<CST_ICMS>(cmbCSTCSOSN);
            }
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
    }
}
