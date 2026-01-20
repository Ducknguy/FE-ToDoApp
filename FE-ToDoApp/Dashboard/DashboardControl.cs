using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace FE_ToDoApp.Dashboard
{
    public partial class DashboardControl : UserControl
    {
        // Chuỗi kết nối (bạn chỉnh lại tên server nếu cần)
        private string strConn = @"Data Source=.;Initial Catalog=user;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public DashboardControl()
        {
            InitializeComponent(); // Gọi hàm bên file Designer
            LoadDashboardData();   // Gọi hàm tải dữ liệu
        }

        public void LoadDashboardData()
        {
            // Hiển thị ngày tháng Tiếng Việt
            lblDate.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy", new CultureInfo("vi-VN"));

            // Xóa dữ liệu cũ để nạp mới
            flowStats.Controls.Clear();
            tblLists.Controls.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    LoadStats(conn); // Tải 4 thẻ thống kê

                    // --- 1. CỘT TRÁI: CÔNG VIỆC HIỆN TẠI (Hôm nay & Chưa qua giờ) ---
                    Panel pnlToday = CreateListCard("Các công việc hiện tại");
                    string sqlToday = @"SELECT Id, Title, DueDate, Status FROM [Task] 
                                        WHERE CAST(DueDate AS DATE) = CAST(GETDATE() AS DATE) 
                                          AND DueDate >= GETDATE() 
                                        ORDER BY DueDate ASC";

                    LoadTasksToContainer(conn, pnlToday, sqlToday, true); // true = Hiện checkbox
                    tblLists.Controls.Add(pnlToday, 0, 0);

                    // --- 2. CỘT PHẢI: CÔNG VIỆC QUÁ HẠN (Tất cả việc cũ chưa xong) ---
                    Panel pnlRight = CreateListCard("Các công việc quá hạn");
                    string sqlRight = @"SELECT Id, Title, DueDate, Status FROM [Task] 
                                        WHERE DueDate < GETDATE() AND Status != 'Done'
                                        ORDER BY DueDate ASC";

                    LoadTasksToContainer(conn, pnlRight, sqlRight, false); // false = Chỉ hiện nút xóa
                    tblLists.Controls.Add(pnlRight, 1, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Dashboard: " + ex.Message);
            }
        }

        private void LoadTasksToContainer(SqlConnection conn, Panel card, string query, bool showCheckbox)
        {
            FlowLayoutPanel container = (FlowLayoutPanel)card.Controls["listContainer"];
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["Id"]);
                        string title = reader["Title"].ToString();
                        DateTime dueDate = Convert.ToDateTime(reader["DueDate"]);
                        bool isDone = reader["Status"].ToString() == "Done";

                        Color color = Color.DodgerBlue;
                        if (!isDone && dueDate < DateTime.Now) color = Color.OrangeRed;
                        if (isDone) color = Color.SeaGreen;

                        // Hiển thị: Ngày/Tháng - Giờ:Phút
                        string timeInfo = dueDate.ToString("dd/MM - HH:mm");

                        container.Controls.Add(CreateTaskRow(id, title, timeInfo, color, isDone, showCheckbox));
                    }
                }
            }
        }

        // Tạo giao diện cho 1 dòng công việc
        private Panel CreateTaskRow(int taskId, string title, string info, Color tagColor, bool isDone, bool showCheckbox)
        {
            Panel row = new Panel { Size = new Size(400, 60), Margin = new Padding(0, 5, 0, 5) };
            int textX = showCheckbox ? 35 : 15;

            // 1. Checkbox
            if (showCheckbox)
            {
                CheckBox ck = new CheckBox { Checked = isDone, Width = 25, Location = new Point(5, 18), Cursor = Cursors.Hand };
                ck.Click += (s, e) => { ToggleTaskStatus(taskId, ck.Checked); };
                row.Controls.Add(ck);
            }

            // 2. Tiêu đề
            Label lblT = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10, isDone ? FontStyle.Strikeout : FontStyle.Bold),
                ForeColor = isDone ? Color.Gray : Color.Black,
                Location = new Point(textX, 8),
                AutoSize = true
            };

            // 3. Thông tin thời gian
            Label lblI = new Label
            {
                Text = isDone ? "✓ Đã hoàn thành" : info,
                Font = new Font("Segoe UI", 8, isDone ? FontStyle.Bold : FontStyle.Regular),
                ForeColor = isDone ? Color.SeaGreen : Color.Gray,
                Location = new Point(textX, 30),
                AutoSize = true
            };

            // 4. Nút Xóa
            Button btnDel = new Button
            {
                Text = "🗑️",
                Size = new Size(30, 30),
                Location = new Point(330, 15),
                Anchor = AnchorStyles.Right,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.Red,
                Cursor = Cursors.Hand
            };
            btnDel.FlatAppearance.BorderSize = 0;
            btnDel.Click += (s, e) => {
                if (MessageBox.Show("Xóa công việc này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes) DeleteTask(taskId);
            };

            // 5. Vạch màu
            Panel dot = new Panel { BackColor = tagColor, Size = new Size(5, 40), Location = new Point(370, 10), Anchor = AnchorStyles.Right };

            row.Controls.AddRange(new Control[] { lblT, lblI, btnDel, dot });
            return row;
        }

        private void ToggleTaskStatus(int id, bool isChecked)
        {
            ExecuteSql("UPDATE [Task] SET Status = @Status WHERE Id = @Id", cmd => {
                cmd.Parameters.AddWithValue("@Status", isChecked ? "Done" : "Pending");
                cmd.Parameters.AddWithValue("@Id", id);
            });
            LoadDashboardData();
        }

        private void DeleteTask(int id)
        {
            ExecuteSql("DELETE FROM [Task] WHERE Id = @Id", cmd => cmd.Parameters.AddWithValue("@Id", id));
            LoadDashboardData();
        }

        // Hàm hỗ trợ chạy SQL nhanh gọn
        private void ExecuteSql(string query, Action<SqlCommand> paramBuilder)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        paramBuilder(cmd);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // --- CÁC HÀM TẠO UI THỐNG KÊ & DANH SÁCH ---
        private void LoadStats(SqlConnection conn)
        {
            int today = GetCount(conn, "SELECT COUNT(*) FROM [Task] WHERE CAST(DueDate AS DATE) = CAST(GETDATE() AS DATE)");
            int upcoming = GetCount(conn, "SELECT COUNT(*) FROM [Task] WHERE DueDate > GETDATE()");
            int overdue = GetCount(conn, "SELECT COUNT(*) FROM [Task] WHERE DueDate < GETDATE() AND Status != 'Done'");
            int done = GetCount(conn, "SELECT COUNT(*) FROM [Task] WHERE Status = 'Done'");

            flowStats.Controls.Add(CreateStatCard(today.ToString(), "Hôm nay", Color.AliceBlue, "📅"));
            flowStats.Controls.Add(CreateStatCard(upcoming.ToString(), "Sắp tới", Color.Beige, "🕒"));
            flowStats.Controls.Add(CreateStatCard(overdue.ToString(), "Quá hạn", Color.MistyRose, "⚠️"));
            flowStats.Controls.Add(CreateStatCard(done.ToString(), "Hoàn thành", Color.Honeydew, "✅"));
        }

        private int GetCount(SqlConnection conn, string query)
        {
            using (SqlCommand cmd = new SqlCommand(query, conn)) { return Convert.ToInt32(cmd.ExecuteScalar() ?? 0); }
        }

        private Panel CreateStatCard(string value, string title, Color bgColor, string icon)
        {
            Panel card = new Panel { Size = new Size(220, 130), BackColor = Color.White, Margin = new Padding(10) };
            card.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, card.ClientRectangle, Color.FromArgb(230, 230, 230), ButtonBorderStyle.Solid);
            Label lblVal = new Label { Text = value, Font = new Font("Segoe UI", 22, FontStyle.Bold), Location = new Point(15, 10), AutoSize = true };
            Label lblTit = new Label { Text = title, ForeColor = Color.DimGray, Location = new Point(15, 60), AutoSize = true };
            Label lblIcon = new Label { Text = icon, Location = new Point(170, 15), Font = new Font("Segoe UI", 18), AutoSize = true };
            Panel footer = new Panel { BackColor = bgColor, Dock = DockStyle.Bottom, Height = 5 };
            card.Controls.AddRange(new Control[] { lblVal, lblTit, lblIcon, footer });
            return card;
        }

        private Panel CreateListCard(string title)
        {
            Panel card = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Margin = new Padding(15), Padding = new Padding(10) };
            card.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, card.ClientRectangle, Color.FromArgb(230, 230, 230), ButtonBorderStyle.Solid);
            Label lbl = new Label { Text = title, Font = new Font("Segoe UI", 14, FontStyle.Bold), Location = new Point(15, 15), AutoSize = true };
            FlowLayoutPanel listContainer = new FlowLayoutPanel { Name = "listContainer", FlowDirection = FlowDirection.TopDown, WrapContents = false, Location = new Point(15, 60), Size = new Size(card.Width - 30, 350), AutoScroll = true, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom };
            card.Controls.Add(lbl); card.Controls.Add(listContainer);
            return card;
        }
    }
}