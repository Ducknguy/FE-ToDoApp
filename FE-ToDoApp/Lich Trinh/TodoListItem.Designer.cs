using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FE_ToDoApp.Lich_Trinh
{
    partial class ToDoListItem
    {
        private IContainer components = null!;
        private Label lblTitle = null!;
        private Label lblProgress = null!;
        private Label lblDoneIcon = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
            lblTitle = new Label();
            lblProgress = new Label();
            lblDoneIcon = new Label();
            SuspendLayout();

            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 240, 255);
            BorderStyle = BorderStyle.FixedSingle;
            Padding = new Padding(10);
            Margin = new Padding(0, 0, 0, 8);
            Size = new Size(260, 56);

            // Title
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Detail title";
            lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.AutoSize = false;
            lblTitle.Location = new Point(12, 8);
            lblTitle.Size = new Size(180, 24);

            // Progress label (3/5 items)
            lblProgress.Name = "lblProgress";
            lblProgress.Text = "";
            lblProgress.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblProgress.ForeColor = Color.Gray;
            lblProgress.AutoSize = false;
            lblProgress.Location = new Point(12, 32);
            lblProgress.Size = new Size(180, 16);
            lblProgress.Visible = false;

            // Done icon (✓)
            lblDoneIcon.Name = "lblDoneIcon";
            lblDoneIcon.Text = "✓";
            lblDoneIcon.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblDoneIcon.ForeColor = Color.Green;
            lblDoneIcon.AutoSize = false;
            lblDoneIcon.Location = new Point(220, 12);
            lblDoneIcon.Size = new Size(30, 32);
            lblDoneIcon.TextAlign = ContentAlignment.MiddleCenter;
            lblDoneIcon.Visible = false;

            Controls.Add(lblTitle);
            Controls.Add(lblProgress);
            Controls.Add(lblDoneIcon);

            lblDoneIcon.BringToFront();

            ResumeLayout(false);
        }
    }
}
