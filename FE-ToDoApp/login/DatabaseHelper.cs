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
        // Cần thay đổi chuỗi kết nối này cho phù hợp với SQL Server của bạn!
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VS\BTL\FE-TODOAPP\LOGIN\DATABASE1.MDF;Integrated Security=True;Connect Timeout=30";

        // Hoặc sử dụng ConfigurationManager.ConnectionStrings["UserDBConnection"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
