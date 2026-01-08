using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ChatbotAI_Form
{
    public static class UIHelper
    {
        /// <summary>
        /// Hàm hỗ trợ bo góc cho bất kỳ Control nào
        /// </summary>
        /// <param name="control">Control cần bo (Button, Panel, Form...)</param>
        /// <param name="radius">Bán kính góc bo</param>
        public static void BoGoc(Control control, int radius)
        {
            if (control == null || radius <= 0) return;

            GraphicsPath path = new GraphicsPath();
            // Vẽ các cung tròn cho 4 góc
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            // Gán vùng hiển thị mới cho control
            control.Region = new Region(path);
        }

        //FOTER BÊN DƯỚI KHI TƯƠNG TÁC NÓ SẼ NOIOT HẲN LÊN 
        public static void VeVienFocus(Panel panel, TextBox input, Color colorFocus, Color colorNormal)
        {
            // Biến để lưu trạng thái đang Focus hay không
            bool isFocused = false;

            // Khi người dùng nhấn vào ô Text
            input.Enter += (s, e) => { isFocused = true; panel.Invalidate(); };

            // Khi người dùng nhấn ra ngoài
            input.Leave += (s, e) => { isFocused = false; panel.Invalidate(); };

            // Sự kiện vẽ của Panel
            panel.Paint += (s, e) =>
            {
                Color penColor = isFocused ? colorFocus : colorNormal;
                // Độ dày viền là 2 pixel
                using (Pen pen = new Pen(penColor, 2))
                {
                    // Vẽ hình chữ nhật bao quanh (lùi vào 1px để không bị mất góc bo)
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.DrawRectangle(pen, 3, 3, panel.Width - 7, panel.Height - 7);
                }
            };
        }

        // thêm file vào ttrene chô
        public static Panel CreateFileChip(string fileName, Action onRemove)
        {
            // Khung bao quanh file
            Panel chip = new Panel
            {
                Size = new Size(180, 32),
                BackColor = Color.FromArgb(243, 243, 243),
                Margin = new Padding(0, 0, 8, 5),
                Cursor = Cursors.Default
            };
            UIHelper.BoGoc(chip, 12); // Bo tròn nhẹ

            // Nhãn tên file
            Label lbl = new Label
            {
                Text = "📎 " + fileName,
                AutoSize = false,
                Size = new Size(145, 32),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 0, 0),
                Font = new Font("Segoe UI", 9F),
                AutoEllipsis = true
            };

            // Nút xóa file (X)
            Button btnDel = new Button
            {
                Text = "✕",
                Size = new Size(25, 32),
                Dock = DockStyle.Right,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 7F, FontStyle.Bold),
                ForeColor = Color.Gray
            };
            btnDel.FlatAppearance.BorderSize = 0;
            btnDel.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 220, 220);
            btnDel.Click += (s, e) => onRemove();

            chip.Controls.Add(lbl);
            chip.Controls.Add(btnDel);
            return chip;
        }

        /// <summary>
        /// Quét tất cả nút: Bình thường vuông, Hover vào thì bo tròn
        /// </summary>
        public static void TuDongBoGocKhiHover(Control parent, int radius)
        {
            // Duyệt qua tất cả các control trong Form/Panel
            foreach (Control c in parent.Controls)
            {
                // 1. Nếu là Nút (Button)
                if (c is Button btn)
                {
                    // Đảm bảo ban đầu là hình chữ nhật (vuông)
                    btn.Region = null;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0; // Xóa viền đen mặc định cho đẹp

                    // -> Chuột vào: Bo tròn
                    btn.MouseEnter += (s, e) => BoGoc(btn, radius);

                    // -> Chuột ra: Hủy bo tròn (Về lại hình chữ nhật)
                    btn.MouseLeave += (s, e) => btn.Region = null;
                }

                // 2. Nếu là Panel, GroupBox... (vật chứa) -> Gọi đệ quy để tìm nút bên trong
                if (c.HasChildren)
                {
                    TuDongBoGocKhiHover(c, radius);
                }
            }
        }

        public static void BoGocTuyChinh(Control control, int radius, bool tl, bool tr, bool br, bool bl)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2; // Đường kính góc bo

            // 1. Góc Trên-Trái
            if (tl) path.AddArc(0, 0, d, d, 180, 90);
            else path.AddLine(0, 0, 0, 0); // Nhọn

            // 2. Góc Trên-Phải
            if (tr) path.AddArc(control.Width - d, 0, d, d, 270, 90);
            else path.AddLine(control.Width, 0, control.Width, 0); // Nhọn

            // 3. Góc Dưới-Phải
            if (br) path.AddArc(control.Width - d, control.Height - d, d, d, 0, 90);
            else path.AddLine(control.Width, control.Height, control.Width, control.Height); // Nhọn

            // 4. Góc Dưới-Trái
            if (bl) path.AddArc(0, control.Height - d, d, d, 90, 90);
            else path.AddLine(0, control.Height, 0, control.Height); // Nhọn

            path.CloseFigure();
            control.Region = new Region(path);
        }

      
        // Hàm tạo nút công cụ (Icon + Tooltip)
        public static Button CreateToolButton(string icon, string tipText, EventHandler onClick, ToolTip toolTip)
        {
            Button btn = new Button
            {
                Text = icon,
                Size = new Size(28, 24),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.Gray,
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 0, 2, 0),
                Font = new Font("Segoe UI Symbol", 10F, FontStyle.Regular),
                TextAlign = ContentAlignment.TopCenter
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 0, 0, 0);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 0, 0, 0);

            btn.Click += onClick;

            // Gắn tooltip (nếu có truyền vào)
            if (toolTip != null) toolTip.SetToolTip(btn, tipText);

            return btn;
        }
    }
}