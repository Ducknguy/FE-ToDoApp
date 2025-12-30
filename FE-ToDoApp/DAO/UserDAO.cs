using System;
using System.Data.SqlClient;
using FE_ToDoApp.DTO;
using System.Drawing;
using System.IO;
// using FE_ToDoApp.DTO; // Nhớ dòng này nếu User.cs để trong DTO

namespace FE_ToDoApp.DAO
{
    public class UserDAO
    {
        // Lưu ý: Nếu bạn đã có class ConnectSQL.cs, bạn có thể dùng nó để lấy chuỗi kết nối
        private string connectionString = @"Data Source=YOUR_SERVER_NAME;Initial Catalog=YOUR_DATABASE_NAME;Integrated Security=True";

        // 1. Lấy thông tin người dùng
        public User GetUserById(int userId)
        {
            User user = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Giả sử bảng tên là Users
                string query = "SELECT * FROM Users WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", userId);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        user = new User();
                        user.Id = (int)reader["id"];
                        user.Username = reader["username"].ToString();
                        user.Email = reader["email"].ToString();
                        user.Name = reader["name"].ToString();

                        if (reader["image"] != DBNull.Value)
                        {
                            user.Avatar = (byte[])reader["image"];
                        }
                    }
                }
                catch (Exception ex) { }
            }
            return user;
        }

        // 2. Cập nhật thông tin
        public bool UpdateUserInfo(int id, string name, string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Users SET name = @name, email = @email WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 3. Cập nhật Avatar
        public bool UpdateUserAvatar(int id, byte[] imageBytes)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Users SET image = @img WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@img", imageBytes);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Các hàm hỗ trợ chuyển đổi ảnh
        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }
        // 4. Đổi mật khẩu
        public bool ChangePassword(int id, string newPassword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Users SET password = @pass WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pass", newPassword);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}