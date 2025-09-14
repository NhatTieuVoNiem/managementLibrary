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
    public partial class FormCustomers : Form
    {
        public FormCustomers()
        {
            InitializeComponent();
            this.Load += Customers_Load;
        }
        connectData c = new connectData();
        private void Customers_Load(object sender, EventArgs e)
        {
            c.connect();
            FormCustomers_Load();
            dataGridViewCustomers.CellClick += dataGridView_CellClick;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           
            c.connect();

            string lastName = txtLastName.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string note = txtNote.Text.Trim();

            if (string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(firstName))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ và Tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"INSERT INTO Customers (LastName, FirstName, Email, Phone, Address, Note)
                     VALUES (@LastName, @FirstName, @Email, @Phone, @Address, @Note)";

            try
            {
                c.connect();
                using (SqlCommand cmd = new SqlCommand(query, c.conn))
                {
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Note", string.IsNullOrEmpty(note) ? (object)DBNull.Value : note);

                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Thêm khách hàng thành công!");
                FormCustomers_Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void FormCustomers_Load()
        {

            try
            {
                c.connect();
                string query = "SELECT CustomerID, LastName, FirstName, Email, Phone, Address, Note FROM Customers";

                SqlDataAdapter da = new SqlDataAdapter(query, c.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewCustomers.AutoGenerateColumns = false;
                dataGridViewCustomers.DataSource = dt;

                // Mapping cột trong DataGridView với dữ liệu trong DataTable
                dataGridViewCustomers.Columns["CustomerID"].DataPropertyName = "CustomerID";
                dataGridViewCustomers.Columns["LastName"].DataPropertyName = "LastName";
                dataGridViewCustomers.Columns["FirstName"].DataPropertyName = "FirstName";
                dataGridViewCustomers.Columns["Email"].DataPropertyName = "Email";
                dataGridViewCustomers.Columns["Phone"].DataPropertyName = "Phone";
                dataGridViewCustomers.Columns["Address"].DataPropertyName = "Address";
                dataGridViewCustomers.Columns["Note"].DataPropertyName = "Note";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewCustomers.Rows[e.RowIndex];

                txtCustomerID.Text = row.Cells["CustomerID"].Value?.ToString();
                txtLastName.Text = row.Cells["LastName"].Value?.ToString();
                txtFirstName.Text = row.Cells["FirstName"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                txtPhone.Text = row.Cells["Phone"].Value?.ToString();
                txtAddress.Text = row.Cells["Address"].Value?.ToString();
                txtNote.Text = row.Cells["Note"].Value?.ToString();
                btnThem.Enabled = false;
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerID.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int customerID = int.Parse(txtCustomerID.Text);
            string lastName = txtLastName.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string note = txtNote.Text.Trim();

            if (string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(firstName))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ và Tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"UPDATE Customers
                     SET LastName=@LastName, FirstName=@FirstName, Email=@Email,
                         Phone=@Phone, Address=@Address, Note=@Note
                     WHERE CustomerID=@CustomerID";

            try
            {
                c.connect();
                using (SqlCommand cmd = new SqlCommand(query, c.conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Note", string.IsNullOrEmpty(note) ? (object)DBNull.Value : note);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("Sửa khách hàng thành công!");
                    else
                        MessageBox.Show("Không tìm thấy khách hàng để sửa!");
                }

                FormCustomers_Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerID.Text)) return;

            int customerID = int.Parse(txtCustomerID.Text);

            DialogResult dr = MessageBox.Show($"Bạn có chắc muốn xóa khách hàng {customerID} không?",
                                              "Xác nhận", MessageBoxButtons.YesNo);
            if (dr != DialogResult.Yes) return;

            string query = "DELETE FROM Customers WHERE CustomerID=@CustomerID";

            try
            {
                c.connect();
                using (SqlCommand cmd = new SqlCommand(query, c.conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Xóa khách hàng thành công!");
                        FormCustomers_Load();
                        btnLammoi_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng để xóa!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            txtCustomerID.Clear();
            txtLastName.Clear();
            txtFirstName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtNote.Clear();
            dataGridViewCustomers.ClearSelection();
            btnThem.Enabled = true;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string keyword = txtLastName.Text.Trim(); // txtSearch là ô nhập tìm kiếm

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập tên để tìm kiếm!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                c.connect();
                string query = @"SELECT CustomerID, LastName, FirstName, Email, Phone, Address, Note
                         FROM Customers
                         WHERE (LastName + ' ' + FirstName) LIKE @Keyword";

                SqlDataAdapter da = new SqlDataAdapter(query, c.conn);
                da.SelectCommand.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewCustomers.AutoGenerateColumns = false;
                dataGridViewCustomers.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }
    }
    }


