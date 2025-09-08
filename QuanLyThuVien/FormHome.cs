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
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void danhMụcToolStripMenuItem(object sender, ToolStripItemClickedEventArgs e)
        {
            Form frm = new Form();
            switch (e.ClickedItem.Name)
            {
                case "MenuNhanVien":
                    F_NhanVien f_nhanvien = new F_NhanVien();
                    frm = f_nhanvien;
                    break;
                case "MenuKhachHang":
                    F_KhachHang f_KhachHang = new F_KhachHang();
                    frm = f_KhachHang;
                    break;

                case "MenuHangHoa":
                    F_HangHoa f_hanghoa = new F_HangHoa();
                    frm = f_hanghoa;
                    break;
                case "MenuHoaDon":
                    F_HoaDon f_HoaDon = new F_HoaDon();
                    frm = f_HoaDon;
                    break;
            }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            frm.BringToFront();
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
