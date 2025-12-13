using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Google.Apis.Calendar.v3.Data; // Thư viện Google để hiểu object 'Event'

namespace FE_ToDoApp.Calendar
{
    // Kế thừa từ Form để biến Class này thành một cửa sổ
    public class EventDetailsForm : Form
    {
        // Hàm khởi tạo: Nhận vào Tiêu đề ngày và Danh sách sự kiện
        public EventDetailsForm(string dateTitle, List<Event> events)
        {
            // --- 1. Cấu hình giao diện cửa sổ (Form) ---
            this.Text = "Chi tiết công việc";
            this.Size = new Size(450, 550); // Chiều rộng, cao
            this.StartPosition = FormStartPosition.CenterParent; // Hiện giữa form cha
            this.ShowIcon = false;
            this.MinimizeBox = false; // Ẩn nút thu nhỏ
            this.MaximizeBox = false; // Ẩn nút phóng to
            this.BackColor = Color.White;

            // --- 2. Tạo Tiêu đề (VD: Danh sách việc ngày 2025-12-01) ---
            Label lblTitle = new Label();
            lblTitle.Text = $"📅 Danh sách việc ngày {dateTitle}";
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 60;
            lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.ForeColor = Color.DarkSlateBlue;
            lblTitle.BackColor = Color.WhiteSmoke;
            this.Controls.Add(lblTitle);

            // --- 3. Tạo vùng chứa danh sách (FlowLayoutPanel) ---
            // Cái này giúp danh sách tự cuộn nếu có nhiều việc
            FlowLayoutPanel panelList = new FlowLayoutPanel();
            panelList.Dock = DockStyle.Fill;
            panelList.AutoScroll = true; // Bật thanh cuộn
            panelList.FlowDirection = FlowDirection.TopDown; // Xếp từ trên xuống
            panelList.WrapContents = false; // Không cho nhảy dòng ngang
            panelList.Padding = new Padding(10);
            this.Controls.Add(panelList);
            panelList.BringToFront(); // Đưa lên trên để ko bị che

            // --- 4. Duyệt danh sách và vẽ từng ô công việc ---
            if (events == null || events.Count == 0)
            {
                // Nếu không có việc gì (đề phòng)
                Label lblEmpty = new Label();
                lblEmpty.Text = "Không có dữ liệu chi tiết.";
                lblEmpty.AutoSize = true;
                lblEmpty.Font = new Font("Segoe UI", 12);
                panelList.Controls.Add(lblEmpty);
            }
            else
            {
                // Vòng lặp tạo từng ô
                foreach (var evt in events)
                {
                    Panel pnlItem = CreateEventItem(evt);
                    panelList.Controls.Add(pnlItem);
                }
            }
        }

        // --- Hàm phụ: Tạo giao diện cho 1 công việc ---
        private Panel CreateEventItem(Event evt)
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(400, 90); // Kích thước mỗi ô
            pnl.BackColor = Color.AliceBlue;
            pnl.Margin = new Padding(0, 0, 0, 10); // Cách ô dưới 10px
            pnl.BorderStyle = BorderStyle.FixedSingle;

            // A. Hiển thị giờ
            Label lblTime = new Label();
            if (evt.Start.DateTime.HasValue)
                lblTime.Text = evt.Start.DateTime.Value.ToString("HH:mm");
            else
                lblTime.Text = "Cả ngày"; // Sự kiện All-day

            lblTime.Location = new Point(10, 15);
            lblTime.Size = new Size(70, 25);
            lblTime.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblTime.ForeColor = Color.OrangeRed;
            pnl.Controls.Add(lblTime);

            // B. Hiển thị Tên công việc
            Label lblSummary = new Label();
            lblSummary.Text = evt.Summary; // Tên sự kiện
            lblSummary.Location = new Point(90, 15);
            lblSummary.Size = new Size(290, 25);
            lblSummary.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblSummary.ForeColor = Color.Black;
            pnl.Controls.Add(lblSummary);

            // C. Hiển thị Mô tả (nếu có)
            string desc = evt.Description ?? "Không có mô tả thêm";
            // Cắt bớt nếu dài quá
            if (desc.Length > 55) desc = desc.Substring(0, 55) + "...";

            Label lblDesc = new Label();
            lblDesc.Text = desc;
            lblDesc.Location = new Point(90, 45);
            lblDesc.Size = new Size(290, 40);
            lblDesc.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            lblDesc.ForeColor = Color.Gray;
            pnl.Controls.Add(lblDesc);

            return pnl;
        }
    }
}