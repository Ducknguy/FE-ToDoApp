using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FE_ToDoApp.Calendar
{
    partial class calendar
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblMonthYear;
        private TableLayoutPanel pnlGrid;

        public List<DayCell> matrixDays = new List<DayCell>();

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitCustomInterface()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Lịch Công Việc";
            this.Size = new Size(1100, 760);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            this.DoubleBuffered = true;

            Panel pnlHeader = new Panel();
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 60;
            pnlHeader.BackColor = Color.WhiteSmoke;
            this.Controls.Add(pnlHeader);

            Button btnPrev = CreateNavButton("<", DockStyle.Left);
            btnPrev.Click += (s, e) => ChangeMonth(-1);
            pnlHeader.Controls.Add(btnPrev);

            Button btnNext = CreateNavButton(">", DockStyle.Right);
            btnNext.Click += (s, e) => ChangeMonth(1);
            pnlHeader.Controls.Add(btnNext);

            lblMonthYear = new Label();
            lblMonthYear.Dock = DockStyle.Fill;
            lblMonthYear.TextAlign = ContentAlignment.MiddleCenter;
            lblMonthYear.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblMonthYear.ForeColor = Color.DarkSlateGray;
            lblMonthYear.Cursor = Cursors.Hand;

            ToolTip tt = new ToolTip();
            tt.SetToolTip(lblMonthYear, "Nhấn vào đây để chọn nhanh Tháng/Năm");

            pnlHeader.Controls.Add(lblMonthYear);
            lblMonthYear.BringToFront();

            Panel pnlSpacer = new Panel();
            pnlSpacer.Dock = DockStyle.Top;
            pnlSpacer.Height = 30;
            pnlSpacer.BackColor = Color.White;
            this.Controls.Add(pnlSpacer);
            pnlSpacer.BringToFront();

            pnlGrid = new TableLayoutPanel();
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.ColumnCount = 7;
            pnlGrid.RowCount = 7;
            pnlGrid.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            pnlGrid.Padding = new Padding(20, 0, 20, 20);

            for (int i = 0; i < 7; i++) pnlGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 7));
            pnlGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            for (int i = 0; i < 6; i++) pnlGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 6));

            this.Controls.Add(pnlGrid);
            pnlGrid.BringToFront();

            string[] daysOfWeek = { "Chủ Nhật", "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy" };
            for (int i = 0; i < 7; i++)
            {
                Label lbl = new Label();
                lbl.Text = daysOfWeek[i];
                lbl.Dock = DockStyle.Fill;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                lbl.BackColor = Color.AliceBlue;
                if (i == 0 || i == 6) lbl.ForeColor = Color.Red;
                pnlGrid.Controls.Add(lbl, i, 0);
            }

            matrixDays.Clear();
            for (int i = 0; i < 42; i++)
            {
                DayCell cell = new DayCell();
                cell.MouseUp += DayCell_MouseUp;
                pnlGrid.Controls.Add(cell);
                matrixDays.Add(cell);
            }
        }

        private Button CreateNavButton(string text, DockStyle dock)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Dock = dock;
            btn.Width = 60;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Consolas", 15, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            return btn;
        }
    }
}