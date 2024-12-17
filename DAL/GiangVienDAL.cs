using System;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class GiangVienDAL
    {
        private string connectionString = "Data Source=ADMIN-PC\\PHAMNAM;Initial Catalog=QuanLyGiaoVien;Integrated Security=True";

        public DataTable GetAllGiangVien()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT GV.GiangVienID, GV.HoTen AS TenGiangVien, GV.HocHam, GV.HocVi, GV.Email, GV.Phone, MH.TenMon AS TenMonHoc FROM GiangVien AS GV LEFT JOIN GiaoVienMonHoc AS GVMH ON GV.GiangVienID = GVMH.GiangVienID LEFT JOIN  MonHoc AS MH ON GVMH.MonHocID = MH.MonHocID", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public bool AddGiangVien(GiangVienDTO gv)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO GiangVien (HoTen, HocHam, HocVi, Email, Phone) VALUES (@HoTen, @HocHam, @HocVi, @Email, @Phone)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HoTen", gv.HoTen);
                cmd.Parameters.AddWithValue("@HocHam", gv.HocHam);
                cmd.Parameters.AddWithValue("@HocVi", gv.HocVi);
                cmd.Parameters.AddWithValue("@Email", gv.Email);
                cmd.Parameters.AddWithValue("@Phone", gv.Phone);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateGiangVien(GiangVienDTO gv)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE GiangVien SET HoTen = @HoTen, HocHam = @HocHam, HocVi = @HocVi, Email = @Email, Phone = @Phone WHERE GiangVienID = @GiangVienID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@GiangVienID", gv.GiangVienID);
                cmd.Parameters.AddWithValue("@HoTen", gv.HoTen);
                cmd.Parameters.AddWithValue("@HocHam", gv.HocHam);
                cmd.Parameters.AddWithValue("@HocVi", gv.HocVi);
                cmd.Parameters.AddWithValue("@Email", gv.Email);
                cmd.Parameters.AddWithValue("@Phone", gv.Phone);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable LayDanhSachMonDay()
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
        public DataTable LayDanhSachHocHam()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT TenChucDanh FROM ChucDanh Where LoaiChucDanh = N'Học Hàm'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable LayDanhSachHocVi()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT TenChucDanh FROM ChucDanh Where LoaiChucDanh = N'Học Vị'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public bool ThemMonDayChoGiangVien(int giangVienID, int monHocID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO GiaoVienMonHoc (GiangVienID, MonHocID) VALUES (@GiangVienID, @MonHocID)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@GiangVienID", giangVienID);
                cmd.Parameters.AddWithValue("@MonHocID", monHocID);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}
