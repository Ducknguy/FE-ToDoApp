using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FE_ToDoApp.Lich_Trinh
{
    public partial class TaskItem : UserControl
    {
        public TaskItem()
        {
            InitializeComponent();
        }

        private void hover_trashcan(object sender, EventArgs e)
        {
            trashcan_nondelete.Visible = false;
            trashcan_delete.Visible = true;
        }

        private void leave_trashcan(object sender, EventArgs e)
        {
            trashcan_nondelete.Visible = true;
            trashcan_delete.Visible = false;
        }
    }
}
