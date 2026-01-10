using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FE_ToDoApp.Calendar
{
    public static class DatabaseHelper
    {
        // QUAN TRỌNG: Dùng chuỗi kết nối tới database 'user' (nơi chứa bảng Task)
        private static string connectionString = @"Data Source=.;Initial Catalog=user;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public static List<TaskItem> GetTasksByMonth(int month, int year)
        {
            List<TaskItem> list = new List<TaskItem>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Lấy dữ liệu từ bảng [Task] thay vì Calendar
                    string sql = "SELECT * FROM [Task] WHERE MONTH(DueDate) = @m AND YEAR(DueDate) = @y";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@m", month);
                        cmd.Parameters.AddWithValue("@y", year);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TaskItem item = new TaskItem();
                                item.Id = Convert.ToInt32(reader["Id"]);
                                item.Title = reader["Title"].ToString();
                                // Kiểm tra null cho các cột có thể trống
                                item.Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : "";
                                item.DuaDate = Convert.ToDateTime(reader["DueDate"]);
                                item.Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : "Pending";
                                list.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi tải lịch: " + ex.Message); }
            }
            return list;
        }

        public static void AddTask(TaskItem task)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // INSERT vào bảng [Task] và KHÔNG cần UserID nữa
                    string sql = "INSERT INTO [Task] (Title, Description, DueDate, Status, Category) VALUES (@Title, @Desc, @Date, 'Pending', 'General')";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", task.Title);
                        cmd.Parameters.AddWithValue("@Desc", task.Description ?? "");
                        cmd.Parameters.AddWithValue("@Date", task.DuaDate);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi thêm việc: " + ex.Message); }
            }
        }

        public static void UpdateTask(TaskItem task)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Update bảng [Task]
                    string sql = "UPDATE [Task] SET Title = @Title, Description = @Desc, DueDate = @Date WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", task.Id);
                        cmd.Parameters.AddWithValue("@Title", task.Title);
                        cmd.Parameters.AddWithValue("@Desc", task.Description ?? "");
                        cmd.Parameters.AddWithValue("@Date", task.DuaDate);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi sửa: " + ex.Message); }
            }
        }

        public static void DeleteTask(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Delete từ bảng [Task]
                    string sql = "DELETE FROM [Task] WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
            }
        }
    }
}