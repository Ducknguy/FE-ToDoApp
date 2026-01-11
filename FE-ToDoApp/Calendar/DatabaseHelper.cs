using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FE_ToDoApp.Calendar
{
    public static class DatabaseHelper
    {
        private static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ToDoApp;Integrated Security=True";

        // Lấy danh sách
        public static List<TaskItem> GetTasksByMonth(int month, int year)
        {
            List<TaskItem> list = new List<TaskItem>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM Calendar WHERE MONTH(StartDate) = @m AND YEAR(StartDate) = @y";

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
                                item.Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : "";
                                item.StartDate = Convert.ToDateTime(reader["StartDate"]);
                                item.Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : "New";
                                list.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return list;
        }
        // Thêm 
        public static void AddTask(TaskItem task)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string sql = "INSERT INTO Calendar (UserID, Title, Description, StartDate, Status) VALUES (3, @Title, @Desc, @Start, 'New')";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", task.Title);
                        cmd.Parameters.AddWithValue("@Desc", task.Description ?? "");
                        cmd.Parameters.AddWithValue("@Start", task.StartDate);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi thêm việc: " + ex.Message); }
            }
        }

        // Cập nhật
        public static void UpdateTask(TaskItem task)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE Calendar SET Title = @Title, Description = @Desc, StartDate = @Start WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", task.Id);
                        cmd.Parameters.AddWithValue("@Title", task.Title);
                        cmd.Parameters.AddWithValue("@Desc", task.Description ?? "");
                        cmd.Parameters.AddWithValue("@Start", task.StartDate);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi sửa: " + ex.Message); }
            }
        }

        // Xóa
        public static void DeleteTask(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "DELETE FROM Calendar WHERE Id = @Id";
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