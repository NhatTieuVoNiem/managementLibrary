using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class FormQuenMatKhau : Form
    {
        connectData c = new connectData();

        public FormQuenMatKhau()
        {
            InitializeComponent();
        }

        // Hàm hash chuỗi
        private string HashString(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Lấy 3 câu hỏi bảo mật từ DB
        private void btnLayCauHoi_Click(object sender, EventArgs e)
        {
            try
            {
                c.connect();
                string userOrEmail = txtUsername.Text.Trim();

                if (string.IsNullOrEmpty(userOrEmail))
                {
                    MessageBox.Show("Vui lòng nhập Username hoặc Email!", "Thông báo");
                    return;
                }

                string sql = @"SELECT SecurityQuestion1, SecurityQuestion2, SecurityQuestion3 
                               FROM Users 
                               WHERE Username=@UserOrEmail OR Email=@UserOrEmail";

                using (SqlCommand cmd = new SqlCommand(sql, c.conn))
                {
                    cmd.Parameters.AddWithValue("@UserOrEmail", userOrEmail);

                    SqlDataReader reader = cmd.ExecuteReader();
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                c.disconnect();
            }
        }

        // Xác nhận trả lời và đổi mật khẩu
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                c.connect();
                string userOrEmail = txtUsername.Text.Trim();
                string answer1 = txtAnswer1.Text.Trim();
                string answer2 = txtAnswer2.Text.Trim();
                string answer3 = txtAnswer3.Text.Trim();

                string sql = @"SELECT SecurityAnswerHash1, SecurityAnswerHash2, SecurityAnswerHash3
                               FROM Users 
                               WHERE Username=@UserOrEmail OR Email=@UserOrEmail";

                using (SqlCommand cmd = new SqlCommand(sql, c.conn))
                {
                    cmd.Parameters.AddWithValue("@UserOrEmail", userOrEmail);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string ans1 = reader["SecurityAnswerHash1"].ToString();
                        string ans2 = reader["SecurityAnswerHash2"].ToString();
                        string ans3 = reader["SecurityAnswerHash3"].ToString();
                        reader.Close();

                        // So sánh hash câu trả lời
                        if (HashString(answer1) == ans1 &&
                            HashString(answer2) == ans2 &&
                            HashString(answer3) == ans3)
                        {
                            if (txtNewPassword.Text != txtConfirmPassword.Text)
                            {
                                MessageBox.Show("Mật khẩu xác nhận không khớp!");
                                return;
                            }

                            string hashedPassword = HashString(txtNewPassword.Text);

                            string update = @"UPDATE Users 
                                              SET PasswordHash=@Password 
                                              WHERE Username=@UserOrEmail OR Email=@UserOrEmail";

                            using (SqlCommand updateCmd = new SqlCommand(update, c.conn))
                            {
                                updateCmd.Parameters.AddWithValue("@Password", hashedPassword);
                                updateCmd.Parameters.AddWithValue("@UserOrEmail", userOrEmail);
                                updateCmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Đổi mật khẩu thành công!");
                            this.Hide();
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                c.disconnect();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDangNhap frm = new FormDangNhap();
            frm.Show();
        }
    }
}
