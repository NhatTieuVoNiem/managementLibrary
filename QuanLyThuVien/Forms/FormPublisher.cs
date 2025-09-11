using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyThuVien.Forms
{
    public partial class FormPublisher : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=libraryManagement;Integrated Security=True;";

        public FormPublisher()
        {
            InitializeComponent();
            LoadData();
        }

        // Load dữ liệu vào DataGridView
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT PublisherID, PublisherName, Address, Phone, Note FROM Publishers";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPublisher.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
                }
            }
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtNote.Clear();
        }

        // Thêm
        private void btnInsert_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string note = txtNote.Text.Trim();

            // 1. Kiểm tra tên NXB
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Tên NXB không được để trống!",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra số điện thoại
            if (!string.IsNullOrWhiteSpace(phone))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\d{10}$"))
                {
                    MessageBox.Show("Số điện thoại phải gồm đúng 10 chữ số!",
                                    "Lỗi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
            }


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 3. Check trùng tên NXB
                string checkSql = "SELECT COUNT(*) FROM Publishers WHERE PublisherName = @name";
                SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                checkCmd.Parameters.AddWithValue("@name", name);

                int exists = (int)checkCmd.ExecuteScalar();
                if (exists > 0)
                {
                    MessageBox.Show("Tên NXB đã tồn tại trong hệ thống!",
                                    "Lỗi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // 4. Thêm NXB mới
                string sql = "INSERT INTO Publishers (PublisherName, Address, Phone, Note) " +
                             "VALUES (@name, @addr, @phone, @note)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@addr", address);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@note", note);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Thêm NXB thành công!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            LoadData();
            ClearForm();
        }


        // Sửa
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPublisher.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một NXB để sửa!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvPublisher.CurrentRow.Cells["PublisherID"].Value);

            string name = txtName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string note = txtNote.Text.Trim();

            // 1. Kiểm tra tên NXB
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Tên NXB không được để trống!",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra số điện thoại (phải đúng 10 số)
            if (!string.IsNullOrWhiteSpace(phone))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\d{10}$"))
                {
                    MessageBox.Show("Số điện thoại phải gồm đúng 10 chữ số!",
                                    "Lỗi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 3. Check trùng tên NXB (ngoại trừ chính nó)
                string checkSql = "SELECT COUNT(*) FROM Publishers WHERE PublisherName = @name AND PublisherID <> @id";
                SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                checkCmd.Parameters.AddWithValue("@name", name);
                checkCmd.Parameters.AddWithValue("@id", id);

                int exists = (int)checkCmd.ExecuteScalar();
                if (exists > 0)
                {
                    MessageBox.Show("Tên NXB đã tồn tại trong hệ thống!",
                                    "Lỗi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // 4. Cập nhật
                string sql = "UPDATE Publishers SET PublisherName=@name, Address=@addr, Phone=@phone, Note=@note WHERE PublisherID=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@addr", address);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@note", note);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cập nhật NXB thành công!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            LoadData();
            ClearForm();
        }


        // Xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPublisher.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một NXB để xoá!");
                return;
            }

            int id = Convert.ToInt32(dgvPublisher.CurrentRow.Cells["PublisherID"].Value);

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xoá NXB này?",
                                              "Xác nhận",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = "DELETE FROM Publishers WHERE PublisherID = @id";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }

                    LoadData();
                    ClearForm();
                }
                catch (SqlException ex)
                {
                    // Bắt lỗi ràng buộc FK
                    if (ex.Number == 547) // 547 = Foreign Key violation
                    {
                        MessageBox.Show("Không thể xoá NXB này vì có sách được xuất bản từ NXB này!",
                                        "Lỗi",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi SQL: " + ex.Message);
                    }
                }
            }
        }


        // Tìm kiếm theo tên
        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Publishers WHERE PublisherName LIKE @name";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", "%" + txtName.Text + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPublisher.DataSource = dt;
            }
        }

        // Làm mới
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearForm();
        }

        // CellClick hiển thị dữ liệu lên textbox
        private void dgvPublisher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPublisher.Rows[e.RowIndex].Cells["PublisherID"].Value != null)
            {
                txtName.Text = dgvPublisher.Rows[e.RowIndex].Cells["PublisherName"].Value?.ToString();
                txtAddress.Text = dgvPublisher.Rows[e.RowIndex].Cells["Address"].Value?.ToString();
                txtPhone.Text = dgvPublisher.Rows[e.RowIndex].Cells["Phone"].Value?.ToString();
                txtNote.Text = dgvPublisher.Rows[e.RowIndex].Cells["Note"].Value?.ToString();
            }
        }
    }
}
