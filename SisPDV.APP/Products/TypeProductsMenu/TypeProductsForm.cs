using SisPDV.APP.Helpers;
using SisPDV.Application.DTOs.Company;
using SisPDV.Application.DTOs.ProductType;
using SisPDV.Application.DTOs.Validation;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Enum;
using SisPDV.Domain.Helpers;
using System.Globalization;
using System.Threading.Tasks;

namespace SisPDV.APP.Products.TypeProductsMenu
{
    public partial class TypeProductsForm : Form
    {
        private readonly ICompanyService _companyService;
        private readonly IProductTypeService _productTypeService;
        private CompanyDTO? _company;
        private int _idProductType;

        public TypeProductsForm(ICompanyService companyService, IProductTypeService productTypeService)
        {
            InitializeComponent();
            _companyService = companyService;
            _productTypeService = productTypeService;
        }

        private async void TypeProductsForm_Load(object sender, EventArgs e)
        {
            _idProductType = 0;
            _company = await _companyService.GetAsync();

            configTypesGrid();
            loadComboEnum();
            await LoadProductTypesGridAsync();
        }

        private async Task LoadProductTypesGridAsync()
        {
            var productTypes = await _productTypeService.GetProductTypesAsync();

            dgvTypes.DataSource = productTypes.Select(p => new
            {
                p.Id,
                p.Type,
                p.NCM,
                p.IVA,
                p.CFOP,
                Origin = p.Origin?.ToString(),

            }).ToList();
        }

        private void loadComboEnum()
        {
            LoadEnumToComboHelper.LoadEnumToComboBox<ProductOrigin>(cmbOrigin);

            if (_company!.TaxRegime == TaxRegime.SimplesNacional)
            {
                LoadEnumToComboHelper.LoadEnumToComboBox<CSOSN>(cmbCST_CSOSN);
            }
            else
            {
                LoadEnumToComboHelper.LoadEnumToComboBox<CST_ICMS>(cmbCST_CSOSN);
            }
            LoadEnumToComboHelper.LoadEnumToComboBox<CST_COFINS>(cmbCSTCOFINS);
            LoadEnumToComboHelper.LoadEnumToComboBox<CST_PIS>(cmbCSTPIS);
        }

        private void configTypesGrid()
        {
            dgvTypes.ReadOnly = true;
            dgvTypes.AutoGenerateColumns = false;
            dgvTypes.AllowUserToAddRows = false;
            dgvTypes.AllowUserToDeleteRows = false;
            dgvTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTypes.MultiSelect = false;
            dgvTypes.RowHeadersVisible = false;

            dgvTypes.Columns.Clear();

            dgvTypes.Columns.Clear();

            dgvTypes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "Id",
                DataPropertyName = "Id",
                Width = 280,
                Visible = false
            });

