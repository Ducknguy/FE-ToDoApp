using System;
using System.Data;
using System.Data.SQLite;
using FE_ToDoApp.Database;

namespace FE_ToDoApp.ThungRac
{
    public static class DB
    {
        // ✅ SQLite: KHÔNG cần ConnStr nữa, dùng chung SQLiteHelper

        public static DataTable GetData(string sql, params SQLiteParameter[] ps)
        {
            using var conn = SQLiteHelper.GetConnection();
            using var cmd = new SQLiteCommand(sql, conn);

            if (ps != null && ps.Length > 0)
                cmd.Parameters.AddRange(ps);

            using var da = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static int Execute(string sql, params SQLiteParameter[] ps)
        {
            using var conn = SQLiteHelper.GetConnection();
            using var cmd = new SQLiteCommand(sql, conn);

            if (ps != null && ps.Length > 0)
                cmd.Parameters.AddRange(ps);

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        // ✅ Lấy dữ liệu cho Thùng rác
        public static DataTable LayDuLieuThungRac()
        {
            string sql = @"
                SELECT 
                    id_todo AS ItemId,
                    title AS Title,
                    'Todo' AS SourceTable,
                    DeletedAt
                FROM Todo_List_Detail
                WHERE IsDeleted = 1

                UNION ALL

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

        // ✅ Khôi phục
        public static int KhoiPhuc(string sourceTable, int itemId)
        {
            string sql = "";

            if (sourceTable == "Todo")
                sql = "UPDATE Todo_List_Detail SET IsDeleted = 0, DeletedAt = NULL WHERE id_todo = @id";
            else if (sourceTable == "WeekCategory")
                sql = "UPDATE WeekCategory_detail SET IsDeleted = 0, DeletedAt = NULL WHERE CategoryId = @id";
            else
                return 0;

            return Execute(sql, new SQLiteParameter("@id", itemId));
        }

        // ✅ Xóa vĩnh viễn
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

            return Execute(sql, new SQLiteParameter("@id", itemId));
        }

        // ✅ Xóa mềm (đưa vào thùng rác)
        public static int XoaVaoThungRac(string sourceTable, int itemId)
        {
            string sql = "";

            if (sourceTable == "Todo")
                sql = "UPDATE Todo_List_Detail SET IsDeleted = 1, DeletedAt = datetime('now') WHERE id_todo = @id";
            else if (sourceTable == "WeekCategory")
                sql = "UPDATE WeekCategory_detail SET IsDeleted = 1, DeletedAt = datetime('now') WHERE CategoryId = @id";
            else
                return 0;

            return Execute(sql, new SQLiteParameter("@id", itemId));
        }
    }
}
