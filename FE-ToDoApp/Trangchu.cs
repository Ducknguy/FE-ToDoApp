using ChatbotAI_Form;
using FE_ToDoApp.Calendar;
using FE_ToDoApp.Dashboard;
using FE_ToDoApp.Lich_Trinh;
using FE_ToDoApp.NewFolder;
using FE_ToDoApp.Setting;
using ChatbotAI_Form;
using FE_ToDoApp.login;


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

        }

        private void add_private_item_click(object sender, EventArgs e)
        {

        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            calendar calendar = new calendar();
            calendar.ShowDialog();

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();

            FE_ToDoApp.Dashboard.DashboardControl ucDashboard = new FE_ToDoApp.Dashboard.DashboardControl();

            ucDashboard.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(ucDashboard);
            ucDashboard.Show();
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
            FE_ToDoApp.WeekList.week_group _task = new FE_ToDoApp.WeekList.week_group();
            _task.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(_task);
            _task.Show();
        }
    }
}
