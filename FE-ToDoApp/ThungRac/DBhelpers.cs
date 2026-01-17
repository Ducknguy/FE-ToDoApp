using System;
using System.Data;
using System.Data.SqlClient;

namespace FE_ToDoApp.ThungRac
{
    public static class DB
    {
        // ⚠️ Lưu ý: sửa lại đúng tên server của bạn nếu cần
        public static string ConnStr =
            @"Data Source=LAPTOP-HJ0H2N4I;Initial Catalog=ToDoApp;Integrated Security=True;TrustServerCertificate=True";

        // --- PHẦN 1: CÁC HÀM CƠ BẢN (GIỮ NGUYÊN) ---

        public static DataTable GetData(string sql)
        {
            using SqlConnection conn = new SqlConnection(ConnStr);
            using SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static int Execute(string sql, params SqlParameter[] ps)
        {
            using SqlConnection conn = new SqlConnection(ConnStr);
            using SqlCommand cmd = new SqlCommand(sql, conn);
            if (ps != null && ps.Length > 0) cmd.Parameters.AddRange(ps);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }


        // Lấy dữ liệu gộp từ 3 bảng (Đã sửa tên bảng chuẩn theo ảnh DB)
        public static DataTable LayDuLieuThungRac()
        {
            string sql = @"
        -- TODO CHA (Todo_List_Detail)
        SELECT 
            id_todo AS ItemId,
            title AS Title,
            'Todo' AS SourceTable,
            DeletedAt
        FROM Todo_List_Detail
        WHERE IsDeleted = 1

        UNION ALL

        -- CALENDAR
        SELECT
            Id AS ItemId,
            Title AS Title,
            'Calendar' AS SourceTable,
            DeletedAt
        FROM Calendar
        WHERE IsDeleted = 1

        ORDER BY DeletedAt DESC
    ";

            return GetData(sql);
        }


        // khoio phuhc
        public static int KhoiPhuc(string sourceTable, int itemId)
        {
            string sql = "";

            if (sourceTable == "Todo")
                sql = "UPDATE Todo_List_Detail SET IsDeleted = 0, DeletedAt = NULL WHERE id_todo = @id";
            else if (sourceTable == "Calendar")
                sql = "UPDATE Calendar SET IsDeleted = 0, DeletedAt = NULL WHERE Id = @id";
            else
                return 0;

            return Execute(sql, new SqlParameter("@id", itemId));
        }


        // xoa vv
        public static int XoaVinhVien(string sourceTable, int itemId)
        {
            string sql = "";

            if (sourceTable == "Todo")
            {
                sql = @"
            DELETE FROM Todo_List_Item WHERE id_todo = @id;
            DELETE FROM Todo_List_Detail WHERE id_todo = @id;
        ";
            }
            else if (sourceTable == "Calendar")
            {
                sql = "DELETE FROM Calendar WHERE Id = @id";
            }
            else
                return 0;

            return Execute(sql, new SqlParameter("@id", itemId));
        }

        // ✅ Xóa mềm: chuyển vào Thùng rác
        public static int XoaVaoThungRac(string sourceTable, int itemId)
        {
            string sql = "";

            if (sourceTable == "Todo")
                sql = "UPDATE Todo_List_Detail SET IsDeleted = 1, DeletedAt = GETDATE() WHERE id_todo = @id";
            else if (sourceTable == "Calendar")
                sql = "UPDATE Calendar SET IsDeleted = 1, DeletedAt = GETDATE() WHERE Id = @id";
            else
                return 0;

            return Execute(sql, new SqlParameter("@id", itemId));
        }

    }
}