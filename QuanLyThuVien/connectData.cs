using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien
{
    internal class connectData
    {
        public SqlConnection conn;
        public void connect()
        {
            string strCon = @"Data Source=.;Initial Catalog=LibraryManagement;Integrated Security=True";
            try
            {
                conn = new SqlConnection(strCon);
                conn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public void disconnect()
        {
            conn.Close();
            conn.Dispose();
            conn = null;
        }
        public Boolean exeSQL(string cmd)
        {
            try
            {
                SqlCommand sc = new SqlCommand(cmd, conn);
                sc.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

