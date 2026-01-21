using System;
using System.Data.SQLite;
using System.Windows.Forms;
using FE_ToDoApp.Database;
using FE_ToDoApp.WeekList.Data;

namespace FE_ToDoApp.ThemNhanh
{
    public partial class QuickAdd : Form
    {
        private QuickAddTodo? todoControl;
        private QuickAddWeek? weekControl;

        public event EventHandler? TodoAdded;
        public event EventHandler? WeekAdded;
        public int AddedCategoryId { get; private set; }
        public string AddedType { get; private set; } = string.Empty;

        public QuickAdd()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            comboBox1.SelectedIndex = 0;
            LoadControlForSelectedType();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadControlForSelectedType();
        }

        private void LoadControlForSelectedType()
        {
            mainPanel.Controls.Clear();

            if (comboBox1.SelectedIndex == 0) // Todo
            {
                todoControl = new QuickAddTodo
                {
                    Dock = DockStyle.Fill
                };
                mainPanel.Controls.Add(todoControl);
            }
            else if (comboBox1.SelectedIndex == 1) // Week
            {
                weekControl = new QuickAddWeek
                {
                    Dock = DockStyle.Fill
                };
                mainPanel.Controls.Add(weekControl);
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) // Todo
            {
                SaveTodo();
            }
            else if (comboBox1.SelectedIndex == 1) // Week
            {
                SaveWeek();
            }
        }

        private void SaveTodo()
        {
            if (todoControl == null)
            {
                MessageBox.Show("Có lỗi xảy ra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!todoControl.ValidateInput())
            {
                return;
            }

            try
            {
                string title = todoControl.TodoTitle;
                DateTime date = todoControl.TodoDate;

                int newId = InsertTodoToDatabase(title, date);

                MessageBox.Show($"Đã thêm Todo thành công!\nTiêu đề: {title}", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                todoControl.ClearInputs();
                
                AddedType = "Todo";
                TodoAdded?.Invoke(this, EventArgs.Empty);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm Todo: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveWeek()
        {
            if (weekControl == null)
            {
                MessageBox.Show("Có lỗi xảy ra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!weekControl.ValidateInput())
            {
                return;
            }

            try
            {
                string categoryName = weekControl.CategoryName;
                DateTime weekStart = weekControl.WeekStartDate;
                DateTime weekEnd = weekControl.WeekEndDate;
                string taskTitle = weekControl.TaskTitle;
                string taskDescription = weekControl.TaskDescription;
                int dayOfWeek = weekControl.DayOfWeek;

                var categoryRepo = new WeekCategoryRepository();
                int categoryId = categoryRepo.Insert(categoryName, weekStart, weekEnd);
                AddedCategoryId = categoryId;

                var taskRepo = new WeekTaskRepository();
                int taskId = taskRepo.Insert(categoryId, weekStart, dayOfWeek, taskTitle);

                if (!string.IsNullOrWhiteSpace(taskDescription))
                {
                    UpdateTaskDescription(taskId, taskDescription);
                }

                MessageBox.Show(
                    $"Đã thêm Week thành công!\n\n" +
                    $"Nhóm: {categoryName}\n" +
                    $"Tuần: {weekStart:dd/MM/yyyy} - {weekEnd:dd/MM/yyyy}\n" +
                    $"Công việc: {taskTitle}",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                weekControl.ClearInputs();
                
                AddedType = "Week";
                WeekAdded?.Invoke(this, EventArgs.Empty);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm Week: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private int InsertTodoToDatabase(string title, DateTime date)
        {
            string sql = @"
                INSERT INTO Todo_List_Detail (title, userid, created_at, updated_at, IsDeleted)
                VALUES (@title, 1, @date, datetime('now'), 0);
                
                SELECT last_insert_rowid();";

            var result = SQLiteHelper.ExecuteScalar(sql,
                new SQLiteParameter("@title", title),
                new SQLiteParameter("@date", date));

            return Convert.ToInt32(result);
        }

        private void UpdateTaskDescription(int taskId, string description)
        {
            string sql = @"
                UPDATE WeekCategory_item 
                SET Description = @Description, UpdatedAt = datetime('now')
                WHERE Id_weekly = @TaskId";

            SQLiteHelper.ExecuteNonQuery(sql,
                new SQLiteParameter("@TaskId", taskId),
                new SQLiteParameter("@Description", description));
        }
    }
}