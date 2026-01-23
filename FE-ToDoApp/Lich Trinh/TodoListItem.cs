using System;
using System.Drawing;
using System.Windows.Forms;

namespace FE_ToDoApp.Lich_Trinh
{
    public partial class ToDoListItem : UserControl
    {
        public int TodoId { get; set; }

        public string Title
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }

        public event EventHandler? Clicked;

        public ToDoListItem()
        {
            InitializeComponent();
            WireClickRecursive(this);
        }

        public void SetTitle(string title) => Title = title;

        public void SetSelected(bool selected)
        {
            BackColor = selected ? Color.FromArgb(200, 220, 255) : Color.FromArgb(230, 240, 255);
        }

        public void SetStreakInfo(int currentStreak, int bestStreak)
        {
            if (currentStreak > 0)
            {
                lblStreakIcon.Visible = true;
                lblStreakCount.Visible = true;
                lblStreakCount.Text = currentStreak.ToString();

                // Đổi màu theo mức streak - đơn giản
                if (currentStreak >= 30)
                {
                    lblStreakCount.ForeColor = Color.FromArgb(220, 20, 60); // Đỏ
                    lblStreakIcon.Text = "🔥";
                }
                else if (currentStreak >= 14)
                {
                    lblStreakCount.ForeColor = Color.FromArgb(255, 69, 0); // Đỏ cam
                    lblStreakIcon.Text = "🔥";
                }
                else if (currentStreak >= 7)
                {
                    lblStreakCount.ForeColor = Color.FromArgb(255, 140, 0); // Cam đậm
                    lblStreakIcon.Text = "🔥";
                }
                else
                {
                    lblStreakCount.ForeColor = Color.FromArgb(255, 165, 0); // Cam
                    lblStreakIcon.Text = "🔥";
                }

                // Tooltip đơn giản
                var tooltip = new ToolTip();
                string tooltipText = $"Streak: {currentStreak} ngày\nKỷ lục: {bestStreak} ngày";
                tooltip.SetToolTip(lblStreakIcon, tooltipText);
                tooltip.SetToolTip(lblStreakCount, tooltipText);
            }
            else
            {
                lblStreakIcon.Visible = false;
                lblStreakCount.Visible = false;
            }
        }

        public void SetCompletionStatus(int completedCount, int totalCount)
        {

            if (totalCount == 0)
            {
                lblProgress.Visible = false;
                lblDoneIcon.Visible = false;
                BackColor = Color.FromArgb(230, 240, 255);
                return;
            }

            lblProgress.Text = $"{completedCount}/{totalCount} items";
            lblProgress.Visible = true;

            if (completedCount == totalCount)
            {
                lblDoneIcon.Visible = true;
                BackColor = Color.FromArgb(240, 255, 240);
                lblProgress.ForeColor = Color.Green;
                lblTitle.ForeColor = Color.FromArgb(60, 120, 60);
            }
            else if (completedCount > 0)
            {
                lblDoneIcon.Visible = false;
                BackColor = Color.FromArgb(255, 250, 230);
                lblProgress.ForeColor = Color.FromArgb(200, 140, 0);
                lblTitle.ForeColor = Color.Black;
            }
            else
            {
                lblDoneIcon.Visible = false;
                BackColor = Color.FromArgb(230, 240, 255);
                lblProgress.ForeColor = Color.Gray;
                lblTitle.ForeColor = Color.Black;
            }
        }

        private void WireClickRecursive(Control root)
        {
            root.Cursor = Cursors.Hand;
            root.Click += (s, e) => Clicked?.Invoke(this, EventArgs.Empty);

            foreach (Control c in root.Controls)
                WireClickRecursive(c);
        }
    }
}
