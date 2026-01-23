namespace FE_ToDoApp.login
{
    partial class Register
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
            labelLoginLink = new Label();
            linkLogin = new LinkLabel();
            btnRegister = new Button();
            chkShowPassword = new CheckBox();
            labelConfirm = new Label();
            txtConfirmPassword = new TextBox();
            labelPass = new Label();
            txtPassword = new TextBox();
            labelEmail = new Label();
            txtEmail = new TextBox();
            labelUser = new Label();
            txtUsername = new TextBox();
            labelTitle = new Label();
            pictureBoxLogo = new PictureBox();
            panelCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // panelCard
            // 
            panelCard.Anchor = AnchorStyles.None;
            panelCard.BackColor = Color.White;
            panelCard.Controls.Add(labelLoginLink);
            panelCard.Controls.Add(linkLogin);
            panelCard.Controls.Add(btnRegister);
            panelCard.Controls.Add(chkShowPassword);
            panelCard.Controls.Add(labelConfirm);
            panelCard.Controls.Add(txtConfirmPassword);
            panelCard.Controls.Add(labelPass);
            panelCard.Controls.Add(txtPassword);
            panelCard.Controls.Add(labelEmail);
            panelCard.Controls.Add(txtEmail);
            panelCard.Controls.Add(labelUser);
            panelCard.Controls.Add(txtUsername);
            panelCard.Controls.Add(labelTitle);
            panelCard.Controls.Add(pictureBoxLogo);
            panelCard.Location = new Point(100, 40);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(500, 720);
            panelCard.TabIndex = 0;
            // 
            // labelLoginLink
            // 
            labelLoginLink.ForeColor = Color.FromArgb(113, 128, 150);
            labelLoginLink.Location = new Point(77, 630);
            labelLoginLink.Name = "labelLoginLink";
            labelLoginLink.Size = new Size(213, 25);
            labelLoginLink.TabIndex = 0;
            labelLoginLink.Text = "Bạn đã có tài khoản?";
            // 
            // linkLogin
            // 
            linkLogin.LinkColor = Color.FromArgb(37, 132, 235);
            linkLogin.Location = new Point(282, 630);
            linkLogin.Name = "linkLogin";
            linkLogin.Size = new Size(113, 25);
            linkLogin.TabIndex = 1;
            linkLogin.TabStop = true;
            linkLogin.Text = "Đăng nhập";
            linkLogin.TextAlign = ContentAlignment.MiddleCenter;
            linkLogin.LinkClicked += linkLogin_LinkClicked;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(37, 132, 235);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(50, 530);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(400, 55);
            btnRegister.TabIndex = 2;
            btnRegister.Text = "Đăng kí";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click_1;
            // 
            // chkShowPassword
            // 
            chkShowPassword.Font = new Font("Segoe UI", 9F);
            chkShowPassword.ForeColor = Color.FromArgb(113, 128, 150);
            chkShowPassword.Location = new Point(50, 475);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(200, 25);
            chkShowPassword.TabIndex = 3;
            chkShowPassword.Text = "Hiện mật khẩu";
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // labelConfirm
            // 
            labelConfirm.Font = new Font("Segoe UI Semibold", 10F);
            labelConfirm.Location = new Point(260, 390);
            labelConfirm.Name = "labelConfirm";
            labelConfirm.Size = new Size(190, 23);
            labelConfirm.TabIndex = 4;
            labelConfirm.Text = "Xác nhận mật khẩu: ";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(260, 420);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '●';
            txtConfirmPassword.Size = new Size(190, 30);
            txtConfirmPassword.TabIndex = 5;
            // 
            // labelPass
            // 
            labelPass.Font = new Font("Segoe UI Semibold", 10F);
            labelPass.Location = new Point(50, 390);
            labelPass.Name = "labelPass";
            labelPass.Size = new Size(100, 23);
            labelPass.TabIndex = 6;
            labelPass.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(50, 420);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(190, 30);
            txtPassword.TabIndex = 7;
            // 
            // labelEmail
            // 
            labelEmail.Font = new Font("Segoe UI Semibold", 10F);
            labelEmail.Location = new Point(50, 300);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(100, 23);
            labelEmail.TabIndex = 8;
            labelEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 11F);
            txtEmail.Location = new Point(50, 330);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(400, 32);
            txtEmail.TabIndex = 9;
            // 
            // labelUser
            // 
            labelUser.Font = new Font("Segoe UI Semibold", 10F);
            labelUser.Location = new Point(50, 210);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(128, 23);
            labelUser.TabIndex = 10;
            labelUser.Text = "Tên đăng nhập:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(50, 240);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(400, 32);
            txtUsername.TabIndex = 11;
            // 
            // labelTitle
            // 
            labelTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(45, 55, 72);
            labelTitle.Location = new Point(0, 130);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(500, 50);
            labelTitle.TabIndex = 12;
            labelTitle.Text = "TẠO TÀI KHOẢN";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Location = new Point(210, 40);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(80, 80);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 13;
            pictureBoxLogo.TabStop = false;
            // 
            // Register
            // 
            BackColor = Color.FromArgb(242, 245, 249);
            ClientSize = new Size(700, 800);
            Controls.Add(panelCard);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Todo App - Create Account";
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
        }

        private Panel panelCard;
        private Label labelTitle, labelUser, labelEmail, labelPass, labelConfirm, labelLoginLink;
        private TextBox txtUsername, txtEmail, txtPassword, txtConfirmPassword;
        private CheckBox chkShowPassword;
        private Button btnRegister;
        private LinkLabel linkLogin;
        private PictureBox pictureBoxLogo;
    }
}