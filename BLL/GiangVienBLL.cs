using System;
using System.Data;
using DAL;
using DTO;

namespace BLL
{
    public class GiangVienBLL
    {
        GiangVienDAL dal = new GiangVienDAL();

        public DataTable GetAllGiangVien()
        {
            return dal.GetAllGiangVien();
        }

        public bool AddGiangVien(GiangVienDTO gv)
        {
            return dal.AddGiangVien(gv);
        }

        public bool UpdateGiangVien(GiangVienDTO gv)
        {
            return dal.UpdateGiangVien(gv);
        }
        public DataTable LayDanhSachMonDay()
        {
            return dal.LayDanhSachMonDay();
        }
        public DataTable LayDanhSachHocHam()
        {
            return dal.LayDanhSachHocHam();
        }
        public DataTable LayDanhSachHocVi()
        {
            return dal.LayDanhSachHocVi();
        }
        public bool ThemMonDayChoGiangVien(int giangVienID, int monHocID)
        {
            return dal.ThemMonDayChoGiangVien(giangVienID, monHocID);
        }

    }
}
