using SisPDV.APP.Helpers;
using SisPDV.Application.DTOs.Config;
using SisPDV.Application.DTOs.Config.PrintSector;
using SisPDV.Application.Helper;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Enum;
using SisPDV.Domain.Helpers;
using System.Data;
using System.Drawing.Printing;
using System.Threading.Tasks;
using WindowsForms = System.Windows.Forms;

namespace SisPDV.APP.ConfigMenu
{
    public partial class ConfigForm : Form
    {
        private readonly IPrinterSerctorsServices _printerSectors;
        private readonly IConfigService _configServices;

        public ConfigForm(
            IPrinterSerctorsServices printerSectorsService,
            IConfigService configServices
            )
        {
            InitializeComponent();
            _printerSectors = printerSectorsService;
            _configServices = configServices;
        }

        private void btnSelectBackupPath_Click(object sender, EventArgs e)
        {
            selectedPath(txtBackupPath);
        }

        private void selectedPath(TextBox txtPath)
        {
            var result = SelectedHelper.SelectedPath(txtBackupPath);

            if (!string.IsNullOrWhiteSpace(result))
            {
                txtPath.Text = result;
            }
            else
            {
                MessageBox.Show("Caminho de pasta inválido ou não selecionado.", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void chkPrinterSector_CheckedChanged(object sender, EventArgs e)
        {
            dgvPrintSectors.Visible = chkPrinterSector.Checked;
            btnAddSector.Visible = chkPrinterSector.Checked;
            
        }

        private async void ConfigForm_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            ConfigGrid();
            PutPrintOnGrid();

            await loadConfigs();
            
        }

        private async Task loadConfigs()
        {
            var cashNumber = CashNumberHelper.GetCashNumber(
                pathSystem: WindowsForms.Application.StartupPath);

            txtCashNumber.Text = cashNumber.ToString();

            var (config, printerSectors) = await _configServices.GetFullConfigAsync();

            txtDigitalCertificate.Text = config.DigitalCertificate;
            txtPasswordCertificate.Text = config.PasswordCertificate;
            chkCertificateA1.Checked = config.CertificateA1;
            setCertificateGroupState();

            chkEnableNFCe.Checked = config.NFCeEnabled;
            SetNFCeGroupState();

            txtVersionDF.Text = config.VersionDF;
            txtNFCEModel.Text = config.Model.ToString();
            txtSerial.Text = config.Serial.ToString();
            txtInitialNumber.Text = config.InitialNumber.ToString();
            cmbEnvironment.SelectedValue = (int)config.Environment;
            txtCSC.Text = config.CSC;
            txtCSCId.Text = config.CSCId;
            chkPrintNFCe.Checked = config.Print;
            cmbTypeEmission.SelectedValue = (int)config.TypeEmission;
            txtXMLPath.Text = config.XMLPath;

            chkEnableNFe.Checked = config.NFeEnabled;
            setNFeGroupState();

            txtVersionNFe.Text = config.NFeVersionDF;
            txtNFeModel.Text = config.NFeModel.ToString();
            txtNFeSerial.Text = config.NFeSerial.ToString();
            txtNFeInitialNumber.Text = config.NFeInitialNumber.ToString();
            txtNFeXmlPath.Text = config.NFeXmlPath;
            cmbNFeEnvironment.SelectedValue = (int)config.NFeEnvironment;
            chkNFePrint.Checked = config.NFePrint;
            chkNFeSavePDF.Checked = config.NFeSavePDF;
            txtNFeEmail.Text = config.NFeDestinationEmail;
            cmbNFeFinality.SelectedValue = (int)config.NFeFinality;
            cmbNFePresence.SelectedValue= (int)config.NFePresenceIndicator;
            cmbNFePayment.SelectedValue = (int)config.NFePaymentForm;

            chkUseStockControl.Checked = config.UseStockControl;
            chkSalesZeroStock.Checked = config.SalesZeroStock;
            chkOrderPrint.Checked = config.OrderPrint;
            txtBackupPath.Text = config.BackupPath;
            chkAutoCloseOrder.Checked = config.AutoCloseOrder;
            chkPrinterSector.Checked = config.UsePrintSector;

            if (chkPrinterSector.Checked)
                LoadPrintSectors(printerSectors);
                
        }

        private void LoadPrintSectors(List<PrintSectorsDTO> printerSectors)
        {
            dgvPrintSectors.Rows.Clear();


            foreach (var sector in printerSectors)
            {
                dgvPrintSectors.Rows.Add(
                    sector.Id,
                    sector.SectorName,
                    sector.PrinterName,
                    sector.NumberOfCopies,
                    sector.Active ? true : false,
                    sector.IsDefault ? true : false
                    );
            }
        }

        private void LoadComboBox()
        {
            LoadEnumToComboHelper.LoadEnumToComboBox<EnvironmentNFCe>(cmbEnvironment); //Combo Ambiente NFC-e 
            LoadEnumToComboHelper.LoadEnumToComboBox<EnvironmentNFCe>(cmbNFeEnvironment); // Combo Ambiente NF-e
            LoadEnumToComboHelper.LoadEnumToComboBox<NFeFinality>(cmbNFeFinality); //Combo Finalidade NF-e
            LoadEnumToComboHelper.LoadEnumToComboBox<PaymentType>(cmbNFePayment); // Combo Forma de Pagamento Nfe
            LoadEnumToComboHelper.LoadEnumToComboBox<PresenceIndicator>(cmbNFePresence); // Combo Indicador de Presença do Pagador NF-e
            LoadEnumToComboHelper.LoadEnumToComboBox<TypeEmission>(cmbTypeEmission); // Tipo de Emissão NFC-e
        }

        private void ConfigGrid()
        {
            dgvPrintSectors.Columns.Clear();
            dgvPrintSectors.AutoGenerateColumns = false;
            dgvPrintSectors.AllowUserToAddRows = false;
            dgvPrintSectors.RowHeadersVisible = false;
            dgvPrintSectors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Coluna ID (opcional, se quiser mostrar no grid)
            var colId = new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                Width = 50,
                Visible = false // ou true, se quiser mostrar
            };
            dgvPrintSectors.Columns.Add(colId);
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

            dgvPrintSectors.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvPrintSectors.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvPrintSectors.RowHeadersVisible = false;
            dgvPrintSectors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrintSectors.MultiSelect = false;
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

        private async void dgvPrintSectors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPrintSectors.Columns[e.ColumnIndex].Name == "RemoveButton")
            {
                var row = dgvPrintSectors.Rows[e.RowIndex];
                int id = Convert.ToInt32(row.Cells["Id"].Value);

                var confirm = MessageBox.Show("Deseja remover este setor de impressão?", "SisPDV", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    var sucess = await _printerSectors.RemovePrintSectors(id);
                    if(sucess)
                    {
                        dgvPrintSectors.Rows.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao remover o setor de impressão.", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                        
                }
                    
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


            if (int.TryParse(txtCashNumber.Text, out var cashNumber) && cashNumber <= 0)
            {
                MessageBox.Show("O número do caixa deve ser maior que zero.", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!validateCashNumber())
            {
                return;
            }

            int.TryParse(txtCashNumber.Text, out var cashNumber);

            var result = await _configServices.SaveAsyncConfig(
                cashNumber: cashNumber,
                requestPrintSector: GetPrinterSectorsList(),
                requestConfig: GetConfigForm(),
                pathSystem: WindowsForms.Application.StartupPath
                );

            if (!result.IsValid)
            {
                MessageBox.Show(string.Join("\n", result.Errors), "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Configurações salvas com sucesso", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var config = await _configServices.GetConfigAsync();
                SystemConfig.Load(config);
            }
        }

        private ConfigDTO GetConfigForm()
        {
            return new ConfigDTO
            {
                // Certificado Digital
                DigitalCertificate = txtDigitalCertificate.Text.Trim(),
                PasswordCertificate = txtPasswordCertificate.Text.Trim(),
                CertificateA1 = chkCertificateA1.Checked,

                // NFC-e
                NFCeEnabled = chkEnableNFCe.Checked,
                VersionDF = txtVersionDF.Text.Trim(),
                Model = int.TryParse(txtNFCEModel.Text, out var NFCEModel) ? NFCEModel : 65,
                Serial = int.TryParse(txtSerial.Text, out var serial) ? serial : 0,
                InitialNumber = int.TryParse(txtInitialNumber.Text, out var inicial) ? inicial : 0,
                Environment = (EnvironmentNFCe)cmbEnvironment.SelectedValue!, /*? EnvironmentNFCe.Producao : EnvironmentNFCe.Homologacao*/
                CSC = txtCSC.Text.Trim(),
                CSCId = txtCSCId.Text.Trim(),
                Print = chkPrintNFCe.Checked,
                TypeEmission = (TypeEmission)cmbTypeEmission.SelectedValue!,
                XMLPath = txtXMLPath.Text.Trim(),

                // NF-e
                NFeEnabled = chkEnableNFe.Checked,
                NFeVersionDF = txtVersionNFe.Text.Trim(),
                NFeModel = int.TryParse(txtNFeModel.Text, out var NFeModel) ? NFeModel : 55,
                NFeSerial = int.TryParse(txtNFeSerial.Text, out var serialNFe) ? serialNFe : 0,
                NFeInitialNumber = int.TryParse(txtNFeInitialNumber.Text, out var initalNumberNFe) ? initalNumberNFe : 0,
                NFeXmlPath = txtNFeXmlPath.Text.Trim(),
                NFeEnvironment = (EnvironmentNFCe)cmbNFeEnvironment.SelectedValue!, /*EnvironmentNFCe.Producao : EnvironmentNFCe.Homologacao,*/
                NFePrint = chkNFePrint.Checked,
                NFeSavePDF = chkNFeSavePDF.Checked,
                NFeDestinationEmail = txtNFeEmail.Text.Trim(),
                NFeFinality = (NFeFinality)cmbNFeFinality.SelectedValue!,
                NFePresenceIndicator = (PresenceIndicator)cmbNFePresence.SelectedValue!,
                NFePaymentForm = (PaymentType)cmbNFePayment.SelectedValue!,

                // Gerais
                UseStockControl = chkUseStockControl.Checked,
                SalesZeroStock = chkSalesZeroStock.Checked,
                OrderPrint = chkOrderPrint.Checked,
                BackupPath = txtBackupPath.Text.Trim(),
                AutoCloseOrder = chkAutoCloseOrder.Checked,
                UsePrintSector = chkPrinterSector.Checked

            };
        }

        private List<PrintSectorsDTO> GetPrinterSectorsList()
        {
            var sectores = new List<PrintSectorsDTO>();

            foreach (DataGridViewRow row in dgvPrintSectors.Rows)
            {
                if (row.IsNewRow) continue;

                var sectorName = row.Cells["SectorName"]?.Value?.ToString();
                var printerName = row.Cells["PrinterName"]?.Value?.ToString();
                var numberOfCopiesStr = row.Cells["NumberOfCopies"]?.Value?.ToString() ?? "1";
                var active = row.Cells["Active"]?.Value as bool? ?? true;
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

        private void txtVersionDF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustDecimal(txtVersionDF.Text, e.KeyChar))
                e.Handled = true;
        }

        private void txtVersionNFe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustDecimal(txtVersionNFe.Text, e.KeyChar))
                e.Handled = true;
        }

        private void txtNFeModel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustNumbers(e.KeyChar))
                e.Handled = true;
        }

