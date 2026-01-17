using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; // Cần thêm thư viện này để chạy Async

namespace FE_ToDoApp.Calendar
{
    public partial class calendar : Form
    {
        private int _month, _year;

        // CACHE: Lưu trữ dữ liệu các tháng đã tải. Key là chuỗi "tháng-năm" (VD: "1-2026")
        private Dictionary<string, List<TaskItem>> _dataCache = new Dictionary<string, List<TaskItem>>();

        // Biến tạm để giữ list task đang hiển thị
        private List<TaskItem> _currentMonthTasks;

        public calendar()
        {
            InitializeComponent();
            _month = DateTime.Now.Month;
            _year = DateTime.Now.Year;

            // Gọi hàm LoadCalendar (vì là async nên không cần await ở constructor)
            LoadCalendar(_month, _year);
        }

        // Đổi thành 'async void' để chạy bất đồng bộ
        private async void LoadCalendar(int month, int year)
        {
            lblMonthYear.Text = $"THÁNG {month} / {year}";

            // 1. Tính toán logic ngày tháng (Phần này tính nhanh, không cần Async)
            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);

            // Logic Thứ Hai = 0
            int startCol = ((int)firstDayOfMonth.DayOfWeek + 6) % 7;

            // 2. Xử lý dữ liệu (Phần này nặng, cần tối ưu)
            string cacheKey = $"{month}-{year}";

            if (_dataCache.ContainsKey(cacheKey))
            {
                // TRƯỜNG HỢP 1: Đã có trong Cache -> Lấy ra dùng luôn (Siêu nhanh)
                _currentMonthTasks = _dataCache[cacheKey];
            }
            else
            {
                // TRƯỜNG HỢP 2: Chưa có -> Tải từ Database (Chạy ngầm để không đơ UI)
                // Hiển thị trạng thái đang tải (nếu cần)
                this.Cursor = Cursors.WaitCursor;

                // Chạy hàm GetTasksByMonth trong luồng riêng
                _currentMonthTasks = await Task.Run(() => DatabaseHelper.GetTasksByMonth(month, year));

                // Lưu vào cache để lần sau dùng lại
                _dataCache[cacheKey] = _currentMonthTasks;

                this.Cursor = Cursors.Default;
            }

            // 3. Vẽ lên giao diện (Suspend để tránh giật khi vẽ nhiều ô)
            pnlGrid.SuspendLayout();

            for (int i = 0; i < 42; i++)
            {
                // Kiểm tra an toàn cho mảng
                if (matrixDays == null || i >= matrixDays.Length) break;

                DayCell cell = matrixDays[i];
                cell.Clear(); // Xóa dữ liệu cũ

                int dayVal = i - startCol + 1;

                if (dayVal > 0 && dayVal <= daysInMonth)
                {
                    cell.SetDate(dayVal, month, year);

                    // Highlight ngày hôm nay
                    if (dayVal == DateTime.Now.Day && month == DateTime.Now.Month && year == DateTime.Now.Year)
                    {
                        cell.SetToday();
                    }

                    // Hiển thị công việc
                    if (_currentMonthTasks != null)
                    {
                        // Đếm số việc trong ngày
                        int taskCount = _currentMonthTasks.Count(t => t.StartDate.Date == new DateTime(year, month, dayVal).Date);
                        if (taskCount > 0)
                        {
                            cell.ShowInfo(taskCount);
                        }
                    }
                }
            }
            pnlGrid.ResumeLayout();
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            _month--;
            if (_month < 1) { _month = 12; _year--; }
            LoadCalendar(_month, _year);
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            _month++;
            if (_month > 12) { _month = 1; _year++; }
            LoadCalendar(_month, _year);
        }

        private void LblMonthYear_Click(object sender, EventArgs e)
        {
            using (GotoDateForm gotoForm = new GotoDateForm(_month, _year))
            {
                if (gotoForm.ShowDialog() == DialogResult.OK)
                {
                    _month = gotoForm.SelectedMonth;
                    _year = gotoForm.SelectedYear;
                    LoadCalendar(_month, _year);
                }
            }
        }

        private void DayCell_MouseUp(object sender, MouseEventArgs e)
        {
            DayCell cell = sender as DayCell;
            if (cell == null || string.IsNullOrEmpty(cell.FullDate)) return;

            // Mở form chi tiết
            using (EventDetailsForm detailsForm = new EventDetailsForm(cell.FullDate, _currentMonthTasks))
            {
                DialogResult result = detailsForm.ShowDialog();

                // QUAN TRỌNG: Nếu người dùng Thêm/Sửa/Xóa việc -> Dữ liệu cũ bị sai
                // Cần xóa Cache của tháng hiện tại để nó tải lại dữ liệu mới nhất

                // Giả sử form trả về OK nếu có thay đổi (Hoặc bạn cứ reload cho chắc)
                // if (result == DialogResult.OK) 
                {
                    string currentKey = $"{_month}-{_year}";
                    if (_dataCache.ContainsKey(currentKey))
                    {
                        _dataCache.Remove(currentKey); // Xóa cache cũ đi
                    }
                    LoadCalendar(_month, _year); // Tải lại để cập nhật thay đổi
                }
            }
        }
    }

    // Class DayCell giữ nguyên như cũ (tôi lược bỏ bớt để code gọn, bạn giữ nguyên code DayCell của bạn)
    public class DayCell : Label
    {
        public string FullDate { get; set; }
        private bool _isToday = false;

        public DayCell()
        {
            this.AutoSize = false;
            this.Dock = DockStyle.Fill;
            this.TextAlign = ContentAlignment.TopLeft;
            this.Padding = new Padding(5);
            this.Margin = new Padding(1);
            this.Font = new Font("Segoe UI", 10);
            this.BackColor = Color.White;
            this.Cursor = Cursors.Hand;
            this.BorderStyle = BorderStyle.FixedSingle;

            this.MouseEnter += (s, e) => { if (!_isToday && !string.IsNullOrEmpty(FullDate)) this.BackColor = Color.AliceBlue; };
            this.MouseLeave += (s, e) => { if (_isToday) this.BackColor = Color.OrangeRed; else this.BackColor = Color.White; };
        }

        public void Clear()
        {
            this.Text = "";
            this.FullDate = "";
            this._isToday = false;
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Font = new Font("Segoe UI", 10);
            this.Visible = false;
        }

        public void SetDate(int day, int month, int year)
        {
            this.Visible = true;
            this.Text = day.ToString();
            this.FullDate = $"{year}-{month:D2}-{day:D2}";
        }

        public void SetToday()
        {
            _isToday = true;
            this.BackColor = Color.OrangeRed;
            this.ForeColor = Color.White;
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Text += " (Hôm nay)";
        }

        public void ShowInfo(int count)
        {
            this.Text += $"\n\n📌 {count} việc";
            if (!_isToday) this.ForeColor = Color.Blue;
        }
    }
}