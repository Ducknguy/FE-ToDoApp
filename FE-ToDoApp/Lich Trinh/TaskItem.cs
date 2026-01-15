using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

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
        }

        private void SetupRightDetail()
        {
            flp_task_right.Controls.Clear();

            _detail.ConnectionString = DatabaseHelper.ConnectionString;
            _detail.AutoSize = false;
            _detail.Margin = new Padding(0);
            _detail.Width = GetRightWidth();

            _detail.TodoHeaderChanged += (s, e) => LoadTodosToLeftList();
            _detail.TodoDeleted += (s, e) =>
            {
                LoadTodosToLeftList();
            };

            flp_task_right.Controls.Add(_detail);
        }

        // LEFT list
        private void LoadTodosToLeftList()
        {
            flp_task_left.SuspendLayout();
            flp_task_left.Controls.Clear();

            var dt = Db_GetTodos();

            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["id_todo"]);
                string title = Convert.ToString(row["title"]) ?? "(no title)";

                // Tạo Panel container chứa ToDoListItem + 2 nút
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
                item.Clicked += (s, e) => SelectTodo(id);

                // Tạo nút Xóa (màu đỏ nhạt)
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

                // Tạo nút Sửa (màu xanh nhạt)
                Button btnEditItem = new Button
                {
                    Name = "btnEdit",
                    Text = "✎",
                    Width = 30,
                    Height = 30,
                    BackColor = Color.FromArgb(173, 216, 230), // LightBlue
                    ForeColor = Color.DarkBlue,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Visible = false,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                };
                btnEditItem.FlatAppearance.BorderSize = 0;
                btnEditItem.Location = new Point(container.Width - 70, 13);
                btnEditItem.Anchor = AnchorStyles.Right | AnchorStyles.Top;

                // Sự kiện Xóa
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

                // Sự kiện Sửa
                btnEditItem.Click += (s, e) =>
                {
                    string newTitle = Microsoft.VisualBasic.Interaction.InputBox(
                        "Nhập tiêu đề mới:", "Sửa detail", title);

                    if (string.IsNullOrWhiteSpace(newTitle) || newTitle == title) return;

                    Db_UpdateTodoTitle(id, newTitle);
                    LoadTodosToLeftList();
                    SelectTodo(id);
                };

                // Thêm vào container
                container.Controls.Add(item);
                container.Controls.Add(btnEditItem);
                container.Controls.Add(btnDeleteItem);

                // BringToFront để nút hiển thị trên cùng
                btnEditItem.BringToFront();
                btnDeleteItem.BringToFront();

                flp_task_left.Controls.Add(container);
            }

            flp_task_left.ResumeLayout();
            ResizeLeftListItemsToFullWidth();

            // auto select first
            if (flp_task_left.Controls.Count > 0 &&
                flp_task_left.Controls[0].Tag is int firstId)
            {
                SelectTodo(firstId);
            }
            else
            {
                _detail.LoadTodo(-1);
            }

            // Reset chế độ sau khi reload
            if (_deleteMode || _editMode)
            {
                _deleteMode = false;
                _editMode = false;
                //btn_delete.Text = "Xóa";
                //btn_edit.Text = "Sửa";
            }

            // Cập nhật nút hiển thị
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
                    
                    // Tìm ToDoListItem trong container
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
            //_editMode = !_editMode;
            //btn_edit.Text = _editMode ? "Xong" : "Sửa";

            //if (_editMode)
            //{
            //    _deleteMode = false;
            //    btn_delete.Text = "Xóa";
            //}

            UpdateItemButtons();
        }

        // ===== CHỨC NĂNG XÓA TODO (GIỐNG TODODETAILITEMCONTROL) =====
        private void btn_delete_Click(object? sender, EventArgs e)
        {
            //_deleteMode = !_deleteMode;
            //btn_delete.Text = _deleteMode ? "Xong" : "Xóa";

            //if (_deleteMode)
            //{
            //    _editMode = false;
            //    btn_edit.Text = "Sửa";
            //}

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

        // ===== DATABASE OPERATIONS =====
        private static DataTable Db_GetTodos()
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand(@"
                SELECT id_todo, title
                FROM Todo_List_Detail
                WHERE (IsDeleted = 0 OR IsDeleted IS NULL)
                ORDER BY updated_at DESC, id_todo DESC;", conn);

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private static int Db_InsertTodo(string title)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            using var cmd = new SqlCommand(@"
                INSERT INTO Todo_List_Detail (title, userid, created_at, updated_at)
                OUTPUT INSERTED.id_todo
                VALUES (@title, 1, GETDATE(), GETDATE());", conn);

            cmd.Parameters.Add("@title", SqlDbType.NVarChar, 255).Value = title;
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private static void Db_UpdateTodoTitle(int todoId, string newTitle)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            using var cmd = new SqlCommand(@"
                UPDATE Todo_List_Detail
                SET title = @title, updated_at = GETDATE()
                WHERE id_todo = @id;", conn);

            cmd.Parameters.AddWithValue("@title", newTitle);
            cmd.Parameters.AddWithValue("@id", todoId);
            cmd.ExecuteNonQuery();
        }

        private static void Db_DeleteTodo(int todoId)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            using var cmd = new SqlCommand(@"
                UPDATE Todo_List_Detail 
                SET IsDeleted = 1, DeletedAt = GETDATE() 
                WHERE id_todo = @id;", conn);
            cmd.Parameters.AddWithValue("@id", todoId);
            cmd.ExecuteNonQuery();
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
                    
                    // Cập nhật vị trí nút khi resize
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
    }
}
