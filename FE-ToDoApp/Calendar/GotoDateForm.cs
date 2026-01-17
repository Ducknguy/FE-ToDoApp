using System;
using System.Drawing;
using System.Windows.Forms;

namespace FE_ToDoApp.Calendar
{
    public class GotoDateForm : Form
    {
        public int SelectedMonth { get; private set; }
        public int SelectedYear { get; private set; }

        private ComboBox cboMonth;
        private ComboBox cboYear;

        public GotoDateForm(int currentMonth, int currentYear)
        {
            this.Text = "Đi tới ngày...";
            this.Size = new Size(300, 220);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;

            Label lblMonth = new Label() { Text = "Chọn Tháng:", Location = new Point(30, 20), AutoSize = true };
            cboMonth = new ComboBox() { Location = new Point(30, 45), Width = 220, DropDownStyle = ComboBoxStyle.DropDownList };
            for (int i = 1; i <= 12; i++) cboMonth.Items.Add("Tháng " + i);
            cboMonth.SelectedIndex = currentMonth - 1;

            Label lblYear = new Label() { Text = "Chọn Năm:", Location = new Point(30, 85), AutoSize = true };
            cboYear = new ComboBox() { Location = new Point(30, 110), Width = 220, DropDownStyle = ComboBoxStyle.DropDownList };

            int startYear = DateTime.Now.Year - 10;
            for (int i = 0; i < 20; i++)
            {
                int y = startYear + i;
                cboYear.Items.Add(y);
                if (y == currentYear) cboYear.SelectedIndex = i;
            }

            Button btnOK = new Button()
            {
                Text = "Xác nhận",
                Location = new Point(80, 150),
                Width = 120,
                Height = 30,
                BackColor = Color.CornflowerBlue,
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.OK
            };
            btnOK.Click += (s, e) => {
                SelectedMonth = cboMonth.SelectedIndex + 1;
                SelectedYear = (int)cboYear.SelectedItem;
            };

            this.Controls.AddRange(new Control[] { lblMonth, cboMonth, lblYear, cboYear, btnOK });
        }
    }
}