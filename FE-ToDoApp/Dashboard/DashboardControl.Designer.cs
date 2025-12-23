namespace FE_ToDoApp.Dashboard
{
    partial class DashboardControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblDate = new Label();
            lblTitle = new Label();
            flowStats = new FlowLayoutPanel();
            tblLists = new TableLayoutPanel();

            // pnlHeader
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 90;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblDate);

            // flowStats (Chứa 4 thẻ thống kê)
            flowStats.Dock = DockStyle.Top;
            flowStats.Height = 160;
            flowStats.BackColor = Color.FromArgb(250, 250, 250);

            // tblLists (Chứa 2 bảng danh sách chi tiết)
            tblLists.Dock = DockStyle.Fill;
            tblLists.ColumnCount = 2;
            tblLists.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblLists.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblLists.RowCount = 1;
            tblLists.Padding = new Padding(10);

            // DashboardControl
            this.Controls.Add(tblLists);
            this.Controls.Add(flowStats);
            this.Controls.Add(pnlHeader);
            this.Size = new Size(1000, 700);
            this.BackColor = Color.FromArgb(245, 245, 245);
        }

        private Panel pnlHeader;
        private Label lblDate;
        private Label lblTitle;
        private FlowLayoutPanel flowStats;
        private TableLayoutPanel tblLists;
    }
}