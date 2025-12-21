using System.Windows.Forms;
using System.Drawing;

namespace FE_ToDoApp.Setting
{
    partial class setting
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            sidebarPanel = new Panel();
            btnTuyChon = new Button();
            panelTaiKhoan = new Panel();
            lblTaiKhoan = new Label();
            panelSettings = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            cmbNgonNgu = new ComboBox();
            lblMoTaNgonNgu = new Label();
            lblNgonNgu = new Label();
            cmbGiaoDien = new ComboBox();
            lblMoTaGiaoDien = new Label();
            lblGiaoDien = new Label();
            line1 = new Panel();
            lblTieuDeTuyChon = new Label();
            panelAccount = new Panel();
            lblEmailValue = new Label();
            lblEmail = new Label();
            linkThemAnh = new LinkLabel();
            txtTenUaDung = new TextBox();
            lblTenUaDung = new Label();
            panelAvatar = new Panel();
            lblAvatarText = new Label();
            lblTieuDeTaiKhoan = new Label();
            imageList1 = new ImageList(components);
            openFileDialogAvatar = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            sidebarPanel.SuspendLayout();
            panelTaiKhoan.SuspendLayout();
            panelSettings.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panelAccount.SuspendLayout();
            panelAvatar.SuspendLayout();
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
            splitContainer1.Panel1.Tag = "Sidebar";
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.AutoScroll = true;
            splitContainer1.Panel2.BackColor = Color.White;
            splitContainer1.Panel2.Controls.Add(panelSettings);
            splitContainer1.Panel2.Controls.Add(panelAccount);
            splitContainer1.Panel2.Padding = new Padding(40, 20, 40, 20);
            splitContainer1.Size = new Size(984, 761);
            splitContainer1.SplitterDistance = 280;
            splitContainer1.TabIndex = 0;
            // 
            // sidebarPanel
            // 
            sidebarPanel.AutoScroll = true;
            sidebarPanel.Controls.Add(btnTuyChon);
            sidebarPanel.Controls.Add(panelTaiKhoan);
            sidebarPanel.Dock = DockStyle.Fill;
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Padding = new Padding(8);
            sidebarPanel.Size = new Size(280, 761);
            sidebarPanel.TabIndex = 0;
            sidebarPanel.Tag = "Sidebar";
            // 
            // btnTuyChon
            // 
            btnTuyChon.Dock = DockStyle.Top;
            btnTuyChon.FlatAppearance.BorderSize = 0;
            btnTuyChon.FlatStyle = FlatStyle.Flat;
            btnTuyChon.Location = new Point(8, 107);
            btnTuyChon.Name = "btnTuyChon";
            btnTuyChon.Padding = new Padding(15, 0, 0, 0);
            btnTuyChon.Size = new Size(264, 30);
            btnTuyChon.TabIndex = 1;
            btnTuyChon.Text = "     Tùy chọn";
            btnTuyChon.TextAlign = ContentAlignment.MiddleLeft;
            btnTuyChon.UseVisualStyleBackColor = true;
            // 
            // panelTaiKhoan
            // 
            panelTaiKhoan.Controls.Add(lblTaiKhoan);
            panelTaiKhoan.Cursor = Cursors.Hand;
            panelTaiKhoan.Dock = DockStyle.Top;
            panelTaiKhoan.Location = new Point(8, 8);
            panelTaiKhoan.Name = "panelTaiKhoan";
            panelTaiKhoan.Padding = new Padding(5, 0, 0, 0);
            panelTaiKhoan.Size = new Size(264, 99);
            panelTaiKhoan.TabIndex = 0;
            // 
            // lblTaiKhoan
            // 
            lblTaiKhoan.AutoSize = true;
            lblTaiKhoan.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTaiKhoan.Location = new Point(11, 41);
            lblTaiKhoan.Name = "lblTaiKhoan";
            lblTaiKhoan.Size = new Size(131, 23);
            lblTaiKhoan.TabIndex = 0;
            lblTaiKhoan.Text = "Quang Hòa Bùi";
            // 
            // panelNotifications
            // 
            panelNotifications.Controls.Add(linkTimHieuThongBao);
            panelNotifications.Controls.Add(linkQuanLyCaiDat);
            panelNotifications.Controls.Add(tableLayoutPanel8);
            panelNotifications.Controls.Add(tableLayoutPanel7);
            panelNotifications.Controls.Add(tableLayoutPanel6);
            panelNotifications.Controls.Add(tableLayoutPanel5);
            panelNotifications.Controls.Add(tableLayoutPanel4);
            panelNotifications.Controls.Add(lblThongBaoQuaEmail);
            panelNotifications.Controls.Add(panel1);
            panelNotifications.Controls.Add(tableLayoutPanelDiscord);
            panelNotifications.Controls.Add(lblTieuDeThongBao);
            panelNotifications.Dock = DockStyle.Top;
            panelNotifications.Location = new Point(40, 1349);
            panelNotifications.Name = "panelNotifications";
            panelNotifications.Size = new Size(599, 800);
            panelNotifications.TabIndex = 2;
            // 
            // linkTimHieuThongBao
            // 
            linkTimHieuThongBao.AutoSize = true;
            linkTimHieuThongBao.Location = new Point(9, 692);
            linkTimHieuThongBao.Name = "linkTimHieuThongBao";
            linkTimHieuThongBao.Size = new Size(183, 23);
            linkTimHieuThongBao.TabIndex = 10;
            linkTimHieuThongBao.TabStop = true;
            linkTimHieuThongBao.Text = "Tìm hiểu về thông báo";
            // 
            // linkQuanLyCaiDat
            // 
            linkQuanLyCaiDat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            linkQuanLyCaiDat.AutoSize = true;
            linkQuanLyCaiDat.Location = new Point(388, 638);
            linkQuanLyCaiDat.Name = "linkQuanLyCaiDat";
            linkQuanLyCaiDat.Size = new Size(125, 23);
            linkQuanLyCaiDat.TabIndex = 9;
            linkQuanLyCaiDat.TabStop = true;
            linkQuanLyCaiDat.Text = "Quản lý cài đặt";
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 2;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 84.13461F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.86538F));
            tableLayoutPanel8.Controls.Add(lblMoTaEmailThongBaoVaCapNhat, 0, 1);
            tableLayoutPanel8.Controls.Add(lblEmailThongBaoVaCapNhat, 0, 0);
            tableLayoutPanel8.Dock = DockStyle.Top;
            tableLayoutPanel8.Location = new Point(0, 559);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 2;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel8.Size = new Size(599, 81);
            tableLayoutPanel8.TabIndex = 8;
            // 
            // lblMoTaEmailThongBaoVaCapNhat
            // 
            lblMoTaEmailThongBaoVaCapNhat.AutoSize = true;
            tableLayoutPanel8.SetColumnSpan(lblMoTaEmailThongBaoVaCapNhat, 2);
            lblMoTaEmailThongBaoVaCapNhat.ForeColor = Color.Gray;
            lblMoTaEmailThongBaoVaCapNhat.Location = new Point(3, 35);
            lblMoTaEmailThongBaoVaCapNhat.Name = "lblMoTaEmailThongBaoVaCapNhat";
            lblMoTaEmailThongBaoVaCapNhat.Size = new Size(570, 46);
            lblMoTaEmailThongBaoVaCapNhat.TabIndex = 3;
            lblMoTaEmailThongBaoVaCapNhat.Text = "Nhận email không thường xuyên khi có đợt ra mắt sản phẩm và các tính năng mới từ Notion";
            // 
            // lblEmailThongBaoVaCapNhat
            // 
            lblEmailThongBaoVaCapNhat.AutoSize = true;
            lblEmailThongBaoVaCapNhat.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmailThongBaoVaCapNhat.Location = new Point(3, 0);
            lblEmailThongBaoVaCapNhat.Name = "lblEmailThongBaoVaCapNhat";
            lblEmailThongBaoVaCapNhat.Size = new Size(230, 23);
            lblEmailThongBaoVaCapNhat.TabIndex = 2;
            lblEmailThongBaoVaCapNhat.Text = "Email thông báo và cập nhật";
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 84.13461F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.86538F));
            tableLayoutPanel7.Controls.Add(chkBanTomTatKhongGianLamViec, 1, 0);
            tableLayoutPanel7.Controls.Add(lblMoTaBanTomTatKhongGianLamViec, 0, 1);
            tableLayoutPanel7.Controls.Add(lblBanTomTatKhongGianLamViec, 0, 0);
            tableLayoutPanel7.Dock = DockStyle.Top;
            tableLayoutPanel7.Location = new Point(0, 478);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 2;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel7.Size = new Size(599, 81);
            tableLayoutPanel7.TabIndex = 7;
            // 
            // chkBanTomTatKhongGianLamViec
            // 
            chkBanTomTatKhongGianLamViec.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkBanTomTatKhongGianLamViec.AutoSize = true;
            chkBanTomTatKhongGianLamViec.Checked = true;
            chkBanTomTatKhongGianLamViec.CheckState = CheckState.Checked;
            chkBanTomTatKhongGianLamViec.Location = new Point(578, 3);
            chkBanTomTatKhongGianLamViec.Name = "chkBanTomTatKhongGianLamViec";
            chkBanTomTatKhongGianLamViec.Size = new Size(18, 17);
            chkBanTomTatKhongGianLamViec.TabIndex = 4;
            chkBanTomTatKhongGianLamViec.UseVisualStyleBackColor = true;
            // panelSettings
            // 
            panelSettings.Controls.Add(tableLayoutPanel1);
            panelSettings.Controls.Add(line1);
            panelSettings.Controls.Add(lblTieuDeTuyChon);
            panelSettings.Dock = DockStyle.Top;
            panelSettings.Location = new Point(40, 420);
            panelSettings.Name = "panelSettings";
            panelSettings.Size = new Size(620, 209);
            panelSettings.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(cmbNgonNgu, 1, 2);
            tableLayoutPanel1.Controls.Add(lblMoTaNgonNgu, 0, 3);
            tableLayoutPanel1.Controls.Add(lblNgonNgu, 0, 2);
            tableLayoutPanel1.Controls.Add(cmbGiaoDien, 1, 0);
            tableLayoutPanel1.Controls.Add(lblMoTaGiaoDien, 0, 1);
            tableLayoutPanel1.Controls.Add(lblGiaoDien, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 71);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(620, 155);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // cmbNgonNgu
            // 
            cmbNgonNgu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbNgonNgu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNgonNgu.FormattingEnabled = true;
            cmbNgonNgu.Items.AddRange(new object[] { "Tiếng Việt", "Tiếng Anh" });
            cmbNgonNgu.Location = new Point(406, 81);
            cmbNgonNgu.Name = "cmbNgonNgu";
            cmbNgonNgu.Size = new Size(211, 29);
            cmbNgonNgu.TabIndex = 5;
            cmbNgonNgu.SelectedIndexChanged += cmbNgonNgu_SelectedIndexChanged;
            // 
            // lblMoTaNgonNgu
            // 
            lblMoTaNgonNgu.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lblMoTaNgonNgu, 2);
            lblMoTaNgonNgu.ForeColor = Color.Gray;
            lblMoTaNgonNgu.Location = new Point(3, 112);
            lblMoTaNgonNgu.Name = "lblMoTaNgonNgu";
            lblMoTaNgonNgu.Padding = new Padding(0, 5, 0, 15);
            lblMoTaNgonNgu.Size = new Size(486, 43);
            lblMoTaNgonNgu.TabIndex = 3;
            lblMoTaNgonNgu.Text = "Thay đổi ngôn ngữ được sử dụng trong giao diện người dùng.";
            // 
            // lblNgonNgu
            // 
            lblNgonNgu.AutoSize = true;
            lblNgonNgu.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNgonNgu.Location = new Point(3, 78);
            lblNgonNgu.Name = "lblNgonNgu";
            lblNgonNgu.Padding = new Padding(0, 5, 0, 0);
            lblNgonNgu.Size = new Size(88, 28);
            lblNgonNgu.TabIndex = 2;
            lblNgonNgu.Text = "Ngôn ngữ";
            // 
            // cmbGiaoDien
            // 
            cmbGiaoDien.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbGiaoDien.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGiaoDien.FormattingEnabled = true;
            cmbGiaoDien.Items.AddRange(new object[] { "Theo cài đặt hệ thống", "Sáng", "Tối" });
            cmbGiaoDien.Location = new Point(406, 3);
            cmbGiaoDien.Name = "cmbGiaoDien";
            cmbGiaoDien.Size = new Size(211, 29);
            cmbGiaoDien.TabIndex = 1;
            cmbGiaoDien.SelectedIndexChanged += cmbGiaoDien_SelectedIndexChanged;
            // 
            // lblMoTaGiaoDien
            // 
            lblMoTaGiaoDien.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lblMoTaGiaoDien, 2);
            lblMoTaGiaoDien.ForeColor = Color.Gray;
            lblMoTaGiaoDien.Location = new Point(3, 35);
            lblMoTaGiaoDien.Name = "lblMoTaGiaoDien";
            lblMoTaGiaoDien.Padding = new Padding(0, 5, 0, 15);
            lblMoTaGiaoDien.Size = new Size(383, 43);
            lblMoTaGiaoDien.TabIndex = 0;
            lblMoTaGiaoDien.Text = "Tùy chỉnh giao diện Notion trên thiết bị của bạn.";
            // 
            // lblGiaoDien
            // 
            lblGiaoDien.AutoSize = true;
            lblGiaoDien.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGiaoDien.Location = new Point(3, 0);
            lblGiaoDien.Name = "lblGiaoDien";
            lblGiaoDien.Padding = new Padding(0, 5, 0, 0);
            lblGiaoDien.Size = new Size(83, 28);
            lblGiaoDien.TabIndex = 0;
            lblGiaoDien.Text = "Giao diện";
            // 
            // line1
            // 
            line1.BackColor = Color.Gainsboro;
            line1.Dock = DockStyle.Top;
            line1.Location = new Point(0, 70);
            line1.Name = "line1";
            line1.Size = new Size(620, 1);
            line1.TabIndex = 1;
            // 
            // lblTieuDeTuyChon
            // 
            lblTieuDeTuyChon.Dock = DockStyle.Top;
            lblTieuDeTuyChon.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDeTuyChon.Location = new Point(0, 0);
            lblTieuDeTuyChon.Name = "lblTieuDeTuyChon";
            lblTieuDeTuyChon.Size = new Size(620, 70);
            lblTieuDeTuyChon.TabIndex = 0;
            lblTieuDeTuyChon.Text = "Tùy chọn";
            lblTieuDeTuyChon.TextAlign = ContentAlignment.BottomLeft;
            // 
            // panelAccount
            // 
            panelAccount.Controls.Add(lblEmailValue);
            panelAccount.Controls.Add(lblEmail);
            panelAccount.Controls.Add(linkThemAnh);
            panelAccount.Controls.Add(txtTenUaDung);
            panelAccount.Controls.Add(lblTenUaDung);
            panelAccount.Controls.Add(panelAvatar);
            panelAccount.Controls.Add(lblTieuDeTaiKhoan);
            panelAccount.Dock = DockStyle.Top;
            panelAccount.Location = new Point(40, 20);
            panelAccount.Name = "panelAccount";
            panelAccount.Size = new Size(620, 400);
            panelAccount.TabIndex = 1;
            panelAccount.Visible = false;
            // 
            // lblEmailValue
            // 
            lblEmailValue.AutoSize = true;
            lblEmailValue.Location = new Point(106, 220);
            lblEmailValue.Name = "lblEmailValue";
            lblEmailValue.Size = new Size(237, 23);
            lblEmailValue.TabIndex = 9;
            lblEmailValue.Text = "quanghoa300404@gmail.com";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(103, 190);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(51, 23);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email";
            // 
            // linkThemAnh
            // 
            linkThemAnh.AutoSize = true;
            linkThemAnh.Location = new Point(103, 90);
            linkThemAnh.Name = "linkThemAnh";
            linkThemAnh.Size = new Size(87, 23);
            linkThemAnh.TabIndex = 4;
            linkThemAnh.TabStop = true;
            linkThemAnh.Text = "Thêm ảnh";
            linkThemAnh.Click += linkThemAnh_Click;
            // 
            // txtTenUaDung
            // 
            txtTenUaDung.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTenUaDung.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenUaDung.Location = new Point(106, 142);
            txtTenUaDung.Name = "txtTenUaDung";
            txtTenUaDung.Size = new Size(511, 34);
            txtTenUaDung.TabIndex = 3;
            txtTenUaDung.Text = "Quang Hòa Bùi";
            // 
            // lblTenUaDung
            // 
            lblTenUaDung.AutoSize = true;
            lblTenUaDung.Location = new Point(103, 113);
            lblTenUaDung.Name = "lblTenUaDung";
            lblTenUaDung.Size = new Size(105, 23);
            lblTenUaDung.TabIndex = 2;
            lblTenUaDung.Text = "Tên ưa dùng";
            // 
            // panelAvatar
            // 
            panelAvatar.BackColor = Color.Gainsboro;
            panelAvatar.BackgroundImageLayout = ImageLayout.Zoom;
            panelAvatar.Controls.Add(lblAvatarText);
            panelAvatar.Location = new Point(6, 113);
            panelAvatar.Name = "panelAvatar";
            panelAvatar.Size = new Size(80, 80);
            panelAvatar.TabIndex = 1;
            // 
            // lblAvatarText
            // 
            lblAvatarText.Dock = DockStyle.Fill;
            lblAvatarText.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAvatarText.Location = new Point(0, 0);
            lblAvatarText.Name = "lblAvatarText";
            lblAvatarText.Size = new Size(80, 80);
            lblAvatarText.TabIndex = 0;
            lblAvatarText.Text = "Q";
            lblAvatarText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTieuDeTaiKhoan
            // 
            lblTieuDeTaiKhoan.AutoSize = true;
            lblTieuDeTaiKhoan.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDeTaiKhoan.Location = new Point(-1, 0);
            lblTieuDeTaiKhoan.Name = "lblTieuDeTaiKhoan";
            lblTieuDeTaiKhoan.Size = new Size(173, 46);
            lblTieuDeTaiKhoan.TabIndex = 0;
            lblTieuDeTaiKhoan.Text = "Tài khoản";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // openFileDialogAvatar
            // 
            openFileDialogAvatar.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialogAvatar.Title = "Chọn ảnh đại diện";
            // 
            // setting
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 761);
            Controls.Add(splitContainer1);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "setting";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cài đặt";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            sidebarPanel.ResumeLayout(false);
            panelTaiKhoan.ResumeLayout(false);
            panelTaiKhoan.PerformLayout();
            panelSettings.ResumeLayout(false);
            panelSettings.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panelAccount.ResumeLayout(false);
            panelAccount.PerformLayout();
            panelAvatar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Panel panelTaiKhoan;
        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.Button btnTuyChon;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label lblTieuDeTuyChon;
        private System.Windows.Forms.Panel line1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblGiaoDien;
        private System.Windows.Forms.Label lblMoTaGiaoDien;
        private System.Windows.Forms.ComboBox cmbGiaoDien;
        private System.Windows.Forms.Label lblNgonNgu;
        private System.Windows.Forms.Label lblMoTaNgonNgu;
        private System.Windows.Forms.ComboBox cmbNgonNgu;
        private System.Windows.Forms.Panel panelAccount;
        private System.Windows.Forms.Label lblTieuDeTaiKhoan;
        private System.Windows.Forms.Panel panelAvatar;
        private System.Windows.Forms.Label lblAvatarText;
        private System.Windows.Forms.Label lblTenUaDung;
        private System.Windows.Forms.TextBox txtTenUaDung;
        private System.Windows.Forms.LinkLabel linkThemAnh;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblEmailValue;
        private System.Windows.Forms.OpenFileDialog openFileDialogAvatar;
    }
}