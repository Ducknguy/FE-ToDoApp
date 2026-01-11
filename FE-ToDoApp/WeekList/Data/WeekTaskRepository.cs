using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using FE_ToDoApp.WeekList.Models;

namespace FE_ToDoApp.WeekList.Data
{
    /// <summary>
    /// Repository pattern cho WeekTask
    /// </summary>
    public class WeekTaskRepository
    {
        private readonly string _connectionString;

        public WeekTaskRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Load t?t c? task c?a 1 category trong tu?n
        /// </summary>
        public List<WeekTask> GetByCategory(int categoryId, DateTime weekStart)
        {
            var tasks = new List<WeekTask>();

            string sql = @"
                SELECT wt.TaskId, wt.CategoryId, wt.WeekPlanId, wt.DayOfWeek, 
                       wt.Title, wt.IsDone, wt.OrderIndex
                FROM WeekPlanTask wt
                INNER JOIN WeekPlan wp ON wt.WeekPlanId = wp.WeekPlanId
                WHERE wt.CategoryId = @CategoryId 
                  AND wp.WeekStartDate = @WeekStart
                ORDER BY wt.DayOfWeek, wt.OrderIndex, wt.TaskId";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    cmd.Parameters.AddWithValue("@WeekStart", weekStart.Date);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tasks.Add(new WeekTask
                            {
                                TaskId = Convert.ToInt32(reader["TaskId"]),
                                CategoryId = Convert.ToInt32(reader["CategoryId"]),
                                WeekPlanId = Convert.ToInt32(reader["WeekPlanId"]),
                                DayOfWeek = Convert.ToInt32(reader["DayOfWeek"]),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                IsDone = reader.GetBoolean(reader.GetOrdinal("IsDone")),
                                OrderIndex = Convert.ToInt32(reader["OrderIndex"])
                            });
                        }
                    }
                }
            }

            return tasks;
        }

        /// <summary>
        /// Thêm task m?i
        /// </summary>
        public int Insert(int categoryId, DateTime weekStart, int dayOfWeek, string title)
        {
            string sql = @"
                DECLARE @WeekPlanId INT;
                
                -- Tìm ho?c t?o WeekPlan
                SELECT @WeekPlanId = WeekPlanId FROM WeekPlan WHERE WeekStartDate = @WeekStart;
                
                IF @WeekPlanId IS NULL
                BEGIN
                    INSERT INTO WeekPlan (WeekStartDate) VALUES (@WeekStart);
                    SET @WeekPlanId = SCOPE_IDENTITY();
                END
                
                -- L?y OrderIndex l?n nh?t
                DECLARE @MaxOrder INT;
                SELECT @MaxOrder = ISNULL(MAX(OrderIndex), -1) 
                FROM WeekPlanTask 
                WHERE WeekPlanId = @WeekPlanId 
                  AND CategoryId = @CategoryId 
                  AND DayOfWeek = @DayOfWeek;
                
                -- Insert task m?i
                INSERT INTO WeekPlanTask (WeekPlanId, CategoryId, DayOfWeek, Title, IsDone, OrderIndex)
                VALUES (@WeekPlanId, @CategoryId, @DayOfWeek, @Title, 0, @MaxOrder + 1);
                
                SELECT SCOPE_IDENTITY();";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    cmd.Parameters.AddWithValue("@WeekStart", weekStart.Date);
                    cmd.Parameters.AddWithValue("@DayOfWeek", dayOfWeek);
                    cmd.Parameters.AddWithValue("@Title", title);
                    
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// C?p nh?t task
        /// </summary>
        public void Update(int taskId, string title, int dayOfWeek)
        {
            string sql = @"
                UPDATE WeekPlanTask 
                SET Title = @Title, DayOfWeek = @DayOfWeek
                WHERE TaskId = @TaskId";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TaskId", taskId);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@DayOfWeek", dayOfWeek);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// C?p nh?t tr?ng thái IsDone
        /// </summary>
        public void UpdateStatus(int taskId, bool isDone)
        {
            string sql = @"
                UPDATE WeekPlanTask 
                SET IsDone = @IsDone 
                WHERE TaskId = @TaskId";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TaskId", taskId);
                    cmd.Parameters.AddWithValue("@IsDone", isDone);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Xóa task
        /// </summary>
        public void Delete(int taskId)
        {
            string sql = "DELETE FROM WeekPlanTask WHERE TaskId = @TaskId";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TaskId", taskId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
