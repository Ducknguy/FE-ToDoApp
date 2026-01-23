using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Globalization;

namespace FE_ToDoApp.Dashboard
{
    public partial class DashboardControl : UserControl
    {
        private string strConn = $"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ToDoApp.db")};Version=3;";

        public DashboardControl()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        public void LoadDashboardData()
        {
            lblDate.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy", new CultureInfo("vi-VN"));

            flowStats.Controls.Clear();
            tblLists.Controls.Clear();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(strConn))
                {
                    conn.Open();
                    LoadStats(conn);

                    // --- PHẦN 1: CÔNG VIỆC SẮP TỚI (Upcoming) ---
                    Panel pnlToday = CreateListCard("Các công việc sắp tới");

                    string sqlUpcoming = @"
                        SELECT 
                            i.Id_weekly AS ID, 
                            i.Title, 
                            i.StartDate AS TaskDate, 
                            i.Status, 
                            d.CategoryName AS GroupName,
                            'Calendar' AS SourceType
                        FROM WeekCategory_item i
                        JOIN WeekCategory_detail d ON i.CategoryId = d.CategoryId
                        WHERE date(i.StartDate) >= date('now', 'localtime')
                        
                        UNION ALL
                        
                        SELECT 
                            t.id_item AS ID, 
                            t.item_detail AS Title, 
                            l.created_at AS TaskDate, 
                            t.status AS Status, 
                            l.title AS GroupName,
                            'Todo' AS SourceType
                        FROM Todo_List_Item t
                        JOIN Todo_List_Detail l ON t.id_todo = l.id_todo
                        WHERE date(l.created_at) >= date('now', 'localtime')

                        ORDER BY TaskDate ASC";

                    LoadTasksToContainer(conn, pnlToday, sqlUpcoming, true);
                    tblLists.Controls.Add(pnlToday, 0, 0);


                    // --- PHẦN 2: CÔNG VIỆC QUÁ HẠN (Overdue) ---
                    Panel pnlOverdue = CreateListCard("Các công việc quá hạn");

                    string sqlOverdue = @"
                        SELECT 
                            i.Id_weekly AS ID, 
                            i.Title, 
                            i.StartDate AS TaskDate, 
                            i.Status, 
                            d.CategoryName AS GroupName,
                            'Calendar' AS SourceType
                        FROM WeekCategory_item i
                        JOIN WeekCategory_detail d ON i.CategoryId = d.CategoryId
                        WHERE date(i.StartDate) < date('now', 'localtime') AND i.Status = 0
                        
                        UNION ALL
                        
                        SELECT 
                            t.id_item AS ID, 
                            t.item_detail AS Title, 
                            l.created_at AS TaskDate, 
                            t.status AS Status, 
                            l.title AS GroupName,
                            'Todo' AS SourceType
                        FROM Todo_List_Item t
                        JOIN Todo_List_Detail l ON t.id_todo = l.id_todo
                        WHERE date(l.created_at) < date('now', 'localtime') AND (t.status = 0 OR t.status IS NULL)

                        ORDER BY TaskDate ASC";

                    LoadTasksToContainer(conn, pnlOverdue, sqlOverdue, false);
                    tblLists.Controls.Add(pnlOverdue, 1, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Dashboard: " + ex.Message);
            }
        }

        private void LoadTasksToContainer(SQLiteConnection conn, Panel card, string query, bool showCheckbox)
        {
            FlowLayoutPanel container = (FlowLayoutPanel)card.Controls["listContainer"];

            int rowWidth = container.ClientSize.Width + 520;
            if (rowWidth <= 0) rowWidth = 400;

            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["ID"]);
                        string title = reader["Title"].ToString();
                        string categoryName = reader["GroupName"].ToString();
                        string sourceType = reader["SourceType"].ToString();

                        string fullDisplayTitle = $"{categoryName} - {title}";
                        DateTime taskDate = Convert.ToDateTime(reader["TaskDate"]);

                        int statusInt = 0;
                        if (reader["Status"] != DBNull.Value)
                            statusInt = Convert.ToInt32(reader["Status"]);

                        bool isDone = (statusInt == 1);

                        Color color = Color.DodgerBlue;
                        if (!isDone && taskDate.Date < DateTime.Now.Date) color = Color.OrangeRed;
                        if (isDone) color = Color.SeaGreen;

                        string timeInfo = taskDate.ToString("dddd, dd/MM/yyyy", new CultureInfo("vi-VN"));

                        container.Controls.Add(CreateTaskRow(id, fullDisplayTitle, timeInfo, color, isDone, showCheckbox, rowWidth, sourceType));
                    }
                }
            }
        }

        private Panel CreateTaskRow(int taskId, string title, string info, Color tagColor, bool isDone, bool showCheckbox, int width, string sourceType)
        {
            Panel row = new Panel
            {
                Size = new Size(width, 55),
                Margin = new Padding(0, 5, 0, 5)
            };

            int textX = showCheckbox ? 35 : 15;

            // --- TẠO BADGE (NHÃN) PHÂN LOẠI ---
            Label lblBadge = new Label
            {
                Text = sourceType,
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Padding = new Padding(3),
                Location = new Point(width - 160, 15),
                Anchor = AnchorStyles.Right
            };

            if (sourceType == "Calendar")
            {
                lblBadge.BackColor = Color.MistyRose;
                lblBadge.ForeColor = Color.Maroon;
            }
            else
            {
                lblBadge.BackColor = Color.LightSkyBlue;
                lblBadge.ForeColor = Color.Navy;
            }

            if (isDone)
            {
                row.BackColor = Color.FromArgb(240, 255, 240);

                if (showCheckbox)
                {
                    CheckBox ck = new CheckBox { Checked = true, Width = 25, Location = new Point(10, 18), Cursor = Cursors.Hand };
                    ck.Click += (s, e) => { ToggleTaskStatus(taskId, false, sourceType); };
                    row.Controls.Add(ck);
                }

                Label lblT = new Label
                {
                    Text = title,
                    Font = new Font("Segoe UI", 10, FontStyle.Strikeout),
                    ForeColor = Color.Gray,
                    Location = new Point(40, 8),
                    AutoSize = true
                };
                row.Controls.Add(lblT);

                Label lblI = new Label
                {
                    Text = info,
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    ForeColor = Color.Gray,
                    Location = new Point(40, 30),
                    AutoSize = true
                };
                row.Controls.Add(lblI);

                Button btnDel = new Button
                {
                    Text = "🗑️",
                    Size = new Size(30, 30),
                    Location = new Point(width - 50, 12),
                    Anchor = AnchorStyles.Right,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Transparent,
                    ForeColor = Color.Red,
                    Cursor = Cursors.Hand
                };
                btnDel.FlatAppearance.BorderSize = 0;
                btnDel.Click += (s, e) => {
                    if (MessageBox.Show("Xóa công việc này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        DeleteTask(taskId, sourceType);
                };
                row.Controls.Add(btnDel);

                Panel dot = new Panel
                {
                    BackColor = Color.ForestGreen,
                    Size = new Size(5, 40),
                    Location = new Point(width - 5, 8),
                    Anchor = AnchorStyles.Right
                };
                row.Controls.Add(dot);
                row.Controls.Add(lblBadge);
            }
            else
            {
                row.BackColor = Color.White;

                if (showCheckbox)
                {
                    CheckBox ck = new CheckBox { Checked = false, Width = 25, Location = new Point(5, 18), Cursor = Cursors.Hand };
                    ck.Click += (s, e) => { ToggleTaskStatus(taskId, true, sourceType); };
                    row.Controls.Add(ck);
                }

                Label lblT = new Label
                {
                    Text = title,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.Black,
                    Location = new Point(textX, 8),
                    AutoSize = true
                };

                Label lblI = new Label
                {
                    Text = info,
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    ForeColor = Color.Gray,
                    Location = new Point(textX, 30),
                    AutoSize = true
                };

                Button btnDel = new Button
                {
                    Text = "🗑️",
                    Size = new Size(30, 30),
                    Location = new Point(width - 50, 12),
                    Anchor = AnchorStyles.Right,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Transparent,
                    ForeColor = Color.Red,
                    Cursor = Cursors.Hand
                };
                btnDel.FlatAppearance.BorderSize = 0;
                btnDel.Click += (s, e) => {
                    if (MessageBox.Show("Xóa công việc này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        DeleteTask(taskId, sourceType);
                };

                Panel dot = new Panel
                {
                    BackColor = tagColor,
                    Size = new Size(5, 40),
                    Location = new Point(width - 5, 8),
                    Anchor = AnchorStyles.Right
                };

                row.Controls.AddRange(new Control[] { lblT, lblI, btnDel, dot, lblBadge });
            }

            return row;
        }

        private void ToggleTaskStatus(int id, bool isChecked, string sourceType)
        {
            string query = "";
            string statusVal = isChecked ? "1" : "0";

            if (sourceType == "Calendar")
            {
                query = $"UPDATE WeekCategory_item SET Status = {statusVal} WHERE Id_weekly = {id}";
            }
            else
            {
                query = $"UPDATE Todo_List_Item SET status = {statusVal} WHERE id_item = {id}";
            }

            ExecuteSql(query, cmd => { });
            LoadDashboardData();
        }

        private void DeleteTask(int id, string sourceType)
        {
            string query = "";
            if (sourceType == "Calendar")
            {
                query = $"DELETE FROM WeekCategory_item WHERE Id_weekly = {id}";
            }
            else
            {
                query = $"DELETE FROM Todo_List_Item WHERE id_item = {id}";
            }

            ExecuteSql(query, cmd => { });
            LoadDashboardData();
        }

        private void ExecuteSql(string query, Action<SQLiteCommand> paramBuilder)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(strConn))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        paramBuilder(cmd);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void LoadStats(SQLiteConnection conn)
        {
            // 1. TODAY
            string sqlToday = @"SELECT 
                (SELECT COUNT(*) FROM WeekCategory_item WHERE date(StartDate) = date('now', 'localtime')) + 
                (SELECT COUNT(*) FROM Todo_List_Item t JOIN Todo_List_Detail l ON t.id_todo = l.id_todo WHERE date(l.created_at) = date('now', 'localtime'))";
            int today = GetCount(conn, sqlToday);

            // 2. UPCOMING
            string sqlUpcoming = @"SELECT 
                (SELECT COUNT(*) FROM WeekCategory_item WHERE date(StartDate) > date('now', 'localtime') AND Status = 0) + 
                (SELECT COUNT(*) FROM Todo_List_Item t JOIN Todo_List_Detail l ON t.id_todo = l.id_todo WHERE date(l.created_at) > date('now', 'localtime') AND (t.status = 0 OR t.status IS NULL))";
            int upcoming = GetCount(conn, sqlUpcoming);

            // 3. OVERDUE
            string sqlOverdue = @"SELECT 
                (SELECT COUNT(*) FROM WeekCategory_item WHERE date(StartDate) < date('now', 'localtime') AND Status = 0) + 
                (SELECT COUNT(*) FROM Todo_List_Item t JOIN Todo_List_Detail l ON t.id_todo = l.id_todo WHERE date(l.created_at) < date('now', 'localtime') AND (t.status = 0 OR t.status IS NULL))";
            int overdue = GetCount(conn, sqlOverdue);

            // 4. DONE
            string sqlDone = @"SELECT 
                (SELECT COUNT(*) FROM WeekCategory_item WHERE Status = 1) + 
                (SELECT COUNT(*) FROM Todo_List_Item WHERE status = 1)";
            int done = GetCount(conn, sqlDone);

            flowStats.Controls.Add(CreateStatCard(today.ToString(), "Hôm nay", Color.AliceBlue, "📅"));
            flowStats.Controls.Add(CreateStatCard(upcoming.ToString(), "Sắp tới", Color.Beige, "🕒"));
            flowStats.Controls.Add(CreateStatCard(overdue.ToString(), "Quá hạn", Color.MistyRose, "⚠️"));
            flowStats.Controls.Add(CreateStatCard(done.ToString(), "Hoàn thành", Color.Honeydew, "✅"));
        }

        private int GetCount(SQLiteConnection conn, string query)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn)) { return Convert.ToInt32(cmd.ExecuteScalar() ?? 0); }
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