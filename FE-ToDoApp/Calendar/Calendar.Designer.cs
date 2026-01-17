namespace FE_ToDoApp.Calendar
{
    partial class calendar
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlGrid = new System.Windows.Forms.TableLayoutPanel();
            this.lblMonthYear = new System.Windows.Forms.Label();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.tlpWeekHeader = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();

            // 
            // lblMonthYear
            // 
            this.lblMonthYear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMonthYear.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold); // Tăng font size
            this.lblMonthYear.ForeColor = System.Drawing.Color.Navy; // Đổi màu chữ cho nổi bật
            this.lblMonthYear.Location = new System.Drawing.Point(250, 20);
            this.lblMonthYear.Name = "lblMonthYear";
            this.lblMonthYear.Size = new System.Drawing.Size(300, 45);
            this.lblMonthYear.TabIndex = 1;
            this.lblMonthYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMonthYear.Click += new System.EventHandler(this.LblMonthYear_Click);

            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPrev.BackColor = System.Drawing.Color.White;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat; // Nút phẳng hiện đại
            this.btnPrev.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPrev.Location = new System.Drawing.Point(170, 25);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(50, 40);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.BtnPrev_Click);

            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnNext.Location = new System.Drawing.Point(580, 25);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(50, 40);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);

            // 
            // tlpWeekHeader (Tiêu đề Thứ)
            // 
            this.tlpWeekHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpWeekHeader.ColumnCount = 7;
            this.tlpWeekHeader.RowCount = 1;
            this.tlpWeekHeader.Location = new System.Drawing.Point(20, 80);
            this.tlpWeekHeader.Name = "tlpWeekHeader";
            this.tlpWeekHeader.Size = new System.Drawing.Size(760, 40); // Chiều cao header
            this.tlpWeekHeader.TabIndex = 4;
            // Kẻ viền cho header (CellBorderStyle)
            this.tlpWeekHeader.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpWeekHeader.BackColor = System.Drawing.Color.FromArgb(240, 240, 240); // Màu nền xám nhẹ cho header

            for (int i = 0; i < 7; i++)
                this.tlpWeekHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28F));

            string[] days = { "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy", "Chủ Nhật" };
            for (int i = 0; i < 7; i++)
            {
                System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
                lbl.Text = days[i];
                lbl.Dock = System.Windows.Forms.DockStyle.Fill;
                lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                // Style cho chữ tiêu đề
                lbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
                lbl.ForeColor = System.Drawing.Color.DarkSlateGray;

                // Tô màu riêng cho Chủ Nhật (cột cuối cùng)
                if (i == 6) lbl.ForeColor = System.Drawing.Color.Red;

                this.tlpWeekHeader.Controls.Add(lbl, i, 0);
            }

            // 
            // pnlGrid (Lưới lịch)
            // 
            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrid.ColumnCount = 7;
            this.pnlGrid.RowCount = 6;
            this.pnlGrid.Location = new System.Drawing.Point(20, 120); // Dính liền với header (Header cao 40 + Y=80 -> Y=120)
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(760, 460);
            this.pnlGrid.TabIndex = 0;
            // Kẻ viền cho lưới lịch
            this.pnlGrid.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pnlGrid.BackColor = System.Drawing.Color.White;

            for (int i = 0; i < 7; i++)
                this.pnlGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            for (int i = 0; i < 6; i++)
                this.pnlGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66F));

            this.matrixDays = new DayCell[42];
            for (int i = 0; i < 42; i++)
            {
                this.matrixDays[i] = new DayCell();
                this.matrixDays[i].MouseUp += new System.Windows.Forms.MouseEventHandler(this.DayCell_MouseUp);

                // Ép vị trí (Quan trọng)
                int col = i % 7;
                int row = i / 7;
                this.pnlGrid.Controls.Add(this.matrixDays[i], col, row);
            }

            // 
            // calendar Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke; // Màu nền Form sáng sủa
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.tlpWeekHeader);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.lblMonthYear);
            this.Controls.Add(this.pnlGrid);
            this.Name = "calendar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch Công Việc";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlGrid;
        private System.Windows.Forms.TableLayoutPanel tlpWeekHeader;
        private System.Windows.Forms.Label lblMonthYear;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private DayCell[] matrixDays;
    }
}