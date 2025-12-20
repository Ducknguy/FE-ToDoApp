using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// ĐÃ THAY ĐỔI NAMESPACE ĐỂ TRÙNG VỚI TỆP DESIGNER
namespace FE_ToDoApp.Setting
{
    public partial class setting : Form
    {
        public setting()
        {
            InitializeComponent();

            // --- CÀI ĐẶT BAN ĐẦU ---

            // 1. Đặt theme mặc định là Sáng (hoặc theo hệ thống)
            SetTheme("Sáng"); // Giả định bắt đầu với theme Sáng

            // 2. Đặt ngôn ngữ mặc định
            cmbNgonNgu.SelectedItem = "Tiếng Việt";
            SetLanguage("Tiếng Việt");

            // 3. Hiển thị panel Cài đặt (Settings) và ẩn 2 panel còn lại
            panelSettings.Visible = true;
            panelAccount.Visible = false;
            panelNotifications.Visible = false;

            // 4. Đăng ký sự kiện click cho các panel/label ở sidebar
            // Click vào "Quang Hòa Bùi"
            panelTaiKhoan.Click += new EventHandler(ShowAccountPanel_Click);
            lblTaiKhoan.Click += new EventHandler(ShowAccountPanel_Click);

            // Click vào "Tùy chọn"
            btnTuyChon.Click += new EventHandler(ShowSettingsPanel_Click);

            // Click vào "Thông báo"
            btnThongBao.Click += new EventHandler(ShowNotificationsPanel_Click);
        }

        // --- BỘ XỬ LÝ SỰ KIỆN ---

        /// <summary>
        /// Hiển thị Panel Tài khoản
        /// </summary>
        private void ShowAccountPanel_Click(object sender, EventArgs e)
        {
            panelSettings.Visible = false;
            panelAccount.Visible = true;
            panelNotifications.Visible = false;
        }

        /// <summary>
        /// Hiển thị Panel Cài đặt
        /// </summary>
        private void ShowSettingsPanel_Click(object sender, EventArgs e)
        {
            panelSettings.Visible = true;
            panelAccount.Visible = false;
            panelNotifications.Visible = false;
        }

        /// <summary>
        /// Hiển thị Panel Thông báo
        /// </summary>
        private void ShowNotificationsPanel_Click(object sender, EventArgs e)
        {
            panelSettings.Visible = false;
            panelAccount.Visible = false;
            panelNotifications.Visible = true;
        }


        /// <summary>
        /// Xử lý sự kiện khi người dùng thay đổi lựa chọn Giao diện (Theme)
        /// </summary>
        private void cmbGiaoDien_SelectedIndexChanged(object sender, EventArgs e)
        {
            // *** ĐÃ SỬA LỖI CS8600 ***
            // Lấy giá trị một cách an toàn, kiểm tra null
            string? selectedTheme = cmbGiaoDien.SelectedItem as string;
            if (selectedTheme != null)
            {
                SetTheme(selectedTheme);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng thay đổi Ngôn ngữ
        /// </summary>
        private void cmbNgonNgu_SelectedIndexChanged(object sender, EventArgs e)
        {
            // *** ĐÃ SỬA LỖI CS8600 (Dòng 121 của bạn) ***
            // Lấy giá trị một cách an toàn, kiểm tra null
            string? selectedLang = cmbNgonNgu.SelectedItem as string;
            if (selectedLang != null)
            {
                SetLanguage(selectedLang);
            }
        }

        /// <summary>
        /// (MỚI) Xử lý sự kiện click "Thêm ảnh"
        /// </summary>
        private void linkThemAnh_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại chọn tệp
            if (openFileDialogAvatar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Lấy đường dẫn tệp
                    string imagePath = openFileDialogAvatar.FileName;

                    // Tải ảnh vào panelAvatar
                    panelAvatar.BackgroundImage = Image.FromFile(imagePath);

                    // Ẩn chữ "Q" đi
                    lblAvatarText.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải ảnh: " + ex.Message);
                }
            }
        }


        // --- LOGIC CHÍNH ---

