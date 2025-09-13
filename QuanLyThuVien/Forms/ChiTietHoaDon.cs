using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

        private void LoadData()
        {
            c.connect();
            string sql = @"SELECT BorrowingDetails.Quantity AS [Quantity], BorrowingDetails.Note AS [Note],Borrowing.BorrowID AS [BorrowID], Borrowing.BorrowDate AS [BorrowDate], Members.FirstName AS [NhanVien], Books.Title AS [TenSach], BorrowingDetails.DetailID, Books.Price AS [Price],Users.Email AS [LienHe], Users.FullName AS [KhachHang], (BorrowingDetails.Quantity * Books.Price) AS [ThanhTien] FROM BorrowingDetails INNER JOIN Borrowing ON BorrowingDetails.BorrowID = Borrowing.BorrowID INNER JOIN Books ON Borrowing.BookID = Books.BookID INNER JOIN Members ON Borrowing.MemberID = Members.MemberID INNER JOIN Users ON Borrowing.UserID = Users.UserID WHERE BorrowingDetails.BorrowID = @BorrowID";

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
                        cbNhanVien.Text = reader["NhanVien"].ToString();
                        cbKhachHang.Text = reader["KhachHang"].ToString();
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


                    int soLuong;
                    if (!int.TryParse(txtSoLuong.Text, out soLuong))
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
