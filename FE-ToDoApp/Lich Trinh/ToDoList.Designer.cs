namespace FE_ToDoApp.Lich_Trinh
{
    partial class ToDoList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToDoList));
            label1 = new Label();
            panelContent = new Panel();
            pictureBox4 = new PictureBox();
            panel4 = new Panel();
            trashcan_delete = new PictureBox();
            trashcan_nondelete = new PictureBox();
            textBox2 = new TextBox();
            checkBox2 = new CheckBox();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trashcan_delete).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trashcan_nondelete).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(79, 44);
            label1.Name = "label1";
            label1.Size = new Size(212, 54);
            label1.TabIndex = 0;
            label1.Text = "To-Do List";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelContent
            // 
            panelContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelContent.AutoScroll = true;
            panelContent.Controls.Add(panel4);
            panelContent.Location = new Point(79, 128);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(907, 440);
            panelContent.TabIndex = 2;
            // 
            // pictureBox4
            // 
            pictureBox4.Cursor = Cursors.Hand;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(992, 126);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(71, 59);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 3;
            pictureBox4.TabStop = false;
            pictureBox4.Click += add_item_click;
            // 
            // panel4
            // 
            panel4.Controls.Add(trashcan_delete);
            panel4.Controls.Add(trashcan_nondelete);
            panel4.Controls.Add(textBox2);
            panel4.Controls.Add(checkBox2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(907, 57);
            panel4.TabIndex = 2;
            // 
            // trashcan_delete
            // 
            trashcan_delete.Cursor = Cursors.Hand;
            trashcan_delete.Image = (Image)resources.GetObject("trashcan_delete.Image");
            trashcan_delete.Location = new Point(836, 4);
            trashcan_delete.Name = "trashcan_delete";
            trashcan_delete.Size = new Size(54, 46);
            trashcan_delete.SizeMode = PictureBoxSizeMode.Zoom;
            trashcan_delete.TabIndex = 3;
            trashcan_delete.TabStop = false;
            trashcan_delete.Visible = false;
            trashcan_delete.MouseLeave += leave_trashcan;
            // 
            // trashcan_nondelete
            // 
            trashcan_nondelete.Cursor = Cursors.Hand;
            trashcan_nondelete.Image = (Image)resources.GetObject("trashcan_nondelete.Image");
            trashcan_nondelete.Location = new Point(836, 5);
            trashcan_nondelete.Name = "trashcan_nondelete";
            trashcan_nondelete.Size = new Size(54, 46);
            trashcan_nondelete.SizeMode = PictureBoxSizeMode.Zoom;
            trashcan_nondelete.TabIndex = 2;
            trashcan_nondelete.TabStop = false;
            trashcan_nondelete.MouseHover += hover_trashcan;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.White;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Cursor = Cursors.IBeam;
            textBox2.Font = new Font("Segoe UI", 16F);
            textBox2.Location = new Point(71, 10);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Việc cần làm";
            textBox2.Size = new Size(672, 36);
            textBox2.TabIndex = 1;
            // 
            // checkBox2
            // 
            checkBox2.Cursor = Cursors.Hand;
            checkBox2.FlatStyle = FlatStyle.System;
            checkBox2.Font = new Font("Segoe UI", 20F);
            checkBox2.Location = new Point(3, 3);
            checkBox2.Name = "checkBox2";
            checkBox2.RightToLeft = RightToLeft.Yes;
            checkBox2.Size = new Size(40, 51);
            checkBox2.TabIndex = 0;
            checkBox2.TextAlign = ContentAlignment.MiddleCenter;
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // ToDoList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1072, 632);
            Controls.Add(pictureBox4);
            Controls.Add(panelContent);
            Controls.Add(label1);
            Name = "ToDoList";
            Text = "ToDoList";
            panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trashcan_delete).EndInit();
            ((System.ComponentModel.ISupportInitialize)trashcan_nondelete).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panelContent;
        private PictureBox pictureBox4;
        private Panel panel4;
        private PictureBox trashcan_delete;
        private PictureBox trashcan_nondelete;
        private TextBox textBox2;
        private CheckBox checkBox2;
    }
}