using Microsoft.VisualBasic;
using System.Data;
using System.Data.SQLite;
using FE_ToDoApp.Database;


namespace FE_ToDoApp.Lich_Trinh
{
    public partial class TodoDetailItemControl : UserControl
    {
        public int TodoId { get; private set; } = -1;

        public event EventHandler? TodoDeleted;
        public event EventHandler? TodoHeaderChanged;
        public event EventHandler? TodoItemStatusChanged;

        private bool _deleteMode = false;
        private bool _editMode = false;

        private Control? _footer;

        public TodoDetailItemControl()
        {
            InitializeComponent();
            _footer = FindFooterControl();

            btnAdd.Click += (s, e) => AddItem();
            btnDelete.Click += (s, e) => ToggleDeleteMode();
            btnEdit.Click += (s, e) => ToggleEditMode();
            flpBody.SizeChanged += (s, e) => ResizeAllRows();

            EnsureFooterIsLast();
        }
        public void LoadTodo(int todoId)
        {
            TodoId = todoId;

            if (TodoId <= 0)
            {
                lblTitle.Text = "Chưa chọn detail";
                btnAdd.Enabled = false; 
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;

                ClearItemRowsOnly();
                EnsureFooterIsLast();
                return;
            }

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;

            lblTitle.Text = GetTodoTitle(todoId);

            LoadItems();
            EnsureFooterIsLast();
        }
        private void ToggleDeleteMode()
        {
            _deleteMode = !_deleteMode;
            btnDelete.Text = _deleteMode ? "Xong" : "Xóa";

            if (_deleteMode) _editMode = false;

            UpdateRowButtons();
        }

        private void ToggleEditMode()
        {
            _editMode = !_editMode;
            btnEdit.Text = _editMode ? "Xong" : "Sửa";

            if (_editMode) _deleteMode = false;

            UpdateRowButtons();
        }

