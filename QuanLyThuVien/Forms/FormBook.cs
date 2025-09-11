using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien.Forms
{
    public partial class FormBook : Form
    {
        connectData c = new connectData(); // dùng class connectData

        public FormBook()
        {
            InitializeComponent();
            LoadData();
            LoadComboboxes();
        }

        // ===== Load dữ liệu bảng Books =====
        private void LoadData()
        {
            try
            {
                c.connect();
                string sql = "SELECT BookID, Title, AuthorID, CategoryID, PublisherID, YearPublished, LocationID, Quantity, Available, Note FROM Books";
                SqlDataAdapter da = new SqlDataAdapter(sql, c.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvBook.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                c.disconnect();
            }
        }

        // ===== Load dữ liệu cho các combobox =====
        private void LoadComboboxes()
        {
            LoadComboBox(cbAuthor,
                "SELECT AuthorID, (LastName + ' ' + FirstName) AS AuthorName FROM Authors",
                "AuthorName", "AuthorID");

            LoadComboBox(cbCategory,
                "SELECT CategoryID, CategoryName FROM Categories",
                "CategoryName", "CategoryID");

            LoadComboBox(cbPublisher,
                "SELECT PublisherID, PublisherName FROM Publishers",
                "PublisherName", "PublisherID");

            LoadComboBox(cbLocation,
                "SELECT LocationID, (Floor + ' - ' + Room + ' - ' + ShelfCode) AS LocationName FROM BookLocations",
                "LocationName", "LocationID");
        }

        private void LoadComboBox(ComboBox comboBox, string query, string display, string value)
        {
            try
            {
                c.connect();
                SqlDataAdapter da = new SqlDataAdapter(query, c.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox.DataSource = dt;
                comboBox.DisplayMember = display;
                comboBox.ValueMember = value;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load combobox: " + ex.Message);
            }
            finally
            {
                c.disconnect();
            }
        }

        // ===== Click vào DataGridView -> hiện dữ liệu =====
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

        // ===== Thêm sách =====
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(txtBookTitle.Text))
            {
                MessageBox.Show("Tên sách không được để trống!");
                return;
            }
            if (cbAuthor.SelectedValue == null || cbCategory.SelectedValue == null ||
                cbPublisher.SelectedValue == null || cbLocation.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Tác giả, Thể loại, NXB, Vị trí!");
                return;
            }

            if (!int.TryParse(txtYear.Text, out int year) ||
                !int.TryParse(txtQuantity.Text, out int quantity) ||
                !int.TryParse(txtAvailable.Text, out int available))
            {
                MessageBox.Show("Năm, số lượng, có sẵn phải là số!");
                return;
            }

            try
            {
                c.connect();
                string sql = @"INSERT INTO Books 
                            (Title, AuthorID, CategoryID, PublisherID, YearPublished, LocationID, Quantity, Available, Note) 
                            VALUES (@Title, @AuthorID, @CategoryID, @PublisherID, @YearPublished, @LocationID, @Quantity, @Available, @Note)";
                SqlCommand cmd = new SqlCommand(sql, c.conn);
                cmd.Parameters.AddWithValue("@Title", txtBookTitle.Text);
                cmd.Parameters.AddWithValue("@AuthorID", cbAuthor.SelectedValue);
                cmd.Parameters.AddWithValue("@CategoryID", cbCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@PublisherID", cbPublisher.SelectedValue);
                cmd.Parameters.AddWithValue("@YearPublished", year);
                cmd.Parameters.AddWithValue("@LocationID", cbLocation.SelectedValue);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Available", available);
                cmd.Parameters.AddWithValue("@Note", txtNote.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm sách thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
            finally
            {
                c.disconnect();
            }

            LoadData();
        }

        // ===== Sửa sách =====
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBook.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn sách để sửa!");
                return;
            }

            if (!int.TryParse(txtYear.Text, out int year) ||
                !int.TryParse(txtQuantity.Text, out int quantity) ||
                !int.TryParse(txtAvailable.Text, out int available))
            {
                MessageBox.Show("Năm, số lượng, có sẵn phải là số!");
                return;
            }

            int bookId = Convert.ToInt32(dgvBook.CurrentRow.Cells["BookID"].Value);

            try
            {
                c.connect();
                string sql = @"UPDATE Books 
                               SET Title=@Title, AuthorID=@AuthorID, CategoryID=@CategoryID, PublisherID=@PublisherID,
                                   YearPublished=@YearPublished, LocationID=@LocationID, Quantity=@Quantity, Available=@Available, Note=@Note
                               WHERE BookID=@BookID";
                SqlCommand cmd = new SqlCommand(sql, c.conn);
                cmd.Parameters.AddWithValue("@BookID", bookId);
                cmd.Parameters.AddWithValue("@Title", txtBookTitle.Text);
                cmd.Parameters.AddWithValue("@AuthorID", cbAuthor.SelectedValue);
                cmd.Parameters.AddWithValue("@CategoryID", cbCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@PublisherID", cbPublisher.SelectedValue);
                cmd.Parameters.AddWithValue("@YearPublished", year);
                cmd.Parameters.AddWithValue("@LocationID", cbLocation.SelectedValue);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Available", available);
                cmd.Parameters.AddWithValue("@Note", txtNote.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Sửa sách thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
            }
            finally
            {
                c.disconnect();
            }

            LoadData();
        }

        // ===== Xoá sách =====
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBook.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn sách để xoá!");
                return;
            }

            int bookId = Convert.ToInt32(dgvBook.CurrentRow.Cells["BookID"].Value);

            if (MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    c.connect();
                    string sql = "DELETE FROM Books WHERE BookID=@BookID";
                    SqlCommand cmd = new SqlCommand(sql, c.conn);
                    cmd.Parameters.AddWithValue("@BookID", bookId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xoá thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xoá: " + ex.Message);
                }
                finally
                {
                    c.disconnect();
                }

                LoadData();
            }
        }

        // ===== Tìm kiếm =====
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                c.connect();
                string sql = "SELECT * FROM Books WHERE Title LIKE @keyword";
                SqlCommand cmd = new SqlCommand(sql, c.conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + txtBookTitle.Text.Trim() + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvBook.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
            finally
            {
                c.disconnect();
            }
        }
    }
}
