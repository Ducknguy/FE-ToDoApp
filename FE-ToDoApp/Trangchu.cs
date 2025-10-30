﻿using FE_ToDoApp.Lich_Trinh;
using FE_ToDoApp.NewFolder;

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
            ThungRac thungRac = new ThungRac();
            thungRac.ShowDialog();
        }

        private void btn_CaiDat(object sender, EventArgs e)
        {
            ToDoList todolist = new ToDoList();
            todolist.ShowDialog();
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
            sidebar_item.Width = private_item_panel.ClientSize.Width;
            sidebar_item.Dock = DockStyle.Top;
            sidebar_item.Cursor = Cursors.Hand;

            sidebar_item.TargetForm = newtodo;

            private_item_panel.Controls.Add(sidebar_item);
            privatePages.Add(newtodo);

            sidebar_item.Click += sidebar_item_click;

        }
    }
}
