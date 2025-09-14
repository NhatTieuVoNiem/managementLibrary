namespace QuanLyThuVien.Forms
{
    partial class FormBookLocation
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelShelfCode = new System.Windows.Forms.Label();
            this.txtShelfCode = new System.Windows.Forms.TextBox();
            this.labelFloor = new System.Windows.Forms.Label();
            this.txtFloor = new System.Windows.Forms.TextBox();
            this.labelRoom = new System.Windows.Forms.Label();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.labelNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvBookLocation = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.labelTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelShelfCode, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtShelfCode, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelFloor, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtFloor, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelRoom, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtRoom, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelNote, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtNote, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.dgvBookLocation, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.labelTitle, 4);
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(3, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(894, 50);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "QUẢN LÝ VỊ TRÍ SÁCH";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelShelfCode
            // 
            this.labelShelfCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelShelfCode.Font = new System.Drawing.Font("Times New Roman", 13.8F);
            this.labelShelfCode.Location = new System.Drawing.Point(138, 50);
            this.labelShelfCode.Name = "labelShelfCode";
            this.labelShelfCode.Size = new System.Drawing.Size(174, 40);
            this.labelShelfCode.TabIndex = 1;
            this.labelShelfCode.Text = "Mã kệ:";
            this.labelShelfCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtShelfCode
            // 
            this.txtShelfCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShelfCode.Font = new System.Drawing.Font("Times New Roman", 13.8F);
            this.txtShelfCode.Location = new System.Drawing.Point(318, 53);
            this.txtShelfCode.Name = "txtShelfCode";
            this.txtShelfCode.Size = new System.Drawing.Size(444, 34);
            this.txtShelfCode.TabIndex = 2;
            // 
            // labelFloor
            // 
            this.labelFloor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFloor.Font = new System.Drawing.Font("Times New Roman", 13.8F);
            this.labelFloor.Location = new System.Drawing.Point(138, 90);
            this.labelFloor.Name = "labelFloor";
            this.labelFloor.Size = new System.Drawing.Size(174, 40);
            this.labelFloor.TabIndex = 3;
            this.labelFloor.Text = "Tầng:";
            this.labelFloor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFloor
            // 
            this.txtFloor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFloor.Font = new System.Drawing.Font("Times New Roman", 13.8F);
            this.txtFloor.Location = new System.Drawing.Point(318, 93);
            this.txtFloor.Name = "txtFloor";
            this.txtFloor.Size = new System.Drawing.Size(444, 34);
            this.txtFloor.TabIndex = 4;
            // 
            // labelRoom
            // 
            this.labelRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRoom.Font = new System.Drawing.Font("Times New Roman", 13.8F);
            this.labelRoom.Location = new System.Drawing.Point(138, 130);
            this.labelRoom.Name = "labelRoom";
            this.labelRoom.Size = new System.Drawing.Size(174, 40);
            this.labelRoom.TabIndex = 5;
            this.labelRoom.Text = "Phòng:";
            this.labelRoom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRoom
            // 
            this.txtRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRoom.Font = new System.Drawing.Font("Times New Roman", 13.8F);
            this.txtRoom.Location = new System.Drawing.Point(318, 133);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(444, 34);
            this.txtRoom.TabIndex = 6;
            // 
            // labelNote
            // 
            this.labelNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNote.Font = new System.Drawing.Font("Times New Roman", 13.8F);
            this.labelNote.Location = new System.Drawing.Point(138, 170);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(174, 80);
            this.labelNote.TabIndex = 7;
            this.labelNote.Text = "Ghi chú:";
            this.labelNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNote
            // 
            this.txtNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNote.Font = new System.Drawing.Font("Times New Roman", 13.8F);
            this.txtNote.Location = new System.Drawing.Point(318, 173);
            this.txtNote.Multiline = true;
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNote.Size = new System.Drawing.Size(444, 74);
            this.txtNote.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.btnAdd, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnEdit, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDelete, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSearch, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(318, 253);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(444, 54);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvBookLocation
            // 
            this.dgvBookLocation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBookLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvBookLocation, 4);
            this.dgvBookLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBookLocation.Location = new System.Drawing.Point(3, 313);
            this.dgvBookLocation.Name = "dgvBookLocation";
            this.dgvBookLocation.RowHeadersWidth = 51;
            this.dgvBookLocation.Size = new System.Drawing.Size(894, 284);
            this.dgvBookLocation.TabIndex = 10;
            this.dgvBookLocation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBookLocation_CellClick);
            // 
            // FormBookLocation
            // 
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormBookLocation";
            this.Text = "Quản lý vị trí sách";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookLocation)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelShelfCode;
        private System.Windows.Forms.TextBox txtShelfCode;
        private System.Windows.Forms.Label labelFloor;
        private System.Windows.Forms.TextBox txtFloor;
        private System.Windows.Forms.Label labelRoom;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvBookLocation;
    }
}
