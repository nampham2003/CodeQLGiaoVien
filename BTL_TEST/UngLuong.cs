using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_TEST
{
    public partial class UngLuong : Form
    {
        private string connectionString = "Data Source=ADMIN-PC\\PHAMNAM;Initial Catalog=QuanLyGiaoVien;Integrated Security=True";

        public UngLuong()
        {
            InitializeComponent();
            LoadDataToListView();
        }

        private void UngLuong_Load(object sender, EventArgs e)
        {
            LoadDataToListView();
        }

        private void LoadDataToListView(string filterID = "", string filterName = "")
        {
            string query = @"
        SELECT 
            GV.GiangVienID,
            GV.HoTen,
            GV.HocHam,
            GV.HocVi,
            LH.TenLop AS Lop,
            HS.HeSo AS HeSo,
            CASE 
                WHEN CD1.GiaTienDay >= ISNULL(CD2.GiaTienDay, 0) THEN GV.HocHam
                ELSE GV.HocVi
            END AS ChucVu,
            CASE 
                WHEN CD1.GiaTienDay >= ISNULL(CD2.GiaTienDay, 0) THEN CD1.GiaTienDay
                ELSE CD2.GiaTienDay
            END AS DonGia,
            (SELECT COUNT(*) 
             FROM DiemDanhBuoiHoc DDBH 
             WHERE DDBH.GiangVienID = GV.GiangVienID AND DDBH.TrangThai = 1 AND DDBH.DaTamUng = 0) AS SoBuoiDaDay,
            (CASE 
                WHEN CD1.GiaTienDay >= ISNULL(CD2.GiaTienDay, 0) THEN CD1.GiaTienDay
                ELSE CD2.GiaTienDay
            END * HS.HeSo * 
            (SELECT COUNT(*) 
             FROM DiemDanhBuoiHoc DDBH 
             WHERE DDBH.GiangVienID = GV.GiangVienID AND DDBH.TrangThai = 1 AND DDBH.DaTamUng = 0) * 3) AS TienUng
        FROM 
            GiangVien GV
        LEFT JOIN 
            ChucDanh CD1 ON CD1.TenChucDanh = GV.HocHam
        LEFT JOIN 
            ChucDanh CD2 ON CD2.TenChucDanh = GV.HocVi
        LEFT JOIN 
            ThoiKhoaBieu TKB ON GV.GiangVienID = TKB.GiangVienID
        LEFT JOIN 
            LopHoc LH ON LH.LopID = TKB.LopID
        LEFT JOIN 
            HeSo HS ON LH.SiSo BETWEEN HS.SiSoTu AND ISNULL(HS.SiSoDen, 9999)
        WHERE 
            TKB.LopID IS NOT NULL
            AND (@filterID = '' OR GV.GiangVienID LIKE '%' + @filterID + '%')
            AND (@filterName = '' OR GV.HoTen LIKE '%' + @filterName + '%')
        GROUP BY 
            GV.GiangVienID, GV.HoTen, GV.HocHam, GV.HocVi, LH.TenLop, HS.HeSo, CD1.GiaTienDay, CD2.GiaTienDay;
    ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@filterID", filterID);
                command.Parameters.AddWithValue("@filterName", filterName);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    listView1.Items.Clear();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["GiangVienID"].ToString());
                        item.SubItems.Add(reader["HoTen"].ToString());
                        item.SubItems.Add(reader["HocHam"].ToString());
                        item.SubItems.Add(reader["HocVi"].ToString());
                        item.SubItems.Add(reader["Lop"].ToString());
                        item.SubItems.Add(reader["HeSo"].ToString());
                        item.SubItems.Add(reader["ChucVu"].ToString());
                        item.SubItems.Add(reader["DonGia"].ToString());
                        item.SubItems.Add(reader["SoBuoiDaDay"].ToString());
                        item.SubItems.Add(reader["TienUng"].ToString());

                        listView1.Items.Add(item);
                    }
                }
            }
        }


        private void txtID_TextChanged(object sender, EventArgs e)
        {
            LoadDataToListView(txtID.Text, txtTen.Text);
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            LoadDataToListView(txtID.Text, txtTen.Text);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];

                // Đẩy ID và Tên lên các ô textBox
                txtID.Text = selectedItem.SubItems[0].Text;
                txtTen.Text = selectedItem.SubItems[1].Text;

                string selectedID = selectedItem.SubItems[0].Text;
                string selectedName = selectedItem.SubItems[1].Text;

                decimal totalTienUng = 0;

                // Duyệt qua tất cả các mục trong listView để cộng dồn TienUng cho các mục có cùng GiangVienID và HoTen
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.SubItems[0].Text == selectedID && item.SubItems[1].Text == selectedName)
                    {
                        string tienUngStr = item.SubItems[9].Text; // SubItems[9] là cột TienUng
                        if (decimal.TryParse(tienUngStr, out decimal tienUng))
                        {
                            totalTienUng += tienUng; // Cộng dồn TienUng
                        }
                    }
                }

                // Hiển thị tổng số tiền ứng lên labTongTien
                labTongTien.Text = "Số Tiền Tạm Ứng: " + totalTienUng.ToString("N0");
            }
        }

        private void btnUngLuong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn giảng viên trước khi ứng lương.");
                return;
            }

            // Lấy thông tin GiangVienID, SoTienUng và NgayUng từ các điều khiển trên form
            string giangVienID = txtID.Text;
            decimal soTienUng = 0;

            // Cộng dồn TienUng của giảng viên
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[0].Text == giangVienID)
                {
                    if (decimal.TryParse(item.SubItems[9].Text, out decimal tienUng))
                    {
                        soTienUng += tienUng;
                    }
                }
            }

            // Kiểm tra nếu tổng số tiền tạm ứng là 0
            if (soTienUng == 0)
            {
                MessageBox.Show("Không thể tạm ứng khi tổng số tiền tạm ứng là 0.");
                return;
            }

            DateTime ngayUng = dateTimePicker1.Value;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Lưu thông tin vào bảng BangTamUng
                string insertQuery = @"
                INSERT INTO BangTamUng (GiangVienID, SoTienTamUng, NgayTamUng)
                VALUES (@GiangVienID, @SoTienTamUng, @NgayTamUng)";

                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@GiangVienID", giangVienID);
                    insertCommand.Parameters.AddWithValue("@SoTienTamUng", soTienUng);
                    insertCommand.Parameters.AddWithValue("@NgayTamUng", ngayUng);

                    insertCommand.ExecuteNonQuery();
                }

                // Cập nhật trạng thái DaTamUng = 1 trong bảng DiemDanhBuoiHoc cho các buổi đã dạy của giảng viên
                string updateQuery = @"
                UPDATE DiemDanhBuoiHoc
                SET DaTamUng = 1
                WHERE GiangVienID = @GiangVienID AND TrangThai = 1 AND DaTamUng = 0";

                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@GiangVienID", giangVienID);
                    updateCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Đã ứng lương thành công và cập nhật trạng thái các buổi học.");

                // Hỏi người dùng có muốn xuất file không
                var result = MessageBox.Show("Bạn có muốn xuất thông tin ra file không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Text Files (*.txt)|*.txt",
                        FileName = "ThongTinUngLuong.txt"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                            {
                                writer.WriteLine("Thông Tin Ứng Lương");
                                writer.WriteLine("====================");
                                writer.WriteLine("Giảng Viên ID: " + giangVienID);
                                writer.WriteLine("Họ Tên: " + txtTen.Text);
                                writer.WriteLine("Ngày Tạm Ứng: " + ngayUng.ToShortDateString());
                                writer.WriteLine("Số Tiền Tạm Ứng: " + soTienUng.ToString("N0"));
                                writer.WriteLine("====================");
                                writer.WriteLine("Thời gian xuất: " + DateTime.Now);
                            }

                            MessageBox.Show("Đã xuất thông tin ra file thành công.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi ghi file: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void labTongTien_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

    }
}
