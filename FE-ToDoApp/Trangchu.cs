using ChatbotAI_Form;
using FE_ToDoApp.Calendar;
using FE_ToDoApp.Dashboard;
using FE_ToDoApp.Lich_Trinh;
using FE_ToDoApp.login;
using FE_ToDoApp.Setting;
using FE_ToDoApp.ThungRac;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
    

namespace FE_ToDoApp
{
    public partial class Trangchu : Form
    {
        private List<Form> privatePages = new List<Form>();

        private int _currentUserId;
        private string _currentUsername;

        public Trangchu(int userId, string username)
        {
            InitializeComponent();

            //this._currentUserId = userId;
            //this._currentUsername = username;

            ////gOpenDashboard();
        }

        public Trangchu()
        {
            InitializeComponent();

            //this._currentUserId = 1;
            //this._currentUsername = "Test User";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //this.Text = $"ToDo App - Xin chào, {_currentUsername}!";
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenDashboard();
        }

        private void OpenDashboard()
        {
            //mainPanel.Controls.Clear();

            DashboardControl ucDashboard = new DashboardControl();

            //ucDashboard.Dock = DockStyle.Fill;
            //mainPanel.Controls.Add(ucDashboard);
            //ucDashboard.Show();
        }

        private void btnTrash_Click(object sender, EventArgs e)
        {
            //ThungRac thungRacForm = new ThungRac();
            //thungRacForm.ShowDialog();
        }

        private void btn_CaiDat(object sender, EventArgs e)
        {
           setting setting = new setting();
              setting.ShowDialog();
        }

        private void btnChatbotAI_Click(object sender, EventArgs e)
        {
            ChatbotAI chatbot = new ChatbotAI();
            chatbot.ShowDialog();
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            calendar calendar = new calendar();
            calendar.ShowDialog();
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
                        if (control is Form form) form.Hide();
                    }
                    targetForm.Show();
                    targetForm.BringToFront();
                }
            }
        }

        //private void add_private_item_click(object sender, EventArgs e)
        //{
        //    ToDoList newtodo = new ToDoList();
        //    newtodo.TopLevel = false;
        //    newtodo.FormBorderStyle = FormBorderStyle.None;
        //    newtodo.Dock = DockStyle.Left;

        //    mainPanel.Controls.Clear();
        //    mainPanel.Controls.Add(newtodo);
        //    newtodo.Show();
        //    privatePages.Add(newtodo);

        //    Private_Sidebar sidebar_item = new Private_Sidebar();
        //    sidebar_item.TargetForm = newtodo;
        //    sidebar_item.Click += sidebar_item_click;

        //}

        private void btn_logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Login1 loginForm = new Login1();
                loginForm.Show();

                this.Close();
            }
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            FE_ToDoApp.Lich_Trinh.TaskItem _task = new FE_ToDoApp.Lich_Trinh.TaskItem();
            _task.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(_task);
            _task.Show();
        }

        private void btnWeekly_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            FE_ToDoApp.WeekList.WeekGroupMVC weekPlan = new FE_ToDoApp.WeekList.WeekGroupMVC();
            weekPlan.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(weekPlan);
            weekPlan.Show();
        }
    }
}