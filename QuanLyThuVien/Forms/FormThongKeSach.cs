using ClosedXML.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien.Forms
{
    public partial class FormThongKeSach : Form
    {
        connectData c = new connectData();
        decimal tongTien = 0;

        public FormThongKeSach()
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
                        b.BookID,
                        b.Title AS [Tên sách],
                        (a.FirstName + ' ' + a.LastName) AS [Tác giả],
                        c.CategoryName AS [Thể loại],
                        p.PublisherName AS [Nhà xuất bản],
                        br.BorrowDate AS [Ngày mượn],
                        SUM(bd.Quantity) AS [Số lượng mượn],
                        SUM(bd.Quantity * b.Price) AS [Tổng tiền]
                    FROM BorrowingDetails bd
                    JOIN Borrowing br ON bd.BorrowID = br.BorrowID
                    JOIN Books b      ON br.BookID = b.BookID
                    LEFT JOIN Authors a    ON b.AuthorID = a.AuthorID
                    LEFT JOIN Categories c ON b.CategoryID = c.CategoryID
                    LEFT JOIN Publishers p ON b.PublisherID = p.PublisherID
                    WHERE CAST(br.BorrowDate AS DATE) BETWEEN @from AND @to
                    GROUP BY b.BookID, b.Title, a.FirstName, a.LastName, c.CategoryName, p.PublisherName, br.BorrowDate
                    ORDER BY br.BorrowDate ASC, [Số lượng mượn] DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, c.conn);
                da.SelectCommand.Parameters.AddWithValue("@from", dtpFromDate.Value.Date);
                da.SelectCommand.Parameters.AddWithValue("@to", dtpToDate.Value.Date);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvThongKeKhoangNgay.DataSource = dt;

                // Tính tổng tiền
                tongTien = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (decimal.TryParse(row["Tổng tiền"].ToString(), out decimal tien))
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
            if (dgvThongKeKhoangNgay.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                FileName = "ThongKeSach.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var ws = wb.Worksheets.Add("ThongKeSach");

                        // Ghi chú ngày thống kê
                        ws.Cell(1, 1).Value = $"Thống kê từ ngày {dtpFromDate.Value:dd/MM/yyyy} đến {dtpToDate.Value:dd/MM/yyyy}";
                        ws.Range(1, 1, 1, dgvThongKeKhoangNgay.Columns.Count).Merge();
                        ws.Cell(1, 1).Style.Font.Bold = true;
                        ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // Header
                        for (int i = 0; i < dgvThongKeKhoangNgay.Columns.Count; i++)
                        {
                            ws.Cell(2, i + 1).Value = dgvThongKeKhoangNgay.Columns[i].HeaderText;
                            ws.Cell(2, i + 1).Style.Font.Bold = true;
                        }

                        // Data
                        for (int i = 0; i < dgvThongKeKhoangNgay.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvThongKeKhoangNgay.Columns.Count; j++)
                            {
                                var cell = ws.Cell(i + 3, j + 1);
                                cell.Value = dgvThongKeKhoangNgay.Rows[i].Cells[j].Value?.ToString();

                                // Định dạng ngày mượn nếu là cột "Ngày mượn"
                                if (dgvThongKeKhoangNgay.Columns[j].HeaderText == "Ngày mượn" &&
                                    DateTime.TryParse(cell.Value.ToString(), out DateTime date))
                                {
                                    cell.Value = date;
                                    cell.Style.DateFormat.Format = "dd/MM/yyyy";
                                }
                            }
                        }

                        // Dòng tổng tiền
                        int lastRow = dgvThongKeKhoangNgay.Rows.Count + 3;
                        ws.Cell(lastRow, dgvThongKeKhoangNgay.Columns.Count - 1).Value = "Tổng tiền:";
                        ws.Cell(lastRow, dgvThongKeKhoangNgay.Columns.Count).Value = tongTien;
                        ws.Range(lastRow, dgvThongKeKhoangNgay.Columns.Count - 1, lastRow, dgvThongKeKhoangNgay.Columns.Count).Style.Font.Bold = true;

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
