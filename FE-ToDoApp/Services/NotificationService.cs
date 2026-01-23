using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using FE_ToDoApp.Database;

namespace FE_ToDoApp.Services
{
    public static class NotificationService
    {
        private static NotifyIcon _notifyIcon;
        
        public static void Initialize(NotifyIcon notifyIcon)
        {
            _notifyIcon = notifyIcon;
        }
        
        public static void CheckAndSendNotifications()
        {
            try
            {
                // 1. Check TODO ITEMS
                var todoItems = SQLiteHelper.ExecuteQuery(@"
                    SELECT 
                        i.id_item, 
                        i.item_detail, 
                        i.ReminderTime,
                        t.title as todo_title
                    FROM Todo_List_Item i
                    INNER JOIN Todo_List_Detail t ON i.id_todo = t.id_todo
                    WHERE i.ReminderTime IS NOT NULL 
                      AND i.ReminderTime <= datetime('now') 
                      AND i.ReminderTime >= datetime('now', '-1 minute')
                      AND (t.IsDeleted = 0 OR t.IsDeleted IS NULL)
                ");
                
                foreach (DataRow row in todoItems.Rows)
                {
                    string itemDetail = row["item_detail"].ToString();
                    string todoTitle = row["todo_title"].ToString();
                    int itemId = Convert.ToInt32(row["id_item"]);
                    
                    ShowNotification(
                        $"📋 Todo: {todoTitle}", 
                        $"⏰ {itemDetail}"
                    );
                    
                    ClearItemReminder(itemId);
                }

                // 2. Check WEEK TASKS
                var weekTasks = SQLiteHelper.ExecuteQuery(@"
                    SELECT 
                        w.Id_weekly,
                        w.Title,
                        w.ReminderTime,
                        c.CategoryName
                    FROM WeekCategory_item w
                    INNER JOIN WeekCategory_detail c ON w.CategoryId = c.CategoryId
                    WHERE w.ReminderTime IS NOT NULL 
                      AND w.ReminderTime <= datetime('now') 
                      AND w.ReminderTime >= datetime('now', '-1 minute')
                      AND (c.IsDeleted = 0 OR c.IsDeleted IS NULL)
                ");
                
                foreach (DataRow row in weekTasks.Rows)
                {
                    string taskTitle = row["Title"].ToString();
                    string categoryName = row["CategoryName"].ToString();
                    int weekId = Convert.ToInt32(row["Id_weekly"]);
                    
                    ShowNotification(
                        $"📅 Week: {categoryName}", 
                        $"⏰ {taskTitle}"
                    );
                    
                    ClearWeekReminder(weekId);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"NotificationService Error: {ex.Message}");
            }
        }
        
        private static void ShowNotification(string title, string message)
        {
            if (_notifyIcon != null)
            {
                _notifyIcon.BalloonTipTitle = title;
                _notifyIcon.BalloonTipText = message;
                _notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                _notifyIcon.ShowBalloonTip(5000);
            }
            else
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private static void ClearItemReminder(int itemId)
        {
            try
            {
                SQLiteHelper.ExecuteNonQuery(@"
                    UPDATE Todo_List_Item 
                    SET ReminderTime = NULL 
                    WHERE id_item = @id",
                    new SQLiteParameter("@id", itemId)
                );
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ClearItemReminder Error: {ex.Message}");
            }
        }

        private static void ClearWeekReminder(int weekId)
        {
            try
            {
                SQLiteHelper.ExecuteNonQuery(@"
                    UPDATE WeekCategory_item 
                    SET ReminderTime = NULL 
                    WHERE Id_weekly = @id",
                    new SQLiteParameter("@id", weekId)
                );
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ClearWeekReminder Error: {ex.Message}");
            }
        }
        
        // ===== TODO ITEM METHODS =====
        public static DateTime? GetItemReminder(int itemId)
        {
            try
            {
                var result = SQLiteHelper.ExecuteScalar(@"
                    SELECT ReminderTime 
                    FROM Todo_List_Item 
                    WHERE id_item = @id",
                    new SQLiteParameter("@id", itemId)
                );
                
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDateTime(result);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetItemReminder Error: {ex.Message}");
            }
            
            return null;
        }
        
        public static void SetItemReminder(int itemId, DateTime? reminderTime)
        {
            try
            {
                if (reminderTime.HasValue)
                {
                    SQLiteHelper.ExecuteNonQuery(@"
                        UPDATE Todo_List_Item 
                        SET ReminderTime = @reminder
                        WHERE id_item = @id",
                        new SQLiteParameter("@reminder", reminderTime.Value),
                        new SQLiteParameter("@id", itemId)
                    );
                }
                else
                {
                    SQLiteHelper.ExecuteNonQuery(@"
                        UPDATE Todo_List_Item 
                        SET ReminderTime = NULL
                        WHERE id_item = @id",
                        new SQLiteParameter("@id", itemId)
                    );
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SetItemReminder Error: {ex.Message}");
            }
        }

        // ===== WEEK TASK METHODS =====
        public static DateTime? GetWeekTaskReminder(int weekId)
        {
            try
            {
                var result = SQLiteHelper.ExecuteScalar(@"
                    SELECT ReminderTime 
                    FROM WeekCategory_item 
                    WHERE Id_weekly = @id",
                    new SQLiteParameter("@id", weekId)
                );
                
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDateTime(result);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetWeekTaskReminder Error: {ex.Message}");
            }
            
            return null;
        }
        
        public static void SetWeekTaskReminder(int weekId, DateTime? reminderTime)
        {
            try
            {
                if (reminderTime.HasValue)
                {
                    SQLiteHelper.ExecuteNonQuery(@"
                        UPDATE WeekCategory_item 
                        SET ReminderTime = @reminder, UpdatedAt = datetime('now')
                        WHERE Id_weekly = @id",
                        new SQLiteParameter("@reminder", reminderTime.Value),
                        new SQLiteParameter("@id", weekId)
                    );
                }
                else
                {
                    SQLiteHelper.ExecuteNonQuery(@"
                        UPDATE WeekCategory_item 
                        SET ReminderTime = NULL, UpdatedAt = datetime('now')
                        WHERE Id_weekly = @id",
                        new SQLiteParameter("@id", weekId)
                    );
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SetWeekTaskReminder Error: {ex.Message}");
            }
        }
    }
}
