namespace SisPDV.APP.ConfigMenu
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabConfig = new TabControl();
            tabGeneral = new TabPage();
            groupBox1 = new GroupBox();
            btnSelectBackupPath = new FontAwesome.Sharp.IconButton();
            txtBackupPath = new TextBox();
            lblBackupPath = new Label();
            chkOrderPrint = new CheckBox();
            chkAutoCloseOrder = new CheckBox();
            chkSalesZeroStock = new CheckBox();
            label1 = new Label();
            chkUseStockControl = new CheckBox();
            txtCashNumber = new TextBox();
            tabNFCe = new TabPage();
            chkEnableNFCe = new CheckBox();
            grbNFCe = new GroupBox();
            cmbEnvironment = new ComboBox();
            lblEnvironment = new Label();
            txtInitialNumber = new TextBox();
            lblInitialNumber = new Label();
            txtSerial = new TextBox();
            lblSerial = new Label();
            txtNFCEModel = new TextBox();
            lblModel = new Label();
            txtVersionDF = new TextBox();
            lblVersionDF = new Label();
            chkPrintNFCe = new CheckBox();
            btnSelectXMLPath = new FontAwesome.Sharp.IconButton();
            txtXMLPath = new TextBox();
            lblXMLPath = new Label();
            cmbTypeEmission = new ComboBox();
            lblTypeEmission = new Label();
            txtCSCId = new TextBox();
            lblCSCId = new Label();
            txtCSC = new TextBox();
            lblCSC = new Label();
            tabPrinters = new TabPage();
            groupBox3 = new GroupBox();
            btnAddSector = new FontAwesome.Sharp.IconButton();
            dgvPrintSectors = new DataGridView();
            chkPrinterSector = new CheckBox();
            tabNFe = new TabPage();
            chkEnableNFe = new CheckBox();
            grbNFe = new GroupBox();
            cmbNFePayment = new ComboBox();
            lblNFePayment = new Label();
            cmbNFePresence = new ComboBox();
            lblNFePresence = new Label();
            cmbNFeFinality = new ComboBox();
            lblNFeFinality = new Label();
            txtNFeEmail = new TextBox();
            lblNFeEmail = new Label();
            chkNFeSavePDF = new CheckBox();
            chkNFePrint = new CheckBox();
            btnXMLPathNFe = new FontAwesome.Sharp.IconButton();
            txtNFeXmlPath = new TextBox();
            lblNFeXmlPath = new Label();
            cmbNFeEnvironment = new ComboBox();
            lblNFeEnvironment = new Label();
            txtNFeInitialNumber = new TextBox();
            lblNFeInitialNumber = new Label();
            txtNFeSerial = new TextBox();
            lblNFeSerial = new Label();
            txtNFeModel = new TextBox();
            lblNFeModel = new Label();
            txtVersionNFe = new TextBox();
            lblNFEVersion = new Label();
            tabDigitalCertificate = new TabPage();
            grbCertificateDigital = new GroupBox();
            txtPasswordCertificate = new TextBox();
            lbltxtPasswordCertificate = new Label();
            btnSelectCertificate = new FontAwesome.Sharp.IconButton();
            txtDigitalCertificate = new TextBox();
            lblDigitalCertificate = new Label();
            panel1 = new Panel();
            btnCancel = new FontAwesome.Sharp.IconButton();
            btnSave = new FontAwesome.Sharp.IconButton();
            chkCertificateA1 = new CheckBox();
            tabConfig.SuspendLayout();
            tabGeneral.SuspendLayout();
            groupBox1.SuspendLayout();
            tabNFCe.SuspendLayout();
            grbNFCe.SuspendLayout();
            tabPrinters.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrintSectors).BeginInit();
            tabNFe.SuspendLayout();
            grbNFe.SuspendLayout();
            tabDigitalCertificate.SuspendLayout();
            grbCertificateDigital.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tabConfig
            // 
            tabConfig.Controls.Add(tabGeneral);
            tabConfig.Controls.Add(tabNFCe);
            tabConfig.Controls.Add(tabPrinters);
            tabConfig.Controls.Add(tabNFe);
            tabConfig.Controls.Add(tabDigitalCertificate);
            tabConfig.Location = new Point(0, 4);
            tabConfig.Multiline = true;
            tabConfig.Name = "tabConfig";
            tabConfig.SelectedIndex = 0;
            tabConfig.Size = new Size(769, 351);
            tabConfig.TabIndex = 0;
            // 
            // tabGeneral
            // 
            tabGeneral.Controls.Add(groupBox1);
            tabGeneral.Location = new Point(4, 24);
            tabGeneral.Name = "tabGeneral";
            tabGeneral.Padding = new Padding(3);
            tabGeneral.Size = new Size(761, 323);
            tabGeneral.TabIndex = 0;
            tabGeneral.Text = "Informações Gerais";
            tabGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Control;
            groupBox1.Controls.Add(btnSelectBackupPath);
            groupBox1.Controls.Add(txtBackupPath);
            groupBox1.Controls.Add(lblBackupPath);
            groupBox1.Controls.Add(chkOrderPrint);
            groupBox1.Controls.Add(chkAutoCloseOrder);
            groupBox1.Controls.Add(chkSalesZeroStock);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(chkUseStockControl);
            groupBox1.Controls.Add(txtCashNumber);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(755, 317);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // btnSelectBackupPath
            // 
            btnSelectBackupPath.BackColor = Color.WhiteSmoke;
            btnSelectBackupPath.FlatAppearance.BorderColor = Color.LightGray;
            btnSelectBackupPath.FlatStyle = FlatStyle.Flat;
            btnSelectBackupPath.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            btnSelectBackupPath.IconColor = Color.Gray;
            btnSelectBackupPath.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSelectBackupPath.IconSize = 16;
            btnSelectBackupPath.ImageAlign = ContentAlignment.MiddleLeft;
            btnSelectBackupPath.Location = new Point(645, 139);
            btnSelectBackupPath.Name = "btnSelectBackupPath";
            btnSelectBackupPath.Size = new Size(103, 23);
            btnSelectBackupPath.TabIndex = 9;
            btnSelectBackupPath.Text = "    Selecionar...\n\n";
            btnSelectBackupPath.UseVisualStyleBackColor = false;
            btnSelectBackupPath.Click += btnSelectBackupPath_Click;
            // 
            // txtBackupPath
            // 
            txtBackupPath.Location = new Point(191, 139);
            txtBackupPath.Name = "txtBackupPath";
            txtBackupPath.ReadOnly = true;
            txtBackupPath.Size = new Size(450, 23);
            txtBackupPath.TabIndex = 8;
            // 
            // lblBackupPath
            // 
            lblBackupPath.AutoSize = true;
            lblBackupPath.Location = new Point(6, 142);
            lblBackupPath.Name = "lblBackupPath";
            lblBackupPath.Size = new Size(179, 15);
            lblBackupPath.TabIndex = 7;
            lblBackupPath.Text = "Caminho do backup automático";
            // 
            // chkOrderPrint
            // 
            chkOrderPrint.AutoSize = true;
            chkOrderPrint.Location = new Point(6, 120);
            chkOrderPrint.Name = "chkOrderPrint";
            chkOrderPrint.Size = new Size(112, 19);
            chkOrderPrint.TabIndex = 6;
            chkOrderPrint.Text = "Imprimir pedido";
            chkOrderPrint.UseVisualStyleBackColor = true;
            // 
            // chkAutoCloseOrder
            // 
            chkAutoCloseOrder.AutoSize = true;
            chkAutoCloseOrder.Location = new Point(6, 95);
            chkAutoCloseOrder.Name = "chkAutoCloseOrder";
            chkAutoCloseOrder.Size = new Size(198, 19);
            chkAutoCloseOrder.TabIndex = 5;
            chkAutoCloseOrder.Text = "Fechar pedido automaticamente";
            chkAutoCloseOrder.UseVisualStyleBackColor = true;
            // 
            // chkSalesZeroStock
            // 
            chkSalesZeroStock.AutoSize = true;
            chkSalesZeroStock.Location = new Point(6, 70);
            chkSalesZeroStock.Name = "chkSalesZeroStock";
            chkSalesZeroStock.Size = new Size(213, 19);
            chkSalesZeroStock.TabIndex = 4;
            chkSalesZeroStock.Text = "Permitir venda com estoque zerado\n";
            chkSalesZeroStock.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 3;
            label1.Text = "Número do Caixa";
            // 
            // chkUseStockControl
            // 
            chkUseStockControl.AutoSize = true;
            chkUseStockControl.Location = new Point(6, 45);
            chkUseStockControl.Name = "chkUseStockControl";
            chkUseStockControl.Size = new Size(159, 19);
            chkUseStockControl.TabIndex = 2;
            chkUseStockControl.Text = "Usar Controle de Estoque";
            chkUseStockControl.UseVisualStyleBackColor = true;
            // 
            // txtCashNumber
            // 
            txtCashNumber.Location = new Point(112, 16);
            txtCashNumber.Name = "txtCashNumber";
            txtCashNumber.PlaceholderText = "Número do Caixa";
            txtCashNumber.Size = new Size(100, 23);
            txtCashNumber.TabIndex = 0;
            txtCashNumber.KeyPress += txtCashNumber_KeyPress;
            // 
            // tabNFCe
            // 
            tabNFCe.Controls.Add(chkEnableNFCe);
            tabNFCe.Controls.Add(grbNFCe);
            tabNFCe.Location = new Point(4, 24);
            tabNFCe.Name = "tabNFCe";
            tabNFCe.Padding = new Padding(3);
            tabNFCe.Size = new Size(761, 323);
            tabNFCe.TabIndex = 1;
            tabNFCe.Text = "Configurações NFC-e";
            tabNFCe.UseVisualStyleBackColor = true;
            // 
            // chkEnableNFCe
            // 
            chkEnableNFCe.BackColor = SystemColors.Control;
            chkEnableNFCe.FlatStyle = FlatStyle.Flat;
            chkEnableNFCe.Location = new Point(8, 3);
            chkEnableNFCe.Name = "chkEnableNFCe";
            chkEnableNFCe.Size = new Size(166, 19);
            chkEnableNFCe.TabIndex = 37;
            chkEnableNFCe.Text = "Habilitar emissão de NF-e";
            chkEnableNFCe.UseVisualStyleBackColor = false;
            chkEnableNFCe.CheckedChanged += chkEnableNFCe_CheckedChanged;
            // 
            // grbNFCe
            // 
            grbNFCe.BackColor = SystemColors.Control;
            grbNFCe.Controls.Add(cmbEnvironment);
            grbNFCe.Controls.Add(lblEnvironment);
            grbNFCe.Controls.Add(txtInitialNumber);
            grbNFCe.Controls.Add(lblInitialNumber);
            grbNFCe.Controls.Add(txtSerial);
            grbNFCe.Controls.Add(lblSerial);
            grbNFCe.Controls.Add(txtNFCEModel);
            grbNFCe.Controls.Add(lblModel);
            grbNFCe.Controls.Add(txtVersionDF);
            grbNFCe.Controls.Add(lblVersionDF);
            grbNFCe.Controls.Add(chkPrintNFCe);
            grbNFCe.Controls.Add(btnSelectXMLPath);
            grbNFCe.Controls.Add(txtXMLPath);
            grbNFCe.Controls.Add(lblXMLPath);
            grbNFCe.Controls.Add(cmbTypeEmission);
            grbNFCe.Controls.Add(lblTypeEmission);
            grbNFCe.Controls.Add(txtCSCId);
            grbNFCe.Controls.Add(lblCSCId);
            grbNFCe.Controls.Add(txtCSC);
            grbNFCe.Controls.Add(lblCSC);
            grbNFCe.Dock = DockStyle.Fill;
            grbNFCe.Location = new Point(3, 3);
            grbNFCe.Name = "grbNFCe";
            grbNFCe.Size = new Size(755, 317);
            grbNFCe.TabIndex = 0;
            grbNFCe.TabStop = false;
            // 
            // cmbEnvironment
            // 
            cmbEnvironment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEnvironment.FormattingEnabled = true;
            cmbEnvironment.Location = new Point(119, 65);
            cmbEnvironment.Name = "cmbEnvironment";
            cmbEnvironment.Size = new Size(504, 23);
            cmbEnvironment.TabIndex = 34;
            // 
            // lblEnvironment
            // 
            lblEnvironment.AutoSize = true;
            lblEnvironment.Location = new Point(5, 68);
            lblEnvironment.Name = "lblEnvironment";
            lblEnvironment.Size = new Size(59, 15);
            lblEnvironment.TabIndex = 33;
            lblEnvironment.Text = "Ambiente";
            // 
            // txtInitialNumber
            // 
            txtInitialNumber.Location = new Point(573, 36);
            txtInitialNumber.MaxLength = 5;
            txtInitialNumber.Name = "txtInitialNumber";
            txtInitialNumber.Size = new Size(50, 23);
            txtInitialNumber.TabIndex = 32;
            txtInitialNumber.TextAlign = HorizontalAlignment.Right;
            txtInitialNumber.KeyPress += txtInitialNumber_KeyPress;
            // 
            // lblInitialNumber
            // 
            lblInitialNumber.AutoSize = true;
            lblInitialNumber.Location = new Point(482, 39);
            lblInitialNumber.Name = "lblInitialNumber";
            lblInitialNumber.Size = new Size(85, 15);
            lblInitialNumber.TabIndex = 31;
            lblInitialNumber.Text = "Número Inicial";
            // 
            // txtSerial
            // 
            txtSerial.Location = new Point(426, 36);
            txtSerial.MaxLength = 5;
            txtSerial.Name = "txtSerial";
            txtSerial.Size = new Size(50, 23);
            txtSerial.TabIndex = 30;
            txtSerial.TextAlign = HorizontalAlignment.Right;
            txtSerial.KeyPress += txtSerial_KeyPress;
            // 
            // lblSerial
            // 
            lblSerial.AutoSize = true;
            lblSerial.Location = new Point(388, 39);
            lblSerial.Name = "lblSerial";
            lblSerial.Size = new Size(32, 15);
            lblSerial.TabIndex = 29;
            lblSerial.Text = "Série";
            // 
            // txtNFCEModel
            // 
            txtNFCEModel.Location = new Point(332, 36);
            txtNFCEModel.MaxLength = 5;
            txtNFCEModel.Name = "txtNFCEModel";
            txtNFCEModel.ReadOnly = true;
            txtNFCEModel.Size = new Size(50, 23);
            txtNFCEModel.TabIndex = 28;
            txtNFCEModel.Text = "65";
            txtNFCEModel.TextAlign = HorizontalAlignment.Right;
            // 
            // lblModel
            // 
            lblModel.AutoSize = true;
            lblModel.Location = new Point(278, 39);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(48, 15);
            lblModel.TabIndex = 27;
            lblModel.Text = "Modelo\t";
            // 
            // txtVersionDF
            // 
            txtVersionDF.Location = new Point(222, 36);
            txtVersionDF.MaxLength = 5;
            txtVersionDF.Name = "txtVersionDF";
            txtVersionDF.Size = new Size(50, 23);
            txtVersionDF.TabIndex = 26;
            txtVersionDF.Text = "4.00";
            txtVersionDF.TextAlign = HorizontalAlignment.Right;
            txtVersionDF.KeyPress += txtVersionDF_KeyPress;
            // 
            // lblVersionDF
            // 
            lblVersionDF.AutoSize = true;
            lblVersionDF.Location = new Point(119, 39);
            lblVersionDF.Name = "lblVersionDF";
            lblVersionDF.Size = new Size(97, 15);
            lblVersionDF.TabIndex = 25;
            lblVersionDF.Text = "Versão do Layout\t";
            // 
            // chkPrintNFCe
            // 
            chkPrintNFCe.FlatStyle = FlatStyle.Flat;
            chkPrintNFCe.Location = new Point(629, 35);
            chkPrintNFCe.Name = "chkPrintNFCe";
            chkPrintNFCe.Size = new Size(119, 19);
            chkPrintNFCe.TabIndex = 24;
            chkPrintNFCe.Text = "Imprimir NFC-e\n\n";
            chkPrintNFCe.UseVisualStyleBackColor = true;
            // 
            // btnSelectXMLPath
            // 
            btnSelectXMLPath.BackColor = Color.WhiteSmoke;
            btnSelectXMLPath.FlatAppearance.BorderColor = Color.LightGray;
            btnSelectXMLPath.FlatStyle = FlatStyle.Flat;
            btnSelectXMLPath.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            btnSelectXMLPath.IconColor = Color.Gray;
            btnSelectXMLPath.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSelectXMLPath.IconSize = 16;
            btnSelectXMLPath.ImageAlign = ContentAlignment.MiddleLeft;
            btnSelectXMLPath.Location = new Point(643, 180);
            btnSelectXMLPath.Name = "btnSelectXMLPath";
            btnSelectXMLPath.Size = new Size(103, 23);
            btnSelectXMLPath.TabIndex = 23;
            btnSelectXMLPath.Text = "    Selecionar...\n\n";
            btnSelectXMLPath.UseVisualStyleBackColor = false;
            btnSelectXMLPath.Click += btnSelectXMLPath_Click;
            // 
            // txtXMLPath
            // 
            txtXMLPath.Location = new Point(119, 181);
            txtXMLPath.Name = "txtXMLPath";
            txtXMLPath.ReadOnly = true;
            txtXMLPath.Size = new Size(504, 23);
            txtXMLPath.TabIndex = 22;
            // 
            // lblXMLPath
            // 
            lblXMLPath.AutoSize = true;
            lblXMLPath.Location = new Point(5, 184);
            lblXMLPath.Name = "lblXMLPath";
            lblXMLPath.Size = new Size(83, 15);
            lblXMLPath.TabIndex = 21;
            lblXMLPath.Text = "Caminho XML";
            // 
            // cmbTypeEmission
            // 
            cmbTypeEmission.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTypeEmission.FormattingEnabled = true;
            cmbTypeEmission.Location = new Point(119, 152);
            cmbTypeEmission.Name = "cmbTypeEmission";
            cmbTypeEmission.Size = new Size(504, 23);
            cmbTypeEmission.TabIndex = 20;
            // 
            // lblTypeEmission
            // 
            lblTypeEmission.AutoSize = true;
            lblTypeEmission.Location = new Point(5, 155);
            lblTypeEmission.Name = "lblTypeEmission";
            lblTypeEmission.Size = new Size(92, 15);
            lblTypeEmission.TabIndex = 19;
            lblTypeEmission.Text = "Tipo de Emissão";
            // 
            // txtCSCId
            // 
            txtCSCId.Location = new Point(119, 123);
            txtCSCId.Name = "txtCSCId";
            txtCSCId.Size = new Size(504, 23);
            txtCSCId.TabIndex = 18;
            // 
            // lblCSCId
            // 
            lblCSCId.AutoSize = true;
            lblCSCId.Location = new Point(5, 126);
            lblCSCId.Name = "lblCSCId";
            lblCSCId.Size = new Size(43, 15);
            lblCSCId.TabIndex = 17;
            lblCSCId.Text = "CSC ID";
            // 
            // txtCSC
            // 
            txtCSC.Location = new Point(119, 94);
            txtCSC.Name = "txtCSC";
            txtCSC.Size = new Size(504, 23);
            txtCSC.TabIndex = 16;
            // 
            // lblCSC
            // 
            lblCSC.AutoSize = true;
            lblCSC.Location = new Point(5, 97);
            lblCSC.Name = "lblCSC";
            lblCSC.Size = new Size(71, 15);
            lblCSC.TabIndex = 15;
            lblCSC.Text = "Código CSC";
            // 
            // tabPrinters
            // 
            tabPrinters.Controls.Add(groupBox3);
            tabPrinters.Location = new Point(4, 24);
            tabPrinters.Name = "tabPrinters";
            tabPrinters.Padding = new Padding(3);
            tabPrinters.Size = new Size(761, 323);
            tabPrinters.TabIndex = 2;
            tabPrinters.Text = "Impressoras ";
            tabPrinters.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = SystemColors.Control;
            groupBox3.Controls.Add(btnAddSector);
            groupBox3.Controls.Add(dgvPrintSectors);
            groupBox3.Controls.Add(chkPrinterSector);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(755, 317);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = " ";
            // 
            // btnAddSector
            // 
            btnAddSector.BackColor = Color.WhiteSmoke;
            btnAddSector.FlatAppearance.BorderColor = Color.LightGray;
            btnAddSector.FlatStyle = FlatStyle.Flat;
            btnAddSector.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddSector.ForeColor = Color.ForestGreen;
            btnAddSector.IconChar = FontAwesome.Sharp.IconChar.None;
            btnAddSector.IconColor = Color.Black;
            btnAddSector.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddSector.IconSize = 16;
            btnAddSector.Location = new Point(718, 29);
            btnAddSector.Name = "btnAddSector";
            btnAddSector.Size = new Size(30, 30);
            btnAddSector.TabIndex = 2;
            btnAddSector.Text = "+";
            btnAddSector.UseVisualStyleBackColor = false;
            btnAddSector.Visible = false;
            btnAddSector.Click += btnAddSector_Click;
            // 
            // dgvPrintSectors
            // 
            dgvPrintSectors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrintSectors.Location = new Point(5, 65);
            dgvPrintSectors.Name = "dgvPrintSectors";
            dgvPrintSectors.RowHeadersVisible = false;
            dgvPrintSectors.Size = new Size(744, 246);
            dgvPrintSectors.TabIndex = 1;
            dgvPrintSectors.Visible = false;
            dgvPrintSectors.CellContentClick += dgvPrintSectors_CellContentClick;
            dgvPrintSectors.CellEndEdit += dgvPrintSectors_CellEndEdit;
            dgvPrintSectors.CellValueChanged += dgvPrintSectors_CellValueChanged;
            dgvPrintSectors.CurrentCellDirtyStateChanged += dgvPrintSectors_CurrentCellDirtyStateChanged;
            // 
            // chkPrinterSector
            // 
            chkPrinterSector.AutoSize = true;
            chkPrinterSector.Location = new Point(6, 22);
            chkPrinterSector.Name = "chkPrinterSector";
            chkPrinterSector.Size = new Size(168, 19);
            chkPrinterSector.TabIndex = 0;
            chkPrinterSector.Text = "Imprime em outros setores";
            chkPrinterSector.UseVisualStyleBackColor = true;
            chkPrinterSector.CheckedChanged += chkPrinterSector_CheckedChanged;
            // 
            // tabNFe
            // 
            tabNFe.Controls.Add(chkEnableNFe);
            tabNFe.Controls.Add(grbNFe);
            tabNFe.Location = new Point(4, 24);
            tabNFe.Name = "tabNFe";
            tabNFe.Padding = new Padding(3);
            tabNFe.Size = new Size(761, 323);
            tabNFe.TabIndex = 3;
            tabNFe.Text = "NF-e";
            tabNFe.UseVisualStyleBackColor = true;
            // 
            // chkEnableNFe
            // 
            chkEnableNFe.BackColor = SystemColors.Control;
            chkEnableNFe.FlatStyle = FlatStyle.Flat;
            chkEnableNFe.Location = new Point(9, 6);
            chkEnableNFe.Name = "chkEnableNFe";
            chkEnableNFe.Size = new Size(166, 19);
            chkEnableNFe.TabIndex = 26;
            chkEnableNFe.Text = "Habilitar emissão de NF-e";
            chkEnableNFe.UseVisualStyleBackColor = false;
            chkEnableNFe.CheckedChanged += chkEnableNFe_CheckedChanged;
            // 
            // grbNFe
            // 
            grbNFe.BackColor = SystemColors.Control;
            grbNFe.Controls.Add(cmbNFePayment);
            grbNFe.Controls.Add(lblNFePayment);
            grbNFe.Controls.Add(cmbNFePresence);
            grbNFe.Controls.Add(lblNFePresence);
            grbNFe.Controls.Add(cmbNFeFinality);
            grbNFe.Controls.Add(lblNFeFinality);
            grbNFe.Controls.Add(txtNFeEmail);
            grbNFe.Controls.Add(lblNFeEmail);
            grbNFe.Controls.Add(chkNFeSavePDF);
            grbNFe.Controls.Add(chkNFePrint);
            grbNFe.Controls.Add(btnXMLPathNFe);
            grbNFe.Controls.Add(txtNFeXmlPath);
            grbNFe.Controls.Add(lblNFeXmlPath);
            grbNFe.Controls.Add(cmbNFeEnvironment);
            grbNFe.Controls.Add(lblNFeEnvironment);
            grbNFe.Controls.Add(txtNFeInitialNumber);
            grbNFe.Controls.Add(lblNFeInitialNumber);
            grbNFe.Controls.Add(txtNFeSerial);
            grbNFe.Controls.Add(lblNFeSerial);
            grbNFe.Controls.Add(txtNFeModel);
            grbNFe.Controls.Add(lblNFeModel);
            grbNFe.Controls.Add(txtVersionNFe);
            grbNFe.Controls.Add(lblNFEVersion);
            grbNFe.Dock = DockStyle.Fill;
            grbNFe.Location = new Point(3, 3);
            grbNFe.Name = "grbNFe";
            grbNFe.Size = new Size(755, 317);
            grbNFe.TabIndex = 0;
            grbNFe.TabStop = false;
            // 
            // cmbNFePayment
            // 
            cmbNFePayment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNFePayment.FormattingEnabled = true;
            cmbNFePayment.Location = new Point(130, 221);
            cmbNFePayment.Name = "cmbNFePayment";
            cmbNFePayment.Size = new Size(401, 23);
            cmbNFePayment.TabIndex = 48;
            // 
            // lblNFePayment
            // 
            lblNFePayment.AutoSize = true;
            lblNFePayment.Location = new Point(6, 224);
            lblNFePayment.Name = "lblNFePayment";
            lblNFePayment.Size = new Size(121, 15);
            lblNFePayment.TabIndex = 47;
            lblNFePayment.Text = "Forma de Pagamento";
            // 
            // cmbNFePresence
            // 
            cmbNFePresence.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNFePresence.FormattingEnabled = true;
            cmbNFePresence.Location = new Point(130, 192);
            cmbNFePresence.Name = "cmbNFePresence";
            cmbNFePresence.Size = new Size(401, 23);
            cmbNFePresence.TabIndex = 46;
            // 
            // lblNFePresence
            // 
            lblNFePresence.AutoSize = true;
            lblNFePresence.Location = new Point(6, 195);
            lblNFePresence.Name = "lblNFePresence";
            lblNFePresence.Size = new Size(123, 15);
            lblNFePresence.TabIndex = 45;
            lblNFePresence.Text = "Indicador de Presença";
            // 
            // cmbNFeFinality
            // 
            cmbNFeFinality.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNFeFinality.FormattingEnabled = true;
            cmbNFeFinality.Location = new Point(130, 163);
            cmbNFeFinality.Name = "cmbNFeFinality";
            cmbNFeFinality.Size = new Size(401, 23);
            cmbNFeFinality.TabIndex = 44;
            // 
            // lblNFeFinality
            // 
            lblNFeFinality.AutoSize = true;
            lblNFeFinality.Location = new Point(6, 166);
            lblNFeFinality.Name = "lblNFeFinality";
            lblNFeFinality.Size = new Size(61, 15);
            lblNFeFinality.TabIndex = 43;
            lblNFeFinality.Text = "Finalidade";
            // 
            // txtNFeEmail
            // 
            txtNFeEmail.Location = new Point(130, 134);
            txtNFeEmail.Name = "txtNFeEmail";
            txtNFeEmail.Size = new Size(401, 23);
            txtNFeEmail.TabIndex = 42;
            // 
            // lblNFeEmail
            // 
            lblNFeEmail.AutoSize = true;
            lblNFeEmail.Location = new Point(6, 137);
            lblNFeEmail.Name = "lblNFeEmail";
            lblNFeEmail.Size = new Size(107, 15);
            lblNFeEmail.TabIndex = 41;
            lblNFeEmail.Text = "E-mail Destinatário";
            // 
            // chkNFeSavePDF
            // 
            chkNFeSavePDF.FlatStyle = FlatStyle.Flat;
            chkNFeSavePDF.Location = new Point(130, 115);
            chkNFeSavePDF.Name = "chkNFeSavePDF";
            chkNFeSavePDF.Size = new Size(184, 19);
            chkNFeSavePDF.TabIndex = 40;
            chkNFeSavePDF.Text = "Salvar PDF automaticamente";
            chkNFeSavePDF.UseVisualStyleBackColor = true;
            // 
            // chkNFePrint
            // 
            chkNFePrint.FlatStyle = FlatStyle.Flat;
            chkNFePrint.Location = new Point(6, 115);
            chkNFePrint.Name = "chkNFePrint";
            chkNFePrint.Size = new Size(119, 19);
            chkNFePrint.TabIndex = 39;
            chkNFePrint.Text = "Imprimir NF-e";
            chkNFePrint.UseVisualStyleBackColor = true;
            // 
            // btnXMLPathNFe
            // 
            btnXMLPathNFe.BackColor = Color.WhiteSmoke;
            btnXMLPathNFe.FlatAppearance.BorderColor = Color.LightGray;
            btnXMLPathNFe.FlatStyle = FlatStyle.Flat;
            btnXMLPathNFe.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            btnXMLPathNFe.IconColor = Color.Gray;
            btnXMLPathNFe.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnXMLPathNFe.IconSize = 16;
            btnXMLPathNFe.ImageAlign = ContentAlignment.MiddleLeft;
            btnXMLPathNFe.Location = new Point(526, 85);
            btnXMLPathNFe.Name = "btnXMLPathNFe";
            btnXMLPathNFe.Size = new Size(103, 23);
            btnXMLPathNFe.TabIndex = 38;
            btnXMLPathNFe.Text = "    Selecionar...\n\n";
            btnXMLPathNFe.UseVisualStyleBackColor = false;
            btnXMLPathNFe.Click += btnXMLPathNFe_Click;
            // 
            // txtNFeXmlPath
            // 
            txtNFeXmlPath.Location = new Point(94, 86);
            txtNFeXmlPath.Name = "txtNFeXmlPath";
            txtNFeXmlPath.ReadOnly = true;
            txtNFeXmlPath.Size = new Size(426, 23);
            txtNFeXmlPath.TabIndex = 37;
            // 
            // lblNFeXmlPath
            // 
            lblNFeXmlPath.AutoSize = true;
            lblNFeXmlPath.Location = new Point(6, 89);
            lblNFeXmlPath.Name = "lblNFeXmlPath";
            lblNFeXmlPath.Size = new Size(83, 15);
            lblNFeXmlPath.TabIndex = 36;
            lblNFeXmlPath.Text = "Caminho XML";
            // 
            // cmbNFeEnvironment
            // 
            cmbNFeEnvironment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNFeEnvironment.FormattingEnabled = true;
            cmbNFeEnvironment.Location = new Point(94, 57);
            cmbNFeEnvironment.Name = "cmbNFeEnvironment";
            cmbNFeEnvironment.Size = new Size(426, 23);
            cmbNFeEnvironment.TabIndex = 35;
            // 
            // lblNFeEnvironment
            // 
            lblNFeEnvironment.AutoSize = true;
            lblNFeEnvironment.Location = new Point(6, 60);
            lblNFeEnvironment.Name = "lblNFeEnvironment";
            lblNFeEnvironment.Size = new Size(59, 15);
            lblNFeEnvironment.TabIndex = 34;
            lblNFeEnvironment.Text = "Ambiente";
            // 
            // txtNFeInitialNumber
            // 
            txtNFeInitialNumber.Location = new Point(529, 28);
            txtNFeInitialNumber.Name = "txtNFeInitialNumber";
            txtNFeInitialNumber.Size = new Size(100, 23);
            txtNFeInitialNumber.TabIndex = 33;
            txtNFeInitialNumber.TextAlign = HorizontalAlignment.Right;
            txtNFeInitialNumber.KeyPress += txtNFeInitialNumber_KeyPress;
            // 
            // lblNFeInitialNumber
            // 
            lblNFeInitialNumber.AutoSize = true;
            lblNFeInitialNumber.Location = new Point(444, 31);
            lblNFeInitialNumber.Name = "lblNFeInitialNumber";
            lblNFeInitialNumber.Size = new Size(85, 15);
            lblNFeInitialNumber.TabIndex = 32;
            lblNFeInitialNumber.Text = "Número Inicial";
            // 
            // txtNFeSerial
            // 
            txtNFeSerial.Location = new Point(358, 28);
            txtNFeSerial.Name = "txtNFeSerial";
            txtNFeSerial.Size = new Size(80, 23);
            txtNFeSerial.TabIndex = 31;
            txtNFeSerial.TextAlign = HorizontalAlignment.Right;
            txtNFeSerial.KeyPress += txtNFeSerial_KeyPress;
            // 
            // lblNFeSerial
            // 
            lblNFeSerial.AutoSize = true;
            lblNFeSerial.Location = new Point(320, 31);
            lblNFeSerial.Name = "lblNFeSerial";
            lblNFeSerial.Size = new Size(32, 15);
            lblNFeSerial.TabIndex = 30;
            lblNFeSerial.Text = "Série";
            // 
            // txtNFeModel
            // 
            txtNFeModel.Location = new Point(234, 28);
            txtNFeModel.Name = "txtNFeModel";
            txtNFeModel.ReadOnly = true;
            txtNFeModel.Size = new Size(80, 23);
            txtNFeModel.TabIndex = 29;
            txtNFeModel.Text = "55";
            txtNFeModel.TextAlign = HorizontalAlignment.Right;
            txtNFeModel.KeyPress += txtNFeModel_KeyPress;
            // 
            // lblNFeModel
            // 
            lblNFeModel.AutoSize = true;
            lblNFeModel.Location = new Point(180, 31);
            lblNFeModel.Name = "lblNFeModel";
            lblNFeModel.Size = new Size(48, 15);
            lblNFeModel.TabIndex = 28;
            lblNFeModel.Text = "Modelo";
            // 
            // txtVersionNFe
            // 
            txtVersionNFe.Location = new Point(94, 28);
            txtVersionNFe.Name = "txtVersionNFe";
            txtVersionNFe.Size = new Size(80, 23);
            txtVersionNFe.TabIndex = 27;
            txtVersionNFe.TextAlign = HorizontalAlignment.Right;
            txtVersionNFe.KeyPress += txtVersionNFe_KeyPress;
            // 
            // lblNFEVersion
            // 
            lblNFEVersion.AutoSize = true;
            lblNFEVersion.Location = new Point(6, 31);
            lblNFEVersion.Name = "lblNFEVersion";
            lblNFEVersion.Size = new Size(68, 15);
            lblNFEVersion.TabIndex = 26;
            lblNFEVersion.Text = "Versão XML";
            // 
            // tabDigitalCertificate
            // 
            tabDigitalCertificate.Controls.Add(chkCertificateA1);
            tabDigitalCertificate.Controls.Add(grbCertificateDigital);
            tabDigitalCertificate.Location = new Point(4, 24);
            tabDigitalCertificate.Name = "tabDigitalCertificate";
            tabDigitalCertificate.Padding = new Padding(3);
            tabDigitalCertificate.Size = new Size(761, 323);
            tabDigitalCertificate.TabIndex = 4;
            tabDigitalCertificate.Text = "Certificado Digital";
            tabDigitalCertificate.UseVisualStyleBackColor = true;
            // 
            // grbCertificateDigital
            // 
            grbCertificateDigital.BackColor = SystemColors.Control;
            grbCertificateDigital.Controls.Add(txtPasswordCertificate);
            grbCertificateDigital.Controls.Add(lbltxtPasswordCertificate);
            grbCertificateDigital.Controls.Add(btnSelectCertificate);
            grbCertificateDigital.Controls.Add(txtDigitalCertificate);
            grbCertificateDigital.Controls.Add(lblDigitalCertificate);
            grbCertificateDigital.Dock = DockStyle.Fill;
            grbCertificateDigital.Location = new Point(3, 3);
            grbCertificateDigital.Name = "grbCertificateDigital";
            grbCertificateDigital.Size = new Size(755, 317);
            grbCertificateDigital.TabIndex = 0;
            grbCertificateDigital.TabStop = false;
            // 
            // txtPasswordCertificate
            // 
            txtPasswordCertificate.Location = new Point(131, 51);
            txtPasswordCertificate.Name = "txtPasswordCertificate";
            txtPasswordCertificate.Size = new Size(500, 23);
            txtPasswordCertificate.TabIndex = 19;
            txtPasswordCertificate.UseSystemPasswordChar = true;
            // 
            // lbltxtPasswordCertificate
            // 
            lbltxtPasswordCertificate.AutoSize = true;
            lbltxtPasswordCertificate.Location = new Point(7, 54);
            lbltxtPasswordCertificate.Name = "lbltxtPasswordCertificate";
            lbltxtPasswordCertificate.Size = new Size(117, 15);
            lbltxtPasswordCertificate.TabIndex = 18;
            lbltxtPasswordCertificate.Text = "Senha do Certificado";
            // 
            // btnSelectCertificate
            // 
            btnSelectCertificate.BackColor = Color.WhiteSmoke;
            btnSelectCertificate.FlatAppearance.BorderColor = Color.LightGray;
            btnSelectCertificate.FlatStyle = FlatStyle.Flat;
            btnSelectCertificate.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            btnSelectCertificate.IconColor = Color.Gray;
            btnSelectCertificate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSelectCertificate.IconSize = 16;
            btnSelectCertificate.ImageAlign = ContentAlignment.MiddleLeft;
            btnSelectCertificate.Location = new Point(645, 22);
            btnSelectCertificate.Name = "btnSelectCertificate";
            btnSelectCertificate.Size = new Size(103, 23);
            btnSelectCertificate.TabIndex = 17;
            btnSelectCertificate.Text = "    Selecionar...\n\n";
            btnSelectCertificate.UseVisualStyleBackColor = false;
            btnSelectCertificate.Click += btnSelectCertificate_Click;
            // 
            // txtDigitalCertificate
            // 
            txtDigitalCertificate.Location = new Point(131, 22);
            txtDigitalCertificate.Name = "txtDigitalCertificate";
            txtDigitalCertificate.ReadOnly = true;
            txtDigitalCertificate.Size = new Size(500, 23);
            txtDigitalCertificate.TabIndex = 16;
            // 
            // lblDigitalCertificate
            // 
            lblDigitalCertificate.AutoSize = true;
            lblDigitalCertificate.Location = new Point(7, 26);
            lblDigitalCertificate.Name = "lblDigitalCertificate";
            lblDigitalCertificate.Size = new Size(102, 15);
            lblDigitalCertificate.TabIndex = 15;
            lblDigitalCertificate.Text = "Certificado Digital";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnSave);
            panel1.Location = new Point(553, 357);
            panel1.Name = "panel1";
            panel1.Size = new Size(212, 41);
            panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.Control;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.Black;
            btnCancel.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            btnCancel.IconColor = Color.Tomato;
            btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancel.IconSize = 20;
            btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancel.Location = new Point(15, 9);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 23);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "     Cancelar";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.Control;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.Black;
            btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSave.IconColor = Color.ForestGreen;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSave.IconSize = 20;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(122, 9);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(80, 23);
            btnSave.TabIndex = 9;
            btnSave.Text = "   Salvar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // chkCertificateA1
            // 
            chkCertificateA1.AutoSize = true;
            chkCertificateA1.BackColor = SystemColors.Control;
            chkCertificateA1.FlatStyle = FlatStyle.Flat;
            chkCertificateA1.Location = new Point(8, 3);
            chkCertificateA1.Name = "chkCertificateA1";
            chkCertificateA1.Size = new Size(98, 19);
            chkCertificateA1.TabIndex = 21;
            chkCertificateA1.Text = "Certificado A1";
            chkCertificateA1.UseVisualStyleBackColor = false;
            chkCertificateA1.CheckedChanged += chkCertificateA1_CheckedChanged;
            // 
            // ConfigForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(768, 404);
            Controls.Add(panel1);
            Controls.Add(tabConfig);
            Name = "ConfigForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configurações do Sistema";
            Load += ConfigForm_Load;
            tabConfig.ResumeLayout(false);
            tabGeneral.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabNFCe.ResumeLayout(false);
            grbNFCe.ResumeLayout(false);
            grbNFCe.PerformLayout();
            tabPrinters.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrintSectors).EndInit();
            tabNFe.ResumeLayout(false);
            grbNFe.ResumeLayout(false);
            grbNFe.PerformLayout();
            tabDigitalCertificate.ResumeLayout(false);
            tabDigitalCertificate.PerformLayout();
            grbCertificateDigital.ResumeLayout(false);
            grbCertificateDigital.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabConfig;
        private TabPage tabGeneral;
        private TabPage tabNFCe;
        private GroupBox groupBox1;
        private CheckBox chkUseStockControl;
        private TextBox txtCashNumber;
        private CheckBox chkSalesZeroStock;
        private Label label1;
        private CheckBox chkAutoCloseOrder;
        private TextBox txtBackupPath;
        private Label lblBackupPath;
        private CheckBox chkOrderPrint;
        private FontAwesome.Sharp.IconButton btnSelectBackupPath;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnCancel;
        private FontAwesome.Sharp.IconButton btnSave;
        private GroupBox grbNFCe;
        private FontAwesome.Sharp.IconButton btnSelectXMLPath;
        private TextBox txtXMLPath;
        private Label lblXMLPath;
        private ComboBox cmbTypeEmission;
        private Label lblTypeEmission;
        private TextBox txtCSCId;
        private Label lblCSCId;
        private TextBox txtCSC;
        private Label lblCSC;
        private CheckBox chkPrintNFCe;
        private TabPage tabPrinters;
        private GroupBox groupBox3;
        private CheckBox chkPrinterSector;
        private DataGridView dgvPrintSectors;
        private FontAwesome.Sharp.IconButton btnAddSector;
        private TabPage tabNFe;
        private GroupBox grbNFe;
        private Label lblVersionDF;
        private TabPage tabDigitalCertificate;
        private GroupBox grbCertificateDigital;
        private TextBox txtPasswordCertificate;
        private Label lbltxtPasswordCertificate;
        private FontAwesome.Sharp.IconButton btnSelectCertificate;
        private TextBox txtDigitalCertificate;
        private Label lblDigitalCertificate;
        private TextBox txtVersionDF;
        private Label lblModel;
        private TextBox txtNFCEModel;
        private Label lblSerial;
        private TextBox txtSerial;
        private Label lblInitialNumber;
        private TextBox txtInitialNumber;
        private ComboBox cmbEnvironment;
        private Label lblEnvironment;
        private Label lblNFEVersion;
        private Label lblNFeSerial;
        private TextBox txtNFeModel;
        private Label lblNFeModel;
        private TextBox txtVersionNFe;
        private Label lblNFeXmlPath;
        private ComboBox cmbNFeEnvironment;
        private Label lblNFeEnvironment;
        private TextBox txtNFeInitialNumber;
        private Label lblNFeInitialNumber;
        private TextBox txtNFeSerial;
        private CheckBox chkNFePrint;
        private FontAwesome.Sharp.IconButton btnXMLPathNFe;
        private TextBox txtNFeXmlPath;
        private Label lblNFePresence;
        private ComboBox cmbNFeFinality;
        private Label lblNFeFinality;
        private TextBox txtNFeEmail;
        private Label lblNFeEmail;
        private CheckBox chkNFeSavePDF;
        private ComboBox cmbNFePayment;
        private Label lblNFePayment;
        private ComboBox cmbNFePresence;
        private CheckBox chkEnableNFCe;
        private CheckBox chkEnableNFe;
        private CheckBox chkCertificateA1;
    }
}