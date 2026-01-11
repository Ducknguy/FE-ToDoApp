using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using FE_ToDoApp.WeekList.Models;

namespace FE_ToDoApp.WeekList.Data
{
    public static class Db
    {
        // TODO: Thay connection string theo DB th?c t?
        private const string ConnectionString = "Data Source=duc;Initial Catalog=ToDoApp;Integrated Security=True;Encrypt=False";

        /// <summary>
        /// Load t?t c? task c?a tu?n b?t ??u t? weekStart (Monday)
        /// </summary>
        public static List<WeekTask> LoadWeekTasks(DateTime weekStart)
        {
            var tasks = new List<WeekTask>();

            // TODO: Thay tên b?ng và c?t theo schema th?c t?
            // Hi?n t?i gi? s?:
            // - B?ng: WeekPlanTask
            // - C?t: TaskId, DayOfWeek, Title, IsDone, OrderIndex
            // - Join v?i WeekPlan qua WeekPlanId và WeekStartDate

            string sql = @"
                SELECT wt.TaskId, wt.DayOfWeek, wt.Title, wt.IsDone, wt.OrderIndex
                FROM WeekPlanTask wt
                INNER JOIN WeekPlan wp ON wt.WeekPlanId = wp.WeekPlanId
                WHERE wp.WeekStartDate = @WeekStart
                ORDER BY wt.DayOfWeek, wt.OrderIndex, wt.TaskId";

            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@WeekStart", weekStart.Date);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tasks.Add(new WeekTask
                            {
                                TaskId = Convert.ToInt32(reader[0]),
                                DayOfWeek = Convert.ToInt32(reader[1]),
                                Title = reader.GetString(2),
                                IsDone = reader.GetBoolean(3),
                                OrderIndex = Convert.ToInt32(reader[4])
                            });
                        }
                    }
                }
            }

            return tasks;
        }

        /// <summary>
        /// C?p nh?t tr?ng thái IsDone c?a task
        /// </summary>
        public static void UpdateDone(int taskId, bool isDone)
        {
            // TODO: Thay tên b?ng và c?t
            string sql = @"
                UPDATE WeekPlanTask 
                SET IsDone = @IsDone 
                WHERE TaskId = @TaskId";

            using (var conn = new SqlConnection(ConnectionString))
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
        /// Thêm task m?i vào tu?n
        /// </summary>
        public static int InsertTask(DateTime weekStart, int dayOfWeek, string title)
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
                WHERE WeekPlanId = @WeekPlanId AND DayOfWeek = @DayOfWeek;
                
                -- Insert task m?i
                INSERT INTO WeekPlanTask (WeekPlanId, DayOfWeek, Title, IsDone, OrderIndex)
                VALUES (@WeekPlanId, @DayOfWeek, @Title, 0, @MaxOrder + 1);
                
                SELECT SCOPE_IDENTITY();";

            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@WeekStart", weekStart.Date);
                    cmd.Parameters.AddWithValue("@DayOfWeek", dayOfWeek);
                    cmd.Parameters.AddWithValue("@Title", title);
                    
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// C?p nh?t thông tin task
        /// </summary>
        public static void UpdateTask(int taskId, string title, int dayOfWeek)
        {
            string sql = @"
                UPDATE WeekPlanTask 
                SET Title = @Title, DayOfWeek = @DayOfWeek
                WHERE TaskId = @TaskId";

            using (var conn = new SqlConnection(ConnectionString))
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
        /// Xóa task
        /// </summary>
        public static void DeleteTask(int taskId)
        {
            string sql = "DELETE FROM WeekPlanTask WHERE TaskId = @TaskId";

            using (var conn = new SqlConnection(ConnectionString))
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
