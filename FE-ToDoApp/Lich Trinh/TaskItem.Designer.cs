using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FE_ToDoApp.Lich_Trinh
{
    partial class TaskItem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            task_Item = new Panel();
            flp_task_right = new FlowLayoutPanel();
            panel1 = new Panel();
            flp_task_left = new FlowLayoutPanel();
            panel_add = new Panel();
            btn_add = new Button();
            head_panel = new Panel();
            search_panel1 = new Panel();
            pictureBox1 = new PictureBox();
            txt_search_place = new TextBox();
            task_Item.SuspendLayout();
            panel1.SuspendLayout();
            panel_add.SuspendLayout();
            head_panel.SuspendLayout();
            search_panel1.SuspendLayout();
            ((ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // task_Item
            // 
            task_Item.Controls.Add(flp_task_right);
            task_Item.Controls.Add(panel1);
            task_Item.Controls.Add(head_panel);
            task_Item.Dock = DockStyle.Fill;
            task_Item.Location = new Point(0, 0);
            task_Item.Margin = new Padding(0);
            task_Item.Name = "task_Item";
            task_Item.Size = new Size(1319, 597);
            task_Item.TabIndex = 0;
            // 
            // flp_task_right
            // 
            flp_task_right.Dock = DockStyle.Fill;
            flp_task_right.Location = new Point(284, 73);
            flp_task_right.Margin = new Padding(0);
            flp_task_right.Name = "flp_task_right";
            flp_task_right.Size = new Size(1035, 524);
            flp_task_right.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.Controls.Add(flp_task_left);
            panel1.Controls.Add(panel_add);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 73);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(284, 524);
            panel1.TabIndex = 2;
            // 
            // flp_task_left
            // 
            flp_task_left.Dock = DockStyle.Fill;
            flp_task_left.Location = new Point(0, 0);
            flp_task_left.Margin = new Padding(0);
            flp_task_left.Name = "flp_task_left";
            flp_task_left.Size = new Size(284, 491);
            flp_task_left.TabIndex = 0;
            // 
            // panel_add
            // 
            panel_add.Controls.Add(btn_add);
            panel_add.Dock = DockStyle.Bottom;
            panel_add.Location = new Point(0, 491);
            panel_add.Margin = new Padding(0);
            panel_add.Name = "panel_add";
            panel_add.Size = new Size(284, 33);
            panel_add.TabIndex = 1;
            // 
            // btn_add
            // 
            btn_add.Location = new Point(87, 2);
            btn_add.Margin = new Padding(0);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(94, 29);
            btn_add.TabIndex = 0;
            btn_add.Text = "Thêm";
            btn_add.UseVisualStyleBackColor = true;
            // 
            // head_panel
            // 
            head_panel.Controls.Add(search_panel1);
            head_panel.Dock = DockStyle.Top;
            head_panel.Location = new Point(0, 0);
            head_panel.Margin = new Padding(0);
            head_panel.Name = "head_panel";
            head_panel.Size = new Size(1319, 73);
            head_panel.TabIndex = 1;
            // 
            // search_panel1
            // 
            search_panel1.BackColor = Color.FromArgb(243, 242, 241);
            search_panel1.Controls.Add(pictureBox1);
            search_panel1.Controls.Add(txt_search_place);
            search_panel1.Location = new Point(13, 13);
            search_panel1.Margin = new Padding(0);
            search_panel1.Name = "search_panel1";
            search_panel1.Size = new Size(360, 45);
            search_panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.search__1_;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(43, 45);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // txt_search_place
            // 
            txt_search_place.BackColor = Color.FromArgb(243, 242, 241);
            txt_search_place.BorderStyle = BorderStyle.None;
            txt_search_place.Font = new Font("Segoe UI", 14F);
            txt_search_place.Location = new Point(49, 8);
            txt_search_place.Margin = new Padding(0);
            txt_search_place.Name = "txt_search_place";
            txt_search_place.PlaceholderText = "Search task and events ....";
            txt_search_place.Size = new Size(308, 32);
            txt_search_place.TabIndex = 0;
            // 
            // TaskItem
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(task_Item);
            Margin = new Padding(0);
            Name = "TaskItem";
            Size = new Size(1319, 597);
            task_Item.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel_add.ResumeLayout(false);
            head_panel.ResumeLayout(false);
            search_panel1.ResumeLayout(false);
            search_panel1.PerformLayout();
            ((ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel head_panel;
        private Panel search_panel1;
        private TextBox txt_search_place;
        private PictureBox pictureBox1;
        private FlowLayoutPanel flp_task_left;
        private Panel panel1;
        private Panel panel_add;
        private FlowLayoutPanel flp_task_right;
        private Button btn_add;
        private Panel task_Item;
    }
}