            dgvTypes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "Tipo de Produto",
                DataPropertyName = "Type",
                Width = 280
            });

            dgvTypes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNCM",
                HeaderText = "NCM",
                DataPropertyName = "NCM",
                Width = 150
            });

            dgvTypes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCFOP",
                HeaderText = "CFOP",
                DataPropertyName = "CFOP",
                Width = 150
            });

            dgvTypes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIVA",
                HeaderText = "IVA (%)",
                DataPropertyName = "IVA",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvTypes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colOrigin",
                HeaderText = "Origem",
                DataPropertyName = "Origin",
                Width = 155
            });
        }

        private ProductTypeDTO BuildProductTypeFromForm()
        {

            var dto = new ProductTypeDTO
            {
                Id = _idProductType,
                Type = txtTypeName.Text.Trim(),
                NCM = string.IsNullOrWhiteSpace(txtNCM.Text) ? null : txtNCM.Text.Trim(),
                IVA = string.IsNullOrWhiteSpace(txtIVA.Text) ? null : decimal.Parse(txtIVA.Text, new CultureInfo("pt-BR")),
                CFOP = string.IsNullOrWhiteSpace(txtCFOP.Text) ? null : txtCFOP.Text.Trim(),
                Origin = cmbOrigin.SelectedValue is int origin && origin >= 0 ? (ProductOrigin?)origin : null,
                CST_PIS = cmbCSTPIS.SelectedValue is int pis && pis > 0 ? (CST_PIS?)pis : null,
                CST_COFINS = cmbCSTCOFINS.SelectedValue is int cofins && cofins > 0 ? (CST_COFINS?)cofins : null,
                Notes = string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text.Trim()
            };
            if (_company!.TaxRegime == TaxRegime.SimplesNacional)
            {
                dto.CST_CSOSN = cmbCST_CSOSN.SelectedValue is int csosn && csosn > 0 ? (CSOSN)csosn : null;
                dto.CST_ICMS = null;
            }
            else
            {
                dto.CST_CSOSN = null;
                dto.CST_ICMS = cmbCST_CSOSN.SelectedValue is int cst_icms && cst_icms > 0 ? (CST_ICMS)cst_icms : null;
            }
            return dto;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var request = BuildProductTypeFromForm();

            var results = await ValidateData(request);

            if (!results)
                return;

            await _productTypeService.SaveAsync(request);

            if (_idProductType == 0)
            {
                MessageBox.Show("Cadastro salvo com sucesso", "Sis_PDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cadastro alterado com sucesso", "Sis_PDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            CleanData();
            await LoadProductTypesGridAsync();
        }

        private void CleanData()
        {
            _idProductType = 0;

            txtTypeName.Clear();
            txtNCM.Clear();
            txtIVA.Clear();
            txtCFOP.Clear();
            txtNotes.Clear();

            // Seleciona o primeiro item ("0 - Selecione") nos combos
            cmbOrigin.SelectedIndex = 0;
            cmbCST_CSOSN.SelectedIndex = 0;
            cmbCSTPIS.SelectedIndex = 0;
            cmbCSTCOFINS.SelectedIndex = 0;

            // Se desejar dar foco no primeiro campo
            txtTypeName.Focus();

            btnSave.Text = "   Salvar";
        }

        private async Task<bool> ValidateData(ProductTypeDTO request)
        {
            var validateDate = await _productTypeService.ValidateAsync(request);

            if (!validateDate.IsValid)
            {
                MessageBox.Show(string.Join("\n", validateDate.Errors), "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            CleanData();
        }

        private async void dgvTypes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvTypes.Rows[e.RowIndex];

                _idProductType = Convert.ToInt32(row.Cells["colId"].Value);

                var productType = await _productTypeService.GetByIdAsync(_idProductType);

                if (productType == null) 
                {
                    MessageBox.Show("Tipo de produto não encontrado.");
                    return;
                }

                _idProductType = productType.Id;
                txtTypeName.Text = productType.Type ?? "";
                txtNCM.Text = productType.NCM ?? "";
                txtIVA.Text = productType.IVA?.ToString("N2") ?? "";
                txtCFOP.Text = productType.CFOP ?? "";
                txtNotes.Text = productType.Notes ?? "";

                cmbOrigin.SelectedValue = productType.Origin.HasValue ? (int)productType.Origin.Value : 0;

                if (_company!.TaxRegime == TaxRegime.SimplesNacional)
                {
                    cmbCST_CSOSN.SelectedValue = productType.CST_CSOSN.HasValue ? (int)productType.CST_CSOSN.Value : 0;
                }
                else
                {
                    cmbCST_CSOSN.SelectedValue = productType.CST_ICMS.HasValue ? (int)productType.CST_ICMS.Value : 0;
                }

                cmbCSTPIS.SelectedValue = productType.CST_PIS.HasValue ? (int)productType.CST_PIS.Value : 0;
                cmbCSTCOFINS.SelectedValue = productType.CST_COFINS.HasValue ? (int)productType.CST_COFINS.Value : 0;

            }
            
        }

        private void txtNCM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustNumbers(e.KeyChar))
                e.Handled = true;
        }

        private void txtIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustDecimal(txtIVA.Text, e.KeyChar))
                e.Handled = true;
        }
    }
}
