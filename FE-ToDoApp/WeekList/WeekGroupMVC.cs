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
    public partial class WeekGroupMVC : UserControl
    {
        //private const string ConnectionString = "Data Source=duc;Initial Catalog=ToDoApp;Integrated Security=True;Encrypt=False";

        private WeekCategoryController _categoryController;
        private WeekTaskController _taskController;

        private List<WeekCategory> _categories = new List<WeekCategory>();
        private week_category_item? _selectedCategoryItem;
        private int _currentCategoryId = -1;
        private DateTime _currentWeekStart;
        private List<WeekTask> _allTasks = new List<WeekTask>();
        private CheckBox? _selectedCheckBox;

        public WeekGroupMVC()
        {
            InitializeComponent();

            _categoryController = new WeekCategoryController();
            _taskController = new WeekTaskController();

            _currentWeekStart = GetMonday(DateTime.Now);
            button1.Click += BtnAddTask_Click;
            button2.Click += BtnEditTask_Click;
            button3.Click += BtnDeleteTask_Click;
            button1.Text = "➕ Thêm";
            button2.Text = "✏️ Sửa";
            button3.Text = "🗑️ Xóa";
            txt_search_place.TextChanged += TxtSearch_TextChanged;
            LoadCategories();
        }

        public void RefreshData()
        {
            LoadCategories();
        }

        public void SelectCategory(int categoryId)
        {
            var targetItem = flowLayoutPanel1.Controls.OfType<week_category_item>()
                .FirstOrDefault(item => item.CategoryId == categoryId);

            if (targetItem != null)
            {
                CategoryItem_Clicked(targetItem, EventArgs.Empty);
            }
        }

        private void LoadCategories()
        {
            try
            {
                _categories = _categoryController.GetAllCategories();

                var toRemove = flowLayoutPanel1.Controls.OfType<week_category_item>().ToList();
                foreach (var item in toRemove)
                {
                    flowLayoutPanel1.Controls.Remove(item);
                    item.Dispose();
                }
                int insertIndex = flowLayoutPanel1.Controls.IndexOf(panel4) + 1;

                foreach (var category in _categories)
                {
                    var item = new week_category_item
                    {
                        CategoryId = category.CategoryId,
                        CategoryName = category.CategoryName,
                        Width = 267,
                        Height = 70,
                        Margin = new Padding(3)
                    };

                    item.SetWeekRange(category.WeekStartDate, category.WeekEndDate);
                    item.Clicked += CategoryItem_Clicked;
                    item.EditRequested += CategoryItem_EditRequested;
                    item.DeleteRequested += CategoryItem_DeleteRequested;

                    flowLayoutPanel1.Controls.Add(item);
                    flowLayoutPanel1.Controls.SetChildIndex(item, insertIndex++);
                }

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
            LoadWeek();
        }

        private void CategoryItem_EditRequested(object? sender, EventArgs e)
        {
            var item = sender as week_category_item;
            if (item == null) return;

            var category = _categories.FirstOrDefault(c => c.CategoryId == item.CategoryId);
            if (category == null) return;

            // Hỏi xác nhận trước khi sửa
            var confirmResult = MessageBox.Show(
                $"Bạn có muốn sửa nhóm công việc '{category.CategoryName}' không?",
                "Xác nhận sửa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                var dialog = new CategoryEditDialog(
                    category.CategoryName,
                    category.WeekStartDate,
                    category.WeekEndDate);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _categoryController.UpdateCategory(
                        category.CategoryId,
                        dialog.CategoryName,
                        dialog.WeekStartDate,
                        dialog.WeekEndDate);

                    LoadCategories();

                    MessageBox.Show("Cập nhật nhóm công việc thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // đây nef
        private void CategoryItem_DeleteRequested(object? sender, EventArgs e)
        {
            var item = sender as week_category_item;
            if (item == null) return;

            var category = _categories.FirstOrDefault(c => c.CategoryId == item.CategoryId);
            if (category == null) return;
            var confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa nhóm công việc '{category.CategoryName}' không?\n\n" +
                "Tất cả các task trong nhóm này sẽ không bị xóa nhưng sẽ không hiển thị trong view này nữa.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                _categoryController.DeleteCategory(category.CategoryId);
                LoadCategories();

                MessageBox.Show("Xóa nhóm công việc thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadWeek()
        {
            if (_currentCategoryId <= 0)
            {
                ClearAllDays();
                return;
            }

            try
            {
                _allTasks = _taskController.GetTasksByCategory(_currentCategoryId, _currentWeekStart);

                var filtered = _allTasks;
                string searchKeyword = txt_search_place.Text.Trim();

                if (!string.IsNullOrWhiteSpace(searchKeyword))
                {
                    filtered = _allTasks
                        .Where(t => t.Title.IndexOf(searchKeyword, StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();
                }
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
            
            // Clear existing controls (except header panel)
            var toRemove = new List<Control>();
            foreach (Control c in dayPanel.Controls)
            {
                // Giữ lại panel header (panel6, panel8, etc.)
                if (c is Panel headerPanel && headerPanel.BackColor == SystemColors.ActiveBorder)
                    continue;
                toRemove.Add(c);
            }
            
            foreach (var c in toRemove)
            {
                dayPanel.Controls.Remove(c);
                c.Dispose();
            }

            int yPos = 70;
            
            // Tính width dựa vào dayPanel (ví dụ panel5 width = 1121)
            // Trừ scrollbar nếu có
            int scrollbarWidth = dayPanel.VerticalScroll.Visible ? SystemInformation.VerticalScrollBarWidth : 0;
            int availableWidth = dayPanel.ClientSize.Width - scrollbarWidth;
            
            // Width của task panel (trừ padding)
            int taskPanelWidth = Math.Max(200, availableWidth - 50); // 50 = padding left/right

            foreach (var task in tasks)
            {
                // Container panel for each task
                Panel taskPanel = new Panel
                {
                    Width = taskPanelWidth,
                    Height = 35,
                    Location = new Point(24, yPos),
                    BackColor = Color.Transparent,
                    Tag = task.TaskId
                };

                // Checkbox - width: panel width trừ space cho icon
                CheckBox chk = new CheckBox
                {
                    Text = task.Title,
                    Checked = task.IsDone,
                    Location = new Point(0, 8),
                    Width = taskPanelWidth - 45, // Space for done icon
                    Height = 24,
                    Font = new Font("Segoe UI", 10F),
                    FlatStyle = FlatStyle.Flat,
                    Tag = task.TaskId,
                    AutoSize = false,
                    AutoEllipsis = true
                };

                // Done icon (✓) - fixed position từ bên phải
                Label lblDoneIcon = new Label
                {
                    Name = "lblDoneIcon",
                    Text = "✓",
                    Width = 30,
                    Height = 24,
                    Location = new Point(taskPanelWidth - 35, 6),
                    Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                    ForeColor = Color.Green,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Visible = task.IsDone,
                    BackColor = Color.Transparent
                };

                chk.CheckedChanged += Chk_CheckedChanged;
                chk.Click += Chk_Click;
                chk.DoubleClick += Chk_DoubleClick;

                taskPanel.Controls.Add(chk);
                taskPanel.Controls.Add(lblDoneIcon);
                lblDoneIcon.BringToFront();

                ApplyCompletionStyle(taskPanel, chk, lblDoneIcon, task.IsDone);

                dayPanel.Controls.Add(taskPanel);
                taskPanel.BringToFront(); // Đảm bảo nó nằm trên header
                
                yPos += 35;
            }
        }

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

        private void BtnEditTask_Click(object? sender, EventArgs e)
        {
            EditTask();
        }

        private void BtnDeleteTask_Click(object? sender, EventArgs e)
        {
            DeleteTaskPrompt();
        }

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
        private void Chk_Click(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            if (chk != null)
            {
                _selectedCheckBox = chk;
            }
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
                if (task != null) 
                {
                    task.IsDone = newValue;
                }

                // Find parent panel and done icon
                Panel? taskPanel = chk.Parent as Panel;
                if (taskPanel != null)
                {
                    Label? doneIcon = taskPanel.Controls.OfType<Label>()
                        .FirstOrDefault(l => l.Name == "lblDoneIcon");
                    
                    ApplyCompletionStyle(taskPanel, chk, doneIcon, newValue);
                }
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
        private void ApplyCompletionStyle(Panel taskPanel, CheckBox chk, Label? doneIcon, bool isDone)
        {
            if (isDone)
            {
                // Background xanh nhạt
                taskPanel.BackColor = Color.FromArgb(240, 255, 240);
                
                // Text gạch ngang + màu xám
                chk.Font = new Font(chk.Font, FontStyle.Strikeout);
                chk.ForeColor = Color.FromArgb(120, 120, 120);
                chk.BackColor = Color.Transparent;
                
                // Show done icon
                if (doneIcon != null)
                {
                    doneIcon.Visible = true;
                }
            }
            else
            {
                // Background trong suốt
                taskPanel.BackColor = Color.Transparent;
                
                // Text bình thường
                chk.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                chk.ForeColor = Color.Black;
                chk.BackColor = Color.Transparent;
                
                // Hide done icon
                if (doneIcon != null)
                {
                    doneIcon.Visible = false;
                }
            }
        }
        private void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            if (_currentCategoryId > 0)
            {
                LoadWeek();
            }
        }

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

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            var dialog = new Views.Dialogs.CategoryAddDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int newCategoryId = _categoryController.AddCategory(
                        dialog.CategoryName,
                        dialog.WeekStartDate,
                        dialog.WeekEndDate);

                    LoadCategories();

                    var newItem = flowLayoutPanel1.Controls.OfType<week_category_item>()
                        .FirstOrDefault(item => item.CategoryId == newCategoryId);

                    if (newItem != null)
                    {
                        CategoryItem_Clicked(newItem, EventArgs.Empty);
                    }

                    MessageBox.Show("Thêm nhóm công việc thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
