namespace SisPDV.APP.Cash
{
    partial class CashOpeningForm
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
            grbCashOpening = new GroupBox();
            btnOpenCash = new FontAwesome.Sharp.IconButton();
            gbReceiptPreview = new GroupBox();
            btnPrintReceipt = new FontAwesome.Sharp.IconButton();
            rtbReceiptPreview = new RichTextBox();
            lblStatus = new Label();
            lblDate = new Label();
            txtDate = new TextBox();
            lblCashNumber = new Label();
            txtCashNumber = new TextBox();
            lblOpeningValue = new Label();
            txtOpeningValue = new TextBox();
            grbCashOpening.SuspendLayout();
            gbReceiptPreview.SuspendLayout();
            SuspendLayout();
            // 
            // grbCashOpening
            // 
            grbCashOpening.Controls.Add(btnOpenCash);
            grbCashOpening.Controls.Add(gbReceiptPreview);
            grbCashOpening.Controls.Add(lblStatus);
            grbCashOpening.Controls.Add(lblDate);
            grbCashOpening.Controls.Add(txtDate);
            grbCashOpening.Controls.Add(lblCashNumber);
            grbCashOpening.Controls.Add(txtCashNumber);
            grbCashOpening.Controls.Add(lblOpeningValue);
            grbCashOpening.Controls.Add(txtOpeningValue);
            grbCashOpening.Location = new Point(12, 12);
            grbCashOpening.Name = "grbCashOpening";
            grbCashOpening.Size = new Size(576, 256);
            grbCashOpening.TabIndex = 10;
            grbCashOpening.TabStop = false;
            // 
            // btnOpenCash
            // 
            btnOpenCash.IconChar = FontAwesome.Sharp.IconChar.Lock;
            btnOpenCash.IconColor = Color.DarkRed;
            btnOpenCash.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnOpenCash.IconSize = 32;
            btnOpenCash.ImageAlign = ContentAlignment.MiddleLeft;
            btnOpenCash.Location = new Point(16, 166);
            btnOpenCash.Name = "btnOpenCash";
            btnOpenCash.Size = new Size(230, 35);
            btnOpenCash.TabIndex = 14;
            btnOpenCash.Text = "Abrir Caixa";
            btnOpenCash.UseVisualStyleBackColor = true;
            // 
            // gbReceiptPreview
            // 
            gbReceiptPreview.Controls.Add(btnPrintReceipt);
            gbReceiptPreview.Controls.Add(rtbReceiptPreview);
            gbReceiptPreview.Location = new Point(270, 22);
            gbReceiptPreview.Name = "gbReceiptPreview";
            gbReceiptPreview.Size = new Size(300, 221);
            gbReceiptPreview.TabIndex = 13;
            gbReceiptPreview.TabStop = false;
            gbReceiptPreview.Text = "Visualização do Comprovante";
            // 
            // btnPrintReceipt
            // 
            btnPrintReceipt.IconChar = FontAwesome.Sharp.IconChar.Print;
            btnPrintReceipt.IconColor = Color.SaddleBrown;
            btnPrintReceipt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPrintReceipt.IconSize = 32;
            btnPrintReceipt.ImageAlign = ContentAlignment.MiddleLeft;
            btnPrintReceipt.Location = new Point(6, 186);
            btnPrintReceipt.Name = "btnPrintReceipt";
            btnPrintReceipt.Size = new Size(288, 35);
            btnPrintReceipt.TabIndex = 1;
            btnPrintReceipt.Text = "Imprimir Comprovante";
            btnPrintReceipt.UseVisualStyleBackColor = true;
            // 
            // rtbReceiptPreview
            // 
            rtbReceiptPreview.BackColor = Color.White;
            rtbReceiptPreview.BorderStyle = BorderStyle.None;
            rtbReceiptPreview.Font = new Font("Consolas", 10F);
            rtbReceiptPreview.Location = new Point(6, 19);
            rtbReceiptPreview.Name = "rtbReceiptPreview";
            rtbReceiptPreview.ReadOnly = true;
            rtbReceiptPreview.Size = new Size(288, 160);
            rtbReceiptPreview.TabIndex = 0;
            rtbReceiptPreview.Text = "";
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(6, 226);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(230, 20);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Status: Caixa Fechado";
            // 
            // lblDate
            // 
            lblDate.Location = new Point(4, 41);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(100, 20);
            lblDate.TabIndex = 6;
            lblDate.Text = "Data:";
            // 
            // txtDate
            // 
            txtDate.Location = new Point(114, 38);
            txtDate.Name = "txtDate";
            txtDate.ReadOnly = true;
            txtDate.Size = new Size(100, 23);
            txtDate.TabIndex = 7;
            // 
            // lblCashNumber
            // 
            lblCashNumber.Location = new Point(4, 70);
            lblCashNumber.Name = "lblCashNumber";
            lblCashNumber.Size = new Size(100, 20);
            lblCashNumber.TabIndex = 8;
            lblCashNumber.Text = "Caixa Nº:";
            // 
            // txtCashNumber
            // 
            txtCashNumber.Location = new Point(114, 67);
            txtCashNumber.Name = "txtCashNumber";
            txtCashNumber.ReadOnly = true;
            txtCashNumber.Size = new Size(100, 23);
            txtCashNumber.TabIndex = 9;
            // 
            // lblOpeningValue
            // 
            lblOpeningValue.Location = new Point(4, 99);
            lblOpeningValue.Name = "lblOpeningValue";
            lblOpeningValue.Size = new Size(104, 20);
            lblOpeningValue.TabIndex = 10;
            lblOpeningValue.Text = "Valor de Abertura:";
            // 
            // txtOpeningValue
            // 
            txtOpeningValue.Location = new Point(114, 96);
            txtOpeningValue.Name = "txtOpeningValue";
            txtOpeningValue.Size = new Size(100, 23);
            txtOpeningValue.TabIndex = 1;
            txtOpeningValue.TextAlign = HorizontalAlignment.Right;
            txtOpeningValue.KeyPress += txtOpeningValue_KeyPress;
            // 
            // CashOpeningForm
            // 
            ClientSize = new Size(600, 280);
            Controls.Add(grbCashOpening);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CashOpeningForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Abertura de Caixa";
            Load += CashOpeningForm_Load;
            grbCashOpening.ResumeLayout(false);
            grbCashOpening.PerformLayout();
            gbReceiptPreview.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grbCashOpening;
        private FontAwesome.Sharp.IconButton btnOpenCash;
        private GroupBox gbReceiptPreview;
        private FontAwesome.Sharp.IconButton btnPrintReceipt;
        private RichTextBox rtbReceiptPreview;
        private Label lblStatus;
        private Label lblDate;
        private TextBox txtDate;
        private Label lblCashNumber;
        private TextBox txtCashNumber;
        private Label lblOpeningValue;
        private TextBox txtOpeningValue;
    }
}