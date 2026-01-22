using FE_ToDoApp.Lich_Trinh;
using FE_ToDoApp.login;
using FE_ToDoApp.Setting;
using FE_ToDoApp.Calendar;
using ChatbotAI_Form;
using System.Globalization;
using FE_ToDoApp.ThungRac;
using FE_ToDoApp.Database;
using FE_ToDoApp.Services;


namespace FE_ToDoApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SQLiteHelper.InitializeDatabase();

            // Kh?i ??ng Streak Service
            StreakService.CheckStreaksOnStartup();
            StreakService.Start();

            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();          

            Application.Run(new Trangchu());
            
            // D?ng service khi app thoát
            StreakService.Stop();
        }
    }
}