using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class FormCategory : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=libraryManagement;Integrated Security=True;";

        public FormCategory()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT CategoryID, CategoryName, Note FROM Categories"; // table Category
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCategory.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
                }
            }
        }

        // Thêm
        private void btnInsert_Click(object sender, EventArgs e) 
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Tên thể loại không được để trống!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Categories (CategoryName, Note) VALUES (@name, @note)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", txtCategoryName.Text);
                cmd.Parameters.AddWithValue("@note", txtNote.Text);
                cmd.ExecuteNonQuery();
            }

            LoadData();
            ClearForm();
        }

        // Sửa
        private void btnUpdate_Click(object sender, EventArgs e) 
        {
            if (dgvCategory.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một thể loại để sửa!");
                return;
            }

            int id = Convert.ToInt32(dgvCategory.CurrentRow.Cells["ID"].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE Categories SET CategoryName=@name, Note=@note WHERE ID=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", txtCategoryName.Text);
                cmd.Parameters.AddWithValue("@note", txtNote.Text);
                cmd.ExecuteNonQuery();
            }

            LoadData();
            ClearForm();
        }

        // Xoá
        private void btnDelete_Click(object sender, EventArgs e) 
        {
            if (dgvCategory.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một thể loại để xoá!");
                return;
            }

            int id = Convert.ToInt32(dgvCategory.CurrentRow.Cells["ID"].Value);

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM Categories WHERE ID=@id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
                ClearForm();
            }
        }

        // Tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e) 
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Categories WHERE CategoryName LIKE @name";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", "%" + txtCategoryName.Text + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCategory.DataSource = dt;
            }
        }

        // Khi click chọn 1 dòng trong DataGridView -> hiển thị lên textbox
        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCategory.Rows[e.RowIndex].Cells["ID"].Value != null)
            {
                txtCategoryName.Text = dgvCategory.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();
                txtNote.Text = dgvCategory.Rows[e.RowIndex].Cells["Note"].Value.ToString();
            }
        }

        private void ClearForm()
        {
            txtCategoryName.Clear();
            txtNote.Clear();
        }

    }
}
