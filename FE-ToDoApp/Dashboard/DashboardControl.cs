using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace FE_ToDoApp.Dashboard
{
    public partial class DashboardControl : UserControl
    {
        private string strConn = @"Data Source=.;Initial Catalog=user;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public DashboardControl()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private int currentUserID = 1;

        public void LoadDashboardData()
        {
            lblDate.Text = DateTime.Now.ToString("dddd, MMMM dd");
            flowStats.Controls.Clear();
            tblLists.Controls.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    LoadStats(conn);

                    Panel pnlToday = CreateListCard("Today's Agenda");
                    string sqlToday = "SELECT Title, DueDate, Category, Status FROM [Task] " +
                                      "WHERE CAST(DueDate AS DATE) = CAST(GETDATE() AS DATE) ORDER BY DueDate ASC";

                    LoadTasksToContainer(conn, pnlToday, sqlToday);
                    tblLists.Controls.Add(pnlToday, 0, 0);

                    Panel pnlUpcoming = CreateListCard("Upcoming Schedules");
                    string sqlUpcoming = "SELECT Title, DueDate, Category, Status FROM [Task] " +
                                         "WHERE CAST(DueDate AS DATE) > CAST(GETDATE() AS DATE) ORDER BY DueDate ASC";

                    LoadTasksToContainer(conn, pnlUpcoming, sqlUpcoming);
                    tblLists.Controls.Add(pnlUpcoming, 1, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Thông báo");
            }
        }

        private void LoadTasksToContainer(SqlConnection conn, Panel card, string query)
        {
            FlowLayoutPanel container = (FlowLayoutPanel)card.Controls["listContainer"];
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Xóa dòng cmd.Parameters.AddWithValue nếu có
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string title = reader["Title"].ToString();
                        string category = reader["Category"]?.ToString() ?? "General";
                        DateTime dueDate = Convert.ToDateTime(reader["DueDate"]);
                        bool isDone = reader["Status"].ToString() == "Done";

                        Color color = GetColorByCategory(category);
                        string timeInfo = dueDate.ToString("HH:mm") + " • " + category;

                        container.Controls.Add(CreateTaskRow(title, timeInfo, color, isDone));
                    }
                }
            }
        }

        private Panel CreateTaskRow(string title, string info, Color tagColor, bool isDone)
        {
            Panel row = new Panel { Size = new Size(400, 55), Margin = new Padding(0, 5, 0, 5) };

            CheckBox ck = new CheckBox { Checked = isDone, Width = 25, Location = new Point(5, 15), Cursor = Cursors.Hand };

            Label lblT = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10, isDone ? FontStyle.Strikeout : FontStyle.Bold),
                ForeColor = isDone ? Color.Gray : Color.Black,
                Location = new Point(35, 8),
                AutoSize = true
            };

            Label lblI = new Label
            {
                Text = info,
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.Gray,
                Location = new Point(35, 28),
                AutoSize = true
            };

            Panel dot = new Panel
            {
                BackColor = tagColor,
                Size = new Size(8, 8),
                Location = new Point(370, 20),
                Anchor = AnchorStyles.Right
            };

            row.Controls.AddRange(new Control[] { ck, lblT, lblI, dot });
            return row;
        }

        private Color GetColorByCategory(string category)
        {
            switch (category.ToLower())
            {
                case "work": return Color.DodgerBlue;
                case "health": return Color.Orange;
                case "personal": return Color.MediumPurple;
                default: return Color.LightGray;
            }
        }

        private Panel CreateListCard(string title)
        {
            Panel card = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Margin = new Padding(15), Padding = new Padding(10) };

            card.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, card.ClientRectangle, Color.FromArgb(230, 230, 230), ButtonBorderStyle.Solid);

            Label lbl = new Label { Text = title, Font = new Font("Segoe UI", 14, FontStyle.Bold), Location = new Point(15, 15), AutoSize = true };

            FlowLayoutPanel listContainer = new FlowLayoutPanel
            {
                Name = "listContainer",
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Location = new Point(15, 60),
                Size = new Size(card.Width - 30, 350),
                AutoScroll = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
            };

            card.Controls.Add(lbl);
            card.Controls.Add(listContainer);
            return card;
        }

        private void LoadStats(SqlConnection conn)
        {
            int today = GetCount(conn, "SELECT COUNT(*) FROM [Task] WHERE CAST(DueDate AS DATE) = CAST(GETDATE() AS DATE)");
            int upcoming = GetCount(conn, "SELECT COUNT(*) FROM [Task] WHERE DueDate > GETDATE()");
            int overdue = GetCount(conn, "SELECT COUNT(*) FROM [Task] WHERE DueDate < GETDATE() AND Status != 'Done'");
            int done = GetCount(conn, "SELECT COUNT(*) FROM [Task] WHERE Status = 'Done'");

            flowStats.Controls.Add(CreateStatCard(today.ToString(), "Today Tasks", Color.AliceBlue, "📅"));
            flowStats.Controls.Add(CreateStatCard(upcoming.ToString(), "Upcoming", Color.Beige, "🕒"));
            flowStats.Controls.Add(CreateStatCard(overdue.ToString(), "Overdue", Color.MistyRose, "⚠️"));
            flowStats.Controls.Add(CreateStatCard(done.ToString(), "Completed", Color.Honeydew, "✅"));
        }

        private int GetCount(SqlConnection conn, string query)
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                return Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
            }
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
    }
}