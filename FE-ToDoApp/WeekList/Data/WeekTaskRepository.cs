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

            string sql = @"
                SELECT 
                    Id_weekly AS TaskId,
                    Title,
                    StartDate,
                    Status
                FROM WeekCategory_item
                WHERE CategoryId = @CategoryId
                  AND StartDate >= @WeekStart 
                  AND StartDate <= @WeekEnd
                ORDER BY StartDate, Id_weekly";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    cmd.Parameters.AddWithValue("@WeekStart", weekStart.Date);
                    cmd.Parameters.AddWithValue("@WeekEnd", weekEnd.Date.AddHours(23).AddMinutes(59).AddSeconds(59));

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime startDate = Convert.ToDateTime(reader["StartDate"]);
                            int dayOfWeek = GetDayOfWeekNumber(startDate);

                            tasks.Add(new WeekTask
                            {
                                TaskId = Convert.ToInt32(reader["TaskId"]),
                                CategoryId = categoryId,
                                WeekPlanId = 0,
                                DayOfWeek = dayOfWeek,
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                IsDone = reader.GetBoolean(reader.GetOrdinal("Status")),
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
            DateTime startDate = weekStart.AddDays(dayOfWeek - 1);

            string sql = @"
                INSERT INTO WeekCategory_item (CategoryId, Title, Description, StartDate, Status, CreatedAt)
                VALUES (@CategoryId, @Title, '', @StartDate, 0, GETDATE());
                
                SELECT SCOPE_IDENTITY();";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void Update(int taskId, string title, int dayOfWeek)
        {
            DateTime currentStartDate = GetTaskStartDate(taskId);
            if (currentStartDate == DateTime.MinValue)
            {
                throw new Exception("Không tìm thấy task");
            }

            DateTime weekStart = GetMonday(currentStartDate);
            DateTime newStartDate = weekStart.AddDays(dayOfWeek - 1);

            string sql = @"
                UPDATE WeekCategory_item 
                SET Title = @Title, StartDate = @StartDate, UpdatedAt = GETDATE()
                WHERE Id_weekly = @TaskId";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TaskId", taskId);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@StartDate", newStartDate);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateStatus(int taskId, bool isDone)
        {
            string sql = @"
                UPDATE WeekCategory_item 
                SET Status = @Status 
                WHERE Id_weekly = @TaskId";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TaskId", taskId);
                    cmd.Parameters.AddWithValue("@Status", isDone);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int taskId)
        {
            string sql = @"
                DELETE FROM WeekCategory_item 
                WHERE Id_weekly = @TaskId";

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

        private DateTime GetTaskStartDate(int taskId)
        {
            string sql = "SELECT StartDate FROM WeekCategory_item WHERE Id_weekly = @TaskId";

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
