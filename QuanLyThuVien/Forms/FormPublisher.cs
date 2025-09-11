using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyThuVien.Forms
{
    public partial class FormPublisher : Form
    {
        connectData c = new connectData();

        public FormPublisher()
        {
            InitializeComponent();
            LoadData();
        }

        // Load dữ liệu vào DataGridView
        private void LoadData()
        {
            try
            {
                c.connect();
                string query = "SELECT PublisherID, PublisherName, Address, Phone, Note FROM Publishers";
                SqlDataAdapter da = new SqlDataAdapter(query, c.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPublisher.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                c.disconnect();
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

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Tên NXB không được để trống!");
                return;
            }

            if (!string.IsNullOrWhiteSpace(phone) && !Regex.IsMatch(phone, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại phải gồm đúng 10 chữ số!");
                return;
            }

            try
            {
                c.connect();

                // Check trùng tên
                string checkSql = "SELECT COUNT(*) FROM Publishers WHERE PublisherName = @name";
                SqlCommand checkCmd = new SqlCommand(checkSql, c.conn);
                checkCmd.Parameters.AddWithValue("@name", name);
                int exists = (int)checkCmd.ExecuteScalar();
                if (exists > 0)
                {
                    MessageBox.Show("Tên NXB đã tồn tại!");
                    return;
                }

                string sql = "INSERT INTO Publishers (PublisherName, Address, Phone, Note) VALUES (@name, @addr, @phone, @note)";
                SqlCommand cmd = new SqlCommand(sql, c.conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@addr", address);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@note", note);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm NXB thành công!");
                LoadData();
                ClearForm();
            }
            finally
            {
                c.disconnect();
            }
        }

        // Sửa
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPublisher.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một NXB để sửa!");
                return;
            }

            int id = Convert.ToInt32(dgvPublisher.CurrentRow.Cells["PublisherID"].Value);
            string name = txtName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string note = txtNote.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Tên NXB không được để trống!");
                return;
            }

            if (!string.IsNullOrWhiteSpace(phone) && !Regex.IsMatch(phone, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại phải gồm đúng 10 chữ số!");
                return;
            }

            try
            {
                c.connect();

                string checkSql = "SELECT COUNT(*) FROM Publishers WHERE PublisherName = @name AND PublisherID <> @id";
                SqlCommand checkCmd = new SqlCommand(checkSql, c.conn);
                checkCmd.Parameters.AddWithValue("@name", name);
                checkCmd.Parameters.AddWithValue("@id", id);
                int exists = (int)checkCmd.ExecuteScalar();
                if (exists > 0)
                {
                    MessageBox.Show("Tên NXB đã tồn tại!");
                    return;
                }

                string sql = "UPDATE Publishers SET PublisherName=@name, Address=@addr, Phone=@phone, Note=@note WHERE PublisherID=@id";
                SqlCommand cmd = new SqlCommand(sql, c.conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@addr", address);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@note", note);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Cập nhật thành công!");
                LoadData();
                ClearForm();
            }
            finally
            {
                c.disconnect();
            }
        }

        // Xoá
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPublisher.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một NXB để xoá!");
                return;
            }

            int id = Convert.ToInt32(dgvPublisher.CurrentRow.Cells["PublisherID"].Value);

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    c.connect();
                    string sql = "DELETE FROM Publishers WHERE PublisherID=@id";
                    SqlCommand cmd = new SqlCommand(sql, c.conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xoá thành công!");
                    LoadData();
                    ClearForm();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        MessageBox.Show("Không thể xoá vì có sách thuộc NXB này!");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi SQL: " + ex.Message);
                    }
                }
                finally
                {
                    c.disconnect();
                }
            }
        }

        // Tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                c.connect();
                string sql = "SELECT * FROM Publishers WHERE PublisherName LIKE @name";
                SqlCommand cmd = new SqlCommand(sql, c.conn);
                cmd.Parameters.AddWithValue("@name", "%" + txtName.Text + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPublisher.DataSource = dt;
            }
            finally
            {
                c.disconnect();
            }
        }

        // Làm mới
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearForm();
        }

        // Hiển thị dữ liệu khi click
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
