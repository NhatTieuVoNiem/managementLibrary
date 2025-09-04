using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyThuVien
{
    public partial class FormQuenMatKhau : Form
    {
        public FormQuenMatKhau()
        {
            InitializeComponent();
        }


        private void btnLayCauHoi_Click(object sender, EventArgs e)
        {
            using (SqlConnection Ketnoi = new SqlConnection(
                @"Data Source=.;Initial Catalog=LibraryManagement;Integrated Security=True;TrustServerCertificate=True"))
            {
                Ketnoi.Open();
                string userOrEmail = txtUsername.Text.Trim();

                if (string.IsNullOrEmpty(userOrEmail))
                {
                    MessageBox.Show("Vui lòng nhập Username hoặc Email!", "Thông báo");
                    return;
                }

                string sql = @"SELECT SecurityQuestion1, SecurityQuestion2, SecurityQuestion3 
                       FROM Users 
                       WHERE Username=@UserOrEmail OR Email=@UserOrEmail";

                SqlCommand Lenh = new SqlCommand(sql, Ketnoi);
                Lenh.Parameters.AddWithValue("@UserOrEmail", userOrEmail);

                SqlDataReader reader = Lenh.ExecuteReader();
                if (reader.Read())
                {
                    lblQuestion1.Text = reader["SecurityQuestion1"].ToString();
                    lblQuestion2.Text = reader["SecurityQuestion2"].ToString();
                    lblQuestion3.Text = reader["SecurityQuestion3"].ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Username hoặc Email này!", "Lỗi");
                }
                reader.Close();
            }
        }
        

        

    }
}

