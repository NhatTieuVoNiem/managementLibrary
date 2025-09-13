using ClosedXML.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace QuanLyThuVien.Forms
{
    public partial class FormSachThongKe : Form
    {

        public FormSachThongKe()
        {
            InitializeComponent();
        }
        connectData c = new connectData();
        private void FormThongKe_Load(object sender, EventArgs e)
        {
            LoadThongKe();
        }

        private void LoadThongKe()
        {
            {
                c.connect();
                // Tổng số sách
                SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM Books", c.conn);
                int tongSach = (int)cmd1.ExecuteScalar();
                lblTongSach.Text = "Tổng số sách: " + tongSach;

                // Top 10 sách mượn nhiều nhất
                SqlDataAdapter da = new SqlDataAdapter(@"
                    SELECT TOP 10 b.Title AS [Tên sách], COUNT(*) AS [Số lượt mượn]
                    FROM BorrowingDetails bd
                    JOIN Books b ON bd.BookID = b.BookID
                    GROUP BY b.Title
                    ORDER BY [Số lượt mượn] DESC", c.conn);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvThongKe.DataSource = dt;
            }
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
                FileName = "ThongKeSach.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var ws = wb.Worksheets.Add("ThongKe");

                        // Ghi header
                        for (int i = 0; i < dgvThongKe.Columns.Count; i++)
                        {
                            ws.Cell(1, i + 1).Value = dgvThongKe.Columns[i].HeaderText;
                            ws.Cell(1, i + 1).Style.Font.Bold = true;
                        }

                        // Ghi dữ liệu
                        for (int i = 0; i < dgvThongKe.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvThongKe.Columns.Count; j++)
                            {
                                ws.Cell(i + 2, j + 1).Value = dgvThongKe.Rows[i].Cells[j].Value?.ToString();
                            }
                        }

                        // Thêm border cho toàn bảng
                        var range = ws.Range(1, 1, dgvThongKe.Rows.Count + 1, dgvThongKe.Columns.Count);
                        range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                        // Tự động co giãn cột
                        ws.Columns().AdjustToContents();

                        // Lưu file
                        wb.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
