using FontAwesome.Sharp;
using SisPDV.APP.Extensions;

namespace SisPDV.APP.Login
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            mainPanel = new TableLayoutPanel();
            leftPanel = new Panel();
            btnClean = new IconButton();
            btnLogin = new IconButton();
            txtPassword = new TextBox();
            iconPassword = new IconPictureBox();
            txtUser = new TextBox();
            iconUser = new IconPictureBox();
            lblTitle = new Label();
            rightPanel = new Panel();
            mainPanel.SuspendLayout();
            leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconUser).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.ColumnCount = 2;
            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainPanel.Controls.Add(leftPanel, 0, 0);
            mainPanel.Controls.Add(rightPanel, 1, 0);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.RowCount = 1;
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            mainPanel.Size = new Size(684, 228);
            mainPanel.TabIndex = 0;
            // 
            // leftPanel
            // 
            leftPanel.BackColor = Color.WhiteSmoke;
            leftPanel.Controls.Add(btnClean);
            leftPanel.Controls.Add(btnLogin);
            leftPanel.Controls.Add(txtPassword);
            leftPanel.Controls.Add(iconPassword);
            leftPanel.Controls.Add(txtUser);
            leftPanel.Controls.Add(iconUser);
            leftPanel.Controls.Add(lblTitle);
            leftPanel.Dock = DockStyle.Fill;
            leftPanel.Location = new Point(3, 3);
            leftPanel.Name = "leftPanel";
            leftPanel.Padding = new Padding(40);
            leftPanel.Size = new Size(336, 222);
            leftPanel.TabIndex = 1;
            // 
            // btnClean
            // 
            btnClean.BackColor = Color.LightGray;
            btnClean.FlatAppearance.BorderSize = 0;
            btnClean.FlatStyle = FlatStyle.Flat;
            btnClean.ForeColor = Color.Black;
            btnClean.IconChar = IconChar.Eraser;
            btnClean.IconColor = Color.Black;
            btnClean.IconFont = IconFont.Auto;
            btnClean.IconSize = 16;
            btnClean.ImageAlign = ContentAlignment.MiddleLeft;
            btnClean.Location = new Point(165, 190);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(75, 23);
            btnClean.TabIndex = 6;
            btnClean.Text = "   Limpar";
            btnClean.UseVisualStyleBackColor = false;
            btnClean.Click += btnClean_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.RoyalBlue;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.IconChar = IconChar.SignIn;
            btnLogin.IconColor = Color.White;
            btnLogin.IconFont = IconFont.Auto;
            btnLogin.IconSize = 16;
            btnLogin.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogin.Location = new Point(40, 191);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "   Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(40, 143);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Senha";
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // iconPassword
            // 
            iconPassword.BackColor = Color.WhiteSmoke;
            iconPassword.ForeColor = Color.Gray;
            iconPassword.IconChar = IconChar.Lock;
            iconPassword.IconColor = Color.Gray;
            iconPassword.IconFont = IconFont.Auto;
            iconPassword.Location = new Point(5, 139);
            iconPassword.Name = "iconPassword";
            iconPassword.Size = new Size(32, 32);
            iconPassword.TabIndex = 3;
            iconPassword.TabStop = false;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(40, 103);
            txtUser.Name = "txtUser";
            txtUser.PlaceholderText = "Usuário";
            txtUser.Size = new Size(200, 23);
            txtUser.TabIndex = 2;
            // 
            // iconUser
            // 
            iconUser.BackColor = Color.WhiteSmoke;
            iconUser.ForeColor = Color.Gray;
            iconUser.IconChar = IconChar.User;
            iconUser.IconColor = Color.Gray;
            iconUser.IconFont = IconFont.Auto;
            iconUser.Location = new Point(5, 99);
            iconUser.Name = "iconUser";
            iconUser.Size = new Size(32, 32);
            iconUser.TabIndex = 1;
            iconUser.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(40, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(172, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Acesso ao Sistema";
            // 
            // rightPanel
            // 
            rightPanel.BackColor = Color.White;
            rightPanel.BackgroundImage = (Image)resources.GetObject("rightPanel.BackgroundImage");
            rightPanel.BackgroundImageLayout = ImageLayout.Zoom;
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(345, 3);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(336, 222);
            rightPanel.TabIndex = 2;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 228);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - PDV";
            mainPanel.ResumeLayout(false);
            leftPanel.ResumeLayout(false);
            leftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconUser).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainPanel;
        private Panel leftPanel;
        private TextBox txtPassword;
        private FontAwesome.Sharp.IconPictureBox iconPassword;
        private TextBox txtUser;
        private FontAwesome.Sharp.IconPictureBox iconUser;
        private Label lblTitle;
        private IconButton btnClean;
        private IconButton btnLogin;
        private Panel rightPanel;
    }
}