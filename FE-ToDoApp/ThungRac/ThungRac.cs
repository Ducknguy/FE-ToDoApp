using FE_ToDoApp.ThungRac;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace FE_ToDoApp.ThungRac
{
    public partial class Thungrac : Form
    {

        private bool _isLoadingTrash = false;
        private bool _isInit = true;

        public Thungrac()
        {
            InitializeComponent();

            pTrashItemSample.Visible = false;  // dùng làm template

            // ✅ gắn event qua 1 hàm chung
            chkTodo.CheckedChanged += FilterChanged;
            chkCalendar.CheckedChanged += FilterChanged;

            // ✅ search: vừa bo góc vừa lọc realtime
            txtSearch.TextChanged += (s, e) =>
            {
                UIHelperThungrac.BoGoc(pnlSearch, 14);
                LoadTrash();  // ✅ thêm dòng này
            };

            // Khi form vừa mở → không focus TextBox
            this.Shown += (s, e) => this.ActiveControl = null;
            this.MouseDown += (s, e) => this.ActiveControl = null;

            UIHelperThungrac.VienFocus(
                pnlSearch,
                txtSearch,
                Color.FromArgb(60, 120, 255),
                Color.FromArgb(245, 245, 245)
            );

            // ✅ init checkbox an toàn (không bị gọi LoadTrash 3 lần)
            _isInit = true;
            chkTodo.Checked = true;
            chkCalendar.Checked = true;
            _isInit = false;

            // ✅ chỉ gọi 1 lần
            LoadTrash();
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            if (_isInit) return;
            LoadTrash();
        }


        private void LoadTrash()
        {
            if (_isLoadingTrash) return;
            _isLoadingTrash = true;

            try
            {
                flpTrashList.Controls.Clear();

                DataTable dt = DB.LayDuLieuThungRac();

                // ❌ bỏ đoạn auto bật checkbox trong LoadTrash (đã init ở constructor)
                // if (!chkTodo.Checked && !chkWeekly.Checked && !chkCalendar.Checked) ...

                if (dt.Rows.Count == 0)
                {
                    flpTrashList.Visible = false;
                    lblEmptyIcon.Visible = true;
                    lblEmptyText.Visible = true;
                    return;
                }

                flpTrashList.Visible = true;
                lblEmptyIcon.Visible = false;
                lblEmptyText.Visible = false;

                string keyword = txtSearch.Text.Trim().ToLower();

                foreach (DataRow row in dt.Rows)
                {
                    int itemId = Convert.ToInt32(row["ItemId"]);
                    string title = row["Title"].ToString();
                    string sourceTable = row["SourceTable"].ToString();

                    if (!string.IsNullOrEmpty(keyword) && !title.ToLower().Contains(keyword))
                        continue;

                    DateTime? deletedAt = null;
                    if (row["DeletedAt"] != DBNull.Value)
                        deletedAt = Convert.ToDateTime(row["DeletedAt"]);

                    string type = (sourceTable == "Todo") ? "Todo" : "Calendar";
                    if (type == "Todo" && !chkTodo.Checked) continue;
                    if (type == "Calendar" && !chkCalendar.Checked) continue;

                    Panel uiItem = TaoItemThungRac(title, type, deletedAt, itemId, sourceTable);
                    flpTrashList.Controls.Add(uiItem);
                }

                if (flpTrashList.Controls.Count == 0)
                {
                    flpTrashList.Visible = false;
                    lblEmptyIcon.Visible = true;
                    lblEmptyText.Visible = true;
                }
            }
            finally
            {
                _isLoadingTrash = false;
            }
        }


        private Panel TaoItemThungRac(string title, string type, DateTime? deletedAt, int itemId, string sourceTable)
        {
            // ====== panel item ======
            Panel item = new Panel();
            item.BackColor = pTrashItemSample.BackColor;
            item.BorderStyle = pTrashItemSample.BorderStyle;
            item.Size = pTrashItemSample.Size;
            item.Margin = pTrashItemSample.Margin;

            // ====== thanh màu bên trái ======
            Panel pColor = new Panel();
            pColor.Name = "pTypeColor";
            pColor.Location = pTypeColor.Location;
            pColor.Size = pTypeColor.Size;

            // ====== label title ======
            Label lblTitle = new Label();
            lblTitle.Name = "lblTrashTitle";
            lblTitle.Font = lblTrashTitle.Font;
            lblTitle.ForeColor = lblTrashTitle.ForeColor;
            lblTitle.Location = lblTrashTitle.Location;
            lblTitle.Size = lblTrashTitle.Size;
            lblTitle.Text = title;

            // ====== meta ======
            Label lblMeta = new Label();
            lblMeta.Name = "lblTrashMeta";
            lblMeta.Font = lblTrashMeta.Font;
            lblMeta.ForeColor = lblTrashMeta.ForeColor;
            lblMeta.Location = lblTrashMeta.Location;
            lblMeta.Size = lblTrashMeta.Size;

            if (deletedAt.HasValue)
                lblMeta.Text = $"Đã xóa: {deletedAt.Value:dd/MM/yyyy HH:mm}";
            else
                lblMeta.Text = "Đã xóa: (không rõ)";

            // ====== tag loại ======
            Label lblTag = new Label();
            lblTag.Name = "lblTypeTag";
            lblTag.Font = lblTypeTag.Font;
            lblTag.ForeColor = lblTypeTag.ForeColor;
            lblTag.BackColor = lblTypeTag.BackColor;
            lblTag.Location = lblTypeTag.Location;
            lblTag.Size = lblTypeTag.Size;
            lblTag.TextAlign = lblTypeTag.TextAlign;
            lblTag.Text = type;

            // ====== nút restore ======
            Button btnR = new Button();
            btnR.Name = "btnRestore";
            btnR.BackColor = btnRestore.BackColor;
            btnR.FlatStyle = btnRestore.FlatStyle;
            btnR.FlatAppearance.BorderSize = btnRestore.FlatAppearance.BorderSize;
            btnR.Font = btnRestore.Font;
            btnR.Location = btnRestore.Location;
            btnR.Size = btnRestore.Size;
            btnR.Text = btnRestore.Text;
            btnR.Cursor = btnRestore.Cursor;
            btnR.UseVisualStyleBackColor = btnRestore.UseVisualStyleBackColor;

            // ====== nút delete forever ======
            Button btnD = new Button();
            btnD.Name = "btnDeleteForever";
            btnD.Font = btnDeleteForever.Font;
            btnD.ForeColor = btnDeleteForever.ForeColor;
            btnD.Location = btnDeleteForever.Location;
            btnD.Size = btnDeleteForever.Size;
            btnD.Text = btnDeleteForever.Text;
            btnD.Cursor = btnDeleteForever.Cursor;
            btnD.UseVisualStyleBackColor = btnDeleteForever.UseVisualStyleBackColor;

            // ====== SET MÀU theo loại ======
            SetTypeStyle(type, pColor, lblTag);

            // ====== EVENT nút bấm ======
            btnR.Click += (s, e) =>
            {
                DB.KhoiPhuc(sourceTable, itemId);
                LoadTrash(); // reload
            };

            btnD.Click += (s, e) =>
            {
                var confirm = MessageBox.Show(
                    "Xóa vĩnh viễn mục này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    DB.XoaVinhVien(sourceTable, itemId);
                    LoadTrash(); // reload
                }
            };

            // ====== add vào panel item ======
            item.Controls.Add(btnD);
            item.Controls.Add(btnR);
            item.Controls.Add(lblTag);
            item.Controls.Add(lblMeta);
            item.Controls.Add(lblTitle);
            item.Controls.Add(pColor);

            return item;
        }

        private void SetTypeStyle(string type, Panel pColor, Label lblTag)
        {
            // bạn chỉnh màu theo gu bạn
            if (type == "Todo")
            {
                pColor.BackColor = Color.DodgerBlue;
                lblTag.BackColor = Color.LightSkyBlue;
                lblTag.ForeColor = Color.DarkBlue;
            }
            else if (type == "Calendar")
            {
                pColor.BackColor = Color.MediumVioletRed;
                lblTag.BackColor = Color.MistyRose;
                lblTag.ForeColor = Color.Maroon;
            }
            else
            {
                pColor.BackColor = Color.Gray;
                lblTag.BackColor = Color.Gainsboro;
                lblTag.ForeColor = Color.DimGray;
            }
        }

        private void Thungrac_Load(object sender, EventArgs e)
        {

        }
    }
}
