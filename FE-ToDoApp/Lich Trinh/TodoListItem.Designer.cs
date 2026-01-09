using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FE_ToDoApp.Lich_Trinh
{
    partial class ToDoListItem
    {
        private IContainer components = null!;
        private Label lblTitle = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
            lblTitle = new Label();
            SuspendLayout();

            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 240, 255);
            BorderStyle = BorderStyle.FixedSingle;
            Padding = new Padding(10);
            Margin = new Padding(0, 0, 0, 8);
            Size = new Size(260, 56);

            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Detail title";
            lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.AutoSize = false;
            lblTitle.Location = new Point(12, 14);
            lblTitle.Size = new Size(230, 28);

            Controls.Add(lblTitle);
            ResumeLayout(false);
        }
    }
}
