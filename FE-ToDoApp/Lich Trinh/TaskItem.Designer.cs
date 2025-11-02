namespace FE_ToDoApp.Lich_Trinh
{
    partial class TaskItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskItem));
            panel1 = new Panel();
            trashcan_delete = new PictureBox();
            trashcan_nondelete = new PictureBox();
            textBox1 = new TextBox();
            checkBox1 = new CheckBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trashcan_delete).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trashcan_nondelete).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(trashcan_delete);
            panel1.Controls.Add(trashcan_nondelete);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(checkBox1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(893, 57);
            panel1.TabIndex = 1;
            // 
            // trashcan_delete
            // 
            trashcan_delete.Cursor = Cursors.Hand;
            trashcan_delete.Image = (Image)resources.GetObject("trashcan_delete.Image");
            trashcan_delete.Location = new Point(836, 5);
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
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Cursor = Cursors.IBeam;
            textBox1.Font = new Font("Segoe UI", 16F);
            textBox1.Location = new Point(71, 10);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Việc cần làm";
            textBox1.Size = new Size(672, 36);
            textBox1.TabIndex = 1;
            // 
            // checkBox1
            // 
            checkBox1.Cursor = Cursors.Hand;
            checkBox1.FlatStyle = FlatStyle.System;
            checkBox1.Font = new Font("Segoe UI", 20F);
            checkBox1.Location = new Point(3, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.RightToLeft = RightToLeft.Yes;
            checkBox1.Size = new Size(40, 51);
            checkBox1.TabIndex = 0;
            checkBox1.TextAlign = ContentAlignment.MiddleCenter;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // TaskItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(panel1);
            Name = "TaskItem";
            Size = new Size(896, 60);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trashcan_delete).EndInit();
            ((System.ComponentModel.ISupportInitialize)trashcan_nondelete).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox trashcan_delete;
        private PictureBox trashcan_nondelete;
        private TextBox textBox1;
        private CheckBox checkBox1;
    }
}
