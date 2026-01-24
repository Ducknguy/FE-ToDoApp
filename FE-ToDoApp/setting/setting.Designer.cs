namespace FE_ToDoApp.Setting
{
    partial class setting
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            sidebarPanel = new Panel();
            btnGiaoDien = new Button();
            btnThongTinCaNhan = new Button();
            panelUserSidebar = new Panel();
            lblSidebarName = new Label();
            panelAccount = new Panel();
            tableLayoutAccount = new TableLayoutPanel();
            panelRightAvatar = new Panel();
            btnDoiAnh = new Button();
            panelAvatar = new Panel();
            lblAvatarText = new Label();
            panelLeftInfo = new Panel();
            grpPassword = new GroupBox();
            chkShowPassword = new CheckBox();
            btnLuuMatKhau = new Button();
            txtPassXacNhan = new TextBox();
            label5 = new Label();
            txtPassMoi = new TextBox();
            label4 = new Label();
            txtPassCu = new TextBox();
            label3 = new Label();
            grpInfo = new GroupBox();
            btnLuuThongTin = new Button();
            txtEmail = new TextBox();
            label2 = new Label();
            txtTenHienThi = new TextBox();
            label1 = new Label();
            panelAppearance = new Panel();
            cmbGiaoDien = new ComboBox();
            lblThemeDesc = new Label();
            lblThemeTitle = new Label();
            lblHeaderAppearance = new Label();
            openFileDialogAvatar = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            sidebarPanel.SuspendLayout();
            panelUserSidebar.SuspendLayout();
            panelAccount.SuspendLayout();
            tableLayoutAccount.SuspendLayout();
            panelRightAvatar.SuspendLayout();
            panelAvatar.SuspendLayout();
            panelLeftInfo.SuspendLayout();
            grpPassword.SuspendLayout();
            grpInfo.SuspendLayout();
            panelAppearance.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.White;
            splitContainer1.Panel1.Controls.Add(sidebarPanel);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelAccount);
            splitContainer1.Panel2.Controls.Add(panelAppearance);
            splitContainer1.Size = new Size(984, 661);
            splitContainer1.SplitterDistance = 250;
            splitContainer1.TabIndex = 0;
            // 
            // sidebarPanel
            // 
            sidebarPanel.Controls.Add(btnGiaoDien);
            sidebarPanel.Controls.Add(btnThongTinCaNhan);
            sidebarPanel.Controls.Add(panelUserSidebar);
            sidebarPanel.Dock = DockStyle.Fill;
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Padding = new Padding(10);
            sidebarPanel.Size = new Size(250, 661);
            sidebarPanel.TabIndex = 0;
            // 
            // btnGiaoDien
            // 
            btnGiaoDien.Dock = DockStyle.Top;
            btnGiaoDien.FlatAppearance.BorderSize = 0;
            btnGiaoDien.FlatStyle = FlatStyle.Flat;
            btnGiaoDien.Font = new Font("Segoe UI", 10F);
            btnGiaoDien.Location = new Point(10, 110);
            btnGiaoDien.Name = "btnGiaoDien";
            btnGiaoDien.Size = new Size(230, 40);
            btnGiaoDien.TabIndex = 2;
            btnGiaoDien.Text = "🎨  Cài đặt Giao diện";
            btnGiaoDien.TextAlign = ContentAlignment.MiddleLeft;
            btnGiaoDien.UseVisualStyleBackColor = true;
            // 
            // btnThongTinCaNhan
            // 
            btnThongTinCaNhan.Dock = DockStyle.Top;
            btnThongTinCaNhan.FlatAppearance.BorderSize = 0;
            btnThongTinCaNhan.FlatStyle = FlatStyle.Flat;
            btnThongTinCaNhan.Font = new Font("Segoe UI", 10F);
            btnThongTinCaNhan.Location = new Point(10, 70);
            btnThongTinCaNhan.Name = "btnThongTinCaNhan";
            btnThongTinCaNhan.Size = new Size(230, 40);
            btnThongTinCaNhan.TabIndex = 1;
            btnThongTinCaNhan.Text = "👤  Thông tin cá nhân";
            btnThongTinCaNhan.TextAlign = ContentAlignment.MiddleLeft;
            btnThongTinCaNhan.UseVisualStyleBackColor = true;
            // 
            // panelUserSidebar
            // 
            panelUserSidebar.Controls.Add(lblSidebarName);
            panelUserSidebar.Dock = DockStyle.Top;
            panelUserSidebar.Location = new Point(10, 10);
            panelUserSidebar.Name = "panelUserSidebar";
            panelUserSidebar.Size = new Size(230, 60);
            panelUserSidebar.TabIndex = 0;
            // 
            // lblSidebarName
            // 
            lblSidebarName.AutoSize = true;
            lblSidebarName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSidebarName.Location = new Point(5, 15);
            lblSidebarName.Name = "lblSidebarName";
            lblSidebarName.Size = new Size(116, 28);
            lblSidebarName.TabIndex = 0;
            lblSidebarName.Text = "User Name";
            // 
            // panelAccount
            // 
            panelAccount.AutoScroll = true;
            panelAccount.Controls.Add(tableLayoutAccount);
            panelAccount.Dock = DockStyle.Fill;
            panelAccount.Location = new Point(0, 0);
            panelAccount.Name = "panelAccount";
            panelAccount.Padding = new Padding(20);
            panelAccount.Size = new Size(730, 661);
            panelAccount.TabIndex = 0;
            // 
            // tableLayoutAccount
            // 
            tableLayoutAccount.ColumnCount = 2;
            tableLayoutAccount.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutAccount.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutAccount.Controls.Add(panelRightAvatar, 1, 0);
            tableLayoutAccount.Controls.Add(panelLeftInfo, 0, 0);
            tableLayoutAccount.Dock = DockStyle.Top;
            tableLayoutAccount.Location = new Point(20, 20);
            tableLayoutAccount.Name = "tableLayoutAccount";
            tableLayoutAccount.RowCount = 1;
            tableLayoutAccount.RowStyles.Add(new RowStyle());
            tableLayoutAccount.Size = new Size(690, 600);
            tableLayoutAccount.TabIndex = 0;
            // 
            // panelRightAvatar
            // 
            panelRightAvatar.Controls.Add(btnDoiAnh);
            panelRightAvatar.Controls.Add(panelAvatar);
            panelRightAvatar.Dock = DockStyle.Top;
            panelRightAvatar.Location = new Point(451, 3);
            panelRightAvatar.Name = "panelRightAvatar";
            panelRightAvatar.Size = new Size(236, 250);
            panelRightAvatar.TabIndex = 1;
            // 
            // btnDoiAnh
            // 
            btnDoiAnh.Location = new Point(68, 170);
            btnDoiAnh.Name = "btnDoiAnh";
            btnDoiAnh.Size = new Size(100, 30);
            btnDoiAnh.TabIndex = 1;
            btnDoiAnh.Text = "Chọn ảnh...";
            btnDoiAnh.UseVisualStyleBackColor = true;
            btnDoiAnh.Click += btnDoiAnh_Click;
            // 
            // panelAvatar
            // 
            panelAvatar.BackColor = Color.Gainsboro;
            panelAvatar.BackgroundImageLayout = ImageLayout.Zoom;
            panelAvatar.Controls.Add(lblAvatarText);
            panelAvatar.Location = new Point(43, 10);
            panelAvatar.Name = "panelAvatar";
            panelAvatar.Size = new Size(150, 150);
            panelAvatar.TabIndex = 0;
            // 
            // lblAvatarText
            // 
            lblAvatarText.Dock = DockStyle.Fill;
            lblAvatarText.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblAvatarText.Location = new Point(0, 0);
            lblAvatarText.Name = "lblAvatarText";
            lblAvatarText.Size = new Size(150, 150);
            lblAvatarText.TabIndex = 0;
            lblAvatarText.Text = "Q";
            lblAvatarText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelLeftInfo
            // 
            panelLeftInfo.Controls.Add(grpPassword);
            panelLeftInfo.Controls.Add(grpInfo);
            panelLeftInfo.Dock = DockStyle.Top;
            panelLeftInfo.Location = new Point(3, 3);
            panelLeftInfo.Name = "panelLeftInfo";
            panelLeftInfo.Size = new Size(442, 590);
            panelLeftInfo.TabIndex = 0;
            // 
            // grpPassword
            // 
            grpPassword.Controls.Add(chkShowPassword);
            grpPassword.Controls.Add(btnLuuMatKhau);
            grpPassword.Controls.Add(txtPassXacNhan);
            grpPassword.Controls.Add(label5);
            grpPassword.Controls.Add(txtPassMoi);
            grpPassword.Controls.Add(label4);
            grpPassword.Controls.Add(txtPassCu);
            grpPassword.Controls.Add(label3);
            grpPassword.Dock = DockStyle.Top;
            grpPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpPassword.Location = new Point(0, 260);
            grpPassword.Name = "grpPassword";
            grpPassword.Size = new Size(442, 300);
            grpPassword.TabIndex = 1;
            grpPassword.TabStop = false;
            grpPassword.Text = "THAY ĐỔI MẬT KHẨU";
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.BackgroundImageLayout = ImageLayout.Center;
            chkShowPassword.Location = new Point(22, 223);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(177, 27);
            chkShowPassword.TabIndex = 7;
            chkShowPassword.Text = "Hiển thị mật khẩu";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged_1;
            // 
            // btnLuuMatKhau
            // 
            btnLuuMatKhau.BackColor = Color.ForestGreen;
            btnLuuMatKhau.FlatAppearance.BorderSize = 0;
            btnLuuMatKhau.FlatStyle = FlatStyle.Flat;
            btnLuuMatKhau.ForeColor = Color.White;
            btnLuuMatKhau.Location = new Point(150, 259);
            btnLuuMatKhau.Name = "btnLuuMatKhau";
            btnLuuMatKhau.Size = new Size(141, 35);
            btnLuuMatKhau.TabIndex = 6;
            btnLuuMatKhau.Text = "Lưu mật khẩu";
            btnLuuMatKhau.UseVisualStyleBackColor = false;
            btnLuuMatKhau.Click += btnLuuMatKhau_Click;
            // 
            // txtPassXacNhan
            // 
            txtPassXacNhan.Font = new Font("Segoe UI", 10F);
            txtPassXacNhan.Location = new Point(201, 180);
            txtPassXacNhan.Name = "txtPassXacNhan";
            txtPassXacNhan.PasswordChar = '*';
            txtPassXacNhan.Size = new Size(199, 30);
            txtPassXacNhan.TabIndex = 5;
            txtPassXacNhan.TextChanged += txtPassXacNhan_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(20, 183);
            label5.Name = "label5";
            label5.Size = new Size(155, 23);
            label5.TabIndex = 4;
            label5.Text = "Nhập lại mật khẩu:";
            // 
            // txtPassMoi
            // 
            txtPassMoi.Font = new Font("Segoe UI", 10F);
            txtPassMoi.Location = new Point(201, 120);
            txtPassMoi.Name = "txtPassMoi";
            txtPassMoi.PasswordChar = '*';
            txtPassMoi.Size = new Size(199, 30);
            txtPassMoi.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(20, 123);
            label4.Name = "label4";
            label4.Size = new Size(120, 23);
            label4.TabIndex = 2;
            label4.Text = "Mật khẩu mới:";
            // 
            // txtPassCu
            // 
            txtPassCu.Font = new Font("Segoe UI", 10F);
            txtPassCu.Location = new Point(201, 60);
            txtPassCu.Name = "txtPassCu";
            txtPassCu.PasswordChar = '*';
            txtPassCu.Size = new Size(199, 30);
            txtPassCu.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(20, 63);
            label3.Name = "label3";
            label3.Size = new Size(109, 23);
            label3.TabIndex = 0;
            label3.Text = "Mật khẩu cũ:";
            // 
            // grpInfo
            // 
            grpInfo.Controls.Add(btnLuuThongTin);
            grpInfo.Controls.Add(txtEmail);
            grpInfo.Controls.Add(label2);
            grpInfo.Controls.Add(txtTenHienThi);
            grpInfo.Controls.Add(label1);
            grpInfo.Dock = DockStyle.Top;
            grpInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpInfo.Location = new Point(0, 0);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(442, 260);
            grpInfo.TabIndex = 0;
            grpInfo.TabStop = false;
            grpInfo.Text = "THÔNG TIN CÁ NHÂN";
            // 
            // btnLuuThongTin
            // 
            btnLuuThongTin.BackColor = Color.ForestGreen;
            btnLuuThongTin.FlatAppearance.BorderSize = 0;
            btnLuuThongTin.FlatStyle = FlatStyle.Flat;
            btnLuuThongTin.ForeColor = Color.White;
            btnLuuThongTin.Location = new Point(150, 180);
            btnLuuThongTin.Name = "btnLuuThongTin";
            btnLuuThongTin.Size = new Size(141, 35);
            btnLuuThongTin.TabIndex = 4;
            btnLuuThongTin.Text = "Lưu thay đổi";
            btnLuuThongTin.UseVisualStyleBackColor = false;
            btnLuuThongTin.Click += btnLuuThongTin_Click;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(150, 120);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 30);
            txtEmail.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(20, 123);
            label2.Name = "label2";
            label2.Size = new Size(55, 23);
            label2.TabIndex = 2;
            label2.Text = "Email:";
            // 
            // txtTenHienThi
            // 
            txtTenHienThi.Font = new Font("Segoe UI", 10F);
            txtTenHienThi.Location = new Point(150, 60);
            txtTenHienThi.Name = "txtTenHienThi";
            txtTenHienThi.Size = new Size(250, 30);
            txtTenHienThi.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(20, 63);
            label1.Name = "label1";
            label1.Size = new Size(134, 23);
            label1.TabIndex = 0;
            label1.Text = "Tên người dùng:";
            // 
            // panelAppearance
            // 
            panelAppearance.Controls.Add(cmbGiaoDien);
            panelAppearance.Controls.Add(lblThemeDesc);
            panelAppearance.Controls.Add(lblThemeTitle);
            panelAppearance.Controls.Add(lblHeaderAppearance);
            panelAppearance.Dock = DockStyle.Fill;
            panelAppearance.Location = new Point(0, 0);
            panelAppearance.Name = "panelAppearance";
            panelAppearance.Padding = new Padding(40);
            panelAppearance.Size = new Size(730, 661);
            panelAppearance.TabIndex = 1;
            panelAppearance.Visible = false;
            // 
            // cmbGiaoDien
            // 
            cmbGiaoDien.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGiaoDien.Font = new Font("Segoe UI", 10F);
            cmbGiaoDien.FormattingEnabled = true;
            cmbGiaoDien.Items.AddRange(new object[] { "Sáng", "Tối" });
            cmbGiaoDien.Location = new Point(42, 160);
            cmbGiaoDien.Name = "cmbGiaoDien";
            cmbGiaoDien.Size = new Size(200, 31);
            cmbGiaoDien.TabIndex = 3;
            cmbGiaoDien.SelectedIndexChanged += cmbGiaoDien_SelectedIndexChanged;
            // 
            // lblThemeDesc
            // 
            lblThemeDesc.AutoSize = true;
            lblThemeDesc.ForeColor = Color.Gray;
            lblThemeDesc.Location = new Point(40, 130);
            lblThemeDesc.Name = "lblThemeDesc";
            lblThemeDesc.Size = new Size(372, 19);
            lblThemeDesc.TabIndex = 2;
            lblThemeDesc.Text = "Tùy chỉnh giao diện hiển thị của ứng dụng trên thiết bị này.";
            // 
            // lblThemeTitle
            // 
            lblThemeTitle.AutoSize = true;
            lblThemeTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblThemeTitle.Location = new Point(40, 105);
            lblThemeTitle.Name = "lblThemeTitle";
            lblThemeTitle.Size = new Size(118, 25);
            lblThemeTitle.TabIndex = 1;
            lblThemeTitle.Text = "Chế độ màu";
            // 
            // lblHeaderAppearance
            // 
            lblHeaderAppearance.AutoSize = true;
            lblHeaderAppearance.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblHeaderAppearance.Location = new Point(35, 40);
            lblHeaderAppearance.Name = "lblHeaderAppearance";
            lblHeaderAppearance.Size = new Size(172, 46);
            lblHeaderAppearance.TabIndex = 0;
            lblHeaderAppearance.Text = "Giao diện";
            // 
            // openFileDialogAvatar
            // 
            openFileDialogAvatar.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            // 
            // setting
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(984, 661);
            Controls.Add(splitContainer1);
            Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "setting";
            Text = "Cài đặt";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            sidebarPanel.ResumeLayout(false);
            panelUserSidebar.ResumeLayout(false);
            panelUserSidebar.PerformLayout();
            panelAccount.ResumeLayout(false);
            tableLayoutAccount.ResumeLayout(false);
            panelRightAvatar.ResumeLayout(false);
            panelAvatar.ResumeLayout(false);
            panelLeftInfo.ResumeLayout(false);
            grpPassword.ResumeLayout(false);
            grpPassword.PerformLayout();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            panelAppearance.ResumeLayout(false);
            panelAppearance.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Button btnGiaoDien;
        private System.Windows.Forms.Button btnThongTinCaNhan;
        private System.Windows.Forms.Panel panelUserSidebar;
        private System.Windows.Forms.Label lblSidebarName;
        private System.Windows.Forms.Panel panelAccount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutAccount;
        private System.Windows.Forms.Panel panelLeftInfo;
        private System.Windows.Forms.Panel panelRightAvatar;
        private System.Windows.Forms.Panel panelAvatar;
        private System.Windows.Forms.Label lblAvatarText;
        private System.Windows.Forms.Button btnDoiAnh;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.GroupBox grpPassword;
        private System.Windows.Forms.Panel panelAppearance;
        private System.Windows.Forms.Label lblHeaderAppearance;
        private System.Windows.Forms.Label lblThemeTitle;
        private System.Windows.Forms.Label lblThemeDesc;
        private System.Windows.Forms.ComboBox cmbGiaoDien;
        private System.Windows.Forms.OpenFileDialog openFileDialogAvatar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenHienThi;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLuuThongTin;
        private System.Windows.Forms.Button btnLuuMatKhau;
        private System.Windows.Forms.TextBox txtPassXacNhan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPassMoi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassCu;
        private System.Windows.Forms.Label label3;
        private CheckBox chkShowPassword;
    }
}