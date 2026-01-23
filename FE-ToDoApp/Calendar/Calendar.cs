using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE_ToDoApp.Calendar
{
    public partial class calendar : Form
    {
        private int _month, _year;

        private Dictionary<string, List<TaskItem>> _dataCache = new Dictionary<string, List<TaskItem>>();

        private List<TaskItem> _currentMonthTasks;

        public calendar()
        {
            InitializeComponent();

            InitializeWeekHeader();
            InitializeDayCells();

            _month = DateTime.Now.Month;
            _year = DateTime.Now.Year;

            LoadCalendar(_month, _year);
        }

        private void InitializeWeekHeader()
        {
            string[] days = { "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy", "Chủ Nhật" };
            for (int i = 0; i < 7; i++)
            {
                System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
                lbl.Text = days[i];
                lbl.Dock = System.Windows.Forms.DockStyle.Fill;
                lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                lbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
                lbl.ForeColor = System.Drawing.Color.DarkSlateGray;

                if (i == 6) lbl.ForeColor = System.Drawing.Color.Red;

                this.tlpWeekHeader.Controls.Add(lbl, i, 0);
            }
        }

        private void InitializeDayCells()
        {
            this.matrixDays = new DayCell[42];
            for (int i = 0; i < 42; i++)
            {
                this.matrixDays[i] = new DayCell();
                this.matrixDays[i].MouseUp += new System.Windows.Forms.MouseEventHandler(this.DayCell_MouseUp);

                int col = i % 7;
                int row = i / 7;
                this.pnlGrid.Controls.Add(this.matrixDays[i], col, row);
            }
        }

        private async void LoadCalendar(int month, int year)
        {
            lblMonthYear.Text = $"THÁNG {month} / {year}";

            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);

            int startCol = ((int)firstDayOfMonth.DayOfWeek + 6) % 7;

            string cacheKey = $"{month}-{year}";

            if (_dataCache.ContainsKey(cacheKey))
            {
                _currentMonthTasks = _dataCache[cacheKey];
            }
            else
            {
              
                this.Cursor = Cursors.WaitCursor;

                _currentMonthTasks = await Task.Run(() => DatabaseHelper.GetTasksByMonth(month, year));
                _dataCache[cacheKey] = _currentMonthTasks;

                this.Cursor = Cursors.Default;
            }

            pnlGrid.SuspendLayout();

            for (int i = 0; i < 42; i++)
            {
                if (matrixDays == null || i >= matrixDays.Length) break;

                DayCell cell = matrixDays[i];
                cell.Clear(); 

                int dayVal = i - startCol + 1;

                if (dayVal > 0 && dayVal <= daysInMonth)
                {
                    cell.SetDate(dayVal, month, year);

                    if (dayVal == DateTime.Now.Day && month == DateTime.Now.Month && year == DateTime.Now.Year)
                    {
                        cell.SetToday();
                    }

                    if (_currentMonthTasks != null)
                    {
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

            using (EventDetailsForm detailsForm = new EventDetailsForm(cell.FullDate, _currentMonthTasks))
            {
                DialogResult result = detailsForm.ShowDialog();

                
                // if (result == DialogResult.OK) 
                {
                    string currentKey = $"{_month}-{_year}";
                    if (_dataCache.ContainsKey(currentKey))
                    {
                        _dataCache.Remove(currentKey); 
                    }
                }
            }
        }
    }

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
