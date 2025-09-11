using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien.Forms
{
    public partial class FormAuthor : Form
    {
        connectData c = new connectData(); // dùng class connectData

        public FormAuthor()
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
                string query = "SELECT AuthorID, LastName, FirstName, Biography, Note FROM Authors";
                SqlDataAdapter da = new SqlDataAdapter(query, c.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAuthor.DataSource = dt;
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
            txtLastName.Clear();
            txtFirstName.Clear();
            txtBiography.Clear();
            txtNote.Clear();
        }

        // ===== Thêm =====
        private void btnInsert_Click(object sender, EventArgs e)
        {
            string lastName = txtLastName.Text.Trim();
            string firstName = txtFirstName.Text.Trim();

            if (string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Họ và Tên tác giả không được để trống!");
                return;
            }

            try
            {
                c.connect();

                // Check trùng lặp (Họ + Tên)
                string checkSql = "SELECT COUNT(*) FROM Authors WHERE LastName=@lname AND FirstName=@fname";
                SqlCommand checkCmd = new SqlCommand(checkSql, c.conn);
                checkCmd.Parameters.AddWithValue("@lname", lastName);
                checkCmd.Parameters.AddWithValue("@fname", firstName);

                int exists = (int)checkCmd.ExecuteScalar();
                if (exists > 0)
                {
                    MessageBox.Show("Tác giả này đã tồn tại!");
                    return;
                }

                // Insert
                string sql = "INSERT INTO Authors (LastName, FirstName, Biography, Note) VALUES (@lname, @fname, @bio, @note)";
                SqlCommand cmd = new SqlCommand(sql, c.conn);
                cmd.Parameters.AddWithValue("@lname", lastName);
                cmd.Parameters.AddWithValue("@fname", firstName);
                cmd.Parameters.AddWithValue("@bio", txtBiography.Text.Trim());
                cmd.Parameters.AddWithValue("@note", txtNote.Text.Trim());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm tác giả thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
            finally
            {
                c.disconnect();
            }

            LoadData();
            ClearForm();
        }

        // ===== Sửa =====
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAuthor.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một tác giả để sửa!");
                return;
            }

            string lastName = txtLastName.Text.Trim();
            string firstName = txtFirstName.Text.Trim();

            if (string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Họ và Tên tác giả không được để trống!");
                return;
            }

            int id = Convert.ToInt32(dgvAuthor.CurrentRow.Cells["AuthorID"].Value);

            try
            {
                c.connect();

                // Check trùng lặp (ngoại trừ chính nó)
                string checkSql = "SELECT COUNT(*) FROM Authors WHERE LastName=@lname AND FirstName=@fname AND AuthorID <> @id";
                SqlCommand checkCmd = new SqlCommand(checkSql, c.conn);
                checkCmd.Parameters.AddWithValue("@lname", lastName);
                checkCmd.Parameters.AddWithValue("@fname", firstName);
                checkCmd.Parameters.AddWithValue("@id", id);

                int exists = (int)checkCmd.ExecuteScalar();
                if (exists > 0)
                {
                    MessageBox.Show("Tác giả này đã tồn tại!");
                    return;
                }

                // Update
                string sql = @"UPDATE Authors 
                               SET LastName=@lname, FirstName=@fname, Biography=@bio, Note=@note 
                               WHERE AuthorID=@id";
                SqlCommand cmd = new SqlCommand(sql, c.conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@lname", lastName);
                cmd.Parameters.AddWithValue("@fname", firstName);
                cmd.Parameters.AddWithValue("@bio", txtBiography.Text.Trim());
                cmd.Parameters.AddWithValue("@note", txtNote.Text.Trim());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Sửa tác giả thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
            }
            finally
            {
                c.disconnect();
            }

            LoadData();
            ClearForm();
        }

        // ===== Xoá =====
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAuthor.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một tác giả để xoá!");
                return;
            }

            int id = Convert.ToInt32(dgvAuthor.CurrentRow.Cells["AuthorID"].Value);

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xoá tác giả này?",
                                              "Xác nhận",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    c.connect();
                    string sql = "DELETE FROM Authors WHERE AuthorID = @id";
                    SqlCommand cmd = new SqlCommand(sql, c.conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xoá tác giả thành công!");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // ràng buộc FK
                    {
                        MessageBox.Show("Không thể xoá tác giả này vì đang có sách của tác giả này!",
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

                LoadData();
                ClearForm();
            }
        }

        // ===== Tìm kiếm =====
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                c.connect();
                string sql = "SELECT * FROM Authors WHERE LastName LIKE @kw OR FirstName LIKE @kw";
                SqlCommand cmd = new SqlCommand(sql, c.conn);
                cmd.Parameters.AddWithValue("@kw", "%" + txtLastName.Text.Trim() + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAuthor.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
            finally
            {
                c.disconnect();
            }
        }

        // ===== Làm mới =====
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearForm();
        }

        // ===== Click vào DataGridView => hiển thị dữ liệu lên textbox =====
        private void dgvAuthor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAuthor.Rows[e.RowIndex].Cells["AuthorID"].Value != null)
            {
                txtLastName.Text = dgvAuthor.Rows[e.RowIndex].Cells["LastName"].Value?.ToString();
                txtFirstName.Text = dgvAuthor.Rows[e.RowIndex].Cells["FirstName"].Value?.ToString();
                txtBiography.Text = dgvAuthor.Rows[e.RowIndex].Cells["Biography"].Value?.ToString();
                txtNote.Text = dgvAuthor.Rows[e.RowIndex].Cells["Note"].Value?.ToString();
            }
        }
    }
}
