using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace FE_ToDoApp.Calendar
{
    public partial class EventDetailsForm : Form
    {
        private FlowLayoutPanel panelList;
        private DateTime _currentDate;

        public EventDetailsForm(string dateString, List<TaskItem> events)
        {
            _currentDate = DateTime.Parse(dateString);

            this.Text = "Chi tiết công việc";
            this.Size = new Size(480, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Panel pnlHeader = new Panel() { Dock = DockStyle.Top, Height = 60, BackColor = Color.WhiteSmoke };

            Label lblTitle = new Label()
            {
                Text = $"{_currentDate:dd/MM/yyyy}",
                Location = new Point(10, 15),
                AutoSize = true,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.DarkSlateBlue
            };

            pnlHeader.Controls.Add(lblTitle);
            this.Controls.Add(pnlHeader);

            panelList = new FlowLayoutPanel();
            panelList.Dock = DockStyle.Fill;
            panelList.AutoScroll = true;
            panelList.Padding = new Padding(10);
            panelList.BackColor = Color.White;
            this.Controls.Add(panelList);
            panelList.BringToFront();

            LoadEvents(events);
        }

        private void LoadEvents(List<TaskItem> events)
        {
            panelList.Controls.Clear();

            var todayEvents = events.Where(t => t.StartDate.Date == _currentDate.Date)
                                   .OrderBy(t => t.ReminderTime ?? t.StartDate)
                                   .ToList();

            if (todayEvents.Count == 0)
            {
                Label lblEmpty = new Label();
                lblEmpty.Text = "Không có công việc nào trong ngày này.";
                lblEmpty.AutoSize = true;
                lblEmpty.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                lblEmpty.ForeColor = Color.Gray;
                lblEmpty.Padding = new Padding(20);
                panelList.Controls.Add(lblEmpty);
                return;
            }

            foreach (var task in todayEvents)
            {
                panelList.Controls.Add(CreateTaskItem(task));
            }
        }

        private Panel CreateTaskItem(TaskItem task)
        {
            Panel pnl = new Panel();
            pnl.Width = 430;
            pnl.Height = 90;
            pnl.Margin = new Padding(0, 0, 0, 10);
            pnl.BackColor = Color.AliceBlue;
            pnl.BorderStyle = BorderStyle.FixedSingle;

            string timeText;
            if (task.ReminderTime.HasValue)
            {
                timeText = task.ReminderTime.Value.ToString("HH:mm");
            }
            else if (task.StartDate.TimeOfDay.TotalSeconds > 0)
            {
                timeText = task.StartDate.ToString("HH:mm");
            }
            else
            {
                timeText = "--:--";
            }

            Label lblTime = new Label()
            {
                Text = timeText,
                Location = new Point(10, 10),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Teal,
                AutoSize = true
            };

            Label lblSummary = new Label()
            {
                Text = task.Title,
                Location = new Point(80, 10),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Black,
                Width = 330
            };

            Label lblDesc = new Label()
            {
                Text = task.Description,
                Location = new Point(80, 40),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.DimGray,
                Width = 330,
                Height = 40
            };

            pnl.Controls.AddRange(new Control[] { lblTime, lblSummary, lblDesc });
            return pnl;
        }
    }
}
