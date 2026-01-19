using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using FE_ToDoApp.WeekList.Models;

namespace FE_ToDoApp.WeekList.Data
{

    public class WeekCategoryRepository
    {
        private readonly string _connectionString;

        public WeekCategoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<WeekCategory> GetAll()
        {
            var categories = new List<WeekCategory>();
            
            string sql = @"
                SELECT CategoryId, CategoryName, WeekStartDate, WeekEndDate, OrderIndex, IsActive
                FROM WeekCategory_detail
                WHERE IsDeleted = 0
                ORDER BY WeekStartDate DESC, OrderIndex, CategoryName";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
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
                            IsActive = reader.IsDBNull(5) ? true : reader.GetBoolean(5)
                        });
                    }
                }
            }

            return categories;
        }


        //public WeekCategory? GetById(int categoryId)
        //{
        //    string sql = @"
        //        SELECT CategoryId, CategoryName, WeekStartDate, WeekEndDate, OrderIndex, IsActive
        //        FROM WeekCategory_detail
        //        WHERE CategoryId = @CategoryId AND IsDeleted = 0";

        //    using (var conn = new SqlConnection(_connectionString))
        //    {
        //        conn.Open();
        //        using (var cmd = new SqlCommand(sql, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    
        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    return new WeekCategory
        //                    {
        //                        CategoryId = reader.GetInt32(0),
        //                        CategoryName = reader.GetString(1),
        //                        WeekStartDate = reader.GetDateTime(2),
        //                        WeekEndDate = reader.GetDateTime(3),
        //                        OrderIndex = reader.GetInt32(4),
        //                        IsActive = reader.GetBoolean(5)
        //                    };
        //                }
        //            }
        //        }
        //    }

        //    return null;
        //}

        public int Insert(string categoryName, DateTime weekStartDate, DateTime weekEndDate)
        {
            string sql = @"
                INSERT INTO WeekCategory_detail (UserId, CategoryName, WeekStartDate, WeekEndDate, OrderIndex, IsActive, IsDeleted)
                VALUES (@UserId, @CategoryName, @WeekStartDate, @WeekEndDate, @OrderIndex, @IsActive, 0);
                
                SELECT SCOPE_IDENTITY();";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", 1);
                    cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                    cmd.Parameters.AddWithValue("@WeekStartDate", weekStartDate);
                    cmd.Parameters.AddWithValue("@WeekEndDate", weekEndDate);
                    cmd.Parameters.AddWithValue("@OrderIndex", 0);
                    cmd.Parameters.AddWithValue("@IsActive", true);
                    
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

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
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
                    DeletedAt = GETDATE()
                WHERE CategoryId = @CategoryId";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
