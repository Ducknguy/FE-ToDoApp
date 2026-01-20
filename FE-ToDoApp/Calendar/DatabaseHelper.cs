using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FE_ToDoApp.Calendar
{
    public static class DatabaseHelper
    {
        private static string connectionString = @"Data Source=Money\SQLEXPRESS;Initial Catalog=ToDoApp;Integrated Security=True;Encrypt=False";

        public static List<TaskItem> GetTasksByMonth(int month, int year)
        {
            List<TaskItem> list = new List<TaskItem>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT Id, Title, Description, StartDate, Status FROM dbo.Calendar WHERE MONTH(StartDate) = @m AND YEAR(StartDate) = @y";

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
                                item.Title = reader["Title"] != DBNull.Value ? reader["Title"].ToString() : "";
                                item.Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : "";
                                item.StartDate = reader["StartDate"] != DBNull.Value ? Convert.ToDateTime(reader["StartDate"]) : DateTime.MinValue;
                                item.Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : "Pending";

                                list.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return list;
        }
    }
}