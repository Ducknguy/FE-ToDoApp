using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FE_ToDoApp.WeekList.Controllers;
using FE_ToDoApp.WeekList.Models;
using FE_ToDoApp.WeekList.Views;
using FE_ToDoApp.WeekList.Views.Dialogs;

namespace FE_ToDoApp.WeekList       
{
    /// <summary>
    /// WeekList với MVC Pattern và Category Management (Simplified)
    /// Render 7 ngày trực tiếp, không dùng WeekItemsControl
    /// </summary>
    public partial class WeekGroupMVC : UserControl
    {
        // ===== CONNECTION =====
        private const string ConnectionString = "Data Source=duc;Initial Catalog=ToDoApp;Integrated Security=True;Encrypt=False";

        // ===== CONTROLLERS =====
        private WeekCategoryController _categoryController;
        private WeekTaskController _taskController;

        // ===== STATE =====
        private List<WeekCategory> _categories = new List<WeekCategory>();
        private week_category_item? _selectedCategoryItem;
        private int _currentCategoryId = -1;
        private DateTime _currentWeekStart;
        private List<WeekTask> _allTasks = new List<WeekTask>();
        private CheckBox? _selectedCheckBox;

        public WeekGroupMVC()
        {
            InitializeComponent();

            // Initialize Controllers
            _categoryController = new WeekCategoryController(ConnectionString);
            _taskController = new WeekTaskController(ConnectionString);

            // Calculate current week
            _currentWeekStart = GetMonday(DateTime.Now);

            // Wire button events - THÊM/SỬA/XÓA TASKS (không phải categories)
            button1.Click += BtnAddTask_Click;      // Thêm task
            button2.Click += BtnEditTask_Click;     // Sửa task
            button3.Click += BtnDeleteTask_Click;   // Xóa task

            // Đổi text của buttons cho rõ ràng
            button1.Text = "➕ Thêm";
            button2.Text = "✏️ Sửa";
            button3.Text = "🗑️ Xóa";

            // Wire search event
            txt_search_place.TextChanged += TxtSearch_TextChanged;

            // Load initial data
            LoadCategories();
        }

        // =============================
        // CATEGORY MANAGEMENT
        // =============================
        
