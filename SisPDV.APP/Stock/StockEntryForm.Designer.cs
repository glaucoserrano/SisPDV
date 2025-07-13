namespace SisPDV.APP.Stock
{
    partial class StockEntryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvMovements;


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
            dgvMovements = new DataGridView();
            groupBox1 = new GroupBox();
            lblCurrentStock = new Label();
            btnClean = new FontAwesome.Sharp.IconButton();
            btnSave = new FontAwesome.Sharp.IconButton();
            txtNotes = new TextBox();
            lblNotes = new Label();
            cmbMovementType = new ComboBox();
            lblMovimentType = new Label();
            txtDocumentNumber = new TextBox();
            lblDocument = new Label();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            lblQuantity = new Label();
            txtQuantity = new TextBox();
            lblProduct = new Label();
            txtProductSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvMovements).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvMovements
            // 
            dgvMovements.AllowUserToAddRows = false;
            dgvMovements.AllowUserToDeleteRows = false;
            dgvMovements.AllowUserToResizeColumns = false;
            dgvMovements.AllowUserToResizeRows = false;
            dgvMovements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMovements.Location = new Point(12, 200);
            dgvMovements.Name = "dgvMovements";
            dgvMovements.ReadOnly = true;
            dgvMovements.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvMovements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovements.Size = new Size(598, 300);
            dgvMovements.TabIndex = 14;
            dgvMovements.CellDoubleClick += dgvMovements_CellDoubleClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblCurrentStock);
            groupBox1.Controls.Add(btnClean);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(txtNotes);
            groupBox1.Controls.Add(lblNotes);
            groupBox1.Controls.Add(cmbMovementType);
            groupBox1.Controls.Add(lblMovimentType);
            groupBox1.Controls.Add(txtDocumentNumber);
            groupBox1.Controls.Add(lblDocument);
            groupBox1.Controls.Add(lblDate);
            groupBox1.Controls.Add(dtpDate);
            groupBox1.Controls.Add(lblQuantity);
            groupBox1.Controls.Add(txtQuantity);
            groupBox1.Controls.Add(lblProduct);
            groupBox1.Controls.Add(txtProductSearch);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(598, 182);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Movimentação de Estoque";
            // 
            // lblCurrentStock
            // 
            lblCurrentStock.AutoSize = true;
            lblCurrentStock.Location = new Point(415, 84);
            lblCurrentStock.Name = "lblCurrentStock";
            lblCurrentStock.Size = new Size(83, 15);
            lblCurrentStock.TabIndex = 44;
            lblCurrentStock.Text = "Estoque Atual:";
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
            btnClean.Location = new Point(436, 153);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(75, 23);
            btnClean.TabIndex = 43;
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
            btnSave.Location = new Point(517, 153);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 42;
            btnSave.Text = "   Salvar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(144, 110);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(265, 66);
            txtNotes.TabIndex = 41;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(6, 113);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(77, 15);
            lblNotes.TabIndex = 40;
            lblNotes.Text = "Observações:";
            // 
            // cmbMovementType
            // 
            cmbMovementType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMovementType.FormattingEnabled = true;
            cmbMovementType.Location = new Point(144, 81);
            cmbMovementType.Name = "cmbMovementType";
            cmbMovementType.Size = new Size(265, 23);
            cmbMovementType.TabIndex = 39;
            // 
            // lblMovimentType
            // 
            lblMovimentType.AutoSize = true;
            lblMovimentType.Location = new Point(6, 84);
            lblMovimentType.Name = "lblMovimentType";
            lblMovimentType.Size = new Size(132, 15);
            lblMovimentType.TabIndex = 38;
            lblMovimentType.Text = "Tipo de Movimentação:";
            // 
            // txtDocumentNumber
            // 
            txtDocumentNumber.Location = new Point(246, 51);
            txtDocumentNumber.Name = "txtDocumentNumber";
            txtDocumentNumber.Size = new Size(346, 23);
            txtDocumentNumber.TabIndex = 37;
            // 
            // lblDocument
            // 
            lblDocument.AutoSize = true;
            lblDocument.Location = new Point(149, 57);
            lblDocument.Name = "lblDocument";
            lblDocument.Size = new Size(90, 15);
            lblDocument.TabIndex = 36;
            lblDocument.Text = "Nº Documento:";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(6, 57);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(34, 15);
            lblDate.TabIndex = 34;
            lblDate.Text = "Data:";
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(65, 51);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(78, 23);
            dtpDate.TabIndex = 35;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(414, 25);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(72, 15);
            lblQuantity.TabIndex = 24;
            lblQuantity.Text = "Quantidade:";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(492, 22);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(100, 23);
            txtQuantity.TabIndex = 25;
            txtQuantity.TextAlign = HorizontalAlignment.Right;
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Location = new Point(6, 25);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(53, 15);
            lblProduct.TabIndex = 12;
            lblProduct.Text = "Produto:";
            // 
            // txtProductSearch
            // 
            txtProductSearch.Location = new Point(64, 22);
            txtProductSearch.Name = "txtProductSearch";
            txtProductSearch.Size = new Size(344, 23);
            txtProductSearch.TabIndex = 13;
            txtProductSearch.TextChanged += txtProductSearch_TextChanged;
            // 
            // StockEntryForm
            // 
            ClientSize = new Size(633, 507);
            Controls.Add(groupBox1);
            Controls.Add(dgvMovements);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StockEntryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Entrada / Movimentação de Estoque";
            Load += StockEntryForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMovements).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Label lblDate;
        private DateTimePicker dtpDate;
        private Label lblQuantity;
        private TextBox txtQuantity;
        private Label lblProduct;
        private TextBox txtProductSearch;
        private Label lblDocument;
        private TextBox txtNotes;
        private Label lblNotes;
        private ComboBox cmbMovementType;
        private Label lblMovimentType;
        private TextBox txtDocumentNumber;
        private FontAwesome.Sharp.IconButton btnClean;
        private FontAwesome.Sharp.IconButton btnSave;
        private Label lblCurrentStock;
    }
}