using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FE_ToDoApp.Lich_Trinh
{
    partial class ToDoListItem
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Black;   // QUAN TRỌNG
            this.lblTitle.BackColor = Color.Transparent;
            this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new Padding(12, 0, 12, 0);
            this.lblTitle.Text = "ToDo Title";
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.Name = "lblTitle";

            // 
            // ToDoListItem
            // 
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.FromArgb(230, 240, 255); // xanh nhạt
            this.Controls.Add(this.lblTitle);
            this.Margin = new Padding(0);
            this.Name = "ToDoListItem";
            this.Size = new Size(260, 56);
            this.ResumeLayout(false);
        }
        #endregion

        private Label lblTitle;
    }
}
