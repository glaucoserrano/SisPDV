namespace SisPDV.APP.Cash
{
    partial class CashClosingForm
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
            groupBox1 = new GroupBox();
            lblStatus = new Label();
            gbReceiptPreview = new GroupBox();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            rtbPreview = new RichTextBox();
            lblTotalInCash = new Label();
            lblDate = new Label();
            txtDate = new TextBox();
            lblCashNumber = new Label();
            txtCashNumber = new TextBox();
            btnCancel = new FontAwesome.Sharp.IconButton();
            btnCloseCash = new FontAwesome.Sharp.IconButton();
            dgvSummaryByType = new DataGridView();
            dgvSummaryByPayment = new DataGridView();
            txtTotalInCash = new TextBox();
            groupBox1.SuspendLayout();
            gbReceiptPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSummaryByType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSummaryByPayment).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblStatus);
            groupBox1.Controls.Add(gbReceiptPreview);
            groupBox1.Controls.Add(lblTotalInCash);
            groupBox1.Controls.Add(lblDate);
            groupBox1.Controls.Add(txtDate);
            groupBox1.Controls.Add(lblCashNumber);
            groupBox1.Controls.Add(txtCashNumber);
            groupBox1.Controls.Add(btnCancel);
            groupBox1.Controls.Add(btnCloseCash);
            groupBox1.Controls.Add(dgvSummaryByType);
            groupBox1.Controls.Add(dgvSummaryByPayment);
            groupBox1.Controls.Add(txtTotalInCash);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(813, 432);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(6, 407);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(230, 20);
            lblStatus.TabIndex = 31;
            lblStatus.Text = "Status: Caixa Fechado";
            // 
            // gbReceiptPreview
            // 
            gbReceiptPreview.Controls.Add(iconButton1);
            gbReceiptPreview.Controls.Add(rtbPreview);
            gbReceiptPreview.Location = new Point(412, 15);
            gbReceiptPreview.Name = "gbReceiptPreview";
            gbReceiptPreview.Size = new Size(394, 397);
            gbReceiptPreview.TabIndex = 30;
            gbReceiptPreview.TabStop = false;
            gbReceiptPreview.Text = "Visualização do Comprovante";
            // 
            // iconButton1
            // 
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.Print;
            iconButton1.IconColor = Color.SaddleBrown;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 32;
            iconButton1.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton1.Location = new Point(59, 354);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(288, 35);
            iconButton1.TabIndex = 1;
            iconButton1.Text = "Imprimir Comprovante";
            iconButton1.UseVisualStyleBackColor = true;
            // 
            // rtbPreview
            // 
            rtbPreview.BackColor = Color.White;
            rtbPreview.BorderStyle = BorderStyle.None;
            rtbPreview.Font = new Font("Consolas", 10F);
            rtbPreview.Location = new Point(6, 19);
            rtbPreview.Name = "rtbPreview";
            rtbPreview.ReadOnly = true;
            rtbPreview.Size = new Size(380, 320);
            rtbPreview.TabIndex = 0;
            rtbPreview.Text = "";
            // 
            // lblTotalInCash
            // 
            lblTotalInCash.Location = new Point(12, 85);
            lblTotalInCash.Name = "lblTotalInCash";
            lblTotalInCash.Size = new Size(114, 20);
            lblTotalInCash.TabIndex = 27;
            lblTotalInCash.Text = "Valor Fechamento:";
            // 
            // lblDate
            // 
            lblDate.Location = new Point(12, 27);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(100, 20);
            lblDate.TabIndex = 23;
            lblDate.Text = "Data:";
            // 
            // txtDate
            // 
            txtDate.Location = new Point(132, 24);
            txtDate.Name = "txtDate";
            txtDate.ReadOnly = true;
            txtDate.Size = new Size(100, 23);
            txtDate.TabIndex = 24;
            txtDate.TextAlign = HorizontalAlignment.Right;
            // 
            // lblCashNumber
            // 
            lblCashNumber.Location = new Point(12, 56);
            lblCashNumber.Name = "lblCashNumber";
            lblCashNumber.Size = new Size(100, 20);
            lblCashNumber.TabIndex = 25;
            lblCashNumber.Text = "Caixa Nº:";
            // 
            // txtCashNumber
            // 
            txtCashNumber.Location = new Point(132, 53);
            txtCashNumber.Name = "txtCashNumber";
            txtCashNumber.ReadOnly = true;
            txtCashNumber.Size = new Size(100, 23);
            txtCashNumber.TabIndex = 26;
            txtCashNumber.TextAlign = HorizontalAlignment.Right;
            // 
            // btnCancel
            // 
            btnCancel.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            btnCancel.IconColor = Color.DarkRed;
            btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancel.IconSize = 32;
            btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancel.Location = new Point(215, 369);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(191, 35);
            btnCancel.TabIndex = 22;
            btnCancel.Text = "Cancelar Fechamento";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Visible = false;
            // 
            // btnCloseCash
            // 
            btnCloseCash.IconChar = FontAwesome.Sharp.IconChar.Lock;
            btnCloseCash.IconColor = Color.DarkRed;
            btnCloseCash.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCloseCash.IconSize = 32;
            btnCloseCash.ImageAlign = ContentAlignment.MiddleLeft;
            btnCloseCash.Location = new Point(6, 369);
            btnCloseCash.Name = "btnCloseCash";
            btnCloseCash.Size = new Size(191, 35);
            btnCloseCash.TabIndex = 20;
            btnCloseCash.Text = "Fechar Caixa";
            btnCloseCash.UseVisualStyleBackColor = true;
            btnCloseCash.Click += btnCloseCash_Click;
            // 
            // dgvSummaryByType
            // 
            dgvSummaryByType.AllowUserToAddRows = false;
            dgvSummaryByType.AllowUserToDeleteRows = false;
            dgvSummaryByType.AllowUserToOrderColumns = true;
            dgvSummaryByType.AllowUserToResizeColumns = false;
            dgvSummaryByType.AllowUserToResizeRows = false;
            dgvSummaryByType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSummaryByType.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSummaryByType.Location = new Point(6, 111);
            dgvSummaryByType.Name = "dgvSummaryByType";
            dgvSummaryByType.ReadOnly = true;
            dgvSummaryByType.RowHeadersVisible = false;
            dgvSummaryByType.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvSummaryByType.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSummaryByType.Size = new Size(400, 120);
            dgvSummaryByType.TabIndex = 13;
            // 
            // dgvSummaryByPayment
            // 
            dgvSummaryByPayment.AllowUserToAddRows = false;
            dgvSummaryByPayment.AllowUserToDeleteRows = false;
            dgvSummaryByPayment.AllowUserToResizeColumns = false;
            dgvSummaryByPayment.AllowUserToResizeRows = false;
            dgvSummaryByPayment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSummaryByPayment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSummaryByPayment.Location = new Point(6, 237);
            dgvSummaryByPayment.Name = "dgvSummaryByPayment";
            dgvSummaryByPayment.ReadOnly = true;
            dgvSummaryByPayment.RowHeadersVisible = false;
            dgvSummaryByPayment.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvSummaryByPayment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSummaryByPayment.Size = new Size(400, 120);
            dgvSummaryByPayment.TabIndex = 14;
            // 
            // txtTotalInCash
            // 
            txtTotalInCash.Location = new Point(132, 82);
            txtTotalInCash.Name = "txtTotalInCash";
            txtTotalInCash.Size = new Size(150, 23);
            txtTotalInCash.TabIndex = 15;
            txtTotalInCash.TextAlign = HorizontalAlignment.Right;
            txtTotalInCash.KeyPress += txtTotalInCash_KeyPress;
            // 
            // CashClosingForm
            // 
            ClientSize = new Size(813, 432);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CashClosingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fechamento de Caixa";
            Load += CashClosingForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbReceiptPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSummaryByType).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSummaryByPayment).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvSummaryByType;
        private DataGridView dgvSummaryByPayment;
        private TextBox txtTotalInCash;
        private FontAwesome.Sharp.IconButton btnCloseCash;
        private FontAwesome.Sharp.IconButton btnCancel;
        private Label lblDate;
        private TextBox txtDate;
        private Label lblCashNumber;
        private TextBox txtCashNumber;
        private Label lblTotalInCash;
        private FontAwesome.Sharp.IconButton btnPrintReceipt;
        private RichTextBox rtbPreview;
        private Label lblStatus;
        private GroupBox gbReceiptPreview;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}