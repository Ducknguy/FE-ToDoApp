using System;
using System.Drawing;
using System.Windows.Forms;

namespace FE_ToDoApp.WeekList
{
    public class TaskEditDialog : Form
    {
        private TextBox txtTitle;
        private ComboBox cboDayOfWeek;
        private Button btnOK;
        private Button btnCancel;
        private Label lblTitle;
        private Label lblDay;

        public string TaskTitle { get; private set; }
        public int DayOfWeek { get; private set; }

        public TaskEditDialog(string title = "", int dayOfWeek = 1)
        {
            TaskTitle = title;
            DayOfWeek = dayOfWeek;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = string.IsNullOrEmpty(TaskTitle) ? "Thêm Task" : "Sửa Task";
            this.Size = new Size(400, 200);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Label Title
            lblTitle = new Label
            {
                Text = "Tiêu đề:",
                Location = new Point(20, 20),
                Size = new Size(80, 23),
                Font = new Font("Segoe UI", 10F)
            };
            this.Controls.Add(lblTitle);

            // TextBox Title
            txtTitle = new TextBox
            {
                Location = new Point(110, 20),
                Size = new Size(250, 27),
                Font = new Font("Segoe UI", 10F),
                Text = TaskTitle
            };
            this.Controls.Add(txtTitle);

            // Label Day
            lblDay = new Label
            {
                Text = "Ngày:",
                Location = new Point(20, 60),
                Size = new Size(80, 23),
                Font = new Font("Segoe UI", 10F)
            };
            this.Controls.Add(lblDay);

            // ComboBox Day
            cboDayOfWeek = new ComboBox
            {
                Location = new Point(110, 60),
                Size = new Size(250, 27),
                Font = new Font("Segoe UI", 10F),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboDayOfWeek.Items.AddRange(new object[]
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            });
            cboDayOfWeek.SelectedIndex = DayOfWeek - 1;
            this.Controls.Add(cboDayOfWeek);

            // Button OK
            btnOK = new Button
            {
                Text = "OK",
                Location = new Point(170, 110),
                Size = new Size(90, 30),
                Font = new Font("Segoe UI", 10F),
                DialogResult = DialogResult.OK
            };
            btnOK.Click += BtnOK_Click;
            this.Controls.Add(btnOK);

            // Button Cancel
            btnCancel = new Button
            {
                Text = "Hủy",
                Location = new Point(270, 110),
                Size = new Size(90, 30),
                Font = new Font("Segoe UI", 10F),
                DialogResult = DialogResult.Cancel
            };
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề task!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                this.DialogResult = DialogResult.None;
                return;
            }

            TaskTitle = txtTitle.Text.Trim();
            DayOfWeek = cboDayOfWeek.SelectedIndex + 1;
        }
    }
}
