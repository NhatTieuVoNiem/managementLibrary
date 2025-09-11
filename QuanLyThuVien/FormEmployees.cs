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
            }
            // Câu lệnh SQL insert
            string query = "INSERT INTO Employees (EmployeeID, FullName, Gender, BirthDate, Phone, Address, Position) " +
                           "VALUES (@EmployeeID, @FullName, @Gender, @BirthDate, @Phone, @Address, @Position)";

            using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=LibraryManagement;Integrated Security=True"))
            using (SqlCommand thuchien = new SqlCommand(query, c.conn)) 
            {
                thuchien.Parameters.AddWithValue("@EmployeeID", id);
                thuchien.Parameters.AddWithValue("@FullName", name);
                thuchien.Parameters.AddWithValue("@Gender", gender ?? "");
                thuchien.Parameters.AddWithValue("@BirthDate", birthDate);
                thuchien.Parameters.AddWithValue("@Phone", phone);
                thuchien.Parameters.AddWithValue("@Address", address);
                thuchien.Parameters.AddWithValue("@Position", position);

                try
                {
                    c.connect();
                    thuchien.ExecuteNonQuery();
                    MessageBox.Show("Thêm nhân viên thành công!");
                    LoadEmployees();

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
                
                

                 // Gán dữ liệu cho DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
    }
    }

