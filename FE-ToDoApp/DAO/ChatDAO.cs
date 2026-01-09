using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE_ToDoApp.DAO
{
    public class ChatDAO
    {
        private ConnectSQL db = new ConnectSQL();

        // Lấy danh sách session chat
        public List<ChatSession> GetSessions()
        {
            List<ChatSession> list = new List<ChatSession>();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM ChatSessions ORDER BY CreatedAt DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    list.Add(new ChatSession
                    {
                        Id = rd["SessionID"].ToString(),
                        Title = rd["Title"].ToString(),
                        CreatedAt = Convert.ToDateTime(rd["CreatedAt"])
                    });
                }
            }

            return list;
        }

        // Lấy tin nhắn theo session
        public List<ChatMessage> GetMessages(string sessionId)
        {
            List<ChatMessage> list = new List<ChatMessage>();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT * FROM ChatMessages 
                               WHERE SessionID = @id 
                               ORDER BY ThoiGian";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", sessionId);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    list.Add(new ChatMessage
                    {
                        IsUser = Convert.ToBoolean(rd["IsUser"]),
                        Content = rd["Content"].ToString(),
                        Time = Convert.ToDateTime(rd["ThoiGian"])
                    });
                }
            }

            return list;
        }

        // Lưu session mới
        public void SaveSession(ChatSession session)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO ChatSessions (SessionID, Title, CreatedAt)
                               VALUES (@id, @title, @time)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", session.Id);
                cmd.Parameters.AddWithValue("@title", session.Title);
                cmd.Parameters.AddWithValue("@time", session.CreatedAt);
                cmd.ExecuteNonQuery();
            }
        }

        // Lưu tin nhắn
        public void SaveMessage(string sessionId, ChatMessage msg)
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = @"INSERT INTO ChatMessages
                           (SessionID, IsUser, Content, ThoiGian)
                           VALUES (@sid, @isUser, @content, @time)";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@sid", sessionId);
                    cmd.Parameters.AddWithValue("@isUser", msg.IsUser);
                    cmd.Parameters.AddWithValue("@content", msg.Content);
                    cmd.Parameters.AddWithValue("@time", msg.Time);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "❌ Lỗi khi lưu tin nhắn!\n" + ex.Message,
                    "Lỗi Database",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // =======================
        // XÓA SESSION
        // =======================
        public void DeleteSession(string sessionId)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string sqlMsg = "DELETE FROM ChatMessages WHERE SessionID = @id";
                SqlCommand cmdMsg = new SqlCommand(sqlMsg, conn);
                cmdMsg.Parameters.AddWithValue("@id", sessionId);
                cmdMsg.ExecuteNonQuery();

                string sqlSes = "DELETE FROM ChatSessions WHERE SessionID = @id";
                SqlCommand cmdSes = new SqlCommand(sqlSes, conn);
                cmdSes.Parameters.AddWithValue("@id", sessionId);
                cmdSes.ExecuteNonQuery();
            }
        }

    }
}
