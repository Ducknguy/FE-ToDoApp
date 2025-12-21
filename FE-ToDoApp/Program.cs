using FE_ToDoApp.Lich_Trinh;
using FE_ToDoApp.login;
using FE_ToDoApp.Setting;
using FE_ToDoApp.Calendar;
using ChatbotAI_Form;
using System.Globalization;


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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
<<<<<<< HEAD
            Application.Run(new setting());
=======
            Application.Run(new calendar());

>>>>>>> 47520a1bb1243e4b420857b9396962316c6bacd9
        }
    }
}