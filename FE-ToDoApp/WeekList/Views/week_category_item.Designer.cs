namespace FE_ToDoApp.WeekList.Views
{
    partial class week_category_item
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblCategoryName;
        private ContextMenuStrip contextMenuCategory;
        private ToolStripMenuItem menuItemEdit;
        private ToolStripMenuItem menuItemDelete;

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
            this.components = new System.ComponentModel.Container();
            this.lblCategoryName = new Label();
            this.contextMenuCategory = new ContextMenuStrip(this.components);
            this.menuItemEdit = new ToolStripMenuItem();
            this.menuItemDelete = new ToolStripMenuItem();
            this.contextMenuCategory.SuspendLayout();
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
            this.lblCategoryName.Text = "Công việc";
            // 
            // contextMenuCategory
            // 
            this.contextMenuCategory.Items.AddRange(new ToolStripItem[] {
                this.menuItemEdit,
                this.menuItemDelete
            });
            this.contextMenuCategory.Name = "contextMenuCategory";
            this.contextMenuCategory.Size = new System.Drawing.Size(181, 70);
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.Image = null;
            this.menuItemEdit.Name = "menuItemEdit";
            this.menuItemEdit.Size = new System.Drawing.Size(180, 22);
            this.menuItemEdit.Text = "Sửa";
            // 
            // menuItemDelete
            // 
            this.menuItemDelete.Image = null;
            this.menuItemDelete.Name = "menuItemDelete";
            this.menuItemDelete.Size = new System.Drawing.Size(180, 22);
            this.menuItemDelete.Text = "Xóa";
            // 
            // week_category_item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.ContextMenuStrip = this.contextMenuCategory;
            this.Controls.Add(this.lblCategoryName);
            this.Name = "week_category_item";
            this.Size = new System.Drawing.Size(267, 70);
            this.contextMenuCategory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
