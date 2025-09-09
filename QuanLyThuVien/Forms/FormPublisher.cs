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
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên NXB không được để trống!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Publishers (PublisherName, Address, Phone, Note) VALUES (@name, @addr, @phone, @note)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@addr", txtAddress.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@note", txtNote.Text);
                cmd.ExecuteNonQuery();
            }

            LoadData();
            ClearForm();
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

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE Publishers SET PublisherName=@name, Address=@addr, Phone=@phone, Note=@note WHERE PublisherID=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@addr", txtAddress.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@note", txtNote.Text);
                cmd.ExecuteNonQuery();
            }

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
