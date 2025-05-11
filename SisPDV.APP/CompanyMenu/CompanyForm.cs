using SisPDV.Application.DTOs.Company;
using SisPDV.Application.ExternalInterfaces;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Entities;
using SisPDV.Domain.Enum;
using SisPDV.Domain.Helpers;
using System.ComponentModel;

namespace SisPDV.APP.CompanyMenu
{
    public partial class CompanyForm : Form
    {
        private readonly int? _userId;
        private readonly ICnpjService _cnpjService;
        private readonly ICepService _cepService;
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;

        private Company? _actualCompany;

        public CompanyForm(ICnpjService cnpjService,
            ICepService cepService,
            ICompanyService companyService,
            int? userId,
            IUserService userService)
        {
            InitializeComponent();
            _cnpjService = cnpjService;
            _cepService = cepService;
            _companyService = companyService;
            _userId = userId;
            _userService = userService;
        }

        private async void CompanyForm_Load(object sender, EventArgs e)
        {
            LoadTaxRegimeCombo();
            _actualCompany = await _companyService.GetAsync();
            var user = await _userService.GetById(_userId);

            if (_actualCompany != null)
            {
                FillFields(_actualCompany);
                txtCNPJ.Enabled = false;
                btnSave.Text = "   Alterar";
            }
            else
            {

                if (!user!.Login.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Apenas o usuário administrador pode cadastrar a empresa.", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }
                btnSave.Text = "   Salvar";
                txtCNPJ.Enabled = true;
            }
        }

        private void FillFields(Company actualCompany)
        {
            if (actualCompany == null)
                return;

            txtCNPJ.Text = actualCompany.CNPJ ?? string.Empty;
            txtCompanyName.Text = actualCompany.CompanyName ?? string.Empty;
            txtFantasyName.Text = actualCompany.FantasyName ?? string.Empty;
            txtIE.Text = actualCompany.IE ?? string.Empty;
            txtIM.Text = actualCompany.IM ?? string.Empty;
            txtUF.Text = actualCompany.UF ?? string.Empty;
            txtCity.Text = actualCompany.City ?? string.Empty;
            txtCityCode.Text = actualCompany.CityCode > 0 ? actualCompany.CityCode.ToString() : string.Empty;
            txtCEP.Text = actualCompany.CEP ?? string.Empty;
            txtStreet.Text = actualCompany.Street ?? string.Empty;
            txtNumber.Text = actualCompany.Number ?? string.Empty;
            txtDistrict.Text = actualCompany.District ?? string.Empty;
            txtPhone.Text = actualCompany.Phone ?? string.Empty;
            txtEmail.Text = actualCompany.Email ?? string.Empty;

            if (actualCompany.TaxRegime > 0)
                cmbTaxRegime.SelectedIndex = (int)actualCompany.TaxRegime;
            else
                cmbTaxRegime.SelectedIndex = 0;
        }

        private void LoadTaxRegimeCombo()
        {
            var list = new List<object>();
            
            list.AddRange(Enum.GetValues(typeof(TaxRegime))
                .Cast<TaxRegime>()
                .Select(tr => new
                {
                    Id = (int)tr,
                    Name = GetEnumDescription(tr)
                }));

            cmbTaxRegime.DisplayMember = "Name";
            cmbTaxRegime.ValueMember = "Id";
            cmbTaxRegime.DataSource = list;
            cmbTaxRegime.SelectedIndex = 0;

        }

        private string GetEnumDescription(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi!.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        private async void txtCNPJ_Leave(object sender, EventArgs e)
        {
            //var cnpj = txtCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "");
            var cnpj = FormatHelper.OnlyNumber(txtCNPJ.Text);
            if (cnpj.Length > 0)
            {
                var cnpjDTO = await _cnpjService.GetCNPJAsync(cnpj);

                if (cnpjDTO == null) return;

                txtCompanyName.Text = cnpjDTO.nome;
                txtFantasyName.Text = cnpjDTO.fantasia;
                txtIE.Text = cnpjDTO.inscricao_estadual;
                txtEmail.Text = cnpjDTO.email;
                txtPhone.Text = cnpjDTO.telefone;
            }
        }

        private async void txtCEP_Leave(object sender, EventArgs e)
        {
            //var cep = txtCEP.Text.Replace("-", "");
            var cep = FormatHelper.OnlyNumber(txtCEP.Text);
            if (cep.Length > 0)
            {
                var cepDto = await _cepService.GetCepsync(cep);

                if (cepDto == null) return;

                txtStreet.Text = cepDto.logradouro;
                txtCity.Text = cepDto.localidade;
                txtCityCode.Text = cepDto.ibge;
                txtDistrict.Text = cepDto.bairro;
                txtUF.Text = cepDto.uf;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            _actualCompany = await _companyService.GetAsync();

            if (_actualCompany == null)
            {
                var newCompany = new CompanyDTO
                {
                    Id = 0,
                    //CNPJ = txtCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", ""),
                    CNPJ = FormatHelper.OnlyNumber(txtCNPJ.Text),
                    CompanyName = txtCompanyName.Text,
                    FantasyName = txtFantasyName.Text,
                    IE = txtIE.Text,
                    IM = txtIM.Text,
                    UF = txtUF.Text,
                    City = txtCity.Text,
                    CityCode = !string.IsNullOrEmpty(txtCityCode.Text) ? Convert.ToInt32(txtCityCode.Text) : 0,
                    //CEP = txtCEP.Text.Replace("-", ""),
                    CEP = FormatHelper.OnlyNumber(txtCEP.Text),
                    Street = txtStreet.Text,
                    Number = txtNumber.Text,
                    District = txtDistrict.Text,
                    //Phone = txtPhone.Text.Replace("(", "").Replace(")", "").Replace("-", ""),
                    Phone = FormatHelper.OnlyNumber(txtPhone.Text),
                    Email = txtEmail.Text,
                    TaxRegime = (TaxRegime)cmbTaxRegime.SelectedValue!
                };

                var validate = await validateDate(newCompany);
                
                if (!validate)
                    return;

                await _companyService.SaveAsync(newCompany);

                //Gera hash para o cnpj 
                await _companyService.SaveCnpjHashAsync(newCompany.CNPJ);

                MessageBox.Show("Empresa salva com sucesso!", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var oldCompany = new CompanyDTO
                {
                    Id = _actualCompany.Id,
                    CNPJ = _actualCompany.CNPJ,
                    CompanyName = txtCompanyName.Text,
                    FantasyName = txtFantasyName.Text,
                    IE = txtIE.Text,
                    IM = txtIM.Text,
                    UF = txtUF.Text,
                    City = txtCity.Text,
                    CityCode = Convert.ToInt32(txtCityCode.Text),
                    //CEP = txtCEP.Text.Replace("-", ""),
                    CEP = FormatHelper.OnlyNumber(txtCEP.Text),
                    Street = txtStreet.Text,
                    Number = txtNumber.Text,
                    District = txtDistrict.Text,
                    //Phone = txtPhone.Text.Replace("(", "").Replace(")", "").Replace("-", ""),
                    Phone = FormatHelper.OnlyNumber(txtPhone.Text),
                    Email = txtEmail.Text,
                    TaxRegime = (TaxRegime)cmbTaxRegime.SelectedValue!
                }; 

                var Validate = await validateDate(oldCompany);
                if (!Validate)
                    return;

                await _companyService.SaveAsync(oldCompany);

                MessageBox.Show("Empresa atualizada com sucesso!", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            
            txtCNPJ.Enabled = false;
            btnSave.Text = "   Alterar";
        }

        private async Task<bool> validateDate(CompanyDTO companyDate)
        {
            var validateDate = await _companyService.ValidateCompanyData(companyDate);

            if (!validateDate.IsValid)
            {
                MessageBox.Show(string.Join("\n", validateDate.Errors), "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
