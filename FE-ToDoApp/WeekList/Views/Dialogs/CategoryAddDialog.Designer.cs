namespace FE_ToDoApp.WeekList.Views.Dialogs
{
    partial class CategoryAddDialog
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblWeekSelection = new System.Windows.Forms.Label();
            this.datePickerWeek = new System.Windows.Forms.DateTimePicker();
            this.lblWeekRange = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(156, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Tên nhóm công việc:";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCategoryName.Location = new System.Drawing.Point(20, 50);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(340, 30);
            this.txtCategoryName.TabIndex = 1;
            // 
            // lblWeekSelection
            // 
            this.lblWeekSelection.AutoSize = true;
            this.lblWeekSelection.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblWeekSelection.Location = new System.Drawing.Point(20, 95);
            this.lblWeekSelection.Name = "lblWeekSelection";
            this.lblWeekSelection.Size = new System.Drawing.Size(100, 23);
            this.lblWeekSelection.TabIndex = 4;
            this.lblWeekSelection.Text = "Chọn tuần:";
            // 
            // datePickerWeek
            // 
            this.datePickerWeek.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.datePickerWeek.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerWeek.Location = new System.Drawing.Point(20, 125);
            this.datePickerWeek.Name = "datePickerWeek";
            this.datePickerWeek.Size = new System.Drawing.Size(340, 30);
            this.datePickerWeek.TabIndex = 5;
            this.datePickerWeek.ValueChanged += new System.EventHandler(this.datePickerWeek_ValueChanged);
            // 
            // lblWeekRange
            // 
            this.lblWeekRange.AutoSize = true;
            this.lblWeekRange.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblWeekRange.ForeColor = System.Drawing.Color.Gray;
            this.lblWeekRange.Location = new System.Drawing.Point(20, 160);
            this.lblWeekRange.Name = "lblWeekRange";
            this.lblWeekRange.Size = new System.Drawing.Size(200, 20);
            this.lblWeekRange.TabIndex = 6;
            this.lblWeekRange.Text = "Tuần: 12/01/2026 - 18/01/2026";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(190, 195);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 35);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Thêm";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.Location = new System.Drawing.Point(280, 195);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 35);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // CategoryAddDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(384, 251);
            this.Controls.Add(this.lblWeekRange);
            this.Controls.Add(this.datePickerWeek);
            this.Controls.Add(this.lblWeekSelection);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtCategoryName);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategoryAddDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm Nhóm Công Việc Mới";
            this.ResumeLayout(false);
            this.PerformLayout();
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
