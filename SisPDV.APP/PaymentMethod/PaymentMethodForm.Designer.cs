namespace SisPDV.APP.PaymentMethod
{
    partial class PaymentMethodForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblSefazCode;
        private System.Windows.Forms.ComboBox cmbSefazCode;
        private System.Windows.Forms.CheckBox chkActive;

        private System.Windows.Forms.GroupBox gbForm;
        private System.Windows.Forms.GroupBox gbGrid;

        private System.Windows.Forms.DataGridView dgvPayments;

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.RadioButton rbInactive;


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
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblSefazCode = new Label();
            cmbSefazCode = new ComboBox();
            chkActive = new CheckBox();
            gbForm = new GroupBox();
            btnClean = new FontAwesome.Sharp.IconButton();
            btnSave = new FontAwesome.Sharp.IconButton();
            lblSearch = new Label();
            txtSearch = new TextBox();
            rbAll = new RadioButton();
            rbActive = new RadioButton();
            rbInactive = new RadioButton();
            dgvPayments = new DataGridView();
            gbGrid = new GroupBox();
            gbForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            gbGrid.SuspendLayout();
            SuspendLayout();
            // 
            // lblDescription
            // 
            lblDescription.Location = new Point(6, 25);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(68, 20);
            lblDescription.TabIndex = 0;
            lblDescription.Text = "Descrição";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(75, 22);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(300, 23);
            txtDescription.TabIndex = 1;
            // 
            // lblSefazCode
            // 
            lblSefazCode.Location = new Point(477, 25);
            lblSefazCode.Name = "lblSefazCode";
            lblSefazCode.Size = new Size(100, 20);
            lblSefazCode.TabIndex = 4;
            lblSefazCode.Text = "Código SEFAZ";
            // 
            // cmbSefazCode
            // 
            cmbSefazCode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSefazCode.Location = new Point(583, 22);
            cmbSefazCode.Name = "cmbSefazCode";
            cmbSefazCode.Size = new Size(197, 23);
            cmbSefazCode.TabIndex = 5;
            // 
            // chkActive
            // 
            chkActive.Checked = true;
            chkActive.CheckState = CheckState.Checked;
            chkActive.Location = new Point(10, 59);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(60, 25);
            chkActive.TabIndex = 6;
            chkActive.Text = "Ativo";
            // 
            // gbForm
            // 
            gbForm.Controls.Add(btnClean);
            gbForm.Controls.Add(btnSave);
            gbForm.Controls.Add(lblDescription);
            gbForm.Controls.Add(txtDescription);
            gbForm.Controls.Add(lblSefazCode);
            gbForm.Controls.Add(cmbSefazCode);
            gbForm.Controls.Add(chkActive);
            gbForm.Location = new Point(10, 10);
            gbForm.Name = "gbForm";
            gbForm.Size = new Size(800, 90);
            gbForm.TabIndex = 0;
            gbForm.TabStop = false;
            gbForm.Text = "Cadastro";
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
            btnClean.Location = new Point(610, 61);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(75, 23);
            btnClean.TabIndex = 29;
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
            btnSave.Location = new Point(705, 61);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 28;
            btnSave.Text = "   Salvar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // lblSearch
            // 
            lblSearch.Location = new Point(20, 25);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(50, 20);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Buscar:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(75, 22);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(250, 23);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // rbAll
            // 
            rbAll.Checked = true;
            rbAll.Location = new Point(600, 22);
            rbAll.Name = "rbAll";
            rbAll.Size = new Size(104, 24);
            rbAll.TabIndex = 2;
            rbAll.TabStop = true;
            rbAll.Text = "Todos";
            rbAll.CheckedChanged += rbAll_CheckedChanged;
            // 
            // rbActive
            // 
            rbActive.Location = new Point(370, 22);
            rbActive.Name = "rbActive";
            rbActive.Size = new Size(104, 24);
            rbActive.TabIndex = 3;
            rbActive.Text = "Ativos";
            rbActive.CheckedChanged += rbActive_CheckedChanged;
            // 
            // rbInactive
            // 
            rbInactive.Location = new Point(490, 22);
            rbInactive.Name = "rbInactive";
            rbInactive.Size = new Size(104, 24);
            rbInactive.TabIndex = 4;
            rbInactive.Text = "Inativos";
            rbInactive.CheckedChanged += rbInactive_CheckedChanged;
            // 
            // dgvPayments
            // 
            dgvPayments.AllowUserToAddRows = false;
            dgvPayments.AllowUserToDeleteRows = false;
            dgvPayments.Location = new Point(20, 60);
            dgvPayments.MultiSelect = false;
            dgvPayments.Name = "dgvPayments";
            dgvPayments.ReadOnly = true;
            dgvPayments.RowHeadersVisible = false;
            dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayments.Size = new Size(760, 268);
            dgvPayments.TabIndex = 5;
            dgvPayments.CellDoubleClick += dgvPayments_CellDoubleClick;
            // 
            // gbGrid
            // 
            gbGrid.Controls.Add(lblSearch);
            gbGrid.Controls.Add(txtSearch);
            gbGrid.Controls.Add(rbAll);
            gbGrid.Controls.Add(rbActive);
            gbGrid.Controls.Add(rbInactive);
            gbGrid.Controls.Add(dgvPayments);
            gbGrid.Location = new Point(10, 106);
            gbGrid.Name = "gbGrid";
            gbGrid.Size = new Size(800, 342);
            gbGrid.TabIndex = 1;
            gbGrid.TabStop = false;
            gbGrid.Text = "Formas de Pagamento Cadastradas";
            // 
            // PaymentMethodForm
            // 
            ClientSize = new Size(820, 460);
            Controls.Add(gbForm);
            Controls.Add(gbGrid);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PaymentMethodForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Formas de Pagamento";
            Load += PaymentMethodForm_Load;
            gbForm.ResumeLayout(false);
            gbForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            gbGrid.ResumeLayout(false);
            gbGrid.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnClean;
        private FontAwesome.Sharp.IconButton btnSave;
    }
}