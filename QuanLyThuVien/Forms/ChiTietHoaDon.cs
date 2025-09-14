using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class ChiTietHoaDon : Form
    {
        private int borrowId;
        private int detailID;
        connectData c = new connectData();

        public ChiTietHoaDon(int id)
        {
            InitializeComponent();
            borrowId = id;
            LoadSach();
            LoadKhachHang();
            LoadNhanVien();
            LoadData();
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

        private void LoadData()
        {
            try
            {
                c.connect();
                string sql = @"
                    SELECT 
                        BD.Quantity, 
                        BD.Note, 
                        B.BorrowID, 
                        B.BorrowDate, 
                       U.FirstName + ' ' + U.LastName AS [NhanVien],
                        M.FirstName + ' ' + M.LastName AS [KhachHang], 
                        BK.Title AS [TenSach], 
                        BD.DetailID, 
                        BK.Price, 
                        M.Email AS [LienHe], 
                        (BD.Quantity * BK.Price) AS [ThanhTien]
                    FROM BorrowingDetails BD
                    INNER JOIN Borrowing B ON BD.BorrowID = B.BorrowID
                    INNER JOIN Books BK ON B.BookID = BK.BookID
                    INNER JOIN Members M ON B.MemberID = M.MemberID
                    INNER JOIN Users U ON B.UserID = U.UserID
                    WHERE BD.BorrowID = @BorrowID";

                using (SqlCommand cmd = new SqlCommand(sql, c.conn))
                {
                    cmd.Parameters.AddWithValue("@BorrowID", borrowId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            detailID = Convert.ToInt32(reader["DetailID"]);
                            txtMaHD.Text = reader["BorrowID"].ToString();
                            txtNgayLap.Text = Convert.ToDateTime(reader["BorrowDate"]).ToString("dd/MM/yyyy");
                            cbNhanVien.Text = reader["NhanVien"].ToString();     // từ Users
                            cbKhachHang.Text = reader["KhachHang"].ToString();   // từ Members
                            cbSach.Text = reader["TenSach"].ToString();
                            txtSoLuong.Text = reader["Quantity"].ToString();
                            txtGiaBan.Text = reader["Price"].ToString();
                            txtThanhTien.Text = reader["ThanhTien"].ToString();
                            txtGhiChu.Text = reader["Note"].ToString();
                            txtLienHe.Text = reader["LienHe"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu chi tiết hóa đơn: " + ex.Message);
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

                string sql = @"UPDATE BorrowingDetails 
                               SET Quantity = @Quantity,
                                   Note = @Note
                               WHERE DetailID = @DetailID";

                using (SqlCommand cmd = new SqlCommand(sql, c.conn))
                {
                    cmd.Parameters.AddWithValue("@DetailID", detailID);

                    if (!int.TryParse(txtSoLuong.Text, out int soLuong))
                    {
                        MessageBox.Show("Số lượng không hợp lệ!");
                        return;
                    }
                    cmd.Parameters.AddWithValue("@Quantity", soLuong);

                    if (string.IsNullOrEmpty(txtGhiChu.Text))
                        cmd.Parameters.AddWithValue("@Note", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Note", txtGhiChu.Text);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Sửa chi tiết hóa đơn thành công!");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy chi tiết hóa đơn cần sửa!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
            }
            finally
            {
                c.disconnect();
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            FormXuatHoaDon f = new FormXuatHoaDon(borrowId);
            f.ShowDialog();
        }
    }
}
