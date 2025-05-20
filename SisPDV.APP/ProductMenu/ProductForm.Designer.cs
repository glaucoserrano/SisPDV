namespace SisPDV.APP.ProductMenu
{
    partial class ProductForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabRegister, tabList;
        private System.Windows.Forms.GroupBox gbGeneral, gbImage;
        private System.Windows.Forms.PictureBox pbProductImage;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tabRegister = new TabPage();
            groupBox1 = new GroupBox();
            textBox1 = new TextBox();
            lblNotes = new Label();
            chkService = new CheckBox();
            chkFractional = new CheckBox();
            chkWeighing = new CheckBox();
            gbPrinters = new GroupBox();
            chkAutoPrint = new CheckBox();
            chkShowInOrder = new CheckBox();
            cmbPrintSector = new ComboBox();
            lblPrintSector = new Label();
            chkPrintersSector = new CheckBox();
            btnClean = new FontAwesome.Sharp.IconButton();
            btnSave = new FontAwesome.Sharp.IconButton();
            gbFiscalPricing = new GroupBox();
            cmbCFOP = new ComboBox();
            lblCFOP = new Label();
            txtCEST = new TextBox();
            lblCEST = new Label();
            txtNCM = new TextBox();
            lblNCM = new Label();
            cmbCSTCSOSN = new ComboBox();
            lblCSTCSOSN = new Label();
            txtSalePrice = new TextBox();
            lblSalePrice = new Label();
            txtProfitMargin = new TextBox();
            lblProfitMargin = new Label();
            txtCostPrice = new TextBox();
            lblCostPrice = new Label();
            gbStock = new GroupBox();
            txtLocation = new TextBox();
            chkAllowZeroStockSale = new CheckBox();
            chkStockControlled = new CheckBox();
            txtMaxStock = new TextBox();
            txtMinStock = new TextBox();
            txtStock = new TextBox();
            lblLocation = new Label();
            lblMaxStock = new Label();
            lblMinStock = new Label();
            lblStock = new Label();
            gbGeneral = new GroupBox();
            txtProductId = new TextBox();
            chkAticve = new CheckBox();
            cmbUnity = new ComboBox();
            lblUnity = new Label();
            cmbCategory = new ComboBox();
            lblCategory = new Label();
            txtRefSupplier = new TextBox();
            lblRefSupplier = new Label();
            txtDescricao = new TextBox();
            lblDescricao = new Label();
            txtBarCode = new TextBox();
            lblBarCode = new Label();
            lblProductId = new Label();
            cmbProductType = new ComboBox();
            lblProductType = new Label();
            gbImage = new GroupBox();
            btnAddImage = new FontAwesome.Sharp.IconButton();
            pbProductImage = new PictureBox();
            tabList = new TabPage();
            tabControl.SuspendLayout();
            tabRegister.SuspendLayout();
            groupBox1.SuspendLayout();
            gbPrinters.SuspendLayout();
            gbFiscalPricing.SuspendLayout();
            gbStock.SuspendLayout();
            gbGeneral.SuspendLayout();
            gbImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbProductImage).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabRegister);
            tabControl.Controls.Add(tabList);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(900, 600);
            tabControl.TabIndex = 0;
            // 
            // tabRegister
            // 
            tabRegister.BackColor = SystemColors.Control;
            tabRegister.Controls.Add(groupBox1);
            tabRegister.Controls.Add(gbPrinters);
            tabRegister.Controls.Add(btnClean);
            tabRegister.Controls.Add(btnSave);
            tabRegister.Controls.Add(gbFiscalPricing);
            tabRegister.Controls.Add(gbStock);
            tabRegister.Controls.Add(gbGeneral);
            tabRegister.Controls.Add(gbImage);
            tabRegister.Location = new Point(4, 24);
            tabRegister.Name = "tabRegister";
            tabRegister.Size = new Size(892, 572);
            tabRegister.TabIndex = 0;
            tabRegister.Text = "Cadastro";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(lblNotes);
            groupBox1.Controls.Add(chkService);
            groupBox1.Controls.Add(chkFractional);
            groupBox1.Controls.Add(chkWeighing);
            groupBox1.Location = new Point(20, 438);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(864, 102);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Outras";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(20, 55);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(840, 40);
            textBox1.TabIndex = 27;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(20, 40);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(74, 15);
            lblNotes.TabIndex = 26;
            lblNotes.Text = "Observações";
            // 
            // chkService
            // 
            chkService.AutoSize = true;
            chkService.Location = new Point(320, 20);
            chkService.Name = "chkService";
            chkService.Size = new Size(64, 19);
            chkService.TabIndex = 25;
            chkService.Text = "Serviço";
            chkService.UseVisualStyleBackColor = true;
            // 
            // chkFractional
            // 
            chkFractional.AutoSize = true;
            chkFractional.Location = new Point(150, 20);
            chkFractional.Name = "chkFractional";
            chkFractional.Size = new Size(161, 19);
            chkFractional.TabIndex = 24;
            chkFractional.Text = "Permite venda fracionada";
            chkFractional.UseVisualStyleBackColor = true;
            // 
            // chkWeighing
            // 
            chkWeighing.AutoSize = true;
            chkWeighing.Location = new Point(10, 20);
            chkWeighing.Name = "chkWeighing";
            chkWeighing.Size = new Size(118, 19);
            chkWeighing.TabIndex = 23;
            chkWeighing.Text = "Vendido por Peso";
            chkWeighing.UseVisualStyleBackColor = true;
            // 
            // gbPrinters
            // 
            gbPrinters.Controls.Add(chkAutoPrint);
            gbPrinters.Controls.Add(chkShowInOrder);
            gbPrinters.Controls.Add(cmbPrintSector);
            gbPrinters.Controls.Add(lblPrintSector);
            gbPrinters.Controls.Add(chkPrintersSector);
            gbPrinters.Location = new Point(20, 356);
            gbPrinters.Name = "gbPrinters";
            gbPrinters.Size = new Size(864, 76);
            gbPrinters.TabIndex = 13;
            gbPrinters.TabStop = false;
            gbPrinters.Text = "Impressoras";
            // 
            // chkAutoPrint
            // 
            chkAutoPrint.AutoSize = true;
            chkAutoPrint.Location = new Point(678, 29);
            chkAutoPrint.Name = "chkAutoPrint";
            chkAutoPrint.Size = new Size(171, 19);
            chkAutoPrint.TabIndex = 33;
            chkAutoPrint.Text = "Imprimir Automaticamente";
            chkAutoPrint.UseVisualStyleBackColor = true;
            // 
            // chkShowInOrder
            // 
            chkShowInOrder.AutoSize = true;
            chkShowInOrder.Location = new Point(535, 29);
            chkShowInOrder.Name = "chkShowInOrder";
            chkShowInOrder.Size = new Size(127, 19);
            chkShowInOrder.TabIndex = 32;
            chkShowInOrder.Text = "Mostrar em pedido";
            chkShowInOrder.UseVisualStyleBackColor = true;
            // 
            // cmbPrintSector
            // 
            cmbPrintSector.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPrintSector.FormattingEnabled = true;
            cmbPrintSector.Location = new Point(270, 28);
            cmbPrintSector.Name = "cmbPrintSector";
            cmbPrintSector.Size = new Size(250, 23);
            cmbPrintSector.TabIndex = 31;
            // 
            // lblPrintSector
            // 
            lblPrintSector.AutoSize = true;
            lblPrintSector.Location = new Point(157, 31);
            lblPrintSector.Name = "lblPrintSector";
            lblPrintSector.Size = new Size(107, 15);
            lblPrintSector.TabIndex = 23;
            lblPrintSector.Text = "Setor de Impressão";
            // 
            // chkPrintersSector
            // 
            chkPrintersSector.AutoSize = true;
            chkPrintersSector.Location = new Point(6, 30);
            chkPrintersSector.Name = "chkPrintersSector";
            chkPrintersSector.Size = new Size(145, 19);
            chkPrintersSector.TabIndex = 22;
            chkPrintersSector.Text = "Impressora em Setores";
            chkPrintersSector.UseVisualStyleBackColor = true;
            chkPrintersSector.CheckedChanged += chkPrintersSector_CheckedChanged;
            // 
            // btnClean
            // 
            btnClean.BackColor = SystemColors.Control;
            btnClean.FlatStyle = FlatStyle.Flat;
            btnClean.ForeColor = Color.Black;
            btnClean.IconChar = FontAwesome.Sharp.IconChar.Eraser;
            btnClean.IconColor = Color.Tomato;
            btnClean.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClean.IconSize = 20;
            btnClean.ImageAlign = ContentAlignment.MiddleLeft;
            btnClean.Location = new Point(724, 546);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(75, 23);
            btnClean.TabIndex = 12;
            btnClean.Text = "   Limpar";
            btnClean.UseVisualStyleBackColor = false;
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
            btnSave.Location = new Point(805, 546);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 11;
            btnSave.Text = "   Salvar";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // gbFiscalPricing
            // 
            gbFiscalPricing.Controls.Add(cmbCFOP);
            gbFiscalPricing.Controls.Add(lblCFOP);
            gbFiscalPricing.Controls.Add(txtCEST);
            gbFiscalPricing.Controls.Add(lblCEST);
            gbFiscalPricing.Controls.Add(txtNCM);
            gbFiscalPricing.Controls.Add(lblNCM);
            gbFiscalPricing.Controls.Add(cmbCSTCSOSN);
            gbFiscalPricing.Controls.Add(lblCSTCSOSN);
            gbFiscalPricing.Controls.Add(txtSalePrice);
            gbFiscalPricing.Controls.Add(lblSalePrice);
            gbFiscalPricing.Controls.Add(txtProfitMargin);
            gbFiscalPricing.Controls.Add(lblProfitMargin);
            gbFiscalPricing.Controls.Add(txtCostPrice);
            gbFiscalPricing.Controls.Add(lblCostPrice);
            gbFiscalPricing.Location = new Point(20, 274);
            gbFiscalPricing.Name = "gbFiscalPricing";
            gbFiscalPricing.Size = new Size(864, 76);
            gbFiscalPricing.TabIndex = 3;
            gbFiscalPricing.TabStop = false;
            gbFiscalPricing.Text = "Fiscal e Preços";
            // 
            // cmbCFOP
            // 
            cmbCFOP.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCFOP.FormattingEnabled = true;
            cmbCFOP.Location = new Point(618, 37);
            cmbCFOP.Name = "cmbCFOP";
            cmbCFOP.Size = new Size(231, 23);
            cmbCFOP.TabIndex = 30;
            // 
            // lblCFOP
            // 
            lblCFOP.AutoSize = true;
            lblCFOP.Location = new Point(618, 19);
            lblCFOP.Name = "lblCFOP";
            lblCFOP.Size = new Size(37, 15);
            lblCFOP.TabIndex = 29;
            lblCFOP.Text = "CFOP";
            // 
            // txtCEST
            // 
            txtCEST.Location = new Point(524, 37);
            txtCEST.Name = "txtCEST";
            txtCEST.Size = new Size(80, 23);
            txtCEST.TabIndex = 28;
            // 
            // lblCEST
            // 
            lblCEST.AutoSize = true;
            lblCEST.Location = new Point(524, 19);
            lblCEST.Name = "lblCEST";
            lblCEST.Size = new Size(75, 15);
            lblCEST.TabIndex = 27;
            lblCEST.Text = "Código CEST";
            // 
            // txtNCM
            // 
            txtNCM.Location = new Point(438, 37);
            txtNCM.Name = "txtNCM";
            txtNCM.Size = new Size(80, 23);
            txtNCM.TabIndex = 26;
            // 
            // lblNCM
            // 
            lblNCM.AutoSize = true;
            lblNCM.Location = new Point(438, 19);
            lblNCM.Name = "lblNCM";
            lblNCM.Size = new Size(35, 15);
            lblNCM.TabIndex = 25;
            lblNCM.Text = "NCM";
            // 
            // cmbCSTCSOSN
            // 
            cmbCSTCSOSN.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCSTCSOSN.FormattingEnabled = true;
            cmbCSTCSOSN.Location = new Point(332, 37);
            cmbCSTCSOSN.Name = "cmbCSTCSOSN";
            cmbCSTCSOSN.Size = new Size(100, 23);
            cmbCSTCSOSN.TabIndex = 24;
            // 
            // lblCSTCSOSN
            // 
            lblCSTCSOSN.AutoSize = true;
            lblCSTCSOSN.Location = new Point(332, 19);
            lblCSTCSOSN.Name = "lblCSTCSOSN";
            lblCSTCSOSN.Size = new Size(70, 15);
            lblCSTCSOSN.TabIndex = 23;
            lblCSTCSOSN.Text = "CST/CSOSN";
            // 
            // txtSalePrice
            // 
            txtSalePrice.Location = new Point(218, 37);
            txtSalePrice.Name = "txtSalePrice";
            txtSalePrice.Size = new Size(100, 23);
            txtSalePrice.TabIndex = 22;
            // 
            // lblSalePrice
            // 
            lblSalePrice.AutoSize = true;
            lblSalePrice.Location = new Point(218, 19);
            lblSalePrice.Name = "lblSalePrice";
            lblSalePrice.Size = new Size(88, 15);
            lblSalePrice.TabIndex = 21;
            lblSalePrice.Text = "Preço de venda";
            // 
            // txtProfitMargin
            // 
            txtProfitMargin.Location = new Point(120, 37);
            txtProfitMargin.Name = "txtProfitMargin";
            txtProfitMargin.Size = new Size(80, 23);
            txtProfitMargin.TabIndex = 20;
            // 
            // lblProfitMargin
            // 
            lblProfitMargin.AutoSize = true;
            lblProfitMargin.Location = new Point(120, 19);
            lblProfitMargin.Name = "lblProfitMargin";
            lblProfitMargin.Size = new Size(58, 15);
            lblProfitMargin.TabIndex = 19;
            lblProfitMargin.Text = "Lucro (%)";
            // 
            // txtCostPrice
            // 
            txtCostPrice.Location = new Point(6, 37);
            txtCostPrice.Name = "txtCostPrice";
            txtCostPrice.Size = new Size(100, 23);
            txtCostPrice.TabIndex = 18;
            // 
            // lblCostPrice
            // 
            lblCostPrice.AutoSize = true;
            lblCostPrice.Location = new Point(10, 19);
            lblCostPrice.Name = "lblCostPrice";
            lblCostPrice.Size = new Size(87, 15);
            lblCostPrice.TabIndex = 14;
            lblCostPrice.Text = "Preço de Custo";
            // 
            // gbStock
            // 
            gbStock.Controls.Add(txtLocation);
            gbStock.Controls.Add(chkAllowZeroStockSale);
            gbStock.Controls.Add(chkStockControlled);
            gbStock.Controls.Add(txtMaxStock);
            gbStock.Controls.Add(txtMinStock);
            gbStock.Controls.Add(txtStock);
            gbStock.Controls.Add(lblLocation);
            gbStock.Controls.Add(lblMaxStock);
            gbStock.Controls.Add(lblMinStock);
            gbStock.Controls.Add(lblStock);
            gbStock.Location = new Point(20, 192);
            gbStock.Name = "gbStock";
            gbStock.Size = new Size(864, 76);
            gbStock.TabIndex = 2;
            gbStock.TabStop = false;
            gbStock.Text = "Estoque";
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(760, 35);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(100, 23);
            txtLocation.TabIndex = 23;
            // 
            // chkAllowZeroStockSale
            // 
            chkAllowZeroStockSale.AutoSize = true;
            chkAllowZeroStockSale.Location = new Point(530, 39);
            chkAllowZeroStockSale.Name = "chkAllowZeroStockSale";
            chkAllowZeroStockSale.Size = new Size(214, 19);
            chkAllowZeroStockSale.TabIndex = 22;
            chkAllowZeroStockSale.Text = "Permite Venda com Estoque Zerado";
            chkAllowZeroStockSale.UseVisualStyleBackColor = true;
            // 
            // chkStockControlled
            // 
            chkStockControlled.AutoSize = true;
            chkStockControlled.Location = new Point(340, 39);
            chkStockControlled.Name = "chkStockControlled";
            chkStockControlled.Size = new Size(133, 19);
            chkStockControlled.TabIndex = 21;
            chkStockControlled.Text = "Controle de Estoque";
            chkStockControlled.UseVisualStyleBackColor = true;
            // 
            // txtMaxStock
            // 
            txtMaxStock.Location = new Point(230, 37);
            txtMaxStock.Name = "txtMaxStock";
            txtMaxStock.Size = new Size(100, 23);
            txtMaxStock.TabIndex = 19;
            // 
            // txtMinStock
            // 
            txtMinStock.Location = new Point(120, 37);
            txtMinStock.Name = "txtMinStock";
            txtMinStock.Size = new Size(100, 23);
            txtMinStock.TabIndex = 18;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(6, 37);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(100, 23);
            txtStock.TabIndex = 17;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(760, 19);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(68, 15);
            lblLocation.TabIndex = 16;
            lblLocation.Text = "Localização";
            // 
            // lblMaxStock
            // 
            lblMaxStock.AutoSize = true;
            lblMaxStock.Location = new Point(230, 19);
            lblMaxStock.Name = "lblMaxStock";
            lblMaxStock.Size = new Size(96, 15);
            lblMaxStock.TabIndex = 15;
            lblMaxStock.Text = "Estoque Máximo";
            // 
            // lblMinStock
            // 
            lblMinStock.AutoSize = true;
            lblMinStock.Location = new Point(120, 19);
            lblMinStock.Name = "lblMinStock";
            lblMinStock.Size = new Size(94, 15);
            lblMinStock.TabIndex = 14;
            lblMinStock.Text = "Estoque Mínimo";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(10, 19);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(80, 15);
            lblStock.TabIndex = 13;
            lblStock.Text = "Estoque Atual";
            // 
            // gbGeneral
            // 
            gbGeneral.Controls.Add(txtProductId);
            gbGeneral.Controls.Add(chkAticve);
            gbGeneral.Controls.Add(cmbUnity);
            gbGeneral.Controls.Add(lblUnity);
            gbGeneral.Controls.Add(cmbCategory);
            gbGeneral.Controls.Add(lblCategory);
            gbGeneral.Controls.Add(txtRefSupplier);
            gbGeneral.Controls.Add(lblRefSupplier);
            gbGeneral.Controls.Add(txtDescricao);
            gbGeneral.Controls.Add(lblDescricao);
            gbGeneral.Controls.Add(txtBarCode);
            gbGeneral.Controls.Add(lblBarCode);
            gbGeneral.Controls.Add(lblProductId);
            gbGeneral.Controls.Add(cmbProductType);
            gbGeneral.Controls.Add(lblProductType);
            gbGeneral.Location = new Point(20, 20);
            gbGeneral.Name = "gbGeneral";
            gbGeneral.Size = new Size(728, 166);
            gbGeneral.TabIndex = 0;
            gbGeneral.TabStop = false;
            gbGeneral.Text = "Informações Gerais";
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(361, 16);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(102, 23);
            txtProductId.TabIndex = 21;
            // 
            // chkAticve
            // 
            chkAticve.AutoSize = true;
            chkAticve.Checked = true;
            chkAticve.CheckState = CheckState.Checked;
            chkAticve.Location = new Point(6, 121);
            chkAticve.Name = "chkAticve";
            chkAticve.Size = new Size(54, 19);
            chkAticve.TabIndex = 20;
            chkAticve.Text = "Ativo";
            chkAticve.UseVisualStyleBackColor = true;
            // 
            // cmbUnity
            // 
            cmbUnity.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUnity.FormattingEnabled = true;
            cmbUnity.Location = new Point(535, 88);
            cmbUnity.Name = "cmbUnity";
            cmbUnity.Size = new Size(187, 23);
            cmbUnity.TabIndex = 19;
            // 
            // lblUnity
            // 
            lblUnity.AutoSize = true;
            lblUnity.Location = new Point(476, 91);
            lblUnity.Name = "lblUnity";
            lblUnity.Size = new Size(51, 15);
            lblUnity.TabIndex = 18;
            lblUnity.Text = "Unidade";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(270, 88);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(200, 23);
            cmbCategory.TabIndex = 17;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(206, 91);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(58, 15);
            lblCategory.TabIndex = 16;
            lblCategory.Text = "Categoria";
            // 
            // txtRefSupplier
            // 
            txtRefSupplier.Location = new Point(100, 88);
            txtRefSupplier.Name = "txtRefSupplier";
            txtRefSupplier.Size = new Size(100, 23);
            txtRefSupplier.TabIndex = 15;
            // 
            // lblRefSupplier
            // 
            lblRefSupplier.AutoSize = true;
            lblRefSupplier.Location = new Point(6, 91);
            lblRefSupplier.Name = "lblRefSupplier";
            lblRefSupplier.Size = new Size(76, 15);
            lblRefSupplier.TabIndex = 14;
            lblRefSupplier.Text = "Código Forn.";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(100, 53);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(622, 23);
            txtDescricao.TabIndex = 13;
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Location = new Point(6, 56);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(58, 15);
            lblDescricao.TabIndex = 12;
            lblDescricao.Text = "Descrição";
            // 
            // txtBarCode
            // 
            txtBarCode.Location = new Point(572, 16);
            txtBarCode.Name = "txtBarCode";
            txtBarCode.Size = new Size(150, 23);
            txtBarCode.TabIndex = 11;
            // 
            // lblBarCode
            // 
            lblBarCode.AutoSize = true;
            lblBarCode.Location = new Point(469, 19);
            lblBarCode.Name = "lblBarCode";
            lblBarCode.Size = new Size(97, 15);
            lblBarCode.TabIndex = 10;
            lblBarCode.Text = "Código de Barras";
            // 
            // lblProductId
            // 
            lblProductId.AutoSize = true;
            lblProductId.Location = new Point(306, 19);
            lblProductId.Name = "lblProductId";
            lblProductId.Size = new Size(50, 15);
            lblProductId.TabIndex = 8;
            lblProductId.Text = "Produto";
            // 
            // cmbProductType
            // 
            cmbProductType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProductType.FormattingEnabled = true;
            cmbProductType.Location = new Point(100, 16);
            cmbProductType.Name = "cmbProductType";
            cmbProductType.Size = new Size(200, 23);
            cmbProductType.TabIndex = 7;
            cmbProductType.SelectedIndexChanged += cmbProductType_SelectedIndexChanged;
            // 
            // lblProductType
            // 
            lblProductType.Location = new Point(6, 19);
            lblProductType.Name = "lblProductType";
            lblProductType.Size = new Size(100, 23);
            lblProductType.TabIndex = 6;
            lblProductType.Text = "Tipo de Produto";
            // 
            // gbImage
            // 
            gbImage.Controls.Add(btnAddImage);
            gbImage.Controls.Add(pbProductImage);
            gbImage.Location = new Point(754, 20);
            gbImage.Name = "gbImage";
            gbImage.Size = new Size(130, 166);
            gbImage.TabIndex = 1;
            gbImage.TabStop = false;
            gbImage.Text = "Imagem";
            // 
            // btnAddImage
            // 
            btnAddImage.IconChar = FontAwesome.Sharp.IconChar.Image;
            btnAddImage.IconColor = SystemColors.HotTrack;
            btnAddImage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddImage.IconSize = 20;
            btnAddImage.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddImage.Location = new Point(15, 135);
            btnAddImage.Name = "btnAddImage";
            btnAddImage.Size = new Size(100, 23);
            btnAddImage.TabIndex = 1;
            btnAddImage.Text = "     Adicionar";
            btnAddImage.UseVisualStyleBackColor = true;
            // 
            // pbProductImage
            // 
            pbProductImage.BorderStyle = BorderStyle.FixedSingle;
            pbProductImage.Location = new Point(15, 20);
            pbProductImage.Name = "pbProductImage";
            pbProductImage.Size = new Size(100, 100);
            pbProductImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbProductImage.TabIndex = 0;
            pbProductImage.TabStop = false;
            // 
            // tabList
            // 
            tabList.BackColor = SystemColors.Control;
            tabList.Location = new Point(4, 24);
            tabList.Name = "tabList";
            tabList.Size = new Size(892, 572);
            tabList.TabIndex = 1;
            tabList.Text = "Consulta";
            // 
            // ProductForm
            // 
            ClientSize = new Size(900, 600);
            Controls.Add(tabControl);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProductForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Produto";
            Load += ProductForm_Load;
            tabControl.ResumeLayout(false);
            tabRegister.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbPrinters.ResumeLayout(false);
            gbPrinters.PerformLayout();
            gbFiscalPricing.ResumeLayout(false);
            gbFiscalPricing.PerformLayout();
            gbStock.ResumeLayout(false);
            gbStock.PerformLayout();
            gbGeneral.ResumeLayout(false);
            gbGeneral.PerformLayout();
            gbImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbProductImage).EndInit();
            ResumeLayout(false);
        }
        private Label lblProductType;
        private Label lblProductId;
        private ComboBox cmbProductType;
        private TextBox txtRefSupplier;
        private Label lblRefSupplier;
        private TextBox txtDescricao;
        private Label lblDescricao;
        private TextBox txtBarCode;
        private Label lblBarCode;
        private CheckBox chkAticve;
        private ComboBox cmbUnity;
        private Label lblUnity;
        private ComboBox cmbCategory;
        private Label lblCategory;
        private GroupBox gbStock;
        private Label lblMinStock;
        private Label lblStock;
        private TextBox txtStock;
        private Label lblLocation;
        private Label lblMaxStock;
        private CheckBox chkStockControlled;
        private TextBox txtMaxStock;
        private TextBox txtMinStock;
        private GroupBox gbFiscalPricing;
        private TextBox txtLocation;
        private CheckBox chkAllowZeroStockSale;
        private FontAwesome.Sharp.IconButton btnClean;
        private FontAwesome.Sharp.IconButton btnSave;
        private TextBox txtCostPrice;
        private Label lblCostPrice;
        private ComboBox cmbCSTCSOSN;
        private Label lblCSTCSOSN;
        private TextBox txtSalePrice;
        private Label lblSalePrice;
        private TextBox txtProfitMargin;
        private Label lblProfitMargin;
        private GroupBox gbPrinters;
        private ComboBox cmbCFOP;
        private Label lblCFOP;
        private TextBox txtCEST;
        private Label lblCEST;
        private TextBox txtNCM;
        private Label lblNCM;
        private FontAwesome.Sharp.IconButton btnAddImage;
        private ComboBox cmbPrintSector;
        private Label lblPrintSector;
        private CheckBox chkPrintersSector;
        private GroupBox groupBox1;
        private CheckBox chkAutoPrint;
        private CheckBox chkShowInOrder;
        private CheckBox chkWeighing;
        private CheckBox chkService;
        private CheckBox chkFractional;
        private TextBox textBox1;
        private Label lblNotes;
        private TextBox txtProductId;
    }
}