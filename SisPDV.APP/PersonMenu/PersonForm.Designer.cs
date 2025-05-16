namespace SisPDV.APP.PersonMenu
{
    partial class PersonForm : Form
    {
        private System.ComponentModel.IContainer components = null;

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
            chkActive = new CheckBox();
            btnClean = new FontAwesome.Sharp.IconButton();
            btnSave = new FontAwesome.Sharp.IconButton();
            grpIdentification = new GroupBox();
            groupBox1 = new GroupBox();
            rdbIndicatorNaoContribuinte = new RadioButton();
            rdbIndicatorIsento = new RadioButton();
            rdbIndicatorContribuinteICMS = new RadioButton();
            txtCNPJ = new MaskedTextBox();
            lblIE = new Label();
            lblCNPJ = new Label();
            lblCompanyName = new Label();
            grbTypePerson = new GroupBox();
            rdoPersonTypeCompany = new RadioButton();
            rdoPersonTypeIndividual = new RadioButton();
            txtName = new TextBox();
            txtIE = new TextBox();
            grpContact = new GroupBox();
            lblPhone = new Label();
            lblEmail = new Label();
            txtPhone = new MaskedTextBox();
            txtEmail = new TextBox();
            grpAddress = new GroupBox();
            lblUF = new Label();
            lblCityCode = new Label();
            txtUF = new TextBox();
            txtCityCode = new TextBox();
            lblCity = new Label();
            lblDistrict = new Label();
            lblComplement = new Label();
            lblNumber = new Label();
            lblAdreess = new Label();
            lblCEP = new Label();
            txtCEP = new MaskedTextBox();
            txtStreet = new TextBox();
            txtNumber = new TextBox();
            txtComplement = new TextBox();
            txtDistrict = new TextBox();
            txtCity = new TextBox();
            grpType = new GroupBox();
            chkClient = new CheckBox();
            chkSupplier = new CheckBox();
            chkCarrier = new CheckBox();
            tabSearch = new TabPage();
            grbSearch = new GroupBox();
            panel1 = new Panel();
            groupBox2 = new GroupBox();
            rdbSearchCompany = new RadioButton();
            rdbSearchIndividual = new RadioButton();
            btnSearch = new FontAwesome.Sharp.IconButton();
            grbTypeSearch = new GroupBox();
            chkSearchClient = new CheckBox();
            chkSearchSupplier = new CheckBox();
            chkSearchCarrier = new CheckBox();
            chkSearchActive = new CheckBox();
            txtSerachCNPJ = new MaskedTextBox();
            lblSearchCNPJ = new Label();
            txtSearchName = new TextBox();
            lblSearchName = new Label();
            dgvPerson = new DataGridView();
            tabControl.SuspendLayout();
            tabRegister.SuspendLayout();
            grpIdentification.SuspendLayout();
            groupBox1.SuspendLayout();
            grbTypePerson.SuspendLayout();
            grpContact.SuspendLayout();
            grpAddress.SuspendLayout();
            grpType.SuspendLayout();
            tabSearch.SuspendLayout();
            grbSearch.SuspendLayout();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            grbTypeSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPerson).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabRegister);
            tabControl.Controls.Add(tabSearch);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(800, 450);
            tabControl.TabIndex = 0;
            // 
            // tabRegister
            // 
            tabRegister.BackColor = SystemColors.Control;
            tabRegister.Controls.Add(chkActive);
            tabRegister.Controls.Add(btnClean);
            tabRegister.Controls.Add(btnSave);
            tabRegister.Controls.Add(grpIdentification);
            tabRegister.Controls.Add(grpContact);
            tabRegister.Controls.Add(grpAddress);
            tabRegister.Controls.Add(grpType);
            tabRegister.Location = new Point(4, 24);
            tabRegister.Name = "tabRegister";
            tabRegister.Size = new Size(792, 422);
            tabRegister.TabIndex = 0;
            tabRegister.Text = "Cadastro";
            // 
            // chkActive
            // 
            chkActive.Checked = true;
            chkActive.CheckState = CheckState.Checked;
            chkActive.FlatStyle = FlatStyle.Flat;
            chkActive.Location = new Point(30, 350);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(104, 24);
            chkActive.TabIndex = 11;
            chkActive.Text = "Ativo";
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
            btnClean.Location = new Point(600, 391);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(75, 23);
            btnClean.TabIndex = 10;
            btnClean.Text = "   Limpar";
            btnClean.UseVisualStyleBackColor = false;
            btnClean.Click += btnClean_Click;
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
            btnSave.Location = new Point(681, 391);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 9;
            btnSave.Text = "   Salvar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // grpIdentification
            // 
            grpIdentification.Controls.Add(groupBox1);
            grpIdentification.Controls.Add(txtCNPJ);
            grpIdentification.Controls.Add(lblIE);
            grpIdentification.Controls.Add(lblCNPJ);
            grpIdentification.Controls.Add(lblCompanyName);
            grpIdentification.Controls.Add(grbTypePerson);
            grpIdentification.Controls.Add(txtName);
            grpIdentification.Controls.Add(txtIE);
            grpIdentification.Location = new Point(20, 20);
            grpIdentification.Name = "grpIdentification";
            grpIdentification.Size = new Size(740, 115);
            grpIdentification.TabIndex = 0;
            grpIdentification.TabStop = false;
            grpIdentification.Text = "Identificação";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdbIndicatorNaoContribuinte);
            groupBox1.Controls.Add(rdbIndicatorIsento);
            groupBox1.Controls.Add(rdbIndicatorContribuinteICMS);
            groupBox1.Location = new Point(416, 63);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(304, 45);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Indicador Ins. Estadual";
            // 
            // rdbIndicatorNaoContribuinte
            // 
            rdbIndicatorNaoContribuinte.AutoSize = true;
            rdbIndicatorNaoContribuinte.FlatStyle = FlatStyle.Flat;
            rdbIndicatorNaoContribuinte.Location = new Point(169, 18);
            rdbIndicatorNaoContribuinte.Name = "rdbIndicatorNaoContribuinte";
            rdbIndicatorNaoContribuinte.Size = new Size(116, 19);
            rdbIndicatorNaoContribuinte.TabIndex = 2;
            rdbIndicatorNaoContribuinte.TabStop = true;
            rdbIndicatorNaoContribuinte.Text = "Não Contribuinte";
            rdbIndicatorNaoContribuinte.UseVisualStyleBackColor = true;
            // 
            // rdbIndicatorIsento
            // 
            rdbIndicatorIsento.AutoSize = true;
            rdbIndicatorIsento.FlatStyle = FlatStyle.Flat;
            rdbIndicatorIsento.Location = new Point(106, 18);
            rdbIndicatorIsento.Name = "rdbIndicatorIsento";
            rdbIndicatorIsento.Size = new Size(56, 19);
            rdbIndicatorIsento.TabIndex = 1;
            rdbIndicatorIsento.TabStop = true;
            rdbIndicatorIsento.Text = "Isento";
            rdbIndicatorIsento.UseVisualStyleBackColor = true;
            // 
            // rdbIndicatorContribuinteICMS
            // 
            rdbIndicatorContribuinteICMS.AutoSize = true;
            rdbIndicatorContribuinteICMS.FlatStyle = FlatStyle.Flat;
            rdbIndicatorContribuinteICMS.Location = new Point(8, 18);
            rdbIndicatorContribuinteICMS.Name = "rdbIndicatorContribuinteICMS";
            rdbIndicatorContribuinteICMS.Size = new Size(91, 19);
            rdbIndicatorContribuinteICMS.TabIndex = 0;
            rdbIndicatorContribuinteICMS.TabStop = true;
            rdbIndicatorContribuinteICMS.Text = "Contribuinte";
            rdbIndicatorContribuinteICMS.UseVisualStyleBackColor = true;
            // 
            // txtCNPJ
            // 
            txtCNPJ.Location = new Point(474, 39);
            txtCNPJ.Mask = "99,999,999/9999-99";
            txtCNPJ.Name = "txtCNPJ";
            txtCNPJ.Size = new Size(119, 23);
            txtCNPJ.TabIndex = 17;
            txtCNPJ.Leave += txtCNPJ_Leave;
            // 
            // lblIE
            // 
            lblIE.AutoSize = true;
            lblIE.Location = new Point(600, 21);
            lblIE.Name = "lblIE";
            lblIE.Size = new Size(72, 15);
            lblIE.TabIndex = 7;
            lblIE.Text = "Ins. Estadual";
            // 
            // lblCNPJ
            // 
            lblCNPJ.AutoSize = true;
            lblCNPJ.Location = new Point(474, 21);
            lblCNPJ.Name = "lblCNPJ";
            lblCNPJ.Size = new Size(66, 15);
            lblCNPJ.TabIndex = 6;
            lblCNPJ.Text = "CPF / CNPJ";
            // 
            // lblCompanyName
            // 
            lblCompanyName.AutoSize = true;
            lblCompanyName.Location = new Point(168, 21);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new Size(116, 15);
            lblCompanyName.TabIndex = 5;
            lblCompanyName.Text = "Nome / Razão Social";
            // 
            // grbTypePerson
            // 
            grbTypePerson.Controls.Add(rdoPersonTypeCompany);
            grbTypePerson.Controls.Add(rdoPersonTypeIndividual);
            grbTypePerson.Location = new Point(9, 22);
            grbTypePerson.Name = "grbTypePerson";
            grbTypePerson.Size = new Size(151, 45);
            grbTypePerson.TabIndex = 4;
            grbTypePerson.TabStop = false;
            grbTypePerson.Text = "Tipo de Pessoa";
            // 
            // rdoPersonTypeCompany
            // 
            rdoPersonTypeCompany.AutoSize = true;
            rdoPersonTypeCompany.FlatStyle = FlatStyle.Flat;
            rdoPersonTypeCompany.Location = new Point(68, 18);
            rdoPersonTypeCompany.Name = "rdoPersonTypeCompany";
            rdoPersonTypeCompany.Size = new Size(64, 19);
            rdoPersonTypeCompany.TabIndex = 1;
            rdoPersonTypeCompany.TabStop = true;
            rdoPersonTypeCompany.Text = "Jurídica";
            rdoPersonTypeCompany.UseVisualStyleBackColor = true;
            rdoPersonTypeCompany.CheckedChanged += rdoPersonTypeCompany_CheckedChanged;
            // 
            // rdoPersonTypeIndividual
            // 
            rdoPersonTypeIndividual.AutoSize = true;
            rdoPersonTypeIndividual.FlatStyle = FlatStyle.Flat;
            rdoPersonTypeIndividual.Location = new Point(8, 18);
            rdoPersonTypeIndividual.Name = "rdoPersonTypeIndividual";
            rdoPersonTypeIndividual.Size = new Size(53, 19);
            rdoPersonTypeIndividual.TabIndex = 0;
            rdoPersonTypeIndividual.TabStop = true;
            rdoPersonTypeIndividual.Text = "Física";
            rdoPersonTypeIndividual.UseVisualStyleBackColor = true;
            rdoPersonTypeIndividual.CheckedChanged += rdoPersonTypeIndividual_CheckedChanged;
            // 
            // txtName
            // 
            txtName.Location = new Point(168, 39);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Nome / Razão Social";
            txtName.Size = new Size(300, 23);
            txtName.TabIndex = 0;
            // 
            // txtIE
            // 
            txtIE.Location = new Point(600, 39);
            txtIE.Name = "txtIE";
            txtIE.PlaceholderText = "Inscrição Estadual";
            txtIE.Size = new Size(120, 23);
            txtIE.TabIndex = 3;
            // 
            // grpContact
            // 
            grpContact.Controls.Add(lblPhone);
            grpContact.Controls.Add(lblEmail);
            grpContact.Controls.Add(txtPhone);
            grpContact.Controls.Add(txtEmail);
            grpContact.Location = new Point(20, 138);
            grpContact.Name = "grpContact";
            grpContact.Size = new Size(740, 60);
            grpContact.TabIndex = 1;
            grpContact.TabStop = false;
            grpContact.Text = "Contato";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(430, 13);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(51, 15);
            lblPhone.TabIndex = 22;
            lblPhone.Text = "Telefone";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(9, 13);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(41, 15);
            lblEmail.TabIndex = 21;
            lblEmail.Text = "E-mail";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(430, 31);
            txtPhone.Mask = "(99)99999-9999";
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(180, 23);
            txtPhone.TabIndex = 20;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(10, 31);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "E-mail";
            txtEmail.Size = new Size(400, 23);
            txtEmail.TabIndex = 0;
            // 
            // grpAddress
            // 
            grpAddress.Controls.Add(lblUF);
            grpAddress.Controls.Add(lblCityCode);
            grpAddress.Controls.Add(txtUF);
            grpAddress.Controls.Add(txtCityCode);
            grpAddress.Controls.Add(lblCity);
            grpAddress.Controls.Add(lblDistrict);
            grpAddress.Controls.Add(lblComplement);
            grpAddress.Controls.Add(lblNumber);
            grpAddress.Controls.Add(lblAdreess);
            grpAddress.Controls.Add(lblCEP);
            grpAddress.Controls.Add(txtCEP);
            grpAddress.Controls.Add(txtStreet);
            grpAddress.Controls.Add(txtNumber);
            grpAddress.Controls.Add(txtComplement);
            grpAddress.Controls.Add(txtDistrict);
            grpAddress.Controls.Add(txtCity);
            grpAddress.Location = new Point(20, 204);
            grpAddress.Name = "grpAddress";
            grpAddress.Size = new Size(740, 120);
            grpAddress.TabIndex = 2;
            grpAddress.TabStop = false;
            grpAddress.Text = "Endereço";
            // 
            // lblUF
            // 
            lblUF.AutoSize = true;
            lblUF.Location = new Point(630, 57);
            lblUF.Name = "lblUF";
            lblUF.Size = new Size(21, 15);
            lblUF.TabIndex = 34;
            lblUF.Text = "UF";
            // 
            // lblCityCode
            // 
            lblCityCode.AutoSize = true;
            lblCityCode.Location = new Point(430, 57);
            lblCityCode.Name = "lblCityCode";
            lblCityCode.Size = new Size(44, 15);
            lblCityCode.TabIndex = 33;
            lblCityCode.Text = "Cidade";
            // 
            // txtUF
            // 
            txtUF.Location = new Point(630, 75);
            txtUF.Name = "txtUF";
            txtUF.PlaceholderText = "UF";
            txtUF.Size = new Size(90, 23);
            txtUF.TabIndex = 32;
            // 
            // txtCityCode
            // 
            txtCityCode.Location = new Point(430, 75);
            txtCityCode.Name = "txtCityCode";
            txtCityCode.PlaceholderText = "Código IBGE";
            txtCityCode.Size = new Size(180, 23);
            txtCityCode.TabIndex = 31;
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Location = new Point(220, 57);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(44, 15);
            lblCity.TabIndex = 30;
            lblCity.Text = "Cidade";
            // 
            // lblDistrict
            // 
            lblDistrict.AutoSize = true;
            lblDistrict.Location = new Point(10, 57);
            lblDistrict.Name = "lblDistrict";
            lblDistrict.Size = new Size(56, 15);
            lblDistrict.TabIndex = 29;
            lblDistrict.Text = "Endereço";
            // 
            // lblComplement
            // 
            lblComplement.AutoSize = true;
            lblComplement.Location = new Point(504, 13);
            lblComplement.Name = "lblComplement";
            lblComplement.Size = new Size(84, 15);
            lblComplement.TabIndex = 28;
            lblComplement.Text = "Complemento";
            // 
            // lblNumber
            // 
            lblNumber.AutoSize = true;
            lblNumber.Location = new Point(416, 13);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(51, 15);
            lblNumber.TabIndex = 27;
            lblNumber.Text = "Número";
            // 
            // lblAdreess
            // 
            lblAdreess.AutoSize = true;
            lblAdreess.Location = new Point(110, 13);
            lblAdreess.Name = "lblAdreess";
            lblAdreess.Size = new Size(56, 15);
            lblAdreess.TabIndex = 26;
            lblAdreess.Text = "Endereço";
            // 
            // lblCEP
            // 
            lblCEP.AutoSize = true;
            lblCEP.Location = new Point(10, 13);
            lblCEP.Name = "lblCEP";
            lblCEP.Size = new Size(28, 15);
            lblCEP.TabIndex = 25;
            lblCEP.Text = "CEP";
            // 
            // txtCEP
            // 
            txtCEP.Location = new Point(10, 31);
            txtCEP.Mask = "99999-999";
            txtCEP.Name = "txtCEP";
            txtCEP.Size = new Size(90, 23);
            txtCEP.TabIndex = 24;
            txtCEP.Leave += txtCEP_Leave;
            // 
            // txtStreet
            // 
            txtStreet.Location = new Point(110, 31);
            txtStreet.Name = "txtStreet";
            txtStreet.PlaceholderText = "Rua";
            txtStreet.Size = new Size(300, 23);
            txtStreet.TabIndex = 1;
            // 
            // txtNumber
            // 
            txtNumber.Location = new Point(416, 31);
            txtNumber.Name = "txtNumber";
            txtNumber.PlaceholderText = "Número";
            txtNumber.Size = new Size(80, 23);
            txtNumber.TabIndex = 2;
            // 
            // txtComplement
            // 
            txtComplement.Location = new Point(504, 31);
            txtComplement.Name = "txtComplement";
            txtComplement.PlaceholderText = "Complemento";
            txtComplement.Size = new Size(216, 23);
            txtComplement.TabIndex = 3;
            // 
            // txtDistrict
            // 
            txtDistrict.Location = new Point(10, 75);
            txtDistrict.Name = "txtDistrict";
            txtDistrict.PlaceholderText = "Bairro";
            txtDistrict.Size = new Size(200, 23);
            txtDistrict.TabIndex = 4;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(220, 75);
            txtCity.Name = "txtCity";
            txtCity.PlaceholderText = "Cidade";
            txtCity.Size = new Size(200, 23);
            txtCity.TabIndex = 5;
            // 
            // grpType
            // 
            grpType.Controls.Add(chkClient);
            grpType.Controls.Add(chkSupplier);
            grpType.Controls.Add(chkCarrier);
            grpType.Location = new Point(130, 330);
            grpType.Name = "grpType";
            grpType.Size = new Size(337, 50);
            grpType.TabIndex = 3;
            grpType.TabStop = false;
            grpType.Text = "Tipo";
            // 
            // chkClient
            // 
            chkClient.FlatStyle = FlatStyle.Flat;
            chkClient.Location = new Point(10, 20);
            chkClient.Name = "chkClient";
            chkClient.Size = new Size(84, 24);
            chkClient.TabIndex = 0;
            chkClient.Text = "Cliente";
            // 
            // chkSupplier
            // 
            chkSupplier.FlatStyle = FlatStyle.Flat;
            chkSupplier.Location = new Point(100, 20);
            chkSupplier.Name = "chkSupplier";
            chkSupplier.Size = new Size(104, 24);
            chkSupplier.TabIndex = 1;
            chkSupplier.Text = "Fornecedor";
            // 
            // chkCarrier
            // 
            chkCarrier.FlatStyle = FlatStyle.Flat;
            chkCarrier.Location = new Point(210, 20);
            chkCarrier.Name = "chkCarrier";
            chkCarrier.Size = new Size(104, 24);
            chkCarrier.TabIndex = 2;
            chkCarrier.Text = "Transportadora";
            // 
            // tabSearch
            // 
            tabSearch.Controls.Add(grbSearch);
            tabSearch.Location = new Point(4, 24);
            tabSearch.Name = "tabSearch";
            tabSearch.Size = new Size(792, 422);
            tabSearch.TabIndex = 1;
            tabSearch.Text = "Consulta";
            tabSearch.UseVisualStyleBackColor = true;
            // 
            // grbSearch
            // 
            grbSearch.BackColor = SystemColors.Control;
            grbSearch.Controls.Add(panel1);
            grbSearch.Controls.Add(dgvPerson);
            grbSearch.Dock = DockStyle.Fill;
            grbSearch.Location = new Point(0, 0);
            grbSearch.Name = "grbSearch";
            grbSearch.Size = new Size(792, 422);
            grbSearch.TabIndex = 0;
            grbSearch.TabStop = false;
            grbSearch.Text = "Consulta";
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(grbTypeSearch);
            panel1.Controls.Add(chkSearchActive);
            panel1.Controls.Add(txtSerachCNPJ);
            panel1.Controls.Add(lblSearchCNPJ);
            panel1.Controls.Add(txtSearchName);
            panel1.Controls.Add(lblSearchName);
            panel1.Location = new Point(3, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(786, 118);
            panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rdbSearchCompany);
            groupBox2.Controls.Add(rdbSearchIndividual);
            groupBox2.Location = new Point(311, 7);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(151, 45);
            groupBox2.TabIndex = 22;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tipo de Pessoa";
            // 
            // rdbSearchCompany
            // 
            rdbSearchCompany.AutoSize = true;
            rdbSearchCompany.Checked = true;
            rdbSearchCompany.FlatStyle = FlatStyle.Flat;
            rdbSearchCompany.Location = new Point(68, 18);
            rdbSearchCompany.Name = "rdbSearchCompany";
            rdbSearchCompany.Size = new Size(64, 19);
            rdbSearchCompany.TabIndex = 1;
            rdbSearchCompany.TabStop = true;
            rdbSearchCompany.Text = "Jurídica";
            rdbSearchCompany.UseVisualStyleBackColor = true;
            rdbSearchCompany.CheckedChanged += rdbSearchCompany_CheckedChanged;
            // 
            // rdbSearchIndividual
            // 
            rdbSearchIndividual.AutoSize = true;
            rdbSearchIndividual.FlatStyle = FlatStyle.Flat;
            rdbSearchIndividual.Location = new Point(8, 18);
            rdbSearchIndividual.Name = "rdbSearchIndividual";
            rdbSearchIndividual.Size = new Size(53, 19);
            rdbSearchIndividual.TabIndex = 0;
            rdbSearchIndividual.Text = "Física";
            rdbSearchIndividual.UseVisualStyleBackColor = true;
            rdbSearchIndividual.CheckedChanged += rdbSearchIndividual_CheckedChanged;
            // 
            // btnSearch
            // 
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnSearch.IconColor = Color.Black;
            btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSearch.IconSize = 16;
            btnSearch.ImageAlign = ContentAlignment.MiddleLeft;
            btnSearch.Location = new Point(689, 78);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(89, 24);
            btnSearch.TabIndex = 21;
            btnSearch.Text = "   Pesquisar";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // grbTypeSearch
            // 
            grbTypeSearch.Controls.Add(chkSearchClient);
            grbTypeSearch.Controls.Add(chkSearchSupplier);
            grbTypeSearch.Controls.Add(chkSearchCarrier);
            grbTypeSearch.Location = new Point(5, 58);
            grbTypeSearch.Name = "grbTypeSearch";
            grbTypeSearch.Size = new Size(337, 50);
            grbTypeSearch.TabIndex = 20;
            grbTypeSearch.TabStop = false;
            grbTypeSearch.Text = "Tipo";
            // 
            // chkSearchClient
            // 
            chkSearchClient.FlatStyle = FlatStyle.Flat;
            chkSearchClient.Location = new Point(10, 20);
            chkSearchClient.Name = "chkSearchClient";
            chkSearchClient.Size = new Size(84, 24);
            chkSearchClient.TabIndex = 0;
            chkSearchClient.Text = "Cliente";
            // 
            // chkSearchSupplier
            // 
            chkSearchSupplier.FlatStyle = FlatStyle.Flat;
            chkSearchSupplier.Location = new Point(100, 20);
            chkSearchSupplier.Name = "chkSearchSupplier";
            chkSearchSupplier.Size = new Size(104, 24);
            chkSearchSupplier.TabIndex = 1;
            chkSearchSupplier.Text = "Fornecedor";
            // 
            // chkSearchCarrier
            // 
            chkSearchCarrier.FlatStyle = FlatStyle.Flat;
            chkSearchCarrier.Location = new Point(210, 20);
            chkSearchCarrier.Name = "chkSearchCarrier";
            chkSearchCarrier.Size = new Size(104, 24);
            chkSearchCarrier.TabIndex = 2;
            chkSearchCarrier.Text = "Transportadora";
            // 
            // chkSearchActive
            // 
            chkSearchActive.FlatStyle = FlatStyle.Flat;
            chkSearchActive.Location = new Point(593, 27);
            chkSearchActive.Name = "chkSearchActive";
            chkSearchActive.Size = new Size(104, 24);
            chkSearchActive.TabIndex = 19;
            chkSearchActive.Text = "Ativo";
            // 
            // txtSerachCNPJ
            // 
            txtSerachCNPJ.Location = new Point(468, 29);
            txtSerachCNPJ.Mask = "99,999,999/9999-99";
            txtSerachCNPJ.Name = "txtSerachCNPJ";
            txtSerachCNPJ.Size = new Size(119, 23);
            txtSerachCNPJ.TabIndex = 18;
            // 
            // lblSearchCNPJ
            // 
            lblSearchCNPJ.AutoSize = true;
            lblSearchCNPJ.Location = new Point(468, 11);
            lblSearchCNPJ.Name = "lblSearchCNPJ";
            lblSearchCNPJ.Size = new Size(66, 15);
            lblSearchCNPJ.TabIndex = 2;
            lblSearchCNPJ.Text = "CPF / CNPJ";
            // 
            // txtSearchName
            // 
            txtSearchName.Location = new Point(5, 29);
            txtSearchName.Name = "txtSearchName";
            txtSearchName.PlaceholderText = "Nome / Razão Social";
            txtSearchName.Size = new Size(300, 23);
            txtSearchName.TabIndex = 1;
            // 
            // lblSearchName
            // 
            lblSearchName.AutoSize = true;
            lblSearchName.Location = new Point(5, 11);
            lblSearchName.Name = "lblSearchName";
            lblSearchName.Size = new Size(116, 15);
            lblSearchName.TabIndex = 0;
            lblSearchName.Text = "Nome / Razão Social";
            // 
            // dgvPerson
            // 
            dgvPerson.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPerson.Dock = DockStyle.Bottom;
            dgvPerson.Location = new Point(3, 146);
            dgvPerson.Name = "dgvPerson";
            dgvPerson.RowHeadersVisible = false;
            dgvPerson.Size = new Size(786, 273);
            dgvPerson.TabIndex = 0;
            dgvPerson.CellDoubleClick += dgvPerson_CellDoubleClick;
            // 
            // PersonForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PersonForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Pessoa (Cliente / Fornecedor / Transportadora)";
            Load += PersonForm_Load;
            tabControl.ResumeLayout(false);
            tabRegister.ResumeLayout(false);
            grpIdentification.ResumeLayout(false);
            grpIdentification.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            grbTypePerson.ResumeLayout(false);
            grbTypePerson.PerformLayout();
            grpContact.ResumeLayout(false);
            grpContact.PerformLayout();
            grpAddress.ResumeLayout(false);
            grpAddress.PerformLayout();
            grpType.ResumeLayout(false);
            tabSearch.ResumeLayout(false);
            grbSearch.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            grbTypeSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPerson).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabRegister;
        private System.Windows.Forms.TabPage tabSearch;

        private System.Windows.Forms.GroupBox grpIdentification;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtIE;

        private System.Windows.Forms.GroupBox grpContact;
        private System.Windows.Forms.TextBox txtEmail;

        private System.Windows.Forms.GroupBox grpAddress;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.TextBox txtComplement;
        private System.Windows.Forms.TextBox txtDistrict;
        private System.Windows.Forms.TextBox txtCity;

        private System.Windows.Forms.GroupBox grpType;
        private System.Windows.Forms.CheckBox chkClient;
        private System.Windows.Forms.CheckBox chkSupplier;
        private System.Windows.Forms.CheckBox chkCarrier;
        private FontAwesome.Sharp.IconButton btnClean;
        private FontAwesome.Sharp.IconButton btnSave;
        private GroupBox grbTypePerson;
        private RadioButton rdoPersonTypeCompany;
        private RadioButton rdoPersonTypeIndividual;
        private Label lblCompanyName;
        private Label lblCNPJ;
        private Label lblIE;
        private Label lblEmail;
        private MaskedTextBox txtPhone;
        private Label lblPhone;
        private Label lblComplement;
        private Label lblNumber;
        private Label lblAdreess;
        private Label lblCEP;
        private MaskedTextBox txtCEP;
        private Label lblDistrict;
        private Label lblCity;
        private Label lblCityCode;
        private TextBox txtUF;
        private TextBox txtCityCode;
        private Label lblUF;
        private CheckBox chkActive;
        private MaskedTextBox txtCNPJ;
        private GroupBox groupBox1;
        private RadioButton rdbIndicatorIsento;
        private RadioButton rdbIndicatorContribuinteICMS;
        private RadioButton rdbIndicatorNaoContribuinte;
        private GroupBox grbSearch;
        private DataGridView dgvPerson;
        private Panel panel1;
        private Label lblSearchCNPJ;
        private TextBox txtSearchName;
        private Label lblSearchName;
        private GroupBox grbTypeSearch;
        private CheckBox chkSearchClient;
        private CheckBox chkSearchSupplier;
        private CheckBox chkSearchCarrier;
        private CheckBox chkSearchActive;
        private MaskedTextBox txtSerachCNPJ;
        private FontAwesome.Sharp.IconButton btnSearch;
        private GroupBox groupBox2;
        private RadioButton rdbSearchCompany;
        private RadioButton rdbSearchIndividual;
    }
}
