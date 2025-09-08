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

        private void bộLọcToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thểLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCategory F = new FormCategory();
            F.Show();
            this.Hide();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {

        }
    }
}
