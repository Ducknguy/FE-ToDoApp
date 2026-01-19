using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace FE_ToDoApp.Database
{
    public static class SQLiteHelper
    {
        private static string _dbFileName = "ToDoApp.db";
        private static string _dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _dbFileName);
        
        public static string ConnectionString => $"Data Source={_dbPath};Version=3;";

        /// <summary>
        /// L?y connection m?i
        /// </summary>
        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }

        /// <summary>
        /// Kh?i t?o database và t?o b?ng n?u ch?a t?n t?i
        /// </summary>
        public static void InitializeDatabase()
        {
            if (!File.Exists(_dbPath))
            {
                SQLiteConnection.CreateFile(_dbPath);
                CreateTables();
            }
        }

       
        private static void CreateTables()
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string createTablesScript = @"
                -- Users Table
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE,
                    Password TEXT NOT NULL,
                    Email TEXT NOT NULL UNIQUE,
                    CreatedAt DATETIME NOT NULL DEFAULT (datetime('now'))
                );

                -- ChatSessions Table
                CREATE TABLE IF NOT EXISTS ChatSessions (
                    SessionID INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserId INTEGER NOT NULL,
                    Title TEXT NOT NULL,
                    CreatedAt DATETIME NOT NULL DEFAULT (datetime('now')),
                    FOREIGN KEY (UserId) REFERENCES Users(Id)
                );

                -- ChatMessages Table
                CREATE TABLE IF NOT EXISTS ChatMessages (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    SessionID INTEGER NOT NULL,
                    IsUser INTEGER NOT NULL,
                    Content TEXT NOT NULL,
                    ThoiGian DATETIME NOT NULL DEFAULT (datetime('now')),
                    Files TEXT NULL,
                    FOREIGN KEY (SessionID) REFERENCES ChatSessions(SessionID) ON DELETE CASCADE
                );

                -- Todo_List_Detail Table
                CREATE TABLE IF NOT EXISTS Todo_List_Detail (
                    id_todo INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserId INTEGER NOT NULL,
                    title TEXT NOT NULL,
                    created_at DATETIME NOT NULL DEFAULT (datetime('now')),
                    updated_at DATETIME NULL,
                    IsDeleted INTEGER NOT NULL DEFAULT 0,
                    DeletedAt DATETIME NULL,
                    FOREIGN KEY (UserId) REFERENCES Users(Id)
                );

                -- Todo_List_Item Table
                CREATE TABLE IF NOT EXISTS Todo_List_Item (
                    id_item INTEGER PRIMARY KEY AUTOINCREMENT,
                    id_todo INTEGER NOT NULL,
                    item_detail TEXT NOT NULL,
                    status INTEGER NULL,
                    FOREIGN KEY (id_todo) REFERENCES Todo_List_Detail(id_todo)
                );

                -- WeekCategory_detail Table
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

                -- WeekCategory_item Table
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
                    FOREIGN KEY (CategoryId) REFERENCES WeekCategory_detail(CategoryId) ON DELETE CASCADE
                );

                -- Insert default user for testing
                INSERT OR IGNORE INTO Users (Id, Username, Password, Email, CreatedAt) 
                VALUES (1, 'admin', 'admin', 'admin@todo.com', datetime('now'));
                ";

                using (var cmd = new SQLiteCommand(createTablesScript, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Execute SELECT query và tr? v? DataTable
        /// </summary>
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

        /// <summary>
        /// Execute INSERT, UPDATE, DELETE
        /// </summary>
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

        /// <summary>
        /// Execute SELECT và tr? v? giá tr? ??n
        /// </summary>
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
