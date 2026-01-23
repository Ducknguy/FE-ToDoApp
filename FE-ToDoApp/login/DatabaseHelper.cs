using System;
using System.Data.SQLite;
using System.IO;

namespace FE_ToDoApp.login
{
    public class DatabaseHelper
    {
        private static string strConn = $"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ToDoApp.db")};Version=3;";

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(strConn);
        }
    }
}