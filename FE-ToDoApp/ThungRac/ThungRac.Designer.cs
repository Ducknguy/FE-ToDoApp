namespace FE_ToDoApp.NewFolder
{
    partial class ThungRac
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThungRac));
            panel1 = new Panel();
            panel9 = new Panel();
            textBox1 = new TextBox();
            panel8 = new Panel();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            panel5 = new Panel();
            panel7 = new Panel();
            label1 = new Label();
            panel4 = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel3 = new Panel();
            label3 = new Label();
            panel1.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            panel7.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel9);
            panel1.Controls.Add(panel8);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(444, 45);
            panel1.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.Controls.Add(textBox1);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(50, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(394, 45);
            panel9.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = Color.FromArgb(247, 247, 247);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 13F);
            textBox1.Location = new Point(0, 9);
            textBox1.Margin = new Padding(10);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "    Tìm kiếm trang trong Thùng rác";
            textBox1.Size = new Size(375, 28);
            textBox1.TabIndex = 3;
            // 
            // panel8
            // 
            panel8.Controls.Add(pictureBox1);
            panel8.Dock = DockStyle.Left;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(50, 45);
            panel8.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(9, 9);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(41, 28);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel4);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 45);
            panel2.Name = "panel2";
            panel2.Size = new Size(444, 339);
            panel2.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Controls.Add(panel7);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 47);
            panel5.Name = "panel5";
            panel5.Size = new Size(444, 292);
            panel5.TabIndex = 1;
            // 
            // panel7
            // 
            panel7.Controls.Add(label1);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(444, 292);
            panel7.TabIndex = 1;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(444, 292);
            label1.TabIndex = 1;
            label1.Text = "   🗑️\r\nKhông có kết quả\r\n\r\n\r\n\r\n\r\n.\r\n";
            label1.TextAlign = ContentAlignment.BottomCenter;
            // 
            // panel4
            // 
            panel4.Controls.Add(button3);
            panel4.Controls.Add(button2);
            panel4.Controls.Add(button1);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(444, 47);
            panel4.TabIndex = 0;
            // 
            // button3
            // 
            button3.AutoSize = true;
            button3.BackColor = Color.FromArgb(247, 247, 247);
            button3.Location = new Point(288, 6);
            button3.Name = "button3";
            button3.Size = new Size(143, 30);
            button3.TabIndex = 2;
            button3.Text = "🏢 Không gian nhóm 🔽";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.AutoSize = true;
            button2.BackColor = Color.FromArgb(247, 247, 247);
            button2.Location = new Point(196, 6);
            button2.Name = "button2";
            button2.Size = new Size(78, 30);
            button2.TabIndex = 1;
            button2.Text = "📁 Trong 🔽";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.BackColor = Color.FromArgb(247, 247, 247);
            button1.Location = new Point(12, 6);
            button1.Name = "button1";
            button1.Size = new Size(170, 30);
            button1.TabIndex = 0;
            button1.Text = "👤 Chỉnh sửa gần nhất bởi 🔽";
            button1.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(label3);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 384);
            panel3.Name = "panel3";
            panel3.Size = new Size(444, 35);
            panel3.TabIndex = 2;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(247, 247, 247);
            label3.Dock = DockStyle.Bottom;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(444, 35);
            label3.TabIndex = 0;
            label3.Text = "Các trang trong Thùng rác quá 30 ngày sẽ tự động bị xóa";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ThungRac
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 419);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ThungRac";
            Text = "ThungRac";
            panel1.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label3;
        private Panel panel7;
        private Panel panel9;
        private Panel panel8;
        private PictureBox pictureBox1;
        private TextBox textBox1;
        private Label label1;
    }
}