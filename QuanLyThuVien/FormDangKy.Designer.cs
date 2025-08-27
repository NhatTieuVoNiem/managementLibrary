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

            this.SuspendLayout();

            // ===== Username =====
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(40, 28);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(68, 15);
            this.lblUsername.Text = "Username:";
            this.txtUsername.Location = new System.Drawing.Point(150, 25);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(240, 23);
            this.txtUsername.TabIndex = 0;

            // ===== Password =====
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(40, 66);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(63, 15);
            this.lblPassword.Text = "Password:";
            this.txtPassword.Location = new System.Drawing.Point(150, 63);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(240, 23);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;

            // ===== Confirm Password =====
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(40, 104);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(109, 15);
            this.lblConfirmPassword.Text = "Nhập lại mật khẩu:";
            this.txtConfirmPassword.Location = new System.Drawing.Point(150, 101);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(240, 23);
            this.txtConfirmPassword.TabIndex = 2;
            this.txtConfirmPassword.UseSystemPasswordChar = true;

            // ===== Full Name =====
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(40, 142);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(67, 15);
            this.lblFullName.Text = "Họ và tên:";
            this.txtFullName.Location = new System.Drawing.Point(150, 139);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(240, 23);
            this.txtFullName.TabIndex = 3;

            // ===== Email =====
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(40, 180);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 15);
            this.lblEmail.Text = "Email:";
            this.txtEmail.Location = new System.Drawing.Point(150, 177);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(240, 23);
            this.txtEmail.TabIndex = 4;

            // ===== Câu hỏi 1 & Trả lời 1 =====
            this.lblQuestion1.AutoSize = true;
            this.lblQuestion1.Location = new System.Drawing.Point(40, 218);
            this.lblQuestion1.Name = "lblQuestion1";
            this.lblQuestion1.Size = new System.Drawing.Size(64, 15);
            this.lblQuestion1.Text = "Câu hỏi 1:";
            this.txtQuestion1.Location = new System.Drawing.Point(150, 215);
            this.txtQuestion1.Name = "txtQuestion1";
            this.txtQuestion1.Size = new System.Drawing.Size(240, 23);
            this.txtQuestion1.TabIndex = 5;

            this.lblAnswer1.AutoSize = true;
            this.lblAnswer1.Location = new System.Drawing.Point(40, 248);
            this.lblAnswer1.Name = "lblAnswer1";
            this.lblAnswer1.Size = new System.Drawing.Size(58, 15);
            this.lblAnswer1.Text = "Trả lời 1:";
            this.txtAnswer1.Location = new System.Drawing.Point(150, 245);
            this.txtAnswer1.Name = "txtAnswer1";
            this.txtAnswer1.Size = new System.Drawing.Size(240, 23);
            this.txtAnswer1.TabIndex = 6;

            // ===== Câu hỏi 2 & Trả lời 2 =====
            this.lblQuestion2.AutoSize = true;
            this.lblQuestion2.Location = new System.Drawing.Point(40, 286);
            this.lblQuestion2.Name = "lblQuestion2";
            this.lblQuestion2.Size = new System.Drawing.Size(64, 15);
            this.lblQuestion2.Text = "Câu hỏi 2:";
            this.txtQuestion2.Location = new System.Drawing.Point(150, 283);
            this.txtQuestion2.Name = "txtQuestion2";
            this.txtQuestion2.Size = new System.Drawing.Size(240, 23);
            this.txtQuestion2.TabIndex = 7;

            this.lblAnswer2.AutoSize = true;
            this.lblAnswer2.Location = new System.Drawing.Point(40, 316);
            this.lblAnswer2.Name = "lblAnswer2";
            this.lblAnswer2.Size = new System.Drawing.Size(58, 15);
            this.lblAnswer2.Text = "Trả lời 2:";
            this.txtAnswer2.Location = new System.Drawing.Point(150, 313);
            this.txtAnswer2.Name = "txtAnswer2";
            this.txtAnswer2.Size = new System.Drawing.Size(240, 23);
            this.txtAnswer2.TabIndex = 8;

            // ===== Câu hỏi 3 & Trả lời 3 =====
            this.lblQuestion3.AutoSize = true;
            this.lblQuestion3.Location = new System.Drawing.Point(40, 354);
            this.lblQuestion3.Name = "lblQuestion3";
            this.lblQuestion3.Size = new System.Drawing.Size(64, 15);
            this.lblQuestion3.Text = "Câu hỏi 3:";
            this.txtQuestion3.Location = new System.Drawing.Point(150, 351);
            this.txtQuestion3.Name = "txtQuestion3";
            this.txtQuestion3.Size = new System.Drawing.Size(240, 23);
            this.txtQuestion3.TabIndex = 9;

            this.lblAnswer3.AutoSize = true;
            this.lblAnswer3.Location = new System.Drawing.Point(40, 384);
            this.lblAnswer3.Name = "lblAnswer3";
            this.lblAnswer3.Size = new System.Drawing.Size(58, 15);
            this.lblAnswer3.Text = "Trả lời 3:";
            this.txtAnswer3.Location = new System.Drawing.Point(150, 381);
            this.txtAnswer3.Name = "txtAnswer3";
            this.txtAnswer3.Size = new System.Drawing.Size(240, 23);
            this.txtAnswer3.TabIndex = 10;

            // ===== Buttons =====
            this.btnRegister.Location = new System.Drawing.Point(150, 420);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(110, 32);
            this.btnRegister.TabIndex = 11;
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            this.btnCancel.Location = new System.Drawing.Point(280, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 32);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // ===== FormDangKy =====
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 480);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);

            this.Controls.Add(this.lblQuestion1);
            this.Controls.Add(this.txtQuestion1);
            this.Controls.Add(this.lblAnswer1);
            this.Controls.Add(this.txtAnswer1);

            this.Controls.Add(this.lblQuestion2);
            this.Controls.Add(this.txtQuestion2);
            this.Controls.Add(this.lblAnswer2);
            this.Controls.Add(this.txtAnswer2);

            this.Controls.Add(this.lblQuestion3);
            this.Controls.Add(this.txtQuestion3);
            this.Controls.Add(this.lblAnswer3);
            this.Controls.Add(this.txtAnswer3);

            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnCancel);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "FormDangKy";
            this.Text = "Đăng ký tài khoản";
            this.AcceptButton = this.btnRegister; // Enter = Đăng ký
            this.CancelButton = this.btnCancel;   // Esc = Hủy
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}
