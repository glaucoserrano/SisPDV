namespace SisPDV.APP.Categories
{
    partial class CategoriesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label lblDescription;
        private TextBox txtDescription;

        private CheckBox chkActive;

        private GroupBox gbFilter;
        private TextBox txtSearch;
        private RadioButton rbAll;
        private RadioButton rbActive;
        private RadioButton rbInactive;

        private DataGridView dgvCategory;

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
            chkActive = new CheckBox();
            gbFilter = new GroupBox();
            lblSearch = new Label();
            txtSearch = new TextBox();
            rbAll = new RadioButton();
            rbActive = new RadioButton();
            rbInactive = new RadioButton();
            dgvCategory = new DataGridView();
            btnClean = new FontAwesome.Sharp.IconButton();
            btnSave = new FontAwesome.Sharp.IconButton();
            gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategory).BeginInit();
            SuspendLayout();
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(22, 15);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(61, 15);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Descrição:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(89, 12);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(410, 23);
            txtDescription.TabIndex = 3;
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Checked = true;
            chkActive.CheckState = CheckState.Checked;
            chkActive.Location = new Point(510, 14);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(54, 19);
            chkActive.TabIndex = 4;
            chkActive.Text = "Ativo";
            chkActive.UseVisualStyleBackColor = true;
            // 
            // gbFilter
            // 
            gbFilter.Controls.Add(lblSearch);
            gbFilter.Controls.Add(txtSearch);
            gbFilter.Controls.Add(rbAll);
            gbFilter.Controls.Add(rbActive);
            gbFilter.Controls.Add(rbInactive);
            gbFilter.Location = new Point(12, 45);
            gbFilter.Name = "gbFilter";
            gbFilter.Size = new Size(780, 50);
            gbFilter.TabIndex = 7;
            gbFilter.TabStop = false;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(10, 23);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(61, 15);
            lblSearch.TabIndex = 4;
            lblSearch.Text = "Descrição:";
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
            // dgvCategory
            // 
            dgvCategory.AllowUserToAddRows = false;
            dgvCategory.AllowUserToDeleteRows = false;
            dgvCategory.AllowUserToResizeColumns = false;
            dgvCategory.AllowUserToResizeRows = false;
            dgvCategory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategory.Location = new Point(12, 105);
            dgvCategory.Name = "dgvCategory";
            dgvCategory.Size = new Size(780, 350);
            dgvCategory.TabIndex = 8;
            dgvCategory.CellDoubleClick += dgvCategory_CellDoubleClick;
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
            btnClean.Location = new Point(636, 12);
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
            btnSave.Location = new Point(717, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 28;
            btnSave.Text = "   Salvar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // CategoriesForm
            // 
            ClientSize = new Size(804, 471);
            Controls.Add(btnClean);
            Controls.Add(btnSave);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(chkActive);
            Controls.Add(gbFilter);
            Controls.Add(dgvCategory);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CategoriesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Categorias";
            Load += CategoriesForm_Load;
            gbFilter.ResumeLayout(false);
            gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSearch;
        private FontAwesome.Sharp.IconButton btnClean;
        private FontAwesome.Sharp.IconButton btnSave;
    }
}