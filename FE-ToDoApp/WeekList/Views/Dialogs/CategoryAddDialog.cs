using System;
using System.Windows.Forms;

namespace FE_ToDoApp.WeekList.Views.Dialogs
{
    public partial class CategoryAddDialog : Form
    {
        public string CategoryName { get; private set; } = string.Empty;
        public DateTime WeekStartDate { get; private set; }
        public DateTime WeekEndDate { get; private set; }

        public CategoryAddDialog()
        {
            InitializeComponent();
            
            datePickerWeek.Value = DateTime.Now;
            UpdateWeekRange();
        }

        private void datePickerWeek_ValueChanged(object sender, EventArgs e)
        {
            UpdateWeekRange();
        }

        private void UpdateWeekRange()
        {
            DateTime selectedDate = datePickerWeek.Value;
            WeekStartDate = GetMonday(selectedDate);
            WeekEndDate = WeekStartDate.AddDays(6);
            
            lblWeekRange.Text = $"Tuần: {WeekStartDate:dd/MM/yyyy} - {WeekEndDate:dd/MM/yyyy}";
        }

        private DateTime GetMonday(DateTime date)
        {
            int daysFromMonday = ((int)date.DayOfWeek - 1 + 7) % 7;
            return date.Date.AddDays(-daysFromMonday);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text.Trim();

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Tên nhóm công việc không được để trống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryName.Focus();
                this.DialogResult = DialogResult.None;
                return;
            }

            CategoryName = categoryName;
            this.DialogResult = DialogResult.OK;
        }
    }
}
