using System.Data.SqlClient;

namespace FE_ToDoApp
{
    public class ConnectSQL
    {
        public static string ConnectionString =
            @"Data Source=LAPTOP-HJ0H2N4I;Initial Catalog=ChatBotDB;Integrated Security=True";

        // Chỉ tạo connection, KHÔNG open
        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
