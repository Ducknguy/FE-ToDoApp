using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FE_ToDoApp
{
    class ConnectSQL
    {
        // --- QUAN TRỌNG: ĐỂ public static ĐỂ CÁC DAO KHÁC DÙNG KÉ ---
        public static string strCon = @"Data Source=Money\SQLEXPRESS;Initial Catalog=ChatBotDB;Integrated Security=True";

        // Đối tượng kết nối
        private SqlConnection conn = null;

        public ConnectSQL()
        {
            conn = new SqlConnection(strCon);
        }

        // HÀM LẤY KẾT NỐI
        public SqlConnection GetConnection()
        {
            return new SqlConnection(strCon);
        }

        // 2. HÀM LẤY DỮ LIỆU (SELECT)
        public DataTable LayDuLieu(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);

                if (conn.State == ConnectionState.Open) conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message);
            }
            return dt;
        }

        // 3. HÀM THAY ĐỔI DỮ LIỆU (INSERT, UPDATE, DELETE CƠ BẢN)
        public bool ThucHienLenh(string sql)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                int ketqua = cmd.ExecuteNonQuery();

                if (conn.State == ConnectionState.Open) conn.Close();

                return ketqua > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực hiện lệnh: " + ex.Message);
                return false;
            }
        }
    }
}