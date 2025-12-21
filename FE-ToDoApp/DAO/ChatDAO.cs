using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; // Thư viện để dùng SqlParameter
using FE_ToDoApp; // Namespace chứa ConnectSQL

namespace ChatbotAI_Form.DAO
{
    public class ChatDAO
    {
        // Gọi class kết nối để dùng ké các hàm LayDuLieu/ThucHienLenh cơ bản
        private ConnectSQL db = new ConnectSQL();

        // 1. Lấy danh sách lịch sử (Dùng hàm cũ cho nhanh)
        public List<ChatSession> GetHistory()
        {
            List<ChatSession> list = new List<ChatSession>();
            string sql = "SELECT * FROM ChatSessions ORDER BY CreatedAt DESC";
            DataTable dt = db.LayDuLieu(sql);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ChatSession()
                {
                    Id = row["SessionID"].ToString(),
                    Title = row["Title"].ToString(),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"])
                });
            }
            return list;
        }

        // 2. Lấy tin nhắn chi tiết (Dùng hàm cũ cho nhanh)
        public List<ChatMessage> GetMessages(string sessionId)
        {
            List<ChatMessage> messages = new List<ChatMessage>();
            string sql = "SELECT * FROM ChatMessages WHERE SessionID = '" + sessionId + "' ORDER BY ThoiGian ASC";
            DataTable dt = db.LayDuLieu(sql);

            foreach (DataRow row in dt.Rows)
            {
                ChatMessage msg = new ChatMessage();
                msg.IsUser = Convert.ToBoolean(row["IsUser"]);
                msg.Content = row["Content"].ToString();

                string fileString = row["Files"].ToString();
                if (!string.IsNullOrEmpty(fileString))
                    msg.Files.AddRange(fileString.Split(';'));

                messages.Add(msg);
            }
            return messages;
        }

        // 3. Tạo Session mới (Cần bảo mật -> Tự mở kết nối dùng SqlParameter)
        public void AddSession(ChatSession session)
        {
            // Lấy chuỗi kết nối từ ConnectSQL
            using (SqlConnection conn = new SqlConnection(ConnectSQL.strCon))
            {
                conn.Open();
                string sql = "INSERT INTO ChatSessions (SessionID, Title, CreatedAt) VALUES (@id, @title, @time)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", session.Id);
                    cmd.Parameters.AddWithValue("@title", session.Title);
                    cmd.Parameters.AddWithValue("@time", session.CreatedAt);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 4. Lưu tin nhắn (Cần bảo mật -> Tự mở kết nối dùng SqlParameter)
        public void AddMessage(string sessionId, string content, bool isUser, List<string> files = null)
        {
            // Lấy chuỗi kết nối từ ConnectSQL
            using (SqlConnection conn = new SqlConnection(ConnectSQL.strCon))
            {
                conn.Open();
                string sql = "INSERT INTO ChatMessages (SessionID, IsUser, Content, ThoiGian, Files) VALUES (@sid, @isUser, @content, @time, @files)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    string filePaths = (files != null && files.Count > 0) ? string.Join(";", files) : "";

                    cmd.Parameters.AddWithValue("@sid", sessionId);
                    cmd.Parameters.AddWithValue("@isUser", isUser);
                    cmd.Parameters.AddWithValue("@content", content);
                    cmd.Parameters.AddWithValue("@time", DateTime.Now);
                    cmd.Parameters.AddWithValue("@files", filePaths);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 5. Xóa cuộc trò chuyện (Dùng hàm cũ cho gọn)
        public void DeleteSession(string sessionId)
        {
            db.ThucHienLenh("DELETE FROM ChatMessages WHERE SessionID = '" + sessionId + "'");
            db.ThucHienLenh("DELETE FROM ChatSessions WHERE SessionID = '" + sessionId + "'");
        }
    }
}