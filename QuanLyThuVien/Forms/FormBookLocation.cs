using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien.Forms
{
    public partial class FormBookLocation : Form
    {
        connectData c = new connectData();
        SqlDataAdapter da;
        DataTable dt;

        public FormBookLocation()
        {
            InitializeComponent();
            LoadData();
        }

        // Load dữ liệu
        private void LoadData()
        {
            try
            {
                c.connect();
                string query = "SELECT LocationID, ShelfCode, Floor, Room, Note FROM BookLocations";
                da = new SqlDataAdapter(query, c.conn);
                dt = new DataTable();
                da.Fill(dt);
                dgvBookLocation.DataSource = dt;
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
            txtShelfCode.Clear();
            txtFloor.Clear();
            txtRoom.Clear();
            txtNote.Clear();
        }

        // Thêm
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtShelfCode.Text) ||
                string.IsNullOrWhiteSpace(txtFloor.Text) ||
                string.IsNullOrWhiteSpace(txtRoom.Text))
            {
                MessageBox.Show("Mã kệ, tầng và phòng không được để trống!");
                return;
            }

            try
            {
                c.connect();
                string sql = "INSERT INTO BookLocations (ShelfCode, Floor, Room, Note) " +
                             "VALUES (@shelf, @floor, @room, @note)";
                using (SqlCommand cmd = new SqlCommand(sql, c.conn))
                {
                    cmd.Parameters.AddWithValue("@shelf", txtShelfCode.Text);
                    cmd.Parameters.AddWithValue("@floor", txtFloor.Text);
                    cmd.Parameters.AddWithValue("@room", txtRoom.Text);
                    cmd.Parameters.AddWithValue("@note", txtNote.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Thêm vị trí thành công!", "Thông báo");
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
            if (dgvBookLocation.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một vị trí để sửa!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtShelfCode.Text) ||
                string.IsNullOrWhiteSpace(txtFloor.Text) ||
                string.IsNullOrWhiteSpace(txtRoom.Text))
            {
                MessageBox.Show("Mã kệ, tầng và phòng không được để trống!");
                return;
            }

            int id = Convert.ToInt32(dgvBookLocation.CurrentRow.Cells["LocationID"].Value);

            try
            {
                c.connect();
                string sql = @"UPDATE BookLocations 
                               SET ShelfCode=@shelf, Floor=@floor, Room=@room, Note=@note 
                               WHERE LocationID=@id";

                using (SqlCommand cmd = new SqlCommand(sql, c.conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@shelf", txtShelfCode.Text);
                    cmd.Parameters.AddWithValue("@floor", txtFloor.Text);
                    cmd.Parameters.AddWithValue("@room", txtRoom.Text);
                    cmd.Parameters.AddWithValue("@note", txtNote.Text);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cập nhật thành công!", "Thông báo");
                LoadData();
                ClearForm();
            }
            finally
            {
                c.disconnect();
            }
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
                    c.connect();
                    string sql = "DELETE FROM BookLocations WHERE LocationID = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, c.conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Xoá thành công!", "Thông báo");
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
                finally
                {
                    c.disconnect();
                }
            }
        }

        // Tìm kiếm theo ShelfCode hoặc Room
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                c.connect();
                string sql = "SELECT * FROM BookLocations WHERE ShelfCode LIKE @kw OR Room LIKE @kw";
                SqlCommand cmd = new SqlCommand(sql, c.conn);
                cmd.Parameters.AddWithValue("@kw", "%" + txtShelfCode.Text.Trim() + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvBookLocation.DataSource = dt;
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
