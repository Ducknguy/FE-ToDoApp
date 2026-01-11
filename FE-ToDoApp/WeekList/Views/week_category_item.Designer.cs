namespace FE_ToDoApp.WeekList.Views
{
    partial class week_category_item
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblCategoryName;

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
            this.lblCategoryName = new Label();
            this.SuspendLayout();
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCategoryName.Location = new System.Drawing.Point(15, 12);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(98, 25);
            this.lblCategoryName.TabIndex = 0;
            this.lblCategoryName.Text = "Công vi?c";
            // 
            // week_category_item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.lblCategoryName);
            this.Name = "week_category_item";
            this.Size = new System.Drawing.Size(267, 50);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
