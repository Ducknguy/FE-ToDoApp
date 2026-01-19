using FE_ToDoApp.Lich_Trinh;
using FE_ToDoApp.login;
using FE_ToDoApp.Setting;
using FE_ToDoApp.Calendar;
using ChatbotAI_Form;
using System.Globalization;
using FE_ToDoApp.ThungRac;
using FE_ToDoApp.Database;


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
            // Kh?i t?o SQLite database
            SQLiteHelper.InitializeDatabase();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();          

            Application.Run(new Trangchu());
        }
    }
}