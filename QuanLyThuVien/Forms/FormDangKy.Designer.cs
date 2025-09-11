namespace QuanLyThuVien
{
    partial class FormDangKy
    {
        private System.ComponentModel.IContainer components = null;

        // ===== Khai báo control =====
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;

        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;

        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;

        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;

        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;

        private System.Windows.Forms.Label lblQuestion1;
        private System.Windows.Forms.TextBox txtQuestion1;
        private System.Windows.Forms.Label lblAnswer1;
        private System.Windows.Forms.TextBox txtAnswer1;

        private System.Windows.Forms.Label lblQuestion2;
        private System.Windows.Forms.TextBox txtQuestion2;
        private System.Windows.Forms.Label lblAnswer2;
        private System.Windows.Forms.TextBox txtAnswer2;

        private System.Windows.Forms.Label lblQuestion3;
        private System.Windows.Forms.TextBox txtQuestion3;
        private System.Windows.Forms.Label lblAnswer3;
        private System.Windows.Forms.TextBox txtAnswer3;

        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;

        /// <summary>Giải phóng tài nguyên</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblQuestion1 = new System.Windows.Forms.Label();
            this.txtQuestion1 = new System.Windows.Forms.TextBox();
            this.lblAnswer1 = new System.Windows.Forms.Label();
            this.txtAnswer1 = new System.Windows.Forms.TextBox();
            this.lblQuestion2 = new System.Windows.Forms.Label();
            this.txtQuestion2 = new System.Windows.Forms.TextBox();
            this.lblAnswer2 = new System.Windows.Forms.Label();
            this.txtAnswer2 = new System.Windows.Forms.TextBox();
            this.lblQuestion3 = new System.Windows.Forms.Label();
            this.txtQuestion3 = new System.Windows.Forms.TextBox();
            this.lblAnswer3 = new System.Windows.Forms.Label();
            this.txtAnswer3 = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tittleRegister = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsername.Location = new System.Drawing.Point(141, 46);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(168, 34);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username:";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUsername
            // 
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsername.Location = new System.Drawing.Point(315, 48);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(516, 30);
            this.txtUsername.TabIndex = 0;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPassword.Location = new System.Drawing.Point(141, 80);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(168, 34);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Mật khẩu:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Location = new System.Drawing.Point(315, 82);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(516, 30);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConfirmPassword.Location = new System.Drawing.Point(141, 114);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(168, 34);
            this.lblConfirmPassword.TabIndex = 2;
            this.lblConfirmPassword.Text = "Nhập lại mật khẩu:";
            this.lblConfirmPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConfirmPassword.Location = new System.Drawing.Point(315, 116);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(516, 30);
            this.txtConfirmPassword.TabIndex = 2;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFullName.Location = new System.Drawing.Point(141, 148);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(168, 34);
            this.lblFullName.TabIndex = 3;
            this.lblFullName.Text = "Họ và tên:";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFullName
            // 
            this.txtFullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFullName.Location = new System.Drawing.Point(315, 150);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(516, 30);
            this.txtFullName.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmail.Location = new System.Drawing.Point(141, 182);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(168, 34);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.Location = new System.Drawing.Point(315, 184);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(516, 30);
            this.txtEmail.TabIndex = 4;
            // 
            // lblQuestion1
            // 
            this.lblQuestion1.AutoSize = true;
            this.lblQuestion1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuestion1.Location = new System.Drawing.Point(141, 216);
            this.lblQuestion1.Name = "lblQuestion1";
            this.lblQuestion1.Size = new System.Drawing.Size(168, 34);
            this.lblQuestion1.TabIndex = 5;
            this.lblQuestion1.Text = "Câu hỏi 1:";
            this.lblQuestion1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQuestion1
            // 
            this.txtQuestion1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuestion1.Location = new System.Drawing.Point(315, 218);
            this.txtQuestion1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtQuestion1.Name = "txtQuestion1";
            this.txtQuestion1.Size = new System.Drawing.Size(516, 30);
            this.txtQuestion1.TabIndex = 5;
            // 
            // lblAnswer1
            // 
            this.lblAnswer1.AutoSize = true;
            this.lblAnswer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAnswer1.Location = new System.Drawing.Point(141, 250);
            this.lblAnswer1.Name = "lblAnswer1";
            this.lblAnswer1.Size = new System.Drawing.Size(168, 34);
            this.lblAnswer1.TabIndex = 6;
            this.lblAnswer1.Text = "Trả lời 1:";
            this.lblAnswer1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAnswer1
            // 
            this.txtAnswer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAnswer1.Location = new System.Drawing.Point(315, 252);
            this.txtAnswer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAnswer1.Name = "txtAnswer1";
            this.txtAnswer1.Size = new System.Drawing.Size(516, 30);
            this.txtAnswer1.TabIndex = 6;
            // 
            // lblQuestion2
            // 
            this.lblQuestion2.AutoSize = true;
            this.lblQuestion2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuestion2.Location = new System.Drawing.Point(141, 284);
            this.lblQuestion2.Name = "lblQuestion2";
            this.lblQuestion2.Size = new System.Drawing.Size(168, 34);
            this.lblQuestion2.TabIndex = 7;
            this.lblQuestion2.Text = "Câu hỏi 2:";
            this.lblQuestion2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQuestion2
            // 
            this.txtQuestion2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuestion2.Location = new System.Drawing.Point(315, 286);
            this.txtQuestion2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtQuestion2.Name = "txtQuestion2";
            this.txtQuestion2.Size = new System.Drawing.Size(516, 30);
            this.txtQuestion2.TabIndex = 7;
            // 
            // lblAnswer2
            // 
            this.lblAnswer2.AutoSize = true;
            this.lblAnswer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAnswer2.Location = new System.Drawing.Point(141, 318);
            this.lblAnswer2.Name = "lblAnswer2";
            this.lblAnswer2.Size = new System.Drawing.Size(168, 34);
            this.lblAnswer2.TabIndex = 8;
            this.lblAnswer2.Text = "Trả lời 2:";
            this.lblAnswer2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAnswer2
            // 
            this.txtAnswer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAnswer2.Location = new System.Drawing.Point(315, 320);
            this.txtAnswer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAnswer2.Name = "txtAnswer2";
            this.txtAnswer2.Size = new System.Drawing.Size(516, 30);
            this.txtAnswer2.TabIndex = 8;
            // 
            // lblQuestion3
            // 
            this.lblQuestion3.AutoSize = true;
            this.lblQuestion3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuestion3.Location = new System.Drawing.Point(141, 352);
            this.lblQuestion3.Name = "lblQuestion3";
            this.lblQuestion3.Size = new System.Drawing.Size(168, 34);
            this.lblQuestion3.TabIndex = 9;
            this.lblQuestion3.Text = "Câu hỏi 3:";
            this.lblQuestion3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQuestion3
            // 
            this.txtQuestion3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuestion3.Location = new System.Drawing.Point(315, 354);
            this.txtQuestion3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtQuestion3.Name = "txtQuestion3";
            this.txtQuestion3.Size = new System.Drawing.Size(516, 30);
            this.txtQuestion3.TabIndex = 9;
            // 
            // lblAnswer3
            // 
            this.lblAnswer3.AutoSize = true;
            this.lblAnswer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAnswer3.Location = new System.Drawing.Point(141, 386);
            this.lblAnswer3.Name = "lblAnswer3";
            this.lblAnswer3.Size = new System.Drawing.Size(168, 34);
            this.lblAnswer3.TabIndex = 10;
            this.lblAnswer3.Text = "Trả lời 3:";
            this.lblAnswer3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAnswer3
            // 
            this.txtAnswer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAnswer3.Location = new System.Drawing.Point(315, 388);
            this.txtAnswer3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAnswer3.Name = "txtAnswer3";
            this.txtAnswer3.Size = new System.Drawing.Size(516, 30);
            this.txtAnswer3.TabIndex = 10;
            
            // 
            // btnRegister
            // 
            this.btnRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRegister.Location = new System.Drawing.Point(3, 2);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(252, 39);
            this.btnRegister.TabIndex = 11;
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(261, 2);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(252, 39);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.txtUsername, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPassword, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtConfirmPassword, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtFullName, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtEmail, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtQuestion1, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtAnswer1, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtQuestion2, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtAnswer2, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtQuestion3, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.txtAnswer3, 2, 11);
            this.tableLayoutPanel1.Controls.Add(this.lblUsername, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPassword, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblConfirmPassword, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblFullName, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblEmail, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblQuestion1, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblAnswer1, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblQuestion2, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblAnswer2, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.lblQuestion3, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.lblAnswer3, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.tittleRegister, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 12);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 14;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1044, 565);
            this.tableLayoutPanel1.TabIndex = 13;
            
            // 
            // tittleRegister
            // 
            this.tittleRegister.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.tittleRegister, 2);
            this.tittleRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tittleRegister.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tittleRegister.Location = new System.Drawing.Point(141, 0);
            this.tittleRegister.Name = "tittleRegister";
            this.tittleRegister.Size = new System.Drawing.Size(690, 46);
            this.tittleRegister.TabIndex = 13;
            this.tittleRegister.Text = "ĐĂNG KÝ TÀI KHOẢN";
            this.tittleRegister.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnRegister, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(315, 422);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(516, 43);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // FormDangKy
            // 
            this.AcceptButton = this.btnRegister;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1044, 565);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FormDangKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký tài khoản";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label tittleRegister;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
