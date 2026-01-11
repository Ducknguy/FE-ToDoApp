using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using FE_ToDoApp.WeekList.Models;

namespace FE_ToDoApp.WeekList.Data
{
    /// <summary>
    /// Repository pattern cho WeekCategory
    /// </summary>
    public class WeekCategoryRepository
    {
        private readonly string _connectionString;

        public WeekCategoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// L?y t?t c? categories ?ang active
        /// </summary>
        public List<WeekCategory> GetAll()
        {
            var categories = new List<WeekCategory>();
            
            string sql = @"
                SELECT CategoryId, CategoryName, OrderIndex, IsActive
                FROM WeekCategory
                WHERE IsActive = 1
                ORDER BY OrderIndex, CategoryId";

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
                            CategoryId = Convert.ToInt32(reader["CategoryId"]),
                            CategoryName = reader.GetString(reader.GetOrdinal("CategoryName")),
                            OrderIndex = Convert.ToInt32(reader["OrderIndex"]),
                            IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))
                        });
                    }
                }
            }

            return categories;
        }

        /// <summary>
        /// L?y category theo ID
        /// </summary>
        public WeekCategory? GetById(int categoryId)
        {
            string sql = @"
                SELECT CategoryId, CategoryName, OrderIndex, IsActive
                FROM WeekCategory
                WHERE CategoryId = @CategoryId";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new WeekCategory
                            {
                                CategoryId = Convert.ToInt32(reader["CategoryId"]),
                                CategoryName = reader.GetString(reader.GetOrdinal("CategoryName")),
                                OrderIndex = Convert.ToInt32(reader["OrderIndex"]),
                                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))
                            };
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Thêm category m?i
        /// </summary>
        public int Insert(string categoryName)
        {
            string sql = @"
                DECLARE @MaxOrder INT;
                SELECT @MaxOrder = ISNULL(MAX(OrderIndex), -1) FROM WeekCategory;
                
                INSERT INTO WeekCategory (CategoryName, OrderIndex, IsActive)
                VALUES (@CategoryName, @MaxOrder + 1, 1);
                
                SELECT SCOPE_IDENTITY();";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// C?p nh?t tên category
        /// </summary>
        public void Update(int categoryId, string categoryName)
        {
            string sql = @"
                UPDATE WeekCategory
                SET CategoryName = @CategoryName
                WHERE CategoryId = @CategoryId";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Xóa m?m category (set IsActive = 0)
        /// </summary>
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
