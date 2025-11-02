namespace FE_ToDoApp
{
    partial class Trangchu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Trangchu));
            sidebarPanel = new Panel();
            panel = new Panel();
            private_item_panel = new Panel();
            privateHeaderPanel = new Panel();
            lblPrivate = new Label();
            btnAddPrivatePage = new Button();
            panel1 = new Panel();
            btnRecent = new Button();
            btnFavorites = new Button();
            btnShared = new Button();
            userPanel = new Panel();
            panel3 = new Panel();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            lblUserName = new Label();
            footerPanel = new Panel();
            btnSettings = new Button();
            btnTrash = new Button();
            mainPanel = new Panel();
            lblBody = new Label();
            lblWelcome = new Label();
            lblTitle = new Label();
            headerPanel = new Panel();
            lblHeaderTitle = new Label();
            sidebarPanel.SuspendLayout();
            panel.SuspendLayout();
            privateHeaderPanel.SuspendLayout();
            panel1.SuspendLayout();
            userPanel.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            footerPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.FromArgb(247, 247, 247);
            sidebarPanel.Controls.Add(panel);
            sidebarPanel.Controls.Add(panel1);
            sidebarPanel.Controls.Add(userPanel);
            sidebarPanel.Controls.Add(footerPanel);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Margin = new Padding(3, 4, 3, 4);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Padding = new Padding(9, 11, 9, 11);
            sidebarPanel.Size = new Size(320, 908);
            sidebarPanel.TabIndex = 0;
            // 
            // panel
            // 
            panel.Controls.Add(private_item_panel);
            panel.Controls.Add(privateHeaderPanel);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(9, 274);
            panel.Name = "panel";
            panel.Size = new Size(302, 538);
            panel.TabIndex = 9;
            // 
            // private_item_panel
            // 
            private_item_panel.Dock = DockStyle.Fill;
            private_item_panel.Location = new Point(0, 42);
            private_item_panel.Name = "private_item_panel";
            private_item_panel.Size = new Size(302, 496);
            private_item_panel.TabIndex = 9;
            // 
            // privateHeaderPanel
            // 
            privateHeaderPanel.BackColor = Color.FromArgb(247, 247, 247);
            privateHeaderPanel.Controls.Add(lblPrivate);
            privateHeaderPanel.Controls.Add(btnAddPrivatePage);
            privateHeaderPanel.Dock = DockStyle.Top;
            privateHeaderPanel.Location = new Point(0, 0);
            privateHeaderPanel.Margin = new Padding(3, 4, 3, 4);
            privateHeaderPanel.Name = "privateHeaderPanel";
            privateHeaderPanel.Padding = new Padding(0, 0, 0, 10);
            privateHeaderPanel.Size = new Size(302, 42);
            privateHeaderPanel.TabIndex = 8;
            // 
            // lblPrivate
            // 
            lblPrivate.AutoSize = true;
            lblPrivate.Dock = DockStyle.Top;
            lblPrivate.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblPrivate.ForeColor = Color.Gray;
            lblPrivate.Location = new Point(0, 0);
            lblPrivate.Name = "lblPrivate";
            lblPrivate.Padding = new Padding(5, 4, 0, 0);
            lblPrivate.Size = new Size(70, 24);
            lblPrivate.TabIndex = 5;
            lblPrivate.Text = "PRIVATE";
            // 
            // btnAddPrivatePage
            // 
            btnAddPrivatePage.Cursor = Cursors.Hand;
            btnAddPrivatePage.Dock = DockStyle.Right;
            btnAddPrivatePage.FlatAppearance.BorderSize = 0;
            btnAddPrivatePage.FlatStyle = FlatStyle.Flat;
            btnAddPrivatePage.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnAddPrivatePage.ForeColor = Color.Gray;
            btnAddPrivatePage.Location = new Point(267, 0);
            btnAddPrivatePage.Margin = new Padding(3, 4, 3, 4);
            btnAddPrivatePage.Name = "btnAddPrivatePage";
            btnAddPrivatePage.Size = new Size(35, 32);
            btnAddPrivatePage.TabIndex = 6;
            btnAddPrivatePage.Text = "+";
            btnAddPrivatePage.UseVisualStyleBackColor = true;
            btnAddPrivatePage.Click += add_private_item_click;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(btnRecent);
            panel1.Controls.Add(btnFavorites);
            panel1.Controls.Add(btnShared);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(9, 106);
            panel1.Margin = new Padding(10, 11, 10, 11);
            panel1.Name = "panel1";
            panel1.Size = new Size(302, 168);
            panel1.TabIndex = 8;
            // 
            // btnRecent
            // 
            btnRecent.Dock = DockStyle.Top;
            btnRecent.FlatAppearance.BorderSize = 0;
            btnRecent.FlatStyle = FlatStyle.Flat;
            btnRecent.Font = new Font("Segoe UI", 9.75F);
            btnRecent.ForeColor = Color.FromArgb(50, 50, 50);
            btnRecent.Location = new Point(0, 59);
            btnRecent.Margin = new Padding(3, 4, 3, 4);
            btnRecent.Name = "btnRecent";
            btnRecent.Padding = new Padding(5, 0, 0, 0);
            btnRecent.Size = new Size(302, 45);
            btnRecent.TabIndex = 2;
            btnRecent.Text = "🕒 Gần đây";
            btnRecent.TextAlign = ContentAlignment.MiddleLeft;
            btnRecent.UseVisualStyleBackColor = true;
            // 
            // btnFavorites
            // 
            btnFavorites.Dock = DockStyle.Top;
            btnFavorites.FlatAppearance.BorderSize = 0;
            btnFavorites.FlatStyle = FlatStyle.Flat;
            btnFavorites.Font = new Font("Segoe UI", 9.75F);
            btnFavorites.ForeColor = Color.FromArgb(50, 50, 50);
            btnFavorites.Location = new Point(0, 0);
            btnFavorites.Margin = new Padding(3, 4, 3, 4);
            btnFavorites.Name = "btnFavorites";
            btnFavorites.Padding = new Padding(5, 0, 0, 0);
            btnFavorites.Size = new Size(302, 59);
            btnFavorites.TabIndex = 3;
            btnFavorites.Text = "⭐ Yêu thích";
            btnFavorites.TextAlign = ContentAlignment.MiddleLeft;
            btnFavorites.UseVisualStyleBackColor = true;
            // 
            // btnShared
            // 
            btnShared.Dock = DockStyle.Bottom;
            btnShared.FlatAppearance.BorderSize = 0;
            btnShared.FlatStyle = FlatStyle.Flat;
            btnShared.Font = new Font("Segoe UI", 9.75F);
            btnShared.ForeColor = Color.FromArgb(50, 50, 50);
            btnShared.Location = new Point(0, 104);
            btnShared.Margin = new Padding(3, 4, 3, 4);
            btnShared.Name = "btnShared";
            btnShared.Padding = new Padding(5, 0, 0, 0);
            btnShared.Size = new Size(302, 64);
            btnShared.TabIndex = 4;
            btnShared.Text = "\U0001f91d Được chia sẻ";
            btnShared.TextAlign = ContentAlignment.MiddleLeft;
            btnShared.UseVisualStyleBackColor = true;
            // 
            // userPanel
            // 
            userPanel.Controls.Add(panel3);
            userPanel.Controls.Add(lblUserName);
            userPanel.Dock = DockStyle.Top;
            userPanel.Location = new Point(9, 11);
            userPanel.Margin = new Padding(3, 4, 3, 4);
            userPanel.Name = "userPanel";
            userPanel.Padding = new Padding(6, 7, 6, 11);
            userPanel.Size = new Size(302, 95);
            userPanel.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(pictureBox1);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(6, 48);
            panel3.Name = "panel3";
            panel3.Size = new Size(290, 36);
            panel3.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox1.BackColor = Color.FromArgb(247, 247, 247);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 9.75F);
            textBox1.Location = new Point(31, 7);
            textBox1.Margin = new Padding(11, 13, 11, 13);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "    Tìm kiếm";
            textBox1.Size = new Size(259, 22);
            textBox1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(31, 36);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Dock = DockStyle.Top;
            lblUserName.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblUserName.ForeColor = Color.FromArgb(50, 50, 50);
            lblUserName.Location = new Point(6, 7);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(162, 25);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "👤 Nguyễn Văn A";
            // 
            // footerPanel
            // 
            footerPanel.Controls.Add(btnSettings);
            footerPanel.Controls.Add(btnTrash);
            footerPanel.Dock = DockStyle.Bottom;
            footerPanel.Location = new Point(9, 812);
            footerPanel.Margin = new Padding(3, 4, 3, 4);
            footerPanel.Name = "footerPanel";
            footerPanel.Size = new Size(302, 85);
            footerPanel.TabIndex = 7;
            // 
            // btnSettings
            // 
            btnSettings.Dock = DockStyle.Top;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 9.75F);
            btnSettings.ForeColor = Color.FromArgb(50, 50, 50);
            btnSettings.Location = new Point(0, 40);
            btnSettings.Margin = new Padding(3, 4, 3, 4);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(302, 40);
            btnSettings.TabIndex = 1;
            btnSettings.Text = "⚙️ Cài đặt";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btn_CaiDat;
            // 
            // btnTrash
            // 
            btnTrash.Dock = DockStyle.Top;
            btnTrash.FlatAppearance.BorderSize = 0;
            btnTrash.FlatStyle = FlatStyle.Flat;
            btnTrash.Font = new Font("Segoe UI", 9.75F);
            btnTrash.ForeColor = Color.FromArgb(50, 50, 50);
            btnTrash.Location = new Point(0, 0);
            btnTrash.Margin = new Padding(3, 4, 3, 4);
            btnTrash.Name = "btnTrash";
            btnTrash.Size = new Size(302, 40);
            btnTrash.TabIndex = 0;
            btnTrash.Text = "🗑️ Thùng rác";
            btnTrash.TextAlign = ContentAlignment.MiddleLeft;
            btnTrash.UseVisualStyleBackColor = true;
            btnTrash.Click += btnTrash_Click;
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.BackColor = Color.White;
            mainPanel.Controls.Add(lblBody);
            mainPanel.Controls.Add(lblWelcome);
            mainPanel.Controls.Add(lblTitle);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(320, 60);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(171, 80, 171, 80);
            mainPanel.Size = new Size(919, 848);
            mainPanel.TabIndex = 1;
            // 
            // lblBody
            // 
            lblBody.AutoSize = true;
            lblBody.Dock = DockStyle.Top;
            lblBody.Font = new Font("Segoe UI", 11.25F);
            lblBody.ForeColor = Color.FromArgb(40, 40, 40);
            lblBody.Location = new Point(171, 80);
            lblBody.Margin = new Padding(3, 0, 3, 13);
            lblBody.Name = "lblBody";
            lblBody.Padding = new Padding(0, 0, 0, 13);
            lblBody.Size = new Size(0, 38);
            lblBody.TabIndex = 4;
            // 
            // lblWelcome
            // 
            lblWelcome.Anchor = AnchorStyles.None;
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(20, 20, 20);
            lblWelcome.Location = new Point(280, 354);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Padding = new Padding(0, 27, 0, 0);
            lblWelcome.Size = new Size(450, 68);
            lblWelcome.TabIndex = 3;
            lblWelcome.Text = "Chào mừng đến với Notion! 👋";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(261, 273);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(469, 81);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Getting Started";
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.White;
            headerPanel.Controls.Add(lblHeaderTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(320, 0);
            headerPanel.Margin = new Padding(3, 4, 3, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(919, 60);
            headerPanel.TabIndex = 2;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 9.75F);
            lblHeaderTitle.ForeColor = Color.FromArgb(40, 40, 40);
            lblHeaderTitle.Location = new Point(22, 19);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(203, 23);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Desktop App Home Form";
            // 
            // Trangchu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1239, 908);
            Controls.Add(mainPanel);
            Controls.Add(headerPanel);
            Controls.Add(sidebarPanel);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(912, 782);
            Name = "Trangchu";
            Text = "Trangchu";
            sidebarPanel.ResumeLayout(false);
            sidebarPanel.PerformLayout();
            panel.ResumeLayout(false);
            privateHeaderPanel.ResumeLayout(false);
            privateHeaderPanel.PerformLayout();
            panel1.ResumeLayout(false);
            userPanel.ResumeLayout(false);
            userPanel.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            footerPanel.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnRecent;
        private System.Windows.Forms.Button btnShared;
        private System.Windows.Forms.Button btnFavorites;
        private System.Windows.Forms.Label lblPrivate;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnTrash;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblBody;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel privateHeaderPanel;
        private System.Windows.Forms.Button btnAddPrivatePage;
        private TextBox textBox1;
        private Panel panel1;
        private Panel panel;
        private Panel panel3;
        private PictureBox pictureBox1;
        private Panel private_item_panel;
    }

}
