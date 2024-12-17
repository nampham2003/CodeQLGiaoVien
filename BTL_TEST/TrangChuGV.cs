using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace BTL_TEST
{
    public partial class TrangChuGV : Form
    {
        private string connectionString = "Data Source=ADMIN-PC\\PHAMNAM;Initial Catalog=QuanLyGiaoVien;Integrated Security=True"; // Chuỗi kết nối đến SQL Server
        public string TenDangNhap { get; set; } // Thuộc tính nhận tên đăng nhập
        public int GiangVienID { get; set; } // Thuộc Tính nhận ID

        public TrangChuGV()
        {
            InitializeComponent();
        }

        private void TrangChuGV_Load(object sender, EventArgs e)
        {
            txtTen.Text = TenDangNhap; // Hiển thị tên đăng nhập trên textbox txtTen
            LoadClassesForTeacher(); // Load các lớp vào ComboBox
            LoadScheduleForSelectedDate(); // Tải thời khóa biểu cho ngày hiện tại
            dateTimePicker.ValueChanged += dateTimePicker_ValueChanged_1;// Thêm sự kiện cho DateTimePicker
        }
        private void LoadClassesForTeacher()
        {
            // Query to get classes for the teacher's schedule in ThoiKhoaBieu
            string query = @"
                SELECT DISTINCT LopHoc.LopID, LopHoc.TenLop
                FROM ThoiKhoaBieu
                INNER JOIN LopHoc ON ThoiKhoaBieu.LopID = LopHoc.LopID
                WHERE ThoiKhoaBieu.GiangVienID = @GiangVienID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@GiangVienID", GiangVienID); // Use GiangVienID as a parameter

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Clear previous items and load new ones into ComboBox
                    cbbLop.Items.Clear();
                    while (reader.Read())
                    {
                        int lopID = reader.GetInt32(0);
                        string tenLop = reader.GetString(1);
                        cbbLop.Items.Add(new ComboBoxItem { LopID = lopID, TenLop = tenLop });
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading classes: " + ex.Message);
            }
        }
        
        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                var selectedItem = listView.SelectedItems[0];
                txtTKBID.Text = selectedItem.SubItems[0].Text;
                cbbLop.Text = selectedItem.SubItems[1].Text;
                txtMonHoc.Text = selectedItem.SubItems[2].Text;
                txtCaHoc.Text = selectedItem.SubItems[3].Text;
                checkBox1.Checked = selectedItem.SubItems[4].Text == "Đã dạy";
                txtGhiChu.Text = selectedItem.SubItems[5].Text;
            }
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
            DangNhap dangNhapForm = new DangNhap();
            dangNhapForm.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtTen_Click(object sender, EventArgs e)
        {

        }

        private void cbbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Xử lý khi thay đổi lựa chọn lớp nếu cần
        }
        private class ComboBoxItem
        {
            public int LopID { get; set; }
            public string TenLop { get; set; }

            public override string ToString()
            {
                return TenLop; // Display the class name in ComboBox
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtGhiChu_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem TKBID đã tồn tại trong bảng DiemDanhBuoiHoc hay chưa
            string checkQuery = "SELECT COUNT(*) FROM DiemDanhBuoiHoc WHERE TKBID = @TKBID AND GiangVienID = @GiangVienID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@TKBID", int.Parse(txtTKBID.Text));
                    checkCommand.Parameters.AddWithValue("@GiangVienID", GiangVienID);

                    connection.Open();
                    int count = (int)checkCommand.ExecuteScalar(); // Lấy số lượng bản ghi tồn tại

                    if (count > 0)
                    {
                        MessageBox.Show("Thông tin điểm danh đã tồn tại. Vui lòng sửa thông tin đã có.");
                        return; // Ngừng thực hiện thêm mới nếu thông tin đã tồn tại
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra thông tin điểm danh: " + ex.Message);
                return;
            }

            // Nếu không có thông tin nào tồn tại, thực hiện thêm mới
            string insertQuery = @"
        INSERT INTO DiemDanhBuoiHoc (TKBID, GiangVienID, TrangThai, GhiChu)
        VALUES (@TKBID, @GiangVienID, @TrangThai, @GhiChu)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@TKBID", int.Parse(txtTKBID.Text));
                    insertCommand.Parameters.AddWithValue("@GiangVienID", GiangVienID);
                    insertCommand.Parameters.AddWithValue("@TrangThai", checkBox1.Checked);
                    insertCommand.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);

                    connection.Open();
                    int result = insertCommand.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Đã thêm thông tin điểm danh thành công.");
                        LoadScheduleForSelectedDate(); // Tải lại danh sách sau khi thêm mới
                    }
                    else
                    {
                        MessageBox.Show("Thêm thông tin điểm danh không thành công.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm thông tin điểm danh: " + ex.Message);
            }
        }


        private void btnThongTinTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void txtCaHoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_ValueChanged_1(object sender, EventArgs e)
        {
            LoadScheduleForSelectedDate(); // Tải thời khóa biểu mới khi thay đổi ngày
        }
        // Hàm tải thời khóa biểu dựa trên ngày được chọn trong DateTimePicker
        private void LoadScheduleForSelectedDate()
        {
            string selectedDate = dateTimePicker.Value.ToString("yyyy-MM-dd"); // Lấy ngày được chọn
            string query = @"
        SELECT 
            ThoiKhoaBieu.TKBID, 
            LopHoc.TenLop, 
            MonHoc.TenMon, 
            ThoiKhoaBieu.CaHoc, 
            DiemDanhBuoiHoc.TrangThai, 
            DiemDanhBuoiHoc.GhiChu
        FROM ThoiKhoaBieu
        INNER JOIN LopHoc ON ThoiKhoaBieu.LopID = LopHoc.LopID
        INNER JOIN MonHoc ON ThoiKhoaBieu.MonHocID = MonHoc.MonHocID
        LEFT JOIN DiemDanhBuoiHoc ON ThoiKhoaBieu.TKBID = DiemDanhBuoiHoc.TKBID
            AND DiemDanhBuoiHoc.GiangVienID = @GiangVienID
        WHERE ThoiKhoaBieu.GiangVienID = @GiangVienID 
            AND ThoiKhoaBieu.NgayHoc = @NgayHoc";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@GiangVienID", GiangVienID);
                    command.Parameters.AddWithValue("@NgayHoc", selectedDate);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    listView.Items.Clear(); // Xóa các mục cũ trước khi tải mới
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["TKBID"].ToString());
                        item.SubItems.Add(reader["TenLop"].ToString());
                        item.SubItems.Add(reader["TenMon"].ToString());
                        item.SubItems.Add(reader["CaHoc"].ToString());

                        // Kiểm tra trạng thái điểm danh
                        bool trangThai = reader["TrangThai"] != DBNull.Value && (bool)reader["TrangThai"];
                        item.SubItems.Add(trangThai ? "Đã dạy" : "Chưa dạy");

                        item.SubItems.Add(reader["GhiChu"].ToString() ?? ""); // Ghi chú hoặc để trống

                        listView.Items.Add(item);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thời khóa biểu: " + ex.Message);
            }
        }
    }
}
