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
using System.Xml.Linq;

namespace QuanLyThuVien
{
    public partial class FormEmployees : Form
    {
        public FormEmployees()
        {
            InitializeComponent();
            this.Load += FormEmployees_Load;
        }
        connectData c = new connectData();
        SqlCommand thuchien;
        private void FormEmployees_Load(object sender, EventArgs e)
        {
            c.connect();
            cboGender.Items.Add("Nam");
            cboGender.Items.Add("Nữ");
            cboGender.Items.Add("Khác");
            LoadEmployees();
            dataGridView.CellClick += dataGridView_CellClick;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            c.connect();
            // Lấy dữ liệu từ form
            string id = txtEmployeeID.Text.Trim();
            string name = txtFullName.Text.Trim();
            string gender = cboGender.SelectedItem?.ToString();
            DateTime birthDate = dtpBirthDate.Value;
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string position = txtPosition.Text.Trim();

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show(this, "Vui lòng nhập đầy đủ Mã NV và Họ tên!", "Thông báo",
                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Câu lệnh SQL insert
            string query = "INSERT INTO Employees (EmployeeID, FullName, Gender, BirthDate, Phone, Address, Position) " +
                           "VALUES (@EmployeeID, @FullName, @Gender, @BirthDate, @Phone, @Address, @Position)";
            using (SqlCommand thuchien = new SqlCommand(query, c.conn)) 
            {
                thuchien.Parameters.Add("@EmployeeID", SqlDbType.NVarChar, 20).Value = id;
                thuchien.Parameters.Add("@FullName", SqlDbType.NVarChar, 100).Value = name;
                thuchien.Parameters.Add("@Gender", SqlDbType.NVarChar, 10).Value = gender ?? "";
                thuchien.Parameters.Add("@BirthDate", SqlDbType.Date).Value = birthDate;
                thuchien.Parameters.Add("@Phone", SqlDbType.NVarChar, 15).Value = phone;
                thuchien.Parameters.Add("@Address", SqlDbType.NVarChar, 200).Value = address;
                thuchien.Parameters.Add("@Position", SqlDbType.NVarChar, 50).Value = position;


                try
                {
                    c.connect();
                    thuchien.ExecuteNonQuery();
                    MessageBox.Show("Thêm nhân viên thành công!");
                    LoadEmployees();
                    btnLammoi_Click(sender, e);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            


        }

        private void LoadEmployees()
        {
            try
            {
                c.connect();
                string query = "SELECT EmployeeID, FullName, Gender, BirthDate, Phone, Address, Position FROM Employees";

                SqlDataAdapter da = new SqlDataAdapter(query, c.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView.AutoGenerateColumns = false;

                // Map dữ liệu từ DataTable -> từng cột DataGridView
                dataGridView.Columns["colEmployeeID"].DataPropertyName = "EmployeeID";
                dataGridView.Columns["colFullName"].DataPropertyName = "FullName";
                dataGridView.Columns["colGender"].DataPropertyName = "Gender";
                dataGridView.Columns["colBirthDate"].DataPropertyName = "BirthDate";
                dataGridView.Columns["colPhone"].DataPropertyName = "Phone";
                dataGridView.Columns["colAddress"].DataPropertyName = "Address";
                dataGridView.Columns["colPosition"].DataPropertyName = "Position";

                // Gán dữ liệu
                dataGridView.DataSource = dt;
            }
            catch (Exception x)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + x.Message);
            }
            c.disconnect();
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            txtEmployeeID.Clear();
            txtFullName.Clear();
            cboGender.SelectedIndex = -1;          // reset combobox
            dtpBirthDate.Value = DateTime.Now;     // reset ngày sinh về hôm nay
            txtPhone.Clear();
            txtAddress.Clear();
            txtPosition.Clear();

            txtEmployeeID.Focus(); // con trỏ nhảy về ô nhập Mã NV
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            c.connect();

            string id = txtEmployeeID.Text.Trim();
            string name = txtFullName.Text.Trim();
            string gender = cboGender.SelectedItem?.ToString();
            DateTime birthDate = dtpBirthDate.Value;
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string position = txtPosition.Text.Trim();

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Vui lòng nhập Mã NV để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"UPDATE Employees
                     SET FullName = @FullName,
                         Gender = @Gender,
                         BirthDate = @BirthDate,
                         Phone = @Phone,
                         Address = @Address,
                         Position = @Position
                     WHERE EmployeeID = @EmployeeID";

            using (SqlCommand cmd = new SqlCommand(query, c.conn))
            {
                cmd.Parameters.AddWithValue("@EmployeeID", id);
                cmd.Parameters.AddWithValue("@FullName", name);
                cmd.Parameters.AddWithValue("@Gender", gender ?? "");
                cmd.Parameters.AddWithValue("@BirthDate", birthDate);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Position", position);

                try
                {
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Sửa nhân viên thành công!");
                        LoadEmployees(); // load lại danh sách
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên cần sửa!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
               
            }
            
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Chỉ xử lý nếu click vào dòng hợp lệ (không phải header)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];

                txtEmployeeID.Text = row.Cells["colEmployeeID"].Value?.ToString();
                txtFullName.Text = row.Cells["colFullName"].Value?.ToString();
                cboGender.Text = row.Cells["colGender"].Value?.ToString();


                // Gán ngày sinh, kiểm tra null
                if (row.Cells["colBirthDate"].Value != null && DateTime.TryParse(row.Cells["colBirthDate"].Value.ToString(), out DateTime birthDate))
                {
                    dtpBirthDate.Value = birthDate;
                }

                txtPhone.Text = row.Cells["colPhone"].Value?.ToString();
                txtAddress.Text = row.Cells["colAddress"].Value?.ToString();
                txtPosition.Text = row.Cells["colPosition"].Value?.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = txtEmployeeID.Text.Trim();
            if (string.IsNullOrEmpty(id)) return;

            DialogResult dr = MessageBox.Show($"Bạn có chắc muốn xóa nhân viên {id} không?",
                                              "Xác nhận", MessageBoxButtons.YesNo);
            if (dr != DialogResult.Yes) return;

            try
            {
                c.connect();
                string query = "DELETE FROM Employees WHERE RTRIM(LTRIM(EmployeeID)) = @EmployeeID";
                using (SqlCommand cmd = new SqlCommand(query, c.conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", id);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Xóa nhân viên thành công!");
                        LoadEmployees();
                        btnLammoi_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên cần xóa!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            
        }

    }
}
   


