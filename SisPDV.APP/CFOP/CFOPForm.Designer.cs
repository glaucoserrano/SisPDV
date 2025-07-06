namespace SisPDV.APP.CFOP
{
    partial class CFOPForm
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
            grbCadastro = new GroupBox();
            chkActive = new CheckBox();
            btnClean = new FontAwesome.Sharp.IconButton();
            btnSave = new FontAwesome.Sharp.IconButton();
            txtNotes = new TextBox();
            lblNotes = new Label();
            txtDescription = new TextBox();
            lblDescription = new Label();
            txtCode = new TextBox();
            lblCode = new Label();
            panel1 = new Panel();
            dgvSearchCFOP = new DataGridView();
            txtSearchDescription = new TextBox();
            label1 = new Label();
            grbRadio = new GroupBox();
            rdbAll = new RadioButton();
            rdbInactive = new RadioButton();
            rdbActive = new RadioButton();
            grbCadastro.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSearchCFOP).BeginInit();
            grbRadio.SuspendLayout();
            SuspendLayout();
            // 
            // grbCadastro
            // 
            grbCadastro.Controls.Add(chkActive);
            grbCadastro.Controls.Add(btnClean);
            grbCadastro.Controls.Add(btnSave);
            grbCadastro.Controls.Add(txtNotes);
            grbCadastro.Controls.Add(lblNotes);
            grbCadastro.Controls.Add(txtDescription);
            grbCadastro.Controls.Add(lblDescription);
            grbCadastro.Controls.Add(txtCode);
            grbCadastro.Controls.Add(lblCode);
            grbCadastro.Location = new Point(12, 12);
            grbCadastro.Name = "grbCadastro";
            grbCadastro.Size = new Size(664, 137);
            grbCadastro.TabIndex = 2;
            grbCadastro.TabStop = false;
            grbCadastro.Text = "Cadastro";
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Checked = true;
            chkActive.CheckState = CheckState.Checked;
            chkActive.Location = new Point(6, 112);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(54, 19);
            chkActive.TabIndex = 28;
            chkActive.Text = "Ativo";
            chkActive.UseVisualStyleBackColor = true;
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
            btnClean.Location = new Point(499, 109);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(75, 23);
            btnClean.TabIndex = 27;
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
            btnSave.Location = new Point(580, 109);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 26;
            btnSave.Text = "   Salvar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(99, 50);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(556, 53);
            txtNotes.TabIndex = 5;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(6, 53);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(74, 15);
            lblNotes.TabIndex = 4;
            lblNotes.Text = "Observações";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(269, 16);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(386, 23);
            txtDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(205, 19);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(58, 15);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Descrição";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(99, 16);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(100, 23);
            txtCode.TabIndex = 1;
            txtCode.KeyPress += txtCode_KeyPress;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Location = new Point(6, 19);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(87, 15);
            lblCode.TabIndex = 0;
            lblCode.Text = "Código (CFOP)";
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvSearchCFOP);
            panel1.Controls.Add(txtSearchDescription);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 155);
            panel1.Name = "panel1";
            panel1.Size = new Size(664, 205);
            panel1.TabIndex = 3;
            // 
            // dgvSearchCFOP
            // 
            dgvSearchCFOP.AllowUserToAddRows = false;
            dgvSearchCFOP.AllowUserToDeleteRows = false;
            dgvSearchCFOP.AllowUserToResizeColumns = false;
            dgvSearchCFOP.AllowUserToResizeRows = false;
            dgvSearchCFOP.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSearchCFOP.Location = new Point(9, 44);
            dgvSearchCFOP.Name = "dgvSearchCFOP";
            dgvSearchCFOP.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvSearchCFOP.Size = new Size(646, 152);
            dgvSearchCFOP.TabIndex = 30;
            dgvSearchCFOP.CellDoubleClick += dgvSearchCFOP_CellDoubleClick;
            // 
            // txtSearchDescription
            // 
            txtSearchDescription.Location = new Point(70, 15);
            txtSearchDescription.Name = "txtSearchDescription";
            txtSearchDescription.Size = new Size(369, 23);
            txtSearchDescription.TabIndex = 5;
            txtSearchDescription.TextChanged += txtSearchDescription_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 18);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 4;
            label1.Text = "Descrição";
            // 
            // grbRadio
            // 
            grbRadio.Controls.Add(rdbAll);
            grbRadio.Controls.Add(rdbInactive);
            grbRadio.Controls.Add(rdbActive);
            grbRadio.Location = new Point(457, 158);
            grbRadio.Name = "grbRadio";
            grbRadio.Size = new Size(208, 39);
            grbRadio.TabIndex = 4;
            grbRadio.TabStop = false;
            // 
            // rdbAll
            // 
            rdbAll.AutoSize = true;
            rdbAll.Checked = true;
            rdbAll.Location = new Point(146, 13);
            rdbAll.Name = "rdbAll";
            rdbAll.Size = new Size(56, 19);
            rdbAll.TabIndex = 2;
            rdbAll.TabStop = true;
            rdbAll.Text = "Todos";
            rdbAll.UseVisualStyleBackColor = true;
            rdbAll.CheckedChanged += rdbAll_CheckedChanged;
            // 
            // rdbInactive
            // 
            rdbInactive.AutoSize = true;
            rdbInactive.Location = new Point(70, 13);
            rdbInactive.Name = "rdbInactive";
            rdbInactive.Size = new Size(66, 19);
            rdbInactive.TabIndex = 1;
            rdbInactive.Text = "Inativos";
            rdbInactive.UseVisualStyleBackColor = true;
            rdbInactive.CheckedChanged += rdbInactive_CheckedChanged;
            // 
            // rdbActive
            // 
            rdbActive.AutoSize = true;
            rdbActive.Location = new Point(6, 13);
            rdbActive.Name = "rdbActive";
            rdbActive.Size = new Size(58, 19);
            rdbActive.TabIndex = 0;
            rdbActive.Text = "Ativos";
            rdbActive.UseVisualStyleBackColor = true;
            rdbActive.CheckedChanged += rdbActive_CheckedChanged;
            // 
            // CFOPForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(691, 367);
            Controls.Add(grbRadio);
            Controls.Add(panel1);
            Controls.Add(grbCadastro);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CFOPForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de CFOP";
            Load += CFOPForm_Load;
            grbCadastro.ResumeLayout(false);
            grbCadastro.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSearchCFOP).EndInit();
            grbRadio.ResumeLayout(false);
            grbRadio.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grbCadastro;
        private TextBox txtNotes;
        private Label lblNotes;
        private TextBox txtDescription;
        private Label lblDescription;
        private TextBox txtCode;
        private Label lblCode;
        private CheckBox chkActive;
        private FontAwesome.Sharp.IconButton btnClean;
        private FontAwesome.Sharp.IconButton btnSave;
        private Panel panel1;
        private DataGridView dgvSearchCFOP;
        private TextBox txtSearchDescription;
        private Label label1;
        private GroupBox grbRadio;
        private RadioButton rdbAll;
        private RadioButton rdbInactive;
        private RadioButton rdbActive;
    }
}