        private void LoadCategories()
        {
            try
            {
                _categories = _categoryController.GetAllCategories();

                // Clear old items
                var toRemove = flowLayoutPanel1.Controls.OfType<week_category_item>().ToList();
                foreach (var item in toRemove)
                {
                    flowLayoutPanel1.Controls.Remove(item);
                    item.Dispose();
                }

                // Render new items after panel4
                int insertIndex = flowLayoutPanel1.Controls.IndexOf(panel4) + 1;
                
                foreach (var category in _categories)
                {
                    var item = new week_category_item
                    {
                        CategoryId = category.CategoryId,
                        CategoryName = category.CategoryName,
                        Width = 267,
                        Height = 50,
                        Margin = new Padding(3)
                    };

                    item.Clicked += CategoryItem_Clicked;
                    flowLayoutPanel1.Controls.Add(item);
                    flowLayoutPanel1.Controls.SetChildIndex(item, insertIndex++);
                }

                // Auto-select first category
                if (_categories.Any())
                {
                    var firstItem = flowLayoutPanel1.Controls.OfType<week_category_item>().FirstOrDefault();
                    if (firstItem != null)
                    {
                        CategoryItem_Clicked(firstItem, EventArgs.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load categories: {ex.Message}\n\n" +
                    $"Hãy đảm bảo bạn đã chạy SQL migration script!", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CategoryItem_Clicked(object? sender, EventArgs e)
        {
            var clickedItem = sender as week_category_item;
            if (clickedItem == null) return;

            // Deselect old item
            if (_selectedCategoryItem != null)
            {
                _selectedCategoryItem.SetSelected(false);
            }

            // Select new item
            _selectedCategoryItem = clickedItem;
            _selectedCategoryItem.SetSelected(true);
            _currentCategoryId = clickedItem.CategoryId;

            // Load tasks cho category này
            LoadWeek();
        }

        // =============================
        // TASK MANAGEMENT (Render trực tiếp)
        // =============================
        
        private void LoadWeek()
        {
            if (_currentCategoryId <= 0)
            {
                ClearAllDays();
                return;
            }

            try
            {
                // Load từ Controller
                _allTasks = _taskController.GetTasksByCategory(_currentCategoryId, _currentWeekStart);

                // Apply search filter
                var filtered = _allTasks;
                string searchKeyword = txt_search_place.Text.Trim();

                if (!string.IsNullOrWhiteSpace(searchKeyword))
                {
                    filtered = _allTasks
                        .Where(t => t.Title.IndexOf(searchKeyword, StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();
                }

                // Group theo ngày và render
                var grouped = filtered
                    .GroupBy(t => t.DayOfWeek)
                    .ToDictionary(g => g.Key, g => g.ToList());

                ClearAndRenderDay(panel5, grouped.ContainsKey(1) ? grouped[1] : new List<WeekTask>());
                ClearAndRenderDay(panel7, grouped.ContainsKey(2) ? grouped[2] : new List<WeekTask>());
                ClearAndRenderDay(panel9, grouped.ContainsKey(3) ? grouped[3] : new List<WeekTask>());
                ClearAndRenderDay(panel11, grouped.ContainsKey(4) ? grouped[4] : new List<WeekTask>());
                ClearAndRenderDay(panel15, grouped.ContainsKey(5) ? grouped[5] : new List<WeekTask>());
                ClearAndRenderDay(panel17, grouped.ContainsKey(6) ? grouped[6] : new List<WeekTask>());
                ClearAndRenderDay(panel19, grouped.ContainsKey(7) ? grouped[7] : new List<WeekTask>());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load tasks: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearAndRenderDay(Panel dayPanel, List<WeekTask> tasks)
        {
            if (dayPanel == null) return;

            // Xóa tất cả checkbox cũ
            var toRemove = dayPanel.Controls.OfType<CheckBox>().ToList();
            foreach (var chk in toRemove)
            {
                dayPanel.Controls.Remove(chk);
                chk.Dispose();
            }

            // Render checkboxes mới
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
        /// Lấy dayOfWeek từ panel name
        /// </summary>
        private int GetDayOfWeekFromPanel(Panel panel)
        {
            if (panel == panel5) return 1;  // Monday
            if (panel == panel7) return 2;  // Tuesday
            if (panel == panel9) return 3;  // Wednesday
            if (panel == panel11) return 4; // Thursday
            if (panel == panel15) return 5; // Friday
            if (panel == panel17) return 6; // Saturday
            if (panel == panel19) return 7; // Sunday
            return 1; // Default Monday
        }

        /// <summary>
        /// Thêm task vào ngày cụ thể
        /// </summary>
        private void AddTaskToDay(int dayOfWeek)
        {
            if (_currentCategoryId <= 0)
            {
                MessageBox.Show("Vui lòng chọn category trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialog = new TaskEditDialog("", dayOfWeek);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int newTaskId = _taskController.AddTask(
                        _currentCategoryId,
                        _currentWeekStart,
                        dialog.DayOfWeek,
                        dialog.TaskTitle);

                    _allTasks.Add(new WeekTask
                    {
                        TaskId = newTaskId,
                        CategoryId = _currentCategoryId,
                        DayOfWeek = dialog.DayOfWeek,
                        Title = dialog.TaskTitle,
                        IsDone = false,
                        OrderIndex = 0
                    });

                    LoadWeek();
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

        // =============================
        // TASK CRUD - TOOLBAR BUTTONS
        // =============================
        
        /// <summary>
        /// Nút Thêm - Hiện dropdown chọn ngày
        /// </summary>
        private void BtnAddTask_Click(object? sender, EventArgs e)
        {
            if (_currentCategoryId <= 0)
            {
                MessageBox.Show("Vui lòng chọn category trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialog = new TaskEditDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int newTaskId = _taskController.AddTask(
                        _currentCategoryId,
                        _currentWeekStart,
                        dialog.DayOfWeek,
                        dialog.TaskTitle);

                    _allTasks.Add(new WeekTask
                    {
                        TaskId = newTaskId,
                        CategoryId = _currentCategoryId,
                        DayOfWeek = dialog.DayOfWeek,
                        Title = dialog.TaskTitle,
                        IsDone = false,
                        OrderIndex = 0
                    });

                    LoadWeek();
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

        /// <summary>
        /// Nút Sửa - Sửa task đang chọn
        /// </summary>
        private void BtnEditTask_Click(object? sender, EventArgs e)
        {
            EditTask();
        }

        /// <summary>
        /// Nút Xóa - Xóa task đang chọn
        /// </summary>
        private void BtnDeleteTask_Click(object? sender, EventArgs e)
        {
            DeleteTaskPrompt();
        }

        /// <summary>
        /// Sửa task (logic)
        /// </summary>
        private void EditTask()
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

                    LoadWeek();
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

        /// <summary>
        /// Xóa task (logic)
        /// </summary>
        private void DeleteTaskPrompt()
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

                    LoadWeek();
                    _selectedCheckBox = null;

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

                var task = _allTasks.FirstOrDefault(t => t.TaskId == taskId);
                if (task != null) task.IsDone = newValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                chk.Checked = !newValue;
            }
            finally
            {
                chk.Enabled = true;
            }
        }

        // =============================
        // SEARCH
        // =============================
        
        private void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            if (_currentCategoryId > 0)
            {
                LoadWeek();
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
    }
}
