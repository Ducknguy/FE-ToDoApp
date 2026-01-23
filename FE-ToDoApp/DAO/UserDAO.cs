using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using FE_ToDoApp.Database; // Dùng SQLiteHelper ở đây
using FE_ToDoApp.DTO;

namespace FE_ToDoApp.DAO
{
    public class UserDAO
    {
        public User GetUserById(int id)
        {
            string query = "SELECT * FROM Users WHERE Id = @id";
            SQLiteParameter param = new SQLiteParameter("@id", id);

            DataTable dt = SQLiteHelper.ExecuteQuery(query, param);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new User
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString(),
                    Email = row["Email"].ToString(),
                    // Kiểm tra nếu cột Avatar tồn tại và không null
                    Avatar = row.Table.Columns.Contains("Avatar") && row["Avatar"] != DBNull.Value
                             ? (byte[])row["Avatar"]
                             : null
                };
            }
            return null;
        }

        public bool UpdateUserInfo(int id, string username, string email)
        {
            string query = "UPDATE Users SET Username = @user, Email = @email WHERE Id = @id";
            SQLiteParameter[] p = {
                new SQLiteParameter("@user", username),
                new SQLiteParameter("@email", email),
                new SQLiteParameter("@id", id)
            };

            return SQLiteHelper.ExecuteNonQuery(query, p) > 0;
        }

        public bool ChangePassword(int id, string newPass)
        {
            string query = "UPDATE Users SET Password = @pass WHERE Id = @id";
            SQLiteParameter[] p = {
                new SQLiteParameter("@pass", newPass),
                new SQLiteParameter("@id", id)
            };

            return SQLiteHelper.ExecuteNonQuery(query, p) > 0;
        }

        public bool UpdateUserAvatar(int id, byte[] avatarData)
        {
            // Lưu ý: Cần đảm bảo bảng Users đã có cột Avatar
            string query = "UPDATE Users SET Avatar = @avatar WHERE Id = @id";
            SQLiteParameter[] p = {
                new SQLiteParameter("@avatar", avatarData),
                new SQLiteParameter("@id", id)
            };

            return SQLiteHelper.ExecuteNonQuery(query, p) > 0;
        }

        // Helper chuyển đổi ảnh
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