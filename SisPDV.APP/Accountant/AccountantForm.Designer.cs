namespace SisPDV.APP.Accountant
{
    partial class AccountantForm
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

        private System.Windows.Forms.GroupBox gbAccountant;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.DataGridView dgvAccountants;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gbAccountant = new GroupBox();
            btnClean = new FontAwesome.Sharp.IconButton();
            btnSave = new FontAwesome.Sharp.IconButton();
            grpContact = new GroupBox();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtPhone = new MaskedTextBox();
            lblPhone = new Label();
            grpAddress = new GroupBox();
            txtCEP = new MaskedTextBox();
            txtUF = new TextBox();
            lblUF = new Label();
            txtCity = new TextBox();
            lblCity = new Label();
            lblCEP = new Label();
            txtDistrict = new TextBox();
            lblDistrict = new Label();
            txtNumber = new TextBox();
            lblNumber = new Label();
            txtStreet = new TextBox();
            lblStreet = new Label();
            txtCRC = new TextBox();
            lblCRC = new Label();
            txtCPF = new MaskedTextBox();
            label1 = new Label();
            txtCNPJ = new MaskedTextBox();
            lblCNPJ = new Label();
            txtAccontant = new TextBox();
            lblAccontant = new Label();
            chkActive = new CheckBox();
            dgvAccountants = new DataGridView();
            gbFilter = new GroupBox();
            lblSearch = new Label();
            txtSearch = new TextBox();
            rbAll = new RadioButton();
            rbActive = new RadioButton();
            rbInactive = new RadioButton();
            gbAccountant.SuspendLayout();
            grpContact.SuspendLayout();
            grpAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccountants).BeginInit();
            gbFilter.SuspendLayout();
            SuspendLayout();
            // 
            // gbAccountant
            // 
            gbAccountant.Controls.Add(btnClean);
            gbAccountant.Controls.Add(btnSave);
            gbAccountant.Controls.Add(grpContact);
            gbAccountant.Controls.Add(grpAddress);
            gbAccountant.Controls.Add(txtCRC);
            gbAccountant.Controls.Add(lblCRC);
            gbAccountant.Controls.Add(txtCPF);
            gbAccountant.Controls.Add(label1);
            gbAccountant.Controls.Add(txtCNPJ);
            gbAccountant.Controls.Add(lblCNPJ);
            gbAccountant.Controls.Add(txtAccontant);
            gbAccountant.Controls.Add(lblAccontant);
            gbAccountant.Controls.Add(chkActive);
            gbAccountant.Location = new Point(12, 12);
            gbAccountant.Name = "gbAccountant";
            gbAccountant.Size = new Size(765, 302);
            gbAccountant.TabIndex = 0;
            gbAccountant.TabStop = false;
            gbAccountant.Text = "Informações do Contador";
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
            btnClean.Location = new Point(600, 274);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(75, 23);
            btnClean.TabIndex = 14;
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
            btnSave.Location = new Point(681, 274);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 13;
            btnSave.Text = "   Salvar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // grpContact
            // 
            grpContact.Controls.Add(txtEmail);
            grpContact.Controls.Add(lblEmail);
            grpContact.Controls.Add(txtPhone);
            grpContact.Controls.Add(lblPhone);
            grpContact.Location = new Point(6, 201);
            grpContact.Name = "grpContact";
            grpContact.Size = new Size(750, 70);
            grpContact.TabIndex = 24;
            grpContact.TabStop = false;
            grpContact.Text = "Contato";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(392, 16);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "E-mail";
            txtEmail.Size = new Size(180, 23);
            txtEmail.TabIndex = 12;
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
            txtPhone.TabIndex = 11;
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
            // grpAddress
            // 
            grpAddress.Controls.Add(txtCEP);
            grpAddress.Controls.Add(txtUF);
            grpAddress.Controls.Add(lblUF);
            grpAddress.Controls.Add(txtCity);
            grpAddress.Controls.Add(lblCity);
            grpAddress.Controls.Add(lblCEP);
            grpAddress.Controls.Add(txtDistrict);
            grpAddress.Controls.Add(lblDistrict);
            grpAddress.Controls.Add(txtNumber);
            grpAddress.Controls.Add(lblNumber);
            grpAddress.Controls.Add(txtStreet);
            grpAddress.Controls.Add(lblStreet);
            grpAddress.Location = new Point(6, 80);
            grpAddress.Name = "grpAddress";
            grpAddress.Size = new Size(750, 115);
            grpAddress.TabIndex = 23;
            grpAddress.TabStop = false;
            grpAddress.Text = "Endereço";
            // 
            // txtCEP
            // 
            txtCEP.Location = new Point(632, 45);
            txtCEP.Mask = "99999-999";
            txtCEP.Name = "txtCEP";
            txtCEP.Size = new Size(90, 23);
            txtCEP.TabIndex = 5;
            txtCEP.Leave += txtCEP_Leave;
            // 
            // txtUF
            // 
            txtUF.Location = new Point(632, 74);
            txtUF.Name = "txtUF";
            txtUF.PlaceholderText = "UF";
            txtUF.Size = new Size(90, 23);
            txtUF.TabIndex = 10;
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
            // txtCity
            // 
            txtCity.Location = new Point(122, 74);
            txtCity.Name = "txtCity";
            txtCity.PlaceholderText = "Cidade";
            txtCity.Size = new Size(180, 23);
            txtCity.TabIndex = 9;
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
            txtDistrict.TabIndex = 8;
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
            txtNumber.TabIndex = 6;
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
            txtStreet.TabIndex = 7;
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
            // txtCRC
            // 
            txtCRC.Location = new Point(478, 51);
            txtCRC.Name = "txtCRC";
            txtCRC.PlaceholderText = "Conselho Regional de Contabilidade";
            txtCRC.Size = new Size(250, 23);
            txtCRC.TabIndex = 4;
            // 
            // lblCRC
            // 
            lblCRC.AutoSize = true;
            lblCRC.Location = new Point(442, 54);
            lblCRC.Name = "lblCRC";
            lblCRC.Size = new Size(30, 15);
            lblCRC.TabIndex = 21;
            lblCRC.Text = "CRC";
            // 
            // txtCPF
            // 
            txtCPF.Location = new Point(84, 51);
            txtCPF.Mask = "999,999,999-99";
            txtCPF.Name = "txtCPF";
            txtCPF.Size = new Size(129, 23);
            txtCPF.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 54);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 19;
            label1.Text = "CPF";
            // 
            // txtCNPJ
            // 
            txtCNPJ.Location = new Point(269, 51);
            txtCNPJ.Mask = "99,999,999/9999-99";
            txtCNPJ.Name = "txtCNPJ";
            txtCNPJ.Size = new Size(167, 23);
            txtCNPJ.TabIndex = 3;
            // 
            // lblCNPJ
            // 
            lblCNPJ.AutoSize = true;
            lblCNPJ.Location = new Point(229, 54);
            lblCNPJ.Name = "lblCNPJ";
            lblCNPJ.Size = new Size(34, 15);
            lblCNPJ.TabIndex = 17;
            lblCNPJ.Text = "CNPJ";
            // 
            // txtAccontant
            // 
            txtAccontant.Location = new Point(84, 22);
            txtAccontant.Name = "txtAccontant";
            txtAccontant.PlaceholderText = "Nome do Contador";
            txtAccontant.Size = new Size(643, 23);
            txtAccontant.TabIndex = 1;
            // 
            // lblAccontant
            // 
            lblAccontant.AutoSize = true;
            lblAccontant.Location = new Point(6, 25);
            lblAccontant.Name = "lblAccontant";
            lblAccontant.Size = new Size(57, 15);
            lblAccontant.TabIndex = 10;
            lblAccontant.Text = "Contador";
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Checked = true;
            chkActive.CheckState = CheckState.Checked;
            chkActive.Location = new Point(6, 277);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(54, 19);
            chkActive.TabIndex = 0;
            chkActive.Text = "Ativo";
            // 
            // dgvAccountants
            // 
            dgvAccountants.AllowUserToAddRows = false;
            dgvAccountants.AllowUserToDeleteRows = false;
            dgvAccountants.AllowUserToResizeColumns = false;
            dgvAccountants.AllowUserToResizeRows = false;
            dgvAccountants.Location = new Point(12, 370);
            dgvAccountants.MultiSelect = false;
            dgvAccountants.Name = "dgvAccountants";
            dgvAccountants.ReadOnly = true;
            dgvAccountants.RowHeadersVisible = false;
            dgvAccountants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAccountants.Size = new Size(765, 189);
            dgvAccountants.TabIndex = 2;
            dgvAccountants.CellDoubleClick += dgvAccountants_CellDoubleClick;
            // 
            // gbFilter
            // 
            gbFilter.Controls.Add(lblSearch);
            gbFilter.Controls.Add(txtSearch);
            gbFilter.Controls.Add(rbAll);
            gbFilter.Controls.Add(rbActive);
            gbFilter.Controls.Add(rbInactive);
            gbFilter.Location = new Point(12, 314);
            gbFilter.Name = "gbFilter";
            gbFilter.Size = new Size(765, 50);
            gbFilter.TabIndex = 8;
            gbFilter.TabStop = false;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(10, 23);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(57, 15);
            lblSearch.TabIndex = 4;
            lblSearch.Text = "Contador";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(77, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(410, 23);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // rbAll
            // 
            rbAll.AutoSize = true;
            rbAll.Checked = true;
            rbAll.Location = new Point(643, 20);
            rbAll.Name = "rbAll";
            rbAll.Size = new Size(56, 19);
            rbAll.TabIndex = 1;
            rbAll.TabStop = true;
            rbAll.Text = "Todos";
            rbAll.CheckedChanged += rbAll_CheckedChanged;
            // 
            // rbActive
            // 
            rbActive.AutoSize = true;
            rbActive.Location = new Point(498, 20);
            rbActive.Name = "rbActive";
            rbActive.Size = new Size(58, 19);
            rbActive.TabIndex = 2;
            rbActive.Text = "Ativos";
            rbActive.CheckedChanged += rbActive_CheckedChanged;
            // 
            // rbInactive
            // 
            rbInactive.AutoSize = true;
            rbInactive.Location = new Point(562, 20);
            rbInactive.Name = "rbInactive";
            rbInactive.Size = new Size(66, 19);
            rbInactive.TabIndex = 3;
            rbInactive.Text = "Inativos";
            rbInactive.CheckedChanged += rbInactive_CheckedChanged;
            // 
            // AccountantForm
            // 
            ClientSize = new Size(790, 561);
            Controls.Add(gbFilter);
            Controls.Add(dgvAccountants);
            Controls.Add(gbAccountant);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AccountantForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Contador";
            Load += AccountantForm_Load;
            gbAccountant.ResumeLayout(false);
            gbAccountant.PerformLayout();
            grpContact.ResumeLayout(false);
            grpContact.PerformLayout();
            grpAddress.ResumeLayout(false);
            grpAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccountants).EndInit();
            gbFilter.ResumeLayout(false);
            gbFilter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtAccontant;
        private Label lblAccontant;
        private MaskedTextBox txtCPF;
        private Label label1;
        private MaskedTextBox txtCNPJ;
        private Label lblCNPJ;
        private TextBox txtCRC;
        private Label lblCRC;
        private GroupBox grpAddress;
        private MaskedTextBox txtCEP;
        private TextBox txtUF;
        private Label lblUF;
        private TextBox txtCity;
        private Label lblCity;
        private Label lblCEP;
        private TextBox txtDistrict;
        private Label lblDistrict;
        private TextBox txtNumber;
        private Label lblNumber;
        private TextBox txtStreet;
        private Label lblStreet;
        private GroupBox grpContact;
        private TextBox txtEmail;
        private Label lblEmail;
        private MaskedTextBox txtPhone;
        private Label lblPhone;
        private FontAwesome.Sharp.IconButton btnClean;
        private FontAwesome.Sharp.IconButton btnSave;
        private GroupBox gbFilter;
        private Label lblSearch;
        private TextBox txtSearch;
        private RadioButton rbAll;
        private RadioButton rbActive;
        private RadioButton rbInactive;
    }
}