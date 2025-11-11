using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            // 3. Hiển thị panel Cài đặt (Settings) và ẩn panel Tài khoản (Account)
            panelSettings.Visible = true;
            panelAccount.Visible = false;

            // 4. Đăng ký sự kiện click cho các panel/label ở sidebar
            // Click vào "Quang Hòa Bùi"
            panelTaiKhoan.Click += new EventHandler(ShowAccountPanel_Click);
            lblTaiKhoan.Click += new EventHandler(ShowAccountPanel_Click);

            // Click vào "Tùy chọn"
            btnTuyChon.Click += new EventHandler(ShowSettingsPanel_Click);
        }

        // --- BỘ XỬ LÝ SỰ KIỆN ---

        /// <summary>
        /// Xử lý sự kiện khi click vào "Quang Hòa Bùi" -> Hiển thị Panel Tài khoản
        /// </summary>
        private void ShowAccountPanel_Click(object sender, EventArgs e)
        {
            panelSettings.Visible = false;
            panelAccount.Visible = true;
        }

        /// <summary>
        /// Xử lý sự kiện khi click vào "Tùy chọn" -> Hiển thị Panel Cài đặt
        /// </summary>
        private void ShowSettingsPanel_Click(object sender, EventArgs e)
        {
            panelSettings.Visible = true;
            panelAccount.Visible = false;
        }


        /// <summary>
        /// Xử lý sự kiện khi người dùng thay đổi lựa chọn Giao diện (Theme)
        /// </summary>
        private void cmbGiaoDien_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTheme = cmbGiaoDien.SelectedItem.ToString();
            SetTheme(selectedTheme);
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng thay đổi Ngôn ngữ
        /// </summary>
        private void cmbNgonNgu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLang = cmbNgonNgu.SelectedItem.ToString();
            SetLanguage(selectedLang);
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
                    lbl.ForeColor = fgColor; // Khoảng quan trọng nên có cp

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
                btnNgoaiTuyen.Text = "     Offline";
                lblKhongGianLamViec.Text = "Workspace";
                btnChung.Text = "     General";
                btnThanhVien.Text = "     Members";
                btnKhongGianNhom.Text = "     Teamspaces";
                btnNotionAI.Text = "     Notion AI";
                btnTrangCongKhai.Text = "     Public Pages";
                btnSidebarKetNoi.Text = "     Connections";

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
                linkTaoAnhChanDung.Text = "Create avatar";
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
            }
            else // Tiếng Việt
            {
                // Sidebar
                lblTaiKhoan.Text = "Quang Hòa Bùi";
                btnTuyChon.Text = "     Tùy chọn";
                btnThongBao.Text = "     Thông báo";
                btnKetNoi.Text = "     Kết nối";
                btnNgoaiTuyen.Text = "     Ngoại tuyến";
                lblKhongGianLamViec.Text = "Không gian làm việc";
                btnChung.Text = "     Chung";
                btnThanhVien.Text = "     Thành viên";
                btnKhongGianNhom.Text = "     Không gian nhóm";
                btnNotionAI.Text = "     Notion AI";
                btnTrangCongKhai.Text = "     Trang công khai";
                btnSidebarKetNoi.Text = "     Kết nối";

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
                linkTaoAnhChanDung.Text = "Tạo ảnh chân dung";
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
            }
        }

        private void setting_Load(object sender, EventArgs e)
        {

        }
    }
}

