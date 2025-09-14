using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class FormMembers : Form
    {

        public FormMembers()
        {
            InitializeComponent();
            this.Load += FormMembers_Load;
        }

        connectData c = new connectData();

        private void FormMembers_Load(object sender, EventArgs e)
        {
            c.connect();
            LoadMembers();
            dataGridView.CellClick += dataGridView_CellClick;
            dataGridView.CellDoubleClick += dataGridView_CellDoubleClick;
            dataGridView.CellDoubleClick -= dataGridView_CellDoubleClick;

        }

        private void LoadMembers()
        {
            try
            {
                c.connect();
                string query = "SELECT MemberID, LastName, FirstName, Email, Phone, Address, JoinDate, Note FROM Members";

                SqlDataAdapter da = new SqlDataAdapter(query, c.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = dt;

                // Mapping
                dataGridView.Columns["colMemberID"].DataPropertyName = "MemberID";
                dataGridView.Columns["colLastName"].DataPropertyName = "LastName";
                dataGridView.Columns["colFirstName"].DataPropertyName = "FirstName";
                dataGridView.Columns["colEmail"].DataPropertyName = "Email";
                dataGridView.Columns["colPhone"].DataPropertyName = "Phone";
                dataGridView.Columns["colAddress"].DataPropertyName = "Address";
                dataGridView.Columns["colJoinDate"].DataPropertyName = "JoinDate";
                dataGridView.Columns["colNote"].DataPropertyName = "Note";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
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

            string query = @"INSERT INTO Members (LastName, FirstName, Email, Phone, Address, Note)
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
                MessageBox.Show("Thêm thành viên thành công!");
                LoadMembers();
                btnLammoi_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMemberID.Text))
            {
                MessageBox.Show("Vui lòng chọn thành viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int memberId = int.Parse(txtMemberID.Text);
            string lastName = txtLastName.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string note = txtNote.Text.Trim();

            string query = @"UPDATE Members
                             SET LastName=@LastName, FirstName=@FirstName, Email=@Email,
                                 Phone=@Phone, Address=@Address, Note=@Note
                             WHERE MemberID=@MemberID";

            try
            {
                c.connect();
                using (SqlCommand cmd = new SqlCommand(query, c.conn))
                {
                    cmd.Parameters.AddWithValue("@MemberID", memberId);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Note", string.IsNullOrEmpty(note) ? (object)DBNull.Value : note);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("Sửa thành viên thành công!");
                    else
                        MessageBox.Show("Không tìm thấy thành viên để sửa!");
                }
                LoadMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMemberID.Text)) return;

            int memberId = int.Parse(txtMemberID.Text);

            DialogResult dr = MessageBox.Show($"Bạn có chắc muốn xóa thành viên {memberId} không?",
                                              "Xác nhận", MessageBoxButtons.YesNo);
            if (dr != DialogResult.Yes) return;

            string query = "DELETE FROM Members WHERE MemberID=@MemberID";

            try
            {
                c.connect();
                using (SqlCommand cmd = new SqlCommand(query, c.conn))
                {
                    cmd.Parameters.AddWithValue("@MemberID", memberId);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Xóa thành viên thành công!");
                        LoadMembers();
                        btnLammoi_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thành viên để xóa!");
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
            txtMemberID.Clear();
            txtLastName.Clear();
            txtFirstName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtNote.Clear();
            txtLastName.Focus();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];

                txtMemberID.Text = row.Cells["colMemberID"].Value?.ToString();
                txtLastName.Text = row.Cells["colLastName"].Value?.ToString();
                txtFirstName.Text = row.Cells["colFirstName"].Value?.ToString();
                txtEmail.Text = row.Cells["colEmail"].Value?.ToString();
                txtPhone.Text = row.Cells["colPhone"].Value?.ToString();
                txtAddress.Text = row.Cells["colAddress"].Value?.ToString();
                txtNote.Text = row.Cells["colNote"].Value?.ToString();
            }
        }
        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];

                int memberID = Convert.ToInt32(row.Cells["colMemberID"].Value); 
                string fullName = row.Cells["colLastName"].Value.ToString() + " " +
                                  row.Cells["colFirstName"].Value.ToString(); // ghép Họ + Tên

                FormSalaries frm = new FormSalaries(memberID, fullName);
                frm.ShowDialog();
            }
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
                string query = @"SELECT MemberID, LastName, FirstName, Email, Phone, Address, Note
                         FROM Members
                         WHERE (LastName + ' ' + FirstName) LIKE @Keyword";

                SqlDataAdapter da = new SqlDataAdapter(query, c.conn);
                da.SelectCommand.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

    }
}


