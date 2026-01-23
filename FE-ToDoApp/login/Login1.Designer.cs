namespace FE_ToDoApp.login
{
    partial class Login1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelCard = new Panel();
            labelOr = new Label();
            panelLine2 = new Panel();
            panelLine1 = new Panel();
            labelNoAccount = new Label();
            linkRegister = new LinkLabel();
            labelPass = new Label();
            labelEmailUser = new Label();
            chkShowPassword = new CheckBox();
            labelTitle = new Label();
            txtUsername = new TextBox();
            linkForgotPassword = new LinkLabel();
            txtPassword = new TextBox();
            btnLogin = new Button();
            panelCard.SuspendLayout();
            SuspendLayout();
            // 
            // panelCard
            // 
            panelCard.Anchor = AnchorStyles.None;
            panelCard.BackColor = Color.White;
            panelCard.Controls.Add(labelOr);
            panelCard.Controls.Add(panelLine2);
            panelCard.Controls.Add(panelLine1);
            panelCard.Controls.Add(labelNoAccount);
            panelCard.Controls.Add(linkRegister);
            panelCard.Controls.Add(labelPass);
            panelCard.Controls.Add(labelEmailUser);
            panelCard.Controls.Add(chkShowPassword);
            panelCard.Controls.Add(labelTitle);
            panelCard.Controls.Add(txtUsername);
            panelCard.Controls.Add(linkForgotPassword);
            panelCard.Controls.Add(txtPassword);
            panelCard.Controls.Add(btnLogin);
            panelCard.Location = new Point(100, 60);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(500, 600);
            panelCard.TabIndex = 0;
            // 
            // labelOr
            // 
            labelOr.ForeColor = Color.FromArgb(160, 174, 192);
            labelOr.Location = new Point(235, 500);
            labelOr.Name = "labelOr";
            labelOr.Size = new Size(59, 23);
            labelOr.TabIndex = 0;
            labelOr.Text = "Hoặc";
            // 
            // panelLine2
            // 
            panelLine2.BackColor = Color.FromArgb(226, 232, 240);
            panelLine2.Location = new Point(275, 510);
            panelLine2.Name = "panelLine2";
            panelLine2.Size = new Size(175, 1);
            panelLine2.TabIndex = 1;
            // 
            // panelLine1
            // 
            panelLine1.BackColor = Color.FromArgb(226, 232, 240);
            panelLine1.Location = new Point(50, 510);
            panelLine1.Name = "panelLine1";
            panelLine1.Size = new Size(175, 1);
            panelLine1.TabIndex = 2;
            // 
            // labelNoAccount
            // 
            labelNoAccount.ForeColor = Color.FromArgb(113, 128, 150);
            labelNoAccount.Location = new Point(71, 550);
            labelNoAccount.Name = "labelNoAccount";
            labelNoAccount.Size = new Size(215, 23);
            labelNoAccount.TabIndex = 3;
            labelNoAccount.Text = "Bạn không có tài khoản?";
            // 
            // linkRegister
            // 
            linkRegister.LinkColor = Color.FromArgb(37, 132, 235);
            linkRegister.Location = new Point(292, 550);
            linkRegister.Name = "linkRegister";
            linkRegister.Size = new Size(158, 23);
            linkRegister.TabIndex = 4;
            linkRegister.TabStop = true;
            linkRegister.Text = "Tạo tài khoản";
            linkRegister.TextAlign = ContentAlignment.MiddleCenter;
            linkRegister.LinkClicked += linkRegister_LinkClicked_1;
            // 
            // labelPass
            // 
            labelPass.Font = new Font("Segoe UI Semibold", 10F);
            labelPass.Location = new Point(50, 290);
            labelPass.Name = "labelPass";
            labelPass.Size = new Size(100, 23);
            labelPass.TabIndex = 5;
            labelPass.Text = "Mật khẩu:";
            // 
            // labelEmailUser
            // 
            labelEmailUser.Font = new Font("Segoe UI Semibold", 10F);
            labelEmailUser.Location = new Point(50, 200);
            labelEmailUser.Name = "labelEmailUser";
            labelEmailUser.Size = new Size(128, 23);
            labelEmailUser.TabIndex = 6;
            labelEmailUser.Text = "Tên đăng nhập:";
            // 
            // chkShowPassword
            // 
            chkShowPassword.ForeColor = Color.FromArgb(113, 128, 150);
            chkShowPassword.Location = new Point(50, 370);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(163, 24);
            chkShowPassword.TabIndex = 7;
            chkShowPassword.Text = "Hiện mật khẩu";
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // labelTitle
            // 
            labelTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(45, 55, 72);
            labelTitle.Location = new Point(-3, 85);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(500, 50);
            labelTitle.TabIndex = 8;
            labelTitle.Text = "CHÀO MỪNG";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(50, 230);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(400, 30);
            txtUsername.TabIndex = 10;
            // 
            // linkForgotPassword
            // 
            linkForgotPassword.LinkColor = Color.FromArgb(37, 132, 235);
            linkForgotPassword.Location = new Point(304, 371);
            linkForgotPassword.Name = "linkForgotPassword";
            linkForgotPassword.Size = new Size(146, 23);
            linkForgotPassword.TabIndex = 11;
            linkForgotPassword.TabStop = true;
            linkForgotPassword.Text = "Quên mật khẩu?";
            linkForgotPassword.LinkClicked += linkForgotPassword_LinkClicked_1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(50, 320);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(400, 30);
            txtPassword.TabIndex = 12;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(37, 132, 235);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(50, 430);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(400, 50);
            btnLogin.TabIndex = 13;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click_1;
            // 
            // Login1
            // 
            BackColor = Color.FromArgb(242, 245, 249);
            ClientSize = new Size(700, 726);
            Controls.Add(panelCard);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Login1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelCard, panelLine1, panelLine2;
        private Label labelTitle, labelEmailUser, labelPass, labelNoAccount, labelOr;
        private CheckBox chkShowPassword;
        private TextBox txtUsername, txtPassword;
        private Button btnLogin;
        private LinkLabel linkForgotPassword, linkRegister;
    }
}