using System;
using System.Windows.Forms;

namespace FE_ToDoApp.ThemNhanh
{
    public partial class QuickAddWeek : UserControl
    {
        public string CategoryName => txtWeekCategoryName.Text.Trim();
        public DateTime WeekStartDate { get; private set; }
        public DateTime WeekEndDate { get; private set; }
        public string TaskTitle => txtWeekTaskTitle.Text.Trim();
        public string TaskDescription => txtWeekTaskDescription.Text.Trim();
        public int DayOfWeek => cmbDayOfWeek.SelectedIndex + 1;

        public QuickAddWeek()
        {
            InitializeComponent();
            InitializeDefaults();
        }

        private void InitializeDefaults()
        {
            dtpWeekDate.Value = DateTime.Now;
            cmbDayOfWeek.SelectedIndex = 0;
            UpdateWeekRange();
        }

        private void dtpWeekDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateWeekRange();
        }

        private void UpdateWeekRange()
        {
            DateTime selectedDate = dtpWeekDate.Value;
            WeekStartDate = GetMonday(selectedDate);
            WeekEndDate = WeekStartDate.AddDays(6);

            lblWeekRange.Text = $"📌 Tuần: {WeekStartDate:dd/MM/yyyy} - {WeekEndDate:dd/MM/yyyy}";
        }

        private DateTime GetMonday(DateTime date)
        {
            int daysFromMonday = ((int)date.DayOfWeek - 1 + 7) % 7;
            return date.Date.AddDays(-daysFromMonday);
        }

        public bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtWeekCategoryName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm công việc!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWeekCategoryName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtWeekTaskTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tên công việc!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWeekTaskTitle.Focus();
                return false;
            }

            if (cmbDayOfWeek.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn ngày trong tuần!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDayOfWeek.Focus();
                return false;
            }

            return true;
        }

        public void ClearInputs()
        {
            txtWeekCategoryName.Clear();
            txtWeekTaskTitle.Clear();
            txtWeekTaskDescription.Clear();
            dtpWeekDate.Value = DateTime.Now;
            cmbDayOfWeek.SelectedIndex = 0;
            UpdateWeekRange();
        }
    }
}
