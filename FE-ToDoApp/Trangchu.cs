using FE_ToDoApp.Calendar;
using FE_ToDoApp.Lich_Trinh;
using FE_ToDoApp.NewFolder;
using FE_ToDoApp.Setting;
using ChatbotAI_Form;
using FE_ToDoApp.login;
using System.Windows.Forms;
using System.Collections.Generic;
using System;

namespace FE_ToDoApp
{
    public partial class Trangchu : Form
    {
        private List<Form> privatePages = new List<Form>();

        public Trangchu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnTrash_Click(object sender, EventArgs e)
        {
            ThungRac thungRacForm = new ThungRac();
            thungRacForm.Show();
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

        private void add_private_item_click(object sender, EventArgs e)
        {
            ToDoList newtodo = new ToDoList();
            newtodo.TopLevel = false;
            newtodo.FormBorderStyle = FormBorderStyle.None;
            newtodo.Dock = DockStyle.Left;

            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(newtodo);
            newtodo.Show();
            privatePages.Add(newtodo);

            Private_Sidebar sidebar_item = new Private_Sidebar();
            sidebar_item.TargetForm = newtodo;

            sidebar_item.Click += sidebar_item_click;
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
    }
}