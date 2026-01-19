using System;
using System.Collections.Generic;
using System.Data.SQLite;
using FE_ToDoApp.WeekList.Models;
using FE_ToDoApp.Database;

namespace FE_ToDoApp.WeekList.Data
{

    public class WeekCategoryRepository
    {
        public List<WeekCategory> GetAll()
        {
            var categories = new List<WeekCategory>();
            
            string sql = @"
                SELECT CategoryId, CategoryName, WeekStartDate, WeekEndDate, OrderIndex, IsActive
                FROM WeekCategory_detail
                WHERE IsDeleted = 0
                ORDER BY WeekStartDate DESC, OrderIndex, CategoryName";

            using (var conn = SQLiteHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categories.Add(new WeekCategory
                        {
                            CategoryId = reader.GetInt32(0),
                            CategoryName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                            WeekStartDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2),
                            WeekEndDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3),
                            OrderIndex = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                            IsActive = reader.IsDBNull(5) ? true : reader.GetInt32(5) == 1
                        });
                    }
                }
            }

            return categories;
        }

        public int Insert(string categoryName, DateTime weekStartDate, DateTime weekEndDate)
        {
            string sql = @"
                INSERT INTO WeekCategory_detail (UserId, CategoryName, WeekStartDate, WeekEndDate, OrderIndex, IsActive, IsDeleted)
                VALUES (@UserId, @CategoryName, @WeekStartDate, @WeekEndDate, @OrderIndex, @IsActive, 0);
                
                SELECT last_insert_rowid();";

            using (var conn = SQLiteHelper.GetConnection())
            {
                conn.Open();
                
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", 1);
                    cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                    cmd.Parameters.AddWithValue("@WeekStartDate", weekStartDate);
                    cmd.Parameters.AddWithValue("@WeekEndDate", weekEndDate);
                    cmd.Parameters.AddWithValue("@OrderIndex", 0);
                    cmd.Parameters.AddWithValue("@IsActive", 1);
                    
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

     
        public void Update(int categoryId, string categoryName, DateTime weekStartDate, DateTime weekEndDate)
        {
            string sql = @"
                UPDATE WeekCategory_detail
                SET CategoryName = @CategoryName,
                    WeekStartDate = @WeekStartDate,
                    WeekEndDate = @WeekEndDate
                WHERE CategoryId = @CategoryId";

            using (var conn = SQLiteHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                    cmd.Parameters.AddWithValue("@WeekStartDate", weekStartDate);
                    cmd.Parameters.AddWithValue("@WeekEndDate", weekEndDate);
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int categoryId)
        {
            string sql = @"
                UPDATE WeekCategory_detail
                SET IsDeleted = 1,
                    DeletedAt = datetime('now')
                WHERE CategoryId = @CategoryId";

            using (var conn = SQLiteHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
