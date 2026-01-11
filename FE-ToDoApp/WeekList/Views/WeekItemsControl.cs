using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FE_ToDoApp.WeekList.Controllers;
using FE_ToDoApp.WeekList.Models;

namespace FE_ToDoApp.WeekList.Views
{
    /// <summary>
    /// UserControl hi?n th? tasks c?a 1 category trong tu?n (7 ngày)
    /// Gi?ng TodoDetailItemControl trong Lich Trinh
    /// </summary>
    public partial class WeekItemsControl : UserControl
    {
        // ===== PUBLIC =====
        public string ConnectionString { get; set; }
        public int CategoryId { get; private set; } = -1;
        public DateTime CurrentWeekStart { get; private set; }

        public event EventHandler? TaskChanged;

        // ===== CONTROLLERS =====
        private WeekTaskController _taskController;

        // ===== STATE =====
        private List<WeekTask> _allTasks = new List<WeekTask>();
        private CheckBox? _selectedCheckBox;

        public WeekItemsControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Kh?i t?o controller v?i connection string
        /// </summary>
        public void Initialize(string connectionString)
        {
            ConnectionString = connectionString;
            _taskController = new WeekTaskController(connectionString);
        }

        /// <summary>
        /// Load tasks c?a 1 category trong tu?n
        /// </summary>
        public void LoadWeekItems(int categoryId, DateTime weekStart)
        {
            MessageBox.Show($"LoadWeekItems ???c g?i!\nCategoryId: {categoryId}\nWeekStart: {weekStart:yyyy-MM-dd}", 
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
                
                MessageBox.Show($"?ã load {_allTasks.Count} tasks t? DB", "DEBUG");
                
                RenderWeek();
                
                MessageBox.Show($"?ã g?i RenderWeek() xong!\nControls trong flowLayoutPanel2: {flowLayoutPanel2.Controls.Count}", 
                    "DEBUG");
                    
                // Force hi?n th?
                flowLayoutPanel2.Visible = true;
                flowLayoutPanel2.BringToFront();
                this.Visible = true;
                this.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"L?i load d? li?u: {ex.Message}\n\nStack trace: {ex.StackTrace}", "L?i", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Render tasks lên 7 ngày
        /// </summary>
        private void RenderWeek()
        {
            // Group theo ngày
            var grouped = _allTasks
                .GroupBy(t => t.DayOfWeek)
                .ToDictionary(g => g.Key, g => g.ToList());

            // Render cho c? 7 ngày
            ClearAndRenderDay(panel5, grouped.ContainsKey(1) ? grouped[1] : new List<WeekTask>());   // Monday
            ClearAndRenderDay(panel7, grouped.ContainsKey(2) ? grouped[2] : new List<WeekTask>());   // Tuesday
            ClearAndRenderDay(panel9, grouped.ContainsKey(3) ? grouped[3] : new List<WeekTask>());   // Wednesday
            ClearAndRenderDay(panel11, grouped.ContainsKey(4) ? grouped[4] : new List<WeekTask>()); // Thursday
            ClearAndRenderDay(panel15, grouped.ContainsKey(5) ? grouped[5] : new List<WeekTask>()); // Friday
            ClearAndRenderDay(panel17, grouped.ContainsKey(6) ? grouped[6] : new List<WeekTask>()); // Saturday
            ClearAndRenderDay(panel19, grouped.ContainsKey(7) ? grouped[7] : new List<WeekTask>()); // Sunday
        }

        /// <summary>
        /// Xóa và render l?i 1 ngày
        /// </summary>
        private void ClearAndRenderDay(Panel dayPanel, List<WeekTask> tasks)
        {
            if (dayPanel == null) return;

            // Xóa t?t c? checkbox c? (gi? l?i panel header)
            var toRemove = dayPanel.Controls.OfType<CheckBox>().ToList();
            foreach (var chk in toRemove)
            {
                dayPanel.Controls.Remove(chk);
                chk.Dispose();
            }

            // Render checkboxes m?i
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

        /// <summary>
        /// Clear t?t c? 7 ngày
        /// </summary>
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

        // =============================
        // CHECKBOX EVENTS
        // =============================
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
                MessageBox.Show($"L?i c?p nh?t: {ex.Message}", "L?i", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                chk.Checked = !newValue;
            }
            finally
            {
                chk.Enabled = true;
            }
        }

        // =============================
        // PUBLIC METHODS - CRUD
        // =============================
        public void AddTask(int dayOfWeek = 1)
        {
            if (CategoryId <= 0)
            {
                MessageBox.Show("Vui lòng ch?n category tr??c!", "Thông báo",
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

                    // Thêm vào local list
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
                    MessageBox.Show($"L?i: {ex.Message}", "L?i",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void EditTask()
        {
            if (_selectedCheckBox == null || _selectedCheckBox.Tag == null)
            {
                MessageBox.Show("Vui lòng ch?n task c?n s?a!", "Thông báo",
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

                    // Update local list
                    task.Title = dialog.TaskTitle;
                    task.DayOfWeek = dialog.DayOfWeek;

                    RenderWeek();
                    TaskChanged?.Invoke(this, EventArgs.Empty);

                    MessageBox.Show("C?p nh?t task thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"L?i: {ex.Message}", "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteTask()
        {
            if (_selectedCheckBox == null || _selectedCheckBox.Tag == null)
            {
                MessageBox.Show("Vui lòng ch?n task c?n xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int taskId = (int)_selectedCheckBox.Tag;
                var task = _allTasks.FirstOrDefault(t => t.TaskId == taskId);
                if (task == null) return;

                var result = MessageBox.Show(
                    $"B?n có ch?c mu?n xóa task '{task.Title}'?",
                    "Xác nh?n xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _taskController.DeleteTask(taskId);

                    // Remove from local list
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
                MessageBox.Show($"L?i: {ex.Message}", "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =============================
        // HELPER
        // =============================
        private DateTime GetMonday(DateTime date)
        {
            int daysFromMonday = ((int)date.DayOfWeek - 1 + 7) % 7;
            return date.Date.AddDays(-daysFromMonday);
        }
    }
}
