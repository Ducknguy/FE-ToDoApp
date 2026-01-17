namespace FE_ToDoApp.WeekList
{
    partial class WeekGroupMVC
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
            panel1 = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            search_panel1 = new Panel();
            pictureBox1 = new PictureBox();
            txt_search_place = new TextBox();
            panel2 = new Panel();
            panel3 = new Panel();
            btnAddCategory = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel4 = new Panel();
            label1 = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            panel5 = new Panel();
            panel6 = new Panel();
            label2 = new Label();
            panel7 = new Panel();
            panel8 = new Panel();
            label3 = new Label();
            panel9 = new Panel();
            panel10 = new Panel();
            label4 = new Label();
            panel11 = new Panel();
            panel12 = new Panel();
            label5 = new Label();
            panel15 = new Panel();
            panel16 = new Panel();
            label8 = new Label();
            panel17 = new Panel();
            panel18 = new Panel();
            label9 = new Label();
            panel19 = new Panel();
            panel20 = new Panel();
            label10 = new Label();
            panel1.SuspendLayout();
            search_panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel4.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            panel10.SuspendLayout();
            panel11.SuspendLayout();
            panel12.SuspendLayout();
            panel15.SuspendLayout();
            panel16.SuspendLayout();
            panel17.SuspendLayout();
            panel18.SuspendLayout();
            panel19.SuspendLayout();
            panel20.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(search_panel1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1400, 55);
            panel1.TabIndex = 0;
            // 
            // button3
            // 
            button3.BackColor = Color.LightCoral;
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button3.Location = new Point(1327, 13);
            button3.Name = "button3";
            button3.Size = new Size(60, 29);
            button3.TabIndex = 4;
            button3.Text = "Xóa";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.LightBlue;
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F);
            button2.Location = new Point(1261, 13);
            button2.Name = "button2";
            button2.Size = new Size(60, 29);
            button2.TabIndex = 3;
            button2.Text = "Sửa";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGreen;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.Location = new Point(1195, 13);
            button1.Name = "button1";
            button1.Size = new Size(60, 29);
            button1.TabIndex = 2;
            button1.Text = "Thêm";
            button1.UseVisualStyleBackColor = false;
            // 
            // search_panel1
            // 
            search_panel1.BackColor = Color.FromArgb(243, 242, 241);
            search_panel1.Controls.Add(pictureBox1);
            search_panel1.Controls.Add(txt_search_place);
            search_panel1.Location = new Point(14, 7);
            search_panel1.Margin = new Padding(0);
            search_panel1.Name = "search_panel1";
            search_panel1.Size = new Size(360, 45);
            search_panel1.TabIndex = 1;
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
            txt_search_place.PlaceholderText = "Tìm kiếm...";
            txt_search_place.Size = new Size(308, 32);
            txt_search_place.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(flowLayoutPanel1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 55);
            panel2.Name = "panel2";
            panel2.Size = new Size(273, 756);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnAddCategory);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 696);
            panel3.Name = "panel3";
            panel3.Size = new Size(273, 60);
            panel3.TabIndex = 1;
            // 
            // btnAddCategory
            // 
            btnAddCategory.BackColor = Color.LightGreen;
            btnAddCategory.Cursor = Cursors.Hand;
            btnAddCategory.FlatStyle = FlatStyle.Flat;
            btnAddCategory.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddCategory.Location = new Point(89, 16);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(80, 28);
            btnAddCategory.TabIndex = 1;
            btnAddCategory.Text = "+ Thêm";
            btnAddCategory.UseVisualStyleBackColor = false;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(panel4);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(273, 756);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ActiveCaption;
            panel4.Controls.Add(label1);
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(267, 64);
            panel4.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 17);
            label1.Name = "label1";
            label1.Size = new Size(155, 28);
            label1.TabIndex = 0;
            label1.Text = "Nhóm công việc";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Controls.Add(panel5);
            flowLayoutPanel2.Controls.Add(panel7);
            flowLayoutPanel2.Controls.Add(panel9);
            flowLayoutPanel2.Controls.Add(panel11);
            flowLayoutPanel2.Controls.Add(panel15);
            flowLayoutPanel2.Controls.Add(panel17);
            flowLayoutPanel2.Controls.Add(panel19);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(273, 55);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1127, 756);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.Controls.Add(panel6);
            panel5.Location = new Point(3, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(1121, 161);
            panel5.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.ActiveBorder;
            panel6.Controls.Add(label2);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(1121, 64);
            panel6.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F);
            label2.Location = new Point(3, 17);
            label2.Name = "label2";
            label2.Size = new Size(93, 31);
            label2.TabIndex = 0;
            label2.Text = "Thứ Hai";
            // 
            // panel7
            // 
            panel7.Controls.Add(panel8);
            panel7.Location = new Point(3, 170);
            panel7.Name = "panel7";
            panel7.Size = new Size(1121, 161);
            panel7.TabIndex = 1;
            // 
            // panel8
            // 
            panel8.BackColor = SystemColors.ActiveBorder;
            panel8.Controls.Add(label3);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(1121, 64);
            panel8.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F);
            label3.Location = new Point(3, 17);
            label3.Name = "label3";
            label3.Size = new Size(84, 31);
            label3.TabIndex = 0;
            label3.Text = "Thứ Ba";
            // 
            // panel9
            // 
            panel9.Controls.Add(panel10);
            panel9.Location = new Point(3, 337);
            panel9.Name = "panel9";
            panel9.Size = new Size(1121, 161);
            panel9.TabIndex = 2;
            // 
            // panel10
            // 
            panel10.BackColor = SystemColors.ActiveBorder;
            panel10.Controls.Add(label4);
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(0, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(1121, 64);
            panel10.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F);
            label4.Location = new Point(3, 17);
            label4.Name = "label4";
            label4.Size = new Size(85, 31);
            label4.TabIndex = 0;
            label4.Text = "Thứ Tư";
            // 
            // panel11
            // 
            panel11.Controls.Add(panel12);
            panel11.Location = new Point(3, 504);
            panel11.Name = "panel11";
            panel11.Size = new Size(1121, 161);
            panel11.TabIndex = 3;
            // 
            // panel12
            // 
            panel12.BackColor = SystemColors.ActiveBorder;
            panel12.Controls.Add(label5);
            panel12.Dock = DockStyle.Top;
            panel12.Location = new Point(0, 0);
            panel12.Name = "panel12";
            panel12.Size = new Size(1121, 64);
            panel12.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F);
            label5.Location = new Point(3, 17);
            label5.Name = "label5";
            label5.Size = new Size(108, 31);
            label5.TabIndex = 0;
            label5.Text = "Thứ Năm";
            // 
            // panel15
            // 
            panel15.Controls.Add(panel16);
            panel15.Location = new Point(3, 671);
            panel15.Name = "panel15";
            panel15.Size = new Size(1121, 161);
            panel15.TabIndex = 4;
            // 
            // panel16
            // 
            panel16.BackColor = SystemColors.ActiveBorder;
            panel16.Controls.Add(label8);
            panel16.Dock = DockStyle.Top;
            panel16.Location = new Point(0, 0);
            panel16.Name = "panel16";
            panel16.Size = new Size(1121, 64);
            panel16.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13.8F);
            label8.Location = new Point(3, 17);
            label8.Name = "label8";
            label8.Size = new Size(96, 31);
            label8.TabIndex = 0;
            label8.Text = "Thứ Sáu";
            // 
            // panel17
            // 
            panel17.Controls.Add(panel18);
            panel17.Location = new Point(3, 838);
            panel17.Name = "panel17";
            panel17.Size = new Size(1121, 161);
            panel17.TabIndex = 5;
            // 
            // panel18
            // 
            panel18.BackColor = SystemColors.ActiveBorder;
            panel18.Controls.Add(label9);
            panel18.Dock = DockStyle.Top;
            panel18.Location = new Point(0, 0);
            panel18.Name = "panel18";
            panel18.Size = new Size(1121, 64);
            panel18.TabIndex = 0;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 13.8F);
            label9.Location = new Point(3, 17);
            label9.Name = "label9";
            label9.Size = new Size(95, 31);
            label9.TabIndex = 0;
            label9.Text = "Thứ Bảy";
            // 
            // panel19
            // 
            panel19.Controls.Add(panel20);
            panel19.Location = new Point(3, 1005);
            panel19.Name = "panel19";
            panel19.Size = new Size(1121, 161);
            panel19.TabIndex = 6;
            // 
            // panel20
            // 
            panel20.BackColor = SystemColors.ActiveBorder;
            panel20.Controls.Add(label10);
            panel20.Dock = DockStyle.Top;
            panel20.Location = new Point(0, 0);
            panel20.Name = "panel20";
            panel20.Size = new Size(1121, 64);
            panel20.TabIndex = 0;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 13.8F);
            label10.Location = new Point(3, 17);
            label10.Name = "label10";
            label10.Size = new Size(110, 31);
            label10.TabIndex = 0;
            label10.Text = "Chủ Nhật";
            // 
            // WeekGroupMVC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowLayoutPanel2);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "WeekGroupMVC";
            Size = new Size(1400, 811);
            panel1.ResumeLayout(false);
            search_panel1.ResumeLayout(false);
            search_panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel9.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel11.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel15.ResumeLayout(false);
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            panel17.ResumeLayout(false);
            panel18.ResumeLayout(false);
            panel18.PerformLayout();
            panel19.ResumeLayout(false);
            panel20.ResumeLayout(false);
            panel20.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel search_panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_search_place;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.Label label10;
        private Panel panel3;
    }
}
