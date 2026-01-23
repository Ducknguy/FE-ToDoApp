using System;
using System.Data.SQLite;
using System.Threading.Tasks;
using FE_ToDoApp.Database;

namespace FE_ToDoApp.Services
{
    public class StreakService
    {
        private static System.Threading.Timer? _timer;
        private static bool _isRunning = false;

        public static void Start()
        {
            if (_isRunning) return;
            _isRunning = true;

            // Tính th?i gian ??n 00:00 ngày mai
            DateTime now = DateTime.Now;
            DateTime tomorrow = now.Date.AddDays(1);
            TimeSpan timeUntilMidnight = tomorrow - now;

            // Ch?y l?n ??u vào 00:00 ngày mai
            _timer = new System.Threading.Timer(
                CheckAndResetStreaks,
                null,
                timeUntilMidnight,
                TimeSpan.FromDays(1) // L?p l?i m?i 24h
            );
        }

        public static void Stop()
        {
            _timer?.Dispose();
            _timer = null;
            _isRunning = false;
        }

        private static void CheckAndResetStreaks(object? state)
        {
            try
            {
                DateTime today = DateTime.Today;
                DateTime yesterday = today.AddDays(-1);

                // Reset streak cho các todo KHÔNG ???c hoàn thành hôm qua
                SQLiteHelper.ExecuteNonQuery(@"
                    UPDATE Todo_List_Detail
                    SET CurrentStreak = 0,
                        updated_at = datetime('now')
                    WHERE (IsDeleted = 0 OR IsDeleted IS NULL)
                      AND (
                          LastCompletedDate IS NULL 
                          OR date(LastCompletedDate) < date(@yesterday)
                      )",
                    new SQLiteParameter("@yesterday", yesterday));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"StreakService Error: {ex.Message}");
            }
        }

        // Manual check (có th? g?i khi app kh?i ??ng)
        public static void CheckStreaksOnStartup()
        {
            CheckAndResetStreaks(null);
        }
    }
}
