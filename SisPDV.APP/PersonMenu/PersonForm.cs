using SisPDV.Application.DTOs.Company;
using SisPDV.Application.DTOs.Person;
using SisPDV.Application.ExternalInterfaces;
using SisPDV.Application.Interfaces;
using SisPDV.Application.Services;
using SisPDV.Domain.Entities;
using SisPDV.Domain.Enum;
using SisPDV.Domain.Helpers;
using System;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SisPDV.APP.PersonMenu
{
    public partial class PersonForm : Form
    {
        private readonly ICepService _cepService;
        private readonly IPersonService _personService;

        private int? _idPerson;
        public PersonForm(ICepService cepService, IPersonService personService)
        {
            InitializeComponent();
            _cepService = cepService;
            _personService = personService;
        }

        private void rdoPersonTypeCompany_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPersonTypeCompany.Checked)
            {
                txtCNPJ.Mask = "00,000,000/0000-00"; // CNPJ
                txtCNPJ.Text = string.Empty;
                txtIE.Text = "";
                rdbIndicatorContribuinteICMS.Checked = true;
            }
        }

        private void rdoPersonTypeIndividual_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPersonTypeIndividual.Checked)
            {
                txtCNPJ.Mask = "000,000,000-00"; // CPF
                txtCNPJ.Text = string.Empty;
                txtIE.Text = "ISENTO";
                rdbIndicatorNaoContribuinte.Checked = true;
            }

        }

        private void PersonForm_Load(object sender, EventArgs e)
        {
            rdoPersonTypeCompany.Checked = true;
            rdbIndicatorContribuinteICMS.Checked = true;

            ConfigSearchGrid();

        }

        private async void txtCEP_Leave(object sender, EventArgs e)
        {
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

        private async void txtCNPJ_Leave(object sender, EventArgs e)
        {
            var cnpjCPF = FormatHelper.OnlyNumber(txtCNPJ.Text).Trim();

            if (rdoPersonTypeIndividual.Checked && !string.IsNullOrEmpty(cnpjCPF))
            {
                if (!ValidationHelper.ValidCPF(cnpjCPF))
                {
                    MessageBox.Show("CPF inválido!", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCNPJ.Focus();
                }
            }
            else if (!ValidationHelper.ValidCNPJ(cnpjCPF) && !string.IsNullOrEmpty(cnpjCPF))
            {
                MessageBox.Show("CNPJ inválido!", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCNPJ.Focus();
            }

            var personExists = await _personService.GetByDocument(cnpjCPF);

            if (personExists != null)
            {
                var result = MessageBox.Show("Já existe um cadastro com esse documento. Deseja editar os dados?", "SisPDV", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    FillFormWithPerson(personExists);
                }
            }

        }
        private void FillFormWithPerson(PersonDTO? personExists)
        {
            _idPerson = personExists!.Id;


            if (personExists.PersonType == PersonType.Company)
                rdoPersonTypeCompany.Checked = true;
            else
                rdoPersonTypeIndividual.Checked = true;

            txtName.Text = personExists.Name;
            //txtCNPJ.Text = personExists.CNPJ_CPF;
            txtIE.Text = personExists.IE;
            switch (personExists.IEIndicator)
            {
                case IEIndicator.ContribuinteICMS:
                    rdbIndicatorContribuinteICMS.Checked = true;
                    break;

                case IEIndicator.ContribuinteIsento:
                    rdbIndicatorIsento.Checked = true;
                    break;

                case IEIndicator.NaoContribuinte:
                    rdbIndicatorNaoContribuinte.Checked = true;
                    break;

                default:
                    rdbIndicatorContribuinteICMS.Checked = true;
                    break;
            }

            //txt.Text = personExists.IM;
            txtEmail.Text = personExists.Email;
            txtPhone.Text = personExists.Phone;
            txtCNPJ.Text = personExists.CNPJ_CPF;
            txtCEP.Text = personExists.ZipCode;
            txtStreet.Text = personExists.Street;
            txtNumber.Text = personExists.Number;
            txtComplement.Text = personExists.Complement;
            txtDistrict.Text = personExists.District;
            txtCity.Text = personExists.City;
            txtUF.Text = personExists.State;
            txtCityCode.Text = personExists.CityCode.ToString();


            chkClient.Checked = personExists.IsCustomer;
            chkSupplier.Checked = personExists.IsSupplier;
            chkCarrier.Checked = personExists.IsCarrier;
            chkActive.Checked = personExists.IsActive;

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var request = BuildPersonDTOFromForm();

            var results = await validateData(request);

            if (!results)
                return;

            await _personService.SaveAsync(request);

            if(_idPerson == 0)
            {
                MessageBox.Show("Cadastro salvo com sucesso", "Sis_PDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cadastro alterado com sucesso", "Sis_PDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            CleanData();
        }

        private PersonDTO BuildPersonDTOFromForm()
        {
            return new PersonDTO
            {
                Id = _idPerson,
                Name = txtName.Text.Trim(),
                CNPJ_CPF = FormatHelper.OnlyNumber(txtCNPJ.Text).Trim(),
                IE = txtIE.Text.Trim(),
                IEIndicator = GetSelectedIEIndicator(),
                //IM = txtIM.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = FormatHelper.OnlyNumber(txtPhone.Text).Trim(),

                ZipCode = FormatHelper.OnlyNumber(txtCEP.Text).Trim(),
                Street = txtStreet.Text.Trim(),
                Number = txtNumber.Text.Trim(),
                Complement = txtComplement.Text.Trim(),
                District = txtDistrict.Text.Trim(),
                City = txtCity.Text.Trim(),
                CityCode = int.TryParse(txtCityCode.Text, out var cityCode) ? cityCode : 0,
                State = txtUF.Text.Trim(),
                //Country = txtCountry.Text.Trim(),
                //CountryCode = txtCountryCode.Text.Trim(),

                PersonType = rdoPersonTypeIndividual.Checked ? PersonType.Individual : PersonType.Company,

                IsCustomer = chkClient.Checked,
                IsSupplier = chkSupplier.Checked,
                IsCarrier = chkCarrier.Checked,

                IsActive = chkActive.Checked
            };
        }

        private IEIndicator GetSelectedIEIndicator()
        {
            if (rdbIndicatorContribuinteICMS.Checked) return IEIndicator.ContribuinteICMS;
            if (rdbIndicatorIsento.Checked) return IEIndicator.ContribuinteIsento;
            if (rdbIndicatorNaoContribuinte.Checked) return IEIndicator.NaoContribuinte;

            return IEIndicator.ContribuinteICMS; // padrão
        }

        private async Task<bool> validateData(PersonDTO personDate)
        {
            var validateData = await _personService.ValidateAsync(personDate);

            if (!validateData.IsValid)
            {
                MessageBox.Show(string.Join("\n", validateData.Errors), "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void ConfigSearchGrid()
        {
            dgvPerson.AutoGenerateColumns = false;
            dgvPerson.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPerson.MultiSelect = false;
            dgvPerson.ReadOnly = true;

            dgvPerson.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "CPF/CNPJ",
                DataPropertyName = "CNPJ_CPF",
                Width = 260
            });

            dgvPerson.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nome",
                DataPropertyName = "Name",
                Width = 262
            });

            dgvPerson.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tipo",
                DataPropertyName = "Types", // Ex: Cliente, Transportadora
                Width = 260
            });
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var name = txtSearchName.Text.Trim();
            var doc = FormatHelper.OnlyNumber(txtSerachCNPJ.Text).Trim();
            var active = chkSearchActive.Checked;
            var filterClient = chkSearchClient.Checked;
            var filterSupplier = chkSearchSupplier.Checked;
            var filterCarrier = chkSearchCarrier.Checked;

            var persons = await _personService.SearchAsync(
                name, doc, active, filterClient, filterSupplier, filterCarrier);


            var data = persons.Select(p => new PersonGridDTO
            {
                Id = p.Id,
                CNPJ_CPF = p.CNPJ_CPF,
                Name = p.Name,
                IsCustomer = p.IsCustomer,
                IsSupplier = p.IsSupplier,
                IsCarrier = p.IsCarrier
            }).ToList();

            dgvPerson.DataSource = data;
        }

        private void rdbSearchCompany_CheckedChanged(object sender, EventArgs e)
        {
            txtSerachCNPJ.Mask = "00,000,000/0000-00"; // CNPJ
            txtSerachCNPJ.Text = string.Empty;
        }

        private void rdbSearchIndividual_CheckedChanged(object sender, EventArgs e)
        {
            txtSerachCNPJ.Mask = "000,000,000-00"; // CPF
            txtSerachCNPJ.Text = string.Empty;
        }

        private async void dgvPerson_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedPerson = dgvPerson.Rows[e.RowIndex].DataBoundItem as PersonGridDTO;

                if (selectedPerson != null)
                {
                    var person = await _personService.GetByDocument(FormatHelper.OnlyNumber(selectedPerson.CNPJ_CPF));

                    FillFormWithPerson(person);

                    tabControl.SelectedTab = tabRegister;
                }
            }
        }
        private void CleanData()
        {
            _idPerson = 0;
            txtName.Text = string.Empty;
            txtCNPJ.Text = string.Empty;
            txtIE.Text = string.Empty;
            rdbIndicatorContribuinteICMS.Checked = true;

            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;

            txtCEP.Text = string.Empty;
            txtStreet.Text = string.Empty;
            txtNumber.Text = string.Empty;
            txtComplement.Text = string.Empty;
            txtDistrict.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtUF.Text = string.Empty;

            txtCityCode.Text = string.Empty;

            rdoPersonTypeCompany.Checked = true;
            rdoPersonTypeIndividual.Checked = false;

            chkClient.Checked = false;
            chkSupplier.Checked = false;
            chkCarrier.Checked = false;
            chkActive.Checked = true;

            txtName.Focus();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            CleanData();
        }
    }
}
