namespace FE_ToDoApp.WeekList
{
    partial class week_group_refactored
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panel1 = new System.Windows.Forms.Panel();
            search_panel1 = new System.Windows.Forms.Panel();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            txt_search_place = new System.Windows.Forms.TextBox();
            panel2 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            button3 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            panel4 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            panel1.SuspendLayout();
            search_panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(search_panel1);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1400, 55);
            panel1.TabIndex = 0;
            // 
            // search_panel1
            // 
            search_panel1.BackColor = System.Drawing.Color.FromArgb(243, 242, 241);
            search_panel1.Controls.Add(pictureBox1);
            search_panel1.Controls.Add(txt_search_place);
            search_panel1.Location = new System.Drawing.Point(14, 7);
            search_panel1.Margin = new Padding(0);
            search_panel1.Name = "search_panel1";
            search_panel1.Size = new System.Drawing.Size(360, 45);
            search_panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            pictureBox1.Location = new System.Drawing.Point(0, 0);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(43, 45);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // txt_search_place
            // 
            txt_search_place.BackColor = System.Drawing.Color.FromArgb(243, 242, 241);
            txt_search_place.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txt_search_place.Font = new System.Drawing.Font("Segoe UI", 14F);
            txt_search_place.Location = new System.Drawing.Point(49, 8);
            txt_search_place.Margin = new Padding(0);
            txt_search_place.Name = "txt_search_place";
            txt_search_place.PlaceholderText = "Search task and events ....";
            txt_search_place.Size = new System.Drawing.Size(308, 32);
            txt_search_place.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(flowLayoutPanel1);
            panel2.Dock = System.Windows.Forms.DockStyle.Left;
            panel2.Location = new System.Drawing.Point(0, 55);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(273, 648);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(button3);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(button1);
            panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel3.Location = new System.Drawing.Point(0, 595);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(273, 53);
            panel3.TabIndex = 1;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(179, 12);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(88, 29);
            button3.TabIndex = 2;
            button3.Text = "Xóa";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(91, 12);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(88, 29);
            button2.TabIndex = 1;
            button2.Text = "S?a";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(3, 12);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(88, 29);
            button1.TabIndex = 0;
            button1.Text = "Thêm";
            button1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(panel4);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(273, 648);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            panel4.Controls.Add(label1);
            panel4.Location = new System.Drawing.Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(267, 64);
            panel4.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(22, 17);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(156, 28);
            label1.TabIndex = 0;
            label1.Text = "Nhóm công vi?c";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel2.Location = new System.Drawing.Point(273, 55);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(1127, 648);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // week_group_refactored
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(flowLayoutPanel2);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "week_group_refactored";
            Size = new System.Drawing.Size(1400, 703);
            panel1.ResumeLayout(false);
            search_panel1.ResumeLayout(false);
            search_panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel search_panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_search_place;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}
