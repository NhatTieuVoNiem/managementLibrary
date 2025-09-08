using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien
{
    public class connectData
    {
        private SqlConnection conn;
        private string connectionString =
            @"Data Source=.\SQLEXPRESS01;Initial Catalog=libraryManagement;Integrated Security=True;";

        public void OpenConnect()
        {
            if (conn == null)
                conn = new SqlConnection(connectionString);

            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }
        public void CloseConnect()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }
        SqlConnection Ketnoi;
        SqlCommand Thuchien;
        SqlDataReader Doc;
        string Lenh = @"";
    }
}
