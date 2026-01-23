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
        private Label lblStreakIcon = null!;
        private Label lblStreakCount = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblProgress = new Label();
            lblDoneIcon = new Label();
            lblStreakIcon = new Label();
            lblStreakCount = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(180, 24);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Detail title";
            // 
            // lblProgress
            // 
            lblProgress.Font = new Font("Segoe UI", 9F);
            lblProgress.ForeColor = Color.Gray;
            lblProgress.Location = new Point(12, 32);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(180, 16);
            lblProgress.TabIndex = 1;
            lblProgress.Visible = false;
            // 
            // lblDoneIcon
            // 
            lblDoneIcon.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblDoneIcon.ForeColor = Color.Green;
            lblDoneIcon.Location = new Point(231, 14);
            lblDoneIcon.Name = "lblDoneIcon";
            lblDoneIcon.Size = new Size(30, 32);
            lblDoneIcon.TabIndex = 2;
            lblDoneIcon.Text = "✓";
            lblDoneIcon.TextAlign = ContentAlignment.MiddleCenter;
            lblDoneIcon.Visible = false;
            // 
            // lblStreakIcon
            // 
            lblStreakIcon.Font = new Font("Segoe UI Emoji", 12F);
            lblStreakIcon.Location = new Point(198, 2);
            lblStreakIcon.Name = "lblStreakIcon";
            lblStreakIcon.Size = new Size(20, 34);
            lblStreakIcon.TabIndex = 3;
            lblStreakIcon.Text = "🔥";
            lblStreakIcon.TextAlign = ContentAlignment.MiddleCenter;
            lblStreakIcon.Visible = false;
            // 
            // lblStreakCount
            // 
            lblStreakCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStreakCount.ForeColor = Color.FromArgb(255, 100, 0);
            lblStreakCount.Location = new Point(214, 14);
            lblStreakCount.Name = "lblStreakCount";
            lblStreakCount.Size = new Size(25, 18);
            lblStreakCount.TabIndex = 4;
            lblStreakCount.Text = "0";
            lblStreakCount.TextAlign = ContentAlignment.MiddleLeft;
            lblStreakCount.Visible = false;
            // 
            // ToDoListItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 240, 255);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblTitle);
            Controls.Add(lblProgress);
            Controls.Add(lblDoneIcon);
            Controls.Add(lblStreakIcon);
            Controls.Add(lblStreakCount);
            Margin = new Padding(0, 0, 0, 8);
            Name = "ToDoListItem";
            Padding = new Padding(10);
            Size = new Size(260, 56);
            ResumeLayout(false);
        }
    }
}
