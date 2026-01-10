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
            LoadCalendar(_month, _year);
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

            List<TaskItem> dbTasks = DatabaseHelper.GetTasksByMonth(month, year);

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

        public void ShowInfo(int count)
        {
            this.Text = this.FullDate.Split('-')[2] + $"\n📅 {count} việc";
            this.ForeColor = Color.DarkBlue;
            if (!_isToday) this.BackColor = Color.AliceBlue;
        }


    }
}