        private void UpdateRowButtons()
        {
            foreach (Control c in flpBody.Controls)
            {
                if (_footer != null && ReferenceEquals(c, _footer)) continue;

                if (c is Panel row)
                {
                    var del = row.Controls["btnDelete"];
                    if (del != null) del.Visible = _deleteMode;

                    var ed = row.Controls["btnEdit"];
                    if (ed != null) ed.Visible = _editMode;
                }
            }
        }
        private void LoadItems()
        {
            ClearItemRowsOnly();

            if (TodoId <= 0)
            {
                EnsureFooterIsLast();
                return;
            }

            DataTable dt = Db_GetItems(TodoId);
            foreach (DataRow r in dt.Rows)
            {
                string itemText = Convert.ToString(r["item_detail"]) ?? "";
                DateTime? reminderTime = r["ReminderTime"] == DBNull.Value ? null : Convert.ToDateTime(r["ReminderTime"]);

                var row = CreateRow(
                    Convert.ToInt32(r["id_item"]),
                    itemText,
                    Convert.ToByte(r["status"]),
                    reminderTime
                );

                AddRowBeforeFooter(row);
            }

            EnsureFooterIsLast();
            UpdateRowButtons();
            if (flpBody.Width > 0)
            {
                ResizeAllRows();
            }
        }
        private Panel CreateRow(int itemId, string text, byte status, DateTime? reminderTime = null)
        {
            int rowWidth = Math.Max(400, flpBody.Width > 0 ? flpBody.Width - 12 : 500);

            Panel row = new Panel
            {
                Height = 40,
                Width = rowWidth,
                Margin = new Padding(4, 4, 4, 4),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Tag = itemId
            };

            CheckBox chk = new CheckBox
            {
                Location = new Point(4, 10),
                Checked = status == 2,
                AutoSize = false,
                Width = 20,
                Height = 20,
                FlatStyle = FlatStyle.Flat
            };
            string displayText;
            if (reminderTime.HasValue)
            {
                string timeStr = reminderTime.Value.ToString("HH:mm dd/MM");
                displayText = $"🔔 {timeStr} | {text}";
            }
            else
            {
                displayText = string.IsNullOrWhiteSpace(text) ? "[EMPTY TEXT]" : text;
            }

            Label lbl = new Label
            {
                Text = displayText,
                Location = new Point(28, 10),
                Width = rowWidth - 80,
                Height = 24,
                AutoSize = false,
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Icon hoàn thành (ban đầu ẩn)
            Label lblDoneIcon = new Label
            {
                Name = "lblDoneIcon",
                Text = "✓",
                Location = new Point(rowWidth - 110, 8),
                Width = 30,
                Height = 24,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.Green,
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false
            };

            Button btnDelete = new Button
            {
                Name = "btnDelete",
                Text = "X",
                Width = 30,
                Height = 26,
                Left = rowWidth - 35,
                Top = 7,
                Visible = false,
                BackColor = Color.LightCoral
            };

            Button btnEdit = new Button
            {
                Name = "btnEdit",
                Text = "✎",
                Width = 30,
                Height = 26,
                Left = rowWidth - 70,
                Top = 7,
                Visible = false,
                BackColor = Color.LightBlue
            };

            chk.CheckedChanged += (s, e) =>
            {
                Db_UpdateItemStatus(itemId, chk.Checked ? (byte)2 : (byte)0);
                ApplyDoneStyle(row, lbl, chk, lblDoneIcon, chk.Checked);
                TodoItemStatusChanged?.Invoke(this, EventArgs.Empty);
            };
            btnDelete.Click += (s, e) =>
            {
                Db_DeleteItem(itemId);
                TodoDeleted?.Invoke(this, EventArgs.Empty);
                LoadItems();
            };
            btnEdit.Click += (s, e) =>
            {
                EditItem(itemId);
            };

            row.Controls.Add(chk);
            row.Controls.Add(lbl);
            row.Controls.Add(lblDoneIcon);
            row.Controls.Add(btnDelete);
            row.Controls.Add(btnEdit);

            lbl.BringToFront();
            lblDoneIcon.BringToFront();
            ApplyDoneStyle(row, lbl, chk, lblDoneIcon, chk.Checked);

            return row;
        }
        private void ClearItemRowsOnly()
        {
            for (int i = flpBody.Controls.Count - 1; i >= 0; i--)
            {
                var c = flpBody.Controls[i];
                if (_footer != null && ReferenceEquals(c, _footer)) continue;
                flpBody.Controls.RemoveAt(i);
                c.Dispose();
            }
        }

        private Control? FindFooterControl()
        {
       
            foreach (Control c in flpBody.Controls)
            {
                if (c.Name == "pnlFooter") return c;
            }
            var found = FindControlRecursive(flpBody, "pnlFooter");
            return found;
        }

        private static Control? FindControlRecursive(Control root, string name)
        {
            foreach (Control c in root.Controls)
            {
                if (c.Name == name) return c;
                var deep = FindControlRecursive(c, name);
                if (deep != null) return deep;
            }
            return null;
        }

        private void EnsureFooterIsLast()
        {
            if (_footer == null) _footer = FindFooterControl();
            if (_footer == null) return;

            if (_footer.Parent != flpBody)
            {
                flpBody.Controls.Add(_footer);
            }
            flpBody.Controls.SetChildIndex(_footer, flpBody.Controls.Count - 1);
        }

        private void AddRowBeforeFooter(Control row)
        {
            if (_footer == null) _footer = FindFooterControl();

            flpBody.Controls.Add(row);

            if (_footer != null && _footer.Parent == flpBody)
            {
                int footerIndex = flpBody.Controls.GetChildIndex(_footer);
                flpBody.Controls.SetChildIndex(row, footerIndex);
            }
        }

        private void ResizeAllRows()
        {
            if (flpBody.Width <= 0) return;

            int rowWidth = Math.Max(400, flpBody.Width - 12);

            foreach (Control c in flpBody.Controls)
            {
                if (_footer != null && ReferenceEquals(c, _footer)) continue;

                if (c is Panel row)
                {
                    row.Width = rowWidth;
                    foreach (Control child in row.Controls)
                    {
                        if (child is Label lbl && child.Name != "lblDoneIcon")
                        {
                            lbl.Width = rowWidth - 80;
                        }
                        else if (child is Label doneIcon && child.Name == "lblDoneIcon")
                        {
                            doneIcon.Left = rowWidth - 110;
                        }
                        else if (child is Button btn && btn.Name == "btnDelete")
                        {
                            btn.Left = rowWidth - 35;
                        }
                        else if (child is Button btn2 && btn2.Name == "btnEdit")
                        {
                            btn2.Left = rowWidth - 70;
                        }
                    }
                }
            }
        }

        private void ApplyDoneStyle(Panel row, Label lbl, CheckBox chk, Label doneIcon, bool done)
        {
            if (done)
            {
                row.BackColor = Color.FromArgb(240, 255, 240); 
                lbl.Font = new Font(lbl.Font, FontStyle.Strikeout);
                lbl.ForeColor = Color.FromArgb(120, 120, 120);
                chk.ForeColor = Color.Green;
                doneIcon.Visible = true;
            }
            else
            {
                row.BackColor = Color.White;
                lbl.Font = new Font(lbl.Font, FontStyle.Regular);
                lbl.ForeColor = Color.Black;
                chk.ForeColor = Color.Black;
                doneIcon.Visible = false;
            }
        }
        private string GetTodoTitle(int todoId)
        {
            if (todoId <= 0) return "";

            var obj = SQLiteHelper.ExecuteScalar(@"
                SELECT title
                FROM Todo_List_Detail
                WHERE id_todo = @id",
                new SQLiteParameter("@id", todoId));

            return obj == null ? "" : Convert.ToString(obj);
        }

        private DataTable Db_GetItems(int todoId)
        {
            return SQLiteHelper.ExecuteQuery(@"
                SELECT id_item, item_detail, status, ReminderTime
                FROM Todo_List_Item
                WHERE id_todo = @todoId
                ORDER BY id_item DESC",
                new SQLiteParameter("@todoId", todoId));
        }

        private void Db_InsertItem(int todoId, string text)
        {
            SQLiteHelper.ExecuteNonQuery(@"
                INSERT INTO Todo_List_Item (id_todo, item_detail, status)
                VALUES (@todoId, @item_detail, 0)",
                new SQLiteParameter("@todoId", todoId),
                new SQLiteParameter("@item_detail", text));
        }

        private void Db_UpdateItemText(int itemId, string text)
        {
            SQLiteHelper.ExecuteNonQuery(@"
                UPDATE Todo_List_Item
                SET item_detail = @item_detail
                WHERE id_item = @id",
                new SQLiteParameter("@item_detail", text),
                new SQLiteParameter("@id", itemId));
        }

        private void Db_UpdateItemStatus(int itemId, byte status)
        {
            SQLiteHelper.ExecuteNonQuery(@"
                UPDATE Todo_List_Item
                SET status = @status
                WHERE id_item = @id",
                new SQLiteParameter("@status", status),
                new SQLiteParameter("@id", itemId));
        }

        private void Db_DeleteItem(int itemId)
        {
            SQLiteHelper.ExecuteNonQuery(@"
                DELETE FROM Todo_List_Item
                WHERE id_item = @id",
                new SQLiteParameter("@id", itemId));
        }

        private string Db_GetItemText(int itemId)
        {
            var obj = SQLiteHelper.ExecuteScalar(@"
                SELECT item_detail
                FROM Todo_List_Item
                WHERE id_item = @id",
                new SQLiteParameter("@id", itemId));

            return obj == null ? "" : Convert.ToString(obj);
        }

        private void ConfigureLayout()
        {
            // LEFT = LIST
            //... existing code
        }
    }
}
