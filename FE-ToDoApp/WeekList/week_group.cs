using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FE_ToDoApp.WeekList.Data;
using FE_ToDoApp.WeekList.Models;

namespace FE_ToDoApp.WeekList
{
    public partial class week_group : UserControl
    {
        private DateTime _currentWeekStart;
        private List<WeekTask> _allTasks = new List<WeekTask>();
        private CheckBox _selectedCheckBox;

        public week_group()
        {
            InitializeComponent();

            // Tính Monday của tuần hiện tại
            _currentWeekStart = GetMonday(DateTime.Now);

            // Gắn sự kiện search
            txt_search_place.TextChanged += (s, e) => LoadWeek();

            // Gắn sự kiện cho các button
            button1.Click += BtnAdd_Click;
            button2.Click += BtnEdit_Click;
            button3.Click += BtnDelete_Click;

            LoadWeek();
        }

        private void LoadWeek()
        {
            try
            {
                // Load từ DB
                _allTasks = Db.LoadWeekTasks(_currentWeekStart);

                // Apply search filter và render
                RenderWeek();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RenderWeek()
        {
            // Filter theo search
            var filtered = _allTasks;
            string searchKeyword = txt_search_place.Text.Trim();

            if (!string.IsNullOrWhiteSpace(searchKeyword) && searchKeyword != "Search task and events ....")
            {
                filtered = _allTasks
                    .Where(t => t.Title.IndexOf(searchKeyword, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }

            // Group theo ngày
            var grouped = filtered
                .GroupBy(t => t.DayOfWeek)
                .ToDictionary(g => g.Key, g => g.ToList());

            // Xóa checkboxes cũ và render lại cho cả 7 ngày
            ClearAndRenderDay(panel5, grouped.ContainsKey(1) ? grouped[1] : new List<WeekTask>());   // Monday
            ClearAndRenderDay(panel7, grouped.ContainsKey(2) ? grouped[2] : new List<WeekTask>());   // Tuesday
            ClearAndRenderDay(panel9, grouped.ContainsKey(3) ? grouped[3] : new List<WeekTask>());   // Wednesday
            ClearAndRenderDay(panel11, grouped.ContainsKey(4) ? grouped[4] : new List<WeekTask>()); // Thursday
            ClearAndRenderDay(panel15, grouped.ContainsKey(5) ? grouped[5] : new List<WeekTask>()); // Friday
            ClearAndRenderDay(panel17, grouped.ContainsKey(6) ? grouped[6] : new List<WeekTask>()); // Saturday
            ClearAndRenderDay(panel19, grouped.ContainsKey(7) ? grouped[7] : new List<WeekTask>()); // Sunday
        }

        private void ClearAndRenderDay(Panel dayPanel, List<WeekTask> tasks)
        {
            if (dayPanel == null) return;

            // Xóa tất cả checkbox cũ (giữ lại panel header)
            var toRemove = dayPanel.Controls.OfType<CheckBox>().ToList();
            foreach (var chk in toRemove)
            {
                dayPanel.Controls.Remove(chk);
                chk.Dispose();
            }

            // Render checkboxes mới
            int yPos = 70; // Bắt đầu dưới header (64px + 6px margin)
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
                BtnEdit_Click(sender, e);
            }
        }

        private void Chk_CheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            if (chk == null || chk.Tag == null) return;

            int taskId = (int)chk.Tag;
            bool newValue = chk.Checked;

            chk.Enabled = false; // Disable khi đang update

            try
            {
                Db.UpdateDone(taskId, newValue);

                // Update local list
                var task = _allTasks.FirstOrDefault(t => t.TaskId == taskId);
                if (task != null) task.IsDone = newValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Rollback UI
                chk.Checked = !newValue;
            }
            finally
            {
                chk.Enabled = true;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new TaskEditDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    int newTaskId = Db.InsertTask(_currentWeekStart, dialog.DayOfWeek, dialog.TaskTitle);
                    
                    // Thêm vào local list
                    _allTasks.Add(new WeekTask
                    {
                        TaskId = newTaskId,
                        DayOfWeek = dialog.DayOfWeek,
                        Title = dialog.TaskTitle,
                        IsDone = false,
                        OrderIndex = 0
                    });

                    RenderWeek();
                    MessageBox.Show("Thêm task thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm task: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
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
                    Db.UpdateTask(taskId, dialog.TaskTitle, dialog.DayOfWeek);
                    
                    // Update local list
                    task.Title = dialog.TaskTitle;
                    task.DayOfWeek = dialog.DayOfWeek;

                    RenderWeek();
                    MessageBox.Show("Cập nhật task thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi sửa task: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
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
                    Db.DeleteTask(taskId);
                    
                    // Remove from local list
                    _allTasks.Remove(task);

                    RenderWeek();
                    _selectedCheckBox = null;
                    
                    MessageBox.Show("Xóa task thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa task: {ex.Message}", "Lỗi", 
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