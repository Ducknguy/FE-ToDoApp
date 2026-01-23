using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using FE_ToDoApp.Database; // Sử dụng SQLiteHelper

namespace FE_ToDoApp.DAO
{
    public class ChatDAO
    {
        // 1. LẤY DANH SÁCH SESSION (Giữ nguyên)
        public List<ChatSession> GetSessions(int userId)
        {
            List<ChatSession> list = new List<ChatSession>();
            try
            {
                string sql = "SELECT * FROM ChatSessions WHERE UserId = @uid ORDER BY CreatedAt DESC";
                DataTable dt = SQLiteHelper.ExecuteQuery(sql, new SQLiteParameter("@uid", userId));

                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new ChatSession
                    {
                        Id = Convert.ToInt32(row["SessionID"]),
                        UserId = Convert.ToInt32(row["UserId"]),
                        Title = row["Title"].ToString(),
                        CreatedAt = Convert.ToDateTime(row["CreatedAt"])
                    });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi GetSessions: " + ex.Message);
            }
            return list;
        }

        // 2. LẤY TIN NHẮN (Giữ nguyên)
        public List<ChatMessage> GetMessages(int sessionId)
        {
            List<ChatMessage> list = new List<ChatMessage>();
            try
            {
                string sql = "SELECT * FROM ChatMessages WHERE SessionID = @id ORDER BY ThoiGian ASC";
                DataTable dt = SQLiteHelper.ExecuteQuery(sql, new SQLiteParameter("@id", sessionId));

                foreach (DataRow row in dt.Rows)
                {
                    string fileStr = row["Files"] == DBNull.Value ? "" : row["Files"].ToString();
                    List<string> fileList = string.IsNullOrEmpty(fileStr)
                                            ? new List<string>()
                                            : new List<string>(fileStr.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries));

                    list.Add(new ChatMessage
                    {
                        IsUser = Convert.ToInt32(row["IsUser"]) == 1,
                        Content = row["Content"].ToString(),
                        Time = Convert.ToDateTime(row["ThoiGian"]),
                        Files = fileList
                    });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi GetMessages: " + ex.Message);
            }
            return list;
        }

