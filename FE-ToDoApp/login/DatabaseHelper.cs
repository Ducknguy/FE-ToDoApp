using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE_ToDoApp.login
{
    public class DatabaseHelper
    {
        private static string connectionString = @"Data Source=GIANG;Initial Catalog=user;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}