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

        public FormThongKeSach()
        {
            InitializeComponent();
        }

        private void FormThongKeSachMuonNhieu_Load(object sender, EventArgs e)
        {
            LoadThongKe();
        }

        private void LoadThongKe()
        {
            c.connect();
            string sql = @"
                SELECT TOP 10 
                       b.BookID,
                       b.Title AS [Tên sách],
                       (a.FirstName + ' ' + a.LastName) AS [Tác giả],
                       COUNT(br.BookID) AS [Số lượt mượn]
                FROM Borrowing br
                INNER JOIN Books b ON br.BookID = b.BookID
                INNER JOIN Authors a ON b.AuthorID = a.AuthorID
                GROUP BY b.BookID, b.Title, a.FirstName, a.LastName
                ORDER BY [Số lượt mượn] DESC";

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
                FileName = "ThongKeSachMuonNhieu.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var ws = wb.Worksheets.Add("ThongKeSachMuonNhieu");

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
