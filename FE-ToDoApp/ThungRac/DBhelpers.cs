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

        // lấy dữ liệu từ bảng trong db
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


        -- WEEK CATEGORY DETAIL
        SELECT
            CategoryId AS ItemId,
            CategoryName AS Title,
            'WeekCategory' AS SourceTable,
            DeletedAt
        FROM WeekCategory_detail
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
            else if (sourceTable == "WeekCategory")
                sql = "UPDATE WeekCategory_detail SET IsDeleted = 0, DeletedAt = NULL WHERE CategoryId = @id";
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
            else if (sourceTable == "WeekCategory")
            {
                sql = @"
            DELETE FROM WeekCategory_item WHERE CategoryId = @id;
            DELETE FROM WeekCategory_detail WHERE CategoryId = @id;
        ";
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
            else if (sourceTable == "WeekCategory")
                sql = "UPDATE WeekCategory_detail SET IsDeleted = 1, DeletedAt = GETDATE() WHERE CategoryId = @id";
            else
                return 0;

            return Execute(sql, new SqlParameter("@id", itemId));
        }


    }
}