using FE_ToDoApp.Lich_Trinh;
using FE_ToDoApp.login;
using FE_ToDoApp.Setting;
using FE_ToDoApp.Calendar;
using ChatbotAI_Form;
using System.Globalization;
using FE_ToDoApp.ThungRac;
using FE_ToDoApp.Database;
using FE_ToDoApp.Services;
using Google.Apis.Calendar.v3.Data;


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

            Application.Run(new Login1());
            
            // D?ng service khi app tho�t
            StreakService.Stop();
        }
    }
}