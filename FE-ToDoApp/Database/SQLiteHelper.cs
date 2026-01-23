using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace FE_ToDoApp.Database
{
    public static class SQLiteHelper
    {
        private static string _dbFileName = "ToDoApp.db";

        private static string _dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "FE-ToDoApp",
            _dbFileName
        );

        public static string ConnectionString => $"Data Source={_dbPath};Version=3;";

        public static string DatabasePath => _dbPath;

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }

        public static void InitializeDatabase()
        {
            string dbDirectory = Path.GetDirectoryName(_dbPath);
            if (!Directory.Exists(dbDirectory))
            {
                Directory.CreateDirectory(dbDirectory);
            }

            if (!File.Exists(_dbPath))
            {
                SQLiteConnection.CreateFile(_dbPath);
                CreateTables();
            }
            else
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    MigrateStreakColumns(conn);
                    MigrateReminderColumns(conn);
                    MigrateUserColumns(conn);
                }
            }
        }

        private static void CreateTables()
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string createTablesScript = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE,
                    Password TEXT NOT NULL,
                    Email TEXT NOT NULL UNIQUE,
                    Avatar BLOB NULL,
                    CreatedAt DATETIME NOT NULL DEFAULT (datetime('now'))
                );

                CREATE TABLE IF NOT EXISTS ChatSessions (
                    SessionID INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserId INTEGER NOT NULL,
                    Title TEXT NOT NULL,
                    CreatedAt DATETIME NOT NULL DEFAULT (datetime('now')),
                    FOREIGN KEY (UserId) REFERENCES Users(Id)
                );

                CREATE TABLE IF NOT EXISTS ChatMessages (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    SessionID INTEGER NOT NULL,
                    IsUser INTEGER NOT NULL,
                    Content TEXT NOT NULL,
                    ThoiGian DATETIME NOT NULL DEFAULT (datetime('now')),
                    Files TEXT NULL,
                    FOREIGN KEY (SessionID) REFERENCES ChatSessions(SessionID) ON DELETE CASCADE
                );

                CREATE TABLE IF NOT EXISTS Todo_List_Detail (
                    id_todo INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserId INTEGER NOT NULL,
                    title TEXT NOT NULL,
                    created_at DATETIME NOT NULL DEFAULT (datetime('now')),
                    updated_at DATETIME NULL,
                    IsDeleted INTEGER NOT NULL DEFAULT 0,
                    DeletedAt DATETIME NULL,
                    CurrentStreak INTEGER NOT NULL DEFAULT 0,
                    BestStreak INTEGER NOT NULL DEFAULT 0,
                    LastCompletedDate DATETIME NULL,
                    ReminderTime DATETIME NULL,
                    FOREIGN KEY (UserId) REFERENCES Users(Id)
                );

                CREATE TABLE IF NOT EXISTS Todo_List_Item (
                    id_item INTEGER PRIMARY KEY AUTOINCREMENT,
                    id_todo INTEGER NOT NULL,
                    item_detail TEXT NOT NULL,
                    status INTEGER NULL,
                    FOREIGN KEY (id_todo) REFERENCES Todo_List_Detail(id_todo)
                );

                CREATE TABLE IF NOT EXISTS WeekCategory_detail (
                    CategoryId INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserId INTEGER NOT NULL,
                    CategoryName TEXT NULL,
                    WeekStartDate DATETIME NULL,
                    WeekEndDate DATETIME NULL,
                    OrderIndex INTEGER NULL,
                    IsActive INTEGER NULL,
                    IsDeleted INTEGER NOT NULL DEFAULT 0,
                    DeletedAt DATETIME NULL,
                    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
                );

                CREATE TABLE IF NOT EXISTS WeekCategory_item (
                    Id_weekly INTEGER PRIMARY KEY AUTOINCREMENT,
                    CategoryId INTEGER NOT NULL,
                    Title TEXT NOT NULL,
                    Description TEXT NULL,
                    StartDate DATETIME NOT NULL,
                    Status INTEGER NOT NULL DEFAULT 0,
                    CreatedAt DATETIME NOT NULL DEFAULT (datetime('now')),
                    UpdatedAt DATETIME NULL,
                    EndDate DATETIME NULL,
                    ReminderTime DATETIME NULL,
                    FOREIGN KEY (CategoryId) REFERENCES WeekCategory_detail(CategoryId) ON DELETE CASCADE
                );

                INSERT OR IGNORE INTO Users (Id, Username, Password, Email, CreatedAt) 
                VALUES (1, 'admin', 'admin', 'admin@todo.com', datetime('now'));
                ";

                using (var cmd = new SQLiteCommand(createTablesScript, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                MigrateStreakColumns(conn);
                MigrateReminderColumns(conn);
                MigrateUserColumns(conn);
            }
        }

        private static void MigrateStreakColumns(SQLiteConnection conn)
        {
            if (!ColumnExists(conn, "Todo_List_Detail", "CurrentStreak"))
            {
                try
                {
                    using (var cmd = new SQLiteCommand("ALTER TABLE Todo_List_Detail ADD COLUMN CurrentStreak INTEGER NOT NULL DEFAULT 0;", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch { }
            }

            if (!ColumnExists(conn, "Todo_List_Detail", "BestStreak"))
            {
                try
                {
                    using (var cmd = new SQLiteCommand("ALTER TABLE Todo_List_Detail ADD COLUMN BestStreak INTEGER NOT NULL DEFAULT 0;", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch { }
            }

            if (!ColumnExists(conn, "Todo_List_Detail", "LastCompletedDate"))
            {
                try
                {
                    using (var cmd = new SQLiteCommand("ALTER TABLE Todo_List_Detail ADD COLUMN LastCompletedDate DATETIME NULL;", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch { }
            }
        }

        private static void MigrateReminderColumns(SQLiteConnection conn)
        {
            if (!ColumnExists(conn, "Todo_List_Detail", "ReminderTime"))
            {
                try
                {
                    using (var cmd = new SQLiteCommand("ALTER TABLE Todo_List_Detail ADD COLUMN ReminderTime DATETIME NULL;", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch { }
            }

            if (!ColumnExists(conn, "WeekCategory_item", "ReminderTime"))
            {
                try
                {
                    using (var cmd = new SQLiteCommand("ALTER TABLE WeekCategory_item ADD COLUMN ReminderTime DATETIME NULL;", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch { }
            }
        }

        private static void MigrateUserColumns(SQLiteConnection conn)
        {
            if (!ColumnExists(conn, "Users", "Avatar"))
            {
                try
                {
                    using (var cmd = new SQLiteCommand("ALTER TABLE Users ADD COLUMN Avatar BLOB NULL;", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch { }
            }
        }

        private static bool ColumnExists(SQLiteConnection conn, string tableName, string columnName)
        {
            try
            {
                using (var cmd = new SQLiteCommand($"PRAGMA table_info({tableName})", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["name"].ToString() == columnName)
                        {
                            return true;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public static DataTable ExecuteQuery(string query, params SQLiteParameter[] parameters)
        {
            DataTable dt = new DataTable();

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }

        public static int ExecuteNonQuery(string query, params SQLiteParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string query, params SQLiteParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}