        private void txtNFeSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustNumbers(e.KeyChar))
                e.Handled = true;
        }

        private void txtNFeInitialNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidationHelper.JustNumbers(e.KeyChar))
                e.Handled = true;
        }

        private void btnSelectXMLPath_Click(object sender, EventArgs e)
        {
            selectedPath(txtXMLPath);
        }

        private void btnXMLPathNFe_Click(object sender, EventArgs e)
        {
            selectedPath(txtNFeXmlPath);
        }

        private void btnSelectCertificate_Click(object sender, EventArgs e)
        {
            selectedCertificate(txtDigitalCertificate);
        }

        private void selectedCertificate(TextBox txtFilePath)
        {
            var result = SelectedHelper.SelectCertificateFile();
            if (!string.IsNullOrEmpty(result))
            {
                txtFilePath.Text = result;
            }
            else
            {
                MessageBox.Show("Caminho de arquivo inválido ou não selecionado.", "SisPDV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void chkEnableNFCe_CheckedChanged(object sender, EventArgs e)
        {
            SetNFCeGroupState();
        }
        private void SetNFCeGroupState()
        {
            grbNFCe.Enabled = chkEnableNFCe.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            CancelConfig();
            Cursor.Current = Cursors.Default;
            this.Enabled = true;

        }

        private async void CancelConfig()
        {
            var result = MessageBox.Show("Tem certeza que deseja cancelar as alterações e restaurar os dados salvos?", "SisPDV",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await loadConfigs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao restaurar as configurações: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void chkEnableNFe_CheckedChanged(object sender, EventArgs e)
        {
            setNFeGroupState();
        }
        private void setNFeGroupState()
        {
            grbNFe.Enabled = chkEnableNFe.Checked;
        }

        private void chkCertificateA1_CheckedChanged(object sender, EventArgs e)
        {
            setCertificateGroupState();
        }

        private void setCertificateGroupState()
        {
            grbCertificateDigital.Enabled = chkCertificateA1.Checked;
        }
    }

}
