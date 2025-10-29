using FE_ToDoApp.Lich_Trinh;
using FE_ToDoApp.NewFolder;

namespace FE_ToDoApp
{
    public partial class Trangchu : Form
    {
        public Trangchu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnTrash_Click(object sender, EventArgs e)
        {
            ThungRac thungRac = new ThungRac();
            thungRac.ShowDialog();
        }

        private void btn_CaiDat(object sender, EventArgs e)
        {
            ToDoList todolist = new ToDoList();
            todolist.ShowDialog();
        }
    }
}
