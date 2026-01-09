using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ChatbotAI_Form
{
    public static class UIHelperThungrac
    {
        // Bo góc đơn giản – chỉ dùng cho Thùng rác
        public static void BoGoc(Control control, int radius)
        {
            if (control == null || control.Width == 0 || control.Height == 0)
                return;

            int d = radius * 2;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, d, d, 180, 90);
            path.AddArc(control.Width - d, 0, d, d, 270, 90);
            path.AddArc(control.Width - d, control.Height - d, d, d, 0, 90);
            path.AddArc(0, control.Height - d, d, d, 90, 90);
            path.CloseFigure();

            control.Region = new Region(path);
        }

        // Viền focus nhẹ kiểu Notion
        public static void VienFocus(
            Panel panel,
            TextBox textBox,
            Color focusColor,
            Color normalColor)
        {
            panel.Paint += (s, e) =>
            {
                Color color = textBox.Focused ? focusColor : normalColor;
                using Pen pen = new Pen(color, 1);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawRectangle(
                    pen,
                    0,
                    0,
                    panel.Width - 1,
                    panel.Height - 1
                );
            };

            textBox.GotFocus += (s, e) => panel.Invalidate();
            textBox.LostFocus += (s, e) => panel.Invalidate();
        }
    }
}
