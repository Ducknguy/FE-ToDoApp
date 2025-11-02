namespace FE_ToDoApp.login
{
    partial class Login1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login1));
            label2 = new Label();
            label1 = new Label();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            pictureBox1 = new PictureBox();
            linkForgotPassword = new LinkLabel();
            linkRegister = new LinkLabel();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(162, 306);
            label2.Name = "label2";
            label2.Size = new Size(94, 22);
            label2.TabIndex = 27;
            label2.Text = "Password:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(162, 239);
            label1.Name = "label1";
            label1.Size = new Size(94, 22);
            label1.TabIndex = 26;
            label1.Text = "Username:";
            // 
            // btnLogin
            // 
            btnLogin.AutoSize = true;
            btnLogin.Location = new Point(295, 465);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(143, 72);
            btnLogin.TabIndex = 25;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(372, 298);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(294, 30);
            txtPassword.TabIndex = 24;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(372, 231);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(294, 30);
            txtUsername.TabIndex = 23;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(284, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(190, 168);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // linkForgotPassword
            // 
            linkForgotPassword.AutoSize = true;
            linkForgotPassword.Location = new Point(162, 397);
            linkForgotPassword.Name = "linkForgotPassword";
            linkForgotPassword.Size = new Size(146, 22);
            linkForgotPassword.TabIndex = 28;
            linkForgotPassword.TabStop = true;
            linkForgotPassword.Text = "Forgot Pasword?";
            linkForgotPassword.LinkClicked += linkForgotPassword_LinkClicked;
            // 
            // linkRegister
            // 
            linkRegister.AutoSize = true;
            linkRegister.Location = new Point(571, 397);
            linkRegister.Name = "linkRegister";
            linkRegister.Size = new Size(76, 22);
            linkRegister.TabIndex = 29;
            linkRegister.TabStop = true;
            linkRegister.Text = "Register";
            linkRegister.LinkClicked += linkRegister_LinkClicked_1;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(linkRegister);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(linkForgotPassword);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(40, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(738, 545);
            panel1.TabIndex = 30;
            // 
            // Login1
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(824, 603);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Login1";
            Text = "Login1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label2;
        private Label label1;
        private Button btnLogin;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private PictureBox pictureBox1;
        private LinkLabel linkForgotPassword;
        private LinkLabel linkRegister;
        private Panel panel1;
    }
}