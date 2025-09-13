using System.Windows.Forms;

namespace QuanLyThuVien.Forms
{
    partial class FormThongKeSach
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.DataGridView dgvThongKeKhoangNgay;
        private System.Windows.Forms.Label lblTongTien;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.dgvThongKeKhoangNgay = new System.Windows.Forms.DataGridView();
            this.lblTongTien = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeKhoangNgay)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(250, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 32);
            this.lblTitle.Text = "THỐNG KÊ SÁCH BÁN THEO NGÀY";

            // lblFromDate
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(30, 60);
            this.lblFromDate.Text = "Từ ngày:";

            // dtpFromDate
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(100, 55);
            this.dtpFromDate.Size = new System.Drawing.Size(120, 26);

            // lblToDate
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(250, 60);
            this.lblToDate.Text = "Đến ngày:";

            // dtpToDate
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(330, 55);
            this.dtpToDate.Size = new System.Drawing.Size(120, 26);

            // btnThongKe
            this.btnThongKe.Location = new System.Drawing.Point(480, 50);
            this.btnThongKe.Size = new System.Drawing.Size(90, 35);
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);

            // btnExportExcel
            this.btnExportExcel.Location = new System.Drawing.Point(590, 50);
            this.btnExportExcel.Size = new System.Drawing.Size(110, 35);
            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);

            // dgvThongKeKhoangNgay
            this.dgvThongKeKhoangNgay.AllowUserToAddRows = false;
            this.dgvThongKeKhoangNgay.AllowUserToDeleteRows = false;
            this.dgvThongKeKhoangNgay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKeKhoangNgay.Location = new System.Drawing.Point(30, 100);
            this.dgvThongKeKhoangNgay.ReadOnly = true;
            this.dgvThongKeKhoangNgay.RowHeadersWidth = 51;
            this.dgvThongKeKhoangNgay.Size = new System.Drawing.Size(740, 350);

            // lblTongTien
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.Location = new System.Drawing.Point(30, 470);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(150, 23);
            this.lblTongTien.Text = "Tổng tiền: 0 VNĐ";

            // FormThongKeKhoangNgay
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.dgvThongKeKhoangNgay);
            this.Controls.Add(this.lblTongTien);
            this.Text = "Thống kê sách bán theo ngày";
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeKhoangNgay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}
