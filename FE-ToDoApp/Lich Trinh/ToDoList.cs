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

    public partial class ToDoList : Form
    {
        private List<Form> privatePages = new List<Form>();
        public ToDoList()
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

        private void add_item_click(object sender, EventArgs e)
        {
           
            TaskItem newItem = new TaskItem();
            newItem.Width = panelContent.ClientSize.Width;
            newItem.Dock = DockStyle.Top;
            int currentCount = panelContent.Controls.Count;
            panelContent.Controls.Add(newItem);
            panelContent.Controls.Add(newItem);
            panelContent.Controls.SetChildIndex(newItem, 0);
            panelContent.ScrollControlIntoView(newItem);
        }
    }
}
