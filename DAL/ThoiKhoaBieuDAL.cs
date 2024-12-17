using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class ThoiKhoaBieuDAL
    {
        private string connectionString = "Data Source=ADMIN-PC\\PHAMNAM;Initial Catalog=QuanLyGiaoVien;Integrated Security=True";

        public List<MonHocDTO> GetMonHoc()
        {
            List<MonHocDTO> monHocs = new List<MonHocDTO>();
            string query = "SELECT MonHocID, TenMon, SoTinChi FROM MonHoc";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                monHocs.Add(new MonHocDTO
                                {
                                    MonHocID = reader.GetInt32(0),
                                    TenMon = reader.GetString(1),
                                    SoTinChi = reader.GetInt32(2)
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception hoặc xử lý lỗi
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return monHocs;
        }


        public List<GiangVienDTO> GetGiangVienByMonHoc(int monHocID)
        {
            List<GiangVienDTO> giangViens = new List<GiangVienDTO>();
            string query = @"SELECT GV.GiangVienID, GV.HoTen 
                             FROM GiangVien AS GV
                             INNER JOIN GiaoVienMonHoc AS GVMH ON GV.GiangVienID = GVMH.GiangVienID
                             WHERE GVMH.MonHocID = @MonHocID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MonHocID", monHocID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    giangViens.Add(new GiangVienDTO
                    {
                        GiangVienID = reader.GetInt32(0),
                        HoTen = reader.GetString(1)
                    });
                }
            }
            return giangViens;
        }

        public List<DanhSachLopDTO> GetLopHocByMonHoc(int monHocID)
        {
            List<DanhSachLopDTO> lopHocs = new List<DanhSachLopDTO>();
            string query = @"SELECT LH.LopID, LH.TenLop 
                             FROM LopHoc AS LH
                             INNER JOIN LopMonHoc AS LMH ON LH.LopID = LMH.LopID
                             WHERE LMH.MonHocID = @MonHocID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MonHocID", monHocID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lopHocs.Add(new DanhSachLopDTO
                    {
                        LopID = reader.GetInt32(0),
                        TenLop = reader.GetString(1)
                    });
                }
            }
            return lopHocs;
        }
        public List<ThoiKhoaBieuDTO> GetThoiKhoaBieu()
        {
            List<ThoiKhoaBieuDTO> thoiKhoaBieus = new List<ThoiKhoaBieuDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT ThoiKhoaBieu.TKBID, LopHoc.TenLop, MonHoc.TenMon, GiangVien.HoTen, ThoiKhoaBieu.NgayHoc, ThoiKhoaBieu.CaHoc
                         FROM ThoiKhoaBieu
                         JOIN LopHoc ON ThoiKhoaBieu.LopID = LopHoc.LopID
                         JOIN MonHoc ON ThoiKhoaBieu.MonHocID = MonHoc.MonHocID
                         JOIN GiangVien ON ThoiKhoaBieu.GiangVienID = GiangVien.GiangVienID";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ThoiKhoaBieuDTO tkb = new ThoiKhoaBieuDTO
                    {
                        TKBID = Convert.ToInt32(reader["TKBID"]),
                        TenLop = reader["TenLop"].ToString(),
                        TenMon = reader["TenMon"].ToString(),
                        HoTenGiangVien = reader["HoTen"].ToString(),
                        NgayHoc = Convert.ToDateTime(reader["NgayHoc"]),
                        CaHoc = Convert.ToInt32(reader["CaHoc"])
                    };
                    thoiKhoaBieus.Add(tkb);
                }
            }

            return thoiKhoaBieus;
        }

        public void AddThoiKhoaBieu(ThoiKhoaBieuDTO tkb)
        {
            string query = @"INSERT INTO ThoiKhoaBieu (LopID, MonHocID, GiangVienID, NgayHoc, CaHoc)
                             VALUES (@LopID, @MonHocID, @GiangVienID, @NgayHoc, @CaHoc)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@LopID", tkb.LopID);
                cmd.Parameters.AddWithValue("@MonHocID", tkb.MonHocID);
                cmd.Parameters.AddWithValue("@GiangVienID", tkb.GiangVienID);
                cmd.Parameters.AddWithValue("@NgayHoc", tkb.NgayHoc);
                cmd.Parameters.AddWithValue("@CaHoc", tkb.CaHoc);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        
        public List<DanhSachLopDTO> GetAvailableLopHocForMonHoc(int monHocID, DateTime ngayBatDau)
        {
            List<DanhSachLopDTO> availableLops = new List<DanhSachLopDTO>();

            string query = @"SELECT LH.LopID, LH.TenLop
                             FROM LopHoc AS LH
                             LEFT JOIN ThoiKhoaBieu AS TKB ON LH.LopID = TKB.LopID 
                                                           AND TKB.MonHocID = @MonHocID 
                                                           AND TKB.NgayHoc = @NgayBatDau
                             WHERE TKB.LopID IS NULL";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MonHocID", monHocID);
                cmd.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    availableLops.Add(new DanhSachLopDTO
                    {
                        LopID = reader.GetInt32(0),
                        TenLop = reader.GetString(1)
                    });
                }
            }

            return availableLops;
        }

        
        public bool KiemTraLopTrungLich(int lopID, int monHocID, DateTime ngayHoc, int caHoc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Lệnh SQL gọi hàm fnKiemTraLopTrungLich
                string query = "SELECT dbo.fnKiemTraLopTrungLich(@LopID, @MonHocID, @NgayHoc, @CaHoc)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LopID", lopID);
                command.Parameters.AddWithValue("@MonHocID", monHocID);
                command.Parameters.AddWithValue("@NgayHoc", ngayHoc);
                command.Parameters.AddWithValue("@CaHoc", caHoc);

                connection.Open();

                // Thực thi truy vấn và trả về kết quả
                return (bool)command.ExecuteScalar();
            }
        }

    }
}
