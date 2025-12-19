using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Google.Apis.Calendar.v3.Data;

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

            for (int i = pnlGrid.Controls.Count - 1; i >= 7; i--)
            {
                pnlGrid.Controls.RemoveAt(i);
            }

            DateTime firstDay = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int startCol = (int)firstDay.DayOfWeek;

            int row = 1;
            int col = startCol;

            for (int day = 1; day <= daysInMonth; day++)
            {
                DayCell btnDay = new DayCell(day, month, year);

                if (day == DateTime.Now.Day && month == DateTime.Now.Month && year == DateTime.Now.Year)
                {
                    btnDay.SetToday();
                }

                btnDay.MouseUp += DayCell_MouseUp;
                pnlGrid.Controls.Add(btnDay, col, row);

                col++;
                if (col > 6) { col = 0; row++; }
            }

            // Gọi hàm lấy dữ liệu
            SyncGoogleEvents();
        }

        private async void SyncGoogleEvents()
        {
            string oldTitle = this.Text;
            this.Text = oldTitle + " (Đang tải lịch Google...)";

            var events = await GoogleHelper.LaySuKienTrongThang(_month, _year);

            if (events == null)
            {
                this.Text = oldTitle;
                return;
            }

            foreach (Control c in pnlGrid.Controls)
            {
                if (c is DayCell cell)
                {
                    DateTime cellDate = DateTime.Parse(cell.FullDate);

                    // --- ĐOẠN NÀY ĐÃ ĐƯỢC NÂNG CẤP ---
                    // Thay vì chỉ đếm, ta lọc và thêm hẳn sự kiện vào list của ô ngày
                    foreach (var evt in events)
                    {
                        bool match = false;
                        if (evt.Start.DateTime.HasValue)
                        {
                            if (evt.Start.DateTime.Value.Date == cellDate.Date) match = true;
                        }
                        else if (evt.Start.Date != null)
                        {
                            if (DateTime.Parse(evt.Start.Date) == cellDate) match = true;
                        }

                        if (match)
                        {
                            cell.GoogleEvents.Add(evt); // Lưu sự kiện vào ô
                        }
                    }

                    // Nếu list có dữ liệu thì hiện số lượng
                    if (cell.GoogleEvents.Count > 0)
                    {
                        cell.ShowGoogleInfo(cell.GoogleEvents.Count);
                    }
                }
            }

            this.Text = oldTitle;
        }

        private void ChangeMonth(int step)
        {
            _month += step;
            if (_month > 12) { _month = 1; _year++; }
            if (_month < 1) { _month = 12; _year--; }
            LoadCalendar(_month, _year);
        }

        // --- XỬ LÝ CLICK ---
        private void DayCell_MouseUp(object sender, MouseEventArgs e)
        {
            DayCell cell = sender as DayCell;
            if (cell == null) return;

            // 1. Chuột Phải -> Hiện Menu Thêm/Sửa/Xóa (Giữ nguyên)
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("➕ Thêm công việc mới", null, (s, ev) => MessageBox.Show($"Thêm: {cell.FullDate}"));
                menu.Show(cell, e.Location);
            }
            // 2. Chuột Trái -> Xem chi tiết (MỚI)
            else if (e.Button == MouseButtons.Left)
            {
                // Chỉ mở form nếu ngày đó có sự kiện Google
                if (cell.GoogleEvents.Count > 0)
                {
                    EventDetailsForm detailsForm = new EventDetailsForm(cell.FullDate, cell.GoogleEvents);
                    detailsForm.ShowDialog(); // Hiện form popup
                }
                else
                {
                    // Nếu không có việc, có thể không làm gì hoặc hiện thông báo
                    // MessageBox.Show("Ngày này không có sự kiện nào.");
                }
            }
        }
    }

    // --- CLASS DAYCELL (ĐÃ NÂNG CẤP) ---
    public class DayCell : Button
    {
        public string FullDate { get; private set; }
        // Biến này để lưu danh sách sự kiện thật
        public List<Event> GoogleEvents { get; set; } = new List<Event>();

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

        public void ShowGoogleInfo(int count)
        {
            this.Text = this.Text.Split('\n')[0] + $"\n📅 {count} việc";
            this.ForeColor = Color.DarkBlue;
            if (!_isToday) this.BackColor = Color.AliceBlue;
        }
    }
}