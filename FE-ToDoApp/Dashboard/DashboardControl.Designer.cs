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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.flowStats = new System.Windows.Forms.FlowLayoutPanel();
            this.tblLists = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblDate);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 90;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 90);
            this.pnlHeader.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(226, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dashboard";

            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDate.ForeColor = System.Drawing.Color.Gray;
            this.lblDate.Location = new System.Drawing.Point(28, 65);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(153, 20);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Sunday, December 21";

            // 
            // flowStats
            // 
            this.flowStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.flowStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowStats.Location = new System.Drawing.Point(0, 90);
            this.flowStats.Name = "flowStats";
            this.flowStats.Padding = new System.Windows.Forms.Padding(15, 5, 0, 10);
            this.flowStats.Size = new System.Drawing.Size(1000, 160);
            this.flowStats.TabIndex = 1;

            // 
            // tblLists
            // 
            this.tblLists.ColumnCount = 2;
            this.tblLists.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLists.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLists.Location = new System.Drawing.Point(0, 250);
            this.tblLists.Name = "tblLists";
            this.tblLists.Padding = new System.Windows.Forms.Padding(10);
            this.tblLists.RowCount = 1;
            this.tblLists.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLists.Size = new System.Drawing.Size(1000, 360);
            this.tblLists.TabIndex = 2;

            // 
            // DashboardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.Controls.Add(this.tblLists);
            this.Controls.Add(this.flowStats);
            this.Controls.Add(this.pnlHeader);
            this.Name = "DashboardControl";
            this.Size = new System.Drawing.Size(1000, 610);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        public System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.FlowLayoutPanel flowStats;
        public System.Windows.Forms.TableLayoutPanel tblLists;
    }
}