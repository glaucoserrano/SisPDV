using SisPDV.APP.Helpers;
using SisPDV.Application.DTOs.Cfop;
using SisPDV.Application.DTOs.Company;
using SisPDV.Application.DTOs.ProductType;
using SisPDV.Application.DTOs.Unities;
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


        private  CompanyDTO? _company;
        public ProductForm(
            IProductTypeService productTypeService, 
            ICfopService cfopService, 
            ICompanyService companyService,
            IUnityService unityService)
        {
            
            InitializeComponent();
            _cfopService = cfopService;
            _productTypeServices = productTypeService;
            _companyService = companyService;
            _unityService = unityService;
        }

        private async void ProductForm_Load(object sender, EventArgs e)
        {
            _company = await _companyService.GetAsync();
            LoadComboProductType();
            LoadComboCfops();
            LoadCombosUnity();
            LoadEnumCombo();
        }

        private async void LoadCombosUnity()
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

        private async void LoadComboCfops()
        {
            await ComboHelper.LoadComboBoxAsync(
                cmbCFOP,
                () => _cfopService.GetCfopAsync(),
                nameof(CfopDTO.Display),
                nameof(CfopDTO.Id),
                defaultDisplay: "Selecione",
                defaultValue: 0);
        }

        private async void LoadComboProductType()
        {
            await ComboHelper.LoadComboBoxAsync(
                cmbProductType,
                () => _productTypeServices.GetProductTypesAsync(),
                nameof(ProductTypeDTO.Type),
                nameof(ProductTypeDTO.Id),
                defaultDisplay: "Selecione",
                defaultValue: 0);
        }
    }
}
