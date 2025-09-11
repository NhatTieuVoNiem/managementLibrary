using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien.Forms
{
    public partial class FormAuthor : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=libraryManagement;Integrated Security=True;";

        public FormAuthor()
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
                    string query = "SELECT AuthorID, LastName, FirstName, Biography, Note FROM Authors";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAuthor.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
                }
            }
        }

        private void ClearForm()
        {
            txtLastName.Clear();
            txtFirstName.Clear();
            txtBiography.Clear();
            txtNote.Clear();
        }

        // Thêm
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Họ và Tên tác giả không được để trống!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Authors (LastName, FirstName, Biography, Note) VALUES (@lname, @fname, @bio, @note)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@lname", txtLastName.Text);
                cmd.Parameters.AddWithValue("@fname", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@bio", txtBiography.Text);
                cmd.Parameters.AddWithValue("@note", txtNote.Text);
                cmd.ExecuteNonQuery();
            }

            LoadData();
            ClearForm();
        }

        // Sửa
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAuthor.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một tác giả để sửa!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Họ và Tên tác giả không được để trống!");
                return;
            }

            int id = Convert.ToInt32(dgvAuthor.CurrentRow.Cells["AuthorID"].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"UPDATE Authors 
                               SET LastName=@lname, FirstName=@fname, Biography=@bio, Note=@note 
                               WHERE AuthorID=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@lname", txtLastName.Text);
                cmd.Parameters.AddWithValue("@fname", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@bio", txtBiography.Text);
                cmd.Parameters.AddWithValue("@note", txtNote.Text);
                cmd.ExecuteNonQuery();
            }

            LoadData();
            ClearForm();
        }

        // Xóa
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
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = "DELETE FROM Authors WHERE AuthorID = @id";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }

                    LoadData();
                    ClearForm();
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
            }
        }

        // Tìm kiếm theo tên (LastName + FirstName)
        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Authors WHERE LastName LIKE @kw OR FirstName LIKE @kw";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@kw", "%" + txtLastName.Text + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAuthor.DataSource = dt;
            }
        }

        // Làm mới
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearForm();
        }

        // CellClick hiển thị dữ liệu lên textbox
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
