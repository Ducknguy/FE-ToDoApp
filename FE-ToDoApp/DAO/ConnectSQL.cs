using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using FE_ToDoApp.Database;

namespace FE_ToDoApp
{
    class ConnectSQL
    {
        // ✅ SQLite: không cần strCon kiểu SQL Server nữa
        // Dùng thẳng SQLiteHelper trong Database folder

        // Đối tượng kết nối
        private SQLiteConnection conn = null;

        public ConnectSQL()
        {
            conn = SQLiteHelper.GetConnection();
        }

        // HÀM LẤY KẾT NỐI
        public SQLiteConnection GetConnection()
        {
            return SQLiteHelper.GetConnection();
        }

        // 2. HÀM LẤY DỮ LIỆU (SELECT)
        public DataTable LayDuLieu(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                using (SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn))
                {
                    da.Fill(dt);
                }

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

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    int ketqua = cmd.ExecuteNonQuery();

                    if (conn.State == ConnectionState.Open) conn.Close();
                    return ketqua > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực hiện lệnh: " + ex.Message);
                return false;
            }
        }
    }
}
