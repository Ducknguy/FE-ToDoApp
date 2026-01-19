using FE_ToDoApp.Calendar;
using FE_ToDoApp.Lich_Trinh;
using FE_ToDoApp.Setting;
using ChatbotAI_Form;
using FE_ToDoApp.login;
using FE_ToDoApp.ThungRac;
using FE_ToDoApp.WeekList;

namespace FE_ToDoApp
{
    public partial class Trangchu : Form
    {
        private List<Form> privatePages = new List<Form>();
        private int currentUserId;
        private string currentUserName;

        public Trangchu()
        {
            InitializeComponent();
        }

        public Trangchu(int userId, string userName)
        {
            InitializeComponent();
            currentUserId = userId;
            currentUserName = userName;
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
            mainPanel.Controls.Clear();
            WeekGroupMVC weekplan = new WeekGroupMVC();
            weekplan.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(weekplan);
            weekplan.Show();
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            FE_ToDoApp.Lich_Trinh.TaskItem _task = new FE_ToDoApp.Lich_Trinh.TaskItem();
            _task.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(_task);
            _task.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            
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