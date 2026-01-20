using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FE_ToDoApp.Lich_Trinh
{
    partial class TodoDetailItemControl
    {
        private IContainer components = null!;

        private Panel pnlHeader = null!;
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
            pnlHeader = new Panel();
            lblTitle = new Label();
            flpBody = new FlowLayoutPanel();
            pnlFooter = new Panel();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            pnlHeader.SuspendLayout();
            flpBody.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(10, 9);
            pnlHeader.Margin = new Padding(3, 2, 3, 2);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(0, 0, 0, 9);
            pnlHeader.Size = new Size(905, 38);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(112, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ten detail";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flpBody
            // 
            flpBody.AutoScroll = true;
            flpBody.Controls.Add(pnlFooter);
            flpBody.Dock = DockStyle.Bottom;
            flpBody.FlowDirection = FlowDirection.TopDown;
            flpBody.Location = new Point(10, 49);
            flpBody.Margin = new Padding(0);
            flpBody.Name = "flpBody";
            flpBody.Size = new Size(905, 440);
            flpBody.TabIndex = 1;
            flpBody.WrapContents = false;
            // 
            // pnlFooter
            // 
            pnlFooter.Controls.Add(btnAdd);
            pnlFooter.Controls.Add(btnEdit);
            pnlFooter.Controls.Add(btnDelete);
            pnlFooter.Location = new Point(0, 6);
            pnlFooter.Margin = new Padding(0, 6, 0, 0);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(901, 33);
            pnlFooter.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(0, 5);
            btnAdd.Margin = new Padding(3, 2, 3, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(70, 22);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm";
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(79, 5);
            btnEdit.Margin = new Padding(3, 2, 3, 2);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(70, 22);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Sửa";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(158, 5);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(70, 22);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xóa";            // 
            // TodoDetailItemControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(flpBody);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 2, 3, 2);
            Name = "TodoDetailItemControl";
            Padding = new Padding(10, 9, 10, 9);
            Size = new Size(925, 498);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            flpBody.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
