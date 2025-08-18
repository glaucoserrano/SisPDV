namespace SisPDV.APP.Order
{
    partial class OrderForm
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
            rtbFiscalMirror = new RichTextBox();
            grbProducts = new GroupBox();
            label1 = new Label();
            txtNotes = new TextBox();
            grbOrder = new GroupBox();
            lblSubtotal = new Label();
            lblDiscountTotal = new Label();
            lblTotal = new Label();
            lblItemTotal = new Label();
            lblDiscount = new Label();
            lblPriceIUnity = new Label();
            lblQuantities = new Label();
            txtProduct = new TextBox();
            txtQuantity = new TextBox();
            txtUnitPrice = new TextBox();
            txtItemTotal = new TextBox();
            txtItemDiscount = new TextBox();
            btnAddItem = new Button();
            grbCommands = new GroupBox();
            btnCancelOrder = new FontAwesome.Sharp.IconButton();
            btnCloseOrder = new FontAwesome.Sharp.IconButton();
            btnNewOrder = new FontAwesome.Sharp.IconButton();
            btnCancelProduct = new FontAwesome.Sharp.IconButton();
            btnSwap = new FontAwesome.Sharp.IconButton();
            lblCurrentUser = new Label();
            rtbCompanyName = new RichTextBox();
            grbProducts.SuspendLayout();
            grbOrder.SuspendLayout();
            grbCommands.SuspendLayout();
            SuspendLayout();
            // 
            // rtbFiscalMirror
            // 
            rtbFiscalMirror.BackColor = Color.White;
            rtbFiscalMirror.BorderStyle = BorderStyle.None;
            rtbFiscalMirror.Font = new Font("Consolas", 10F);
            rtbFiscalMirror.Location = new Point(12, 69);
            rtbFiscalMirror.Name = "rtbFiscalMirror";
            rtbFiscalMirror.ReadOnly = true;
            rtbFiscalMirror.Size = new Size(548, 490);
            rtbFiscalMirror.TabIndex = 20;
            rtbFiscalMirror.Text = "";
            // 
            // grbProducts
            // 
            grbProducts.Controls.Add(label1);
            grbProducts.Controls.Add(txtNotes);
            grbProducts.Controls.Add(grbOrder);
            grbProducts.Controls.Add(lblItemTotal);
            grbProducts.Controls.Add(lblDiscount);
            grbProducts.Controls.Add(lblPriceIUnity);
            grbProducts.Controls.Add(lblQuantities);
            grbProducts.Controls.Add(txtProduct);
            grbProducts.Controls.Add(txtQuantity);
            grbProducts.Controls.Add(txtUnitPrice);
            grbProducts.Controls.Add(txtItemTotal);
            grbProducts.Controls.Add(txtItemDiscount);
            grbProducts.Controls.Add(btnAddItem);
            grbProducts.Enabled = false;
            grbProducts.Location = new Point(565, 152);
            grbProducts.Name = "grbProducts";
            grbProducts.Size = new Size(509, 400);
            grbProducts.TabIndex = 21;
            grbProducts.TabStop = false;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(6, 126);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 45;
            label1.Text = "Obs.:";
            // 
            // txtNotes
            // 
            txtNotes.Font = new Font("Segoe UI", 12F);
            txtNotes.Location = new Point(6, 152);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(497, 67);
            txtNotes.TabIndex = 44;
            // 
            // grbOrder
            // 
            grbOrder.Controls.Add(lblSubtotal);
            grbOrder.Controls.Add(lblDiscountTotal);
            grbOrder.Controls.Add(lblTotal);
            grbOrder.Location = new Point(3, 271);
            grbOrder.Name = "grbOrder";
            grbOrder.Size = new Size(505, 123);
            grbOrder.TabIndex = 43;
            grbOrder.TabStop = false;
            grbOrder.Text = "Pedido";
            // 
            // lblSubtotal
            // 
            lblSubtotal.Font = new Font("Segoe UI", 11F);
            lblSubtotal.Location = new Point(18, 25);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(396, 23);
            lblSubtotal.TabIndex = 39;
            lblSubtotal.Text = "Subtotal: R$ ";
            // 
            // lblDiscountTotal
            // 
            lblDiscountTotal.Font = new Font("Segoe UI", 11F);
            lblDiscountTotal.Location = new Point(18, 55);
            lblDiscountTotal.Name = "lblDiscountTotal";
            lblDiscountTotal.Size = new Size(396, 23);
            lblDiscountTotal.TabIndex = 40;
            lblDiscountTotal.Text = "Descontos: R$ ";
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTotal.Location = new Point(18, 85);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(396, 23);
            lblTotal.TabIndex = 41;
            lblTotal.Text = "Total: R$ ";
            // 
            // lblItemTotal
            // 
            lblItemTotal.Font = new Font("Segoe UI", 11F);
            lblItemTotal.Location = new Point(374, 68);
            lblItemTotal.Name = "lblItemTotal";
            lblItemTotal.Size = new Size(111, 23);
            lblItemTotal.TabIndex = 42;
            lblItemTotal.Text = "Total: ";
            // 
            // lblDiscount
            // 
            lblDiscount.Font = new Font("Segoe UI", 11F);
            lblDiscount.Location = new Point(244, 68);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(111, 23);
            lblDiscount.TabIndex = 41;
            lblDiscount.Text = "Desconto: ";
            // 
            // lblPriceIUnity
            // 
            lblPriceIUnity.Font = new Font("Segoe UI", 11F);
            lblPriceIUnity.Location = new Point(114, 68);
            lblPriceIUnity.Name = "lblPriceIUnity";
            lblPriceIUnity.Size = new Size(111, 23);
            lblPriceIUnity.TabIndex = 40;
            lblPriceIUnity.Text = "Preço Unitário: ";
            // 
            // lblQuantities
            // 
            lblQuantities.Font = new Font("Segoe UI", 11F);
            lblQuantities.Location = new Point(4, 68);
            lblQuantities.Name = "lblQuantities";
            lblQuantities.Size = new Size(100, 23);
            lblQuantities.TabIndex = 39;
            lblQuantities.Text = "Qtd:";
            // 
            // txtProduct
            // 
            txtProduct.Font = new Font("Segoe UI", 12F);
            txtProduct.Location = new Point(4, 29);
            txtProduct.Name = "txtProduct";
            txtProduct.PlaceholderText = "Produto (código, código de barras, ref., nome)";
            txtProduct.Size = new Size(500, 29);
            txtProduct.TabIndex = 30;
            // 
            // txtQuantity
            // 
            txtQuantity.Font = new Font("Segoe UI", 12F);
            txtQuantity.Location = new Point(4, 94);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(100, 29);
            txtQuantity.TabIndex = 31;
            txtQuantity.KeyPress += txtQuantity_KeyPress;
            txtQuantity.Leave += txtQuantity_Leave;
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Font = new Font("Segoe UI", 12F);
            txtUnitPrice.Location = new Point(114, 94);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Size = new Size(120, 29);
            txtUnitPrice.TabIndex = 32;
            txtUnitPrice.KeyPress += txtUnitPrice_KeyPress;
            txtUnitPrice.Leave += txtUnitPrice_Leave;
            // 
            // txtItemTotal
            // 
            txtItemTotal.Font = new Font("Segoe UI", 12F);
            txtItemTotal.Location = new Point(374, 94);
            txtItemTotal.Name = "txtItemTotal";
            txtItemTotal.Size = new Size(120, 29);
            txtItemTotal.TabIndex = 34;
            txtItemTotal.KeyPress += txtItemTotal_KeyPress;
            // 
            // txtItemDiscount
            // 
            txtItemDiscount.Font = new Font("Segoe UI", 12F);
            txtItemDiscount.Location = new Point(244, 94);
            txtItemDiscount.Name = "txtItemDiscount";
            txtItemDiscount.Size = new Size(120, 29);
            txtItemDiscount.TabIndex = 33;
            txtItemDiscount.KeyPress += txtItemDiscount_KeyPress;
            txtItemDiscount.Leave += txtItemDiscount_Leave;
            // 
            // btnAddItem
            // 
            btnAddItem.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddItem.Location = new Point(155, 225);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(200, 40);
            btnAddItem.TabIndex = 35;
            btnAddItem.Text = "Adicionar Item";
            btnAddItem.Click += btnAddItem_Click;
            // 
            // grbCommands
            // 
            grbCommands.Controls.Add(btnCancelOrder);
            grbCommands.Controls.Add(btnCloseOrder);
            grbCommands.Controls.Add(btnNewOrder);
            grbCommands.Location = new Point(562, 69);
            grbCommands.Name = "grbCommands";
            grbCommands.Size = new Size(511, 80);
            grbCommands.TabIndex = 22;
            grbCommands.TabStop = false;
            // 
            // btnCancelOrder
            // 
            btnCancelOrder.IconChar = FontAwesome.Sharp.IconChar.MoneyBill;
            btnCancelOrder.IconColor = Color.Red;
            btnCancelOrder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelOrder.IconSize = 32;
            btnCancelOrder.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelOrder.Location = new Point(24, 22);
            btnCancelOrder.Name = "btnCancelOrder";
            btnCancelOrder.Size = new Size(168, 45);
            btnCancelOrder.TabIndex = 5;
            btnCancelOrder.Text = "Cancelar Pedido";
            btnCancelOrder.UseVisualStyleBackColor = true;
            btnCancelOrder.Visible = false;
            btnCancelOrder.Click += btnCancelOrder_Click;
            // 
            // btnCloseOrder
            // 
            btnCloseOrder.Enabled = false;
            btnCloseOrder.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnCloseOrder.IconColor = Color.DarkCyan;
            btnCloseOrder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCloseOrder.IconSize = 32;
            btnCloseOrder.ImageAlign = ContentAlignment.MiddleLeft;
            btnCloseOrder.Location = new Point(320, 22);
            btnCloseOrder.Name = "btnCloseOrder";
            btnCloseOrder.Size = new Size(168, 45);
            btnCloseOrder.TabIndex = 4;
            btnCloseOrder.Text = "Fechar Pedido";
            btnCloseOrder.UseVisualStyleBackColor = true;
            // 
            // btnNewOrder
            // 
            btnNewOrder.IconChar = FontAwesome.Sharp.IconChar.MoneyBill;
            btnNewOrder.IconColor = Color.DarkOliveGreen;
            btnNewOrder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNewOrder.IconSize = 32;
            btnNewOrder.ImageAlign = ContentAlignment.MiddleLeft;
            btnNewOrder.Location = new Point(24, 22);
            btnNewOrder.Name = "btnNewOrder";
            btnNewOrder.Size = new Size(168, 45);
            btnNewOrder.TabIndex = 0;
            btnNewOrder.Text = "Nova Venda";
            btnNewOrder.UseVisualStyleBackColor = true;
            btnNewOrder.Click += btnNewOrder_Click;
            // 
            // btnCancelProduct
            // 
            btnCancelProduct.Enabled = false;
            btnCancelProduct.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            btnCancelProduct.IconColor = Color.DarkRed;
            btnCancelProduct.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelProduct.IconSize = 32;
            btnCancelProduct.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelProduct.Location = new Point(720, 552);
            btnCancelProduct.Name = "btnCancelProduct";
            btnCancelProduct.Size = new Size(168, 45);
            btnCancelProduct.TabIndex = 24;
            btnCancelProduct.Text = "Excluir Produto";
            btnCancelProduct.UseVisualStyleBackColor = true;
            // 
            // btnSwap
            // 
            btnSwap.Enabled = false;
            btnSwap.IconChar = FontAwesome.Sharp.IconChar.Shuffle;
            btnSwap.IconColor = Color.DarkOliveGreen;
            btnSwap.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSwap.IconSize = 32;
            btnSwap.ImageAlign = ContentAlignment.MiddleLeft;
            btnSwap.Location = new Point(905, 552);
            btnSwap.Name = "btnSwap";
            btnSwap.Size = new Size(168, 45);
            btnSwap.TabIndex = 25;
            btnSwap.Text = "Troca Produtos";
            btnSwap.UseVisualStyleBackColor = true;
            // 
            // lblCurrentUser
            // 
            lblCurrentUser.AutoSize = true;
            lblCurrentUser.Location = new Point(12, 585);
            lblCurrentUser.Name = "lblCurrentUser";
            lblCurrentUser.Size = new Size(0, 15);
            lblCurrentUser.TabIndex = 26;
            // 
            // rtbCompanyName
            // 
            rtbCompanyName.BackColor = Color.White;
            rtbCompanyName.BorderStyle = BorderStyle.None;
            rtbCompanyName.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rtbCompanyName.Location = new Point(12, 20);
            rtbCompanyName.Name = "rtbCompanyName";
            rtbCompanyName.ReadOnly = true;
            rtbCompanyName.RightToLeft = RightToLeft.No;
            rtbCompanyName.Size = new Size(548, 43);
            rtbCompanyName.TabIndex = 27;
            rtbCompanyName.Text = "";
            // 
            // OrderForm
            // 
            ClientSize = new Size(1091, 609);
            Controls.Add(rtbCompanyName);
            Controls.Add(lblCurrentUser);
            Controls.Add(btnSwap);
            Controls.Add(btnCancelProduct);
            Controls.Add(grbCommands);
            Controls.Add(grbProducts);
            Controls.Add(rtbFiscalMirror);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OrderForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pedido";
            Load += OrderForm_Load;
            grbProducts.ResumeLayout(false);
            grbProducts.PerformLayout();
            grbOrder.ResumeLayout(false);
            grbCommands.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbFiscalMirror;
        private GroupBox grbProducts;
        private TextBox txtProduct;
        private TextBox txtQuantity;
        private TextBox txtUnitPrice;
        private TextBox txtItemTotal;
        private TextBox txtItemDiscount;
        private Button btnAddItem;
        private GroupBox grbCommands;
        private FontAwesome.Sharp.IconButton btnNewOrder;
        private Label lblItemTotal;
        private Label lblDiscount;
        private Label lblPriceIUnity;
        private Label lblQuantities;
        private GroupBox grbOrder;
        private FontAwesome.Sharp.IconButton btnCancelOrder;
        private FontAwesome.Sharp.IconButton btnCloseOrder;
        private FontAwesome.Sharp.IconButton btnCancelProduct;
        private FontAwesome.Sharp.IconButton btnSwap;
        private Label lblCurrentUser;
        private RichTextBox rtbCompanyName;
        private Label label1;
        private TextBox txtNotes;
        private Label lblSubtotal;
        private Label lblDiscountTotal;
        private Label lblTotal;
    }
}