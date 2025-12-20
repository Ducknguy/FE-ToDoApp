using System.Windows.Forms;
using System.Drawing;

// Namespace đã được cập nhật theo yêu cầu của bạn
namespace FE_ToDoApp.Setting

{
    // ĐÃ ĐỔI TÊN CLASS TỪ Form1 thành setting
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
            btnNangCapGoi = new Button();
            btnNhap = new Button();
            btnBieuTuongCamXuc = new Button();
            btnSidebarKetNoi = new Button();
            btnTrangCongKhai = new Button();
            btnKhongGianNhom = new Button();
            btnThanhVien = new Button();
            btnChung = new Button();
            lblKhongGianLamViec = new Label();
            btnKetNoi = new Button();
            btnThongBao = new Button();
            btnTuyChon = new Button();
            panelTaiKhoan = new Panel();
            lblTaiKhoan = new Label();
            panelNotifications = new Panel();
            linkTimHieuThongBao = new LinkLabel();
            linkQuanLyCaiDat = new LinkLabel();
            tableLayoutPanel8 = new TableLayoutPanel();
            lblMoTaEmailThongBaoVaCapNhat = new Label();
            lblEmailThongBaoVaCapNhat = new Label();
            tableLayoutPanel7 = new TableLayoutPanel();
            chkBanTomTatKhongGianLamViec = new CheckBox();
            lblMoTaBanTomTatKhongGianLamViec = new Label();
            lblBanTomTatKhongGianLamViec = new Label();
            tableLayoutPanel6 = new TableLayoutPanel();
            chkCapNhatTrang = new CheckBox();
            lblMoTaCapNhatTrang = new Label();
            lblCapNhatTrang = new Label();
            tableLayoutPanel5 = new TableLayoutPanel();
            chkLuonGuiThongBaoEmail = new CheckBox();
            lblMoTaLuonGuiThongBaoEmail = new Label();
            lblLuonGuiThongBaoEmail = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            chkHoatDongKhongGianLamViec = new CheckBox();
            lblMoTaHoatDongKhongGianLamViec = new Label();
            lblHoatDongKhongGianLamViec = new Label();
            lblThongBaoQuaEmail = new Label();
            panel1 = new Panel();
            tableLayoutPanelDiscord = new TableLayoutPanel();
            cmbThongBaoDiscord = new ComboBox();
            lblMoTaThongBaoDiscord = new Label();
            lblThongBaoDiscord = new Label();
            lblTieuDeThongBao = new Label();
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
            openFileDialogAvatar = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            sidebarPanel.SuspendLayout();
            panelTaiKhoan.SuspendLayout();
            panelNotifications.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanelDiscord.SuspendLayout();
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
            splitContainer1.Panel2.Controls.Add(panelNotifications);
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
            sidebarPanel.Controls.Add(btnNangCapGoi);
            sidebarPanel.Controls.Add(btnNhap);
            sidebarPanel.Controls.Add(btnBieuTuongCamXuc);
            sidebarPanel.Controls.Add(btnSidebarKetNoi);
            sidebarPanel.Controls.Add(btnTrangCongKhai);
            sidebarPanel.Controls.Add(btnKhongGianNhom);
            sidebarPanel.Controls.Add(btnThanhVien);
            sidebarPanel.Controls.Add(btnChung);
            sidebarPanel.Controls.Add(lblKhongGianLamViec);
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
            // btnNangCapGoi
            // 
            btnNangCapGoi.Dock = DockStyle.Top;
            btnNangCapGoi.FlatAppearance.BorderSize = 0;
            btnNangCapGoi.FlatStyle = FlatStyle.Flat;
            btnNangCapGoi.Location = new Point(0, 429);
            btnNangCapGoi.Name = "btnNangCapGoi";
            btnNangCapGoi.Padding = new Padding(15, 0, 0, 0);
            btnNangCapGoi.Size = new Size(264, 30);
            btnNangCapGoi.TabIndex = 15;
            btnNangCapGoi.Text = "     Nâng cấp gói";
            btnNangCapGoi.TextAlign = ContentAlignment.MiddleLeft;
            btnNangCapGoi.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNangCapGoi.UseVisualStyleBackColor = true;
            // 
            // btnNhap
            // 
            btnNhap.Dock = DockStyle.Top;
            btnNhap.FlatAppearance.BorderSize = 0;
            btnNhap.FlatStyle = FlatStyle.Flat;
            btnNhap.Location = new Point(0, 399);
            btnNhap.Name = "btnNhap";
            btnNhap.Padding = new Padding(15, 0, 0, 0);
            btnNhap.Size = new Size(264, 30);
            btnNhap.TabIndex = 14;
            btnNhap.Text = "     Nhập";
            btnNhap.TextAlign = ContentAlignment.MiddleLeft;
            btnNhap.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNhap.UseVisualStyleBackColor = true;
            // 
            // btnBieuTuongCamXuc
            // 
            btnBieuTuongCamXuc.Dock = DockStyle.Top;
            btnBieuTuongCamXuc.FlatAppearance.BorderSize = 0;
            btnBieuTuongCamXuc.FlatStyle = FlatStyle.Flat;
            btnBieuTuongCamXuc.Location = new Point(0, 369);
            btnBieuTuongCamXuc.Name = "btnBieuTuongCamXuc";
            btnBieuTuongCamXuc.Padding = new Padding(15, 0, 0, 0);
            btnBieuTuongCamXuc.Size = new Size(264, 30);
            btnBieuTuongCamXuc.TabIndex = 13;
            btnBieuTuongCamXuc.Text = "     Biểu tượng cảm xúc";
            btnBieuTuongCamXuc.TextAlign = ContentAlignment.MiddleLeft;
            btnBieuTuongCamXuc.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBieuTuongCamXuc.UseVisualStyleBackColor = true;
            // 
            // btnSidebarKetNoi
            // 
            btnSidebarKetNoi.Dock = DockStyle.Top;
            btnSidebarKetNoi.FlatAppearance.BorderSize = 0;
            btnSidebarKetNoi.FlatStyle = FlatStyle.Flat;
            btnSidebarKetNoi.Location = new Point(0, 339);
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
            btnTrangCongKhai.Location = new Point(0, 309);
            btnTrangCongKhai.Name = "btnTrangCongKhai";
            btnTrangCongKhai.Padding = new Padding(15, 0, 0, 0);
            btnTrangCongKhai.Size = new Size(264, 30);
            btnTrangCongKhai.TabIndex = 11;
            btnTrangCongKhai.Text = "     Trang công khai";
            btnTrangCongKhai.TextAlign = ContentAlignment.MiddleLeft;
            btnTrangCongKhai.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTrangCongKhai.UseVisualStyleBackColor = true;
            // 
            // btnKhongGianNhom
            // 
            btnKhongGianNhom.Dock = DockStyle.Top;
            btnKhongGianNhom.FlatAppearance.BorderSize = 0;
            btnKhongGianNhom.FlatStyle = FlatStyle.Flat;
            btnKhongGianNhom.Location = new Point(0, 279);
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
            btnThanhVien.Location = new Point(0, 249);
            btnThanhVien.Name = "btnThanhVien";
            btnThanhVien.Padding = new Padding(15, 0, 0, 0);
            btnThanhVien.Size = new Size(264, 30);
            btnThanhVien.TabIndex = 8;
            btnThanhVien.Text = "     Người dùng";
            btnThanhVien.TextAlign = ContentAlignment.MiddleLeft;
            btnThanhVien.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThanhVien.UseVisualStyleBackColor = true;
            // 
            // btnChung
            // 
            btnChung.Dock = DockStyle.Top;
            btnChung.FlatAppearance.BorderSize = 0;
            btnChung.FlatStyle = FlatStyle.Flat;
            btnChung.Location = new Point(0, 219);
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
            lblKhongGianLamViec.Location = new Point(0, 189);
            lblKhongGianLamViec.Name = "lblKhongGianLamViec";
            lblKhongGianLamViec.Padding = new Padding(5, 10, 0, 0);
            lblKhongGianLamViec.Size = new Size(264, 30);
            lblKhongGianLamViec.TabIndex = 6;
            lblKhongGianLamViec.Text = "Không gian làm việc";
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
            lblTaiKhoan.Size = new Size(157, 23);
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
            linkQuanLyCaiDat.Location = new Point(496, 638);
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
            // 
            // lblMoTaBanTomTatKhongGianLamViec
            // 
            lblMoTaBanTomTatKhongGianLamViec.AutoSize = true;
            tableLayoutPanel7.SetColumnSpan(lblMoTaBanTomTatKhongGianLamViec, 2);
            lblMoTaBanTomTatKhongGianLamViec.ForeColor = Color.Gray;
            lblMoTaBanTomTatKhongGianLamViec.Location = new Point(3, 35);
            lblMoTaBanTomTatKhongGianLamViec.Name = "lblMoTaBanTomTatKhongGianLamViec";
            lblMoTaBanTomTatKhongGianLamViec.Size = new Size(592, 46);
            lblMoTaBanTomTatKhongGianLamViec.TabIndex = 3;
            lblMoTaBanTomTatKhongGianLamViec.Text = "Nhận email tóm tắt về những gì đang xảy ra trong không gian làm việc của bạn";
            // 
            // lblBanTomTatKhongGianLamViec
            // 
            lblBanTomTatKhongGianLamViec.AutoSize = true;
            lblBanTomTatKhongGianLamViec.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBanTomTatKhongGianLamViec.Location = new Point(3, 0);
            lblBanTomTatKhongGianLamViec.Name = "lblBanTomTatKhongGianLamViec";
            lblBanTomTatKhongGianLamViec.Size = new Size(259, 23);
            lblBanTomTatKhongGianLamViec.TabIndex = 2;
            lblBanTomTatKhongGianLamViec.Text = "Bản tóm tắt không gian làm việc";
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 84.13461F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.86538F));
            tableLayoutPanel6.Controls.Add(chkCapNhatTrang, 1, 0);
            tableLayoutPanel6.Controls.Add(lblMoTaCapNhatTrang, 0, 1);
            tableLayoutPanel6.Controls.Add(lblCapNhatTrang, 0, 0);
            tableLayoutPanel6.Dock = DockStyle.Top;
            tableLayoutPanel6.Location = new Point(0, 397);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel6.Size = new Size(599, 81);
            tableLayoutPanel6.TabIndex = 6;
            // 
            // chkCapNhatTrang
            // 
            chkCapNhatTrang.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkCapNhatTrang.AutoSize = true;
            chkCapNhatTrang.Checked = true;
            chkCapNhatTrang.CheckState = CheckState.Checked;
            chkCapNhatTrang.Location = new Point(578, 3);
            chkCapNhatTrang.Name = "chkCapNhatTrang";
            chkCapNhatTrang.Size = new Size(18, 17);
            chkCapNhatTrang.TabIndex = 4;
            chkCapNhatTrang.UseVisualStyleBackColor = true;
            // 
            // lblMoTaCapNhatTrang
            // 
            lblMoTaCapNhatTrang.AutoSize = true;
            tableLayoutPanel6.SetColumnSpan(lblMoTaCapNhatTrang, 2);
            lblMoTaCapNhatTrang.ForeColor = Color.Gray;
            lblMoTaCapNhatTrang.Location = new Point(3, 35);
            lblMoTaCapNhatTrang.Name = "lblMoTaCapNhatTrang";
            lblMoTaCapNhatTrang.Size = new Size(534, 23);
            lblMoTaCapNhatTrang.TabIndex = 3;
            lblMoTaCapNhatTrang.Text = "Nhận email tóm tắt về các thay đổi đối với các trang bạn đã đăng ký";
            // 
            // lblCapNhatTrang
            // 
            lblCapNhatTrang.AutoSize = true;
            lblCapNhatTrang.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCapNhatTrang.Location = new Point(3, 0);
            lblCapNhatTrang.Name = "lblCapNhatTrang";
            lblCapNhatTrang.Size = new Size(126, 23);
            lblCapNhatTrang.TabIndex = 2;
            lblCapNhatTrang.Text = "Cập nhật trang";
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 84.13461F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.86538F));
            tableLayoutPanel5.Controls.Add(chkLuonGuiThongBaoEmail, 1, 0);
            tableLayoutPanel5.Controls.Add(lblMoTaLuonGuiThongBaoEmail, 0, 1);
            tableLayoutPanel5.Controls.Add(lblLuonGuiThongBaoEmail, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Top;
            tableLayoutPanel5.Location = new Point(0, 316);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel5.Size = new Size(599, 81);
            tableLayoutPanel5.TabIndex = 5;
            // 
            // chkLuonGuiThongBaoEmail
            // 
            chkLuonGuiThongBaoEmail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkLuonGuiThongBaoEmail.AutoSize = true;
            chkLuonGuiThongBaoEmail.Location = new Point(578, 3);
            chkLuonGuiThongBaoEmail.Name = "chkLuonGuiThongBaoEmail";
            chkLuonGuiThongBaoEmail.Size = new Size(18, 17);
            chkLuonGuiThongBaoEmail.TabIndex = 4;
            chkLuonGuiThongBaoEmail.UseVisualStyleBackColor = true;
            // 
            // lblMoTaLuonGuiThongBaoEmail
            // 
            lblMoTaLuonGuiThongBaoEmail.AutoSize = true;
            tableLayoutPanel5.SetColumnSpan(lblMoTaLuonGuiThongBaoEmail, 2);
            lblMoTaLuonGuiThongBaoEmail.ForeColor = Color.Gray;
            lblMoTaLuonGuiThongBaoEmail.Location = new Point(3, 35);
            lblMoTaLuonGuiThongBaoEmail.Name = "lblMoTaLuonGuiThongBaoEmail";
            lblMoTaLuonGuiThongBaoEmail.Size = new Size(576, 46);
            lblMoTaLuonGuiThongBaoEmail.TabIndex = 3;
            lblMoTaLuonGuiThongBaoEmail.Text = "Nhận email về hoạt động trong không gian làm việc của bạn, ngay cả khi bạn đang dùng ứng dụng";
            // 
            // lblLuonGuiThongBaoEmail
            // 
            lblLuonGuiThongBaoEmail.AutoSize = true;
            lblLuonGuiThongBaoEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLuonGuiThongBaoEmail.Location = new Point(3, 0);
            lblLuonGuiThongBaoEmail.Name = "lblLuonGuiThongBaoEmail";
            lblLuonGuiThongBaoEmail.Size = new Size(242, 23);
            lblLuonGuiThongBaoEmail.TabIndex = 2;
            lblLuonGuiThongBaoEmail.Text = "Luôn gửi thông báo qua email";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 84.13461F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.86538F));
            tableLayoutPanel4.Controls.Add(chkHoatDongKhongGianLamViec, 1, 0);
            tableLayoutPanel4.Controls.Add(lblMoTaHoatDongKhongGianLamViec, 0, 1);
            tableLayoutPanel4.Controls.Add(lblHoatDongKhongGianLamViec, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Top;
            tableLayoutPanel4.Location = new Point(0, 235);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel4.Size = new Size(599, 81);
            tableLayoutPanel4.TabIndex = 4;
            // 
            // chkHoatDongKhongGianLamViec
            // 
            chkHoatDongKhongGianLamViec.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkHoatDongKhongGianLamViec.AutoSize = true;
            chkHoatDongKhongGianLamViec.Checked = true;
            chkHoatDongKhongGianLamViec.CheckState = CheckState.Checked;
            chkHoatDongKhongGianLamViec.Location = new Point(578, 3);
            chkHoatDongKhongGianLamViec.Name = "chkHoatDongKhongGianLamViec";
            chkHoatDongKhongGianLamViec.Size = new Size(18, 17);
            chkHoatDongKhongGianLamViec.TabIndex = 4;
            chkHoatDongKhongGianLamViec.UseVisualStyleBackColor = true;
            // 
            // lblMoTaHoatDongKhongGianLamViec
            // 
            lblMoTaHoatDongKhongGianLamViec.AutoSize = true;
            tableLayoutPanel4.SetColumnSpan(lblMoTaHoatDongKhongGianLamViec, 2);
            lblMoTaHoatDongKhongGianLamViec.ForeColor = Color.Gray;
            lblMoTaHoatDongKhongGianLamViec.Location = new Point(3, 35);
            lblMoTaHoatDongKhongGianLamViec.Name = "lblMoTaHoatDongKhongGianLamViec";
            lblMoTaHoatDongKhongGianLamViec.Size = new Size(591, 46);
            lblMoTaHoatDongKhongGianLamViec.TabIndex = 3;
            lblMoTaHoatDongKhongGianLamViec.Text = "Nhận email khi bạn nhận được bình luận, lượt đề cập, lời mời ghé trang, lời nhắc, yêu cầu truy cập và thay đổi thuộc tính";
            // 
            // lblHoatDongKhongGianLamViec
            // 
            lblHoatDongKhongGianLamViec.AutoSize = true;
            lblHoatDongKhongGianLamViec.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHoatDongKhongGianLamViec.Location = new Point(3, 0);
            lblHoatDongKhongGianLamViec.Name = "lblHoatDongKhongGianLamViec";
            lblHoatDongKhongGianLamViec.Size = new Size(363, 23);
            lblHoatDongKhongGianLamViec.TabIndex = 2;
            lblHoatDongKhongGianLamViec.Text = "Hoạt động trong không gian làm việc của bạn";
            // 
            // lblThongBaoQuaEmail
            // 
            lblThongBaoQuaEmail.AutoSize = true;
            lblThongBaoQuaEmail.Dock = DockStyle.Top;
            lblThongBaoQuaEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblThongBaoQuaEmail.Location = new Point(0, 187);
            lblThongBaoQuaEmail.Name = "lblThongBaoQuaEmail";
            lblThongBaoQuaEmail.Padding = new Padding(0, 20, 0, 0);
            lblThongBaoQuaEmail.Size = new Size(212, 48);
            lblThongBaoQuaEmail.TabIndex = 3;
            lblThongBaoQuaEmail.Text = "Thông báo qua email";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 186);
            panel1.Name = "panel1";
            panel1.Size = new Size(599, 1);
            panel1.TabIndex = 2;
            // 
            // tableLayoutPanelDiscord
            // 
            tableLayoutPanelDiscord.ColumnCount = 2;
            tableLayoutPanelDiscord.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelDiscord.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelDiscord.Controls.Add(cmbThongBaoDiscord, 1, 0);
            tableLayoutPanelDiscord.Controls.Add(lblMoTaThongBaoDiscord, 0, 1);
            tableLayoutPanelDiscord.Controls.Add(lblThongBaoDiscord, 0, 0);
            tableLayoutPanelDiscord.Dock = DockStyle.Top;
            tableLayoutPanelDiscord.Location = new Point(0, 105);
            tableLayoutPanelDiscord.Name = "tableLayoutPanelDiscord";
            tableLayoutPanelDiscord.RowCount = 2;
            tableLayoutPanelDiscord.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanelDiscord.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelDiscord.Size = new Size(599, 81);
            tableLayoutPanelDiscord.TabIndex = 1;
            // 
            // cmbThongBaoDiscord
            // 
            cmbThongBaoDiscord.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbThongBaoDiscord.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbThongBaoDiscord.FormattingEnabled = true;
            cmbThongBaoDiscord.Items.AddRange(new object[] { "Tắt" });
            cmbThongBaoDiscord.Location = new Point(385, 3);
            cmbThongBaoDiscord.Name = "cmbThongBaoDiscord";
            cmbThongBaoDiscord.Size = new Size(211, 29);
            cmbThongBaoDiscord.TabIndex = 1;
            // 
            // lblMoTaThongBaoDiscord
            // 
            lblMoTaThongBaoDiscord.AutoSize = true;
            tableLayoutPanelDiscord.SetColumnSpan(lblMoTaThongBaoDiscord, 2);
            lblMoTaThongBaoDiscord.ForeColor = Color.Gray;
            lblMoTaThongBaoDiscord.Location = new Point(3, 35);
            lblMoTaThongBaoDiscord.Name = "lblMoTaThongBaoDiscord";
            lblMoTaThongBaoDiscord.Size = new Size(557, 46);
            lblMoTaThongBaoDiscord.TabIndex = 0;
            lblMoTaThongBaoDiscord.Text = "Nhận thông báo trong Discord khi có người đề cập đến bạn trong một trang, thuộc tính cơ sở dữ liệu hoặc bình luận";
            // 
            // lblThongBaoDiscord
            // 
            lblThongBaoDiscord.AutoSize = true;
            lblThongBaoDiscord.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblThongBaoDiscord.Location = new Point(3, 0);
            lblThongBaoDiscord.Name = "lblThongBaoDiscord";
            lblThongBaoDiscord.Size = new Size(202, 23);
            lblThongBaoDiscord.TabIndex = 0;
            lblThongBaoDiscord.Text = "Thông báo trong Discord";
            // 
            // lblTieuDeThongBao
            // 
            lblTieuDeThongBao.Dock = DockStyle.Top;
            lblTieuDeThongBao.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDeThongBao.Location = new Point(0, 0);
            lblTieuDeThongBao.Name = "lblTieuDeThongBao";
            lblTieuDeThongBao.Size = new Size(599, 105);
            lblTieuDeThongBao.TabIndex = 0;
            lblTieuDeThongBao.Text = "Thông báo";
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
            panelAccount.Controls.Add(label13);
            panelAccount.Controls.Add(linkThemAnh);
            panelAccount.Controls.Add(txtTenUaDung);
            panelAccount.Controls.Add(lblTenUaDung);
            panelAccount.Controls.Add(panelAvatar);
            panelAccount.Controls.Add(lblTieuDeTaiKhoan);
            panelAccount.Dock = DockStyle.Top;
            panelAccount.Location = new Point(40, 649);
            panelAccount.Name = "panelAccount";
            panelAccount.Size = new Size(599, 700);
            panelAccount.TabIndex = 1;
            // 
            // lblMaKhoa
            // 
            lblMaKhoa.AutoSize = true;
            lblMaKhoa.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaKhoa.Location = new Point(3, 581);
            lblMaKhoa.Name = "lblMaKhoa";
            lblMaKhoa.Size = new Size(76, 23);
            lblMaKhoa.TabIndex = 17;
            lblMaKhoa.Text = "Mã khóa";
            // 
            // btnThemPhuongThucXacMinh
            // 
            btnThemPhuongThucXacMinh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThemPhuongThucXacMinh.Location = new Point(409, 521);
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
            lblXacMinh2Buoc.Size = new Size(138, 23);
            lblXacMinh2Buoc.TabIndex = 14;
            lblXacMinh2Buoc.Text = "Xác minh 2 bước";
            // 
            // btnThemMatKhau
            // 
            btnThemMatKhau.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThemMatKhau.Location = new Point(409, 412);
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
            lblMatKhau.Size = new Size(82, 23);
            lblMatKhau.TabIndex = 11;
            lblMatKhau.Text = "Mật khẩu";
            // 
            // btnDoiEmail
            // 
            btnDoiEmail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDoiEmail.Location = new Point(409, 319);
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
            lblEmailValue.Size = new Size(237, 23);
            lblEmailValue.TabIndex = 9;
            lblEmailValue.Text = "quanghoa300404@gmail.com";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(3, 302);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(51, 23);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email";
            // 
            // lblBaoMatTaiKhoan
            // 
            lblBaoMatTaiKhoan.AutoSize = true;
            lblBaoMatTaiKhoan.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBaoMatTaiKhoan.Location = new Point(2, 252);
            lblBaoMatTaiKhoan.Name = "lblBaoMatTaiKhoan";
            lblBaoMatTaiKhoan.Size = new Size(186, 28);
            lblBaoMatTaiKhoan.TabIndex = 7;
            lblBaoMatTaiKhoan.Text = "Bảo mật tài khoản";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(177, 198);
            label13.Name = "label13";
            label13.Size = new Size(0, 23);
            label13.TabIndex = 5;
            // 
            // linkThemAnh
            // 
            linkThemAnh.AutoSize = true;
            linkThemAnh.Location = new Point(103, 198);
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
            txtTenUaDung.Size = new Size(490, 34);
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
            panelSettings.Size = new Size(599, 629);
            panelSettings.TabIndex = 0;
            // 
            // lblQuyenRiengTu
            // 
            lblQuyenRiengTu.AutoSize = true;
            lblQuyenRiengTu.Dock = DockStyle.Top;
            lblQuyenRiengTu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQuyenRiengTu.Location = new Point(0, 515);
            lblQuyenRiengTu.Name = "lblQuyenRiengTu";
            lblQuyenRiengTu.Padding = new Padding(0, 20, 0, 0);
            lblQuyenRiengTu.Size = new Size(155, 48);
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
            tableLayoutPanel3.Location = new Point(0, 434);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.Size = new Size(599, 81);
            tableLayoutPanel3.TabIndex = 7;
            // 
            // cmbMoKhiKhoiDong
            // 
            cmbMoKhiKhoiDong.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbMoKhiKhoiDong.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMoKhiKhoiDong.FormattingEnabled = true;
            cmbMoKhiKhoiDong.Items.AddRange(new object[] { "Trang truy cập gần đây nhất" });
            cmbMoKhiKhoiDong.Location = new Point(385, 3);
            cmbMoKhiKhoiDong.Name = "cmbMoKhiKhoiDong";
            cmbMoKhiKhoiDong.Size = new Size(211, 29);
            cmbMoKhiKhoiDong.TabIndex = 4;
            // 
            // lblMoTaMoKhiKhoiDong
            // 
            lblMoTaMoKhiKhoiDong.AutoSize = true;
            tableLayoutPanel3.SetColumnSpan(lblMoTaMoKhiKhoiDong, 2);
            lblMoTaMoKhiKhoiDong.ForeColor = Color.Gray;
            lblMoTaMoKhiKhoiDong.Location = new Point(3, 35);
            lblMoTaMoKhiKhoiDong.Name = "lblMoTaMoKhiKhoiDong";
            lblMoTaMoKhiKhoiDong.Size = new Size(552, 46);
            lblMoTaMoKhiKhoiDong.TabIndex = 3;
            lblMoTaMoKhiKhoiDong.Text = "Chọn nội dung hiển thị khi Notion khởi động hoặc khi bạn chuyển đổi không gian làm việc.";
            // 
            // lblMoKhiKhoiDong
            // 
            lblMoKhiKhoiDong.AutoSize = true;
            lblMoKhiKhoiDong.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMoKhiKhoiDong.Location = new Point(3, 0);
            lblMoKhiKhoiDong.Name = "lblMoKhiKhoiDong";
            lblMoKhiKhoiDong.Size = new Size(144, 23);
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
            lblKhoiDong.Size = new Size(111, 48);
            lblKhoiDong.TabIndex = 6;
            lblKhoiDong.Text = "Khởi động";
            // 
            // line3
            // 
            line3.BackColor = Color.Gainsboro;
            line3.Dock = DockStyle.Top;
            line3.Location = new Point(0, 385);
            line3.Name = "line3";
            line3.Size = new Size(599, 1);
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
            tableLayoutPanel2.Size = new Size(599, 81);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // chkBatDauTuan
            // 
            chkBatDauTuan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkBatDauTuan.AutoSize = true;
            chkBatDauTuan.Location = new Point(578, 3);
            chkBatDauTuan.Name = "chkBatDauTuan";
            chkBatDauTuan.Size = new Size(18, 17);
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
            lblMoTaBatDauTuan.Size = new Size(580, 23);
            lblMoTaBatDauTuan.TabIndex = 3;
            lblMoTaBatDauTuan.Text = "Thao tác này sẽ thay đổi giao diện của tất cả lịch trong ứng dụng của bạn.";
            // 
            // lblBatDauTuan
            // 
            lblBatDauTuan.AutoSize = true;
            lblBatDauTuan.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBatDauTuan.Location = new Point(3, 0);
            lblBatDauTuan.Name = "lblBatDauTuan";
            lblBatDauTuan.Size = new Size(202, 23);
            lblBatDauTuan.TabIndex = 2;
            lblBatDauTuan.Text = "Bắt đầu tuần vào thứ Hai";
            // 
            // line2
            // 
            line2.BackColor = Color.Gainsboro;
            line2.Dock = DockStyle.Top;
            line2.Location = new Point(0, 303);
            line2.Name = "line2";
            line2.Size = new Size(599, 1);
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
            tableLayoutPanel1.Size = new Size(599, 181);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // cmbNgonNgu
            // 
            cmbNgonNgu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbNgonNgu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNgonNgu.FormattingEnabled = true;
            cmbNgonNgu.Items.AddRange(new object[] { "Tiếng Việt", "Tiếng Anh" });
            cmbNgonNgu.Location = new Point(385, 78);
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
            lblMoTaNgonNgu.Location = new Point(3, 110);
            lblMoTaNgonNgu.Name = "lblMoTaNgonNgu";
            lblMoTaNgonNgu.Size = new Size(486, 23);
            lblMoTaNgonNgu.TabIndex = 3;
            lblMoTaNgonNgu.Text = "Thay đổi ngôn ngữ được sử dụng trong giao diện người dùng.";
            // 
            // lblNgonNgu
            // 
            lblNgonNgu.AutoSize = true;
            lblNgonNgu.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNgonNgu.Location = new Point(3, 75);
            lblNgonNgu.Name = "lblNgonNgu";
            lblNgonNgu.Size = new Size(88, 23);
            lblNgonNgu.TabIndex = 2;
            lblNgonNgu.Text = "Ngôn ngữ";
            // 
            // cmbGiaoDien
            // 
            cmbGiaoDien.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbGiaoDien.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGiaoDien.FormattingEnabled = true;
            cmbGiaoDien.Items.AddRange(new object[] { "Theo cài đặt hệ thống", "Sáng", "Tối" });
            cmbGiaoDien.Location = new Point(385, 3);
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
            lblMoTaGiaoDien.Size = new Size(383, 23);
            lblMoTaGiaoDien.TabIndex = 0;
            lblMoTaGiaoDien.Text = "Tùy chỉnh giao diện Notion trên thiết bị của bạn.";
            // 
            // lblGiaoDien
            // 
            lblGiaoDien.AutoSize = true;
            lblGiaoDien.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGiaoDien.Location = new Point(3, 0);
            lblGiaoDien.Name = "lblGiaoDien";
            lblGiaoDien.Size = new Size(83, 23);
            lblGiaoDien.TabIndex = 0;
            lblGiaoDien.Text = "Giao diện";
            // 
            // line1
            // 
            line1.BackColor = Color.Gainsboro;
            line1.Dock = DockStyle.Top;
            line1.Location = new Point(0, 121);
            line1.Name = "line1";
            line1.Size = new Size(599, 1);
            line1.TabIndex = 1;
            // 
            // lblTieuDeTuyChon
            // 
            lblTieuDeTuyChon.Dock = DockStyle.Top;
            lblTieuDeTuyChon.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDeTuyChon.Location = new Point(0, 0);
            lblTieuDeTuyChon.Name = "lblTieuDeTuyChon";
            lblTieuDeTuyChon.Size = new Size(599, 121);
            lblTieuDeTuyChon.TabIndex = 0;
            lblTieuDeTuyChon.Text = "Tùy chọn";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
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
            Text = "Cài đặt";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            sidebarPanel.ResumeLayout(false);
            panelTaiKhoan.ResumeLayout(false);
            panelTaiKhoan.PerformLayout();
            panelNotifications.ResumeLayout(false);
            panelNotifications.PerformLayout();
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanelDiscord.ResumeLayout(false);
            tableLayoutPanelDiscord.PerformLayout();
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
        private System.Windows.Forms.Button btnKetNoi;
        private System.Windows.Forms.Button btnThongBao;
        private System.Windows.Forms.Label lblKhongGianLamViec;
        private System.Windows.Forms.Button btnChung;
        private System.Windows.Forms.Button btnThanhVien;
        private System.Windows.Forms.Button btnKhongGianNhom;
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
        private System.Windows.Forms.Button btnBieuTuongCamXuc;
        private System.Windows.Forms.Button btnNhap;
        private System.Windows.Forms.Button btnNangCapGoi;
        private System.Windows.Forms.Panel panelNotifications;
        private System.Windows.Forms.Label lblTieuDeThongBao;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDiscord;
        private System.Windows.Forms.ComboBox cmbThongBaoDiscord;
        private System.Windows.Forms.Label lblMoTaThongBaoDiscord;
        private System.Windows.Forms.Label lblThongBaoDiscord;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblThongBaoQuaEmail;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckBox chkHoatDongKhongGianLamViec;
        private System.Windows.Forms.Label lblMoTaHoatDongKhongGianLamViec;
        private System.Windows.Forms.Label lblHoatDongKhongGianLamViec;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.CheckBox chkLuonGuiThongBaoEmail;
        private System.Windows.Forms.Label lblMoTaLuonGuiThongBaoEmail;
        private System.Windows.Forms.Label lblLuonGuiThongBaoEmail;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.CheckBox chkCapNhatTrang;
        private System.Windows.Forms.Label lblMoTaCapNhatTrang;
        private System.Windows.Forms.Label lblCapNhatTrang;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.CheckBox chkBanTomTatKhongGianLamViec;
        private System.Windows.Forms.Label lblMoTaBanTomTatKhongGianLamViec;
        private System.Windows.Forms.Label lblBanTomTatKhongGianLamViec;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label lblMoTaEmailThongBaoVaCapNhat;
        private System.Windows.Forms.Label lblEmailThongBaoVaCapNhat;
        private System.Windows.Forms.LinkLabel linkQuanLyCaiDat;
        private System.Windows.Forms.LinkLabel linkTimHieuThongBao;
        // KHAI BÁO BIẾN (MỚI)
        private System.Windows.Forms.OpenFileDialog openFileDialogAvatar;
        // Đã xóa các khai báo không cần thiết
        // private System.Windows.Forms.Button btnNotionAI; 
        // private System.Windows.Forms.Button btnNgoaiTuyen;
        // private System.Windows.Forms.LinkLabel linkTaoAnhChanDung;
    }
}