namespace FE_ToDoApp.login
{
    partial class ForgotPasswrod
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelCard = new Panel();
            labelBackToLogin = new Label();
            linkLogin = new LinkLabel();
            labelOr = new Label();
            panelLine1 = new Panel();
            panelLine2 = new Panel();
            btnResetPassword = new Button();
            chkShowPassword = new CheckBox();
            labelNewPass = new Label();
            txtNewPassword = new TextBox();
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
            panelCard.Controls.Add(labelBackToLogin);
            panelCard.Controls.Add(linkLogin);
            panelCard.Controls.Add(labelOr);
            panelCard.Controls.Add(panelLine1);
            panelCard.Controls.Add(panelLine2);
            panelCard.Controls.Add(btnResetPassword);
            panelCard.Controls.Add(chkShowPassword);
            panelCard.Controls.Add(labelNewPass);
            panelCard.Controls.Add(txtNewPassword);
            panelCard.Controls.Add(labelEmail);
            panelCard.Controls.Add(txtEmail);
            panelCard.Controls.Add(labelUser);
            panelCard.Controls.Add(txtUsername);
            panelCard.Controls.Add(labelTitle);
            panelCard.Controls.Add(pictureBoxLogo);
            panelCard.Location = new Point(100, 40);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(500, 680);
            panelCard.TabIndex = 0;
            // 
            // labelBackToLogin
            // 
            labelBackToLogin.Location = new Point(0, 0);
            labelBackToLogin.Name = "labelBackToLogin";
            labelBackToLogin.Size = new Size(100, 23);
            labelBackToLogin.TabIndex = 0;
            // 
            // linkLogin
            // 
            linkLogin.LinkColor = Color.FromArgb(37, 132, 235);
            linkLogin.Location = new Point(136, 624);
            linkLogin.Name = "linkLogin";
            linkLogin.Size = new Size(208, 25);
            linkLogin.TabIndex = 1;
            linkLogin.TabStop = true;
            linkLogin.Text = "Trở về trang đăng nhập";
            linkLogin.TextAlign = ContentAlignment.MiddleCenter;
            linkLogin.LinkClicked += linkLogin_LinkClicked;
            // 
            // labelOr
            // 
            labelOr.ForeColor = Color.FromArgb(160, 174, 192);
            labelOr.Location = new Point(215, 578);
            labelOr.Name = "labelOr";
            labelOr.Size = new Size(100, 23);
            labelOr.TabIndex = 2;
            labelOr.Text = "Hoặc";
            labelOr.Click += labelOr_Click;
            // 
            // panelLine1
            // 
            panelLine1.BackColor = Color.FromArgb(226, 232, 240);
            panelLine1.Location = new Point(50, 590);
            panelLine1.Name = "panelLine1";
            panelLine1.Size = new Size(175, 1);
            panelLine1.TabIndex = 3;
            // 
            // panelLine2
            // 
            panelLine2.BackColor = Color.FromArgb(226, 232, 240);
            panelLine2.Location = new Point(275, 590);
            panelLine2.Name = "panelLine2";
            panelLine2.Size = new Size(175, 1);
            panelLine2.TabIndex = 4;
            // 
            // btnResetPassword
            // 
            btnResetPassword.BackColor = Color.FromArgb(37, 132, 235);
            btnResetPassword.FlatAppearance.BorderSize = 0;
            btnResetPassword.FlatStyle = FlatStyle.Flat;
            btnResetPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnResetPassword.ForeColor = Color.White;
            btnResetPassword.Location = new Point(50, 510);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(400, 50);
            btnResetPassword.TabIndex = 5;
            btnResetPassword.Text = "Đổi mật khẩu";
            btnResetPassword.UseVisualStyleBackColor = false;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // chkShowPassword
            // 
            chkShowPassword.Font = new Font("Segoe UI", 9F);
            chkShowPassword.ForeColor = Color.FromArgb(113, 128, 150);
            chkShowPassword.Location = new Point(50, 455);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(150, 25);
            chkShowPassword.TabIndex = 6;
            chkShowPassword.Text = "Hiện mật khẩu";
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // labelNewPass
            // 
            labelNewPass.Font = new Font("Segoe UI Semibold", 10F);
            labelNewPass.Location = new Point(50, 380);
            labelNewPass.Name = "labelNewPass";
            labelNewPass.Size = new Size(126, 23);
            labelNewPass.TabIndex = 7;
            labelNewPass.Text = "Mật khẩu mới:";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Font = new Font("Segoe UI", 11F);
            txtNewPassword.Location = new Point(50, 410);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '●';
            txtNewPassword.Size = new Size(400, 32);
            txtNewPassword.TabIndex = 8;
            // 
            // labelEmail
            // 
            labelEmail.Font = new Font("Segoe UI Semibold", 10F);
            labelEmail.Location = new Point(50, 290);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(100, 23);
            labelEmail.TabIndex = 9;
            labelEmail.Text = " Email: ";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 11F);
            txtEmail.Location = new Point(50, 320);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(400, 32);
            txtEmail.TabIndex = 10;
            // 
            // labelUser
            // 
            labelUser.Font = new Font("Segoe UI Semibold", 10F);
            labelUser.Location = new Point(50, 200);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(134, 23);
            labelUser.TabIndex = 11;
            labelUser.Text = "Tên đăng nhập:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(50, 230);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(400, 32);
            txtUsername.TabIndex = 12;
            // 
            // labelTitle
            // 
            labelTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(45, 55, 72);
            labelTitle.Location = new Point(0, 130);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(500, 50);
            labelTitle.TabIndex = 13;
            labelTitle.Text = "Lấy lại mật khẩu";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Location = new Point(210, 40);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(80, 80);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 14;
            pictureBoxLogo.TabStop = false;
            // 
            // ForgotPasswrod
            // 
            BackColor = Color.FromArgb(242, 245, 249);
            ClientSize = new Size(700, 780);
            Controls.Add(panelCard);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ForgotPasswrod";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Todo App - Reset Password";
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelCard, panelLine1, panelLine2;
        private Label labelTitle, labelUser, labelEmail, labelNewPass, labelOr, labelBackToLogin;
        private TextBox txtUsername, txtEmail, txtNewPassword;
        private Button btnResetPassword;
        private LinkLabel linkLogin;
        private CheckBox chkShowPassword;
        private PictureBox pictureBoxLogo;
    }
}