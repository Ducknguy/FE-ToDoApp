using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FE_ToDoApp.Calendar
{
    public partial class calendar : Form
    {
        private int _month, _year;
        private Label lblMonthYear;
        private TableLayoutPanel pnlGrid;

        public calendar()
        {
            InitializeComponent();

            this.Text = "Lịch Công Việc";
            this.Size = new Size(1100, 760);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            InitCustomInterface();

            _month = DateTime.Now.Month;
            _year = DateTime.Now.Year;
            LoadCalendar(_month, _year);
        }

        private void InitCustomInterface()
        {
            // 1. Header
            Panel pnlHeader = new Panel();
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 60;
            pnlHeader.BackColor = Color.WhiteSmoke;
            this.Controls.Add(pnlHeader);

            Button btnPrev = CreateNavButton("<", DockStyle.Left);
            btnPrev.Click += (s, e) => ChangeMonth(-1);
            pnlHeader.Controls.Add(btnPrev);

            Button btnNext = CreateNavButton(">", DockStyle.Right);
            btnNext.Click += (s, e) => ChangeMonth(1);
            pnlHeader.Controls.Add(btnNext);

            lblMonthYear = new Label();
            lblMonthYear.Dock = DockStyle.Fill;
            lblMonthYear.TextAlign = ContentAlignment.MiddleCenter;
            lblMonthYear.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblMonthYear.ForeColor = Color.DarkSlateGray;
            pnlHeader.Controls.Add(lblMonthYear);
            lblMonthYear.BringToFront();

            // 2. Spacer
            Panel pnlSpacer = new Panel();
            pnlSpacer.Dock = DockStyle.Top;
            pnlSpacer.Height = 30;
            pnlSpacer.BackColor = Color.White;
            this.Controls.Add(pnlSpacer);
            pnlSpacer.BringToFront();

            // 3. Grid
            pnlGrid = new TableLayoutPanel();
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.ColumnCount = 7;
            pnlGrid.RowCount = 7;
            pnlGrid.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            pnlGrid.Padding = new Padding(20, 0, 20, 20);

            for (int i = 0; i < 7; i++) pnlGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 7));
            pnlGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            for (int i = 0; i < 6; i++) pnlGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 6));

            this.Controls.Add(pnlGrid);
            pnlGrid.BringToFront();

            string[] daysOfWeek = { "Chủ Nhật", "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy" };
            for (int i = 0; i < 7; i++)
            {
                Label lbl = new Label();
                lbl.Text = daysOfWeek[i];
                lbl.Dock = DockStyle.Fill;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                lbl.BackColor = Color.AliceBlue;
                if (i == 0 || i == 6) lbl.ForeColor = Color.Red;
                pnlGrid.Controls.Add(lbl, i, 0);
            }
        }

        private Button CreateNavButton(string text, DockStyle dock)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Dock = dock;
            btn.Width = 60;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Consolas", 15, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            return btn;
        }

        private void LoadCalendar(int month, int year)
        {
            lblMonthYear.Text = $"THÁNG {month} / {year}";

            // Xóa các ô ngày cũ để vẽ lại
            for (int i = pnlGrid.Controls.Count - 1; i >= 7; i--)
            {
                pnlGrid.Controls.RemoveAt(i);
            }

            DateTime firstDay = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int startCol = (int)firstDay.DayOfWeek;

            int row = 1;
            int col = startCol;

            // --- 1. LẤY DỮ LIỆU TỪ SQL ---
            List<TaskItem> dbTasks = DatabaseHelper.GetTasksByMonth(month, year);

            // --- 2. VẼ Ô NGÀY ---
            for (int day = 1; day <= daysInMonth; day++)
            {
                DayCell btnDay = new DayCell(day, month, year);

                if (day == DateTime.Now.Day && month == DateTime.Now.Month && year == DateTime.Now.Year)
                {
                    btnDay.SetToday();
                }

                foreach (var task in dbTasks)
                {
                    if (task.StartDate.Date == DateTime.Parse(btnDay.FullDate).Date)
                    {
                        btnDay.LocalEvents.Add(task);
                    }
                }

                if (btnDay.LocalEvents.Count > 0)
                {
                    btnDay.ShowInfo(btnDay.LocalEvents.Count);
                }

                btnDay.MouseUp += DayCell_MouseUp;

                pnlGrid.Controls.Add(btnDay, col, row);

                col++;
                if (col > 6) { col = 0; row++; }
            }
        }

        private void ChangeMonth(int step)
        {
            _month += step;
            if (_month > 12) { _month = 1; _year++; }
            if (_month < 1) { _month = 12; _year--; }
            LoadCalendar(_month, _year);
        }

        // --- Xử lý click chuột trái-phải ---
        private void DayCell_MouseUp(object sender, MouseEventArgs e)
        {
            DayCell cell = sender as DayCell;
            if (cell == null) return;

            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("➕ Thêm công việc mới", null, (s, ev) =>
                {
                    DateTime selectedDate = DateTime.Parse(cell.FullDate);
                    TaskForm addForm = new TaskForm(selectedDate);

                    if (addForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadCalendar(_month, _year);
                        MessageBox.Show("Đã thêm công việc thành công!");
                    }
                });
                menu.Show(cell, e.Location);
            }
            else if (e.Button == MouseButtons.Left)
            {
                EventDetailsForm detailsForm = new EventDetailsForm(cell.FullDate, cell.LocalEvents);

                detailsForm.ShowDialog();

                LoadCalendar(_month, _year);
            }
        }
    }

    public class DayCell : Button
    {
        public string FullDate { get; private set; }
        public List<TaskItem> LocalEvents { get; set; } = new List<TaskItem>();

        private bool _isToday = false;
        private Color _colorNormal = Color.White;
        private Color _colorHover = Color.LightSkyBlue;
        private Color _colorToday = Color.CornflowerBlue;

        public DayCell(int day, int month, int year)
        {
            this.Text = day.ToString();
            this.FullDate = $"{year}-{month}-{day}";
            this.Dock = DockStyle.Fill;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderColor = Color.Silver;
            this.TextAlign = ContentAlignment.TopLeft;
            this.Padding = new Padding(5);
            this.Font = new Font("Segoe UI", 10);
            this.BackColor = _colorNormal;
            this.Cursor = Cursors.Hand;

            this.MouseEnter += (s, e) => { if (!_isToday) this.BackColor = _colorHover; };
            this.MouseLeave += (s, e) => { if (_isToday) this.BackColor = _colorToday; else this.BackColor = _colorNormal; };
        }

        public void SetToday()
        {
            _isToday = true;
            this.BackColor = _colorToday;
            this.ForeColor = Color.White;
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Text += " (Hôm nay)";
        }

        public void ClearInfo()
        {
            this.Text = this.FullDate.Split('-')[2];
            this.ForeColor = Color.Black;
            if (!_isToday) this.BackColor = _colorNormal;
        }

        public void ShowInfo(int count)
        {
            this.Text = this.FullDate.Split('-')[2] + $"\n📅 {count} việc";
            this.ForeColor = Color.DarkBlue;
            if (!_isToday) this.BackColor = Color.AliceBlue;
        }
    }
}