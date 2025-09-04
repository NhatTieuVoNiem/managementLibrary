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
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            using (SqlConnection Ketnoi = new SqlConnection(
                @"Data Source=.;Initial Catalog=LibraryManagement;Integrated Security=True;TrustServerCertificate=True"))
            {
                Ketnoi.Open();
                string userOrEmail = txtUsername.Text.Trim();
                string answer1 = txtAnswer1.Text.Trim();
                string answer2 = txtAnswer2.Text.Trim();
                string answer3 = txtAnswer3.Text.Trim();

                string sql = @"SELECT SecurityAnswerHash1, SecurityAnswerHash2, SecurityAnswerHash3
                       FROM Users 
                       WHERE Username=@UserOrEmail OR Email=@UserOrEmail";

                SqlCommand cmd = new SqlCommand(sql, Ketnoi);
                cmd.Parameters.AddWithValue("@UserOrEmail", userOrEmail);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string ans1 = reader["SecurityAnswerHash1"].ToString();
                    string ans2 = reader["SecurityAnswerHash2"].ToString();
                    string ans3 = reader["SecurityAnswerHash3"].ToString();
                    reader.Close();

                    
                    if (answer1 == ans1 && answer2 == ans2 && answer3 == ans3)
                    {
                        if (txtNewPassword.Text != txtConfirmPassword.Text)
                        {
                            MessageBox.Show("Mật khẩu xác nhận không khớp!");
                            return;
                        }

                        string hashedPassword = HashPassword(txtNewPassword.Text);

                        string update = "UPDATE Users SET PasswordHash=@Password WHERE Username=@UserOrEmail OR Email=@UserOrEmail";
                        SqlCommand updateCmd = new SqlCommand(update, Ketnoi);
                        updateCmd.Parameters.AddWithValue("@Password", hashedPassword);
                        updateCmd.Parameters.AddWithValue("@UserOrEmail", userOrEmail);
                        updateCmd.ExecuteNonQuery();

                        MessageBox.Show("Đổi mật khẩu thành công!");

                        // Quay về form đăng nhập
                        this.Hide(); // ẩn form quên mật khẩu
                        FormDangNhap frm = new FormDangNhap();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Câu trả lời bảo mật không đúng!");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Username hoặc Email!");
                }
            }
        }

    }
}
        


