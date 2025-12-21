namespace FE_ToDoApp.login
{
    partial class Login1
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

        #region Windows Form Designer generated code

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
            label3 = new Label();
            chkShowPassword = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10F);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(45, 299);
            label2.Name = "label2";
            label2.Size = new Size(86, 23);
            label2.TabIndex = 27;
            label2.Text = "Password:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10F);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(45, 229);
            label1.Name = "label1";
            label1.Size = new Size(91, 23);
            label1.TabIndex = 26;
            label1.Text = "Username:";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 120, 215);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(45, 465);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(360, 45);
            btnLogin.TabIndex = 25;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(45, 325);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(360, 32);
            txtPassword.TabIndex = 24;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(45, 255);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(360, 32);
            txtUsername.TabIndex = 23;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(165, 30);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // linkForgotPassword
            // 
            linkForgotPassword.AutoSize = true;
            linkForgotPassword.Font = new Font("Segoe UI", 9.5F);
            linkForgotPassword.LinkColor = Color.FromArgb(0, 120, 215);
            linkForgotPassword.Location = new Point(45, 415);
            linkForgotPassword.Name = "linkForgotPassword";
            linkForgotPassword.Size = new Size(133, 21);
            linkForgotPassword.TabIndex = 28;
            linkForgotPassword.TabStop = true;
            linkForgotPassword.Text = "Forgot Password?";
            linkForgotPassword.LinkClicked += linkForgotPassword_LinkClicked;
            // 
            // linkRegister
            // 
            linkRegister.AutoSize = true;
            linkRegister.Font = new Font("Segoe UI", 9.5F);
            linkRegister.LinkColor = Color.FromArgb(0, 120, 215);
            linkRegister.Location = new Point(340, 415);
            linkRegister.Name = "linkRegister";
            linkRegister.Size = new Size(67, 21);
            linkRegister.TabIndex = 29;
            linkRegister.TabStop = true;
            linkRegister.Text = "Register";
            linkRegister.LinkClicked += linkRegister_LinkClicked_1;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(chkShowPassword);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(linkRegister);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(linkForgotPassword);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(72, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(450, 550);
            panel1.TabIndex = 30;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 120, 215);
            label3.Location = new Point(148, 175);
            label3.Name = "label3";
            label3.Size = new Size(157, 41);
            label3.TabIndex = 36;
            label3.Text = "Welcome!";
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 9F);
            chkShowPassword.ForeColor = Color.Gray;
            chkShowPassword.Location = new Point(275, 365);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(132, 24);
            chkShowPassword.TabIndex = 35;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // Login1
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 245, 255);
            ClientSize = new Size(600, 650);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Login1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Todo App - Login";
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
        private CheckBox chkShowPassword;
        private Label label3;
    }
}