        // 3. LƯU SESSION MỚI (Giữ nguyên)
        public void SaveSession(ChatSession session)
        {
            try
            {
                string sql = @"
                    INSERT INTO ChatSessions (UserId, Title, CreatedAt)
                    VALUES (@uid, @title, @time);
                    SELECT last_insert_rowid();
                ";

                object result = SQLiteHelper.ExecuteScalar(sql,
                    new SQLiteParameter("@uid", session.UserId),
                    new SQLiteParameter("@title", session.Title),
                    new SQLiteParameter("@time", session.CreatedAt));

                if (result != null)
                {
                    session.Id = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi SaveSession: " + ex.Message);
            }
        }

        // 4. LƯU TIN NHẮN (Giữ nguyên)
        public void SaveMessage(int sessionId, ChatMessage msg)
        {
            try
            {
                string sql = @"
                    INSERT INTO ChatMessages (SessionID, IsUser, Content, ThoiGian, Files)
                    VALUES (@sid, @isUser, @content, @time, @files)
                ";

                string filesValue = (msg.Files != null && msg.Files.Count > 0)
                                    ? string.Join("|", msg.Files)
                                    : null;

                SQLiteHelper.ExecuteNonQuery(sql,
                    new SQLiteParameter("@sid", sessionId),
                    new SQLiteParameter("@isUser", msg.IsUser ? 1 : 0),
                    new SQLiteParameter("@content", msg.Content),
                    new SQLiteParameter("@time", msg.Time),
                    new SQLiteParameter("@files", filesValue));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi SaveMessage: " + ex.Message);
            }
        }

        // 5. XÓA SESSION (Giữ nguyên)
        public void DeleteSession(int sessionId, int userId)
        {
            try
            {
                string sql = "DELETE FROM ChatSessions WHERE SessionID = @id AND UserId = @uid";
                SQLiteHelper.ExecuteNonQuery(sql,
                    new SQLiteParameter("@id", sessionId),
                    new SQLiteParameter("@uid", userId));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi DeleteSession: " + ex.Message);
            }
        }

        // 🔥 PHẦN QUAN TRỌNG: DẠY BOT TÍNH NGÀY THỨ 2, 3, 4... 🔥
        public string GetFullDatabaseSchema()
        {
            try
            {
                string sql = "SELECT sql FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%';";
                System.Data.DataTable dt = FE_ToDoApp.Database.SQLiteHelper.ExecuteQuery(sql);

                string schema = "CẤU TRÚC DATABASE HIỆN TẠI:\n";
                foreach (System.Data.DataRow row in dt.Rows)
                {
                    if (row["sql"] != DBNull.Value)
                        schema += row["sql"].ToString() + ";\n\n";
                }

                // 👇 CẬP NHẬT HƯỚNG DẪN MỚI TẠI ĐÂY 👇
                schema += @"
                --- HƯỚNG DẪN NGHIỆP VỤ (ĐỌC KỸ ĐỂ TÍNH NGÀY) ---
                UserId = 1.

                1. KHI USER NÓI: 'Tạo tuần mới', 'Tạo lịch tuần này' (Create Week)
                   ✅ SQL MẪU:
                   INSERT INTO WeekCategory_detail (UserId, CategoryName, WeekStartDate, WeekEndDate, IsActive, IsDeleted)
                   VALUES (
                       1, 
                       'Tuần ' || strftime('%d/%m', date('now', 'weekday 0', '-6 days')) || ' - ' || strftime('%d/%m', date('now', 'weekday 0')), 
                       date('now', 'weekday 0', '-6 days'), -- Luôn là Thứ 2 tuần này
                       date('now', 'weekday 0'),            -- Luôn là Chủ nhật tuần này
                       1, 
                       0
                   );

                2. KHI USER NÓI: 'Thêm việc [ABC] vào [THỨ X]' (Add task to specific day)
                   👉 Bạn phải xác định ngày chính xác của 'Thứ X' trong tuần hiện tại.
                   👉 Sử dụng cú pháp SQLite: date('now', 'weekday 0', '-6 days', '+N days') để tính.
                      - Thứ 2: date('now', 'weekday 0', '-6 days')
                      - Thứ 3: date('now', 'weekday 0', '-5 days')
                      - Thứ 4: date('now', 'weekday 0', '-4 days')
                      - Thứ 5: date('now', 'weekday 0', '-3 days')
                      - Thứ 6: date('now', 'weekday 0', '-2 days')
                      - Thứ 7: date('now', 'weekday 0', '-1 day')
                      - Chủ Nhật: date('now', 'weekday 0')

                   ✅ CÂU SQL MẪU (Ví dụ thêm vào THỨ 6):
                   INSERT INTO WeekCategory_item (CategoryId, Title, Description, StartDate, Status, CreatedAt)
                   VALUES (
                       -- Lấy tuần mới nhất
                       (SELECT CategoryId FROM WeekCategory_detail WHERE IsDeleted=0 ORDER BY CategoryId DESC LIMIT 1),
                       
                       'Nội dung công việc', 
                       '',
                       
                       -- 🔥 AI HÃY THAY THẾ DÒNG DƯỚI BẰNG CÔNG THỨC NGÀY TƯƠNG ỨNG Ở TRÊN
                       datetime('now', 'weekday 0', '-2 days'), -- Ví dụ này là Thứ 6
                       
                       0,
                       datetime('now')
                   );
                   
                   ⚠️ QUAN TRỌNG: 
                   - Nếu User nói 'Hôm nay', dùng datetime('now').
                   - Nếu User nói 'Ngày mai', dùng datetime('now', '+1 day').
                   - Nếu User nói Thứ mấy, hãy chọn đúng công thức ở trên.
                ";

                return schema;
            }
            catch (Exception ex)
            {
                return "Lỗi schema: " + ex.Message;
            }
        }

        // Hàm thực thi SQL (đã fix lỗi báo ảo)
        public string ExecuteDynamicSQL(string sqlQuery)
        {
            try
            {
                string cleanSQL = sqlQuery.Trim();

                if (cleanSQL.ToUpper().StartsWith("SELECT"))
                {
                    DataTable dt = SQLiteHelper.ExecuteQuery(cleanSQL);
                    if (dt.Rows.Count == 0) return "Kết quả truy vấn rỗng.";

                    string result = "";
                    foreach (DataColumn col in dt.Columns) result += col.ColumnName + " | ";
                    result += "\n" + new string('-', result.Length) + "\n";

                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            if (item is DateTime d) result += d.ToString("dd/MM/yyyy HH:mm") + " | ";
                            else result += item.ToString() + " | ";
                        }
                        result += "\n";
                    }
                    return result;
                }
                else
                {
                    int rowsAffected = SQLiteHelper.ExecuteNonQuery(cleanSQL);
                    if (rowsAffected > 0)
                        return $"✅ THÀNH CÔNG: Đã thêm/sửa {rowsAffected} mục.";
                    else
                        return "⚠️ LỆNH KHÔNG CÓ TÁC DỤNG (Có thể do tuần chưa được tạo).";
                }
            }
            catch (Exception ex)
            {
                return "❌ Lỗi thực thi SQL: " + ex.Message + "\nCâu lệnh: " + sqlQuery;
            }
        }
    }
}