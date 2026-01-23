using ChatbotAI_Form;
using FE_ToDoApp.Calendar;
using FE_ToDoApp.Lich_Trinh;
using FE_ToDoApp.login;
using FE_ToDoApp.Setting;
using FE_ToDoApp.ThemNhanh;
using FE_ToDoApp.ThungRac;
using FE_ToDoApp.WeekList;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FE_ToDoApp
{
    public partial class Trangchu : Form
    {
        private List<Form> privatePages = new List<Form>();

        // 1. Biến lưu ID người dùng hiện tại
        private int currentUserId;

        public Trangchu()
        {
            InitializeComponent();
        }

        // 2. Hàm khởi tạo nhận ID từ Login truyền sang
        public Trangchu(int userId)
        {
            InitializeComponent();
            this.currentUserId = userId; // Lưu ID lại để dùng
        }

        // Giữ lại hàm này nếu code cũ của bạn có dùng, và cập nhật lưu ID luôn
        public Trangchu(int userId, string userName)
        {
            InitializeComponent();
            this.currentUserId = userId;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnTrash_Click(object sender, EventArgs e)
        {
            Thungrac thungrac = new Thungrac();
            thungrac.ShowDialog();
        }

        private void btn_CaiDat(object sender, EventArgs e)
        {
            // 3. SỬA LỖI Ở ĐÂY: Truyền currentUserId vào Form Setting
            setting setting = new setting(currentUserId);
            setting.ShowDialog();
        }

        private void btnChatbotAI_Click(object sender, EventArgs e)
        {
            ChatbotAI chatbot = new ChatbotAI();
            chatbot.ShowDialog();
        }

        private void sidebar_item_click(object sender, EventArgs e)
        {
            Private_Sidebar clickedItem = sender as Private_Sidebar;

            if (clickedItem != null)
            {
                Form targetForm = clickedItem.TargetForm;

                if (targetForm != null)
                {
                    foreach (Control control in mainPanel.Controls)
                    {
                        if (control is Form form)
                        {
                            form.Hide();
                        }
                    }

                    targetForm.Show();
                    targetForm.BringToFront();
                }
            }
        }


        private void btnCalendar_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();

            calendar frmCalendar = new calendar();

            frmCalendar.TopLevel = false;
            frmCalendar.FormBorderStyle = FormBorderStyle.None;
            frmCalendar.Dock = DockStyle.Fill;

            mainPanel.Controls.Add(frmCalendar);
            frmCalendar.Show();
        }

        private void btnWeekly_Click(object sender, EventArgs e)
        {
            //if (currentWeekControl == null || currentWeekControl.IsDisposed)
            //{
            //    mainPanel.Controls.Clear();
            //    currentWeekControl = new WeekGroupMVC();
            //    currentWeekControl.Dock = DockStyle.Fill;
            //    mainPanel.Controls.Add(currentWeekControl);
            //    currentWeekControl.Show();
            //}
            //else
            //{
            //    if (!mainPanel.Controls.Contains(currentWeekControl))
            //    {
            //        mainPanel.Controls.Clear();
            //        mainPanel.Controls.Add(currentWeekControl);
            //    }
            //    currentWeekControl.RefreshData(); // ← Đã có rồi ✓
            //    currentWeekControl.BringToFront();
            //}
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            //if (currentTaskControl == null || currentTaskControl.IsDisposed)
            //{
            //    mainPanel.Controls.Clear();
            //    currentTaskControl = new FE_ToDoApp.Lich_Trinh.TaskItem();
            //    currentTaskControl.Dock = DockStyle.Fill;
            //    mainPanel.Controls.Add(currentTaskControl);
            //    currentTaskControl.Show();
            //}
            //else
            //{
            //    if (!mainPanel.Controls.Contains(currentTaskControl))
            //    {
            //        mainPanel.Controls.Clear();
            //        mainPanel.Controls.Add(currentTaskControl);
            //    }
            //    currentTaskControl.RefreshData(); // ← THÊM DÒNG NÀY
            //    currentTaskControl.BringToFront();
            //}
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            FE_ToDoApp.Dashboard.DashboardControl dashboard = new FE_ToDoApp.Dashboard.DashboardControl();
            dashboard.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(dashboard);
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn đăng xuất chứ?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Login1 login1 = new Login1();
                login1.Show();
                this.Hide();
            }
        }

        private void btnQuickAdd_Click(object sender, EventArgs e)
        {
            //QuickAdd quickadd = new QuickAdd();

            //if (quickadd.ShowDialog() == DialogResult.OK)
            //{
            //    if (quickadd.AddedType == "Week")
            //    {
            //        // Nếu Week control đã tồn tại, refresh nó
            //        if (currentWeekControl != null && !currentWeekControl.IsDisposed)
            //        {
            //            // Refresh data từ DB
            //            currentWeekControl.RefreshData();

            //            // Hiển thị control nếu chưa có trong mainPanel
            //            if (!mainPanel.Controls.Contains(currentWeekControl))
            //            {
            //                mainPanel.Controls.Clear();
            //                mainPanel.Controls.Add(currentWeekControl);
            //            }

            //            currentWeekControl.BringToFront();

            //            // Chọn category vừa thêm
            //            if (quickadd.AddedCategoryId > 0)
            //            {
            //                Application.DoEvents(); // Đợi UI update
            //                currentWeekControl.SelectCategory(quickadd.AddedCategoryId);
            //            }
            //        }
            //        else
            //        {
            //            // Tạo mới Week control
            //            mainPanel.Controls.Clear();
            //            currentWeekControl = new WeekGroupMVC();
            //            currentWeekControl.Dock = DockStyle.Fill;
            //            mainPanel.Controls.Add(currentWeekControl);
            //            currentWeekControl.Show();

            //            // Chọn category vừa thêm
            //            if (quickadd.AddedCategoryId > 0)
            //            {
            //                Application.DoEvents();
            //                currentWeekControl.SelectCategory(quickadd.AddedCategoryId);
            //            }
            //        }
            //    }
            //    else if (quickadd.AddedType == "Todo")
            //    {
            //        // Tương tự cho Todo
            //        if (currentTaskControl != null && !currentTaskControl.IsDisposed)
            //        {
            //            if (!mainPanel.Controls.Contains(currentTaskControl))
            //            {
            //                mainPanel.Controls.Clear();
            //                mainPanel.Controls.Add(currentTaskControl);
            //            }
            //            currentTaskControl.BringToFront();
            //        }
            //        else
            //        {
            //            btnTasks_Click(sender, e);
            //        }
            //    }
            //}
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            // Truyền ID hiện tại khi reload lại trang chủ
            Trangchu trangchu = new Trangchu(currentUserId);
            trangchu.ShowDialog();
            this.Hide();
        }
    }
}