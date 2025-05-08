namespace SisPDV.APP.PermissionMenu
{
    partial class PermissionMenuForm
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
            tvMenus = new TreeView();
            btnSave = new FontAwesome.Sharp.IconButton();
            cmbUsers = new ComboBox();
            lblUsers = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tvMenus);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(cmbUsers);
            groupBox1.Controls.Add(lblUsers);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(384, 261);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Permissões";
            // 
            // tvMenus
            // 
            tvMenus.Location = new Point(18, 54);
            tvMenus.Name = "tvMenus";
            tvMenus.Size = new Size(354, 172);
            tvMenus.TabIndex = 9;
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
            btnSave.Location = new Point(297, 232);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 8;
            btnSave.Text = "   Salvar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // cmbUsers
            // 
            cmbUsers.FormattingEnabled = true;
            cmbUsers.Location = new Point(70, 22);
            cmbUsers.Name = "cmbUsers";
            cmbUsers.Size = new Size(303, 23);
            cmbUsers.TabIndex = 1;
            cmbUsers.SelectedIndexChanged += cmbUsers_SelectedIndexChanged;
            // 
            // lblUsers
            // 
            lblUsers.AutoSize = true;
            lblUsers.Location = new Point(12, 25);
            lblUsers.Name = "lblUsers";
            lblUsers.Size = new Size(52, 15);
            lblUsers.TabIndex = 0;
            lblUsers.Text = "Usuários";
            // 
            // PermissionMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 261);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PermissionMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Permissões de Usuários";
            Load += PrmissionMenuForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cmbUsers;
        private Label lblUsers;
        private TreeView tvMenus;
        private FontAwesome.Sharp.IconButton btnSave;
    }
}