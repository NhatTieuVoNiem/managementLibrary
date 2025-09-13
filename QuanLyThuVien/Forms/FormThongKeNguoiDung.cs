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

        public FormThongKeNguoiDung()
        {
            InitializeComponent();
        }

        private void FormThongKeNguoiDung_Load(object sender, EventArgs e)
        {
            LoadThongKe();
        }

        private void LoadThongKe()
        {
            c.connect();
            string sql = @"
               SELECT TOP 10
    m.MemberID,
    (m.FirstName + ' ' + m.LastName) AS TenNguoiMuon,
    b.BookID,
    b.Title AS TenSach,
    (a.FirstName + ' ' + a.LastName) AS TacGia,
    c.CategoryName AS TheLoai,
    p.PublisherName AS NhaXuatBan,
    SUM(bd.Quantity) AS SoLuongMuon
FROM BorrowingDetails bd
JOIN Borrowing br ON bd.BorrowID = br.BorrowID
JOIN Members m    ON br.MemberID = m.MemberID
JOIN Books b      ON br.BookID = b.BookID
LEFT JOIN Authors a    ON b.AuthorID = a.AuthorID
LEFT JOIN Categories c ON b.CategoryID = c.CategoryID
LEFT JOIN Publishers p ON b.PublisherID = p.PublisherID
GROUP BY m.MemberID, m.FirstName, m.LastName,
         b.BookID, b.Title, a.FirstName, a.LastName, c.CategoryName, p.PublisherName
ORDER BY SoLuongMuon DESC;
";

            SqlDataAdapter da = new SqlDataAdapter(sql, c.conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvThongKe.DataSource = dt;
            c.disconnect();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvThongKe.Rows.Count == 0)
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

                        // Header
                        for (int i = 0; i < dgvThongKe.Columns.Count; i++)
                        {
                            ws.Cell(1, i + 1).Value = dgvThongKe.Columns[i].HeaderText;
                            ws.Cell(1, i + 1).Style.Font.Bold = true;
                        }

                        // Data
                        for (int i = 0; i < dgvThongKe.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvThongKe.Columns.Count; j++)
                            {
                                ws.Cell(i + 2, j + 1).Value = dgvThongKe.Rows[i].Cells[j].Value?.ToString();
                            }
                        }

                        // Border + auto size
                        var range = ws.Range(1, 1, dgvThongKe.Rows.Count + 1, dgvThongKe.Columns.Count);
                        range.Style.Border.OutsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;
                        range.Style.Border.InsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;
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
