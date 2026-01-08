using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FE_ToDoApp.Lich_Trinh
{
    partial class TodoDetailItemControl
    {
        private IContainer components = null!;

        private Label lblTitle = null!;
        private FlowLayoutPanel flpBody = null!;
        private Panel pnlFooter = null!;
        private Button btnAdd = null!;
        private Button btnEdit = null!;
        private Button btnDelete = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();

            lblTitle = new Label();
            flpBody = new FlowLayoutPanel();
            pnlFooter = new Panel();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();

            SuspendLayout();

            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Padding = new Padding(12);
            Size = new Size(600, 500);

            // Header
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "ten detail";
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.AutoSize = true;
            lblTitle.Margin = new Padding(0, 0, 0, 12);

            // Body (items + footer)
            flpBody.Name = "flpBody";
            flpBody.Dock = DockStyle.Fill;
            flpBody.FlowDirection = FlowDirection.TopDown;
            flpBody.WrapContents = false;
            flpBody.AutoScroll = true;
            flpBody.Padding = new Padding(0);
            flpBody.Margin = new Padding(0);

            // Footer panel
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Height = 44;
            pnlFooter.Width = 400;
            pnlFooter.Margin = new Padding(0, 8, 0, 0);

            btnAdd.Name = "btnAdd";
            btnAdd.Text = "Thêm";
            btnAdd.Size = new Size(80, 30);
            btnAdd.Location = new Point(0, 7);

            btnEdit.Name = "btnEdit";
            btnEdit.Text = "Sửa";
            btnEdit.Size = new Size(80, 30);
            btnEdit.Location = new Point(90, 7);

            btnDelete.Name = "btnDelete";
            btnDelete.Text = "Xóa";
            btnDelete.Size = new Size(80, 30);
            btnDelete.Location = new Point(180, 7);

            pnlFooter.Controls.Add(btnAdd);
            pnlFooter.Controls.Add(btnEdit);
            pnlFooter.Controls.Add(btnDelete);

            flpBody.Controls.Add(pnlFooter);

            Controls.Add(flpBody);
            Controls.Add(lblTitle);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
