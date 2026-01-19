using System.Data.SqlClient;

namespace FE_ToDoApp.Lich_Trinh
{
    public static class DatabaseHelper
    {
        public static string ConnectionString { get; set; } =
            @"Data Source=LAPTOP-HJ0H2N4I;Initial Catalog=ToDoApp;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
