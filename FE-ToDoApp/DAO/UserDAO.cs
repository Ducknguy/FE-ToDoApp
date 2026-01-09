using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using FE_ToDoApp.DTO;

namespace FE_ToDoApp.DAO
{
    public class UserDAO
    {
        private string connectionString = @"Data Source=Money\SQLEXPRESS;Initial Catalog=ToDoApp;Integrated Security=True";

        public User GetUserById(int userId)
        {
            User user = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM [User] WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", userId);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        user = new User();
                        user.Id = (int)reader["Id"];
                        user.Username = reader["Username"].ToString();
                        user.Password = reader["Password"].ToString();
                        user.Email = reader["Email"].ToString();

                        if (reader["DateCreated"] != DBNull.Value)
                            user.DateCreated = (DateTime)reader["DateCreated"];

                        // --- KHÔI PHỤC: Đọc dữ liệu ảnh từ cột Image ---
                        if (reader["Image"] != DBNull.Value)
                        {
                            user.Avatar = (byte[])reader["Image"];
                        }
                    }
                }
                catch (Exception ex) { /* Xử lý lỗi log */ }
            }
            return user;
        }

        //update in4 
        public bool UpdateUserInfo(int id, string username, string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE [User] SET Username = @user, Email = @email WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // update password
        public bool ChangePassword(int id, string newPassword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE [User] SET Password = @pass WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pass", newPassword);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateUserAvatar(int id, byte[] imageBytes)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE [User] SET [Image] = @img WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@img", imageBytes);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

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
    }
}