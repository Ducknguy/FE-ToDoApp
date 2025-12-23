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
            calendar calendar = new calendar();
            calendar.ShowDialog();

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear(); // Xóa các control cũ trong panel chính

            // Gọi chính xác Namespace và Class để tránh lỗi CS0118
            FE_ToDoApp.Dashboard.DashboardControl ucDashboard = new FE_ToDoApp.Dashboard.DashboardControl();

            ucDashboard.Dock = DockStyle.Fill; // Để dashboard tràn đầy phần mainPanel
            mainPanel.Controls.Add(ucDashboard);
            ucDashboard.Show();
        }
    }
}
