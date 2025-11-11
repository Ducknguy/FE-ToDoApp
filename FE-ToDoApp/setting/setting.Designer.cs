//using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FE_ToDoApp.Setting
{
    partial class setting
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
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            sidebarPanel = new Panel();
            btnSidebarKetNoi = new Button();
            btnTrangCongKhai = new Button();
            btnNotionAI = new Button();
            btnKhongGianNhom = new Button();
            btnThanhVien = new Button();
            btnChung = new Button();
            lblKhongGianLamViec = new Label();
            btnNgoaiTuyen = new Button();
            btnKetNoi = new Button();
            btnThongBao = new Button();
            btnTuyChon = new Button();
            panelTaiKhoan = new Panel();
            lblTaiKhoan = new Label();
            panelAccount = new Panel();
            lblMaKhoa = new Label();
            btnThemPhuongThucXacMinh = new Button();
            lblMoTaXacMinh2Buoc = new Label();
            lblXacMinh2Buoc = new Label();
            btnThemMatKhau = new Button();
            lblMoTaMatKhau = new Label();
            lblMatKhau = new Label();
            btnDoiEmail = new Button();
            lblEmailValue = new Label();
            lblEmail = new Label();
            lblBaoMatTaiKhoan = new Label();
            linkTaoAnhChanDung = new LinkLabel();
            label13 = new Label();
            linkThemAnh = new LinkLabel();
            txtTenUaDung = new TextBox();
            lblTenUaDung = new Label();
            panelAvatar = new Panel();
            lblAvatarText = new Label();
            lblTieuDeTaiKhoan = new Label();
            panelSettings = new Panel();
            lblQuyenRiengTu = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            cmbMoKhiKhoiDong = new ComboBox();
            lblMoTaMoKhiKhoiDong = new Label();
            lblMoKhiKhoiDong = new Label();
            lblKhoiDong = new Label();
            line3 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            chkBatDauTuan = new CheckBox();
            lblMoTaBatDauTuan = new Label();
            lblBatDauTuan = new Label();
            line2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            cmbNgonNgu = new ComboBox();
            lblMoTaNgonNgu = new Label();
            lblNgonNgu = new Label();
            cmbGiaoDien = new ComboBox();
            lblMoTaGiaoDien = new Label();
            lblGiaoDien = new Label();
            line1 = new Panel();
            lblTieuDeTuyChon = new Label();
            imageList1 = new ImageList(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            sidebarPanel.SuspendLayout();
            panelTaiKhoan.SuspendLayout();
            panelAccount.SuspendLayout();
            panelAvatar.SuspendLayout();
            panelSettings.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
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
            splitContainer1.Panel1.Padding = new Padding(8);
            splitContainer1.Panel1.Tag = "Sidebar";
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.AutoScroll = true;
            splitContainer1.Panel2.BackColor = Color.White;
            splitContainer1.Panel2.Controls.Add(panelAccount);
            splitContainer1.Panel2.Controls.Add(panelSettings);
            splitContainer1.Panel2.Padding = new Padding(40, 20, 40, 20);
            splitContainer1.Size = new Size(984, 761);
            splitContainer1.SplitterDistance = 280;
            splitContainer1.TabIndex = 0;
            // 
            // sidebarPanel
            // 
            sidebarPanel.AutoScroll = true;
            sidebarPanel.Controls.Add(btnSidebarKetNoi);
            sidebarPanel.Controls.Add(btnTrangCongKhai);
            sidebarPanel.Controls.Add(btnNotionAI);
            sidebarPanel.Controls.Add(btnKhongGianNhom);
            sidebarPanel.Controls.Add(btnThanhVien);
            sidebarPanel.Controls.Add(btnChung);
            sidebarPanel.Controls.Add(lblKhongGianLamViec);
            sidebarPanel.Controls.Add(btnNgoaiTuyen);
            sidebarPanel.Controls.Add(btnKetNoi);
            sidebarPanel.Controls.Add(btnThongBao);
            sidebarPanel.Controls.Add(btnTuyChon);
            sidebarPanel.Controls.Add(panelTaiKhoan);
            sidebarPanel.Dock = DockStyle.Fill;
            sidebarPanel.Location = new Point(8, 8);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(264, 745);
            sidebarPanel.TabIndex = 0;
            sidebarPanel.Tag = "Sidebar";
            // 
            // btnSidebarKetNoi
            // 
            btnSidebarKetNoi.Dock = DockStyle.Top;
            btnSidebarKetNoi.FlatAppearance.BorderSize = 0;
            btnSidebarKetNoi.FlatStyle = FlatStyle.Flat;
            btnSidebarKetNoi.Location = new Point(0, 399);
            btnSidebarKetNoi.Name = "btnSidebarKetNoi";
            btnSidebarKetNoi.Padding = new Padding(15, 0, 0, 0);
            btnSidebarKetNoi.Size = new Size(264, 30);
            btnSidebarKetNoi.TabIndex = 12;
            btnSidebarKetNoi.Text = "     Kết nối";
            btnSidebarKetNoi.TextAlign = ContentAlignment.MiddleLeft;
            btnSidebarKetNoi.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSidebarKetNoi.UseVisualStyleBackColor = true;
            // 
            // btnTrangCongKhai
            // 
            btnTrangCongKhai.Dock = DockStyle.Top;
            btnTrangCongKhai.FlatAppearance.BorderSize = 0;
            btnTrangCongKhai.FlatStyle = FlatStyle.Flat;
            btnTrangCongKhai.Location = new Point(0, 369);
            btnTrangCongKhai.Name = "btnTrangCongKhai";
            btnTrangCongKhai.Padding = new Padding(15, 0, 0, 0);
            btnTrangCongKhai.Size = new Size(264, 30);
            btnTrangCongKhai.TabIndex = 11;
            btnTrangCongKhai.Text = "     Trang công khai";
            btnTrangCongKhai.TextAlign = ContentAlignment.MiddleLeft;
            btnTrangCongKhai.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTrangCongKhai.UseVisualStyleBackColor = true;
            // 
            // btnNotionAI
            // 
            btnNotionAI.Dock = DockStyle.Top;
            btnNotionAI.FlatAppearance.BorderSize = 0;
            btnNotionAI.FlatStyle = FlatStyle.Flat;
            btnNotionAI.Location = new Point(0, 339);
            btnNotionAI.Name = "btnNotionAI";
            btnNotionAI.Padding = new Padding(15, 0, 0, 0);
            btnNotionAI.Size = new Size(264, 30);
            btnNotionAI.TabIndex = 10;
            btnNotionAI.Text = "     Notion AI";
            btnNotionAI.TextAlign = ContentAlignment.MiddleLeft;
            btnNotionAI.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNotionAI.UseVisualStyleBackColor = true;
            // 
            // btnKhongGianNhom
            // 
            btnKhongGianNhom.Dock = DockStyle.Top;
            btnKhongGianNhom.FlatAppearance.BorderSize = 0;
            btnKhongGianNhom.FlatStyle = FlatStyle.Flat;
            btnKhongGianNhom.Location = new Point(0, 309);
            btnKhongGianNhom.Name = "btnKhongGianNhom";
            btnKhongGianNhom.Padding = new Padding(15, 0, 0, 0);
            btnKhongGianNhom.Size = new Size(264, 30);
            btnKhongGianNhom.TabIndex = 9;
            btnKhongGianNhom.Text = "     Không gian nhóm";
            btnKhongGianNhom.TextAlign = ContentAlignment.MiddleLeft;
            btnKhongGianNhom.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnKhongGianNhom.UseVisualStyleBackColor = true;
            // 
            // btnThanhVien
            // 
            btnThanhVien.Dock = DockStyle.Top;
            btnThanhVien.FlatAppearance.BorderSize = 0;
            btnThanhVien.FlatStyle = FlatStyle.Flat;
            btnThanhVien.Location = new Point(0, 279);
            btnThanhVien.Name = "btnThanhVien";
            btnThanhVien.Padding = new Padding(15, 0, 0, 0);
            btnThanhVien.Size = new Size(264, 30);
            btnThanhVien.TabIndex = 8;
            btnThanhVien.Text = "     Thành viên";
            btnThanhVien.TextAlign = ContentAlignment.MiddleLeft;
            btnThanhVien.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThanhVien.UseVisualStyleBackColor = true;
            // 
            // btnChung
            // 
            btnChung.Dock = DockStyle.Top;
            btnChung.FlatAppearance.BorderSize = 0;
            btnChung.FlatStyle = FlatStyle.Flat;
            btnChung.Location = new Point(0, 249);
            btnChung.Name = "btnChung";
            btnChung.Padding = new Padding(15, 0, 0, 0);
            btnChung.Size = new Size(264, 30);
            btnChung.TabIndex = 7;
            btnChung.Text = "     Chung";
            btnChung.TextAlign = ContentAlignment.MiddleLeft;
            btnChung.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnChung.UseVisualStyleBackColor = true;
            // 
            // lblKhongGianLamViec
            // 
            lblKhongGianLamViec.Dock = DockStyle.Top;
            lblKhongGianLamViec.ForeColor = Color.Gray;
            lblKhongGianLamViec.Location = new Point(0, 219);
            lblKhongGianLamViec.Name = "lblKhongGianLamViec";
            lblKhongGianLamViec.Padding = new Padding(5, 10, 0, 0);
            lblKhongGianLamViec.Size = new Size(264, 30);
            lblKhongGianLamViec.TabIndex = 6;
            lblKhongGianLamViec.Text = "Không gian làm việc";
            // 
            // btnNgoaiTuyen
            // 
            btnNgoaiTuyen.Dock = DockStyle.Top;
            btnNgoaiTuyen.FlatAppearance.BorderSize = 0;
            btnNgoaiTuyen.FlatStyle = FlatStyle.Flat;
            btnNgoaiTuyen.Location = new Point(0, 189);
            btnNgoaiTuyen.Name = "btnNgoaiTuyen";
            btnNgoaiTuyen.Padding = new Padding(15, 0, 0, 0);
            btnNgoaiTuyen.Size = new Size(264, 30);
            btnNgoaiTuyen.TabIndex = 4;
            btnNgoaiTuyen.Text = "     Ngoại tuyến";
            btnNgoaiTuyen.TextAlign = ContentAlignment.MiddleLeft;
            btnNgoaiTuyen.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNgoaiTuyen.UseVisualStyleBackColor = true;
            // 
            // btnKetNoi
            // 
            btnKetNoi.Dock = DockStyle.Top;
            btnKetNoi.FlatAppearance.BorderSize = 0;
            btnKetNoi.FlatStyle = FlatStyle.Flat;
            btnKetNoi.Location = new Point(0, 159);
            btnKetNoi.Name = "btnKetNoi";
            btnKetNoi.Padding = new Padding(15, 0, 0, 0);
            btnKetNoi.Size = new Size(264, 30);
            btnKetNoi.TabIndex = 3;
            btnKetNoi.Text = "     Kết nối";
            btnKetNoi.TextAlign = ContentAlignment.MiddleLeft;
            btnKetNoi.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnKetNoi.UseVisualStyleBackColor = true;
            // 
            // btnThongBao
            // 
            btnThongBao.Dock = DockStyle.Top;
            btnThongBao.FlatAppearance.BorderSize = 0;
            btnThongBao.FlatStyle = FlatStyle.Flat;
            btnThongBao.Location = new Point(0, 129);
            btnThongBao.Name = "btnThongBao";
            btnThongBao.Padding = new Padding(15, 0, 0, 0);
            btnThongBao.Size = new Size(264, 30);
            btnThongBao.TabIndex = 2;
            btnThongBao.Text = "     Thông báo";
            btnThongBao.TextAlign = ContentAlignment.MiddleLeft;
            btnThongBao.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThongBao.UseVisualStyleBackColor = true;
            // 
            // btnTuyChon
            // 
            btnTuyChon.Dock = DockStyle.Top;
            btnTuyChon.FlatAppearance.BorderSize = 0;
            btnTuyChon.FlatStyle = FlatStyle.Flat;
            btnTuyChon.Location = new Point(0, 99);
            btnTuyChon.Name = "btnTuyChon";
            btnTuyChon.Padding = new Padding(15, 0, 0, 0);
            btnTuyChon.Size = new Size(264, 30);
            btnTuyChon.TabIndex = 1;
            btnTuyChon.Text = "     Tùy chọn";
            btnTuyChon.TextAlign = ContentAlignment.MiddleLeft;
            btnTuyChon.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTuyChon.UseVisualStyleBackColor = true;
            // 
            // panelTaiKhoan
            // 
            panelTaiKhoan.Controls.Add(lblTaiKhoan);
            panelTaiKhoan.Cursor = Cursors.Hand;
            panelTaiKhoan.Dock = DockStyle.Top;
            panelTaiKhoan.Location = new Point(0, 0);
            panelTaiKhoan.Name = "panelTaiKhoan";
            panelTaiKhoan.Padding = new Padding(5, 0, 0, 0);
            panelTaiKhoan.Size = new Size(264, 99);
            panelTaiKhoan.TabIndex = 0;
            // 
            // lblTaiKhoan
            // 
            lblTaiKhoan.AutoSize = true;
            lblTaiKhoan.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTaiKhoan.Location = new Point(11, 41);
            lblTaiKhoan.Name = "lblTaiKhoan";
            lblTaiKhoan.Padding = new Padding(30, 0, 0, 0);
            lblTaiKhoan.Size = new Size(126, 17);
            lblTaiKhoan.TabIndex = 0;
            lblTaiKhoan.Text = "Quang Hòa Bùi";
            // 
            // panelAccount
            // 
            panelAccount.Controls.Add(lblMaKhoa);
            panelAccount.Controls.Add(btnThemPhuongThucXacMinh);
            panelAccount.Controls.Add(lblMoTaXacMinh2Buoc);
            panelAccount.Controls.Add(lblXacMinh2Buoc);
            panelAccount.Controls.Add(btnThemMatKhau);
            panelAccount.Controls.Add(lblMoTaMatKhau);
            panelAccount.Controls.Add(lblMatKhau);
            panelAccount.Controls.Add(btnDoiEmail);
            panelAccount.Controls.Add(lblEmailValue);
            panelAccount.Controls.Add(lblEmail);
            panelAccount.Controls.Add(lblBaoMatTaiKhoan);
            panelAccount.Controls.Add(linkTaoAnhChanDung);
            panelAccount.Controls.Add(label13);
            panelAccount.Controls.Add(linkThemAnh);
            panelAccount.Controls.Add(txtTenUaDung);
            panelAccount.Controls.Add(lblTenUaDung);
            panelAccount.Controls.Add(panelAvatar);
            panelAccount.Controls.Add(lblTieuDeTaiKhoan);
            panelAccount.Dock = DockStyle.Top;
            panelAccount.Location = new Point(40, 649);
            panelAccount.Name = "panelAccount";
            panelAccount.Size = new Size(603, 700);
            panelAccount.TabIndex = 1;
            // 
            // lblMaKhoa
            // 
            lblMaKhoa.AutoSize = true;
            lblMaKhoa.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaKhoa.Location = new Point(3, 581);
            lblMaKhoa.Name = "lblMaKhoa";
            lblMaKhoa.Size = new Size(59, 17);
            lblMaKhoa.TabIndex = 17;
            lblMaKhoa.Text = "Mã khóa";
            // 
            // btnThemPhuongThucXacMinh
            // 
            btnThemPhuongThucXacMinh.Location = new Point(434, 521);
            btnThemPhuongThucXacMinh.Name = "btnThemPhuongThucXacMinh";
            btnThemPhuongThucXacMinh.Size = new Size(187, 30);
            btnThemPhuongThucXacMinh.TabIndex = 16;
            btnThemPhuongThucXacMinh.Text = "Thêm phương thức xác minh";
            btnThemPhuongThucXacMinh.UseVisualStyleBackColor = true;
            // 
            // lblMoTaXacMinh2Buoc
            // 
            lblMoTaXacMinh2Buoc.Location = new Point(3, 498);
            lblMoTaXacMinh2Buoc.Name = "lblMoTaXacMinh2Buoc";
            lblMoTaXacMinh2Buoc.Size = new Size(262, 53);
            lblMoTaXacMinh2Buoc.TabIndex = 15;
            lblMoTaXacMinh2Buoc.Text = "Thêm một lớp bảo mật bổ sung cho tài khoản của bạn trong quá trình đăng nhập.";
            // 
            // lblXacMinh2Buoc
            // 
            lblXacMinh2Buoc.AutoSize = true;
            lblXacMinh2Buoc.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblXacMinh2Buoc.Location = new Point(3, 472);
            lblXacMinh2Buoc.Name = "lblXacMinh2Buoc";
            lblXacMinh2Buoc.Size = new Size(106, 17);
            lblXacMinh2Buoc.TabIndex = 14;
            lblXacMinh2Buoc.Text = "Xác minh 2 bước";
            // 
            // btnThemMatKhau
            // 
            btnThemMatKhau.Location = new Point(434, 412);
            btnThemMatKhau.Name = "btnThemMatKhau";
            btnThemMatKhau.Size = new Size(187, 30);
            btnThemMatKhau.TabIndex = 13;
            btnThemMatKhau.Text = "Thêm mật khẩu";
            btnThemMatKhau.UseVisualStyleBackColor = true;
            // 
            // lblMoTaMatKhau
            // 
            lblMoTaMatKhau.Location = new Point(3, 399);
            lblMoTaMatKhau.Name = "lblMoTaMatKhau";
            lblMoTaMatKhau.Size = new Size(262, 53);
            lblMoTaMatKhau.TabIndex = 12;
            lblMoTaMatKhau.Text = "Đặt mật khẩu vĩnh viễn để đăng nhập vào tài khoản của bạn.";
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMatKhau.Location = new Point(3, 373);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(62, 17);
            lblMatKhau.TabIndex = 11;
            lblMatKhau.Text = "Mật khẩu";
            // 
            // btnDoiEmail
            // 
            btnDoiEmail.Location = new Point(434, 319);
            btnDoiEmail.Name = "btnDoiEmail";
            btnDoiEmail.Size = new Size(187, 30);
            btnDoiEmail.TabIndex = 10;
            btnDoiEmail.Text = "Đổi email";
            btnDoiEmail.UseVisualStyleBackColor = true;
            // 
            // lblEmailValue
            // 
            lblEmailValue.AutoSize = true;
            lblEmailValue.Location = new Point(3, 328);
            lblEmailValue.Name = "lblEmailValue";
            lblEmailValue.Size = new Size(181, 17);
            lblEmailValue.TabIndex = 9;
            lblEmailValue.Text = "quanghoa300404@gmail.com";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(3, 302);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 17);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email";
            // 
            // lblBaoMatTaiKhoan
            // 
            lblBaoMatTaiKhoan.AutoSize = true;
            lblBaoMatTaiKhoan.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBaoMatTaiKhoan.Location = new Point(2, 252);
            lblBaoMatTaiKhoan.Name = "lblBaoMatTaiKhoan";
            lblBaoMatTaiKhoan.Size = new Size(149, 21);
            lblBaoMatTaiKhoan.TabIndex = 7;
            lblBaoMatTaiKhoan.Text = "Bảo mật tài khoản";
            // 
            // linkTaoAnhChanDung
            // 
            linkTaoAnhChanDung.AutoSize = true;
            linkTaoAnhChanDung.Location = new Point(219, 198);
            linkTaoAnhChanDung.Name = "linkTaoAnhChanDung";
            linkTaoAnhChanDung.Size = new Size(120, 17);
            linkTaoAnhChanDung.TabIndex = 6;
            linkTaoAnhChanDung.TabStop = true;
            linkTaoAnhChanDung.Text = "Tạo ảnh chân dung";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(177, 198);
            label13.Name = "label13";
            label13.Size = new Size(36, 17);
            label13.TabIndex = 5;
            label13.Text = "hoặc";
            // 
            // linkThemAnh
            // 
            linkThemAnh.AutoSize = true;
            linkThemAnh.Location = new Point(103, 198);
            linkThemAnh.Name = "linkThemAnh";
            linkThemAnh.Size = new Size(65, 17);
            linkThemAnh.TabIndex = 4;
            linkThemAnh.TabStop = true;
            linkThemAnh.Text = "Thêm ảnh";
            // 
            // txtTenUaDung
            // 
            txtTenUaDung.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenUaDung.Location = new Point(106, 142);
            txtTenUaDung.Name = "txtTenUaDung";
            txtTenUaDung.Size = new Size(515, 29);
            txtTenUaDung.TabIndex = 3;
            txtTenUaDung.Text = "Quang Hòa Bùi";
            // 
            // lblTenUaDung
            // 
            lblTenUaDung.AutoSize = true;
            lblTenUaDung.Location = new Point(103, 113);
            lblTenUaDung.Name = "lblTenUaDung";
            lblTenUaDung.Size = new Size(81, 17);
            lblTenUaDung.TabIndex = 2;
            lblTenUaDung.Text = "Tên ưa dùng";
            // 
            // panelAvatar
            // 
            panelAvatar.BackColor = Color.Gainsboro;
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
            lblTieuDeTaiKhoan.Size = new Size(140, 37);
            lblTieuDeTaiKhoan.TabIndex = 0;
            lblTieuDeTaiKhoan.Text = "Tài khoản";
            // 
            // panelSettings
            // 
            panelSettings.Controls.Add(lblQuyenRiengTu);
            panelSettings.Controls.Add(tableLayoutPanel3);
            panelSettings.Controls.Add(lblKhoiDong);
            panelSettings.Controls.Add(line3);
            panelSettings.Controls.Add(tableLayoutPanel2);
            panelSettings.Controls.Add(line2);
            panelSettings.Controls.Add(tableLayoutPanel1);
            panelSettings.Controls.Add(line1);
            panelSettings.Controls.Add(lblTieuDeTuyChon);
            panelSettings.Dock = DockStyle.Top;
            panelSettings.Location = new Point(40, 20);
            panelSettings.Name = "panelSettings";
            panelSettings.Size = new Size(603, 629);
            panelSettings.TabIndex = 0;
            // 
            // lblQuyenRiengTu
            // 
            lblQuyenRiengTu.AutoSize = true;
            lblQuyenRiengTu.Dock = DockStyle.Top;
            lblQuyenRiengTu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQuyenRiengTu.Location = new Point(0, 508);
            lblQuyenRiengTu.Name = "lblQuyenRiengTu";
            lblQuyenRiengTu.Padding = new Padding(0, 20, 0, 0);
            lblQuyenRiengTu.Size = new Size(125, 41);
            lblQuyenRiengTu.TabIndex = 8;
            lblQuyenRiengTu.Text = "Quyền riêng tư";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(cmbMoKhiKhoiDong, 1, 0);
            tableLayoutPanel3.Controls.Add(lblMoTaMoKhiKhoiDong, 0, 1);
            tableLayoutPanel3.Controls.Add(lblMoKhiKhoiDong, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Top;
            tableLayoutPanel3.Location = new Point(0, 427);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.Size = new Size(603, 81);
            tableLayoutPanel3.TabIndex = 7;
            // 
            // cmbMoKhiKhoiDong
            // 
            cmbMoKhiKhoiDong.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbMoKhiKhoiDong.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMoKhiKhoiDong.FormattingEnabled = true;
            cmbMoKhiKhoiDong.Items.AddRange(new object[] { "Trang truy cập gần đây nhất" });
            cmbMoKhiKhoiDong.Location = new Point(389, 3);
            cmbMoKhiKhoiDong.Name = "cmbMoKhiKhoiDong";
            cmbMoKhiKhoiDong.Size = new Size(211, 25);
            cmbMoKhiKhoiDong.TabIndex = 4;
            // 
            // lblMoTaMoKhiKhoiDong
            // 
            lblMoTaMoKhiKhoiDong.AutoSize = true;
            tableLayoutPanel3.SetColumnSpan(lblMoTaMoKhiKhoiDong, 2);
            lblMoTaMoKhiKhoiDong.ForeColor = Color.Gray;
            lblMoTaMoKhiKhoiDong.Location = new Point(3, 35);
            lblMoTaMoKhiKhoiDong.Name = "lblMoTaMoKhiKhoiDong";
            lblMoTaMoKhiKhoiDong.Size = new Size(535, 17);
            lblMoTaMoKhiKhoiDong.TabIndex = 3;
            lblMoTaMoKhiKhoiDong.Text = "Chọn nội dung hiển thị khi Notion khởi động hoặc khi bạn chuyển đổi không gian làm việc.";
            // 
            // lblMoKhiKhoiDong
            // 
            lblMoKhiKhoiDong.AutoSize = true;
            lblMoKhiKhoiDong.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMoKhiKhoiDong.Location = new Point(3, 0);
            lblMoKhiKhoiDong.Name = "lblMoKhiKhoiDong";
            lblMoKhiKhoiDong.Size = new Size(111, 17);
            lblMoKhiKhoiDong.TabIndex = 2;
            lblMoKhiKhoiDong.Text = "Mở khi khởi động";
            // 
            // lblKhoiDong
            // 
            lblKhoiDong.AutoSize = true;
            lblKhoiDong.Dock = DockStyle.Top;
            lblKhoiDong.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKhoiDong.Location = new Point(0, 386);
            lblKhoiDong.Name = "lblKhoiDong";
            lblKhoiDong.Padding = new Padding(0, 20, 0, 0);
            lblKhoiDong.Size = new Size(89, 41);
            lblKhoiDong.TabIndex = 6;
            lblKhoiDong.Text = "Khởi động";
            // 
            // line3
            // 
            line3.BackColor = Color.Gainsboro;
            line3.Dock = DockStyle.Top;
            line3.Location = new Point(0, 385);
            line3.Name = "line3";
            line3.Size = new Size(603, 1);
            line3.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 84.13461F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.86538F));
            tableLayoutPanel2.Controls.Add(chkBatDauTuan, 1, 0);
            tableLayoutPanel2.Controls.Add(lblMoTaBatDauTuan, 0, 1);
            tableLayoutPanel2.Controls.Add(lblBatDauTuan, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(0, 304);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel2.Size = new Size(603, 81);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // chkBatDauTuan
            // 
            chkBatDauTuan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkBatDauTuan.AutoSize = true;
            chkBatDauTuan.Location = new Point(585, 3);
            chkBatDauTuan.Name = "chkBatDauTuan";
            chkBatDauTuan.Size = new Size(15, 14);
            chkBatDauTuan.TabIndex = 4;
            chkBatDauTuan.UseVisualStyleBackColor = true;
            // 
            // lblMoTaBatDauTuan
            // 
            lblMoTaBatDauTuan.AutoSize = true;
            tableLayoutPanel2.SetColumnSpan(lblMoTaBatDauTuan, 2);
            lblMoTaBatDauTuan.ForeColor = Color.Gray;
            lblMoTaBatDauTuan.Location = new Point(3, 35);
            lblMoTaBatDauTuan.Name = "lblMoTaBatDauTuan";
            lblMoTaBatDauTuan.Size = new Size(442, 17);
            lblMoTaBatDauTuan.TabIndex = 3;
            lblMoTaBatDauTuan.Text = "Thao tác này sẽ thay đổi giao diện của tất cả lịch trong ứng dụng của bạn.";
            // 
            // lblBatDauTuan
            // 
            lblBatDauTuan.AutoSize = true;
            lblBatDauTuan.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBatDauTuan.Location = new Point(3, 0);
            lblBatDauTuan.Name = "lblBatDauTuan";
            lblBatDauTuan.Size = new Size(152, 17);
            lblBatDauTuan.TabIndex = 2;
            lblBatDauTuan.Text = "Bắt đầu tuần vào thứ Hai";
            // 
            // line2
            // 
            line2.BackColor = Color.Gainsboro;
            line2.Dock = DockStyle.Top;
            line2.Location = new Point(0, 303);
            line2.Name = "line2";
            line2.Size = new Size(603, 1);
            line2.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
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
            tableLayoutPanel1.Location = new Point(0, 122);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.Size = new Size(603, 181);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // cmbNgonNgu
            // 
            cmbNgonNgu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbNgonNgu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNgonNgu.FormattingEnabled = true;
            cmbNgonNgu.Items.AddRange(new object[] { "Tiếng Việt", "Tiếng Anh" });
            cmbNgonNgu.Location = new Point(389, 78);
            cmbNgonNgu.Name = "cmbNgonNgu";
            cmbNgonNgu.Size = new Size(211, 25);
            cmbNgonNgu.TabIndex = 5;
            cmbNgonNgu.SelectedIndexChanged += cmbNgonNgu_SelectedIndexChanged;
            // 
            // lblMoTaNgonNgu
            // 
            lblMoTaNgonNgu.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lblMoTaNgonNgu, 2);
            lblMoTaNgonNgu.ForeColor = Color.Gray;
            lblMoTaNgonNgu.Location = new Point(3, 110);
            lblMoTaNgonNgu.Name = "lblMoTaNgonNgu";
            lblMoTaNgonNgu.Size = new Size(375, 17);
            lblMoTaNgonNgu.TabIndex = 3;
            lblMoTaNgonNgu.Text = "Thay đổi ngôn ngữ được sử dụng trong giao diện người dùng.";
            // 
            // lblNgonNgu
            // 
            lblNgonNgu.AutoSize = true;
            lblNgonNgu.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNgonNgu.Location = new Point(3, 75);
            lblNgonNgu.Name = "lblNgonNgu";
            lblNgonNgu.Size = new Size(68, 17);
            lblNgonNgu.TabIndex = 2;
            lblNgonNgu.Text = "Ngôn ngữ";
            // 
            // cmbGiaoDien
            // 
            cmbGiaoDien.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbGiaoDien.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGiaoDien.FormattingEnabled = true;
            cmbGiaoDien.Items.AddRange(new object[] { "Theo cài đặt hệ thống", "Sáng", "Tối" });
            cmbGiaoDien.Location = new Point(389, 3);
            cmbGiaoDien.Name = "cmbGiaoDien";
            cmbGiaoDien.Size = new Size(211, 25);
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
            lblMoTaGiaoDien.Size = new Size(289, 17);
            lblMoTaGiaoDien.TabIndex = 0;
            lblMoTaGiaoDien.Text = "Tùy chỉnh giao diện Notion trên thiết bị của bạn.";
            // 
            // lblGiaoDien
            // 
            lblGiaoDien.AutoSize = true;
            lblGiaoDien.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGiaoDien.Location = new Point(3, 0);
            lblGiaoDien.Name = "lblGiaoDien";
            lblGiaoDien.Size = new Size(64, 17);
            lblGiaoDien.TabIndex = 0;
            lblGiaoDien.Text = "Giao diện";
            // 
            // line1
            // 
            line1.BackColor = Color.Gainsboro;
            line1.Dock = DockStyle.Top;
            line1.Location = new Point(0, 121);
            line1.Name = "line1";
            line1.Size = new Size(603, 1);
            line1.TabIndex = 1;
            // 
            // lblTieuDeTuyChon
            // 
            lblTieuDeTuyChon.Dock = DockStyle.Top;
            lblTieuDeTuyChon.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDeTuyChon.Location = new Point(0, 0);
            lblTieuDeTuyChon.Name = "lblTieuDeTuyChon";
            lblTieuDeTuyChon.Size = new Size(603, 121);
            lblTieuDeTuyChon.TabIndex = 0;
            lblTieuDeTuyChon.Text = "Tùy chọn";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // setting
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 761);
            Controls.Add(splitContainer1);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "setting";
            Text = "Fe-setting";
            Load += setting_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            sidebarPanel.ResumeLayout(false);
            panelTaiKhoan.ResumeLayout(false);
            panelTaiKhoan.PerformLayout();
            panelAccount.ResumeLayout(false);
            panelAccount.PerformLayout();
            panelAvatar.ResumeLayout(false);
            panelSettings.ResumeLayout(false);
            panelSettings.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Panel panelTaiKhoan;
        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.Button btnTuyChon;
        private System.Windows.Forms.Button btnNgoaiTuyen;
        private System.Windows.Forms.Button btnKetNoi;
        private System.Windows.Forms.Button btnThongBao;
        private System.Windows.Forms.Label lblKhongGianLamViec;
        private System.Windows.Forms.Button btnChung;
        private System.Windows.Forms.Button btnThanhVien;
        private System.Windows.Forms.Button btnKhongGianNhom;
        private System.Windows.Forms.Button btnNotionAI;
        private System.Windows.Forms.Button btnTrangCongKhai;
        private System.Windows.Forms.Button btnSidebarKetNoi;
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
        private System.Windows.Forms.Panel line2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox chkBatDauTuan;
        private System.Windows.Forms.Label lblMoTaBatDauTuan;
        private System.Windows.Forms.Label lblBatDauTuan;
        private System.Windows.Forms.Panel line3;
        private System.Windows.Forms.Label lblKhoiDong;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox cmbMoKhiKhoiDong;
        private System.Windows.Forms.Label lblMoTaMoKhiKhoiDong;
        private System.Windows.Forms.Label lblMoKhiKhoiDong;
        private System.Windows.Forms.Label lblQuyenRiengTu;
        private System.Windows.Forms.ComboBox cmbNgonNgu;
        private System.Windows.Forms.Panel panelAccount;
        private System.Windows.Forms.Label lblTieuDeTaiKhoan;
        private System.Windows.Forms.Panel panelAvatar;
        private System.Windows.Forms.Label lblAvatarText;
        private System.Windows.Forms.Label lblTenUaDung;
        private System.Windows.Forms.TextBox txtTenUaDung;
        private System.Windows.Forms.LinkLabel linkThemAnh;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.LinkLabel linkTaoAnhChanDung;
        private System.Windows.Forms.Label lblBaoMatTaiKhoan;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblEmailValue;
        private System.Windows.Forms.Button btnDoiEmail;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.Label lblMoTaMatKhau;
        private System.Windows.Forms.Button btnThemMatKhau;
        private System.Windows.Forms.Label lblXacMinh2Buoc;
        private System.Windows.Forms.Label lblMoTaXacMinh2Buoc;
        private System.Windows.Forms.Button btnThemPhuongThucXacMinh;
        private System.Windows.Forms.Label lblMaKhoa;
    }
}

