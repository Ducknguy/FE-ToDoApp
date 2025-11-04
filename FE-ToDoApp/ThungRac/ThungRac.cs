using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FE_ToDoApp.NewFolder
{
    public partial class ThungRac : Form
    {
        public ThungRac()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ThungRac_Load(object sender, EventArgs e)
        {
            Button[] buttons = { btnChinhSuaGanNhat, btnTrong, btnKhongGianNhom };

            foreach (Button btn in buttons)
            {
                int cornerRadius = 15;
                GraphicsPath path = new GraphicsPath();
                Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);
                int d = cornerRadius * 2;

                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseAllFigures();

                btn.Region = new Region(path);
            }
        }
    }
}
