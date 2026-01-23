using System;
using System.Drawing;
using System.Windows.Forms;
using FE_ToDoApp.Services;

namespace FE_ToDoApp.WeekList
{
    public partial class TaskEditDialog
    {
        private CheckBox chkReminder;
        private DateTimePicker dtpReminderTime;
        private Label lblReminderInfo;

        private void InitializeReminderControls()
        {
            this.Height = 280;

            chkReminder = new CheckBox
            {
                Text = "Nhắc nhở",
                Location = new Point(20, 100),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 10F)
            };
            chkReminder.CheckedChanged += ChkReminder_CheckedChanged;
            this.Controls.Add(chkReminder);

            // Label hiển thị thông tin ngày
            lblReminderInfo = new Label
            {
                Location = new Point(110, 105),
                Size = new Size(250, 25),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.Gray,
                Text = "",
                Visible = false
            };
            this.Controls.Add(lblReminderInfo);

            // Chỉ hiển thị picker cho giờ
            dtpReminderTime = new DateTimePicker
            {
                Location = new Point(110, 135),
                Size = new Size(120, 27),
                Format = DateTimePickerFormat.Time,
                ShowUpDown = true,
                Enabled = false
            };
            this.Controls.Add(dtpReminderTime);

            btnOK.Location = new Point(170, 180);
            btnCancel.Location = new Point(270, 180);

            // Load reminder hiện tại nếu đang edit
            if (TaskId.HasValue && TaskId.Value > 0)
            {
                var currentReminder = NotificationService.GetWeekTaskReminder(TaskId.Value);
                if (currentReminder.HasValue)
                {
                    chkReminder.Checked = true;
                    dtpReminderTime.Value = currentReminder.Value;
                }
                else
                {
                    SetDefaultReminderTime();
                }
            }
            else
            {
                SetDefaultReminderTime();
            }

            // Cập nhật label hiển thị ngày
            UpdateReminderDateLabel();
        }

        private void SetDefaultReminderTime()
        {
            dtpReminderTime.Value = DateTime.Now.Date.AddHours(9);
        }

        private void ChkReminder_CheckedChanged(object sender, EventArgs e)
        {
            dtpReminderTime.Enabled = chkReminder.Checked;
            lblReminderInfo.Visible = chkReminder.Checked;
            UpdateReminderDateLabel();
        }

        private void UpdateReminderDateLabel()
        {
            if (chkReminder.Checked)
            {
                // Lấy ngày từ StartDate (từ DayOfWeek)
                DateTime taskDate = GetTaskDate();
                lblReminderInfo.Text = $"Nhắc vào: {taskDate:dd/MM/yyyy}";
            }
        }

        private DateTime GetTaskDate()
        {
            // Nếu đang edit task, lấy ngày từ StartDate hiện tại
            if (TaskId.HasValue && TaskId.Value > 0)
            {
                var taskRepo = new Data.WeekTaskRepository();
                var task = taskRepo.GetById(TaskId.Value);
                if (task != null)
                {
                    return task.StartDate.Date;
                }
            }

            // Nếu là task mới, tạm thời lấy ngày hôm nay + DayOfWeek
            // (Lưu ý: logic này có thể cần điều chỉnh tùy context)
            int currentDayOfWeek = (int)DateTime.Now.DayOfWeek;
            if (currentDayOfWeek == 0) currentDayOfWeek = 7; // Chuyển Sunday từ 0 thành 7
            
            int selectedDay = cboDayOfWeek.SelectedIndex + 1;
            int daysToAdd = selectedDay - currentDayOfWeek;
            
            if (daysToAdd < 0) daysToAdd += 7; // Nếu đã qua thì lấy tuần sau
            
            return DateTime.Now.Date.AddDays(daysToAdd);
        }

        private void ProcessReminder()
        {
            if (chkReminder.Checked)
            {
                DateTime taskDate = GetTaskDate();
                
                var reminderDateTime = new DateTime(
                    taskDate.Year,
                    taskDate.Month,
                    taskDate.Day,
                    dtpReminderTime.Value.Hour,
                    dtpReminderTime.Value.Minute,
                    0
                );

                if (reminderDateTime <= DateTime.Now)
                {
                    MessageBox.Show("Thời gian nhắc nhở phải lớn hơn thời gian hiện tại!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                ReminderTime = reminderDateTime;
            }
            else
            {
                ReminderTime = null;
            }
        }
    }
}
