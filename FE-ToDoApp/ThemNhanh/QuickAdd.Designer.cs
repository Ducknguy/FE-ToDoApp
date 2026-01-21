namespace FE_ToDoApp.ThemNhanh
{
    partial class QuickAdd
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
            panel1 = new Panel();
            label1 = new Label();
            cbPanel = new Panel();
            comboBox1 = new ComboBox();
            label2 = new Label();
            btnPanel = new Panel();
            btn_Huy = new Button();
            btn_Them = new Button();
            mainPanel = new Panel();
            panel1.SuspendLayout();
            cbPanel.SuspendLayout();
            btnPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 59);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(243, 2);
            label1.Name = "label1";
            label1.Size = new Size(266, 54);
            label1.TabIndex = 0;
            label1.Text = "Thêm Nhanh";
            // 
            // cbPanel
            // 
            cbPanel.Controls.Add(comboBox1);
            cbPanel.Controls.Add(label2);
            cbPanel.Dock = DockStyle.Top;
            cbPanel.Location = new Point(0, 59);
            cbPanel.Name = "cbPanel";
            cbPanel.Size = new Size(800, 80);
            cbPanel.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Todo", "Week" });
            comboBox1.Location = new Point(66, 34);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 3);
            label2.Name = "label2";
            label2.Size = new Size(99, 28);
            label2.TabIndex = 0;
            label2.Text = "Chọn loại:";
            // 
            // btnPanel
            // 
            btnPanel.Controls.Add(btn_Huy);
            btnPanel.Controls.Add(btn_Them);
            btnPanel.Dock = DockStyle.Bottom;
            btnPanel.Location = new Point(0, 735);
            btnPanel.Name = "btnPanel";
            btnPanel.Size = new Size(800, 70);
            btnPanel.TabIndex = 2;
            // 
            // btn_Huy
            // 
            btn_Huy.Font = new Font("Segoe UI", 12F);
            btn_Huy.Location = new Point(548, 23);
            btn_Huy.Name = "btn_Huy";
            btn_Huy.Size = new Size(94, 35);
            btn_Huy.TabIndex = 1;
            btn_Huy.Text = "Hủy";
            btn_Huy.UseVisualStyleBackColor = true;
            btn_Huy.Click += btn_Huy_Click;
            // 
            // btn_Them
            // 
            btn_Them.Font = new Font("Segoe UI", 12F);
            btn_Them.Location = new Point(694, 23);
            btn_Them.Name = "btn_Them";
            btn_Them.Size = new Size(94, 35);
            btn_Them.TabIndex = 0;
            btn_Them.Text = "Thêm";
            btn_Them.UseVisualStyleBackColor = true;
            btn_Them.Click += btn_Them_Click;
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 139);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(800, 596);
            mainPanel.TabIndex = 3;
            // 
            // QuickAdd
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 805);
            Controls.Add(mainPanel);
            Controls.Add(btnPanel);
            Controls.Add(cbPanel);
            Controls.Add(panel1);
            Name = "QuickAdd";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm Nhanh - Quick Add";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            cbPanel.ResumeLayout(false);
            cbPanel.PerformLayout();
            btnPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel cbPanel;
        private Label label2;
        private ComboBox comboBox1;
        private Panel btnPanel;
        private Panel mainPanel;
        private Button btn_Huy;
        private Button btn_Them;
    }
}