using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class FormSalaries : Form
    {
        private int _memberID;
        private string _fullName;

        connectData c = new connectData();

        public FormSalaries(int memberID, string fullName)
        {
            InitializeComponent();
            _memberID = memberID;
            _fullName = fullName;

            this.Load += FormSalaries_Load;
        }

        private void FormSalaries_Load(object sender, EventArgs e)
        {
            try
            {
                // Kết nối database
                c.connect();
                

                txtName.Text = _fullName; // hiển thị tên thành viên
                LoadSalaryHistory();

                // Đăng ký sự kiện button
                btnTinhLuong.Click += btnTinhLuong_Click;
                btnLuu.Click += btnLuu_Click;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối database: " + ex.Message);
            }
        }

        // Load lịch sử lương
        private void LoadSalaryHistory()
        {
            try
            {
                string query = @"SELECT SalaryID, BaseSalary, Bonus, Deduction, TotalSalary, PayDate, Note
                         FROM Salaries WHERE MemberID=@MemberID";
                SqlCommand cmd = new SqlCommand(query, c.conn);
                cmd.Parameters.AddWithValue("@MemberID", _memberID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvSalaries.DataSource = dt;

                // Đổi tên cột sang tiếng Việt
                dgvSalaries.Columns["SalaryID"].HeaderText = "Mã lương";
                dgvSalaries.Columns["BaseSalary"].HeaderText = "Lương cơ bản";
                dgvSalaries.Columns["Bonus"].HeaderText = "Thưởng";
                dgvSalaries.Columns["Deduction"].HeaderText = "Khấu trừ";
                dgvSalaries.Columns["TotalSalary"].HeaderText = "Tổng lương";
                dgvSalaries.Columns["PayDate"].HeaderText = "Ngày trả lương";
                dgvSalaries.Columns["Note"].HeaderText = "Ghi chú";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử lương: " + ex.Message);
            }
        }

        // Tự động tính tổng lương khi bấm nút
        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            decimal baseSalary = decimal.TryParse(txtBaseSalary.Text, out decimal bs) ? bs : 0;
            decimal bonus = decimal.TryParse(txtBonus.Text, out decimal bo) ? bo : 0;
            decimal deduction = decimal.TryParse(txtDeduction.Text, out decimal de) ? de : 0;

            decimal totalSalary = baseSalary + bonus - deduction;

            txtTotalSalary.Text = totalSalary.ToString("N0");
        }

        // Lưu lương vào database
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                decimal baseSalary = decimal.TryParse(txtBaseSalary.Text, out decimal bs) ? bs : 0;
                decimal bonus = decimal.TryParse(txtBonus.Text, out decimal bo) ? bo : 0;
                decimal deduction = decimal.TryParse(txtDeduction.Text, out decimal de) ? de : 0;
                decimal totalSalary = baseSalary + bonus - deduction;
                DateTime payDate = dtpPayDate.Value;
                string note = string.IsNullOrWhiteSpace(txtNote.Text) ? null : txtNote.Text.Trim();

                string query = @"INSERT INTO Salaries(MemberID, BaseSalary, Bonus, Deduction, PayDate, Note)
                                VALUES(@MemberID, @BaseSalary, @Bonus, @Deduction, @PayDate, @Note)";

                using (SqlCommand cmd = new SqlCommand(query, c.conn))
                {
                    cmd.Parameters.AddWithValue("@MemberID", _memberID);
                    cmd.Parameters.AddWithValue("@BaseSalary", baseSalary);
                    cmd.Parameters.AddWithValue("@Bonus", bonus);
                    cmd.Parameters.AddWithValue("@Deduction", deduction);
                    cmd.Parameters.AddWithValue("@TotalSalary", totalSalary);
                    cmd.Parameters.AddWithValue("@PayDate", payDate);
                    cmd.Parameters.AddWithValue("@Note", (object)note ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Lưu lương thành công!");
                LoadSalaryHistory();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu lương: " + ex.Message);
            }
        }

        // Xóa form nhập liệu sau khi lưu
        private void ClearForm()
        {
            txtBaseSalary.Clear();
            txtBonus.Clear();
            txtDeduction.Clear();
            txtTotalSalary.Clear();
            txtNote.Clear();
            dtpPayDate.Value = DateTime.Now;
        }

    }
}
