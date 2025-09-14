using ClosedXML.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien.Forms
{
    public partial class FormThongKeNguoiDung : Form
    {
        connectData c = new connectData();
        decimal tongTien = 0; // thêm biến tổng tiền

        public FormThongKeNguoiDung()
        {
            InitializeComponent();
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (dtpToDate.Value.Date < dtpFromDate.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpToDate.Focus();
                return;
            }

            try
            {
                c.connect();
                string sql = @"
                    SELECT 
                        m.MemberID,
                        (m.FirstName + ' ' + m.LastName) AS TenNguoiMuon,
                        b.Title AS TenSach,
                        (a.FirstName + ' ' + a.LastName) AS TacGia,
                        c.CategoryName AS TheLoai,
                        p.PublisherName AS NhaXuatBan,
                        br.BorrowDate AS NgayMuon,
                        SUM(bd.Quantity) AS SoLuongMuon,
                        SUM(bd.Quantity * b.Price) AS TongTien
                    FROM BorrowingDetails bd
                    JOIN Borrowing br ON bd.BorrowID = br.BorrowID
                    JOIN Members m ON br.MemberID = m.MemberID
                    JOIN Books b ON br.BookID = b.BookID
                    LEFT JOIN Authors a ON b.AuthorID = a.AuthorID
                    LEFT JOIN Categories c ON b.CategoryID = c.CategoryID
                    LEFT JOIN Publishers p ON b.PublisherID = p.PublisherID
                    WHERE br.BorrowDate BETWEEN @From AND @To
                    GROUP BY m.MemberID, m.FirstName, m.LastName,
                             b.Title, a.FirstName, a.LastName, c.CategoryName, p.PublisherName, br.BorrowDate
                    ORDER BY br.BorrowDate ASC, SoLuongMuon DESC;
                ";

                SqlCommand cmd = new SqlCommand(sql, c.conn);
                cmd.Parameters.AddWithValue("@From", dtpFromDate.Value.Date);
                cmd.Parameters.AddWithValue("@To", dtpToDate.Value.Date.AddDays(1).AddSeconds(-1));

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvThongKeNguoiDung.DataSource = dt;

                // tính tổng tiền
                tongTien = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (decimal.TryParse(row["TongTien"].ToString(), out decimal tien))
                        tongTien += tien;
                }
                lblTongTien.Text = $"Tổng tiền: {tongTien:N0} VND";

                if (dt.Rows.Count == 0)
                    MessageBox.Show("Không có dữ liệu trong khoảng thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvThongKeNguoiDung.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                FileName = "ThongKeNguoiDung.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var ws = wb.Worksheets.Add("ThongKeNguoiDung");

                        // Ghi chú ngày thống kê
                        ws.Cell(1, 1).Value = $"Thống kê từ {dtpFromDate.Value:dd/MM/yyyy} đến {dtpToDate.Value:dd/MM/yyyy}";
                        ws.Range(1, 1, 1, dgvThongKeNguoiDung.Columns.Count).Merge();
                        ws.Cell(1, 1).Style.Font.Bold = true;
                        ws.Cell(1, 1).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;

                        // Header
                        for (int i = 0; i < dgvThongKeNguoiDung.Columns.Count; i++)
                        {
                            ws.Cell(2, i + 1).Value = dgvThongKeNguoiDung.Columns[i].HeaderText;
                            ws.Cell(2, i + 1).Style.Font.Bold = true;
                        }

                        // Data
                        for (int i = 0; i < dgvThongKeNguoiDung.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvThongKeNguoiDung.Columns.Count; j++)
                            {
                                var cell = ws.Cell(i + 3, j + 1);
                                cell.Value = dgvThongKeNguoiDung.Rows[i].Cells[j].Value?.ToString();

                                // định dạng ngày mượn
                                if (dgvThongKeNguoiDung.Columns[j].HeaderText == "NgayMuon" &&
                                    DateTime.TryParse(cell.Value.ToString(), out DateTime date))
                                {
                                    cell.Value = date;
                                    cell.Style.DateFormat.Format = "dd/MM/yyyy";
                                }
                            }
                        }

                        // Dòng tổng tiền
                        int lastRow = dgvThongKeNguoiDung.Rows.Count + 3;
                        ws.Cell(lastRow, dgvThongKeNguoiDung.Columns.Count - 1).Value = "Tổng tiền:";
                        ws.Cell(lastRow, dgvThongKeNguoiDung.Columns.Count).Value = tongTien;
                        ws.Range(lastRow, dgvThongKeNguoiDung.Columns.Count - 1, lastRow, dgvThongKeNguoiDung.Columns.Count).Style.Font.Bold = true;

                        ws.Columns().AdjustToContents();
                        wb.SaveAs(sfd.FileName);
                    }
                    MessageBox.Show("Xuất Excel thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message);
                }
            }
        }
    }
}
