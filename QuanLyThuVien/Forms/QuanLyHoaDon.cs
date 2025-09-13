using DocumentFormat.OpenXml.Office.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
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
                cbNhanVien.Text = row.Cells["Nhân viên lập"].Value?.ToString();
                txtNgayLap.Text = row.Cells["Ngày tạo"].Value?.ToString();
                cbKhachHang.Text = row.Cells["Khách hàng"].Value?.ToString();
                cbSach.Text = row.Cells["Tên sách"].Value?.ToString();
                txtGhiChu.Text = row.Cells["Ghi Chú"].Value?.ToString();
            }
        }

        private void LoadHoaDon()
        {
            try
            {
                c.connect();
                string sql = "SELECT Borrowing.BorrowID AS [Mã hóa đơn], Borrowing.BorrowDate AS [Ngày tạo], Members.FirstName AS [Nhân viên lập], Users.FullName AS [Khách hàng], Books.Title AS [Tên sách], Borrowing.Note AS [Ghi chú] FROM  Borrowing INNER JOIN Books ON Borrowing.BookID = Books.BookID INNER JOIN  Users ON Borrowing.UserID = Users.UserID INNER JOIN  Members ON Borrowing.MemberID = Members.MemberID";
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
                string sql = "SELECT MemberID, FirstName + ' ' + LastName AS FullName FROM Members";
                SqlDataAdapter da = new SqlDataAdapter(sql, c.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbNhanVien.DataSource = dt;
                cbNhanVien.DisplayMember = "FullName";  
                cbNhanVien.ValueMember = "MemberID";    
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
                string sql = "SELECT UserID, FullName FROM Users";
                SqlDataAdapter da = new SqlDataAdapter(sql, c.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbKhachHang.DataSource = dt;
                cbKhachHang.DisplayMember = "FullName";  
                cbKhachHang.ValueMember = "UserID";      
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

                // 1. Thêm hóa đơn và lấy BorrowID vừa tạo
                string sql = "INSERT INTO Borrowing (MemberID, BookID, BorrowDate, Note, UserID) " +
                             "VALUES (@MemberID, @BookID, @BorrowDate, @Note, @UserID); " +
                             "SELECT CAST(SCOPE_IDENTITY() AS INT)";
                int borrowID;
                using (SqlCommand cmd = new SqlCommand(sql, c.conn))
                {
                    cmd.Parameters.AddWithValue("@MemberID", cbNhanVien.SelectedValue);
                    cmd.Parameters.AddWithValue("@UserID", cbKhachHang.SelectedValue);
                    cmd.Parameters.AddWithValue("@BookID", cbSach.SelectedValue);

                    DateTime borrowDate = string.IsNullOrEmpty(txtNgayLap.Text) ? DateTime.Now : DateTime.Parse(txtNgayLap.Text);
                    cmd.Parameters.AddWithValue("@BorrowDate", borrowDate);

                    if (string.IsNullOrEmpty(txtGhiChu.Text))
                        cmd.Parameters.AddWithValue("@Note", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Note", txtGhiChu.Text);

                    // Lấy ID vừa tạo
                    borrowID = (int)cmd.ExecuteScalar();
                }

                // 2. Thêm chi tiết hóa đơn
                string sqlDetail = "INSERT INTO BorrowingDetails (BorrowID, Quantity, Note) " +
                                   "VALUES (@BorrowID, @Quantity, @Note)";
                using (SqlCommand cmdDetail = new SqlCommand(sqlDetail, c.conn))
                {
                    cmdDetail.Parameters.AddWithValue("@BorrowID", borrowID);
                    cmdDetail.Parameters.AddWithValue("@Quantity", 1);
                    if (string.IsNullOrEmpty(txtGhiChu.Text))
                        cmdDetail.Parameters.AddWithValue("@Note", DBNull.Value);
                    else
                        cmdDetail.Parameters.AddWithValue("@Note", txtGhiChu.Text);
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
                string sql = "UPDATE Borrowing SET MemberID = @MemberID,  BookID = @BookID, BorrowDate = @BorrowDate, Note = @Note,  UserID = @UserID WHERE BorrowID = @BorrowID";

                using (SqlCommand cmd = new SqlCommand(sql, c.conn))
                {
                    cmd.Parameters.AddWithValue("@BorrowID", txtMaHoaDon.Text);
                    cmd.Parameters.AddWithValue("@MemberID", cbNhanVien.SelectedValue);   
                    cmd.Parameters.AddWithValue("@UserID", cbKhachHang.SelectedValue);   
                    cmd.Parameters.AddWithValue("@BookID", cbSach.SelectedValue);        

                    DateTime borrowDate;
                    if (string.IsNullOrEmpty(txtNgayLap.Text))
                        borrowDate = DateTime.Now;
                    else
                        borrowDate = DateTime.Parse(txtNgayLap.Text);

                    cmd.Parameters.AddWithValue("@BorrowDate", borrowDate);

                    if (string.IsNullOrEmpty(txtGhiChu.Text))
                        cmd.Parameters.AddWithValue("@Note", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Note", txtGhiChu.Text);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật hóa đơn thành công!");
                        LoadHoaDon();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn để cập nhật!");
                    }
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

                        if (rows > 0)
                        {
                            MessageBox.Show("Xóa hóa đơn thành công!");
                            LoadHoaDon();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy hóa đơn để xóa!");
                        }
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
                string sql = "SELECT Borrowing.BorrowID AS[Mã Hóa Đơn], Borrowing.BorrowDate AS [Ngày Lập], Members.FirstName AS [Người Lập], Users.FullName AS [Khách Hàng], Borrowing.Note AS[Ghi Chú] FROM Borrowing INNER JOIN Users ON Borrowing.UserID = Users.UserID INNER JOIN Members ON Borrowing.MemberID = Members.MemberID WHERE BorrowID LIKE @Search ";

                using (SqlCommand cmd = new SqlCommand(sql, c.conn))
                {
                    cmd.Parameters.AddWithValue("@Search", "%" + txtMaHoaDon.Text + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dgvHoaDon.DataSource = dt;
                    }
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
