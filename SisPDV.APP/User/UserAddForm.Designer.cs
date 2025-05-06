namespace SisPDV.APP.User
{
    partial class UserAddForm
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
            tabControl = new TabControl();
            tabRegister = new TabPage();
            groupRegister = new GroupBox();
            btnClean = new FontAwesome.Sharp.IconButton();
            btnSave = new FontAwesome.Sharp.IconButton();
            txtPassword = new TextBox();
            txtUser = new TextBox();
            txtName = new TextBox();
            chkActive = new CheckBox();
            lblPassword = new Label();
            lblLogin = new Label();
            lblName = new Label();
            tabConsult = new TabPage();
            groupBox1 = new GroupBox();
            btnSearch = new FontAwesome.Sharp.IconButton();
            chkSearchActive = new CheckBox();
            txtSearchLogin = new TextBox();
            dgvSearch = new DataGridView();
            txtSearchName = new TextBox();
            tabControl.SuspendLayout();
            tabRegister.SuspendLayout();
            groupRegister.SuspendLayout();
            tabConsult.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSearch).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Alignment = TabAlignment.Bottom;
            tabControl.Controls.Add(tabRegister);
            tabControl.Controls.Add(tabConsult);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(384, 261);
            tabControl.TabIndex = 0;
            // 
            // tabRegister
            // 
            tabRegister.BackColor = SystemColors.Control;
            tabRegister.Controls.Add(groupRegister);
            tabRegister.Location = new Point(4, 4);
            tabRegister.Name = "tabRegister";
            tabRegister.Padding = new Padding(3);
            tabRegister.Size = new Size(376, 233);
            tabRegister.TabIndex = 0;
            tabRegister.Text = "Cadastro";
            // 
            // groupRegister
            // 
            groupRegister.BackColor = SystemColors.Control;
            groupRegister.Controls.Add(btnClean);
            groupRegister.Controls.Add(btnSave);
            groupRegister.Controls.Add(txtPassword);
            groupRegister.Controls.Add(txtUser);
            groupRegister.Controls.Add(txtName);
            groupRegister.Controls.Add(chkActive);
            groupRegister.Controls.Add(lblPassword);
            groupRegister.Controls.Add(lblLogin);
            groupRegister.Controls.Add(lblName);
            groupRegister.Dock = DockStyle.Fill;
            groupRegister.Location = new Point(3, 3);
            groupRegister.Name = "groupRegister";
            groupRegister.Size = new Size(370, 227);
            groupRegister.TabIndex = 0;
            groupRegister.TabStop = false;
            groupRegister.Text = "Cadastro";
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
            btnClean.Location = new Point(206, 180);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(75, 23);
            btnClean.TabIndex = 8;
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
            btnSave.Location = new Point(287, 180);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 7;
            btnSave.Text = "   Salvar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(59, 91);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Senha";
            txtPassword.Size = new Size(303, 23);
            txtPassword.TabIndex = 6;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(59, 62);
            txtUser.Name = "txtUser";
            txtUser.PlaceholderText = "Usuário";
            txtUser.Size = new Size(303, 23);
            txtUser.TabIndex = 5;
            // 
            // txtName
            // 
            txtName.BackColor = SystemColors.ControlLightLight;
            txtName.Location = new Point(59, 33);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Nome";
            txtName.Size = new Size(303, 23);
            txtName.TabIndex = 4;
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Checked = true;
            chkActive.CheckState = CheckState.Checked;
            chkActive.Location = new Point(308, 131);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(54, 19);
            chkActive.TabIndex = 3;
            chkActive.Text = "Ativo";
            chkActive.UseVisualStyleBackColor = true;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(6, 94);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(39, 15);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Senha";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(6, 65);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(47, 15);
            lblLogin.TabIndex = 1;
            lblLogin.Text = "Usuário";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(6, 36);
            lblName.Name = "lblName";
            lblName.Size = new Size(40, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Nome";
            // 
            // tabConsult
            // 
            tabConsult.Controls.Add(groupBox1);
            tabConsult.Location = new Point(4, 4);
            tabConsult.Name = "tabConsult";
            tabConsult.Padding = new Padding(3);
            tabConsult.Size = new Size(376, 233);
            tabConsult.TabIndex = 1;
            tabConsult.Text = "Consulta";
            tabConsult.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Control;
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(chkSearchActive);
            groupBox1.Controls.Add(txtSearchLogin);
            groupBox1.Controls.Add(dgvSearch);
            groupBox1.Controls.Add(txtSearchName);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(370, 227);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Consulta";
            // 
            // btnSearch
            // 
            btnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnSearch.IconColor = Color.Black;
            btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSearch.IconSize = 16;
            btnSearch.Location = new Point(333, 22);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(31, 24);
            btnSearch.TabIndex = 5;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // chkSearchActive
            // 
            chkSearchActive.AutoSize = true;
            chkSearchActive.Checked = true;
            chkSearchActive.CheckState = CheckState.Checked;
            chkSearchActive.Location = new Point(270, 24);
            chkSearchActive.Name = "chkSearchActive";
            chkSearchActive.Size = new Size(59, 19);
            chkSearchActive.TabIndex = 4;
            chkSearchActive.Text = "Ativos";
            chkSearchActive.UseVisualStyleBackColor = true;
            // 
            // txtSearchLogin
            // 
            txtSearchLogin.Location = new Point(138, 22);
            txtSearchLogin.Name = "txtSearchLogin";
            txtSearchLogin.PlaceholderText = "Consultar por Usuário";
            txtSearchLogin.Size = new Size(126, 23);
            txtSearchLogin.TabIndex = 3;
            // 
            // dgvSearch
            // 
            dgvSearch.AllowUserToAddRows = false;
            dgvSearch.AllowUserToDeleteRows = false;
            dgvSearch.AllowUserToResizeColumns = false;
            dgvSearch.AllowUserToResizeRows = false;
            dgvSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSearch.Location = new Point(6, 51);
            dgvSearch.Name = "dgvSearch";
            dgvSearch.ReadOnly = true;
            dgvSearch.RowHeadersVisible = false;
            dgvSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSearch.Size = new Size(359, 168);
            dgvSearch.TabIndex = 2;
            dgvSearch.CellDoubleClick += dgvSearch_CellDoubleClick;
            // 
            // txtSearchName
            // 
            txtSearchName.Location = new Point(6, 22);
            txtSearchName.Name = "txtSearchName";
            txtSearchName.PlaceholderText = "Consultar por Nome";
            txtSearchName.Size = new Size(126, 23);
            txtSearchName.TabIndex = 1;
            // 
            // UserAddForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 261);
            Controls.Add(tabControl);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserAddForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Usuários";
            tabControl.ResumeLayout(false);
            tabRegister.ResumeLayout(false);
            groupRegister.ResumeLayout(false);
            groupRegister.PerformLayout();
            tabConsult.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSearch).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabRegister;
        private GroupBox groupRegister;
        private TabPage tabConsult;
        private FontAwesome.Sharp.IconButton btnSave;
        private TextBox txtPassword;
        private TextBox txtUser;
        private TextBox txtName;
        private CheckBox chkActive;
        private Label lblPassword;
        private Label lblLogin;
        private Label lblName;
        private FontAwesome.Sharp.IconButton btnClean;
        private GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton btnSearch;
        private CheckBox chkSearchActive;
        private TextBox txtSearchLogin;
        private DataGridView dgvSearch;
        private TextBox txtSearchName;
    }
}