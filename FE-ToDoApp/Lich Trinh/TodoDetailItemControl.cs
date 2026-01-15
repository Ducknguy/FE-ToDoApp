using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FE_ToDoApp.Lich_Trinh
{
    public partial class TodoDetailItemControl : UserControl
    {
        // ===== PUBLIC (TaskItem dùng) =====
        public string ConnectionString { get; set; } = DatabaseHelper.ConnectionString;

        public int TodoId { get; private set; } = -1;

        public event EventHandler? TodoDeleted;
        public event EventHandler? TodoHeaderChanged;

        // ===== STATE =====
        private bool _deleteMode = false;
        private bool _editMode = false;

        // Giữ lại footer để không bị Clear mất
        private Control? _footer;

        public TodoDetailItemControl()
        {
            InitializeComponent();

            // tìm footer theo Name trong Designer
            _footer = FindFooterControl();

            btnAdd.Click += (s, e) => AddItem();
            btnDelete.Click += (s, e) => ToggleDeleteMode();
            btnEdit.Click += (s, e) => ToggleEditMode();

            // Resize rows khi flpBody thay đổi kích thước
            flpBody.SizeChanged += (s, e) => ResizeAllRows();

            EnsureFooterIsLast();
        }

        // =============================
        // LOAD TODO
        // =============================
        public void LoadTodo(int todoId)
        {
            TodoId = todoId;

            if (TodoId <= 0)
            {
                lblTitle.Text = "Chưa chọn detail";
                //TodoHeaderChanged?.Invoke(this, EventArgs.Empty);

                // nút vẫn phải nhìn thấy (đừng clear footer)
                btnAdd.Enabled = false;   // add item cần TodoId
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
            //TodoHeaderChanged?.Invoke(this, EventArgs.Empty);

            LoadItems();
            EnsureFooterIsLast();
        }

        // =============================
        // MODE
        // =============================
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
                // footer không phải row
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

        // =============================
        // LOAD ITEMS
        // =============================
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

                var row = CreateRow(
                    Convert.ToInt32(r["id_item"]),
                    itemText,
                    Convert.ToByte(r["status"])
                );

                AddRowBeforeFooter(row);
            }

            EnsureFooterIsLast();
            UpdateRowButtons();

            // Resize lại tất cả rows sau khi load
            if (flpBody.Width > 0)
            {
                ResizeAllRows();
            }
        }

        // =============================
        // ROW
        // =============================
        private Panel CreateRow(int itemId, string text, byte status)
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

            string displayText = string.IsNullOrWhiteSpace(text) ? "[EMPTY TEXT]" : text;
            
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

            // ===== STATUS =====
            chk.CheckedChanged += (s, e) =>
            {
                Db_UpdateItemStatus(itemId, chk.Checked ? (byte)2 : (byte)0);
                ApplyDoneStyle(row, lbl, chk, lblDoneIcon, chk.Checked);
            };

            // ===== DELETE =====
            btnDelete.Click += (s, e) =>
            {
                Db_DeleteItem(itemId);
                TodoDeleted?.Invoke(this, EventArgs.Empty);
                LoadItems();
            };

            // ===== EDIT =====
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

            // Apply initial style
            ApplyDoneStyle(row, lbl, chk, lblDoneIcon, chk.Checked);

            return row;
        }

        // =============================
        // ACTIONS
        // =============================
        private void AddItem()
        {
            if (TodoId <= 0) return;

            string text = Interaction.InputBox("Nhập nội dung", "Thêm");
            if (string.IsNullOrWhiteSpace(text)) return;

            Db_InsertItem(TodoId, text);
            LoadItems();
        }

        private void EditItem(int itemId)
        {
            string current = Db_GetItemText(itemId);
            string edited = Interaction.InputBox("Sửa nội dung", "Sửa", current);

            if (string.IsNullOrWhiteSpace(edited) || edited == current) return;

            Db_UpdateItemText(itemId, edited);
            LoadItems();
        }

        // =============================
        // HELPERS: Giữ footer, chỉ xóa rows
        // =============================
        private void ClearItemRowsOnly()
        {
            // xóa tất cả control trong flpBody TRỪ footer
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
            // nếu Designer của bạn đặt footer là pnlFooter
            // và footer là con trực tiếp của flpBody
            foreach (Control c in flpBody.Controls)
            {
                if (c.Name == "pnlFooter") return c;
            }

            // fallback: tìm sâu hơn (trường hợp footer nằm nested)
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

            // nếu footer đang không nằm trong flpBody thì add vào
            if (_footer.Parent != flpBody)
            {
                flpBody.Controls.Add(_footer);
            }

            // đưa footer xuống cuối
            flpBody.Controls.SetChildIndex(_footer, flpBody.Controls.Count - 1);
        }

        private void AddRowBeforeFooter(Control row)
        {
            if (_footer == null) _footer = FindFooterControl();

            flpBody.Controls.Add(row);

            // nếu có footer thì đưa row lên trước footer
            if (_footer != null && _footer.Parent == flpBody)
            {
                int footerIndex = flpBody.Controls.GetChildIndex(_footer);
                flpBody.Controls.SetChildIndex(row, footerIndex);
            }
        }

        // =============================
        // RESIZE ROWS
        // =============================
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

                    // Resize label và buttons trong row
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

        // =============================
        // STYLE
        // =============================
        private void ApplyDoneStyle(Panel row, Label lbl, CheckBox chk, Label doneIcon, bool done)
        {
            if (done)
            {
                // Row background - màu xanh nhạt
                row.BackColor = Color.FromArgb(240, 255, 240); // Light green
                
                // Label - gạch ngang + màu xám + opacity effect
                lbl.Font = new Font(lbl.Font, FontStyle.Strikeout);
                lbl.ForeColor = Color.FromArgb(120, 120, 120); // Darker gray
                
                // Checkbox - màu xanh lá khi checked
                chk.ForeColor = Color.Green;
                
                // Show done icon
                doneIcon.Visible = true;
            }
            else
            {
                // Row background - trắng
                row.BackColor = Color.White;
                
                // Label - bình thường
                lbl.Font = new Font(lbl.Font, FontStyle.Regular);
                lbl.ForeColor = Color.Black;
                
                // Checkbox - màu mặc định
                chk.ForeColor = Color.Black;
                
                // Hide done icon
                doneIcon.Visible = false;
            }
        }

        // =============================
        // DB (GIỮ API CŨ)
        // =============================
        private string GetTodoTitle(int todoId)
        {
            if (todoId <= 0) return "";

            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand(@"
            SELECT title
            FROM Todo_List_Detail
            WHERE id_todo = @id;", conn);

            cmd.Parameters.AddWithValue("@id", todoId);

            conn.Open();
            var obj = cmd.ExecuteScalar();
            return obj == null ? "" : Convert.ToString(obj);
        }

        private DataTable Db_GetItems(int todoId)
        {
            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand(@"
            SELECT id_item, item_detail, status
            FROM Todo_List_Item
            WHERE id_todo = @todoId
            ORDER BY id_item DESC;", conn);

            cmd.Parameters.AddWithValue("@todoId", todoId);

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        private void Db_InsertItem(int todoId, string text)
        {
            using var conn = new SqlConnection(ConnectionString);
            conn.Open();

            using var cmd = new SqlCommand(@"
                INSERT INTO Todo_List_Item (id_todo, item_detail, status)
                VALUES (@todoId, @item_detail, 0);", conn);

            cmd.Parameters.AddWithValue("@todoId", todoId);
            cmd.Parameters.AddWithValue("@item_detail", text);

            cmd.ExecuteNonQuery();
        }
        private void Db_UpdateItemText(int itemId, string text)
        {
            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand(@"
        UPDATE Todo_List_Item
        SET item_detail = @item_detail
        WHERE id_item = @id;", conn);

            cmd.Parameters.AddWithValue("@item_detail", text);
            cmd.Parameters.AddWithValue("@id", itemId);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
        private void Db_UpdateItemStatus(int itemId, byte status)
        {
            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand(@"
        UPDATE Todo_List_Item
        SET status = @status
        WHERE id_item = @id;", conn);

            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@id", itemId);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
        private void Db_DeleteItem(int itemId)
        {
            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand(@"
        DELETE FROM Todo_List_Item
        WHERE id_item = @id;", conn);

            cmd.Parameters.AddWithValue("@id", itemId);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
        private string Db_GetItemText(int itemId)
        {
            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand(@"
        SELECT item_detail
        FROM Todo_List_Item
        WHERE id_item = @id;", conn);

            cmd.Parameters.AddWithValue("@id", itemId);

            conn.Open();
            var obj = cmd.ExecuteScalar();
            return obj == null ? "" : Convert.ToString(obj);
        }
    }
}