        /// <summary>
        /// Hàm chính để đổi Theme Sáng/Tối
        /// </summary>
        private void SetTheme(string theme)
        {
            Color bgColor, fgColor;
            Color panelBgColor = Color.White; // Màu nền cho các panel nội dung

            if (theme == "Tối")
            {
                bgColor = Color.FromArgb(40, 40, 40); // Màu nền tối
                fgColor = Color.White; // Chữ trắng
                panelBgColor = Color.FromArgb(40, 40, 40);
            }
            else // "Sáng" hoặc "Theo cài đặt hệ thống"
            {
                bgColor = Color.White; // Nền trắng
                fgColor = Color.Black; // Chữ đen
                panelBgColor = Color.White;
            }

            // Áp dụng màu cho Form chính và SplitContainer
            this.BackColor = bgColor;
            this.ForeColor = fgColor;

            splitContainer1.BackColor = bgColor;
            splitContainer1.Panel1.BackColor = bgColor; // Sidebar
            splitContainer1.Panel2.BackColor = panelBgColor; // Nội dung

            // Gọi hàm đệ quy để đổi màu tất cả control
            ApplyThemeRecursive(this.Controls, bgColor, fgColor);
        }

        /// <summary>
        /// Hàm đệ quy duyệt qua tất cả control và áp dụng theme
        /// </summary>
        private void ApplyThemeRecursive(Control.ControlCollection controls, Color bgColor, Color fgColor)
        {
            foreach (Control control in controls)
            {
                // Áp dụng cho control con trước
                if (control.Controls.Count > 0)
                {
                    ApplyThemeRecursive(control.Controls, bgColor, fgColor);
                }

                // --- XỬ LÝ CÁC LOẠI CONTROL CỤ THỂ ---

                // Các Panel (Bao gồm cả SplitContainer và TableLayoutPanel)
                if (control is Panel || control is SplitContainer || control is TableLayoutPanel)
                {
                    control.BackColor = control.Tag?.ToString() == "Sidebar" ? bgColor : Color.Transparent; // Panel sidebar giữ màu nền chính, còn lại trong suốt
                    control.ForeColor = fgColor;
                }

                // Các Nhãn (Label)
                else if (control is Label lbl)
                {
                    lbl.ForeColor = fgColor;

                    // Các tiêu đề (Ví dụ: "Tài khoản", "Quyền riêng tư")
                    if (lbl.Font.Bold)
                    {
                        lbl.BackColor = Color.Transparent; // Tiêu đề phải trong suốt
                        lbl.ForeColor = fgColor;
                    }
                    // Các nhãn mô tả
                    else
                    {
                        lbl.BackColor = Color.Transparent; // Nhãn trên panel phải trong suốt
                        lbl.ForeColor = (bgColor == Color.White) ? Color.Gray : Color.Gainsboro; // Màu mô tả
                    }
                }

                // Các Nút (Button)
                else if (control is Button btn)
                {
                    if (btn.FlatStyle == FlatStyle.Flat) // Các nút ở sidebar
                    {
                        btn.BackColor = bgColor;
                        btn.ForeColor = fgColor;
                    }
                    else // Các nút có viền (ví dụ: "Đổi email")
                    {
                        btn.BackColor = (bgColor == Color.White) ? Color.WhiteSmoke : Color.Gray;
                        btn.ForeColor = fgColor;
                    }
                }

                // ComboBox (Hộp chọn)
                else if (control is ComboBox cmb)
                {
                    cmb.BackColor = bgColor;
                    cmb.ForeColor = fgColor;
                }

                // CheckBox (Hộp kiểm)
                else if (control is CheckBox chk)
                {
                    chk.BackColor = Color.Transparent; // Phải trong suốt
                    chk.ForeColor = fgColor;
                }

                // LinkLabel
                else if (control is LinkLabel link)
                {
                    link.BackColor = Color.Transparent;
                    // Màu link giữ nguyên (thường là xanh) hoặc tùy chỉnh
                    // link.LinkColor = ...
                }

                // TextBox
                else if (control is TextBox txt)
                {
                    txt.BackColor = (bgColor == Color.White) ? Color.White : Color.DarkGray;
                    txt.ForeColor = fgColor;
                }
            }
        }


