using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
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
        SqlDataAdapter da;
        DataTable dt;

        public ChiTietHoaDon(int id)
        {
            InitializeComponent();
            borrowId = id;
            LoadData();
        }

        private void LoadData()
        {
            c.connect();
            string sql = "SELECT BorrowingDetails.DetailID, BorrowingDetails.Quantity AS[SoLuong], " +
                "BorrowingDetails.Note AS[ghiChu]," +
                " Borrowing.BorrowID AS[MaHD], " +
                "Borrowing.BorrowDate AS[NgayLap]," +
                " Books.Price AS[GiaBan]," +
                " Books.Title AS[TenSach]," +
                "Users.Username AS[KhachHang], " +
                "Members.FirstName AS[NhanVienLap] FROM BorrowingDetails INNER JOIN Books ON BorrowingDetails.BookID = Books.BookID INNER JOIN Borrowing ON BorrowingDetails.BorrowID = Borrowing.BorrowID INNER JOIN Members ON Borrowing.MemberID = Members.MemberID INNER JOIN Users ON Borrowing.UserID = Users.UserID WHERE BorrowingDetails.BorrowID = @id";

            using (SqlCommand cmd = new SqlCommand(sql, c.conn))
            { 
                cmd.Parameters.AddWithValue("@id", borrowId);
                
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    detailID = Convert.ToInt32(reader["DetailID"]);
                    txtMaHD.Text = reader["MaHD"].ToString();
                    txtNhanVienLap.Text = reader["NhanVienLap"].ToString();
                    txtKhachHang.Text = reader["KhachHang"].ToString();
                    txtNgayLap.Text = reader["NgayLap"].ToString();
                    txtTenSach.Text = reader["TenSach"].ToString();
                    txtSoLuong.Text = reader["SoLuong"].ToString();
                    txtGiaBan.Text = reader["GiaBan"].ToString();
                    int soLuong = Convert.ToInt32(reader["SoLuong"]);
                    decimal giaBan = Convert.ToDecimal(reader["GiaBan"]);
                    decimal thanhTien = soLuong * giaBan;
                    txtThanhTien.Text = thanhTien.ToString("N0");
                    txtGhiChu.Text = reader["ghiChu"].ToString();
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
                    cmd.Parameters.AddWithValue("@DetailID",detailID );
              

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
    }
}
