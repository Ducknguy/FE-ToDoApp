using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FE_ToDoApp.WeekList.Controllers;
using FE_ToDoApp.WeekList.Models;

namespace FE_ToDoApp.WeekList.Views
{
    public partial class WeekItemsControl : UserControl
    {
        public string ConnectionString { get; set; }
        public int CategoryId { get; private set; } = -1;
        public DateTime CurrentWeekStart { get; private set; }

        public event EventHandler? TaskChanged;

        private WeekTaskController _taskController;
        private List<WeekTask> _allTasks = new List<WeekTask>();
        private CheckBox? _selectedCheckBox;

        public WeekItemsControl()
        {
            InitializeComponent();
        }
        public void Initialize(string connectionString)
        {
            ConnectionString = connectionString;
            _taskController = new WeekTaskController(connectionString);
        }
        public void LoadWeekItems(int categoryId, DateTime weekStart)
        {
            MessageBox.Show($"LoadWeekItems được gọi!\nCategoryId: {categoryId}\nWeekStart: {weekStart:yyyy-MM-dd}", 
                "DEBUG", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CategoryId = categoryId;
            CurrentWeekStart = GetMonday(weekStart);

            if (CategoryId <= 0)
            {
                MessageBox.Show("CategoryId <= 0, clearing all days", "DEBUG");
                ClearAllDays();
                return;
            }

            try
            {
                _allTasks = _taskController.GetTasksByCategory(CategoryId, CurrentWeekStart);

                MessageBox.Show($"Đã load {_allTasks.Count} tasks từ DB", "DEBUG");

                RenderWeek();

                MessageBox.Show($"Đã gọi RenderWeek() xong!\nControls trong flowLayoutPanel2: {flowLayoutPanel2.Controls.Count}", 
                    "DEBUG");
                    
                // Force hi?n th?
                flowLayoutPanel2.Visible = true;
                flowLayoutPanel2.BringToFront();
                this.Visible = true;
                this.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load dữ liệu: {ex.Message}\n\nStack trace: {ex.StackTrace}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     
        private void RenderWeek()
        {
            var grouped = _allTasks
                .GroupBy(t => t.DayOfWeek)
                .ToDictionary(g => g.Key, g => g.ToList());

            // Render cho c? 7 ngày
            ClearAndRenderDay(panel5, grouped.ContainsKey(1) ? grouped[1] : new List<WeekTask>());  
            ClearAndRenderDay(panel7, grouped.ContainsKey(2) ? grouped[2] : new List<WeekTask>());   
            ClearAndRenderDay(panel9, grouped.ContainsKey(3) ? grouped[3] : new List<WeekTask>());   
            ClearAndRenderDay(panel11, grouped.ContainsKey(4) ? grouped[4] : new List<WeekTask>()); 
            ClearAndRenderDay(panel15, grouped.ContainsKey(5) ? grouped[5] : new List<WeekTask>()); 
            ClearAndRenderDay(panel17, grouped.ContainsKey(6) ? grouped[6] : new List<WeekTask>()); 
            ClearAndRenderDay(panel19, grouped.ContainsKey(7) ? grouped[7] : new List<WeekTask>()); 
        }

   
        private void ClearAndRenderDay(Panel dayPanel, List<WeekTask> tasks)
        {
            if (dayPanel == null) return;

            var toRemove = dayPanel.Controls.OfType<CheckBox>().ToList();
            foreach (var chk in toRemove)
            {
                dayPanel.Controls.Remove(chk);
                chk.Dispose();
            }

            int yPos = 70;
            foreach (var task in tasks)
            {
                var chk = new CheckBox
                {
                    Text = task.Title,
                    Checked = task.IsDone,
                    AutoSize = true,
                    Location = new Point(24, yPos),
                    Font = new Font("Segoe UI", 10F),
                    Tag = task.TaskId
                };

                chk.CheckedChanged += Chk_CheckedChanged;
                chk.Click += Chk_Click;
                chk.DoubleClick += Chk_DoubleClick;

                dayPanel.Controls.Add(chk);
                yPos += 30;
            }
        }
        private void ClearAllDays()
        {
            ClearAndRenderDay(panel5, new List<WeekTask>());
            ClearAndRenderDay(panel7, new List<WeekTask>());
            ClearAndRenderDay(panel9, new List<WeekTask>());
            ClearAndRenderDay(panel11, new List<WeekTask>());
            ClearAndRenderDay(panel15, new List<WeekTask>());
            ClearAndRenderDay(panel17, new List<WeekTask>());
            ClearAndRenderDay(panel19, new List<WeekTask>());
        }
        private void Chk_Click(object sender, EventArgs e)
        {
            _selectedCheckBox = sender as CheckBox;
        }

        private void Chk_DoubleClick(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            if (chk != null)
            {
                _selectedCheckBox = chk;
                EditTask();
            }
        }

        private void Chk_CheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            if (chk == null || chk.Tag == null) return;

            int taskId = (int)chk.Tag;
            bool newValue = chk.Checked;

            chk.Enabled = false;

            try
            {
                _taskController.ToggleTaskStatus(taskId, newValue);

                // Update local list
                var task = _allTasks.FirstOrDefault(t => t.TaskId == taskId);
                if (task != null) task.IsDone = newValue;

                TaskChanged?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                chk.Checked = !newValue;
            }
            finally
            {
                chk.Enabled = true;
            }
        }

        public void AddTask(int dayOfWeek = 1)
        {
            if (CategoryId <= 0)
            {
                MessageBox.Show("Vui lòng chọn category trướqc!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialog = new TaskEditDialog("", dayOfWeek);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int newTaskId = _taskController.AddTask(
                        CategoryId, 
                        CurrentWeekStart, 
                        dialog.DayOfWeek, 
                        dialog.TaskTitle);

    
                    _allTasks.Add(new WeekTask
                    {
                        TaskId = newTaskId,
                        CategoryId = CategoryId,
                        DayOfWeek = dialog.DayOfWeek,
                        Title = dialog.TaskTitle,
                        IsDone = false,
                        OrderIndex = 0
                    });

                    RenderWeek();
                    TaskChanged?.Invoke(this, EventArgs.Empty);

                    MessageBox.Show("Thêm task thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void EditTask()
        {
            if (_selectedCheckBox == null || _selectedCheckBox.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn task cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int taskId = (int)_selectedCheckBox.Tag;
                var task = _allTasks.FirstOrDefault(t => t.TaskId == taskId);
                if (task == null) return;

                var dialog = new TaskEditDialog(task.Title, task.DayOfWeek);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _taskController.UpdateTask(taskId, dialog.TaskTitle, dialog.DayOfWeek);

                    task.Title = dialog.TaskTitle;
                    task.DayOfWeek = dialog.DayOfWeek;

                    RenderWeek();
                    TaskChanged?.Invoke(this, EventArgs.Empty);

                    MessageBox.Show("Cập nhật task thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteTask()
        {
            if (_selectedCheckBox == null || _selectedCheckBox.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn task cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int taskId = (int)_selectedCheckBox.Tag;
                var task = _allTasks.FirstOrDefault(t => t.TaskId == taskId);
                if (task == null) return;

                var result = MessageBox.Show(
                    $"Bạn có chắc muốn xóa task '{task.Title}'?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _taskController.DeleteTask(taskId);
                    
                    _allTasks.Remove(task);

                    RenderWeek();
                    _selectedCheckBox = null;
                    TaskChanged?.Invoke(this, EventArgs.Empty);

                    MessageBox.Show("Xóa task thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

 
        private DateTime GetMonday(DateTime date)
        {
            int daysFromMonday = ((int)date.DayOfWeek - 1 + 7) % 7;
            return date.Date.AddDays(-daysFromMonday);
        }
    }
}
