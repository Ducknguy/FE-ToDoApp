namespace FE_ToDoApp.login
{
    partial class Register
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
            label4 = new Label();
            txtEmail = new TextBox();
            label3 = new Label();
            txtConfirmPassword = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnRegister = new Button();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            pictureBox1 = new PictureBox();
            chkShowPassword = new CheckBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(chkShowPassword);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtConfirmPassword);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnRegister);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(40, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(738, 545);
            panel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(117, 359);
            label4.Name = "label4";
            label4.Size = new Size(63, 22);
            label4.TabIndex = 31;
            label4.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(327, 351);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(294, 30);
            txtEmail.TabIndex = 30;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(117, 301);
            label3.Name = "label3";
            label3.Size = new Size(164, 22);
            label3.TabIndex = 29;
            label3.Text = "Confirm Password:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(327, 293);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(294, 30);
            txtConfirmPassword.TabIndex = 28;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(117, 250);
            label2.Name = "label2";
            label2.Size = new Size(94, 22);
            label2.TabIndex = 27;
            label2.Text = "Password:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(117, 201);
            label1.Name = "label1";
            label1.Size = new Size(94, 22);
            label1.TabIndex = 26;
            label1.Text = "Username:";
            // 
            // btnRegister
            // 
            btnRegister.AutoSize = true;
            btnRegister.Location = new Point(295, 470);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(143, 72);
            btnRegister.TabIndex = 25;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click_1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(327, 242);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(294, 30);
            txtPassword.TabIndex = 24;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(327, 193);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(294, 30);
            txtUsername.TabIndex = 23;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.search__1_;
            pictureBox1.Location = new Point(279, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(177, 172);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Location = new Point(461, 411);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(160, 26);
            chkShowPassword.TabIndex = 32;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(824, 603);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Register";
            Text = "Register";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label4;
        private TextBox txtEmail;
        private Label label3;
        private TextBox txtConfirmPassword;
        private Label label2;
        private Label label1;
        private Button btnRegister;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private PictureBox pictureBox1;
        private CheckBox chkShowPassword;
    }
}