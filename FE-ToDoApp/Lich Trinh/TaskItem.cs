using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace FE_ToDoApp.Lich_Trinh
{
    public partial class TaskItem : UserControl
    {
        private const string ConnectionString =
            "Data Source=GIANG;Initial Catalog=ToDoApp;Integrated Security=True;Encrypt=False";

        private int _selectedTodoId = -1;


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

        // RIGHT detail control pinned
        private void SetupRightDetail()
        {
            flp_task_right.Controls.Clear();

            _detail.ConnectionString = ConnectionString;
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

                var item = new ToDoListItem
                {
                    TodoId = id,
                    Tag = id,
                    Height = 56,
                    AutoSize = false,
                    Margin = new Padding(0, 0, 0, 8)
                };

                item.SetTitle(title);
                item.Width = GetLeftWidth();
                item.Clicked += (s, e) => SelectTodo(id);

                flp_task_left.Controls.Add(item);
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
        }

        private void SelectTodo(int todoId)
        {
            _selectedTodoId = todoId;

            foreach (Control c in flp_task_left.Controls)
            {
                bool selected = c.Tag is int id && id == todoId;
                if (c is ToDoListItem t) t.SetSelected(selected);
            }

            _detail.Width = GetRightWidth();
            _detail.LoadTodo(todoId);
        }

        // ADD Todo detail
        private void btn_add_Click(object? sender, EventArgs e)
        {
            string title = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập tiêu đề detail:", "Thêm detail", "New detail");

            if (string.IsNullOrWhiteSpace(title)) return;

            int newId = Db_InsertTodo(title);
            LoadTodosToLeftList();
            SelectTodo(newId);
        }

        // DB Todo_List_Detail
        private static DataTable Db_GetTodos()
        {
            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand(@"
                SELECT id_todo, title
                FROM Todo_List_Detail
                ORDER BY updated_at DESC, id_todo DESC;", conn);

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private static int Db_InsertTodo(string title)
        {
            using var conn = new SqlConnection(ConnectionString);
            conn.Open();

            using var cmd = new SqlCommand(@"
                INSERT INTO Todo_List_Detail (title, created_at, updated_at)
                OUTPUT INSERTED.id_todo
                VALUES (@title, GETDATE(), GETDATE());", conn);

            cmd.Parameters.Add("@title", SqlDbType.NVarChar, 255).Value = title;
            return Convert.ToInt32(cmd.ExecuteScalar());
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
            foreach (Control c in flp_task_left.Controls) c.Width = w;
        }

        private void ResizeRightDetailToFullWidth()
        {
            _detail.Width = GetRightWidth();
        }
    }
}
