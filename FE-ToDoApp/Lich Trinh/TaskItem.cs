using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace FE_ToDoApp.Lich_Trinh
{
    public partial class TaskItem : UserControl
    {
        // ====== DB ======
        private const string ConnectionString =
            "Data Source=duc;Initial Catalog=ToDoApp;Integrated Security=True;Encrypt=False";

        // ====== State ======
        private int _selectedTodoId = -1;

        public TaskItem()
        {
            InitializeComponent();   // <-- quan trọng: InitializeComponent nằm trong Designer
            ConfigureLayout();
            WireEvents();
            LoadTodosToLeft();
        }

        // ====== Layout ======
        private void ConfigureLayout()
        {
            flp_task_left.FlowDirection = FlowDirection.TopDown;
            flp_task_left.WrapContents = false;
            flp_task_left.AutoScroll = true;

            // QUAN TRỌNG: để item bám trái, không bị "trôi"
            flp_task_left.Padding = new Padding(8, 8, 8, 8);

            // RIGHT
            flp_task_right.FlowDirection = FlowDirection.TopDown;
            flp_task_right.WrapContents = false;
            flp_task_right.AutoScroll = true;
            flp_task_right.Padding = new Padding(12, 12, 12, 12);
        }

        private void WireEvents()
        {
            btn_add.Click += btn_add_Click;

            // resize item full width
            flp_task_left.SizeChanged += (s, e) => ResizeLeftItemsToFullWidth();

            // placeholder (optional)
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

        // ====== Load LEFT from DB ======
        private void LoadTodosToLeft()
        {
            flp_task_left.SuspendLayout();
            flp_task_left.Controls.Clear();

            var dt = Db_GetTodos();

            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["id_todo"]);
                string title = Convert.ToString(row["title"]) ?? "(no title)";

                var item = CreateTodoLeftItem(id, title);
                flp_task_left.Controls.Add(item);
            }

            flp_task_left.ResumeLayout();
            ResizeLeftItemsToFullWidth();

            // auto select item đầu tiên (nếu có)
            if (flp_task_left.Controls.Count > 0 && flp_task_left.Controls[0].Tag is int firstId)
                SelectTodo(firstId);
        }

        private Control CreateTodoLeftItem(int todoId, string title)
        {
            var item = new ToDoListItem
            {
                TodoId = todoId,
                Tag = todoId,
                Dock = DockStyle.None,
                AutoSize = false,
                Height = 56,
                Margin = new Padding(0, 0, 0, 8)
            };

            item.SetTitle(title);

            item.Clicked += (s, e) => SelectTodo(todoId);

            // full width theo flp
            item.Width = flp_task_left.ClientSize.Width
                         - flp_task_left.Padding.Horizontal
                         - SystemInformation.VerticalScrollBarWidth;

            return item;
        }

        private void SelectTodo(int todoId)
        {
            _selectedTodoId = todoId;
            HighlightSelectedLeftItem(todoId);
            LoadTodoDetailToRight(todoId);
        }

        private void HighlightSelectedLeftItem(int selectedTodoId)
        {
            foreach (Control c in flp_task_left.Controls)
            {
                bool isSelected = (c.Tag is int id && id == selectedTodoId);
                c.BackColor = isSelected
                    ? Color.FromArgb(200, 220, 255)
                    : Color.FromArgb(230, 240, 255); // KHÔNG Transparent
            }
        }

        // ====== RIGHT detail ======
        private void LoadTodoDetailToRight(int todoId)
        {
            flp_task_right.SuspendLayout();
            flp_task_right.Controls.Clear();

            DataRow? todo = Db_GetTodoById(todoId);
            if (todo == null)
            {
                flp_task_right.Controls.Add(new Label
                {
                    Text = "Không tìm thấy todo trong DB.",
                    AutoSize = true,
                    Margin = new Padding(12)
                });
                flp_task_right.ResumeLayout();
                return;
            }

            string title = Convert.ToString(todo["title"]) ?? "";
            string desc = todo["description"] == DBNull.Value ? "" : Convert.ToString(todo["description"]) ?? "";
            string statusText = Convert.ToString(todo["status"]) ?? "";

            string created = todo.Table.Columns.Contains("created_at") && todo["created_at"] != DBNull.Value
                ? Convert.ToDateTime(todo["created_at"]).ToString("yyyy-MM-dd HH:mm")
                : "";

            string updated = todo.Table.Columns.Contains("updated_at") && todo["updated_at"] != DBNull.Value
                ? Convert.ToDateTime(todo["updated_at"]).ToString("yyyy-MM-dd HH:mm")
                : "";

            flp_task_right.Controls.Add(MakeTitleLabel(title));
            flp_task_right.Controls.Add(MakeInfoLabel($"Status: {statusText}"));
            if (!string.IsNullOrWhiteSpace(created)) flp_task_right.Controls.Add(MakeInfoLabel($"Created: {created}"));
            if (!string.IsNullOrWhiteSpace(updated)) flp_task_right.Controls.Add(MakeInfoLabel($"Updated: {updated}"));
            flp_task_right.Controls.Add(MakeHeaderLabel("Description"));
            flp_task_right.Controls.Add(MakeBodyLabel(string.IsNullOrWhiteSpace(desc) ? "(empty)" : desc));

            flp_task_right.ResumeLayout();
        }

        private Label MakeTitleLabel(string text) => new Label
        {
            Text = text,
            AutoSize = false,
            Height = 42,
            Dock = DockStyle.Top,
            Font = new Font("Segoe UI", 16f, FontStyle.Bold),
            Margin = new Padding(12, 12, 12, 8)
        };

        private Label MakeHeaderLabel(string text) => new Label
        {
            Text = text,
            AutoSize = true,
            Font = new Font("Segoe UI", 11f, FontStyle.Bold),
            Margin = new Padding(12, 14, 12, 6)
        };

        private Label MakeInfoLabel(string text) => new Label
        {
            Text = text,
            AutoSize = true,
            Margin = new Padding(12, 2, 12, 2)
        };

        private Label MakeBodyLabel(string text) => new Label
        {
            Text = text,
            AutoSize = false,
            Width = Math.Max(200, flp_task_right.ClientSize.Width - 24),
            Height = 200,
            Margin = new Padding(12, 0, 12, 12)
        };

        // ====== ADD ======
        private void btn_add_Click(object? sender, EventArgs e)
        {
            string title = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập tiêu đề ToDo:", "Thêm ToDo", "New ToDo");

            if (string.IsNullOrWhiteSpace(title)) return;

            // bạn có thể làm form nhập description riêng; tạm để null
            string? description = null;

            int newId = Db_InsertTodo(title, description);
            LoadTodosToLeft();   
            SelectTodo(newId);   

        }

        // ====== DB: Todo_List ======
        private static DataTable Db_GetTodos()
        {
            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand(@"
                SELECT id_todo, title, description, status, created_at, updated_at
                FROM Todo_List
                ORDER BY updated_at DESC, id_todo DESC;", conn);

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private static DataRow? Db_GetTodoById(int id)
        {
            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand(@"
                SELECT TOP 1 id_todo, title, description, status, created_at, updated_at
                FROM Todo_List
                WHERE id_todo = @id;", conn);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            return dt.Rows.Count == 0 ? null : dt.Rows[0];
        }

        private static int Db_InsertTodo(string title, string? description)
        {
            using var conn = new SqlConnection(ConnectionString);
            conn.Open();

            using var cmd = new SqlCommand(@"
                INSERT INTO Todo_List (title, description, status, created_at, updated_at)
                OUTPUT INSERTED.id_todo
                VALUES (@title, @desc, @status, GETDATE(), GETDATE());", conn);

            cmd.Parameters.Add("@title", SqlDbType.NVarChar, 255).Value = title;
            cmd.Parameters.Add("@desc", SqlDbType.NVarChar).Value = (object?)description ?? DBNull.Value;

            // Nếu status cột của bạn là nvarchar, đổi SqlDbType.Int -> NVarChar và Value="todo"
            cmd.Parameters.Add("@status", SqlDbType.Int).Value = 0;

            object? result = cmd.ExecuteScalar();
            return Convert.ToInt32(result);
        }

        // ====== Helpers ======
        private void ResizeLeftItemsToFullWidth()
        {
            int scrollbar = flp_task_left.VerticalScroll.Visible
         ? SystemInformation.VerticalScrollBarWidth
         : 0;

            int w = flp_task_left.ClientSize.Width
                    - flp_task_left.Padding.Horizontal
                    - scrollbar;

            w = Math.Max(50, w);

            foreach (Control c in flp_task_left.Controls)
            {
                c.Dock = DockStyle.None;     // FlowLayoutPanel không dùng Dock
                c.AutoSize = false;

                // ✅ bỏ giới hạn width nếu trước đó item bị set MaximumSize
                c.MaximumSize = new Size(0, 0);

                c.Width = w;

                // ✅ ép chiều cao chuẩn
                if (c.Height < 40) c.Height = 56;
                c.MinimumSize = new Size(10, c.Height);
            }

        }

        private static void WireClickRecursive(Control root, Action onClick)
        {
            root.Cursor = Cursors.Hand;
            root.Click += (s, e) => onClick();

            foreach (Control c in root.Controls)
                WireClickRecursive(c, onClick);
        }

        private static void TrySetTodoListTitle(Control item, string title)
        {
            // 1) method SetTitle(string)
            MethodInfo? m = item.GetType().GetMethod("SetTitle", BindingFlags.Public | BindingFlags.Instance);
            if (m != null && m.GetParameters().Length == 1)
            {
                m.Invoke(item, new object[] { title });
                return;
            }

            // 2) property Title
            PropertyInfo? p = item.GetType().GetProperty("Title", BindingFlags.Public | BindingFlags.Instance);
            if (p != null && p.CanWrite)
            {
                p.SetValue(item, title);
                return;
            }

            // 3) label named lblTitle
            Control[] found = item.Controls.Find("lblTitle", true);
            if (found.Length > 0 && found[0] is Label lbl)
            {
                lbl.Text = title;
            }
        }
    }
}
