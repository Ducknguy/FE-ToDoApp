using System;
using System.Data.SQLite;
using System.IO;

namespace FE_ToDoApp.login
{
    public class DatabaseHelper
    {
        public static SQLiteConnection GetConnection()
        {
            return FE_ToDoApp.Database.SQLiteHelper.GetConnection();
        }
    }
}
