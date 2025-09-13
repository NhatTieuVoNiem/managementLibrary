using System.Windows.Forms;

namespace QuanLyThuVien
{
    partial class FormSalary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cboEmployeeID = new System.Windows.Forms.ComboBox();
            this.lblMonthYear = new System.Windows.Forms.Label();
            this.dtpMonthYear = new System.Windows.Forms.DateTimePicker();
            this.lblBaseSalary = new System.Windows.Forms.Label();
            this.txtBaseSalary = new System.Windows.Forms.TextBox();
            this.lblWorkDays = new System.Windows.Forms.Label();
            this.txtWorkDays = new System.Windows.Forms.TextBox();
            this.lblAllowance = new System.Windows.Forms.Label();
            this.txtAllowance = new System.Windows.Forms.TextBox();
            this.lblBonus = new System.Windows.Forms.Label();
            this.txtBonus = new System.Windows.Forms.TextBox();
            this.lblDeduction = new System.Windows.Forms.Label();
            this.txtDeduction = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotalSalary = new System.Windows.Forms.TextBox();
            this.btnTinhLuong = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.dataGridViewSalary = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalary)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(327, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(276, 42);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản Lý Lương";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployee.Location = new System.Drawing.Point(54, 89);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(122, 22);
            this.lblEmployee.TabIndex = 1;
            this.lblEmployee.Text = "Mã nhân viên:";
            // 
            // cboEmployeeID
            // 
            this.cboEmployeeID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmployeeID.Location = new System.Drawing.Point(234, 86);
            this.cboEmployeeID.Name = "cboEmployeeID";
            this.cboEmployeeID.Size = new System.Drawing.Size(200, 30);
            this.cboEmployeeID.TabIndex = 2;
            // 
            // lblMonthYear
            // 
            this.lblMonthYear.AutoSize = true;
            this.lblMonthYear.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthYear.Location = new System.Drawing.Point(54, 171);
            this.lblMonthYear.Name = "lblMonthYear";
            this.lblMonthYear.Size = new System.Drawing.Size(106, 22);
            this.lblMonthYear.TabIndex = 3;
            this.lblMonthYear.Text = "Tháng, năm:";
            // 
            // dtpMonthYear
            // 
            this.dtpMonthYear.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMonthYear.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMonthYear.Location = new System.Drawing.Point(234, 165);
            this.dtpMonthYear.Name = "dtpMonthYear";
            this.dtpMonthYear.Size = new System.Drawing.Size(200, 30);
            this.dtpMonthYear.TabIndex = 4;
            // 
            // lblBaseSalary
            // 
            this.lblBaseSalary.AutoSize = true;
            this.lblBaseSalary.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaseSalary.Location = new System.Drawing.Point(54, 239);
            this.lblBaseSalary.Name = "lblBaseSalary";
            this.lblBaseSalary.Size = new System.Drawing.Size(125, 22);
            this.lblBaseSalary.TabIndex = 5;
            this.lblBaseSalary.Text = "Lương cơ bản:";
            // 
            // txtBaseSalary
            // 
            this.txtBaseSalary.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBaseSalary.Location = new System.Drawing.Point(234, 236);
            this.txtBaseSalary.Name = "txtBaseSalary";
            this.txtBaseSalary.Size = new System.Drawing.Size(200, 30);
            this.txtBaseSalary.TabIndex = 6;
            // 
            // lblWorkDays
            // 
            this.lblWorkDays.AutoSize = true;
            this.lblWorkDays.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkDays.Location = new System.Drawing.Point(55, 317);
            this.lblWorkDays.Name = "lblWorkDays";
            this.lblWorkDays.Size = new System.Drawing.Size(120, 22);
            this.lblWorkDays.TabIndex = 7;
            this.lblWorkDays.Text = "Số ngày công:";
            // 
            // txtWorkDays
            // 
            this.txtWorkDays.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWorkDays.Location = new System.Drawing.Point(234, 309);
            this.txtWorkDays.Name = "txtWorkDays";
            this.txtWorkDays.Size = new System.Drawing.Size(200, 30);
            this.txtWorkDays.TabIndex = 8;
            // 
            // lblAllowance
            // 
            this.lblAllowance.AutoSize = true;
            this.lblAllowance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllowance.Location = new System.Drawing.Point(496, 89);
            this.lblAllowance.Name = "lblAllowance";
            this.lblAllowance.Size = new System.Drawing.Size(78, 22);
            this.lblAllowance.TabIndex = 9;
            this.lblAllowance.Text = "Phụ cấp:";
            // 
            // txtAllowance
            // 
            this.txtAllowance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllowance.Location = new System.Drawing.Point(678, 86);
            this.txtAllowance.Name = "txtAllowance";
            this.txtAllowance.Size = new System.Drawing.Size(200, 30);
            this.txtAllowance.TabIndex = 10;
            // 
            // lblBonus
            // 
            this.lblBonus.AutoSize = true;
            this.lblBonus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBonus.Location = new System.Drawing.Point(496, 163);
            this.lblBonus.Name = "lblBonus";
            this.lblBonus.Size = new System.Drawing.Size(77, 22);
            this.lblBonus.TabIndex = 11;
            this.lblBonus.Text = "Thưởng:";
            // 
            // txtBonus
            // 
            this.txtBonus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBonus.Location = new System.Drawing.Point(678, 163);
            this.txtBonus.Name = "txtBonus";
            this.txtBonus.Size = new System.Drawing.Size(200, 30);
            this.txtBonus.TabIndex = 12;
            // 
            // lblDeduction
            // 
            this.lblDeduction.AutoSize = true;
            this.lblDeduction.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeduction.Location = new System.Drawing.Point(496, 236);
            this.lblDeduction.Name = "lblDeduction";
            this.lblDeduction.Size = new System.Drawing.Size(85, 22);
            this.lblDeduction.TabIndex = 13;
            this.lblDeduction.Text = "Khấu trừ:";
            // 
            // txtDeduction
            // 
            this.txtDeduction.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeduction.Location = new System.Drawing.Point(678, 231);
            this.txtDeduction.Name = "txtDeduction";
            this.txtDeduction.Size = new System.Drawing.Size(200, 30);
            this.txtDeduction.TabIndex = 14;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(496, 317);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(107, 22);
            this.lblTotal.TabIndex = 15;
            this.lblTotal.Text = "Tổng lương:";
            // 
            // txtTotalSalary
            // 
            this.txtTotalSalary.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSalary.Location = new System.Drawing.Point(678, 309);
            this.txtTotalSalary.Name = "txtTotalSalary";
            this.txtTotalSalary.ReadOnly = true;
            this.txtTotalSalary.Size = new System.Drawing.Size(200, 30);
            this.txtTotalSalary.TabIndex = 16;
            // 
            // btnTinhLuong
            // 
            this.btnTinhLuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinhLuong.Location = new System.Drawing.Point(334, 367);
            this.btnTinhLuong.Name = "btnTinhLuong";
            this.btnTinhLuong.Size = new System.Drawing.Size(100, 35);
            this.btnTinhLuong.TabIndex = 17;
            this.btnTinhLuong.Text = "Tính lương";
            this.btnTinhLuong.Click += new System.EventHandler(this.btnTinhLuong_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(503, 367);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 35);
            this.btnLuu.TabIndex = 18;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // dataGridViewSalary
            // 
            this.dataGridViewSalary.AllowUserToAddRows = false;
            this.dataGridViewSalary.AllowUserToDeleteRows = false;
            this.dataGridViewSalary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSalary.ColumnHeadersHeight = 29;
            this.dataGridViewSalary.Location = new System.Drawing.Point(58, 425);
            this.dataGridViewSalary.Name = "dataGridViewSalary";
            this.dataGridViewSalary.ReadOnly = true;
            this.dataGridViewSalary.RowHeadersWidth = 51;
            this.dataGridViewSalary.Size = new System.Drawing.Size(818, 270);
            this.dataGridViewSalary.TabIndex = 19;
            // 
            // FormSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 707);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.cboEmployeeID);
            this.Controls.Add(this.lblMonthYear);
            this.Controls.Add(this.dtpMonthYear);
            this.Controls.Add(this.lblBaseSalary);
            this.Controls.Add(this.txtBaseSalary);
            this.Controls.Add(this.lblWorkDays);
            this.Controls.Add(this.txtWorkDays);
            this.Controls.Add(this.lblAllowance);
            this.Controls.Add(this.txtAllowance);
            this.Controls.Add(this.lblBonus);
            this.Controls.Add(this.txtBonus);
            this.Controls.Add(this.lblDeduction);
            this.Controls.Add(this.txtDeduction);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtTotalSalary);
            this.Controls.Add(this.btnTinhLuong);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.dataGridViewSalary);
            this.Name = "FormSalary";
            this.Text = "Quản Lý Lương";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cboEmployeeID;
        private System.Windows.Forms.Label lblMonthYear;
        private System.Windows.Forms.DateTimePicker dtpMonthYear;
        private System.Windows.Forms.Label lblBaseSalary;
        private System.Windows.Forms.TextBox txtBaseSalary;
        private System.Windows.Forms.Label lblWorkDays;
        private System.Windows.Forms.TextBox txtWorkDays;
        private System.Windows.Forms.Label lblAllowance;
        private System.Windows.Forms.TextBox txtAllowance;
        private System.Windows.Forms.Label lblBonus;
        private System.Windows.Forms.TextBox txtBonus;
        private System.Windows.Forms.Label lblDeduction;
        private System.Windows.Forms.TextBox txtDeduction;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotalSalary;
        private System.Windows.Forms.Button btnTinhLuong;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.DataGridView dataGridViewSalary;

    }

}

