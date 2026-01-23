using System;
using System.Windows.Forms;

namespace FE_ToDoApp.ThemNhanh
{
    public partial class QuickAddTodo : UserControl
    {
        public string TodoTitle => textBox1.Text.Trim();
        public DateTime TodoDate => dateTimePicker1.Value;

        public QuickAddTodo()
        {
            InitializeComponent();
            InitializeDefaults();
        }

        private void InitializeDefaults()
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        public bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề công việc!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return false;
            }

            return true;
        }

        public void ClearInputs()
        {
            textBox1.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }
    }
}