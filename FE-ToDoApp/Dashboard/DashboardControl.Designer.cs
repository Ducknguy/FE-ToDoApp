using System.Drawing;
using System.Windows.Forms;

namespace FE_ToDoApp.Dashboard
{
    partial class DashboardControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblDate = new Label();
            flowStats = new FlowLayoutPanel();
            tblLists = new TableLayoutPanel();
            pnlHeader.SuspendLayout();
            SuspendLayout();

            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblDate);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1200, 100);
            pnlHeader.TabIndex = 0;

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(215, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Thống kê";

            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 12F);
            lblDate.ForeColor = Color.Gray;
            lblDate.Location = new Point(30, 70);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(200, 28);
            lblDate.TabIndex = 1;
            lblDate.Text = "Sunday, December 21";

            // 
            // flowStats
            // 
            flowStats.BackColor = Color.FromArgb(250, 250, 250);
            flowStats.Dock = DockStyle.Top;
            flowStats.Location = new Point(0, 100);
            flowStats.Name = "flowStats";
            flowStats.Padding = new Padding(20, 10, 0, 10);
            flowStats.Size = new Size(1200, 180);
            flowStats.TabIndex = 1;

            // 
            // tblLists
            // 
            tblLists.ColumnCount = 2;
            tblLists.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblLists.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblLists.Dock = DockStyle.Fill;
            tblLists.Location = new Point(0, 280);
            tblLists.Name = "tblLists";
            tblLists.Padding = new Padding(20);
            tblLists.RowCount = 1;
            tblLists.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblLists.Size = new Size(1200, 520);
            tblLists.TabIndex = 2;

            // 
            // DashboardControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            Controls.Add(tblLists);
            Controls.Add(flowStats);
            Controls.Add(pnlHeader);
            Name = "DashboardControl";
            Size = new Size(1200, 800);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        public System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.FlowLayoutPanel flowStats;
        public System.Windows.Forms.TableLayoutPanel tblLists;
    }
}