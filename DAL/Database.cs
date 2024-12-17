using System;
using System.Data;
using System.Data.SqlClient;
using BTL_TEST.DTO;

namespace BTL_TEST.DAL
{
    public class TaiKhoanDAL
    {
        private string connectionString = "Data Source=ADMIN-PC\\PHAMNAM;Initial Catalog=QuanLyGiaoVien;Integrated Security=True"; // Chuỗi kết nối đến SQL Server

        public TaiKhoanDTO DangNhap(string tenDangNhap, string matKhau)
        {
            TaiKhoanDTO taiKhoan = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT TaiKhoanID, TenDangNhap, MatKhau, GiangVienID, VaiTro FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau;\r\n";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", matKhau);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    taiKhoan = new TaiKhoanDTO
                    {
                        TaiKhoanID = reader.GetInt32(0),
                        TenDangNhap = reader.GetString(1),
                        MatKhau = reader.GetString(2),
                        GiangVienID = reader.IsDBNull(3) ? 0 : reader.GetInt32(3), // Xử lý NULL
                        VaiTro = reader.GetString(4)
                    };

                }
                reader.Close();
            }
            return taiKhoan;
        }
        // Thêm tài khoản
        public bool ThemTaiKhoan(TaiKhoanDTO taiKhoan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO TaiKhoan (TenDangNhap, MatKhau, GiangVienID, VaiTro) VALUES (@TenDangNhap, @MatKhau, @GiangVienID, @VaiTro)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenDangNhap", taiKhoan.TenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", taiKhoan.MatKhau);

                if (taiKhoan.GiangVienID == 0) // Trường hợp GiangVienID là NULL
                {
                    cmd.Parameters.AddWithValue("@GiangVienID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@GiangVienID", taiKhoan.GiangVienID);
                }

                cmd.Parameters.AddWithValue("@VaiTro", taiKhoan.VaiTro);
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        // Sửa tài khoản
        public bool SuaTaiKhoan(TaiKhoanDTO taiKhoan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE TaiKhoan SET TenDangNhap = @TenDangNhap, MatKhau = @MatKhau, GiangVienID = @GiangVienID, VaiTro = @VaiTro WHERE TaiKhoanID = @TaiKhoanID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TaiKhoanID", taiKhoan.TaiKhoanID);
                cmd.Parameters.AddWithValue("@TenDangNhap", taiKhoan.TenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", taiKhoan.MatKhau);

                if (taiKhoan.GiangVienID == 0) // Trường hợp GiangVienID là NULL
                {
                    cmd.Parameters.AddWithValue("@GiangVienID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@GiangVienID", taiKhoan.GiangVienID);
                }

                cmd.Parameters.AddWithValue("@VaiTro", taiKhoan.VaiTro);
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        // Xóa tài khoản
        public bool XoaTaiKhoan(int taiKhoanID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM TaiKhoan WHERE TaiKhoanID = @TaiKhoanID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TaiKhoanID", taiKhoanID);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Lấy tất cả tài khoản
        public DataTable LayTatCaTaiKhoan()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM TaiKhoan";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

    }
}
