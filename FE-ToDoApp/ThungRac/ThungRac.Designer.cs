namespace FE_ToDoApp.ThungRac
{
    partial class Thungrac
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtSearch = new TextBox();
            lblEmptyIcon = new Label();
            lblEmptyText = new Label();
            lblFooter = new Label();
            pnlSearch = new Panel();
            pnlFilter = new Panel();
            chkTodo = new CheckBox();
            chkWeekly = new CheckBox();
            chkCalendar = new CheckBox();
            flpTrashList = new FlowLayoutPanel();
            pTrashItemSample = new Panel();
            btnDeleteForever = new Button();
            btnRestore = new Button();
            lblTypeTag = new Label();
            lblTrashMeta = new Label();
            lblTrashTitle = new Label();
            pTypeColor = new Panel();
            pnlSearch.SuspendLayout();
            pnlFilter.SuspendLayout();
            flpTrashList.SuspendLayout();
            pTrashItemSample.SuspendLayout();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.WhiteSmoke;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 15F);
            txtSearch.ForeColor = Color.FromArgb(80, 80, 80);
            txtSearch.Location = new Point(10, 7);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm trang trong Thùng rác";
            txtSearch.Size = new Size(376, 32);
            txtSearch.TabIndex = 0;
            // 
            // lblEmptyIcon
            // 
            lblEmptyIcon.Font = new Font("Segoe UI Emoji", 32F);
            lblEmptyIcon.ForeColor = Color.Gray;
            lblEmptyIcon.Location = new Point(0, 195);
            lblEmptyIcon.Name = "lblEmptyIcon";
            lblEmptyIcon.Size = new Size(420, 60);
            lblEmptyIcon.TabIndex = 3;
            lblEmptyIcon.Text = "🗑";
            lblEmptyIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEmptyText
            // 
            lblEmptyText.Font = new Font("Segoe UI", 10F);
            lblEmptyText.ForeColor = Color.Gray;
            lblEmptyText.Location = new Point(0, 255);
            lblEmptyText.Name = "lblEmptyText";
            lblEmptyText.Size = new Size(420, 25);
            lblEmptyText.TabIndex = 2;
            lblEmptyText.Text = "Không có kết quả";
            lblEmptyText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFooter
            // 
            lblFooter.BackColor = Color.FromArgb(224, 224, 224);
            lblFooter.Dock = DockStyle.Bottom;
            lblFooter.Font = new Font("Segoe UI", 8.5F);
            lblFooter.ForeColor = Color.Gray;
            lblFooter.Location = new Point(0, 470);
            lblFooter.Name = "lblFooter";
            lblFooter.Size = new Size(420, 30);
            lblFooter.TabIndex = 4;
            lblFooter.Text = "Các trang trong Thùng rác quá 30 ngày sẽ tự động bị xóa";
            lblFooter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.WhiteSmoke;
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Location = new Point(12, 12);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Padding = new Padding(10, 7, 10, 7);
            pnlSearch.Size = new Size(396, 46);
            pnlSearch.TabIndex = 1;
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.WhiteSmoke;
            pnlFilter.Controls.Add(chkTodo);
            pnlFilter.Controls.Add(chkWeekly);
            pnlFilter.Controls.Add(chkCalendar);
            pnlFilter.Location = new Point(12, 64);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(396, 32);
            pnlFilter.TabIndex = 0;
            // 
            // chkTodo
            // 
            chkTodo.AutoSize = true;
            chkTodo.BackColor = Color.WhiteSmoke;
            chkTodo.Cursor = Cursors.Hand;
            chkTodo.Location = new Point(10, 7);
            chkTodo.Name = "chkTodo";
            chkTodo.Size = new Size(53, 19);
            chkTodo.TabIndex = 0;
            chkTodo.Text = "Todo";
            chkTodo.UseVisualStyleBackColor = false;
            // 
            // chkWeekly
            // 
            chkWeekly.AutoSize = true;
            chkWeekly.Cursor = Cursors.Hand;
            chkWeekly.Location = new Point(156, 7);
            chkWeekly.Name = "chkWeekly";
            chkWeekly.Size = new Size(64, 19);
            chkWeekly.TabIndex = 1;
            chkWeekly.Text = "Weekly";
            // 
            // chkCalendar
            // 
            chkCalendar.AutoSize = true;
            chkCalendar.Cursor = Cursors.Hand;
            chkCalendar.Location = new Point(313, 7);
            chkCalendar.Name = "chkCalendar";
            chkCalendar.Size = new Size(73, 19);
            chkCalendar.TabIndex = 2;
            chkCalendar.Text = "Calendar";
            // 
            // flpTrashList
            // 
            flpTrashList.AutoScroll = true;
            flpTrashList.BackColor = Color.White;
            flpTrashList.Controls.Add(pTrashItemSample);
            flpTrashList.FlowDirection = FlowDirection.TopDown;
            flpTrashList.Location = new Point(0, 108);
            flpTrashList.Name = "flpTrashList";
            flpTrashList.Padding = new Padding(12, 10, 12, 10);
            flpTrashList.Size = new Size(420, 362);
            flpTrashList.TabIndex = 5;
            flpTrashList.Visible = false;
            flpTrashList.WrapContents = false;
            // 
            // pTrashItemSample
            // 
            pTrashItemSample.BackColor = Color.WhiteSmoke;
            pTrashItemSample.BorderStyle = BorderStyle.FixedSingle;
            pTrashItemSample.Controls.Add(btnDeleteForever);
            pTrashItemSample.Controls.Add(btnRestore);
            pTrashItemSample.Controls.Add(lblTypeTag);
            pTrashItemSample.Controls.Add(lblTrashMeta);
            pTrashItemSample.Controls.Add(lblTrashTitle);
            pTrashItemSample.Controls.Add(pTypeColor);
            pTrashItemSample.Location = new Point(12, 10);
            pTrashItemSample.Margin = new Padding(0, 0, 0, 10);
            pTrashItemSample.Name = "pTrashItemSample";
            pTrashItemSample.Size = new Size(396, 78);
            pTrashItemSample.TabIndex = 0;
            pTrashItemSample.Visible = false;
            // 
            // btnDeleteForever
            // 
            btnDeleteForever.BackColor = Color.MistyRose;
            btnDeleteForever.Cursor = Cursors.Hand;
            btnDeleteForever.FlatAppearance.BorderSize = 0;
            btnDeleteForever.FlatStyle = FlatStyle.Flat;
            btnDeleteForever.Font = new Font("Segoe UI", 9F);
            btnDeleteForever.ForeColor = Color.DarkRed;
            btnDeleteForever.Location = new Point(330, 42);
            btnDeleteForever.Name = "btnDeleteForever";
            btnDeleteForever.Size = new Size(45, 24);
            btnDeleteForever.TabIndex = 5;
            btnDeleteForever.Text = "✖";
            btnDeleteForever.UseVisualStyleBackColor = false;
            // 
            // btnRestore
            // 
            btnRestore.BackColor = Color.PaleGreen;
            btnRestore.Cursor = Cursors.Hand;
            btnRestore.FlatAppearance.BorderSize = 0;
            btnRestore.FlatStyle = FlatStyle.Flat;
            btnRestore.Font = new Font("Segoe UI", 9F);
            btnRestore.Location = new Point(330, 12);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(45, 24);
            btnRestore.TabIndex = 4;
            btnRestore.Text = "♻";
            btnRestore.UseVisualStyleBackColor = false;
            // 
            // lblTypeTag
            // 
            lblTypeTag.BackColor = Color.LightSkyBlue;
            lblTypeTag.Font = new Font("Segoe UI Semibold", 8.5F);
            lblTypeTag.ForeColor = Color.DarkBlue;
            lblTypeTag.Location = new Point(255, 10);
            lblTypeTag.Name = "lblTypeTag";
            lblTypeTag.Size = new Size(70, 22);
            lblTypeTag.TabIndex = 3;
            lblTypeTag.Text = "TODO";
            lblTypeTag.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTrashMeta
            // 
            lblTrashMeta.Font = new Font("Segoe UI", 9F);
            lblTrashMeta.ForeColor = Color.Gray;
            lblTrashMeta.Location = new Point(14, 40);
            lblTrashMeta.Name = "lblTrashMeta";
            lblTrashMeta.Size = new Size(235, 20);
            lblTrashMeta.TabIndex = 2;
            lblTrashMeta.Text = "Đã xóa: 10/01/2026 14:20";
            // 
            // lblTrashTitle
            // 
            lblTrashTitle.Font = new Font("Segoe UI Semibold", 11F);
            lblTrashTitle.ForeColor = Color.FromArgb(40, 40, 40);
            lblTrashTitle.Location = new Point(14, 10);
            lblTrashTitle.Name = "lblTrashTitle";
            lblTrashTitle.Size = new Size(235, 24);
            lblTrashTitle.TabIndex = 1;
            lblTrashTitle.Text = "Tiêu đề công việc bị xóa";
            // 
            // pTypeColor
            // 
            pTypeColor.BackColor = Color.DodgerBlue;
            pTypeColor.Location = new Point(0, 0);
            pTypeColor.Name = "pTypeColor";
            pTypeColor.Size = new Size(10, 78);
            pTypeColor.TabIndex = 0;
            // 
            // Thungrac
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(420, 500);
            Controls.Add(flpTrashList);
            Controls.Add(pnlFilter);
            Controls.Add(pnlSearch);
            Controls.Add(lblEmptyText);
            Controls.Add(lblEmptyIcon);
            Controls.Add(lblFooter);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Thungrac";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thungrac";
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            flpTrashList.ResumeLayout(false);
            pTrashItemSample.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtSearch;
        private Label lblEmptyIcon;
        private Label lblEmptyText;
        private Label lblFooter;
        private Panel pnlSearch;
        private Panel pnlFilter;
        private CheckBox chkTodo;
        private CheckBox chkWeekly;
        private CheckBox chkCalendar;

        // ✅ thay panel1
        private FlowLayoutPanel flpTrashList;

        // ✅ controls card mẫu
        private Panel pTrashItemSample;
        private Panel pTypeColor;
        private Label lblTrashTitle;
        private Label lblTrashMeta;
        private Label lblTypeTag;
        private Button btnRestore;
        private Button btnDeleteForever;
    }
}
