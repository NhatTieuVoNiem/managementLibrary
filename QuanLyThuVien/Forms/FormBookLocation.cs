using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien.Forms
{
    public partial class FormBookLocation : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=libraryManagement;Integrated Security=True;";

        public FormBookLocation()
        {
            InitializeComponent();
            LoadData();
        }

        // Load dữ liệu
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT LocationID, ShelfCode, Floor, Room, Note FROM BookLocations";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvBookLocation.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
                }
            }
        }

        private void ClearForm()
        {
            txtShelfCode.Clear();
            txtFloor.Clear();
            txtRoom.Clear();
            txtNote.Clear();
        }

        // Thêm
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtShelfCode.Text) || string.IsNullOrWhiteSpace(txtFloor.Text) || string.IsNullOrWhiteSpace(txtRoom.Text))
            {
                MessageBox.Show("Mã kệ, tầng và phòng không được để trống!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO BookLocations (ShelfCode, Floor, Room, Note) VALUES (@shelf, @floor, @room, @note)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@shelf", txtShelfCode.Text);
                cmd.Parameters.AddWithValue("@floor", txtFloor.Text);
                cmd.Parameters.AddWithValue("@room", txtRoom.Text);
                cmd.Parameters.AddWithValue("@note", txtNote.Text);
                cmd.ExecuteNonQuery();
            }

            LoadData();
            ClearForm();
        }

        // Sửa
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBookLocation.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một vị trí để sửa!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtShelfCode.Text) || string.IsNullOrWhiteSpace(txtFloor.Text) || string.IsNullOrWhiteSpace(txtRoom.Text))
            {
                MessageBox.Show("Mã kệ, tầng và phòng không được để trống!");
                return;
            }

            int id = Convert.ToInt32(dgvBookLocation.CurrentRow.Cells["LocationID"].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"UPDATE BookLocations 
                               SET ShelfCode=@shelf, Floor=@floor, Room=@room, Note=@note 
                               WHERE LocationID=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@shelf", txtShelfCode.Text);
                cmd.Parameters.AddWithValue("@floor", txtFloor.Text);
                cmd.Parameters.AddWithValue("@room", txtRoom.Text);
                cmd.Parameters.AddWithValue("@note", txtNote.Text);
                cmd.ExecuteNonQuery();
            }

            LoadData();
            ClearForm();
        }

        // Xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBookLocation.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một vị trí để xoá!");
                return;
            }

            int id = Convert.ToInt32(dgvBookLocation.CurrentRow.Cells["LocationID"].Value);

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xoá vị trí này?",
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
                        string sql = "DELETE FROM BookLocations WHERE LocationID = @id";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }

                    LoadData();
                    ClearForm();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // FK constraint
                    {
                        MessageBox.Show("Không thể xoá vì có sách đang để vị trí này!",
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

        // Tìm kiếm theo ShelfCode hoặc Room
        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM BookLocations WHERE ShelfCode LIKE @kw OR Room LIKE @kw";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@kw", "%" + txtShelfCode.Text + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvBookLocation.DataSource = dt;
            }
        }

        // Làm mới
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearForm();
        }

        // Hiển thị lên textbox khi chọn row
        private void dgvBookLocation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvBookLocation.Rows[e.RowIndex].Cells["LocationID"].Value != null)
            {
                txtShelfCode.Text = dgvBookLocation.Rows[e.RowIndex].Cells["ShelfCode"].Value?.ToString();
                txtFloor.Text = dgvBookLocation.Rows[e.RowIndex].Cells["Floor"].Value?.ToString();
                txtRoom.Text = dgvBookLocation.Rows[e.RowIndex].Cells["Room"].Value?.ToString();
                txtNote.Text = dgvBookLocation.Rows[e.RowIndex].Cells["Note"].Value?.ToString();
            }
        }
    }
}
