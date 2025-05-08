namespace SisPDV.APP.Main
{
    partial class MainForm
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

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            statusStrip = new StatusStrip();
            sslUser = new ToolStripStatusLabel();
            menuMain = new MenuStrip();
            menuItemConfig = new ToolStripMenuItem();
            MenuItemConfigUser = new ToolStripMenuItem();
            MenuItemConfigChargePassword = new ToolStripMenuItem();
            MenuItemConfigPermission = new ToolStripMenuItem();
            iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            statusStrip.SuspendLayout();
            menuMain.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { sslUser });
            statusStrip.Location = new Point(0, 428);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(800, 22);
            statusStrip.TabIndex = 0;
            // 
            // sslUser
            // 
            sslUser.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sslUser.Name = "sslUser";
            sslUser.Size = new Size(0, 17);
            // 
            // menuMain
            // 
            menuMain.Items.AddRange(new ToolStripItem[] { menuItemConfig });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Size = new Size(800, 24);
            menuMain.TabIndex = 1;
            menuMain.Text = "Configurações";
            // 
            // menuItemConfig
            // 
            menuItemConfig.DropDownItems.AddRange(new ToolStripItem[] { MenuItemConfigUser, MenuItemConfigChargePassword, MenuItemConfigPermission });
            menuItemConfig.Name = "menuItemConfig";
            menuItemConfig.Size = new Size(96, 20);
            menuItemConfig.Text = "Configurações";
            menuItemConfig.TextImageRelation = TextImageRelation.TextBeforeImage;
            menuItemConfig.Visible = false;
            // 
            // MenuItemConfigUser
            // 
            MenuItemConfigUser.Name = "MenuItemConfigUser";
            MenuItemConfigUser.Size = new Size(192, 22);
            MenuItemConfigUser.Text = "Usuários";
            // 
            // MenuItemConfigChargePassword
            // 
            MenuItemConfigChargePassword.Name = "MenuItemConfigChargePassword";
            MenuItemConfigChargePassword.Size = new Size(192, 22);
            MenuItemConfigChargePassword.Text = "Alterar Senha";
            // 
            // MenuItemConfigPermission
            // 
            MenuItemConfigPermission.Name = "MenuItemConfigPermission";
            MenuItemConfigPermission.Size = new Size(192, 22);
            MenuItemConfigPermission.Text = "Permissões de Usuário";
            // 
            // iconMenuItem1
            // 
            iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem1.IconColor = Color.Black;
            iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem1.Name = "iconMenuItem1";
            iconMenuItem1.Size = new Size(32, 19);
            iconMenuItem1.Text = "iconMenuItem1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip);
            Controls.Add(menuMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuMain;
            Name = "MainForm";
            Text = "MainForm";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip;
        private ToolStripStatusLabel sslUser;
        private MenuStrip menuMain;
        private ToolStripMenuItem menuItemConfig;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private ToolStripMenuItem MenuItemConfigUser;
        private ToolStripMenuItem MenuItemConfigChargePassword;
        private ToolStripMenuItem MenuItemConfigPermission;
    }
}