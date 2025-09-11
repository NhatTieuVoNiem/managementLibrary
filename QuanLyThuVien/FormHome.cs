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

        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void danhMụcToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Form frm = new Form();
            switch (e.ClickedItem.Name)
            {
                case "menuNhanVien":
                    QuanLyNhanVien f_nhanvien = new QuanLyNhanVien();
                    frm = f_nhanvien;
                    break;
                case "quảnLýKháchHàngToolStripMenuItem":
                    QuanLyKhachHang f_khachHang = new QuanLyKhachHang();
                    frm = f_khachHang;
                    break;
                case "quảnLýSáchToolStripMenuItem":
                    QuanLySach f_nhanVien = new QuanLySach();
                    frm = f_nhanVien;
                    break;
                case "quảnLýHóaĐơnToolStripMenuItem":
                    QuanLyHoaDon f_hoaDon = new QuanLyHoaDon();
                    frm = f_hoaDon;
                    break;
            }
             frm.MdiParent = this;
             frm.WindowState = FormWindowState.Maximized;
             frm.Show();
             frm.BringToFront();  
        }
    }
}
