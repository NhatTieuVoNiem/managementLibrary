using System.Windows.Forms;

namespace QuanLyThuVien.Forms
{
    partial class FormThongKeNhanVien
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

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvThongKeNhanVien = new System.Windows.Forms.DataGridView();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(900, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THỐNG KÊ NHÂN VIÊN BÁN SÁCH";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(20, 50);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(120, 25);
            this.lblFrom.Text = "Từ ngày:";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(150, 50);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(200, 30);
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(380, 50);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(120, 25);
            this.lblTo.Text = "Đến ngày:";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(510, 50);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(200, 30);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(730, 50);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(120, 30);
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // dgvThongKeNhanVien
            // 
            this.dgvThongKeNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvThongKeNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKeNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKeNhanVien.Location = new System.Drawing.Point(20, 90);
            this.dgvThongKeNhanVien.Name = "dgvThongKeNhanVien";
            this.dgvThongKeNhanVien.Size = new System.Drawing.Size(830, 300);
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongTien.Location = new System.Drawing.Point(20, 400);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(400, 25);
            this.lblTongTien.Text = "Tổng tiền: 0 VND";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Location = new System.Drawing.Point(730, 400);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(120, 30);
            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // FormThongKeNhanVien
            // 
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.dgvThongKeNhanVien);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.btnExportExcel);
            this.Name = "FormThongKeNhanVien";
            this.Text = "Thống kê nhân viên";
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeNhanVien)).EndInit();
            this.ResumeLayout(false);
        }

        private Label lblTitle;
        private Label lblFrom;
        private Label lblTo;
        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;
        private Button btnThongKe;
        private DataGridView dgvThongKeNhanVien;
        private Label lblTongTien;
        private Button btnExportExcel;
    }
}
