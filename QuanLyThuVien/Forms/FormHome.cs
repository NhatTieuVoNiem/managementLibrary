using QuanLyThuVien.Forms;
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
                case "quảnLýHóaĐơnToolStripMenuItem":
                    QuanLyHoaDon f_hoaDon = new QuanLyHoaDon();
                    frm = f_hoaDon;
                    break;
                case "quảnLýSáchToolStripMenuItem1":
                    FormBook f_book = new FormBook();
                    frm = f_book;
                    break;
                case "quảnLýTácGiảToolStripMenuItem":
                    FormAuthor f_author = new FormAuthor();
                    frm = f_author;
                    break;
                case "quảnLýNSXToolStripMenuItem":
                    FormPublisher f_publisher = new FormPublisher();
                    frm = f_publisher;
                    break;
                case "quảnLýThểLoạiToolStripMenuItem":
                    FormCategory f_category = new FormCategory();
                    frm = f_category;
                    break;
                case "quảnLýVịTríSáchToolStripMenuItem":
                    FormBookLocation f_locationBook = new FormBookLocation();
                    frm = f_locationBook;
                    break;
            }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            frm.BringToFront();
        }

        private void báoCáoThốngKêToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Form frm = new Form();
            switch (e.ClickedItem.Name)
            {
                case "menuThongKeNhanVien":
                    FormThongKeNhanVien f_TK_nhanvien = new FormThongKeNhanVien();
                    frm = f_TK_nhanvien;
                    break;
                case "menuThongKeSach":
                    FormThongKeSach f_TK_khachHang = new FormThongKeSach();
                    frm = f_TK_khachHang;
                    break;
                case "menuThongKeKhachHang":
                    FormThongKeKhachHang f_TK_hoaDon = new FormThongKeKhachHang();
                    frm = f_TK_hoaDon;
                    break;                
            }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            frm.BringToFront();
        }
    }
}