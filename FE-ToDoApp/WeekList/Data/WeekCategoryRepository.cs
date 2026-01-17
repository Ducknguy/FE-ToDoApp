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
                FROM WeekCategory
                WHERE IsActive = 1
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
                            CategoryName = reader.GetString(1),
                            WeekStartDate = reader.GetDateTime(2),
                            WeekEndDate = reader.GetDateTime(3),
                            OrderIndex = reader.GetInt32(4),
                            IsActive = reader.GetBoolean(5)
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
        //        FROM WeekCategory
        //        WHERE CategoryId = @CategoryId AND IsActive = 1";

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
            string getMaxIdSql = "SELECT ISNULL(MAX(CategoryId), 0) FROM WeekCategory";
            int newCategoryId = 1;

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                
                using (var cmd = new SqlCommand(getMaxIdSql, conn))
                {
                    var maxId = cmd.ExecuteScalar();
                    newCategoryId = (maxId == DBNull.Value ? 0 : Convert.ToInt32(maxId)) + 1;
                }

                string sql = @"
                    INSERT INTO WeekCategory (CategoryId, CategoryName, WeekStartDate, WeekEndDate, OrderIndex, IsActive)
                    VALUES (@CategoryId, @CategoryName, @WeekStartDate, @WeekEndDate, @OrderIndex, @IsActive)";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryId", newCategoryId);
                    cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                    cmd.Parameters.AddWithValue("@WeekStartDate", weekStartDate);
                    cmd.Parameters.AddWithValue("@WeekEndDate", weekEndDate);
                    cmd.Parameters.AddWithValue("@OrderIndex", 0);
                    cmd.Parameters.AddWithValue("@IsActive", true);
                    
                    cmd.ExecuteNonQuery();
                }
            }

            return newCategoryId;
        }

     
        public void Update(int categoryId, string categoryName, DateTime weekStartDate, DateTime weekEndDate)
        {
            string sql = @"
                UPDATE WeekCategory
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
                UPDATE WeekCategory
                SET IsActive = 0
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
