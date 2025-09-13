using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class FormSalary : Form
    {
        public FormSalary()
        {
            InitializeComponent();

            this.Load += FormSalary_Load;
        }
        connectData c = new connectData();
        private void FormSalary_Load(object sender, EventArgs e)
        {
            c.connect();
            LoadEmployeesToCombo();
            LoadSalary();
        }

        private void LoadEmployeesToCombo()
        {
            string query = "SELECT EmployeeID, FullName FROM Employees";
            SqlDataAdapter da = new SqlDataAdapter(query, c.conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cboEmployeeID.DataSource = dt;
            cboEmployeeID.DisplayMember = "FullName";   // hiển thị tên
            cboEmployeeID.ValueMember = "EmployeeID";   // giá trị = mã NV
            cboEmployeeID.SelectedIndex = -1;
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            decimal baseSalary = decimal.TryParse(txtBaseSalary.Text, out decimal bs) ? bs : 0;
            int workDays = int.TryParse(txtWorkDays.Text, out int wd) ? wd : 0;
            decimal allowance = decimal.TryParse(txtAllowance.Text, out decimal al) ? al : 0;
            decimal bonus = decimal.TryParse(txtBonus.Text, out decimal bo) ? bo : 0;
            decimal deduction = decimal.TryParse(txtDeduction.Text, out decimal de) ? de : 0;

            // Giả sử 1 tháng = 26 ngày công chuẩn
            decimal totalSalary = baseSalary / 26 * workDays + allowance + bonus - deduction;
            txtTotalSalary.Text = totalSalary.ToString("N0");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string empID = cboEmployeeID.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(empID))
            {
                MessageBox.Show("Vui lòng chọn nhân viên!");
                return;
            }

            int month = dtpMonthYear.Value.Month;
            int year = dtpMonthYear.Value.Year;

            decimal baseSalary = decimal.Parse(txtBaseSalary.Text);
            int workDays = int.Parse(txtWorkDays.Text);
            decimal allowance = decimal.Parse(txtAllowance.Text);
            decimal bonus = decimal.Parse(txtBonus.Text);
            decimal deduction = decimal.Parse(txtDeduction.Text);

            try
            {
                c.connect();
                string query = @"INSERT INTO Salaries(EmployeeID, Month, Year, BaseSalary, WorkDays, Allowance, Bonus, Deduction)
                                 VALUES(@EmployeeID, @Month, @Year, @BaseSalary, @WorkDays, @Allowance, @Bonus, @Deduction)";
                using (SqlCommand cmd = new SqlCommand(query, c.conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", empID);
                    cmd.Parameters.AddWithValue("@Month", month);
                    cmd.Parameters.AddWithValue("@Year", year);
                    cmd.Parameters.AddWithValue("@BaseSalary", baseSalary);
                    cmd.Parameters.AddWithValue("@WorkDays", workDays);
                    cmd.Parameters.AddWithValue("@Allowance", allowance);
                    cmd.Parameters.AddWithValue("@Bonus", bonus);
                    cmd.Parameters.AddWithValue("@Deduction", deduction);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đã lưu lương nhân viên!");
                LoadSalary();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
              private void LoadSalary()
        {
            try
            {
                c.connect();
                string query = @"SELECT s.SalaryID, s.EmployeeID, e.FullName, s.Month, s.Year, 
                                        s.BaseSalary, s.WorkDays, s.Allowance, s.Bonus, s.Deduction,
                                        (s.BaseSalary/26*s.WorkDays + s.Allowance + s.Bonus - s.Deduction) AS TotalSalary
                                 FROM Salaries s 
                                 INNER JOIN Employees e ON s.EmployeeID = e.EmployeeID";
                SqlDataAdapter da = new SqlDataAdapter(query, c.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewSalary.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
    }
}
 
