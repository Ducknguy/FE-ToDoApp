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
            panel2 = new Panel();
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
            lblRocket = new Label();
            headerPanel = new Panel();
            lblHeaderTitle = new Label();
            sidebarPanel.SuspendLayout();
            panel2.SuspendLayout();
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
            sidebarPanel.Controls.Add(panel2);
            sidebarPanel.Controls.Add(panel1);
            sidebarPanel.Controls.Add(userPanel);
            sidebarPanel.Controls.Add(footerPanel);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Padding = new Padding(8);
            sidebarPanel.Size = new Size(280, 681);
            sidebarPanel.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(privateHeaderPanel);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(8, 205);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(264, 404);
            panel2.TabIndex = 9;
            // 
            // privateHeaderPanel
            // 
            privateHeaderPanel.BackColor = Color.FromArgb(247, 247, 247);
            privateHeaderPanel.Controls.Add(lblPrivate);
            privateHeaderPanel.Controls.Add(btnAddPrivatePage);
            privateHeaderPanel.Dock = DockStyle.Top;
            privateHeaderPanel.Location = new Point(0, 0);
            privateHeaderPanel.Name = "privateHeaderPanel";
            privateHeaderPanel.Size = new Size(264, 25);
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
            lblPrivate.Padding = new Padding(4, 3, 0, 0);
            lblPrivate.Size = new Size(56, 18);
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
            btnAddPrivatePage.Location = new Point(233, 0);
            btnAddPrivatePage.Name = "btnAddPrivatePage";
            btnAddPrivatePage.Size = new Size(31, 25);
            btnAddPrivatePage.TabIndex = 6;
            btnAddPrivatePage.Text = "+";
            btnAddPrivatePage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(btnRecent);
            panel1.Controls.Add(btnFavorites);
            panel1.Controls.Add(btnShared);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(8, 79);
            panel1.Margin = new Padding(9, 8, 9, 8);
            panel1.Name = "panel1";
            panel1.Size = new Size(264, 126);
            panel1.TabIndex = 8;
            // 
            // btnRecent
            // 
            btnRecent.Dock = DockStyle.Top;
            btnRecent.FlatAppearance.BorderSize = 0;
            btnRecent.FlatStyle = FlatStyle.Flat;
            btnRecent.Font = new Font("Segoe UI", 9.75F);
            btnRecent.ForeColor = Color.FromArgb(50, 50, 50);
            btnRecent.Location = new Point(0, 44);
            btnRecent.Name = "btnRecent";
            btnRecent.Padding = new Padding(4, 0, 0, 0);
            btnRecent.Size = new Size(264, 34);
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
            btnFavorites.Name = "btnFavorites";
            btnFavorites.Padding = new Padding(4, 0, 0, 0);
            btnFavorites.Size = new Size(264, 44);
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
            btnShared.Location = new Point(0, 78);
            btnShared.Name = "btnShared";
            btnShared.Padding = new Padding(4, 0, 0, 0);
            btnShared.Size = new Size(264, 48);
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
            userPanel.Location = new Point(8, 8);
            userPanel.Name = "userPanel";
            userPanel.Padding = new Padding(5, 5, 5, 8);
            userPanel.Size = new Size(264, 71);
            userPanel.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(pictureBox1);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(5, 36);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(254, 27);
            panel3.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox1.BackColor = Color.FromArgb(247, 247, 247);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 9.75F);
            textBox1.Location = new Point(27, 5);
            textBox1.Margin = new Padding(10);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "    Tìm kiếm";
            textBox1.Size = new Size(227, 18);
            textBox1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(27, 27);
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
            lblUserName.Location = new Point(5, 5);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(134, 20);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "👤 Nguyễn Văn A";
            // 
            // footerPanel
            // 
            footerPanel.Controls.Add(btnSettings);
            footerPanel.Controls.Add(btnTrash);
            footerPanel.Dock = DockStyle.Bottom;
            footerPanel.Location = new Point(8, 609);
            footerPanel.Name = "footerPanel";
            footerPanel.Size = new Size(264, 64);
            footerPanel.TabIndex = 7;
            // 
            // btnSettings
            // 
            btnSettings.Dock = DockStyle.Top;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 9.75F);
            btnSettings.ForeColor = Color.FromArgb(50, 50, 50);
            btnSettings.Location = new Point(0, 30);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(264, 30);
            btnSettings.TabIndex = 1;
            btnSettings.Text = "⚙️ Cài đặt";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.UseVisualStyleBackColor = true;
            // 
            // btnTrash
            // 
            btnTrash.Dock = DockStyle.Top;
            btnTrash.FlatAppearance.BorderSize = 0;
            btnTrash.FlatStyle = FlatStyle.Flat;
            btnTrash.Font = new Font("Segoe UI", 9.75F);
            btnTrash.ForeColor = Color.FromArgb(50, 50, 50);
            btnTrash.Location = new Point(0, 0);
            btnTrash.Name = "btnTrash";
            btnTrash.Size = new Size(264, 30);
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
            mainPanel.Controls.Add(lblRocket);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(280, 45);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(150, 60, 150, 60);
            mainPanel.Size = new Size(804, 636);
            mainPanel.TabIndex = 1;
            // 
            // lblBody
            // 
            lblBody.AutoSize = true;
            lblBody.Dock = DockStyle.Top;
            lblBody.Font = new Font("Segoe UI", 11.25F);
            lblBody.ForeColor = Color.FromArgb(40, 40, 40);
            lblBody.Location = new Point(150, 315);
            lblBody.Margin = new Padding(3, 0, 3, 10);
            lblBody.Name = "lblBody";
            lblBody.Padding = new Padding(0, 0, 0, 10);
            lblBody.Size = new Size(0, 30);
            lblBody.TabIndex = 4;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Dock = DockStyle.Top;
            lblWelcome.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(20, 20, 20);
            lblWelcome.Location = new Point(150, 263);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Padding = new Padding(0, 20, 0, 0);
            lblWelcome.Size = new Size(360, 52);
            lblWelcome.TabIndex = 3;
            lblWelcome.Text = "Chào mừng đến với Notion! 👋";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(150, 198);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(378, 65);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Getting Started";
            // 
            // lblRocket
            // 
            lblRocket.AutoSize = true;
            lblRocket.Dock = DockStyle.Top;
            lblRocket.Font = new Font("Segoe UI", 72F);
            lblRocket.Location = new Point(150, 60);
            lblRocket.Name = "lblRocket";
            lblRocket.Padding = new Padding(0, 0, 0, 10);
            lblRocket.Size = new Size(186, 138);
            lblRocket.TabIndex = 0;
            lblRocket.Text = "🚀";
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.White;
            headerPanel.Controls.Add(lblHeaderTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(280, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(804, 45);
            headerPanel.TabIndex = 2;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 9.75F);
            lblHeaderTitle.ForeColor = Color.FromArgb(40, 40, 40);
            lblHeaderTitle.Location = new Point(19, 14);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(157, 17);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Desktop App Home Form";
            // 
            // Trangchu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 681);
            Controls.Add(mainPanel);
            Controls.Add(headerPanel);
            Controls.Add(sidebarPanel);
            MinimumSize = new Size(800, 598);
            Name = "Trangchu";
            Text = "Trangchu";
            sidebarPanel.ResumeLayout(false);
            sidebarPanel.PerformLayout();
            panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblRocket;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblBody;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel privateHeaderPanel;
        private System.Windows.Forms.Button btnAddPrivatePage;
        private TextBox textBox1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private PictureBox pictureBox1;
    }

}
