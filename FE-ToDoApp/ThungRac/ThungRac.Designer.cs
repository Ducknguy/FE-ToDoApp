namespace ChatbotAI_Form
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
            pnlSearch.SuspendLayout();
            pnlFilter.SuspendLayout();
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
            chkWeekly.Location = new Point(156, 7);
            chkWeekly.Name = "chkWeekly";
            chkWeekly.Size = new Size(64, 19);
            chkWeekly.TabIndex = 1;
            chkWeekly.Text = "Weekly";
            // 
            // chkCalendar
            // 
            chkCalendar.AutoSize = true;
            chkCalendar.Location = new Point(313, 7);
            chkCalendar.Name = "chkCalendar";
            chkCalendar.Size = new Size(73, 19);
            chkCalendar.TabIndex = 2;
            chkCalendar.Text = "Calendar";
            // 
            // Thungrac
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(420, 500);
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
    }
}
