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
        SqlConnection Ketnoi;
        SqlCommand Lenh;
        public FormDangKy()
        {
            InitializeComponent();
        }
        // Hàm Hash mật khẩu
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // chuyển thành hex
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
            // Chuỗi kết nối
            Ketnoi = new SqlConnection(@"Data Source=.;Initial Catalog=libraryManagement;Integrated Security=True;");
            Ketnoi.Open();

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim(); // Nhập lại mật khẩu
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string cauhoi1 = txtQuestion1.Text.Trim();
            string traloi1 = txtAnswer1.Text.Trim();
            string cauhoi2 = txtQuestion2.Text.Trim();
            string traloi2 = txtAnswer2.Text.Trim();
            string cauhoi3 = txtQuestion3.Text.Trim();
            string traloi3 = txtAnswer3.Text.Trim();

            // --- VALIDATE dữ liệu ---
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword)
                || string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ. Vui lòng nhập lại.");
                return;
            }

            // Kiểm tra nhập lại mật khẩu
            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra 3 câu hỏi bảo mật
            if (string.IsNullOrEmpty(cauhoi1) || string.IsNullOrEmpty(traloi1) ||
                string.IsNullOrEmpty(cauhoi2) || string.IsNullOrEmpty(traloi2) ||
                string.IsNullOrEmpty(cauhoi3) || string.IsNullOrEmpty(traloi3))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ 3 câu hỏi và câu trả lời bảo mật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra Username
            string checkUsername = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
            SqlCommand checkUsernameCmd = new SqlCommand(checkUsername, Ketnoi);
            checkUsernameCmd.Parameters.AddWithValue("@Username", username);
            int usernameExists = (int)checkUsernameCmd.ExecuteScalar();

            if (usernameExists > 0)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Ketnoi.Close();
                return;
            }

            // Kiểm tra Email
            string checkEmail = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
            SqlCommand checkEmailCmd = new SqlCommand(checkEmail, Ketnoi);
            checkEmailCmd.Parameters.AddWithValue("@Email", email);
            int emailExists = (int)checkEmailCmd.ExecuteScalar();

            if (emailExists > 0)
            {
                MessageBox.Show("Email đã được sử dụng. Vui lòng dùng email khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Ketnoi.Close();
                return;
            }

            try
            {
                // Hash mật khẩu
                string hashedPassword = HashPassword(password);

                // Lệnh insert
                string sql = @"INSERT INTO Users (Username, PasswordHash, FullName, Email, 
                                SecurityQuestion1, SecurityAnswerHash1, SecurityQuestion2, SecurityAnswerHash2, SecurityQuestion3, SecurityAnswerHash3, CreatedAt) 
                               VALUES (@Username, @PasswordHash, @FullName, @Email, 
                                @CauHoi1, @TraLoi1, @CauHoi2, @TraLoi2, @CauHoi3, @TraLoi3, GETDATE())";

                Lenh = new SqlCommand(sql, Ketnoi);
                Lenh.Parameters.AddWithValue("@Username", username);
                Lenh.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                Lenh.Parameters.AddWithValue("@FullName", fullName);
                Lenh.Parameters.AddWithValue("@Email", email);
                Lenh.Parameters.AddWithValue("@CauHoi1", cauhoi1);
                Lenh.Parameters.AddWithValue("@TraLoi1", traloi1);
                Lenh.Parameters.AddWithValue("@CauHoi2", cauhoi2);
                Lenh.Parameters.AddWithValue("@TraLoi2", traloi2);
                Lenh.Parameters.AddWithValue("@CauHoi3", cauhoi3);
                Lenh.Parameters.AddWithValue("@TraLoi3", traloi3);

                int kq = Lenh.ExecuteNonQuery();

                if (kq > 0)
                {
                    MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();  // Ẩn form đăng ký

                 FormDangNhap fLogin = new FormDangNhap();
                 fLogin.ShowDialog();
                 this.Close(); // Đóng hẳn form đăng ký sau khi login đóng
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Ketnoi.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng ký: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FormDangNhap fLogin = new FormDangNhap();
            fLogin.ShowDialog();
            this.Close();

        }

        private void FormDangKy_Load(object sender, EventArgs e)
        {

        }

        private void txtAnswer3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