        /// <summary>
        /// Hàm chính để đổi ngôn ngữ
        /// </summary>
        private void SetLanguage(string lang)
        {
            if (lang == "Tiếng Anh")
            {
                // Sidebar
                lblTaiKhoan.Text = "Quang Hoa Bui";
                btnTuyChon.Text = "     Settings";
                btnThongBao.Text = "     Notifications";
                btnKetNoi.Text = "     Connections";
                // btnNgoaiTuyen.Text = "     Offline"; // ĐÃ XÓA
                lblKhongGianLamViec.Text = "Workspace";
                btnChung.Text = "     General";
                btnThanhVien.Text = "     Members";
                btnKhongGianNhom.Text = "     Teamspaces";
                // btnNotionAI.Text = "     Notion AI"; // ĐÃ XÓA
                btnTrangCongKhai.Text = "     Public Pages";
                btnSidebarKetNoi.Text = "     Connections";
                // btnBieuTuongCamXuc (Mới từ Panel Thông báo)
                // btnNhap (Mới từ Panel Thông báo)
                // btnNangCapGoi (Mới từ Panel Thông báo)

                // Panel Cài đặt (Settings)
                lblTieuDeTuyChon.Text = "Settings";
                lblGiaoDien.Text = "Appearance";
                lblMoTaGiaoDien.Text = "Customize Notion's appearance on this device.";
                lblNgonNgu.Text = "Language";
                lblMoTaNgonNgu.Text = "Change the language used in the interface.";
                lblBatDauTuan.Text = "Start week on Monday";
                lblMoTaBatDauTuan.Text = "This action will change the display of all calendars...";
                lblKhoiDong.Text = "Startup";
                lblMoKhiKhoiDong.Text = "Open on startup";
                lblMoTaMoKhiKhoiDong.Text = "Choose what Notion displays when starting or...";
                lblQuyenRiengTu.Text = "Privacy";

                // Panel Tài khoản (Account)
                lblTieuDeTaiKhoan.Text = "My Account";
                lblTenUaDung.Text = "Preferred name";
                linkThemAnh.Text = "Add photo";
                // linkTaoAnhChanDung.Text = "Create avatar"; // ĐÃ XÓA
                lblBaoMatTaiKhoan.Text = "Account security";
                lblEmail.Text = "Email";
                btnDoiEmail.Text = "Change email";
                lblMatKhau.Text = "Password";
                lblMoTaMatKhau.Text = "Set a permanent password to log in...";
                btnThemMatKhau.Text = "Add password";
                lblXacMinh2Buoc.Text = "2-step verification";
                lblMoTaXacMinh2Buoc.Text = "Add an extra layer of security...";
                btnThemPhuongThucXacMinh.Text = "Add verification method";
                lblMaKhoa.Text = "Lock code";

                // Panel Thông báo (Notifications)
                lblTieuDeThongBao.Text = "Notifications";
                lblThongBaoDiscord.Text = "Discord notifications";
                lblMoTaThongBaoDiscord.Text = "Receive Discord notifications when someone...";
                lblThongBaoQuaEmail.Text = "Email notifications";
                lblHoatDongKhongGianLamViec.Text = "Activity in your workspace";
                lblMoTaHoatDongKhongGianLamViec.Text = "Receive emails about comments, mentions, page invitations...";
                lblLuonGuiThongBaoEmail.Text = "Always send email notifications";
                lblMoTaLuonGuiThongBaoEmail.Text = "Receive email notifications even when you are active...";
                lblCapNhatTrang.Text = "Page updates";
                lblMoTaCapNhatTrang.Text = "Receive email summaries of changes to pages...";
                lblBanTomTatKhongGianLamViec.Text = "Workspace summary";
                lblMoTaBanTomTatKhongGianLamViec.Text = "Receive email summaries of what's new...";
                lblEmailThongBaoVaCapNhat.Text = "Email notifications and updates";
                lblMoTaEmailThongBaoVaCapNhat.Text = "Receive occasional emails about new products...";
                linkQuanLyCaiDat.Text = "Manage settings";
                linkTimHieuThongBao.Text = "Learn about notifications";

            }
            else // Tiếng Việt
            {
                // Sidebar
                lblTaiKhoan.Text = "Quang Hòa Bùi";
                btnTuyChon.Text = "     Tùy chọn";
                btnThongBao.Text = "     Thông báo";
                btnKetNoi.Text = "     Kết nối";
                // btnNgoaiTuyen.Text = "     Ngoại tuyến"; // ĐÃ XÓA
                lblKhongGianLamViec.Text = "Không gian làm việc";
                btnChung.Text = "     Chung";
                btnThanhVien.Text = "     Người dùng"; // Sửa lại từ Thành viên
                btnKhongGianNhom.Text = "     Không gian nhóm";
                // btnNotionAI.Text = "     Notion AI"; // ĐÃ XÓA
                btnTrangCongKhai.Text = "     Trang công khai";
                btnSidebarKetNoi.Text = "     Kết nối";
                // btnBieuTuongCamXuc (Mới từ Panel Thông báo)
                // btnNhap (Mới từ Panel Thông báo)
                // btnNangCapGoi (Mới từ Panel Thông báo)

                // Panel Cài đặt (Settings)
                lblTieuDeTuyChon.Text = "Tùy chọn";
                lblGiaoDien.Text = "Giao diện";
                lblMoTaGiaoDien.Text = "Tùy chỉnh giao diện Notion trên thiết bị của bạn.";
                lblNgonNgu.Text = "Ngôn ngữ";
                lblMoTaNgonNgu.Text = "Thay đổi ngôn ngữ được sử dụng trong giao diện.";
                lblBatDauTuan.Text = "Bắt đầu tuần vào thứ Hai";
                lblMoTaBatDauTuan.Text = "Thao tác này sẽ thay đổi giao diện của tất cả lịch...";
                lblKhoiDong.Text = "Khởi động";
                lblMoKhiKhoiDong.Text = "Mở khi khởi động";
                lblMoTaMoKhiKhoiDong.Text = "Chọn nội dung hiển thị khi Notion khởi động...";
                lblQuyenRiengTu.Text = "Quyền riêng tư";

                // Panel Tài khoản (Account)
                lblTieuDeTaiKhoan.Text = "Tài khoản";
                lblTenUaDung.Text = "Tên ưa dùng";
                linkThemAnh.Text = "Thêm ảnh";
                // linkTaoAnhChanDung.Text = "Tạo ảnh chân dung"; // ĐÃ XÓA
                lblBaoMatTaiKhoan.Text = "Bảo mật tài khoản";
                lblEmail.Text = "Email";
                btnDoiEmail.Text = "Đổi email";
                lblMatKhau.Text = "Mật khẩu";
                lblMoTaMatKhau.Text = "Đặt mật khẩu vĩnh viễn để đăng nhập...";
                btnThemMatKhau.Text = "Thêm mật khẩu";
                lblXacMinh2Buoc.Text = "Xác minh 2 bước";
                lblMoTaXacMinh2Buoc.Text = "Thêm một lớp bảo mật bổ sung...";
                btnThemPhuongThucXacMinh.Text = "Thêm phương thức xác minh";
                lblMaKhoa.Text = "Mã khóa";

                // Panel Thông báo (Notifications)
                lblTieuDeThongBao.Text = "Thông báo";
                lblThongBaoDiscord.Text = "Thông báo trong Discord";
                lblMoTaThongBaoDiscord.Text = "Nhận thông báo trong Discord khi có người...";
                lblThongBaoQuaEmail.Text = "Thông báo qua email";
                lblHoatDongKhongGianLamViec.Text = "Hoạt động trong không gian làm việc của bạn";
                lblMoTaHoatDongKhongGianLamViec.Text = "Nhận email khi bạn nhận được bình luận, lượt đề cập...";
                lblLuonGuiThongBaoEmail.Text = "Luôn gửi thông báo qua email";
                lblMoTaLuonGuiThongBaoEmail.Text = "Nhận email về hoạt động trong không gian làm việc...";
                lblCapNhatTrang.Text = "Cập nhật trang";
                lblMoTaCapNhatTrang.Text = "Nhận email tóm tắt về các thay đổi đối với...";
                lblBanTomTatKhongGianLamViec.Text = "Bản tóm tắt không gian làm việc";
                lblMoTaBanTomTatKhongGianLamViec.Text = "Nhận email tóm tắt về những gì đang xảy ra...";
                lblEmailThongBaoVaCapNhat.Text = "Email thông báo và cập nhật";
                lblMoTaEmailThongBaoVaCapNhat.Text = "Nhận email không thường xuyên khi có đợt ra mắt...";
                linkQuanLyCaiDat.Text = "Quản lý cài đặt";
                linkTimHieuThongBao.Text = "Tìm hiểu về thông báo";
            }
        }

        private void setting_Load(object sender, EventArgs e)
        {

        }
    }
}