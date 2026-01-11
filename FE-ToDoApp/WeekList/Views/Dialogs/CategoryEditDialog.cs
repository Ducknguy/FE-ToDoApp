using System;
using System.Drawing;
using System.Windows.Forms;

namespace FE_ToDoApp.WeekList.Views.Dialogs
{
    /// <summary>
    /// Dialog ?? thêm/s?a Category
    /// </summary>
    public class CategoryEditDialog : Form
    {
        private TextBox txtCategoryName;
        private Button btnOK;
        private Button btnCancel;
        private Label lblCategoryName;

        public string CategoryName { get; private set; }

        public CategoryEditDialog(string categoryName = "")
        {
            CategoryName = categoryName;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = string.IsNullOrEmpty(CategoryName) ? "Thêm Nhóm Công Vi?c" : "S?a Nhóm Công Vi?c";
            this.Size = new Size(400, 150);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Label
            lblCategoryName = new Label
            {
                Text = "Tên nhóm:",
                Location = new Point(20, 20),
                Size = new Size(100, 23),
                Font = new Font("Segoe UI", 10F)
            };
            this.Controls.Add(lblCategoryName);

            // TextBox
            txtCategoryName = new TextBox
            {
                Location = new Point(130, 20),
                Size = new Size(230, 27),
                Font = new Font("Segoe UI", 10F),
                Text = CategoryName
            };
            this.Controls.Add(txtCategoryName);

            // Button OK
            btnOK = new Button
            {
                Text = "OK",
                Location = new Point(170, 65),
                Size = new Size(90, 30),
                Font = new Font("Segoe UI", 10F),
                DialogResult = DialogResult.OK
            };
            btnOK.Click += BtnOK_Click;
            this.Controls.Add(btnOK);

            // Button Cancel
            btnCancel = new Button
            {
                Text = "H?y",
                Location = new Point(270, 65),
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
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Vui lòng nh?p tên nhóm công vi?c!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryName.Focus();
                this.DialogResult = DialogResult.None;
                return;
            }

            CategoryName = txtCategoryName.Text.Trim();
        }
    }
}
