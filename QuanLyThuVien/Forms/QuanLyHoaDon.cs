using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class QuanLyHoaDon : Form
    {
        connectData c = new connectData();
        SqlDataAdapter da;
        DataTable dt;

        public QuanLyHoaDon()
        {
            InitializeComponent();
            LoadHoaDon();
            LoadSach();
            LoadNhanVien();
            LoadKhachHang();
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];
                txtMaHoaDon.Text = row.Cells["Mã hóa đơn"].Value?.ToString();
                cbNhanVien.Text = row.Cells["Nhân viên lập"].Value?.ToString(); // từ Users
                txtNgayLap.Text = row.Cells["Ngày tạo"].Value?.ToString();
                cbKhachHang.Text = row.Cells["Khách hàng"].Value?.ToString();   // từ Members
                cbSach.Text = row.Cells["Tên sách"].Value?.ToString();
                txtGhiChu.Text = row.Cells["Ghi chú"].Value?.ToString();
            }
        }

        private void LoadHoaDon()
        {
            try
            {
                c.connect();
                string sql = @"
                    SELECT 
                        Borrowing.BorrowID AS [Mã hóa đơn], 
                        Borrowing.BorrowDate AS [Ngày tạo], 
                       U.FirstName + ' ' + U.LastName AS [Nhân viên lập],
                        M.FirstName + ' ' + M.LastName AS [Khách hàng], 
                        B.Title AS [Tên sách], 
                        Borrowing.Note AS [Ghi chú]
                    FROM Borrowing
                    INNER JOIN Books B ON Borrowing.BookID = B.BookID
                    INNER JOIN Members M ON Borrowing.MemberID = M.MemberID
                    INNER JOIN Users U ON Borrowing.UserID = U.UserID
                    WHERE U.Role = 'Staff'"; // chỉ lấy nhân viên lập
                da = new SqlDataAdapter(sql, c.conn);
                dt = new DataTable();
                da.Fill(dt);
                dgvHoaDon.DataSource = dt;
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

        private void LoadSach()
        {
            try
            {
                c.connect();
                string sql = "SELECT BookID, Title FROM Books";
                SqlDataAdapter da = new SqlDataAdapter(sql, c.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbSach.DataSource = dt;
                cbSach.DisplayMember = "Title";
                cbSach.ValueMember = "BookID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sách: " + ex.Message);
            }
            finally
            {
                c.disconnect();
            }
        }

        private void LoadNhanVien()
        {
            try
            {
                c.connect();
                string sql = "SELECT UserID, FirstName + ' ' + LastName AS FullName FROM Users WHERE Role = 'Staff'";
                SqlDataAdapter da = new SqlDataAdapter(sql, c.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbNhanVien.DataSource = dt;
                cbNhanVien.DisplayMember = "FullName";
                cbNhanVien.ValueMember = "UserID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhân viên: " + ex.Message);
            }
            finally
            {
                c.disconnect();
            }
        }

        private void LoadKhachHang()
        {
            try
            {
                c.connect();
                string sql = "SELECT MemberID, FirstName + ' ' + LastName AS FullName FROM Members";
                SqlDataAdapter da = new SqlDataAdapter(sql, c.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbKhachHang.DataSource = dt;
                cbKhachHang.DisplayMember = "FullName";
                cbKhachHang.ValueMember = "MemberID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khách hàng: " + ex.Message);
            }
            finally
            {
                c.disconnect();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                c.connect();

                // Thêm hóa đơn (Borrowing)
                string sql = "INSERT INTO Borrowing (UserID, MemberID, BookID, BorrowDate, Note) " +
                             "VALUES (@UserID, @MemberID, @BookID, @BorrowDate, @Note); " +
                             "SELECT CAST(SCOPE_IDENTITY() AS INT)";
                int borrowID;
                using (SqlCommand cmd = new SqlCommand(sql, c.conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", cbNhanVien.SelectedValue);   // nhân viên
                    cmd.Parameters.AddWithValue("@MemberID", cbKhachHang.SelectedValue); // khách hàng
                    cmd.Parameters.AddWithValue("@BookID", cbSach.SelectedValue);

                    DateTime borrowDate = string.IsNullOrEmpty(txtNgayLap.Text) ? DateTime.Now : DateTime.Parse(txtNgayLap.Text);
                    cmd.Parameters.AddWithValue("@BorrowDate", borrowDate);

                    cmd.Parameters.AddWithValue("@Note", string.IsNullOrEmpty(txtGhiChu.Text) ? DBNull.Value : (object)txtGhiChu.Text);

                    borrowID = (int)cmd.ExecuteScalar();
                }

                // Thêm chi tiết hóa đơn
                string sqlDetail = "INSERT INTO BorrowingDetails (BorrowID, Quantity, Note) " +
                                   "VALUES (@BorrowID, @Quantity, @Note)";
                using (SqlCommand cmdDetail = new SqlCommand(sqlDetail, c.conn))
                {
                    cmdDetail.Parameters.AddWithValue("@BorrowID", borrowID);
                    cmdDetail.Parameters.AddWithValue("@Quantity", 1);
                    cmdDetail.Parameters.AddWithValue("@Note", string.IsNullOrEmpty(txtGhiChu.Text) ? DBNull.Value : (object)txtGhiChu.Text);
                    cmdDetail.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm hóa đơn thành công!");
                LoadHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm hóa đơn: " + ex.Message);
            }
            finally
            {
                c.disconnect();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHoaDon.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần sửa!");
                return;
            }

            try
            {
                c.connect();
                string sql = "UPDATE Borrowing SET UserID = @UserID, MemberID = @MemberID, BookID = @BookID, BorrowDate = @BorrowDate, Note = @Note WHERE BorrowID = @BorrowID";

                using (SqlCommand cmd = new SqlCommand(sql, c.conn))
                {
                    cmd.Parameters.AddWithValue("@BorrowID", txtMaHoaDon.Text);
                    cmd.Parameters.AddWithValue("@UserID", cbNhanVien.SelectedValue);   // nhân viên
                    cmd.Parameters.AddWithValue("@MemberID", cbKhachHang.SelectedValue); // khách hàng
                    cmd.Parameters.AddWithValue("@BookID", cbSach.SelectedValue);

                    DateTime borrowDate = string.IsNullOrEmpty(txtNgayLap.Text) ? DateTime.Now : DateTime.Parse(txtNgayLap.Text);
                    cmd.Parameters.AddWithValue("@BorrowDate", borrowDate);

                    cmd.Parameters.AddWithValue("@Note", string.IsNullOrEmpty(txtGhiChu.Text) ? DBNull.Value : (object)txtGhiChu.Text);

                    int rows = cmd.ExecuteNonQuery();
                    MessageBox.Show(rows > 0 ? "Cập nhật hóa đơn thành công!" : "Không tìm thấy hóa đơn để cập nhật!");
                    LoadHoaDon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
            finally
            {
                c.disconnect();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHoaDon.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa!");
                return;
            }

            try
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc muốn xóa hóa đơn này?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    c.connect();
                    string sqlDetail = "DELETE FROM BorrowingDetails WHERE BorrowID = @BorrowID";
                    using (SqlCommand cmdDetail = new SqlCommand(sqlDetail, c.conn))
                    {
                        cmdDetail.Parameters.AddWithValue("@BorrowID", txtMaHoaDon.Text);
                        cmdDetail.ExecuteNonQuery();
                    }

                    string sql = "DELETE FROM Borrowing WHERE BorrowID = @BorrowID";
                    using (SqlCommand cmd = new SqlCommand(sql, c.conn))
                    {
                        cmd.Parameters.AddWithValue("@BorrowID", txtMaHoaDon.Text);
                        int rows = cmd.ExecuteNonQuery();
                        MessageBox.Show(rows > 0 ? "Xóa hóa đơn thành công!" : "Không tìm thấy hóa đơn để xóa!");
                        LoadHoaDon();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
            finally
            {
                c.disconnect();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHoaDon.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm!");
                return;
            }

            try
            {
                c.connect();
                string sql = @"
                    SELECT 
                        Borrowing.BorrowID AS [Mã hóa đơn], 
                        Borrowing.BorrowDate AS [Ngày tạo], 
                        U.FirstName+ ' ' + U.LastName AS [Nhân viên lập], 
                        M.FirstName + ' ' + M.LastName AS [Khách hàng], 
                        Borrowing.Note AS [Ghi chú]
                    FROM Borrowing
                    INNER JOIN Members M ON Borrowing.MemberID = M.MemberID
                    INNER JOIN Users U ON Borrowing.UserID = U.UserID
                    WHERE Borrowing.BorrowID LIKE @Search";

                using (SqlCommand cmd = new SqlCommand(sql, c.conn))
                {
                    cmd.Parameters.AddWithValue("@Search", "%" + txtMaHoaDon.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                        dgvHoaDon.DataSource = dt;
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu phù hợp!");
                        dgvHoaDon.DataSource = null;
                    }
                }
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

        private void dgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int borrowId = Convert.ToInt32(dgvHoaDon.Rows[e.RowIndex].Cells["Mã hóa đơn"].Value);
                ChiTietHoaDon frm = new ChiTietHoaDon(borrowId);
                frm.ShowDialog();
            }
        }
    }
}
