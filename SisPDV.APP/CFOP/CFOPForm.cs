using SisPDV.Application.DTOs.Cfop;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisPDV.APP.CFOP
{
    public partial class CFOPForm : Form
    {
        private readonly ICfopService _cfopService;

        private int _CfopId;
        public CFOPForm(ICfopService cfopService)
        {
            _cfopService = cfopService;
            InitializeComponent();
        }
        private async void CFOPForm_Load(object sender, EventArgs e)
        {
            _CfopId = 0;
            ConfigCFOPGrid();
            rdbAll.Checked = true;
            await LoadCfopsAsync();
        }
        private void ConfigCFOPGrid()
        {
            dgvSearchCFOP.ReadOnly = true;
            dgvSearchCFOP.AutoGenerateColumns = false;
            dgvSearchCFOP.AllowUserToAddRows = false;
            dgvSearchCFOP.AllowUserToDeleteRows = false;
            dgvSearchCFOP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSearchCFOP.MultiSelect = false;
            dgvSearchCFOP.RowHeadersVisible = false;

            dgvSearchCFOP.Columns.Clear();

            dgvSearchCFOP.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "Id",
                DataPropertyName = "Id",
                Visible = false
            });

            dgvSearchCFOP.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCode",
                HeaderText = "Código(CFOP)",
                DataPropertyName = "Code",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvSearchCFOP.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDescription",
                HeaderText = "Descrição",
                DataPropertyName = "Description",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvSearchCFOP.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colActive",
                HeaderText = "Ativo",
                DataPropertyName = "Active",
                Width = 60,
                Visible = false
            });
        }
        private async Task LoadCfopsAsync()
        {
            try
            {
                var cfops = await _cfopService.GetCfopAsync();
                dgvSearchCFOP.DataSource = cfops;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar CFOs:{ex.Message}", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var request = MapFormToDTO();

            var result = await validateData(request);

            if (!result)
                return;
            await _cfopService.SaveAsync(request);

            if (_CfopId == 0)
            {
                MessageBox.Show("Cadastro salvo com sucesso", "Sis_PDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cadastro alterado com sucesso", "Sis_PDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            CleanData();
            await LoadCfopsAsync();

        }

        private void CleanData()
        {
            _CfopId = 0;
            txtCode.Clear();
            txtCode.Focus();
            txtDescription.Clear();
            txtNotes.Clear();
            chkActive.Checked = true;
        }

        private async Task<bool> validateData(CfopDTO request)
        {
            var validate = await _cfopService.ValidateAsync(request);

            if (!validate.IsValid)
            {
                MessageBox.Show(string.Join("\n", validate.Errors), "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;

        }

        private CfopDTO MapFormToDTO()
        {
            return new CfopDTO
            {
                Id = _CfopId,
                Code = txtCode.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Note = txtNotes.Text.Trim(),
                Active = chkActive.Checked
            };


        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustNumbers(e.KeyChar))
                e.Handled = true;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            CleanData();
        }

        private async void dgvSearchCFOP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var id = (int)dgvSearchCFOP.Rows[e.RowIndex].Cells["colId"].Value;

                var cfop = await _cfopService.GetByIdAsync(id);

                if (cfop != null)
                {
                    txtCode.Text = cfop.Code;
                    txtDescription.Text = cfop.Description;
                    txtNotes.Text = cfop.Note;
                    chkActive.Checked = cfop.Active;
                    _CfopId = id;
                }
            }
        }

        private async void txtSearchDescription_TextChanged(object sender, EventArgs e)
        {
            await LoadAsyncSearchCFop();
        }
        private async Task LoadAsyncSearchCFop()
        {
            var search = txtSearchDescription.Text;
            var statusFilter = GetStatusFilter();

            var list = await _cfopService.SearchAsync(search, statusFilter);

            dgvSearchCFOP.DataSource = list;
        }
        private int GetStatusFilter()
        {
            if (rdbActive.Checked) return 0; //ativo
            if (rdbInactive.Checked) return 1; //inativo
            return -1; //todos
        }

        private async void rdbActive_CheckedChanged(object sender, EventArgs e)
        {
            await LoadAsyncSearchCFop();
        }

        private async void rdbInactive_CheckedChanged(object sender, EventArgs e)
        {
            await LoadAsyncSearchCFop();
        }

        private async void rdbAll_CheckedChanged(object sender, EventArgs e)
        {
            await LoadAsyncSearchCFop();
        }
    }
}
