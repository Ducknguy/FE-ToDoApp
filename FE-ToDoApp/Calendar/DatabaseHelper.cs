using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace FE_ToDoApp.Calendar
{
    public static class DatabaseHelper
    {
        public static List<TaskItem> GetTasksByMonth(int month, int year)
        {
            List<TaskItem> list = new List<TaskItem>();
            using (SQLiteConnection conn = FE_ToDoApp.Database.SQLiteHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT 
                                    Id_weekly, 
                                    Title, 
                                    Description, 
                                    StartDate,
                                    Status
                                   FROM WeekCategory_item 
                                   WHERE CAST(strftime('%m', StartDate) AS INTEGER) = @m 
                                   AND CAST(strftime('%Y', StartDate) AS INTEGER) = @y
                                   ORDER BY StartDate";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@m", month);
                        cmd.Parameters.AddWithValue("@y", year);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TaskItem item = new TaskItem();
                                item.Id = Convert.ToInt32(reader["Id_weekly"]);
                                item.Title = reader["Title"] != DBNull.Value ? reader["Title"].ToString() : "";
                                item.Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : "";
                                item.StartDate = reader["StartDate"] != DBNull.Value ? Convert.ToDateTime(reader["StartDate"]) : DateTime.MinValue;
                                item.Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : "0";

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