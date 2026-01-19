using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FE_ToDoApp.Calendar
{
    public static class DatabaseHelper
    {
        // Chỉnh lại connection string của bạn nếu cần
        private static string connectionString = @"Data Source=LAPTOP-HJ0H2N4I;Initial Catalog=ToDoApp;Integrated Security=True";

        public static List<TaskItem> GetTasksByMonth(int month, int year)
        {
            List<TaskItem> list = new List<TaskItem>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Query sử dụng tên cột chính xác từ ảnh DB bạn gửi: WeekStartDate
                    string sql = @"SELECT CategoryId, CategoryName, WeekStartDate 
                                   FROM WeekCategory 
                                   WHERE MONTH(WeekStartDate) = @m AND YEAR(WeekStartDate) = @y";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@m", month);
                        cmd.Parameters.AddWithValue("@y", year);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TaskItem item = new TaskItem();
                                item.Id = Convert.ToInt32(reader["CategoryId"]);
                                item.Title = reader["CategoryName"] != DBNull.Value ? reader["CategoryName"].ToString() : "";
                                // Map cột WeekStartDate vào thuộc tính StartDate
                                item.StartDate = reader["WeekStartDate"] != DBNull.Value ? Convert.ToDateTime(reader["WeekStartDate"]) : DateTime.MinValue;

                                list.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Database: " + ex.Message);
                }
            }
            return list;
        }
    }
}