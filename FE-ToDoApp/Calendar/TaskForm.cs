using System;
using System.Drawing;
using System.Windows.Forms;

namespace FE_ToDoApp.Calendar
{
    public class TaskForm : Form
    {
        private TextBox txtTitle;
        private TextBox txtDesc;
        private DateTimePicker dtpTime;
        private TaskItem _currentTask;
        private DateTime _selectedDate;

        public TaskForm(DateTime date) : this(date, null) { }

        public TaskForm(DateTime date, TaskItem taskToEdit)
        {
            _selectedDate = date;
            _currentTask = taskToEdit;

            bool isEditMode = (_currentTask != null);
            this.Text = isEditMode ? "Cập nhật công việc" : $"Thêm việc mới - {date:dd/MM}";
            this.Size = new Size(400, 350);
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false; this.MinimizeBox = false;

            Label lblTitle = new Label() { Text = "Tiêu đề (*):", Location = new Point(20, 20), AutoSize = true };
            txtTitle = new TextBox() { Location = new Point(20, 45), Width = 340, Text = isEditMode ? _currentTask.Title : "" };

            Label lblTime = new Label() { Text = "Thời gian:", Location = new Point(20, 85), AutoSize = true };
            dtpTime = new DateTimePicker() { Location = new Point(20, 110), Format = DateTimePickerFormat.Time, ShowUpDown = true, Width = 120 };

            dtpTime.Value = isEditMode ? _currentTask.DuaDate : new DateTime(date.Year, date.Month, date.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);

            Label lblDesc = new Label() { Text = "Mô tả:", Location = new Point(20, 150), AutoSize = true };
            txtDesc = new TextBox() { Location = new Point(20, 175), Width = 340, Height = 80, Multiline = true, Text = isEditMode ? _currentTask.Description : "" };

            Button btnSave = new Button()
            {
                Text = isEditMode ? "Cập Nhật" : "Lưu Mới",
                Location = new Point(230, 270),
                Width = 130,
                Height = 35,
                BackColor = isEditMode ? Color.Orange : Color.CornflowerBlue,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSave.Click += BtnSave_Click;

            this.Controls.AddRange(new Control[] { lblTitle, txtTitle, lblTime, dtpTime, lblDesc, txtDesc, btnSave });
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text)) { MessageBox.Show("Nhập tiêu đề!"); return; }

            DateTime newStart = new DateTime(_selectedDate.Year, _selectedDate.Month, _selectedDate.Day, dtpTime.Value.Hour, dtpTime.Value.Minute, 0);

            if (_currentTask == null)
            {
                TaskItem newTask = new TaskItem() { Title = txtTitle.Text, Description = txtDesc.Text, DuaDate = newStart, Status = "New" };
                DatabaseHelper.AddTask(newTask);
            }
            else
            {
                _currentTask.Title = txtTitle.Text;
                _currentTask.Description = txtDesc.Text;
                _currentTask.DuaDate = newStart;
                DatabaseHelper.UpdateTask(_currentTask);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}