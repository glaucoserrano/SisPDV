namespace SisPDV.APP.Cash
{
    partial class CashMovementForm
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
            label1 = new Label();
            txtNote = new TextBox();
            grbSupply = new GroupBox();
            rdoCashWithdrawal = new RadioButton();
            rdoCashSupply = new RadioButton();
            btnMovementCash = new FontAwesome.Sharp.IconButton();
            gbReceiptPreview = new GroupBox();
            btnPrintReceipt = new FontAwesome.Sharp.IconButton();
            rtbReceiptPreview = new RichTextBox();
            lblStatus = new Label();
            lblDate = new Label();
            txtDate = new TextBox();
            lblCashNumber = new Label();
            txtCashNumber = new TextBox();
            lblValue = new Label();
            txtValue = new TextBox();
            grbCashOpening.SuspendLayout();
            grbSupply.SuspendLayout();
            gbReceiptPreview.SuspendLayout();
            SuspendLayout();
            // 
            // grbCashOpening
            // 
            grbCashOpening.Controls.Add(label1);
            grbCashOpening.Controls.Add(txtNote);
            grbCashOpening.Controls.Add(grbSupply);
            grbCashOpening.Controls.Add(btnMovementCash);
            grbCashOpening.Controls.Add(gbReceiptPreview);
            grbCashOpening.Controls.Add(lblStatus);
            grbCashOpening.Controls.Add(lblDate);
            grbCashOpening.Controls.Add(txtDate);
            grbCashOpening.Controls.Add(lblCashNumber);
            grbCashOpening.Controls.Add(txtCashNumber);
            grbCashOpening.Controls.Add(lblValue);
            grbCashOpening.Controls.Add(txtValue);
            grbCashOpening.Location = new Point(12, 12);
            grbCashOpening.Name = "grbCashOpening";
            grbCashOpening.Size = new Size(576, 343);
            grbCashOpening.TabIndex = 10;
            grbCashOpening.TabStop = false;
            // 
            // label1
            // 
            label1.Location = new Point(6, 128);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 16;
            label1.Text = "Observação:";
            // 
            // txtNote
            // 
            txtNote.Location = new Point(114, 125);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(150, 97);
            txtNote.TabIndex = 2;
            // 
            // grbSupply
            // 
            grbSupply.Controls.Add(rdoCashWithdrawal);
            grbSupply.Controls.Add(rdoCashSupply);
            grbSupply.Location = new Point(16, 219);
            grbSupply.Name = "grbSupply";
            grbSupply.Size = new Size(230, 57);
            grbSupply.TabIndex = 11;
            grbSupply.TabStop = false;
            // 
            // rdoCashWithdrawal
            // 
            rdoCashWithdrawal.AutoSize = true;
            rdoCashWithdrawal.Location = new Point(111, 25);
            rdoCashWithdrawal.Name = "rdoCashWithdrawal";
            rdoCashWithdrawal.Size = new Size(64, 19);
            rdoCashWithdrawal.TabIndex = 1;
            rdoCashWithdrawal.Text = "Sangria";
            rdoCashWithdrawal.UseVisualStyleBackColor = true;
            rdoCashWithdrawal.CheckedChanged += rdoCashWithdrawal_CheckedChanged;
            // 
            // rdoCashSupply
            // 
            rdoCashSupply.AutoSize = true;
            rdoCashSupply.Checked = true;
            rdoCashSupply.Location = new Point(6, 25);
            rdoCashSupply.Name = "rdoCashSupply";
            rdoCashSupply.Size = new Size(87, 19);
            rdoCashSupply.TabIndex = 0;
            rdoCashSupply.TabStop = true;
            rdoCashSupply.Text = "Suprimento";
            rdoCashSupply.UseVisualStyleBackColor = true;
            rdoCashSupply.CheckedChanged += rdoCashSupply_CheckedChanged;
            // 
            // btnMovementCash
            // 
            btnMovementCash.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            btnMovementCash.IconColor = Color.DarkGreen;
            btnMovementCash.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMovementCash.IconSize = 32;
            btnMovementCash.ImageAlign = ContentAlignment.MiddleLeft;
            btnMovementCash.Location = new Point(16, 282);
            btnMovementCash.Name = "btnMovementCash";
            btnMovementCash.Size = new Size(230, 35);
            btnMovementCash.TabIndex = 14;
            btnMovementCash.Text = "Suprimento";
            btnMovementCash.UseVisualStyleBackColor = true;
            btnMovementCash.Click += btnMovementCash_Click;
            // 
            // gbReceiptPreview
            // 
            gbReceiptPreview.Controls.Add(btnPrintReceipt);
            gbReceiptPreview.Controls.Add(rtbReceiptPreview);
            gbReceiptPreview.Location = new Point(270, 22);
            gbReceiptPreview.Name = "gbReceiptPreview";
            gbReceiptPreview.Size = new Size(300, 227);
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
            lblStatus.Location = new Point(16, 320);
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
            // lblValue
            // 
            lblValue.Location = new Point(4, 99);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(104, 20);
            lblValue.TabIndex = 10;
            lblValue.Text = "Valor:";
            // 
            // txtValue
            // 
            txtValue.Location = new Point(114, 96);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(100, 23);
            txtValue.TabIndex = 1;
            txtValue.TextAlign = HorizontalAlignment.Right;
            txtValue.KeyPress += txtValue_KeyPress;
            // 
            // CashMovementForm
            // 
            ClientSize = new Size(600, 368);
            Controls.Add(grbCashOpening);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CashMovementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Movimentação de Caixa - Suprimento / Sangria";
            Load += CashMovementForm_Load;
            grbCashOpening.ResumeLayout(false);
            grbCashOpening.PerformLayout();
            grbSupply.ResumeLayout(false);
            grbSupply.PerformLayout();
            gbReceiptPreview.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grbCashOpening;
        private FontAwesome.Sharp.IconButton btnMovementCash;
        private GroupBox gbReceiptPreview;
        private FontAwesome.Sharp.IconButton btnPrintReceipt;
        private RichTextBox rtbReceiptPreview;
        private Label lblStatus;
        private Label lblDate;
        private TextBox txtDate;
        private Label lblCashNumber;
        private TextBox txtCashNumber;
        private Label lblValue;
        private TextBox txtValue;
        private GroupBox grbSupply;
        private RadioButton rdoCashWithdrawal;
        private RadioButton rdoCashSupply;
        private Label label1;
        private TextBox txtNote;
    }
}