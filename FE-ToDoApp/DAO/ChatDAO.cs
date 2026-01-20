using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FE_ToDoApp.DAO
{
    public class ChatDAO
    {
        private ConnectSQL db = new ConnectSQL();

        // 1. LẤY DANH SÁCH SESSION
        public List<ChatSession> GetSessions(int userId)
        {
            List<ChatSession> list = new List<ChatSession>();
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM ChatSessions WHERE UserId = @uid ORDER BY CreatedAt DESC";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@uid", userId);

                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        list.Add(new ChatSession
                        {
                            Id = Convert.ToInt32(rd["SessionID"]),
                            UserId = Convert.ToInt32(rd["UserId"]),
                            Title = rd["Title"].ToString(),
                            CreatedAt = Convert.ToDateTime(rd["CreatedAt"])
                        });
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải lịch sử: " + ex.Message); }

            return list;
        }


        // 2. LẤY TIN NHẮN
        public List<ChatMessage> GetMessages(int sessionId) // Nhận vào int
        {
            List<ChatMessage> list = new List<ChatMessage>();
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    // Lấy tin nhắn theo đúng thứ tự thời gian
                    string sql = "SELECT * FROM ChatMessages WHERE SessionID = @id ORDER BY ThoiGian ASC";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", sessionId);
                    SqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        // Xử lý cột Files có thể bị NULL
                        string fileStr = rd["Files"] == DBNull.Value ? "" : rd["Files"].ToString();
                        List<string> fileList = string.IsNullOrEmpty(fileStr)
                                                ? new List<string>()
                                                : new List<string>(fileStr.Split('|'));

                        list.Add(new ChatMessage
                        {
                            IsUser = Convert.ToBoolean(rd["IsUser"]),
                            Content = rd["Content"].ToString(),
                            Time = Convert.ToDateTime(rd["ThoiGian"]),
                            Files = fileList
                        });
                    }
                }
            }
            catch { }
            return list;
        }

        // 3. LƯU SESSION MỚI (FIX LỖI IDENTITY)
        public void SaveSession(ChatSession session)
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    // Dùng SCOPE_IDENTITY() để lấy ID vừa sinh ra
                    // Lưu ý: Tôi đang để UserId = 1 (Mặc định). 
                    // Sau này bạn cần thay số 1 bằng biến User đang đăng nhập.
                    string sql = @"INSERT INTO ChatSessions (UserId, Title, CreatedAt)
                                   VALUES (@UserId, @title, @time);
                                   SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@UserId", session.UserId);
                    cmd.Parameters.AddWithValue("@title", session.Title);
                    cmd.Parameters.AddWithValue("@time", session.CreatedAt);

                    // Lấy ID trả về gán ngược vào object session
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        session.Id = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo phiên chat: " + ex.Message);
            }
        }

        // 4. LƯU TIN NHẮN
        public void SaveMessage(int sessionId, ChatMessage msg)
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = @"INSERT INTO ChatMessages (SessionID, IsUser, Content, ThoiGian, Files)
                                   VALUES (@sid, @isUser, @content, @time, @files)";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@sid", sessionId);
                    cmd.Parameters.AddWithValue("@isUser", msg.IsUser);
                    cmd.Parameters.AddWithValue("@content", msg.Content);
                    cmd.Parameters.AddWithValue("@time", msg.Time);

                    // Kiểm tra nếu có file thì nối chuỗi, nếu không thì lấy giá trị DBNull
                    object filesValue = (msg.Files != null && msg.Files.Count > 0)
                                        ? string.Join("|", msg.Files)
                                        : (object)DBNull.Value;

                    // Truyền object này vào tham số
                    cmd.Parameters.AddWithValue("@files", filesValue);
                    
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu tin nhắn: " + ex.Message);
            }
        }

        // 5. XÓA SESSION
        public void DeleteSession(int sessionId, int userId)
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM ChatSessions WHERE SessionID = @id AND UserId = @uid";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", sessionId);
                    cmd.Parameters.AddWithValue("@uid", userId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }

    }
}