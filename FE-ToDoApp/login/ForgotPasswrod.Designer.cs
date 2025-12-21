namespace FE_ToDoApp.login
{
    partial class ForgotPasswrod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPasswrod));
            panel1 = new Panel();
            btnResetPassword = new Button();
            txtNewPassword = new TextBox();
            txtEmail = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtUsername = new TextBox();
            label = new Label();
            pictureBox1 = new PictureBox();
            chkShowPassword = new CheckBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(chkShowPassword);
            panel1.Controls.Add(btnResetPassword);
            panel1.Controls.Add(txtNewPassword);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(label);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(49, 30);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(738, 545);
            panel1.TabIndex = 0;
            // 
            // btnResetPassword
            // 
            btnResetPassword.Location = new Point(299, 464);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(135, 51);
            btnResetPassword.TabIndex = 33;
            btnResetPassword.Text = "Reset";
            btnResetPassword.UseVisualStyleBackColor = true;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(315, 355);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.Size = new Size(275, 30);
            txtNewPassword.TabIndex = 32;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(315, 297);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(275, 30);
            txtEmail.TabIndex = 31;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(150, 358);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(137, 22);
            label2.TabIndex = 30;
            label2.Text = "New Password:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(150, 305);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(63, 22);
            label1.TabIndex = 29;
            label1.Text = "Email:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(315, 239);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(275, 30);
            txtUsername.TabIndex = 28;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(150, 247);
            label.Margin = new Padding(4, 0, 4, 0);
            label.Name = "label";
            label.Size = new Size(94, 22);
            label.TabIndex = 27;
            label.Text = "Username:";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(268, 16);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(190, 168);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Location = new Point(430, 406);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(160, 26);
            chkShowPassword.TabIndex = 34;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // ForgotPasswrod
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(824, 603);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ForgotPasswrod";
            Text = "ForgotPasswrod";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label;
        private TextBox txtUsername;
        private TextBox txtNewPassword;
        private TextBox txtEmail;
        private Label label2;
        private Label label1;
        private Button btnResetPassword;
        private CheckBox chkShowPassword;
    }
}