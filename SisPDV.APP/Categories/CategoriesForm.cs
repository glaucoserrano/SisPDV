using SisPDV.Application.DTOs.Category;
using SisPDV.Application.Interfaces;
using SisPDV.Application.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace SisPDV.APP.Categories
{
    public partial class CategoriesForm : Form
    {
        private readonly ICategoryService _categoryService;
        private int _categoryId;

        public CategoriesForm(ICategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;
        }
        private async void CategoriesForm_Load(object sender, EventArgs e)
        {
            _categoryId = 0;
            configCategoryGrid();
            rbAll.Checked = true;
            await LoadCategoriesAsync();
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                var categories = await _categoryService.GetCagoriesAsync();
                dgvCategory.DataSource = categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar Categorias:{ex.Message}", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void configCategoryGrid()
        {
            dgvCategory.ReadOnly = true;
            dgvCategory.AutoGenerateColumns = false;
            dgvCategory.AllowUserToAddRows = false;
            dgvCategory.AllowUserToDeleteRows = false;
            dgvCategory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategory.MultiSelect = false;
            dgvCategory.RowHeadersVisible = false;

            dgvCategory.Columns.Clear();

            dgvCategory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "Id",
                DataPropertyName = "Id",
                Width = 100,
                Visible = false
            });

            dgvCategory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDescription",
                HeaderText = "Descrição",
                DataPropertyName = "Description",
                Width = 400
            });

            dgvCategory.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colActive",
                HeaderText = "Ativo",
                DataPropertyName = "Active",
                Width = 60,
                Visible = false
            });
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var request = MapFormToDTO();

            var result = await validateData(request);

            if (!result)
                return;
            await _categoryService.SaveAsync(request);

            if (_categoryId == 0)
            {
                MessageBox.Show("Cadastro salvo com sucesso", "Sis_PDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cadastro alterado com sucesso", "Sis_PDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            CleanData();
            await LoadCategoriesAsync();
        }

        private void CleanData()
        {
            _categoryId = 0;
            txtDescription.Clear();
            chkActive.Checked = true;
        }

        private async Task<bool> validateData(CategoryDTO request)
        {
            var validate = await _categoryService.ValidateAsync(request);

            if (!validate.IsValid)
            {
                MessageBox.Show(string.Join("\n", validate.Errors), "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private CategoryDTO MapFormToDTO()
        {
            return new CategoryDTO
            {
                Id = _categoryId,
                Description = txtDescription.Text.Trim(),
                Active = chkActive.Checked
            };
        }

        private async void dgvCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var id = (int)dgvCategory.Rows[e.RowIndex].Cells["colId"].Value;

                var category = await _categoryService.GetByIdAsync(id);

                if (category != null)
                {
                    txtDescription.Text = category.Description;
                    chkActive.Checked = category.Active;
                    _categoryId = id;
                }
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            CleanData();
        }
        private async Task LoadAsyncSearchCategory()
        {
            var search = txtSearch.Text;
            var statusFilter = GetStatusFilter();

            var list = await _categoryService.SearchAsync(search, statusFilter);

            dgvCategory.DataSource = list;
        }

        private int GetStatusFilter()
        {
            if (rbActive.Checked) return 0; //ativo
            if (rbInactive.Checked) return 1; //inativo
            return -1; //todos
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            await LoadAsyncSearchCategory();
        }

        private async void rbActive_CheckedChanged(object sender, EventArgs e)
        {
            await LoadAsyncSearchCategory();
        }

        private async void rbInactive_CheckedChanged(object sender, EventArgs e)
        {
            await LoadAsyncSearchCategory();
        }

        private async void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            await LoadAsyncSearchCategory();
        }
    }
}
