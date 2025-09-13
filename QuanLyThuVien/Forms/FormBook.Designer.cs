using System.Windows.Forms;

namespace QuanLyThuVien.Forms
{
    partial class FormBook
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
            this.labelTitleForm = new System.Windows.Forms.Label();
            this.labelBookTitle = new System.Windows.Forms.Label();
            this.txtBookTitle = new System.Windows.Forms.TextBox();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.cbAuthor = new System.Windows.Forms.ComboBox();
            this.labelCategory = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.labelPublisher = new System.Windows.Forms.Label();
            this.cbPublisher = new System.Windows.Forms.ComboBox();
            this.labelYear = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.labelLocation = new System.Windows.Forms.Label();
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.labelAvailable = new System.Windows.Forms.Label();
            this.txtAvailable = new System.Windows.Forms.TextBox();
            this.labelNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.labelBorrowPrice = new System.Windows.Forms.Label();
            this.txtBorrowPrice = new System.Windows.Forms.TextBox();
            this.labelSalePrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvBook = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBook)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.labelTitleForm, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelBookTitle, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtBookTitle, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelAuthor, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbAuthor, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelCategory, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbCategory, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelPublisher, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbPublisher, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelYear, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtYear, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelLocation, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.cbLocation, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelQuantity, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtQuantity, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelAvailable, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtAvailable, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelNote, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtNote, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.labelBorrowPrice, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.txtBorrowPrice, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.labelSalePrice, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.txtPrice, 2, 11);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 12);
            this.tableLayoutPanel1.Controls.Add(this.dgvBook, 0, 13);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 14;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 700);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelTitleForm
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.labelTitleForm, 4);
            this.labelTitleForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitleForm.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.labelTitleForm.Location = new System.Drawing.Point(3, 0);
            this.labelTitleForm.Name = "labelTitleForm";
            this.labelTitleForm.Size = new System.Drawing.Size(994, 50);
            this.labelTitleForm.TabIndex = 0;
            this.labelTitleForm.Text = "QUẢN LÝ SÁCH";
            this.labelTitleForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBookTitle
            // 
            this.labelBookTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBookTitle.Location = new System.Drawing.Point(153, 50);
            this.labelBookTitle.Name = "labelBookTitle";
            this.labelBookTitle.Size = new System.Drawing.Size(194, 40);
            this.labelBookTitle.TabIndex = 1;
            this.labelBookTitle.Text = "Tên sách:";
            this.labelBookTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBookTitle
            // 
            this.txtBookTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBookTitle.Location = new System.Drawing.Point(353, 53);
            this.txtBookTitle.Name = "txtBookTitle";
            this.txtBookTitle.Size = new System.Drawing.Size(494, 22);
            this.txtBookTitle.TabIndex = 2;
            // 
            // labelAuthor
            // 
            this.labelAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAuthor.Location = new System.Drawing.Point(153, 90);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(194, 40);
            this.labelAuthor.TabIndex = 3;
            this.labelAuthor.Text = "Tác giả:";
            this.labelAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbAuthor
            // 
            this.cbAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbAuthor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAuthor.Location = new System.Drawing.Point(353, 93);
            this.cbAuthor.Name = "cbAuthor";
            this.cbAuthor.Size = new System.Drawing.Size(494, 24);
            this.cbAuthor.TabIndex = 4;
            // 
            // labelCategory
            // 
            this.labelCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCategory.Location = new System.Drawing.Point(153, 130);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(194, 40);
            this.labelCategory.TabIndex = 5;
            this.labelCategory.Text = "Thể loại:";
            this.labelCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbCategory
            // 
            this.cbCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.Location = new System.Drawing.Point(353, 133);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(494, 24);
            this.cbCategory.TabIndex = 6;
            // 
            // labelPublisher
            // 
            this.labelPublisher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPublisher.Location = new System.Drawing.Point(153, 170);
            this.labelPublisher.Name = "labelPublisher";
            this.labelPublisher.Size = new System.Drawing.Size(194, 40);
            this.labelPublisher.TabIndex = 7;
            this.labelPublisher.Text = "NXB:";
            this.labelPublisher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbPublisher
            // 
            this.cbPublisher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbPublisher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPublisher.Location = new System.Drawing.Point(353, 173);
            this.cbPublisher.Name = "cbPublisher";
            this.cbPublisher.Size = new System.Drawing.Size(494, 24);
            this.cbPublisher.TabIndex = 8;
            // 
            // labelYear
            // 
            this.labelYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelYear.Location = new System.Drawing.Point(153, 210);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(194, 40);
            this.labelYear.TabIndex = 9;
            this.labelYear.Text = "Năm XB:";
            this.labelYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtYear
            // 
            this.txtYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtYear.Location = new System.Drawing.Point(353, 213);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(494, 22);
            this.txtYear.TabIndex = 10;
            // 
            // labelLocation
            // 
            this.labelLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLocation.Location = new System.Drawing.Point(153, 250);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(194, 40);
            this.labelLocation.TabIndex = 11;
            this.labelLocation.Text = "Vị trí:";
            this.labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbLocation
            // 
            this.cbLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocation.Location = new System.Drawing.Point(353, 253);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(494, 24);
            this.cbLocation.TabIndex = 12;
            // 
            // labelQuantity
            // 
            this.labelQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelQuantity.Location = new System.Drawing.Point(153, 290);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(194, 40);
            this.labelQuantity.TabIndex = 13;
            this.labelQuantity.Text = "Số lượng:";
            this.labelQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuantity.Location = new System.Drawing.Point(353, 293);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(494, 22);
            this.txtQuantity.TabIndex = 14;
            // 
            // labelAvailable
            // 
            this.labelAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAvailable.Location = new System.Drawing.Point(153, 330);
            this.labelAvailable.Name = "labelAvailable";
            this.labelAvailable.Size = new System.Drawing.Size(194, 40);
            this.labelAvailable.TabIndex = 15;
            this.labelAvailable.Text = "Còn lại:";
            this.labelAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAvailable
            // 
            this.txtAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAvailable.Location = new System.Drawing.Point(353, 333);
            this.txtAvailable.Name = "txtAvailable";
            this.txtAvailable.Size = new System.Drawing.Size(494, 22);
            this.txtAvailable.TabIndex = 16;
            // 
            // labelNote
            // 
            this.labelNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNote.Location = new System.Drawing.Point(153, 370);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(194, 60);
            this.labelNote.TabIndex = 17;
            this.labelNote.Text = "Ghi chú:";
            this.labelNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNote
            // 
            this.txtNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNote.Location = new System.Drawing.Point(353, 373);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(494, 54);
            this.txtNote.TabIndex = 18;
            // 
            // labelBorrowPrice
            // 
            this.labelBorrowPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBorrowPrice.Location = new System.Drawing.Point(153, 430);
            this.labelBorrowPrice.Name = "labelBorrowPrice";
            this.labelBorrowPrice.Size = new System.Drawing.Size(194, 40);
            this.labelBorrowPrice.TabIndex = 21;
            this.labelBorrowPrice.Text = "Giá mượn:";
            this.labelBorrowPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBorrowPrice
            // 
            this.txtBorrowPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBorrowPrice.Location = new System.Drawing.Point(353, 433);
            this.txtBorrowPrice.Name = "txtBorrowPrice";
            this.txtBorrowPrice.Size = new System.Drawing.Size(494, 22);
            this.txtBorrowPrice.TabIndex = 22;
            // 
            // labelSalePrice
            // 
            this.labelSalePrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSalePrice.Location = new System.Drawing.Point(153, 470);
            this.labelSalePrice.Name = "labelSalePrice";
            this.labelSalePrice.Size = new System.Drawing.Size(194, 40);
            this.labelSalePrice.TabIndex = 23;
            this.labelSalePrice.Text = "Giá bán:";
            this.labelSalePrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrice
            // 
            this.txtPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrice.Location = new System.Drawing.Point(353, 473);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(494, 22);
            this.txtPrice.TabIndex = 24;
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(353, 513);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(494, 54);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(117, 48);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.Location = new System.Drawing.Point(126, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(117, 48);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Location = new System.Drawing.Point(249, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(117, 48);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Location = new System.Drawing.Point(372, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(119, 48);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // dgvBook
            // 
            this.dgvBook.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvBook, 4);
            this.dgvBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBook.Location = new System.Drawing.Point(3, 573);
            this.dgvBook.Name = "dgvBook";
            this.dgvBook.RowHeadersWidth = 51;
            this.dgvBook.RowTemplate.Height = 24;
            this.dgvBook.Size = new System.Drawing.Size(994, 124);
            this.dgvBook.TabIndex = 20;
            // 
            // FormBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormBook";
            this.Text = "Quản lý sách";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBook)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelTitleForm;
        private System.Windows.Forms.Label labelBookTitle;
        private System.Windows.Forms.TextBox txtBookTitle;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.ComboBox cbAuthor;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label labelPublisher;
        private System.Windows.Forms.ComboBox cbPublisher;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.ComboBox cbLocation;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label labelAvailable;
        private System.Windows.Forms.TextBox txtAvailable;
        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label labelBorrowPrice;
        private System.Windows.Forms.TextBox txtBorrowPrice;
        private System.Windows.Forms.Label labelSalePrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvBook;
    }
}
