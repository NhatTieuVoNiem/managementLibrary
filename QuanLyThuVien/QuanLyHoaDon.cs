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
        }

        private void LoadHoaDon()
        {
            try
            {
                c.connect();
                string sql = "SELECT Borrowing.BorrowID AS [Mã Hóa Đơn], Borrowing.BorrowDate AS [Ngày Lập], Members.FirstName AS [Người Lập], Users.FullName AS [Khách Hàng], Borrowing.Note AS [Ghi Chú] FROM Borrowing INNER JOIN Users ON Borrowing.UserID = Users.UserID INNER JOIN Members ON Borrowing.MemberID = Members.MemberID";
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                c.connect();
                string sql = "INSERT INTO Borrowing (MemberID, BorrowDate, Note, UserID)" +
                    "VALUES (@MemberID,@BorrowDate,@Note,@UserID)";
                using (SqlCommand cmd = new SqlCommand(sql, c.conn))
                {
                    cmd.Parameters.AddWithValue("@MemberID", txtKhachHang.Text);
                    DateTime borrowDate;
                    if (string.IsNullOrEmpty(txtNgayLap.Text))
                        borrowDate = DateTime.Now;
                    else
                        borrowDate = DateTime.Parse(txtNgayLap.Text);

                    cmd.Parameters.AddWithValue("@BorrowDate", borrowDate);
                    cmd.Parameters.AddWithValue("@UserID", txtNhanVienLap.Text);
                    if (string.IsNullOrEmpty(txtGhiChu.Text))
                        cmd.Parameters.AddWithValue("@Note", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Note", DateTime.Parse(txtGhiChu.Text));
                
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Thêm hóa đơn thành công!");
                        LoadHoaDon();
                    }
                }
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                c.connect();
                string sql = "UPDATE Borrowing SET MemberID = @MemberID, BorrowDate = @BorrowDate, Note = @Note, UserID = @UserID WHERE BorrowID = @BorrowID";

                using (SqlCommand cmd = new SqlCommand(sql, c.conn))
                {
                    cmd.Parameters.AddWithValue("@BorrowID", txtMaHoaDon.Text);
                    cmd.Parameters.AddWithValue("@MemberID", txtKhachHang.Text);
                    DateTime borrowDate;
                    if (string.IsNullOrEmpty(txtNgayLap.Text))
                        borrowDate = DateTime.Now;
                    else
                        borrowDate = DateTime.Parse(txtNgayLap.Text);
                    cmd.Parameters.AddWithValue("@BorrowDate", borrowDate);
                    cmd.Parameters.AddWithValue("@UserID", txtNhanVienLap.Text);

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

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];
                txtMaHoaDon.Text = row.Cells["Mã Hóa Đơn"].Value?.ToString();
                txtKhachHang.Text = row.Cells["Người Lập"].Value?.ToString();
                txtNgayLap.Text = row.Cells["Ngày Lập"].Value?.ToString();
                txtNhanVienLap.Text = row.Cells["Khách Hàng"].Value?.ToString();
                txtGhiChu.Text = row.Cells["Ghi Chú"].Value?.ToString();
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
                int borrowId = Convert.ToInt32(dgvHoaDon.Rows[e.RowIndex].Cells["Mã Hóa Đơn"].Value);

                ChiTietHoaDon frm = new ChiTietHoaDon(borrowId);
                frm.ShowDialog();
            }
        }
    }
}
