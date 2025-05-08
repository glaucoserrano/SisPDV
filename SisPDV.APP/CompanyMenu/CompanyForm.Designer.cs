namespace SisPDV.APP.CompanyMenu
{
    partial class CompanyForm
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
            grpCompany = new GroupBox();
            txtCNPJ = new MaskedTextBox();
            cmbTaxRegime = new ComboBox();
            lblTaxRegime = new Label();
            txtIM = new TextBox();
            txtIE = new TextBox();
            txtFantasyName = new TextBox();
            txtCompanyName = new TextBox();
            lblIM = new Label();
            lblIE = new Label();
            lblCNPJ = new Label();
            lblFantasyName = new Label();
            lblCompanyName = new Label();
            grpAddress = new GroupBox();
            txtCEP = new MaskedTextBox();
            txtUF = new TextBox();
            lblUF = new Label();
            txtCityCode = new TextBox();
            lblCityCode = new Label();
            txtCity = new TextBox();
            lblCity = new Label();
            lblCEP = new Label();
            txtDistrict = new TextBox();
            lblDistrict = new Label();
            txtNumber = new TextBox();
            lblNumber = new Label();
            txtStreet = new TextBox();
            lblStreet = new Label();
            grpContact = new GroupBox();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtPhone = new MaskedTextBox();
            lblPhone = new Label();
            btnSave = new FontAwesome.Sharp.IconButton();
            grpCompany.SuspendLayout();
            grpAddress.SuspendLayout();
            grpContact.SuspendLayout();
            SuspendLayout();
            // 
            // grpCompany
            // 
            grpCompany.Controls.Add(txtCNPJ);
            grpCompany.Controls.Add(cmbTaxRegime);
            grpCompany.Controls.Add(lblTaxRegime);
            grpCompany.Controls.Add(txtIM);
            grpCompany.Controls.Add(txtIE);
            grpCompany.Controls.Add(txtFantasyName);
            grpCompany.Controls.Add(txtCompanyName);
            grpCompany.Controls.Add(lblIM);
            grpCompany.Controls.Add(lblIE);
            grpCompany.Controls.Add(lblCNPJ);
            grpCompany.Controls.Add(lblFantasyName);
            grpCompany.Controls.Add(lblCompanyName);
            grpCompany.Location = new Point(10, 10);
            grpCompany.Name = "grpCompany";
            grpCompany.Size = new Size(750, 150);
            grpCompany.TabIndex = 0;
            grpCompany.TabStop = false;
            grpCompany.Text = "Dados da Empresa";
            // 
            // txtCNPJ
            // 
            txtCNPJ.Location = new Point(122, 80);
            txtCNPJ.Mask = "99,999,999/9999-99";
            txtCNPJ.Name = "txtCNPJ";
            txtCNPJ.Size = new Size(200, 23);
            txtCNPJ.TabIndex = 16;
            txtCNPJ.Leave += txtCNPJ_Leave;
            // 
            // cmbTaxRegime
            // 
            cmbTaxRegime.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTaxRegime.FormattingEnabled = true;
            cmbTaxRegime.Location = new Point(472, 109);
            cmbTaxRegime.Name = "cmbTaxRegime";
            cmbTaxRegime.Size = new Size(250, 23);
            cmbTaxRegime.TabIndex = 15;
            // 
            // lblTaxRegime
            // 
            lblTaxRegime.AutoSize = true;
            lblTaxRegime.Location = new Point(365, 112);
            lblTaxRegime.Name = "lblTaxRegime";
            lblTaxRegime.Size = new Size(100, 15);
            lblTaxRegime.TabIndex = 14;
            lblTaxRegime.Text = "Regime Tributário";
            // 
            // txtIM
            // 
            txtIM.Location = new Point(122, 109);
            txtIM.Name = "txtIM";
            txtIM.PlaceholderText = "Inscrição Municipal";
            txtIM.Size = new Size(200, 23);
            txtIM.TabIndex = 13;
            // 
            // txtIE
            // 
            txtIE.Location = new Point(472, 80);
            txtIE.Name = "txtIE";
            txtIE.PlaceholderText = "Inscrição Estadual";
            txtIE.Size = new Size(250, 23);
            txtIE.TabIndex = 12;
            // 
            // txtFantasyName
            // 
            txtFantasyName.Location = new Point(122, 51);
            txtFantasyName.Name = "txtFantasyName";
            txtFantasyName.PlaceholderText = "Nome Fantasia";
            txtFantasyName.Size = new Size(600, 23);
            txtFantasyName.TabIndex = 10;
            // 
            // txtCompanyName
            // 
            txtCompanyName.Location = new Point(122, 22);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.PlaceholderText = "Razão Social";
            txtCompanyName.Size = new Size(600, 23);
            txtCompanyName.TabIndex = 9;
            // 
            // lblIM
            // 
            lblIM.AutoSize = true;
            lblIM.Location = new Point(6, 112);
            lblIM.Name = "lblIM";
            lblIM.Size = new Size(110, 15);
            lblIM.TabIndex = 8;
            lblIM.Text = "Inscrição Municipal";
            // 
            // lblIE
            // 
            lblIE.AutoSize = true;
            lblIE.Location = new Point(365, 83);
            lblIE.Name = "lblIE";
            lblIE.Size = new Size(101, 15);
            lblIE.TabIndex = 6;
            lblIE.Text = "Inscrição Estadual";
            // 
            // lblCNPJ
            // 
            lblCNPJ.AutoSize = true;
            lblCNPJ.Location = new Point(6, 83);
            lblCNPJ.Name = "lblCNPJ";
            lblCNPJ.Size = new Size(34, 15);
            lblCNPJ.TabIndex = 4;
            lblCNPJ.Text = "CNPJ";
            // 
            // lblFantasyName
            // 
            lblFantasyName.AutoSize = true;
            lblFantasyName.Location = new Point(6, 54);
            lblFantasyName.Name = "lblFantasyName";
            lblFantasyName.Size = new Size(86, 15);
            lblFantasyName.TabIndex = 3;
            lblFantasyName.Text = "Nome Fantasia";
            // 
            // lblCompanyName
            // 
            lblCompanyName.AutoSize = true;
            lblCompanyName.Location = new Point(6, 25);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new Size(72, 15);
            lblCompanyName.TabIndex = 0;
            lblCompanyName.Text = "Razão Social";
            // 
            // grpAddress
            // 
            grpAddress.Controls.Add(txtCEP);
            grpAddress.Controls.Add(txtUF);
            grpAddress.Controls.Add(lblUF);
            grpAddress.Controls.Add(txtCityCode);
            grpAddress.Controls.Add(lblCityCode);
            grpAddress.Controls.Add(txtCity);
            grpAddress.Controls.Add(lblCity);
            grpAddress.Controls.Add(lblCEP);
            grpAddress.Controls.Add(txtDistrict);
            grpAddress.Controls.Add(lblDistrict);
            grpAddress.Controls.Add(txtNumber);
            grpAddress.Controls.Add(lblNumber);
            grpAddress.Controls.Add(txtStreet);
            grpAddress.Controls.Add(lblStreet);
            grpAddress.Location = new Point(10, 166);
            grpAddress.Name = "grpAddress";
            grpAddress.Size = new Size(750, 115);
            grpAddress.TabIndex = 1;
            grpAddress.TabStop = false;
            grpAddress.Text = "Endereço";
            // 
            // txtCEP
            // 
            txtCEP.Location = new Point(632, 45);
            txtCEP.Mask = "99999-999";
            txtCEP.Name = "txtCEP";
            txtCEP.Size = new Size(90, 23);
            txtCEP.TabIndex = 23;
            txtCEP.Leave += txtCEP_Leave;
            // 
            // txtUF
            // 
            txtUF.Location = new Point(632, 74);
            txtUF.Name = "txtUF";
            txtUF.PlaceholderText = "UF";
            txtUF.Size = new Size(90, 23);
            txtUF.TabIndex = 22;
            // 
            // lblUF
            // 
            lblUF.AutoSize = true;
            lblUF.Location = new Point(578, 77);
            lblUF.Name = "lblUF";
            lblUF.Size = new Size(21, 15);
            lblUF.TabIndex = 21;
            lblUF.Text = "UF";
            // 
            // txtCityCode
            // 
            txtCityCode.Location = new Point(392, 74);
            txtCityCode.Name = "txtCityCode";
            txtCityCode.PlaceholderText = "Código IBGE";
            txtCityCode.Size = new Size(180, 23);
            txtCityCode.TabIndex = 20;
            // 
            // lblCityCode
            // 
            lblCityCode.AutoSize = true;
            lblCityCode.Location = new Point(313, 77);
            lblCityCode.Name = "lblCityCode";
            lblCityCode.Size = new Size(73, 15);
            lblCityCode.TabIndex = 19;
            lblCityCode.Text = "Código IBGE";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(122, 74);
            txtCity.Name = "txtCity";
            txtCity.PlaceholderText = "Cidade";
            txtCity.Size = new Size(180, 23);
            txtCity.TabIndex = 18;
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Location = new Point(6, 77);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(44, 15);
            lblCity.TabIndex = 17;
            lblCity.Text = "Cidade";
            // 
            // lblCEP
            // 
            lblCEP.AutoSize = true;
            lblCEP.Location = new Point(578, 48);
            lblCEP.Name = "lblCEP";
            lblCEP.Size = new Size(28, 15);
            lblCEP.TabIndex = 15;
            lblCEP.Text = "CEP";
            // 
            // txtDistrict
            // 
            txtDistrict.Location = new Point(122, 45);
            txtDistrict.Name = "txtDistrict";
            txtDistrict.PlaceholderText = "Bairro";
            txtDistrict.Size = new Size(450, 23);
            txtDistrict.TabIndex = 14;
            // 
            // lblDistrict
            // 
            lblDistrict.AutoSize = true;
            lblDistrict.Location = new Point(6, 48);
            lblDistrict.Name = "lblDistrict";
            lblDistrict.Size = new Size(38, 15);
            lblDistrict.TabIndex = 13;
            lblDistrict.Text = "Bairro";
            // 
            // txtNumber
            // 
            txtNumber.Location = new Point(632, 16);
            txtNumber.Name = "txtNumber";
            txtNumber.PlaceholderText = "Número";
            txtNumber.Size = new Size(90, 23);
            txtNumber.TabIndex = 12;
            // 
            // lblNumber
            // 
            lblNumber.AutoSize = true;
            lblNumber.Location = new Point(578, 19);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(51, 15);
            lblNumber.TabIndex = 11;
            lblNumber.Text = "Número";
            // 
            // txtStreet
            // 
            txtStreet.Location = new Point(122, 16);
            txtStreet.Name = "txtStreet";
            txtStreet.PlaceholderText = "Logradouro";
            txtStreet.Size = new Size(450, 23);
            txtStreet.TabIndex = 10;
            // 
            // lblStreet
            // 
            lblStreet.AutoSize = true;
            lblStreet.Location = new Point(6, 19);
            lblStreet.Name = "lblStreet";
            lblStreet.Size = new Size(69, 15);
            lblStreet.TabIndex = 1;
            lblStreet.Text = "Logradouro";
            // 
            // grpContact
            // 
            grpContact.Controls.Add(txtEmail);
            grpContact.Controls.Add(lblEmail);
            grpContact.Controls.Add(txtPhone);
            grpContact.Controls.Add(lblPhone);
            grpContact.Location = new Point(10, 287);
            grpContact.Name = "grpContact";
            grpContact.Size = new Size(750, 70);
            grpContact.TabIndex = 2;
            grpContact.TabStop = false;
            grpContact.Text = "Contato";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(392, 16);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "E-mail";
            txtEmail.Size = new Size(180, 23);
            txtEmail.TabIndex = 21;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(313, 19);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(41, 15);
            lblEmail.TabIndex = 20;
            lblEmail.Text = "E-mail";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(122, 16);
            txtPhone.Mask = "(99)99999-9999";
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(180, 23);
            txtPhone.TabIndex = 19;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(6, 19);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(51, 15);
            lblPhone.TabIndex = 18;
            lblPhone.Text = "Telefone";
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
            btnSave.Location = new Point(657, 369);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 9;
            btnSave.Text = "   Salvar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // CompanyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(768, 404);
            Controls.Add(btnSave);
            Controls.Add(grpContact);
            Controls.Add(grpAddress);
            Controls.Add(grpCompany);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CompanyForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro da Empresa";
            Load += CompanyForm_Load;
            grpCompany.ResumeLayout(false);
            grpCompany.PerformLayout();
            grpAddress.ResumeLayout(false);
            grpAddress.PerformLayout();
            grpContact.ResumeLayout(false);
            grpContact.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpCompany;
        private GroupBox grpAddress;
        private Label lblCompanyName;
        private Label lblCNPJ;
        private Label lblFantasyName;
        private Label lblIE;
        private TextBox txtFantasyName;
        private Label lblIM;
        private ComboBox cmbTaxRegime;
        private Label lblTaxRegime;
        private TextBox txtIM;
        private TextBox txtIE;
        private TextBox txtCompanyName;
        private TextBox txtStreet;
        private Label lblStreet;
        private TextBox txtNumber;
        private Label lblNumber;
        private Label lblCEP;
        private TextBox txtDistrict;
        private Label lblDistrict;
        private TextBox txtUF;
        private Label lblUF;
        private TextBox txtCityCode;
        private Label lblCityCode;
        private TextBox txtCity;
        private Label lblCity;
        private GroupBox grpContact;
        private Label lblEmail;
        private MaskedTextBox txtPhone;
        private Label lblPhone;
        private TextBox txtEmail;
        private FontAwesome.Sharp.IconButton btnSave;
        private MaskedTextBox txtCNPJ;
        private MaskedTextBox txtCEP;
    }
}