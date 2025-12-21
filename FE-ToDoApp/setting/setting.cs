using System;
using System.Drawing;
using System.Windows.Forms;

namespace FE_ToDoApp.Setting
{
    public partial class setting : Form
    {
        public setting()
        {
            InitializeComponent();

            cmbGiaoDien.SelectedItem = "Sáng";
            cmbNgonNgu.SelectedItem = "Tiếng Việt";

            SetTheme("Sáng");
            SetLanguage("Tiếng Việt");

            panelTaiKhoan.Click += (s, e) => ShowPanel(panelAccount);
            lblTaiKhoan.Click += (s, e) => ShowPanel(panelAccount);
            btnTuyChon.Click += (s, e) => ShowPanel(panelSettings);
        }

        private void ShowPanel(Panel panelToShow)
        {
            panelSettings.Visible = false;
            panelAccount.Visible = false;
            panelToShow.Visible = true;
            panelToShow.BringToFront();
        }

        private void cmbGiaoDien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGiaoDien.SelectedItem != null)
                SetTheme(cmbGiaoDien.SelectedItem.ToString());
        }

        private void cmbNgonNgu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNgonNgu.SelectedItem != null)
                SetLanguage(cmbNgonNgu.SelectedItem.ToString());
        }

        private void linkThemAnh_Click(object sender, EventArgs e)
        {
            if (openFileDialogAvatar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    panelAvatar.BackgroundImage = Image.FromFile(openFileDialogAvatar.FileName);
                    lblAvatarText.Visible = false;
                }
                catch (Exception ex) { MessageBox.Show("Lỗi ảnh: " + ex.Message); }
            }
        }

        private void SetTheme(string theme)
        {
            bool isDark = (theme == "Tối");

            Color bgColor = isDark ? Color.FromArgb(32, 32, 32) : Color.White;
            Color fgColor = isDark ? Color.White : Color.Black;
            Color subTextColor = isDark ? Color.DarkGray : Color.Gray;
            Color lineColor = isDark ? Color.FromArgb(60, 60, 60) : Color.Gainsboro;
            Color inputBg = isDark ? Color.FromArgb(50, 50, 50) : Color.White;

            this.BackColor = bgColor;
            this.ForeColor = fgColor;

            ApplyThemeRecursive(this.Controls, bgColor, fgColor, subTextColor, lineColor, inputBg);
        }

        private void ApplyThemeRecursive(Control.ControlCollection controls, Color bg, Color fg, Color subText, Color line, Color inputBg)
        {
            foreach (Control c in controls)
            {
                if (c.Controls.Count > 0) ApplyThemeRecursive(c.Controls, bg, fg, subText, line, inputBg);

                if (c is Panel p)
                {
                    if (p.Tag?.ToString() == "Sidebar") p.BackColor = bg;
                    else if (p.Name.StartsWith("line")) p.BackColor = line;
                    else p.BackColor = Color.Transparent;
                }
                else if (c is Label lbl)
                {
                    lbl.ForeColor = lbl.Font.Bold ? fg : subText;
                    lbl.BackColor = Color.Transparent;
                }
                else if (c is Button btn)
                {
                    btn.ForeColor = fg;
                    btn.BackColor = (btn.FlatStyle == FlatStyle.Flat) ? bg : inputBg;
                }
                else if (c is ComboBox || c is TextBox)
                {
                    c.BackColor = inputBg;
                    c.ForeColor = fg;
                }
                else if (c is LinkLabel link)
                {
                    link.LinkColor = Color.DodgerBlue;
                    link.BackColor = Color.Transparent;
                }
            }
        }

        private void SetLanguage(string lang)
        {
            bool isEng = (lang == "Tiếng Anh");

            lblTaiKhoan.Text = isEng ? "Quang Hoa Bui" : "Quang Hòa Bùi";
            btnTuyChon.Text = isEng ? "     Settings" : "     Tùy chọn";

            lblTieuDeTuyChon.Text = isEng ? "Settings" : "Tùy chọn";
            lblGiaoDien.Text = isEng ? "Appearance" : "Giao diện";
            lblMoTaGiaoDien.Text = isEng ? "Customize appearance on this device." : "Tùy chỉnh giao diện Notion trên thiết bị của bạn.";
            lblNgonNgu.Text = isEng ? "Language" : "Ngôn ngữ";
            lblMoTaNgonNgu.Text = isEng ? "Change the language used in the interface." : "Thay đổi ngôn ngữ được sử dụng trong giao diện.";

            lblTieuDeTaiKhoan.Text = isEng ? "My Account" : "Tài khoản";
            lblTenUaDung.Text = isEng ? "Preferred name" : "Tên ưa dùng";
            linkThemAnh.Text = isEng ? "Add photo" : "Thêm ảnh";
            lblEmail.Text = "Email";
        }
    }
}