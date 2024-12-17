using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_TEST
{
    public partial class Luong : Form
    {
        private string connectionString = "Data Source=ADMIN-PC\\PHAMNAM;Initial Catalog=QuanLyGiaoVien;Integrated Security=True";
        public Luong()
        {
            InitializeComponent();
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
                     WHERE DDBH.GiangVienID = GV.GiangVienID AND DDBH.TrangThai = 1 AND DDBH.DaTamUng = 0) AS SoBuoiDay
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
                        item.SubItems.Add(reader["SoBuoiDay"].ToString());

                        // Tính Tiền và Tiền Tạm Ứng
                        decimal donGia = Convert.ToDecimal(reader["DonGia"]);
                        decimal heSo = Convert.ToDecimal(reader["HeSo"]);
                        int soBuoiDay = Convert.ToInt32(reader["SoBuoiDay"]);
                        decimal tien = donGia * heSo * soBuoiDay * 3;

                        // Lấy Tiền Tạm Ứng
                        string giangVienID = reader["GiangVienID"].ToString();
                        decimal tienUng = GetTienUng(giangVienID);

                        // Tiền Thanh Toán = Tiền - Tiền Tạm Ứng
                        decimal tienThanhToan = tien - tienUng;

                        item.SubItems.Add(tien.ToString("N0"));
                        item.SubItems.Add(tienUng.ToString("N0"));
                        item.SubItems.Add(tienThanhToan.ToString("N0"));

                        listView1.Items.Add(item);
                    }
                }
            }
        }
        // Hàm lấy Tiền Tạm Ứng từ bảng BangTamUng
        private decimal GetTienUng(string giangVienID)
        {
            decimal tienUng = 0;
            string query = "SELECT ISNULL(SUM(SoTienTamUng), 0) FROM BangTamUng WHERE GiangVienID = @GiangVienID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@GiangVienID", giangVienID);

                connection.Open();
                tienUng = Convert.ToDecimal(command.ExecuteScalar());
            }

            return tienUng;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            LoadDataToListView(txtID.Text, txtTen.Text);
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            LoadDataToListView(txtID.Text, txtTen.Text);
        }

        private void labTienUng_Click(object sender, EventArgs e)
        {

        }

        private void labTien_Click(object sender, EventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string filterID = txtID.Text;
            string filterName = txtTen.Text;
            LoadDataToListView(filterID, filterName);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
