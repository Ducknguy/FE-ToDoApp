using System;
using System.IO;
using System.Windows.Forms;

namespace FE_ToDoApp.Database
{
    /// <summary>
    /// Helper class ?? backup và restore database
    /// ??c bi?t h?u ích khi dùng MSIX packaging
    /// </summary>
    public static class DatabaseBackupHelper
    {
        /// <summary>
        /// Backup database ra file ngoài
        /// </summary>
        public static bool BackupDatabase(string targetPath = null)
        {
            try
            {
                if (string.IsNullOrEmpty(targetPath))
                {
                    using (SaveFileDialog dialog = new SaveFileDialog())
                    {
                        dialog.Filter = "Database files (*.db)|*.db|All files (*.*)|*.*";
                        dialog.FileName = $"ToDoApp_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.db";
                        dialog.Title = "Ch?n n?i l?u file backup";

                        if (dialog.ShowDialog() != DialogResult.OK)
                            return false;

                        targetPath = dialog.FileName;
                    }
                }

                string sourcePath = SQLiteHelper.DatabasePath;

                if (!File.Exists(sourcePath))
                {
                    MessageBox.Show("Không tìm th?y database ?? backup!", "L?i", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Copy database file
                File.Copy(sourcePath, targetPath, true);

                MessageBox.Show($"Backup thành công!\nFile ???c l?u t?i:\n{targetPath}", 
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"L?i khi backup database:\n{ex.Message}", "L?i", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Restore database t? file backup
        /// </summary>
        public static bool RestoreDatabase(string sourcePath = null)
        {
            try
            {
                if (string.IsNullOrEmpty(sourcePath))
                {
                    using (OpenFileDialog dialog = new OpenFileDialog())
                    {
                        dialog.Filter = "Database files (*.db)|*.db|All files (*.*)|*.*";
                        dialog.Title = "Ch?n file backup ?? restore";

                        if (dialog.ShowDialog() != DialogResult.OK)
                            return false;

                        sourcePath = dialog.FileName;
                    }
                }

                if (!File.Exists(sourcePath))
                {
                    MessageBox.Show("File backup không t?n t?i!", "L?i", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Xác nh?n restore
                var result = MessageBox.Show(
                    "Restore s? ghi ?è lên database hi?n t?i!\n" +
                    "B?n có ch?c ch?n mu?n ti?p t?c?\n\n" +
                    "Khuy?n ngh?: Backup database hi?n t?i tr??c khi restore.",
                    "Xác nh?n Restore",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return false;

                string targetPath = SQLiteHelper.DatabasePath;

                // Backup database hi?n t?i tr??c khi restore
                if (File.Exists(targetPath))
                {
                    string autoBackupPath = targetPath.Replace(".db", $"_AutoBackup_{DateTime.Now:yyyyMMdd_HHmmss}.db");
                    File.Copy(targetPath, autoBackupPath, true);
                }

                // Copy file backup vào v? trí database
                File.Copy(sourcePath, targetPath, true);

                MessageBox.Show("Restore thành công!\n?ng d?ng s? t?i l?i d? li?u.", 
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"L?i khi restore database:\n{ex.Message}", "L?i", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Export database ra Desktop
        /// </summary>
        public static bool QuickBackupToDesktop()
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string backupPath = Path.Combine(desktopPath, $"ToDoApp_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.db");
                
                return BackupDatabase(backupPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"L?i khi backup ra Desktop:\n{ex.Message}", "L?i", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// L?y thông tin v? database hi?n t?i
        /// </summary>
        public static DatabaseInfo GetDatabaseInfo()
        {
            var info = new DatabaseInfo();
            
            try
            {
                string dbPath = SQLiteHelper.DatabasePath;
                
                if (File.Exists(dbPath))
                {
                    FileInfo fileInfo = new FileInfo(dbPath);
                    info.Exists = true;
                    info.Path = dbPath;
                    info.SizeInBytes = fileInfo.Length;
                    info.SizeFormatted = FormatFileSize(fileInfo.Length);
                    info.CreatedDate = fileInfo.CreationTime;
                    info.LastModifiedDate = fileInfo.LastWriteTime;
                }
                else
                {
                    info.Exists = false;
                    info.Path = dbPath;
                }
            }
            catch (Exception ex)
            {
                info.Error = ex.Message;
            }

            return info;
        }

        private static string FormatFileSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            double len = bytes;
            int order = 0;
            
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            
            return $"{len:0.##} {sizes[order]}";
        }

        /// <summary>
        /// M? th? m?c ch?a database trong File Explorer
        /// </summary>
        public static void OpenDatabaseFolder()
        {
            try
            {
                string dbPath = SQLiteHelper.DatabasePath;
                string folder = Path.GetDirectoryName(dbPath);
                
                if (Directory.Exists(folder))
                {
                    System.Diagnostics.Process.Start("explorer.exe", folder);
                }
                else
                {
                    MessageBox.Show("Th? m?c database không t?n t?i!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không th? m? th? m?c:\n{ex.Message}", "L?i", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    /// <summary>
    /// Thông tin v? database
    /// </summary>
    public class DatabaseInfo
    {
        public bool Exists { get; set; }
        public string Path { get; set; }
        public long SizeInBytes { get; set; }
        public string SizeFormatted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string Error { get; set; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Error))
                return $"Error: {Error}";

            if (!Exists)
                return "Database ch?a ???c t?o";

            return $"Path: {Path}\n" +
                   $"Size: {SizeFormatted}\n" +
                   $"Created: {CreatedDate:yyyy-MM-dd HH:mm:ss}\n" +
                   $"Modified: {LastModifiedDate:yyyy-MM-dd HH:mm:ss}";
        }
    }
}
