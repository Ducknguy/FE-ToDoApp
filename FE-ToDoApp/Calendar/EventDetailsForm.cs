using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq; // Cần cái này để dùng .OrderBy

namespace FE_ToDoApp.Calendar
{
    public class EventDetailsForm : Form
    {
        private FlowLayoutPanel panelList;
        private DateTime _currentDate;
        private bool _hasChanges = false;

        public EventDetailsForm(string dateString, List<TaskItem> events)
        {
            _currentDate = DateTime.Parse(dateString);

            // --- 1. Cấu hình Form ---
            this.Text = "Quản lý công việc";
            this.Size = new Size(480, 600); // Tăng chiều rộng chút để chứa nút
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;

            // --- 2. Header (Tiêu đề + Nút Thêm) ---
            Panel pnlHeader = new Panel() { Dock = DockStyle.Top, Height = 70, BackColor = Color.WhiteSmoke };

            Label lblTitle = new Label() { Text = $"📅 {_currentDate:dd/MM/yyyy}", Location = new Point(10, 20), AutoSize = true, Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = Color.DarkSlateBlue };

            Button btnAdd = new Button() { Text = "+ Thêm Việc", Location = new Point(330, 20), Size = new Size(110, 35), BackColor = Color.ForestGreen, ForeColor = Color.White, Font = new Font("Segoe UI", 10, FontStyle.Bold), Cursor = Cursors.Hand };
            btnAdd.Click += (s, e) => {
                TaskForm frm = new TaskForm(_currentDate); // Mở form thêm
                if (frm.ShowDialog() == DialogResult.OK) 
                { 
                    ReloadData();
                    _hasChanges = true;
                }
            };

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnAdd);
            this.Controls.Add(pnlHeader);

            // --- 3. Panel chứa danh sách ---
            panelList = new FlowLayoutPanel() { Dock = DockStyle.Fill, AutoScroll = true, FlowDirection = FlowDirection.TopDown, WrapContents = false, Padding = new Padding(10) };
            this.Controls.Add(panelList);
            panelList.BringToFront();

            // Vẽ danh sách lần đầu
            RenderList(events);
        }

        // Hàm vẽ lại danh sách
        private void RenderList(List<TaskItem> events)
        {
            panelList.Controls.Clear(); // Xóa cũ

            // Sắp xếp theo giờ tăng dần cho dễ nhìn
            var sortedEvents = events.OrderBy(t => t.StartDate).ToList();

            if (sortedEvents.Count == 0)
            {
                Label lblEmpty = new Label() { Text = "Chưa có công việc nào.", AutoSize = true, Font = new Font("Segoe UI", 12), ForeColor = Color.Gray };
                panelList.Controls.Add(lblEmpty);
                return;
            }

            foreach (var task in sortedEvents)
            {
                panelList.Controls.Add(CreateEventItem(task));
            }
        }

        // Hàm tải lại dữ liệu từ SQL (được gọi sau khi Thêm/Sửa/Xóa)
        private void ReloadData()
        {
            // Gọi lại DatabaseHelper để lấy danh sách mới nhất
            var allTasks = DatabaseHelper.GetTasksByMonth(_currentDate.Month, _currentDate.Year);
            var tasksForDay = allTasks.Where(t => t.StartDate.Date == _currentDate.Date).ToList();
            RenderList(tasksForDay);
        }

        // Tạo 1 dòng công việc (Có nút Sửa, Xóa)
        private Panel CreateEventItem(TaskItem task)
        {
            Panel pnl = new Panel() { Size = new Size(430, 80), BackColor = Color.AliceBlue, Margin = new Padding(0, 0, 0, 10), BorderStyle = BorderStyle.FixedSingle };

            // Giờ
            Label lblTime = new Label() { Text = task.StartDate.ToString("HH:mm"), Location = new Point(10, 15), Size = new Size(60, 25), Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = Color.OrangeRed };

            // Tên
            Label lblSummary = new Label() { Text = task.Title, Location = new Point(80, 15), Size = new Size(240, 25), Font = new Font("Segoe UI", 11, FontStyle.Bold) };

            // Mô tả ngắn
            string desc = task.Description ?? "";
            if (desc.Length > 40) desc = desc.Substring(0, 40) + "...";
            Label lblDesc = new Label() { Text = desc, Location = new Point(80, 45), Size = new Size(240, 20), Font = new Font("Segoe UI", 9, FontStyle.Italic), ForeColor = Color.Gray };

            // --- NÚT SỬA ---
            Button btnEdit = new Button() { Text = "✏️", Location = new Point(330, 15), Size = new Size(40, 40), BackColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
            btnEdit.Click += (s, e) => {
                TaskForm frm = new TaskForm(_currentDate, task); // Truyền task vào để sửa
                if (frm.ShowDialog() == DialogResult.OK) 
                { 
                    ReloadData();
                    _hasChanges = true;
                }
            };

            // --- NÚT XÓA ---
            Button btnDel = new Button() { Text = "🗑️", Location = new Point(380, 15), Size = new Size(40, 40), BackColor = Color.MistyRose, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
            btnDel.Click += (s, e) => {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DatabaseHelper.DeleteTask(task.Id);
                    ReloadData();
                    _hasChanges = true;
                    
                    // Nếu xóa hết công việc trong ngày, đóng form
                    if (panelList.Controls.Count == 1 && panelList.Controls[0] is Label)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            };

            pnl.Controls.AddRange(new Control[] { lblTime, lblSummary, lblDesc, btnEdit, btnDel });
            return pnl;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_hasChanges)
            {
                this.DialogResult = DialogResult.OK;
            }
            base.OnFormClosing(e);
        }
    }
}