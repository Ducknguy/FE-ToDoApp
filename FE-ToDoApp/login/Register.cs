using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FE_ToDoApp.Database;

namespace FE_ToDoApp.login
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            string Username = txtUsername.Text.Trim();
            string Password = txtPassword.Text;
            string Email = txtEmail.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Password.Length < 8)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 8 ký tự để đảm bảo an toàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (Password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu và Mật khẩu xác nhận không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Email.ToLower().EndsWith("@gmail.com") || Email.Length <= 10)
            {
                MessageBox.Show("Email đăng ký phải có định dạng @gmail.com (Ví dụ: abc@gmail.com)", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            try
            {
                using (SQLiteConnection connection = SQLiteHelper.GetConnection())
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(1) FROM Users WHERE Username = @User";

                    using (SQLiteCommand checkCommand = new SQLiteCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@User", Username);
                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Tên tài khoản này đã tồn tại. Vui lòng chọn tên khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtUsername.Focus();
                            return;
                        }
                    }

                    string insertQuery = "INSERT INTO Users (Username, Password, Email) VALUES (@User, @Pass, @Email)";

                    using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@User", Username);
                        insertCommand.Parameters.AddWithValue("@Pass", Password);
                        insertCommand.Parameters.AddWithValue("@Email", Email);

                        int result = insertCommand.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Login1 loginForm = new Login1();
                            loginForm.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Đăng ký thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            char passwordChar = chkShowPassword.Checked ? '\0' : '*';

            txtPassword.PasswordChar = passwordChar;
            txtConfirmPassword.PasswordChar = passwordChar;
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login1 loginForm = new Login1();
            loginForm.Show();
            this.Hide();
        }
    }
}