using System.Data;
using System.Data.SqlClient;
using DTO;

namespace BTL_TEST.DAL
{
    public class MonHocDAL
    {
        private string connectionString = "Data Source=ADMIN-PC\\PHAMNAM;Initial Catalog=QuanLyGiaoVien;Integrated Security=True";

        // Thêm môn học
        public bool ThemMonHoc(MonHocDTO monHoc)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO MonHoc (TenMon, SoTinChi) VALUES (@TenMon, @SoTinChi)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenMon", monHoc.TenMon);
                cmd.Parameters.AddWithValue("@SoTinChi", monHoc.SoTinChi);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Sửa môn học
        public bool SuaMonHoc(MonHocDTO monHoc)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE MonHoc SET TenMon = @TenMon, SoTinChi = @SoTinChi WHERE MonHocID = @MonHocID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MonHocID", monHoc.MonHocID);
                cmd.Parameters.AddWithValue("@TenMon", monHoc.TenMon);
                cmd.Parameters.AddWithValue("@SoTinChi", monHoc.SoTinChi);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Lấy tất cả môn học
        public DataTable LayTatCaMonHoc()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM MonHoc";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
