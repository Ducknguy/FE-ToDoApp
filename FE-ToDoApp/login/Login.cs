using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

public class DatabaseHelper
{
    // Cần thay đổi chuỗi kết nối này cho phù hợp với SQL Server của bạn!
    private static string connectionString = @"D:\VS\BTL\FE-TODOAPP\LOGIN\DATABASE1.MDF";

    // Hoặc sử dụng ConfigurationManager.ConnectionStrings["UserDBConnection"].ConnectionString;

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }
}

namespace FE_ToDoApp.login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            string query = "SELECT COUNT(1) FROM Users WHERE Username = @User AND Password = @Pass";

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@User", username);
                        command.Parameters.AddWithValue("@Pass", password); // So sánh mật khẩu (Chưa Hash)

                        int count = (int)command.ExecuteScalar();

                        if (count == 1)
                        {
                            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Mở Form Chính của ứng dụng và ẩn/đóng LoginForm
                            // Example: new MainForm().Show(); this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Thêm sự kiện click cho 'Quên mật khẩu' (ví dụ: lblForgotPassword_Click)
        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Mở form quên mật khẩu
            ForgotPasswrod forgotForm = new ForgotPasswrod();
            forgotForm.ShowDialog();
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Mở form đăng kí
            // Sử dụng ShowDialog() để nó chặn tương tác với form đăng nhập
            // cho đến khi form đăng kí được đóng lại.
            Register registerForm = new Register();
            registerForm.ShowDialog();
        }
    }
}
