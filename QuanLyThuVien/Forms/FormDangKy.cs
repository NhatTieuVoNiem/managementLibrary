using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class FormDangKy : Form
    {
        connectData c = new connectData(); // dùng class connectData
   


        public FormDangKy()
        {
            InitializeComponent();
        }

        // Hàm Hash mật khẩu / câu trả lời bảo mật
        private string HashPassword(string input)
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

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Mở kết nối
            c.connect();

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string cauhoi1 = txtQuestion1.Text.Trim();
            string traloi1 = txtAnswer1.Text.Trim();
            string cauhoi2 = txtQuestion2.Text.Trim();
            string traloi2 = txtAnswer2.Text.Trim();
            string cauhoi3 = txtQuestion3.Text.Trim();
            string traloi3 = txtAnswer3.Text.Trim();

            // VALIDATE dữ liệu
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ. Vui lòng nhập lại.");
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cauhoi1) || string.IsNullOrEmpty(traloi1) ||
                string.IsNullOrEmpty(cauhoi2) || string.IsNullOrEmpty(traloi2) ||
                string.IsNullOrEmpty(cauhoi3) || string.IsNullOrEmpty(traloi3))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ 3 câu hỏi và câu trả lời bảo mật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kiểm tra Username
                string checkUsername = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                using (SqlCommand checkUsernameCmd = new SqlCommand(checkUsername, c.conn))
                {
                    checkUsernameCmd.Parameters.AddWithValue("@Username", username);
                    int usernameExists = (int)checkUsernameCmd.ExecuteScalar();
                    if (usernameExists > 0)
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Kiểm tra Email
                string checkEmail = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                using (SqlCommand checkEmailCmd = new SqlCommand(checkEmail, c.conn))
                {
                    checkEmailCmd.Parameters.AddWithValue("@Email", email);
                    int emailExists = (int)checkEmailCmd.ExecuteScalar();
                    if (emailExists > 0)
                    {
                        MessageBox.Show("Email đã được sử dụng. Vui lòng dùng email khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Hash mật khẩu và câu trả lời bảo mật
                string hashedPassword = HashPassword(password);
                string hashedAns1 = HashPassword(traloi1);
                string hashedAns2 = HashPassword(traloi2);
                string hashedAns3 = HashPassword(traloi3);

                // Lệnh insert
                string sql = @"INSERT INTO Users (Username, PasswordHash, FullName, Email, 
                                SecurityQuestion1, SecurityAnswerHash1, 
                                SecurityQuestion2, SecurityAnswerHash2, 
                                SecurityQuestion3, SecurityAnswerHash3, CreatedAt) 
                               VALUES (@Username, @PasswordHash, @FullName, @Email, 
                                @CauHoi1, @TraLoi1, @CauHoi2, @TraLoi2, @CauHoi3, @TraLoi3, GETDATE())";

                using (SqlCommand Lenh = new SqlCommand(sql, c.conn))
                {
                    Lenh.Parameters.AddWithValue("@Username", username);
                    Lenh.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    Lenh.Parameters.AddWithValue("@FullName", fullName);
                    Lenh.Parameters.AddWithValue("@Email", email);
                    Lenh.Parameters.AddWithValue("@CauHoi1", cauhoi1);
                    Lenh.Parameters.AddWithValue("@TraLoi1", hashedAns1);
                    Lenh.Parameters.AddWithValue("@CauHoi2", cauhoi2);
                    Lenh.Parameters.AddWithValue("@TraLoi2", hashedAns2);
                    Lenh.Parameters.AddWithValue("@CauHoi3", cauhoi3);
                    Lenh.Parameters.AddWithValue("@TraLoi3", hashedAns3);

                    int kq = Lenh.ExecuteNonQuery();

                    if (kq > 0)
                    {
                        MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        FormDangNhap fLogin = new FormDangNhap();
                        fLogin.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Đăng ký thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng ký: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                c.disconnect();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDangNhap frm = new FormDangNhap();
            frm.Show();
        }
    }
}
