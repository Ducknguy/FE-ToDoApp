using System;
using System.Drawing;
using System.Windows.Forms;
using FE_ToDoApp.DAO;
using FE_ToDoApp.DTO;

namespace FE_ToDoApp.Setting
{
    public partial class setting : Form
    {
        private UserDAO userDAO = new UserDAO();
        private int currentUserId;
        private User currentUser;

        public setting(int idNguoiDung)
        {
            InitializeComponent();
            this.currentUserId = idNguoiDung;

            btnLuuMatKhau.Click -= btnLuuMatKhau_Click;
            btnLuuMatKhau.Click += btnLuuMatKhau_Click;

            btnLuuThongTin.Click -= btnLuuThongTin_Click;
            btnLuuThongTin.Click += btnLuuThongTin_Click;

            btnThongTinCaNhan.Click += (s, e) => ShowPanel(panelAccount);
            btnGiaoDien.Click += (s, e) => ShowPanel(panelAppearance);
            btnDoiAnh.Click += btnDoiAnh_Click;

            SetTheme("Sáng");
            if (cmbGiaoDien.Items.Count > 0) cmbGiaoDien.SelectedItem = "Sáng";
            ShowPanel(panelAccount);

            LoadUserData();
        }

        private void LoadUserData()
        {
            currentUser = userDAO.GetUserById(currentUserId);
            if (currentUser != null)
            {
                lblSidebarName.Text = currentUser.Username;
                txtTenHienThi.Text = currentUser.Username;
                txtEmail.Text = currentUser.Email;

                if (currentUser.Avatar != null && currentUser.Avatar.Length > 0)
                {
                    try
                    {
                        panelAvatar.BackgroundImage = userDAO.ByteArrayToImage(currentUser.Avatar);
                        lblAvatarText.Visible = false;
                    }
                    catch
                    {
                        lblAvatarText.Visible = true;
                    }
                }
            }
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            if (currentUser == null) return;

            bool success = userDAO.UpdateUserInfo(currentUserId, txtTenHienThi.Text, txtEmail.Text);
            if (success)
            {
                MessageBox.Show("Cập nhật thông tin thành công!");
                currentUser.Username = txtTenHienThi.Text;
                currentUser.Email = txtEmail.Text;
                lblSidebarName.Text = currentUser.Username;
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra (Có thể tên đăng nhập đã tồn tại).");
            }
        }

        private void btnLuuMatKhau_Click(object sender, EventArgs e)
        {
            if (currentUser == null) return;

            if (txtPassMoi.Text.Length < 8)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 8 ký tự!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassCu.Text != currentUser.Password)
            {
                MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPassMoi.Text != txtPassXacNhan.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không trùng khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool success = userDAO.ChangePassword(currentUserId, txtPassMoi.Text);
            if (success)
            {
                MessageBox.Show("Đổi mật khẩu thành công!");
                currentUser.Password = txtPassMoi.Text;
                txtPassCu.Clear();
                txtPassMoi.Clear();
                txtPassXacNhan.Clear();
            }
            else
            {
                MessageBox.Show("Lỗi hệ thống khi đổi mật khẩu.");
            }
        }

        private void btnDoiAnh_Click(object sender, EventArgs e)
        {
            if (openFileDialogAvatar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image img = Image.FromFile(openFileDialogAvatar.FileName);
                    panelAvatar.BackgroundImage = img;
                    lblAvatarText.Visible = false;
                    byte[] imgBytes = userDAO.ImageToByteArray(img);
                    userDAO.UpdateUserAvatar(currentUserId, imgBytes);
                    currentUser.Avatar = imgBytes;
                }
                catch
                {
                    MessageBox.Show("Lỗi định dạng ảnh.");
                }
            }
        }

        private void ShowPanel(Panel p)
        {
            panelAccount.Visible = false;
            panelAppearance.Visible = false;
            p.Visible = true;
            p.BringToFront();
        }

        private void cmbGiaoDien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGiaoDien.SelectedItem != null)
                SetTheme(cmbGiaoDien.SelectedItem.ToString());
        }

        private void SetTheme(string theme)
        {
            bool isDark = (theme == "Tối");
            Color bgColor = isDark ? Color.FromArgb(32, 32, 32) : Color.White;
            Color fgColor = isDark ? Color.White : Color.Black;
            this.BackColor = bgColor;
            this.ForeColor = fgColor;
            sidebarPanel.BackColor = bgColor;
            ApplyThemeRecursive(this.Controls, bgColor, fgColor);
        }

        private void ApplyThemeRecursive(Control.ControlCollection controls, Color bg, Color fg)
        {
            foreach (Control c in controls)
            {
                if (c.Controls.Count > 0) ApplyThemeRecursive(c.Controls, bg, fg);
                if (c is GroupBox g) g.ForeColor = fg;
                if (c is Label l) l.ForeColor = fg;
                if (c is TextBox t)
                {
                    t.BackColor = (bg == Color.White) ? Color.WhiteSmoke : Color.FromArgb(60, 60, 60);
                    t.ForeColor = fg;
                }
                if (c is Button b && b.FlatStyle == FlatStyle.Flat) b.ForeColor = fg;
            }
        }

        private void chkShowPassword_CheckedChanged_1(object sender, EventArgs e)
        {
            txtPassXacNhan.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
            txtPassMoi.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
            txtPassCu.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        private void txtPassXacNhan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}