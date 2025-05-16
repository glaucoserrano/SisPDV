namespace SisPDV.APP.Products.TypeProductsMenu
{
    partial class TypeProductsForm
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
            grpFields = new GroupBox();
            btnClean = new FontAwesome.Sharp.IconButton();
            btnSave = new FontAwesome.Sharp.IconButton();
            txtNotes = new TextBox();
            lblNotes = new Label();
            cmbCSTCOFINS = new ComboBox();
            lblCSTCOFINS = new Label();
            cmbCSTPIS = new ComboBox();
            lblCSTPIS = new Label();
            cmbCST_CSOSN = new ComboBox();
            lblCST = new Label();
            txtCFOP = new TextBox();
            lblCFOP = new Label();
            cmbOrigin = new ComboBox();
            lblOrigin = new Label();
            txtIVA = new TextBox();
            lblIVA = new Label();
            txtNCM = new TextBox();
            lblNCM = new Label();
            txtTypeName = new TextBox();
            lblTypeName = new Label();
            grpList = new GroupBox();
            dgvTypes = new DataGridView();
            grpFields.SuspendLayout();
            grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTypes).BeginInit();
            SuspendLayout();
            // 
            // grpFields
            // 
            grpFields.Controls.Add(btnClean);
            grpFields.Controls.Add(btnSave);
            grpFields.Controls.Add(txtNotes);
            grpFields.Controls.Add(lblNotes);
            grpFields.Controls.Add(cmbCSTCOFINS);
            grpFields.Controls.Add(lblCSTCOFINS);
            grpFields.Controls.Add(cmbCSTPIS);
            grpFields.Controls.Add(lblCSTPIS);
            grpFields.Controls.Add(cmbCST_CSOSN);
            grpFields.Controls.Add(lblCST);
            grpFields.Controls.Add(txtCFOP);
            grpFields.Controls.Add(lblCFOP);
            grpFields.Controls.Add(cmbOrigin);
            grpFields.Controls.Add(lblOrigin);
            grpFields.Controls.Add(txtIVA);
            grpFields.Controls.Add(lblIVA);
            grpFields.Controls.Add(txtNCM);
            grpFields.Controls.Add(lblNCM);
            grpFields.Controls.Add(txtTypeName);
            grpFields.Controls.Add(lblTypeName);
            grpFields.Location = new Point(10, 10);
            grpFields.Name = "grpFields";
            grpFields.Size = new Size(860, 256);
            grpFields.TabIndex = 0;
            grpFields.TabStop = false;
            grpFields.Text = "Dados do Tipo de Produto";
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
            btnClean.Location = new Point(664, 220);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(75, 23);
            btnClean.TabIndex = 25;
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
            btnSave.Location = new Point(745, 220);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 24;
            btnSave.Text = "   Salvar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(150, 174);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(670, 40);
            txtNotes.TabIndex = 23;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(20, 177);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(74, 15);
            lblNotes.TabIndex = 22;
            lblNotes.Text = "Observações";
            // 
            // cmbCSTCOFINS
            // 
            cmbCSTCOFINS.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCSTCOFINS.FormattingEnabled = true;
            cmbCSTCOFINS.Location = new Point(570, 145);
            cmbCSTCOFINS.Name = "cmbCSTCOFINS";
            cmbCSTCOFINS.Size = new Size(250, 23);
            cmbCSTCOFINS.TabIndex = 15;
            // 
            // lblCSTCOFINS
            // 
            lblCSTCOFINS.AutoSize = true;
            lblCSTCOFINS.Location = new Point(493, 150);
            lblCSTCOFINS.Name = "lblCSTCOFINS";
            lblCSTCOFINS.Size = new Size(71, 15);
            lblCSTCOFINS.TabIndex = 14;
            lblCSTCOFINS.Text = "CST COFINS";
            // 
            // cmbCSTPIS
            // 
            cmbCSTPIS.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCSTPIS.FormattingEnabled = true;
            cmbCSTPIS.Location = new Point(150, 142);
            cmbCSTPIS.Name = "cmbCSTPIS";
            cmbCSTPIS.Size = new Size(250, 23);
            cmbCSTPIS.TabIndex = 13;
            // 
            // lblCSTPIS
            // 
            lblCSTPIS.AutoSize = true;
            lblCSTPIS.Location = new Point(20, 150);
            lblCSTPIS.Name = "lblCSTPIS";
            lblCSTPIS.Size = new Size(46, 15);
            lblCSTPIS.TabIndex = 12;
            lblCSTPIS.Text = "CST PIS";
            // 
            // cmbCST_CSOSN
            // 
            cmbCST_CSOSN.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCST_CSOSN.FormattingEnabled = true;
            cmbCST_CSOSN.Location = new Point(570, 102);
            cmbCST_CSOSN.Name = "cmbCST_CSOSN";
            cmbCST_CSOSN.Size = new Size(250, 23);
            cmbCST_CSOSN.TabIndex = 11;
            // 
            // lblCST
            // 
            lblCST.AutoSize = true;
            lblCST.Location = new Point(500, 105);
            lblCST.Name = "lblCST";
            lblCST.Size = new Size(64, 15);
            lblCST.TabIndex = 10;
            lblCST.Text = "CST/CSON";
            // 
            // txtCFOP
            // 
            txtCFOP.Location = new Point(150, 107);
            txtCFOP.Name = "txtCFOP";
            txtCFOP.Size = new Size(250, 23);
            txtCFOP.TabIndex = 9;
            // 
            // lblCFOP
            // 
            lblCFOP.AutoSize = true;
            lblCFOP.Location = new Point(20, 110);
            lblCFOP.Name = "lblCFOP";
            lblCFOP.Size = new Size(77, 15);
            lblCFOP.TabIndex = 8;
            lblCFOP.Text = "CFOP Padrão";
            // 
            // cmbOrigin
            // 
            cmbOrigin.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOrigin.FormattingEnabled = true;
            cmbOrigin.Location = new Point(570, 67);
            cmbOrigin.Name = "cmbOrigin";
            cmbOrigin.Size = new Size(250, 23);
            cmbOrigin.TabIndex = 7;
            // 
            // lblOrigin
            // 
            lblOrigin.AutoSize = true;
            lblOrigin.Location = new Point(438, 70);
            lblOrigin.Name = "lblOrigin";
            lblOrigin.Size = new Size(126, 15);
            lblOrigin.TabIndex = 6;
            lblOrigin.Text = "Origem da Mercadoria";
            // 
            // txtIVA
            // 
            txtIVA.Location = new Point(150, 67);
            txtIVA.Name = "txtIVA";
            txtIVA.Size = new Size(250, 23);
            txtIVA.TabIndex = 5;
            txtIVA.KeyPress += txtIVA_KeyPress;
            // 
            // lblIVA
            // 
            lblIVA.AutoSize = true;
            lblIVA.Location = new Point(20, 70);
            lblIVA.Name = "lblIVA";
            lblIVA.Size = new Size(45, 15);
            lblIVA.TabIndex = 4;
            lblIVA.Text = "IVA (%)";
            // 
            // txtNCM
            // 
            txtNCM.Location = new Point(570, 27);
            txtNCM.Name = "txtNCM";
            txtNCM.Size = new Size(250, 23);
            txtNCM.TabIndex = 3;
            txtNCM.KeyPress += txtNCM_KeyPress;
            // 
            // lblNCM
            // 
            lblNCM.AutoSize = true;
            lblNCM.Location = new Point(529, 30);
            lblNCM.Name = "lblNCM";
            lblNCM.Size = new Size(35, 15);
            lblNCM.TabIndex = 2;
            lblNCM.Text = "NCM";
            // 
            // txtTypeName
            // 
            txtTypeName.Location = new Point(150, 27);
            txtTypeName.Name = "txtTypeName";
            txtTypeName.Size = new Size(250, 23);
            txtTypeName.TabIndex = 1;
            // 
            // lblTypeName
            // 
            lblTypeName.AutoSize = true;
            lblTypeName.Location = new Point(20, 30);
            lblTypeName.Name = "lblTypeName";
            lblTypeName.Size = new Size(92, 15);
            lblTypeName.TabIndex = 0;
            lblTypeName.Text = "Tipo de Produto";
            // 
            // grpList
            // 
            grpList.Controls.Add(dgvTypes);
            grpList.Location = new Point(10, 272);
            grpList.Name = "grpList";
            grpList.Size = new Size(860, 330);
            grpList.TabIndex = 1;
            grpList.TabStop = false;
            grpList.Text = "Tipos Cadastrados";
            // 
            // dgvTypes
            // 
            dgvTypes.AllowUserToAddRows = false;
            dgvTypes.AllowUserToDeleteRows = false;
            dgvTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTypes.Location = new Point(10, 25);
            dgvTypes.Name = "dgvTypes";
            dgvTypes.ReadOnly = true;
            dgvTypes.RowHeadersVisible = false;
            dgvTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTypes.Size = new Size(840, 294);
            dgvTypes.TabIndex = 0;
            dgvTypes.CellDoubleClick += dgvTypes_CellDoubleClick;
            // 
            // TypeProductsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(884, 611);
            Controls.Add(grpList);
            Controls.Add(grpFields);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TypeProductsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tipo de Produtos";
            Load += TypeProductsForm_Load;
            grpFields.ResumeLayout(false);
            grpFields.PerformLayout();
            grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTypes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpFields;
        private Label lblNCM;
        private TextBox txtTypeName;
        private Label lblTypeName;
        private ComboBox cmbOrigin;
        private Label lblOrigin;
        private TextBox txtIVA;
        private Label lblIVA;
        private TextBox txtNCM;
        private Label lblCST;
        private TextBox txtCFOP;
        private Label lblCFOP;
        private ComboBox cmbCSTPIS;
        private Label lblCSTPIS;
        private ComboBox cmbCST_CSOSN;
        private ComboBox cmbCSTCOFINS;
        private Label lblCSTCOFINS;
        private TextBox txtNotes;
        private Label lblNotes;
        private FontAwesome.Sharp.IconButton btnClean;
        private FontAwesome.Sharp.IconButton btnSave;
        private GroupBox grpList;
        private DataGridView dgvTypes;
    }
}