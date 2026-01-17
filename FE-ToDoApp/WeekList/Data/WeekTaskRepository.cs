using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using FE_ToDoApp.WeekList.Models;

namespace FE_ToDoApp.WeekList.Data
{

    public class WeekTaskRepository
    {
        private readonly string _connectionString;

        public WeekTaskRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<WeekTask> GetByCategory(int categoryId, DateTime weekStart)
        {
            var tasks = new List<WeekTask>();

            DateTime weekEnd = weekStart.AddDays(6);
            string categoryName = GetCategoryNameById(categoryId);
            if (string.IsNullOrEmpty(categoryName))
            {
                return tasks;
            }

            string sql = @"
                SELECT 
                    Id AS TaskId,
                    Title,
                    EndDate,
                    ISNULL(Status, 'Pending') AS Status
                FROM Calendar
                WHERE ISNULL(Category, 'General') = @CategoryName
                  AND EndDate >= @WeekStart 
                  AND EndDate <= @WeekEnd
                  AND (IsDeleted = 0 OR IsDeleted IS NULL)
                ORDER BY EndDate, Id";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                    cmd.Parameters.AddWithValue("@WeekStart", weekStart.Date);
                    cmd.Parameters.AddWithValue("@WeekEnd", weekEnd.Date.AddHours(23).AddMinutes(59).AddSeconds(59));

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime endDate = Convert.ToDateTime(reader["EndDate"]);
                            int dayOfWeek = GetDayOfWeekNumber(endDate);

                            tasks.Add(new WeekTask
                            {
                                TaskId = Convert.ToInt32(reader["TaskId"]),
                                CategoryId = categoryId,
                                WeekPlanId = 0,
                                DayOfWeek = dayOfWeek,
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                IsDone = reader.GetString(reader.GetOrdinal("Status")).Equals("Done", StringComparison.OrdinalIgnoreCase),
                                OrderIndex = 0
                            });
                        }
                    }
                }
            }

            return tasks;
        }

        public int Insert(int categoryId, DateTime weekStart, int dayOfWeek, string title)
        {

            string categoryName = GetCategoryNameById(categoryId);
            if (string.IsNullOrEmpty(categoryName))
            {
                categoryName = "General";
            }

            DateTime endDate = weekStart.AddDays(dayOfWeek - 1);

            DateTime startDate = endDate;

            string sql = @"
                INSERT INTO Calendar (UserId, Title, Description, StartDate, EndDate, Status, Category, IsDeleted, CreatedAt, UpdatedAt)
                VALUES (1, @Title, '', @StartDate, @EndDate, 'Pending', @Category, 0, GETDATE(), GETDATE());
                
                SELECT SCOPE_IDENTITY();";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    cmd.Parameters.AddWithValue("@Category", categoryName);
                    
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void Update(int taskId, string title, int dayOfWeek)
        {
            DateTime currentEndDate = GetTaskEndDate(taskId);
            if (currentEndDate == DateTime.MinValue)
            {
                throw new Exception("Không tìm thấy task");
            }

            DateTime weekStart = GetMonday(currentEndDate);
            DateTime newEndDate = weekStart.AddDays(dayOfWeek - 1);

            string sql = @"
                UPDATE Calendar 
                SET Title = @Title, EndDate = @EndDate, UpdatedAt = GETDATE()
                WHERE Id = @TaskId";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TaskId", taskId);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@EndDate", newEndDate);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateStatus(int taskId, bool isDone)
        {
            string sql = @"
                UPDATE Calendar 
                SET Status = @Status 
                WHERE Id = @TaskId";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TaskId", taskId);
                    cmd.Parameters.AddWithValue("@Status", isDone ? "Done" : "Pending");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int taskId)
        {
            string sql = @"
                UPDATE Calendar 
                SET IsDeleted = 1, DeletedAt = GETDATE() 
                WHERE Id = @TaskId";

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
        private string GetCategoryNameById(int categoryId)
        {
            string sql = @"
                SELECT CategoryName
                FROM WeekCategory
                WHERE CategoryId = @CategoryId AND IsActive = 1";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return result.ToString();
                    }
                }
            }

            return string.Empty;
        }

        private DateTime GetTaskEndDate(int taskId)
        {
            string sql = "SELECT EndDate FROM Calendar WHERE Id = @TaskId";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TaskId", taskId);
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDateTime(result);
                    }
                }
            }

            return DateTime.MinValue;
        }

        private int GetDayOfWeekNumber(DateTime date)
        {
            int dayOfWeek = (int)date.DayOfWeek;
            return dayOfWeek == 0 ? 7 : dayOfWeek;
        }

        private DateTime GetMonday(DateTime date)
        {
            int daysFromMonday = ((int)date.DayOfWeek - 1 + 7) % 7;
            return date.Date.AddDays(-daysFromMonday);
        }
    }
}
