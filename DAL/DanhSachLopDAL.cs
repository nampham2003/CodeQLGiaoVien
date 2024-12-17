using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DanhSachLopDAL
    {
        private string connectionString = "Data Source=.;Initial Catalog=QuanLyGiaoVien;Integrated Security=True"; // Cập nhật chuỗi kết nối của bạn

        public bool ThemLop(DanhSachLopDTO lop)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO LopHoc (TenLop, SiSo) VALUES (@TenLop, @SiSo)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenLop", lop.TenLop);
                cmd.Parameters.AddWithValue("@SiSo", lop.SiSo);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        
        // Phương thức lấy danh sách lớp học
        public DataTable LayTatCaLopHoc()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT \r\n    LopHoc.LopID AS IDLop,\r\n    LopHoc.TenLop,\r\n    LopHoc.SiSo,\r\n    MonHoc.TenMon,\r\n    MonHoc.SoTinChi\r\nFROM \r\n    LopHoc\r\nLEFT JOIN \r\n    LopMonHoc ON LopHoc.LopID = LopMonHoc.LopID\r\nLEFT JOIN \r\n    MonHoc ON LopMonHoc.MonHocID = MonHoc.MonHocID;\r\n";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        

        // Thêm môn học vào lớp trong bảng LopMonHoc
        public bool ThemMonHocChoLop(MonHocDTO monHoc,DanhSachLopDTO danhSachLop)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO LopMonHoc (LopID, MonHocID) VALUES (@LopID, @MonHocID)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LopID", danhSachLop.LopID);
                cmd.Parameters.AddWithValue("@MonHocID", monHoc.MonHocID);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool KiemTraLopTonTai(string tenLop)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM LopHoc WHERE TenLop = @TenLop";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenLop", tenLop);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        // Phương thức lấy danh sách môn học
        public DataTable LayDanhSachMonHoc()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MonHocID, TenMon FROM MonHoc";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public bool KiemTraMonHocTonTai(int lopID, int monHocID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM LopMonHoc WHERE LopID = @LopID AND MonHocID = @MonHocID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LopID", lopID);
                cmd.Parameters.AddWithValue("@MonHocID", monHocID);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool SuaLop(DanhSachLopDTO lop)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE LopHoc SET TenLop = @TenLop, SiSo = @SiSo WHERE LopID = @LopID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenLop", lop.TenLop);
                cmd.Parameters.AddWithValue("@SiSo", lop.SiSo);
                cmd.Parameters.AddWithValue("@LopID", lop.LopID);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}
