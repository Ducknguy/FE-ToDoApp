using FE_ToDoApp.Lich_Trinh;
using FE_ToDoApp.NewFolder;
using FE_ToDoApp.Setting;

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
            Button btn = sender as Button;

            // Tạo form ảo để LẤY CHIỀU CAO
            ThungRac tempForm = new ThungRac(new Point(0, 0));
            int formHeight = tempForm.Height;
            tempForm.Close();

            Point screenPoint = btn.PointToScreen(new Point(btn.Width, btn.Height)); // <-- ĐÃ SỬA

            int startX = screenPoint.X;
            int startY = screenPoint.Y - formHeight;

            // Tạo và hiển thị form thật
            ThungRac thungRacForm = new ThungRac(new Point(startX, startY));
            thungRacForm.Show();
        }

        private void btn_CaiDat(object sender, EventArgs e)
        {
            setting setting = new setting();
            setting.ShowDialog();
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
    }
}
