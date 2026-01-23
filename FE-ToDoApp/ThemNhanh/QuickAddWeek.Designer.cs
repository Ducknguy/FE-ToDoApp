namespace FE_ToDoApp.ThemNhanh
{
    partial class QuickAddWeek
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlCategorySection = new Panel();
            lblWeekRange = new Label();
            dtpWeekDate = new DateTimePicker();
            lblWeekSelection = new Label();
            txtWeekCategoryName = new TextBox();
            lblCategoryName = new Label();
            lblCategoryTitle = new Label();
            pnlSeparator = new Panel();
            pnlTaskSection = new Panel();
            cmbDayOfWeek = new ComboBox();
            lblDayOfWeek = new Label();
            txtWeekTaskDescription = new TextBox();
            lblTaskDescription = new Label();
            txtWeekTaskTitle = new TextBox();
            lblTaskTitle = new Label();
            lblTaskSectionTitle = new Label();
            pnlCategorySection.SuspendLayout();
            pnlTaskSection.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCategorySection
            // 
            pnlCategorySection.Controls.Add(lblWeekRange);
            pnlCategorySection.Controls.Add(dtpWeekDate);
            pnlCategorySection.Controls.Add(lblWeekSelection);
            pnlCategorySection.Controls.Add(txtWeekCategoryName);
            pnlCategorySection.Controls.Add(lblCategoryName);
            pnlCategorySection.Controls.Add(lblCategoryTitle);
            pnlCategorySection.Dock = DockStyle.Top;
            pnlCategorySection.Location = new Point(0, 0);
            pnlCategorySection.Name = "pnlCategorySection";
            pnlCategorySection.Padding = new Padding(15, 10, 15, 10);
            pnlCategorySection.Size = new Size(600, 245);
            pnlCategorySection.TabIndex = 0;
            // 
            // lblWeekRange
            // 
            lblWeekRange.AutoSize = true;
            lblWeekRange.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblWeekRange.ForeColor = Color.Gray;
            lblWeekRange.Location = new Point(15, 184);
            lblWeekRange.Name = "lblWeekRange";
            lblWeekRange.Size = new Size(239, 20);
            lblWeekRange.TabIndex = 5;
            lblWeekRange.Text = "📌 Tuần: 01/01/2024 - 07/01/2024";
            // 
            // dtpWeekDate
            // 
            dtpWeekDate.Font = new Font("Segoe UI", 11F);
            dtpWeekDate.Format = DateTimePickerFormat.Short;
            dtpWeekDate.Location = new Point(15, 149);
            dtpWeekDate.Name = "dtpWeekDate";
            dtpWeekDate.Size = new Size(570, 32);
            dtpWeekDate.TabIndex = 4;
            dtpWeekDate.ValueChanged += dtpWeekDate_ValueChanged;
            // 
            // lblWeekSelection
            // 
            lblWeekSelection.AutoSize = true;
            lblWeekSelection.Font = new Font("Segoe UI", 11F);
            lblWeekSelection.ForeColor = Color.FromArgb(68, 68, 68);
            lblWeekSelection.Location = new Point(15, 119);
            lblWeekSelection.Name = "lblWeekSelection";
            lblWeekSelection.Size = new Size(104, 25);
            lblWeekSelection.TabIndex = 3;
            lblWeekSelection.Text = "Chọn tuần:";
            // 
            // txtWeekCategoryName
            // 
            txtWeekCategoryName.Font = new Font("Segoe UI", 11F);
            txtWeekCategoryName.Location = new Point(15, 79);
            txtWeekCategoryName.Name = "txtWeekCategoryName";
            txtWeekCategoryName.PlaceholderText = "Nhập tên nhóm công việc...";
            txtWeekCategoryName.Size = new Size(570, 32);
            txtWeekCategoryName.TabIndex = 2;
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Font = new Font("Segoe UI", 11F);
            lblCategoryName.ForeColor = Color.FromArgb(68, 68, 68);
            lblCategoryName.Location = new Point(15, 49);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(184, 25);
            lblCategoryName.TabIndex = 1;
            lblCategoryName.Text = "Tên nhóm công việc:";
            // 
            // lblCategoryTitle
            // 
            lblCategoryTitle.AutoSize = true;
            lblCategoryTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCategoryTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblCategoryTitle.Location = new Point(15, 10);
            lblCategoryTitle.Name = "lblCategoryTitle";
            lblCategoryTitle.Size = new Size(426, 28);
            lblCategoryTitle.TabIndex = 0;
            lblCategoryTitle.Text = "🗂️ PHẦN 1: THÔNG TIN NHÓM CÔNG VIỆC";
            // 
            // pnlSeparator
            // 
            pnlSeparator.BackColor = Color.FromArgb(224, 224, 224);
            pnlSeparator.Dock = DockStyle.Top;
            pnlSeparator.Location = new Point(0, 245);
            pnlSeparator.Name = "pnlSeparator";
            pnlSeparator.Size = new Size(600, 2);
            pnlSeparator.TabIndex = 1;
            // 
            // pnlTaskSection
            // 
            pnlTaskSection.Controls.Add(cmbDayOfWeek);
            pnlTaskSection.Controls.Add(lblDayOfWeek);
            pnlTaskSection.Controls.Add(txtWeekTaskDescription);
            pnlTaskSection.Controls.Add(lblTaskDescription);
            pnlTaskSection.Controls.Add(txtWeekTaskTitle);
            pnlTaskSection.Controls.Add(lblTaskTitle);
            pnlTaskSection.Controls.Add(lblTaskSectionTitle);
            pnlTaskSection.Dock = DockStyle.Fill;
            pnlTaskSection.Location = new Point(0, 247);
            pnlTaskSection.Name = "pnlTaskSection";
            pnlTaskSection.Padding = new Padding(15, 15, 15, 10);
            pnlTaskSection.Size = new Size(600, 331);
            pnlTaskSection.TabIndex = 2;
            // 
            // cmbDayOfWeek
            // 
            cmbDayOfWeek.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDayOfWeek.Font = new Font("Segoe UI", 11F);
            cmbDayOfWeek.FormattingEnabled = true;
            cmbDayOfWeek.Items.AddRange(new object[] { "Thứ Hai (1)", "Thứ Ba (2)", "Thứ Tư (3)", "Thứ Năm (4)", "Thứ Sáu (5)", "Thứ Bảy (6)", "Chủ Nhật (7)" });
            cmbDayOfWeek.Location = new Point(15, 258);
            cmbDayOfWeek.Name = "cmbDayOfWeek";
            cmbDayOfWeek.Size = new Size(570, 33);
            cmbDayOfWeek.TabIndex = 6;
            // 
            // lblDayOfWeek
            // 
            lblDayOfWeek.AutoSize = true;
            lblDayOfWeek.Font = new Font("Segoe UI", 11F);
            lblDayOfWeek.ForeColor = Color.FromArgb(68, 68, 68);
            lblDayOfWeek.Location = new Point(15, 228);
            lblDayOfWeek.Name = "lblDayOfWeek";
            lblDayOfWeek.Size = new Size(154, 25);
            lblDayOfWeek.TabIndex = 5;
            lblDayOfWeek.Text = "Ngày trong tuần:";
            // 
            // txtWeekTaskDescription
            // 
            txtWeekTaskDescription.Font = new Font("Segoe UI", 11F);
            txtWeekTaskDescription.Location = new Point(15, 163);
            txtWeekTaskDescription.Multiline = true;
            txtWeekTaskDescription.Name = "txtWeekTaskDescription";
            txtWeekTaskDescription.PlaceholderText = "Nhập mô tả công việc...";
            txtWeekTaskDescription.ScrollBars = ScrollBars.Vertical;
            txtWeekTaskDescription.Size = new Size(570, 60);
            txtWeekTaskDescription.TabIndex = 4;
            // 
            // lblTaskDescription
            // 
            lblTaskDescription.AutoSize = true;
            lblTaskDescription.Font = new Font("Segoe UI", 11F);
            lblTaskDescription.ForeColor = Color.FromArgb(68, 68, 68);
            lblTaskDescription.Location = new Point(15, 133);
            lblTaskDescription.Name = "lblTaskDescription";
            lblTaskDescription.Size = new Size(150, 25);
            lblTaskDescription.TabIndex = 3;
            lblTaskDescription.Text = "Mô tả công việc:";
            // 
            // txtWeekTaskTitle
            // 
            txtWeekTaskTitle.Font = new Font("Segoe UI", 11F);
            txtWeekTaskTitle.Location = new Point(15, 93);
            txtWeekTaskTitle.Name = "txtWeekTaskTitle";
            txtWeekTaskTitle.PlaceholderText = "Nhập tên công việc...";
            txtWeekTaskTitle.Size = new Size(570, 32);
            txtWeekTaskTitle.TabIndex = 2;
            // 
            // lblTaskTitle
            // 
            lblTaskTitle.AutoSize = true;
            lblTaskTitle.Font = new Font("Segoe UI", 11F);
            lblTaskTitle.ForeColor = Color.FromArgb(68, 68, 68);
            lblTaskTitle.Location = new Point(15, 63);
            lblTaskTitle.Name = "lblTaskTitle";
            lblTaskTitle.Size = new Size(130, 25);
            lblTaskTitle.TabIndex = 1;
            lblTaskTitle.Text = "Tên công việc:";
            // 
            // lblTaskSectionTitle
            // 
            lblTaskSectionTitle.AutoSize = true;
            lblTaskSectionTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTaskSectionTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblTaskSectionTitle.Location = new Point(15, 15);
            lblTaskSectionTitle.Name = "lblTaskSectionTitle";
            lblTaskSectionTitle.Size = new Size(375, 28);
            lblTaskSectionTitle.TabIndex = 0;
            lblTaskSectionTitle.Text = "📋 PHẦN 2: CÔNG VIỆC TRONG TUẦN";
            // 
            // QuickAddWeek
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            Controls.Add(pnlTaskSection);
            Controls.Add(pnlSeparator);
            Controls.Add(pnlCategorySection);
            Name = "QuickAddWeek";
            Size = new Size(600, 578);
            pnlCategorySection.ResumeLayout(false);
            pnlCategorySection.PerformLayout();
            pnlTaskSection.ResumeLayout(false);
            pnlTaskSection.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCategorySection;
        private Label lblCategoryTitle;
        private Label lblCategoryName;
        private TextBox txtWeekCategoryName;
        private Label lblWeekSelection;
        private DateTimePicker dtpWeekDate;
        private Label lblWeekRange;
        private Panel pnlSeparator;
        private Panel pnlTaskSection;
        private Label lblTaskSectionTitle;
        private Label lblTaskTitle;
        private TextBox txtWeekTaskTitle;
        private Label lblTaskDescription;
        private TextBox txtWeekTaskDescription;
        private Label lblDayOfWeek;
        private ComboBox cmbDayOfWeek;
    }
}
