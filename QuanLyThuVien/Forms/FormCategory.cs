using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class FormCategory : Form
    {
        connectData c = new connectData();
        SqlDataAdapter da;
        DataTable dt;

        public FormCategory()
        {
            InitializeComponent();
            LoadData();
        }
        // Kiểm tra tên thể loại đã tồn tại
        private bool IsCategoryNameExists(string categoryName)
        {
            string sql = "SELECT COUNT(*) FROM Categories WHERE CategoryName = @name";
            using (SqlCommand cmd = new SqlCommand(sql, c.conn))
            {
                cmd.Parameters.AddWithValue("@name", categoryName);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }


        // Load dữ liệu
        private void LoadData()
        {
            try
            {
                c.connect();
                string query = "SELECT CategoryID, CategoryName, Note FROM Categories";
                da = new SqlDataAdapter(query, c.conn);
                dt = new DataTable();
                da.Fill(dt);
                dgvCategory.DataSource = dt;
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
            txtCategoryName.Clear();
            txtNote.Clear();
        }

        // Thêm
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Tên thể loại không được để trống!");
                return;
            }

            try
            {
                c.connect();
                // Kiểm tra tên đã tồn tại chưa
                if (IsCategoryNameExists(txtCategoryName.Text))
                {
                    MessageBox.Show("Tên thể loại đã tồn tại!");
                    return;
                }
                string sql = "INSERT INTO Categories (CategoryName, Note) VALUES (@name, @note)";
                using (SqlCommand cmd = new SqlCommand(sql, c.conn))
                {
                    cmd.Parameters.AddWithValue("@name", txtCategoryName.Text);
                    cmd.Parameters.AddWithValue("@note", txtNote.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Thêm thể loại thành công!");
                LoadData();
                ClearForm();
            }
            finally
            {
                c.disconnect();
            }
        }

        // Sửa
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Tên thể loại không được để trống!");
                return;
            }
            if (dgvCategory.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một thể loại để sửa!");
                return;
            }

            int id = Convert.ToInt32(dgvCategory.CurrentRow.Cells["CategoryID"].Value);

            try
            {
                c.connect();
                string sql = "UPDATE Categories SET CategoryName=@name, Note=@note WHERE CategoryID=@id";
                using (SqlCommand cmd = new SqlCommand(sql, c.conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", txtCategoryName.Text);
                    cmd.Parameters.AddWithValue("@note", txtNote.Text);
                    cmd.ExecuteNonQuery();
                }
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
            if (dgvCategory.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một thể loại để xoá!");
                return;
            }

            int id = Convert.ToInt32(dgvCategory.CurrentRow.Cells["CategoryID"].Value);

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    c.connect();
                    string sql = "DELETE FROM Categories WHERE CategoryID=@id";
                    using (SqlCommand cmd = new SqlCommand(sql, c.conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Xoá thành công!");
                    LoadData();
                    ClearForm();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Foreign Key constraint
                    {
                        MessageBox.Show("Không thể xoá thể loại này vì có sách đang thuộc thể loại!",
                                        "Lỗi",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
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
                string sql = "SELECT CategoryID, CategoryName, Note FROM Categories WHERE CategoryName LIKE @name";
                SqlCommand cmd = new SqlCommand(sql, c.conn);
                cmd.Parameters.AddWithValue("@name", "%" + txtCategoryName.Text + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCategory.DataSource = dt;
            }
            finally
            {
                c.disconnect();
            }
        }

        // Click lên DataGridView -> hiển thị dữ liệu
        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCategory.Rows[e.RowIndex].Cells["CategoryID"].Value != null)
            {
                txtCategoryName.Text = dgvCategory.Rows[e.RowIndex].Cells["CategoryName"].Value?.ToString();
                txtNote.Text = dgvCategory.Rows[e.RowIndex].Cells["Note"].Value?.ToString();
            }
        }
    }
}
