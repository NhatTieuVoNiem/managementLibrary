using QuanLyThuVien.libraryManagementDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyThuVien
{
    public partial class FormXuatHoaDon : Form
    {
        public FormXuatHoaDon(int id)
        {
            InitializeComponent();
            borrowId = id;
        }

        private ThongTinHoaDonTableAdapter thongTinHoaDonTableAdapter = new ThongTinHoaDonTableAdapter();
        private int borrowId;

        private void FormXuatHoaDon_Load(object sender, EventArgs e)
        {
              thongTinHoaDonTableAdapter.Fill(this.libraryManagementDataSet.ThongTinHoaDon, borrowId);
            this.reportViewer2.RefreshReport();
        }

       
    }
}
