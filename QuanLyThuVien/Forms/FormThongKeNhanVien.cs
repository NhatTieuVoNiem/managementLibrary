using ClosedXML.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien.Forms
{
    public partial class FormThongKeNhanVien : Form
    {
        connectData c = new connectData();
        decimal tongTien = 0;

        public FormThongKeNhanVien()
        {
            InitializeComponent();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (dtpFromDate.Value.Date > dtpToDate.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                c.connect();
                string sql = @"
                    SELECT 
                        m.MemberID,
                        u.FullName AS NhanVien,
                        b.Title AS TenSach,
                        br.BorrowDate AS NgayMuon,
                        bd.Quantity AS SoLuong,
                        (bd.Quantity * b.Price) AS TongTien
                    FROM BorrowingDetails bd
                    INNER JOIN Borrowing br ON bd.BorrowID = br.BorrowID
                    INNER JOIN Members m ON br.MemberID = m.MemberID
                    INNER JOIN Users u ON br.UserID = u.UserID
                    INNER JOIN Books b ON br.BookID = b.BookID
                    WHERE CAST(br.BorrowDate AS DATE) BETWEEN @FromDate AND @ToDate
                    ORDER BY br.BorrowDate DESC;";

                SqlDataAdapter da = new SqlDataAdapter(sql, c.conn);
                da.SelectCommand.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date);
                da.SelectCommand.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvThongKeNhanVien.DataSource = dt;

                // Tính tổng tiền
                tongTien = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (decimal.TryParse(row["TongTien"].ToString(), out decimal tien))
                    {
                        tongTien += tien;
                    }
                }

                lblTongTien.Text = $"Tổng tiền: {tongTien:N0} VND";

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu trong khoảng thời gian này!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thống kê: " + ex.Message);
            }
            finally
            {
                c.disconnect();
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvThongKeNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                FileName = "ThongKeNhanVien.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var ws = wb.Worksheets.Add("ThongKeNhanVien");

                        // Ghi chú ngày thống kê
                        ws.Cell(1, 1).Value = $"Thống kê từ ngày {dtpFromDate.Value:dd/MM/yyyy} đến {dtpToDate.Value:dd/MM/yyyy}";
                        ws.Range(1, 1, 1, dgvThongKeNhanVien.Columns.Count).Merge();
                        ws.Cell(1, 1).Style.Font.Bold = true;
                        ws.Cell(1, 1).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;

                        // Header
                        for (int i = 0; i < dgvThongKeNhanVien.Columns.Count; i++)
                        {
                            ws.Cell(2, i + 1).Value = dgvThongKeNhanVien.Columns[i].HeaderText;
                            ws.Cell(2, i + 1).Style.Font.Bold = true;
                        }

                        // Data
                        for (int i = 0; i < dgvThongKeNhanVien.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvThongKeNhanVien.Columns.Count; j++)
                            {
                                var cell = ws.Cell(i + 3, j + 1);
                                cell.Value = dgvThongKeNhanVien.Rows[i].Cells[j].Value?.ToString();

                                if (dgvThongKeNhanVien.Columns[j].HeaderText == "NgayMuon" &&
                                    DateTime.TryParse(cell.Value.ToString(), out DateTime date))
                                {
                                    cell.Value = date;
                                    cell.Style.DateFormat.Format = "dd/MM/yyyy";
                                }
                            }
                        }

                        // Dòng tổng tiền
                        int lastRow = dgvThongKeNhanVien.Rows.Count + 3;
                        ws.Cell(lastRow, dgvThongKeNhanVien.Columns.Count - 1).Value = "Tổng tiền:";
                        ws.Cell(lastRow, dgvThongKeNhanVien.Columns.Count).Value = tongTien;
                        ws.Range(lastRow, dgvThongKeNhanVien.Columns.Count - 1, lastRow, dgvThongKeNhanVien.Columns.Count).Style.Font.Bold = true;

                        ws.Columns().AdjustToContents();
                        wb.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Xuất Excel thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message);
                }
            }
        }
    }
}
