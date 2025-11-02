using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FE_ToDoApp.login
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string email = txtEmail.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text; // Giả sử bạn cũng dùng code xác nhận

            // ... (Toàn bộ phần kiểm tra mật khẩu khớp và kiểm tra rỗng giữ nguyên) ...
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu và Mật khẩu xác nhận không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- ĐÂY LÀ DÒNG ĐÃ SỬA ---
            // Tên bảng là [User] (số ít)
            // Tên các cột là username, password, email (viết thường)
            string query = "INSERT INTO [User] (username, password, email) VALUES (@User, @Pass, @Email)";

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        // Tên tham số C# (@User, @Pass, @Email) vẫn phải khớp với
                        // phần VALUES (@User, @Pass, @Email) của câu query
                        command.Parameters.AddWithValue("@User", username);
                        command.Parameters.AddWithValue("@Pass", password);
                        command.Parameters.AddWithValue("@Email", email);

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Đóng form đăng ký
                        }
                        else
                        {
                            MessageBox.Show("Đăng ký thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Lỗi "Invalid object name" sẽ biến mất sau khi sửa
                        // Lỗi "Must declare..." cũng sẽ biến mất nếu bạn
                        // đảm bảo 3 dòng AddWithValue ở trên là chính xác.
                        MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
