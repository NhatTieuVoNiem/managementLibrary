using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        string Nguon = @"Data Source=DESKTOP-A4F70E0;Initial Catalog=LibraryManagement;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection Ketnoi;
        SqlCommand Thuchien;
        SqlDataReader Doc;
        string Lenh = @"";


        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();
            string password = txtMatKhau.Text.Trim();
            try
            {
                using (SqlConnection conn = new SqlConnection(Nguon))
                {
                    conn.Open();  // Kiểm tra kết nối

                    string sql = "SELECT COUNT(*) FROM Users WHERE Username=@user AND PasswordHash=@pass";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);

                    int result = (int)cmd.ExecuteScalar();

                    if (result > 0)
                    {
                        MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormHome main = new FormHome();
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL!\nChi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định!\nChi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienThiMatKhau.Checked;
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                FormDangKy F = new FormDangKy();
                F.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }

        private void btnQuenMatKhau_Click(object sender, EventArgs e)
        {
         
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập email đã đăng ký!");
                return;
            }

            // Kiểm tra email trong DB
            using (var conn = new SqlConnection("Data Source=DESKTOP-A4F70E0.;Initial Catalog=YourDb;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Email=@Email", conn);
                cmd.Parameters.AddWithValue("@Email", email);

                int count = (int)cmd.ExecuteScalar();

                if (count == 0)
                {
                    MessageBox.Show("Email không tồn tại trong hệ thống!");
                    return;
                }
            }

            // Sinh mã reset (OTP)
            string resetCode = Guid.NewGuid().ToString().Substring(0, 6);

            try
            {
                // Gửi mail qua Gmail SMTP
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("yourgmail@gmail.com");
                mail.Subject = "Mã khôi phục mật khẩu";
                mail.Body = $"Mã reset mật khẩu của bạn là: {resetCode}";
                mail.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("yourgmail@gmail.com", "APP_PASSWORD");
                smtp.EnableSsl = true;

                smtp.Send(mail);

                MessageBox.Show("Mã reset đã được gửi đến email. Vui lòng kiểm tra hộp thư!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi mail: " + ex.Message);
            }
        }

    }
}

