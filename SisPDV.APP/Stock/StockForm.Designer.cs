namespace SisPDV.APP.Stock
{
    partial class StockForm
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.TextBox txtProductSearch;
        private System.Windows.Forms.Label lblMinStock;
        private System.Windows.Forms.TextBox txtMinStock;
        private System.Windows.Forms.Label lblMaxStock;
        private System.Windows.Forms.TextBox txtMaxStock;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.DataGridView dgvStock;
        
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
            lblProduct = new Label();
            txtProductSearch = new TextBox();
            lblMinStock = new Label();
            txtMinStock = new TextBox();
            lblMaxStock = new Label();
            txtMaxStock = new TextBox();
            lblLocation = new Label();
            txtLocation = new TextBox();
            dgvStock = new DataGridView();
            btnClean = new FontAwesome.Sharp.IconButton();
            btnSave = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dgvStock).BeginInit();
            SuspendLayout();
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Location = new Point(20, 20);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(50, 15);
            lblProduct.TabIndex = 0;
            lblProduct.Text = "Produto";
            // 
            // txtProductSearch
            // 
            txtProductSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtProductSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtProductSearch.Location = new Point(94, 17);
            txtProductSearch.Name = "txtProductSearch";
            txtProductSearch.Size = new Size(400, 23);
            txtProductSearch.TabIndex = 1;
            txtProductSearch.TextChanged += txtProductSearch_TextChanged;
            // 
            // lblMinStock
            // 
            lblMinStock.AutoSize = true;
            lblMinStock.Location = new Point(500, 20);
            lblMinStock.Name = "lblMinStock";
            lblMinStock.Size = new Size(94, 15);
            lblMinStock.TabIndex = 2;
            lblMinStock.Text = "Estoque Mínimo";
            // 
            // txtMinStock
            // 
            txtMinStock.Location = new Point(600, 17);
            txtMinStock.Name = "txtMinStock";
            txtMinStock.Size = new Size(80, 23);
            txtMinStock.TabIndex = 3;
            txtMinStock.TextAlign = HorizontalAlignment.Right;
            // 
            // lblMaxStock
            // 
            lblMaxStock.AutoSize = true;
            lblMaxStock.Location = new Point(700, 20);
            lblMaxStock.Name = "lblMaxStock";
            lblMaxStock.Size = new Size(96, 15);
            lblMaxStock.TabIndex = 4;
            lblMaxStock.Text = "Estoque Máximo";
            // 
            // txtMaxStock
            // 
            txtMaxStock.Location = new Point(800, 17);
            txtMaxStock.Name = "txtMaxStock";
            txtMaxStock.Size = new Size(80, 23);
            txtMaxStock.TabIndex = 5;
            txtMaxStock.TextAlign = HorizontalAlignment.Right;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(20, 55);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(68, 15);
            lblLocation.TabIndex = 6;
            lblLocation.Text = "Localização";
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(94, 52);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(400, 23);
            txtLocation.TabIndex = 7;
            // 
            // dgvStock
            // 
            dgvStock.AllowUserToAddRows = false;
            dgvStock.AllowUserToDeleteRows = false;
            dgvStock.AllowUserToResizeRows = false;
            dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStock.Location = new Point(20, 90);
            dgvStock.Name = "dgvStock";
            dgvStock.ReadOnly = true;
            dgvStock.RowHeadersVisible = false;
            dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStock.Size = new Size(860, 400);
            dgvStock.TabIndex = 10;
            dgvStock.CellDoubleClick += dgvStock_CellDoubleClick;
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
            btnClean.Location = new Point(719, 51);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(75, 23);
            btnClean.TabIndex = 31;
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
            btnSave.Location = new Point(800, 51);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 30;
            btnSave.Text = "   Salvar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // StockForm
            // 
            ClientSize = new Size(900, 510);
            Controls.Add(btnClean);
            Controls.Add(btnSave);
            Controls.Add(lblProduct);
            Controls.Add(txtProductSearch);
            Controls.Add(lblMinStock);
            Controls.Add(txtMinStock);
            Controls.Add(lblMaxStock);
            Controls.Add(txtMaxStock);
            Controls.Add(lblLocation);
            Controls.Add(txtLocation);
            Controls.Add(dgvStock);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StockForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Estoque";
            Load += StockForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnClean;
        private FontAwesome.Sharp.IconButton btnSave;
    }
}