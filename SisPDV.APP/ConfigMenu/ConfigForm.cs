using SisPDV.Application.DTOs.Config.PrintSector;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Helpers;
using System.Data;
using System.Drawing.Printing;
using System.Threading.Tasks;

namespace SisPDV.APP.ConfigMenu
{
    public partial class ConfigForm : Form
    {
        private readonly IPrinterSerctorsServices _printerSectors;
        private readonly IConfigService _configServices;
        public ConfigForm(IPrinterSerctorsServices printerSectorsService, IConfigService configServices)
        {
            InitializeComponent();
            _printerSectors = printerSectorsService;
            _configServices = configServices;
        }

        private void btnSelectBackupPath_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Selecione uma pasta para backup automático";
                folderDialog.ShowNewFolderButton = true;

                DialogResult result = folderDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    txtBackupPath.Text = folderDialog.SelectedPath;
                }
                else
                {
                    MessageBox.Show("Caminho de pasta inválido ou não selecionado.", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void chkPrinterSector_CheckedChanged(object sender, EventArgs e)
        {
            dgvPrintSectors.Visible = chkPrinterSector.Checked;
            btnAddSector.Visible = chkPrinterSector.Checked;
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            ConfigGrid();
            PutPrintOnGrid();
        }
        private void ConfigGrid()
        {
            dgvPrintSectors.Columns.Clear();
            dgvPrintSectors.AutoGenerateColumns = false;
            dgvPrintSectors.AllowUserToAddRows = false;
            dgvPrintSectors.RowHeadersVisible = false;
            dgvPrintSectors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Coluna Nome do Setor
            var colNome = new DataGridViewTextBoxColumn
            {
                Name = "SectorName",
                HeaderText = "Setor",
                Width = 200
            };
            dgvPrintSectors.Columns.Add(colNome);

            // Coluna Impressora (ComboBox)
            var colImpressora = new DataGridViewComboBoxColumn
            {
                Name = "PrinterName",
                HeaderText = "Impressora",
                Width = 200,
                DataSource = PrinterSettings.InstalledPrinters.Cast<string>().ToList()
            };
            dgvPrintSectors.Columns.Add(colImpressora);

            // Coluna Nº de Cópias
            var colCopias = new DataGridViewTextBoxColumn
            {
                Name = "NumberOfCopies",
                HeaderText = "Nº de Cópias",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            dgvPrintSectors.Columns.Add(colCopias);

            // Coluna Ativo (CheckBox)
            var colAtivo = new DataGridViewCheckBoxColumn
            {
                Name = "Active",
                HeaderText = "Ativo",
                Width = 70
            };
            dgvPrintSectors.Columns.Add(colAtivo);

            // Coluna Setor Padrão (CheckBox)
            var colPadrao = new DataGridViewCheckBoxColumn
            {
                Name = "IsDefault",
                HeaderText = "Padrão",
                Width = 70
            };
            dgvPrintSectors.Columns.Add(colPadrao);

            // Coluna Remover
            var colRemover = new DataGridViewButtonColumn
            {
                Name = "RemoveButton",
                HeaderText = "",
                Text = "Remover",
                UseColumnTextForButtonValue = true,
                Width = 100
            };
            dgvPrintSectors.Columns.Add(colRemover);
        }
        private List<string> GetPrintersInstall()
        {
            return PrinterSettings.InstalledPrinters.Cast<string>().ToList();
        }
        private void PutPrintOnGrid()
        {
            if (dgvPrintSectors.DataSource != null)
            {
                var impressoras = GetPrintersInstall();
                var comboCol = dgvPrintSectors.Columns[1] as DataGridViewComboBoxColumn;

                comboCol!.Items.Clear();
                comboCol.Items.AddRange(impressoras.ToArray());
            }
        }

        private void btnAddSector_Click(object sender, EventArgs e)
        {
            var rowIndex = dgvPrintSectors.Rows.Add();
            dgvPrintSectors.Rows[rowIndex].Cells["SectorName"].Value = string.Empty;
            dgvPrintSectors.Rows[rowIndex].Cells["PrinterName"].Value = null;
        }

        private void dgvPrintSectors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPrintSectors.Columns[e.ColumnIndex].Name == "RemoveButton")
            {
                dgvPrintSectors.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void txtCashNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustNumbers(e.KeyChar))
                e.Handled = true;
        }

        private void txtSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustNumbers(e.KeyChar))
                e.Handled = true;
        }

        private void txtInitialNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustNumbers(e.KeyChar))
                e.Handled = true;
        }

        private void dgvPrintSectors_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var grid = sender as DataGridView;

            if (grid!.Columns[e.ColumnIndex].Name == "NumberOfCopies")
            {
                var cell = grid.Rows[e.RowIndex].Cells[e.ColumnIndex];

                var value = cell.Value?.ToString();

                if (!int.TryParse(value, out int copies) || copies < 1)
                {
                    MessageBox.Show("Informe um número válido maior que zero para as cópias.", "SisPDV",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    cell.Value = 1;

                    grid.CurrentCell = cell;
                    grid.BeginEdit(true);
                }
            }
        }

        private void dgvPrintSectors_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPrintSectors.Columns[e.ColumnIndex].Name == "IsDefault")
            {
                var currentRow = dgvPrintSectors.Rows[e.RowIndex];

                bool isChecked = Convert.ToBoolean(currentRow.Cells["IsDefault"].Value);

                if (isChecked)
                {
                    foreach (DataGridViewRow row in dgvPrintSectors.Rows)
                    {
                        if (row.Index != e.RowIndex)
                        {
                            row.Cells["IsDefault"].Value = false;
                        }
                    }
                }
            }
        }

        private void dgvPrintSectors_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvPrintSectors.IsCurrentCellDirty)
            {
                dgvPrintSectors.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private bool validateCashNumber()
        {
            

            if (int.TryParse(txtCashNumber.Text, out var cashNumber) || cashNumber == 0)
            {
                MessageBox.Show("O número do caixa deve ser maior que zero.", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private async Task btnSave_Click(object sender, EventArgs e)
        {
            if (!validateCashNumber())
            {
                return;
            }

            var result = await _configServices.SaveAsyncConfig(
                cashNumber: int.TryParse(txtCashNumber.Text, out var cashNumber),
                requestPrintSector: GetPrinterSectorsList(),
                );
        }
        private List<PrintSectorsDTO> GetPrinterSectorsList()
        {
            var sectores = new List<PrintSectorsDTO>();

            foreach (DataGridViewRow row  in dgvPrintSectors.Rows)
            {
                if (row.IsNewRow) continue;

                var sectorName = row.Cells["SectorName"]?.Value?.ToString();
                var printerName = row.Cells["PrinterName"]?.Value?.ToString();
                var numberOfCopiesStr = row.Cells["NumberOfCopies"]?.Value?.ToString() ?? "1";
                var active = row.Cells["Active0"]?.Value as bool? ?? true;
                var isDefault = row.Cells["IsDefault"]?.Value as bool? ?? false;

                if (string.IsNullOrEmpty(sectorName) || string.IsNullOrEmpty(printerName))
                    continue;

                if (!int.TryParse(numberOfCopiesStr, out var numberOfCopies) || numberOfCopies < 1)
                    numberOfCopies = 1;

                sectores.Add(new PrintSectorsDTO
                {
                    SectorName = sectorName,
                    PrinterName = printerName,
                    NumberOfCopies = numberOfCopies,
                    Active = active,
                    IsDefault = isDefault
                });
            }
            return sectores;
        }
    }
}
