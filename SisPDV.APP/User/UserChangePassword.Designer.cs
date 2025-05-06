namespace SisPDV.APP.User
{
    partial class UserChangePassword
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
            btnSave = new FontAwesome.Sharp.IconButton();
            txtNewPassword = new TextBox();
            txtOldPassword = new TextBox();
            txtLogin = new TextBox();
            lblNewPassword = new Label();
            lblOldPassword = new Label();
            lblLogin = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(txtNewPassword);
            groupBox1.Controls.Add(txtOldPassword);
            groupBox1.Controls.Add(txtLogin);
            groupBox1.Controls.Add(lblNewPassword);
            groupBox1.Controls.Add(lblOldPassword);
            groupBox1.Controls.Add(lblLogin);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(384, 261);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Alterar";
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.Control;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.Black;
            btnSave.IconChar = FontAwesome.Sharp.IconChar.Refresh;
            btnSave.IconColor = Color.ForestGreen;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSave.IconSize = 20;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(293, 192);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 14;
            btnSave.Text = "   Alterar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(90, 103);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PlaceholderText = "Senha Nova";
            txtNewPassword.Size = new Size(278, 23);
            txtNewPassword.TabIndex = 13;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // txtOldPassword
            // 
            txtOldPassword.Location = new Point(90, 74);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.PlaceholderText = "Senha Antiga";
            txtOldPassword.Size = new Size(278, 23);
            txtOldPassword.TabIndex = 12;
            txtOldPassword.UseSystemPasswordChar = true;
            // 
            // txtLogin
            // 
            txtLogin.BackColor = SystemColors.ControlLightLight;
            txtLogin.Location = new Point(90, 45);
            txtLogin.Name = "txtLogin";
            txtLogin.PlaceholderText = "Login";
            txtLogin.Size = new Size(278, 23);
            txtLogin.TabIndex = 11;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Location = new Point(14, 106);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(70, 15);
            lblNewPassword.TabIndex = 10;
            lblNewPassword.Text = "Senha Nova";
            // 
            // lblOldPassword
            // 
            lblOldPassword.AutoSize = true;
            lblOldPassword.Location = new Point(14, 77);
            lblOldPassword.Name = "lblOldPassword";
            lblOldPassword.Size = new Size(77, 15);
            lblOldPassword.TabIndex = 9;
            lblOldPassword.Text = "Senha Antiga";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(14, 48);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(37, 15);
            lblLogin.TabIndex = 8;
            lblLogin.Text = "Login";
            // 
            // UserChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 261);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserChangePassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Alteração de Senha";
            Load += UserChangePassword_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton btnSave;
        private TextBox txtNewPassword;
        private TextBox txtOldPassword;
        private TextBox txtLogin;
        private Label lblNewPassword;
        private Label lblOldPassword;
        private Label lblLogin;
    }
}