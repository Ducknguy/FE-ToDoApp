namespace FE_ToDoApp.WeekList.Views.Dialogs
{
    partial class CategoryEditDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            txtCategoryName = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            lblWeekSelection = new Label();
            datePickerWeek = new DateTimePicker();
            lblWeekRange = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 10F);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(167, 23);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Tên nhóm công việc:";
            // 
            // txtCategoryName
            // 
            txtCategoryName.Font = new Font("Segoe UI", 10F);
            txtCategoryName.Location = new Point(20, 50);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(340, 30);
            txtCategoryName.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.FromArgb(0, 120, 215);
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnOK.ForeColor = Color.White;
            btnOK.Location = new Point(190, 195);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(80, 35);
            btnOK.TabIndex = 2;
            btnOK.Text = "Cập nhật";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F);
            btnCancel.Location = new Point(280, 195);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 35);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblWeekSelection
            // 
            lblWeekSelection.AutoSize = true;
            lblWeekSelection.Font = new Font("Segoe UI", 10F);
            lblWeekSelection.Location = new Point(20, 95);
            lblWeekSelection.Name = "lblWeekSelection";
            lblWeekSelection.Size = new Size(95, 23);
            lblWeekSelection.TabIndex = 4;
            lblWeekSelection.Text = "Chọn tuần:";
            // 
            // datePickerWeek
            // 
            datePickerWeek.Font = new Font("Segoe UI", 10F);
            datePickerWeek.Format = DateTimePickerFormat.Short;
            datePickerWeek.Location = new Point(20, 125);
            datePickerWeek.Name = "datePickerWeek";
            datePickerWeek.Size = new Size(340, 30);
            datePickerWeek.TabIndex = 5;
            datePickerWeek.ValueChanged += datePickerWeek_ValueChanged;
            // 
            // lblWeekRange
            // 
            lblWeekRange.AutoSize = true;
            lblWeekRange.Font = new Font("Segoe UI", 9F);
            lblWeekRange.ForeColor = Color.Gray;
            lblWeekRange.Location = new Point(20, 160);
            lblWeekRange.Name = "lblWeekRange";
            lblWeekRange.Size = new Size(214, 20);
            lblWeekRange.TabIndex = 6;
            lblWeekRange.Text = "Tuần: 12/01/2026 - 18/01/2026";
            // 
            // CategoryEditDialog
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(384, 251);
            Controls.Add(lblWeekRange);
            Controls.Add(datePickerWeek);
            Controls.Add(lblWeekSelection);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(txtCategoryName);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CategoryEditDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Sửa Nhóm Công Việc";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblWeekSelection;
        private System.Windows.Forms.DateTimePicker datePickerWeek;
        private System.Windows.Forms.Label lblWeekRange;
    }
}
