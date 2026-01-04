using System;
using System.Drawing;
using System.Windows.Forms;
using FE_ToDoApp.DAO;
using FE_ToDoApp.DTO;

namespace FE_ToDoApp.Setting
{
    public partial class setting : Form
    {
        UserDAO userDAO = new UserDAO();
        int currentUserId = 3; //ID trong SQL
        User currentUser;

        public setting()
        {
            InitializeComponent();

            SetTheme("Sáng");
            cmbGiaoDien.SelectedItem = "Sáng";
            ShowPanel(panelAccount);

            LoadUserData();

            btnThongTinCaNhan.Click += (s, e) => ShowPanel(panelAccount);
            btnGiaoDien.Click += (s, e) => ShowPanel(panelAppearance);
        }

        private void LoadUserData()
        {
            currentUser = userDAO.GetUserById(currentUserId);

            if (currentUser != null)
            {
                txtTenHienThi.Text = currentUser.Username;
                txtEmail.Text = currentUser.Email;
                lblSidebarName.Text = currentUser.Username;

                //Image
                if (currentUser.Avatar != null && currentUser.Avatar.Length > 0)
                {
                    try
                    {
                        panelAvatar.BackgroundImage = userDAO.ByteArrayToImage(currentUser.Avatar);
                        lblAvatarText.Visible = false;
                    }
                    catch {}
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy User!");
            }
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            bool success = userDAO.UpdateUserInfo(currentUserId, txtTenHienThi.Text, txtEmail.Text);
            if (success)
            {
                MessageBox.Show("Cập nhật thành công!");
                lblSidebarName.Text = txtTenHienThi.Text;
                currentUser.Username = txtTenHienThi.Text;
                currentUser.Email = txtEmail.Text;
            }
            else
            {
                MessageBox.Show("Lỗi khi lưu thông tin.");
            }
        }

        private void btnLuuMatKhau_Click(object sender, EventArgs e)
        {
            if (currentUser == null) return;

            if (txtPassCu.Text != currentUser.Password)
            {
                MessageBox.Show("Mật khẩu cũ không đúng!");
                return;
            }
            if (txtPassMoi.Text != txtPassXacNhan.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!");
                return;
            }

            bool success = userDAO.ChangePassword(currentUserId, txtPassMoi.Text);
            if (success)
            {
                MessageBox.Show("Đổi mật khẩu thành công!");
                currentUser.Password = txtPassMoi.Text;
                txtPassCu.Clear(); txtPassMoi.Clear(); txtPassXacNhan.Clear();
            }
            else
            {
                MessageBox.Show("Lỗi đổi mật khẩu.");
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
                    bool success = userDAO.UpdateUserAvatar(currentUserId, imgBytes);

                    if (!success) MessageBox.Show("Không lưu được ảnh vào Database!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
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
            if (cmbGiaoDien.SelectedItem != null) SetTheme(cmbGiaoDien.SelectedItem.ToString());
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
    }
}