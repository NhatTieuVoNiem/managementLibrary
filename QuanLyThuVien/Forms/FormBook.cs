using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien.Forms
{
    public partial class FormBook : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=LibraryManagement;Integrated Security=True";
        SqlConnection conn;
        SqlDataAdapter da;
        DataTable dt;

        public FormBook()
        {
            InitializeComponent();
            LoadData();
            LoadComboboxes();
        }

        // Load dữ liệu bảng Books
        private void LoadData()
        {
            conn = new SqlConnection(connectionString);
            string sql = "SELECT BookID, Title, AuthorID, CategoryID, PublisherID, YearPublished, LocationID, Quantity, Available, Note FROM Books";
            da = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            dgvBook.DataSource = dt;
        }

        // Load dữ liệu cho các combobox (Author, Category, Publisher, Location)
        private void LoadComboboxes()
        {
            // Author
            LoadComboBox(cbAuthor,
                "SELECT AuthorID, (LastName + ' ' + FirstName) AS AuthorName FROM Authors",
                "AuthorName", "AuthorID");

            // Category
            LoadComboBox(cbCategory,
                "SELECT CategoryID, CategoryName FROM Categories",
                "CategoryName", "CategoryID");

            // Publisher
            LoadComboBox(cbPublisher,
                "SELECT PublisherID, PublisherName FROM Publishers",
                "PublisherName", "PublisherID");

            // Location (hiển thị chi tiết hơn)
            LoadComboBox(cbLocation,
                "SELECT LocationID, (Floor + ' - ' + Room + ' - ' + ShelfCode) AS LocationName FROM BookLocations",
                "LocationName", "LocationID");
        }

        private void LoadComboBox(ComboBox comboBox, string query, string display, string value)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox.DataSource = dt;
                comboBox.DisplayMember = display;
                comboBox.ValueMember = value;
            }
        }

        // Click vào dòng trên DataGridView -> hiện dữ liệu ra các ô
        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtBookTitle.Text = dgvBook.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                cbAuthor.SelectedValue = dgvBook.Rows[e.RowIndex].Cells["AuthorID"].Value;
                cbCategory.SelectedValue = dgvBook.Rows[e.RowIndex].Cells["CategoryID"].Value;
                cbPublisher.SelectedValue = dgvBook.Rows[e.RowIndex].Cells["PublisherID"].Value;
                txtYear.Text = dgvBook.Rows[e.RowIndex].Cells["YearPublished"].Value.ToString();
                cbLocation.SelectedValue = dgvBook.Rows[e.RowIndex].Cells["LocationID"].Value;
                txtQuantity.Text = dgvBook.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
                txtAvailable.Text = dgvBook.Rows[e.RowIndex].Cells["Available"].Value.ToString();
                txtNote.Text = dgvBook.Rows[e.RowIndex].Cells["Note"].Value.ToString();
            }
        }

        // Thêm sách
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra nhập liệu
            if (string.IsNullOrWhiteSpace(txtBookTitle.Text))
            {
                MessageBox.Show("Tên sách không được để trống!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbAuthor.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Tác giả!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbCategory.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Thể loại!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbPublisher.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Nhà xuất bản!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbLocation.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Vị trí sách!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int year, quantity, available;

            if (!int.TryParse(txtYear.Text, out year))
            {
                MessageBox.Show("Năm xuất bản phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txtQuantity.Text, out quantity))
            {
                MessageBox.Show("Số lượng phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txtAvailable.Text, out available))
            {
                MessageBox.Show("Số lượng có sẵn phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu dữ liệu hợp lệ thì thêm vào DB
            string sql = "INSERT INTO Books (Title, AuthorID, CategoryID, PublisherID, YearPublished, LocationID, Quantity, Available, Note) " +
                         "VALUES (@Title, @AuthorID, @CategoryID, @PublisherID, @YearPublished, @LocationID, @Quantity, @Available, @Note)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Title", txtBookTitle.Text);
                cmd.Parameters.AddWithValue("@AuthorID", cbAuthor.SelectedValue);
                cmd.Parameters.AddWithValue("@CategoryID", cbCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@PublisherID", cbPublisher.SelectedValue);
                cmd.Parameters.AddWithValue("@YearPublished", year);
                cmd.Parameters.AddWithValue("@LocationID", cbLocation.SelectedValue);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Available", available);
                cmd.Parameters.AddWithValue("@Note", txtNote.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadData();
            MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        // Sửa thông tin sách
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBook.CurrentRow != null)
            {
                int bookId = Convert.ToInt32(dgvBook.CurrentRow.Cells["BookID"].Value);
                string sql = "UPDATE Books SET Title=@Title, AuthorID=@AuthorID, CategoryID=@CategoryID, PublisherID=@PublisherID, " +
                             "YearPublished=@YearPublished, LocationID=@LocationID, Quantity=@Quantity, Available=@Available, Note=@Note WHERE BookID=@BookID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@BookID", bookId);
                    cmd.Parameters.AddWithValue("@Title", txtBookTitle.Text);
                    cmd.Parameters.AddWithValue("@AuthorID", cbAuthor.SelectedValue);
                    cmd.Parameters.AddWithValue("@CategoryID", cbCategory.SelectedValue);
                    cmd.Parameters.AddWithValue("@PublisherID", cbPublisher.SelectedValue);
                    cmd.Parameters.AddWithValue("@YearPublished", txtYear.Text);
                    cmd.Parameters.AddWithValue("@LocationID", cbLocation.SelectedValue);
                    cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                    cmd.Parameters.AddWithValue("@Available", txtAvailable.Text);
                    cmd.Parameters.AddWithValue("@Note", txtNote.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadData();
            }
        }

        // Xóa sách
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBook.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một quyển sách để xoá!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            int bookId = Convert.ToInt32(dgvBook.CurrentRow.Cells["BookID"].Value);

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xoá quyển sách này không?",
                                              "Xác nhận xoá",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = "DELETE FROM Books WHERE BookID=@BookID";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@BookID", bookId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xoá sách thành công!",
                                            "Thông báo",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sách để xoá!",
                                            "Thông báo",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                        }
                    }

                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xoá: " + ex.Message,
                                    "Lỗi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }


        // Tìm kiếm sách theo tên
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtBookTitle.Text.Trim();
            string sql = "SELECT * FROM Books WHERE Title LIKE @keyword";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvBook.DataSource = dt;
            }
        }
    }
}
