using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FE_ToDoApp.Calendar
{
    public partial class calendar : Form
    {
        private int _month, _year;

        public calendar()
        {
            InitCustomInterface();

            _month = DateTime.Now.Month;
            _year = DateTime.Now.Year;

            lblMonthYear.Click += LblMonthYear_Click;

            LoadCalendar(_month, _year);
        }

        private void LoadCalendar(int month, int year)
        {
            lblMonthYear.Text = $"THÁNG {month} / {year}";

            pnlGrid.SuspendLayout();

            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int startCol = (int)firstDayOfMonth.DayOfWeek;

            List<TaskItem> dbTasks = DatabaseHelper.GetTasksByMonth(month, year);

            for (int i = 0; i < 42; i++)
            {
                DayCell cell = matrixDays[i];
                cell.Clear();

                int dayVal = i - startCol + 1;

                if (dayVal > 0 && dayVal <= daysInMonth)
                {
                    cell.Visible = true;
                    cell.SetDate(dayVal, month, year);

                    if (dayVal == DateTime.Now.Day && month == DateTime.Now.Month && year == DateTime.Now.Year)
                    {
                        cell.SetToday();
                    }

                    foreach (var task in dbTasks)
                    {
                        if (task.StartDate.Date == DateTime.Parse(cell.FullDate).Date)
                        {
                            cell.LocalEvents.Add(task);
                        }
                    }

                    if (cell.LocalEvents.Count > 0)
                    {
                        cell.ShowInfo(cell.LocalEvents.Count);
                    }
                }
                else
                {
                    cell.Visible = false;
                }
            }

            pnlGrid.ResumeLayout();
        }

        private void ChangeMonth(int step)
        {
            _month += step;
            if (_month > 12) { _month = 1; _year++; }
            if (_month < 1) { _month = 12; _year--; }
            LoadCalendar(_month, _year);
        }

        private void LblMonthYear_Click(object sender, EventArgs e)
        {
            GotoDateForm frm = new GotoDateForm(_month, _year);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _month = frm.SelectedMonth;
                _year = frm.SelectedYear;
                LoadCalendar(_month, _year);
            }
        }

        private void DayCell_MouseUp(object sender, MouseEventArgs e)
        {
            DayCell cell = sender as DayCell;
            if (cell == null || string.IsNullOrEmpty(cell.FullDate)) return;

            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("➕ Thêm công việc mới", null, (s, ev) =>
                {
                    DateTime selectedDate = DateTime.Parse(cell.FullDate);
                    TaskForm addForm = new TaskForm(selectedDate);

                    if (addForm.ShowDialog() == DialogResult.OK)
                    {
                        if (addForm.CreatedTask != null && addForm.CreatedTask.Id != -1)
                        {
                            cell.LocalEvents.Add(addForm.CreatedTask);
                            cell.ShowInfo(cell.LocalEvents.Count);
                        }
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

        public DayCell()
        {
            this.Dock = DockStyle.Fill;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderColor = Color.Silver;
            this.TextAlign = ContentAlignment.TopLeft;
            this.Padding = new Padding(5);
            this.Font = new Font("Segoe UI", 10);
            this.BackColor = _colorNormal;
            this.Cursor = Cursors.Hand;

            this.MouseEnter += (s, e) => { if (!_isToday && this.Visible) this.BackColor = _colorHover; };
            this.MouseLeave += (s, e) => { if (_isToday && this.Visible) this.BackColor = _colorToday; else this.BackColor = _colorNormal; };
        }

        public void Clear()
        {
            this.Text = "";
            this.FullDate = "";
            this.LocalEvents.Clear();
            this._isToday = false;
            this.BackColor = _colorNormal;
            this.ForeColor = Color.Black;
            this.Font = new Font("Segoe UI", 10);
        }

        public void SetDate(int day, int month, int year)
        {
            this.Text = day.ToString();
            this.FullDate = $"{year}-{month}-{day}";
        }

        public void SetToday()
        {
            _isToday = true;
            this.BackColor = _colorToday;
            this.ForeColor = Color.White;
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Text += " (Hôm nay)";
        }

        public void ShowInfo(int count)
        {
            string dayPart = this.FullDate.Split('-')[2];
            this.Text = dayPart + $"\n📅 {count} việc";

            if (!_isToday)
            {
                this.ForeColor = Color.DarkBlue;
                this.BackColor = Color.AliceBlue;
            }
        }
    }
}