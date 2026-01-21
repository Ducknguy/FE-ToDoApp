using System;
using System.Data;
using System.Data.SQLite;
using FE_ToDoApp.Database;

namespace FE_ToDoApp.Lich_Trinh
{
    public partial class TaskItem : UserControl
    {
        

        private int _selectedTodoId = -1;

        private bool _deleteMode = false;
        private bool _editMode = false;

        private readonly TodoDetailItemControl _detail = new TodoDetailItemControl();

        public TaskItem()
        {
            InitializeComponent();
            ConfigureLayout();
            WireEvents();

            SetupRightDetail();
            LoadTodosToLeftList();
        }

        private void ConfigureLayout()
        {
            // LEFT = LIST
            flp_task_left.FlowDirection = FlowDirection.TopDown;
            flp_task_left.WrapContents = false;
            flp_task_left.AutoScroll = true;
            flp_task_left.Padding = new Padding(8);

            // RIGHT = DETAIL
            flp_task_right.FlowDirection = FlowDirection.TopDown;
            flp_task_right.WrapContents = false;
            flp_task_right.AutoScroll = true;
            flp_task_right.Padding = new Padding(12);
        }

        private void WireEvents()
        {
            btn_add.Click += btn_add_Click;

            flp_task_left.SizeChanged += (s, e) => ResizeLeftListItemsToFullWidth();
            flp_task_right.SizeChanged += (s, e) => ResizeRightDetailToFullWidth();

            txt_search_place.GotFocus += (s, e) =>
            {
                if (txt_search_place.Text == "Search task and events ....")
                {
                    txt_search_place.Text = "";
                    txt_search_place.ForeColor = Color.Black;
                }
            };

            txt_search_place.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt_search_place.Text))
                {
                    txt_search_place.Text = "Search task and events ....";
                    txt_search_place.ForeColor = Color.Gray;
                }
            };

            txt_search_place.TextChanged += Txt_Search_TextChanged;
             }

        private void SetupRightDetail()
        {
            flp_task_right.Controls.Clear();

            _detail.AutoSize = false;
            _detail.Margin = new Padding(0);
            _detail.Width = GetRightWidth();

            _detail.TodoHeaderChanged += (s, e) => LoadTodosToLeftList();
            _detail.TodoDeleted += (s, e) =>
            {
                LoadTodosToLeftList();
            };
            _detail.TodoItemStatusChanged += (s, e) => LoadTodosToLeftList();

            flp_task_right.Controls.Add(_detail);
        }

        // LEFT list
        private void LoadTodosToLeftList()
        {
            flp_task_left.SuspendLayout();
            
            // ✅ Lưu lại todo đang chọn
            int previouslySelectedId = _selectedTodoId;
            
            flp_task_left.Controls.Clear();

            string searchKeyword = txt_search_place.Text.Trim();
            bool isSearching = !string.IsNullOrWhiteSpace(searchKeyword) && 
                               searchKeyword != "Search task and events ....";

            var dt = isSearching ? Db_SearchTodos(searchKeyword) : Db_GetTodos();
            
            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["id_todo"]);
                string title = Convert.ToString(row["title"]) ?? "(no title)";

                // ✅ Get completion stats for this todo
                var (completedCount, totalCount) = Db_GetTodoCompletionStats(id);

                Panel container = new Panel
                {
                    Width = GetLeftWidth(),
                    Height = 56,
                    Margin = new Padding(0, 0, 0, 8),
                    Tag = id,
                    BackColor = Color.Transparent
                };

                var item = new ToDoListItem
                {
                    TodoId = id,
                    Tag = id,
                    Height = 56,
                    AutoSize = false,
                    Margin = new Padding(0),
                    Dock = DockStyle.Fill
                };

                item.SetTitle(title);
                
                // ✅ Set completion status
                item.SetCompletionStatus(completedCount, totalCount);
                
                item.Clicked += (s, e) => SelectTodo(id);

                Button btnDeleteItem = new Button
                {
                    Name = "btnDelete",
                    Text = "X",
                    Width = 30,
                    Height = 30,
                    BackColor = Color.FromArgb(255, 200, 200),
                    ForeColor = Color.DarkRed,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Visible = false,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                };
                btnDeleteItem.FlatAppearance.BorderSize = 0;
                btnDeleteItem.Location = new Point(container.Width - 35, 13);
                btnDeleteItem.Anchor = AnchorStyles.Right | AnchorStyles.Top;

                Button btnEditItem = new Button
                {
                    Name = "btnEdit",
                    Text = "✎",
                    Width = 30,
                    Height = 30,
                    BackColor = Color.FromArgb(173, 216, 230),
                    ForeColor = Color.DarkBlue,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Visible = false,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                };
                btnEditItem.FlatAppearance.BorderSize = 0;
                btnEditItem.Location = new Point(container.Width - 70, 13);
                btnEditItem.Anchor = AnchorStyles.Right | AnchorStyles.Top;

                btnDeleteItem.Click += (s, e) =>
                {
                    var result = MessageBox.Show(
                        $"Bạn có chắc muốn xóa '{title}'?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        Db_DeleteTodo(id);
                        LoadTodosToLeftList();
                    }
                };

                btnEditItem.Click += (s, e) =>
                {
                    string newTitle = Microsoft.VisualBasic.Interaction.InputBox(
                        "Nhập tiêu đề mới:", "Sửa detail", title);

                    if (string.IsNullOrWhiteSpace(newTitle) || newTitle == title) return;

                    Db_UpdateTodoTitle(id, newTitle);
                    LoadTodosToLeftList();
                    SelectTodo(id);
                };

                container.Controls.Add(item);
                container.Controls.Add(btnEditItem);
                container.Controls.Add(btnDeleteItem);

                btnEditItem.BringToFront();
                btnDeleteItem.BringToFront();

                flp_task_left.Controls.Add(container);
            }

            flp_task_left.ResumeLayout();
            ResizeLeftListItemsToFullWidth();

            // ✅ Khôi phục lại selection
            bool foundPrevious = false;
            if (previouslySelectedId > 0)
            {
                // Kiểm tra xem todo đã chọn trước đó còn trong danh sách không
                foreach (Control c in flp_task_left.Controls)
                {
                    if (c is Panel container && container.Tag is int id && id == previouslySelectedId)
                    {
                        SelectTodo(previouslySelectedId);
                        foundPrevious = true;
                        break;
                    }
                }
            }

            // Nếu không tìm thấy todo trước đó, chọn todo đầu tiên
            if (!foundPrevious)
            {
                if (flp_task_left.Controls.Count > 0 &&
                    flp_task_left.Controls[0].Tag is int firstId)
                {
                    SelectTodo(firstId);
                }
                else
                {
                    _detail.LoadTodo(-1);
                }
            }

            if (_deleteMode || _editMode)
            {
                _deleteMode = false;
                _editMode = false;
            }

            UpdateItemButtons();
        }

        private void SelectTodo(int todoId)
        {
            _selectedTodoId = todoId;

            foreach (Control c in flp_task_left.Controls)
            {
                if (c is Panel container)
                {
                    bool selected = container.Tag is int id && id == todoId;
                    
                    foreach (Control child in container.Controls)
                    {
                        if (child is ToDoListItem t)
                        {
                            t.SetSelected(selected);
                            break;
                        }
                    }
                }
            }

            _detail.Width = GetRightWidth();
            _detail.LoadTodo(todoId);
        }

        // ===== CHỨC NĂNG THÊM TODO =====
        private void btn_add_Click(object? sender, EventArgs e)
        {
            string title = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập tiêu đề detail:", "Thêm detail", "New detail");

            if (string.IsNullOrWhiteSpace(title)) return;

            int newId = Db_InsertTodo(title);
            LoadTodosToLeftList();
            SelectTodo(newId);
        }

        // ===== CHỨC NĂNG SỬA TODO (GIỐNG TODODETAILITEMCONTROL) =====
        private void btn_edit_Click(object? sender, EventArgs e)
        {
            UpdateItemButtons();
        }

        // ===== CHỨC NĂNG XÓA TODO (GIỐNG TODODETAILITEMCONTROL) =====
        private void btn_delete_Click(object? sender, EventArgs e)
        {
            UpdateItemButtons();
        }

        // ===== CẬP NHẬT NÚT HIỂN THỊ (GIỐNG TODODETAILITEMCONTROL) =====
        private void UpdateItemButtons()
        {
            foreach (Control c in flp_task_left.Controls)
            {
                if (c is Panel container)
                {
                    // Tìm nút Xóa
                    foreach (Control child in container.Controls)
                    {
                        if (child is Button btn)
                        {
                            if (btn.Name == "btnDelete")
                            {
                                btn.Visible = _deleteMode;
                            }
                            else if (btn.Name == "btnEdit")
                            {
                                btn.Visible = _editMode;
                            }
                        }
                    }
                }
            }
        }

        // ===== DATABASE OPERATIONS - SQLITE =====
        private static DataTable Db_GetTodos()
        {
            return SQLiteHelper.ExecuteQuery(@"
                SELECT id_todo, title
                FROM Todo_List_Detail
                WHERE (IsDeleted = 0 OR IsDeleted IS NULL)
                ORDER BY updated_at DESC, id_todo DESC");
        }

        private static int Db_InsertTodo(string title)
        {
            var result = SQLiteHelper.ExecuteScalar(@"
                INSERT INTO Todo_List_Detail (title, userid, created_at, updated_at)
                VALUES (@title, 1, datetime('now'), datetime('now'));
                
                SELECT last_insert_rowid();",
                new SQLiteParameter("@title", title));

            return Convert.ToInt32(result);
        }

        private static void Db_UpdateTodoTitle(int todoId, string newTitle)
        {
            SQLiteHelper.ExecuteNonQuery(@"
                UPDATE Todo_List_Detail
                SET title = @title, updated_at = datetime('now')
                WHERE id_todo = @id",
                new SQLiteParameter("@title", newTitle),
                new SQLiteParameter("@id", todoId));
        }

        private static void Db_DeleteTodo(int todoId)
        {
            SQLiteHelper.ExecuteNonQuery(@"
                UPDATE Todo_List_Detail 
                SET IsDeleted = 1, DeletedAt = datetime('now') 
                WHERE id_todo = @id",
                new SQLiteParameter("@id", todoId));
        }

        private static DataTable Db_SearchTodos(string keyword)
        {
            return SQLiteHelper.ExecuteQuery(@"
                SELECT id_todo, title
                FROM Todo_List_Detail
                WHERE (IsDeleted = 0 OR IsDeleted IS NULL)
                  AND (title LIKE @keyword)
                ORDER BY updated_at DESC, id_todo DESC",
                new SQLiteParameter("@keyword", $"%{keyword}%"));
        }

        private static (int completedCount, int totalCount) Db_GetTodoCompletionStats(int todoId)
        {
            var dt = SQLiteHelper.ExecuteQuery(@"
                SELECT 
                    COUNT(*) as total,
                    SUM(CASE WHEN status = 2 THEN 1 ELSE 0 END) as completed
                FROM Todo_List_Item
                WHERE id_todo = @todoId",
                new SQLiteParameter("@todoId", todoId));

            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                int total = Convert.ToInt32(row["total"]);
                int completed = row["completed"] == DBNull.Value ? 0 : Convert.ToInt32(row["completed"]);
                return (completed, total);
            }

            return (0, 0);
        }

        // widths
        private int GetLeftWidth()
        {
            int scrollbar = flp_task_left.VerticalScroll.Visible ? SystemInformation.VerticalScrollBarWidth : 0;
            return Math.Max(50, flp_task_left.ClientSize.Width - flp_task_left.Padding.Horizontal - scrollbar);
        }

        private int GetRightWidth()
        {
            int scrollbar = flp_task_right.VerticalScroll.Visible ? SystemInformation.VerticalScrollBarWidth : 0;
            return Math.Max(200, flp_task_right.ClientSize.Width - flp_task_right.Padding.Horizontal - scrollbar);
        }

        private void ResizeLeftListItemsToFullWidth()
        {
            int w = GetLeftWidth();
            foreach (Control c in flp_task_left.Controls)
            {
                if (c is Panel container)
                {
                    container.Width = w;
                    
                    foreach (Control child in container.Controls)
                    {
                        if (child is Button btn)
                        {
                            if (btn.Name == "btnDelete")
                            {
                                btn.Left = container.Width - 35;
                            }
                            else if (btn.Name == "btnEdit")
                            {
                                btn.Left = container.Width - 70;
                            }
                        }
                    }
                }
            }
        }

        private void ResizeRightDetailToFullWidth()
        {
            _detail.Width = GetRightWidth();
        }

        private void btn_delete_Click_1(object sender, EventArgs e)
        {
            var ok = MessageBox.Show(
                "Xóa Todo này và chuyển vào thùng rác?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (ok != DialogResult.Yes) return;

            Db_DeleteTodo(_selectedTodoId);   // xóa mềm

            _selectedTodoId = -1;            // ✅ reset đã chọn
            _detail.LoadTodo(-1);            // ✅ clear panel bên phải
            LoadTodosToLeftList();           // ✅ reload list
        }

        private void Txt_Search_TextChanged(object? sender, EventArgs e)
        {
            LoadTodosToLeftList();
        }

        public void RefreshData()
        {
            LoadTodosToLeftList();
        }
    }
}
