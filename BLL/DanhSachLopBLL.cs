using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL; 
using DTO;

namespace BLL
{
    public class DanhSachLopBLL
    {
        private DanhSachLopDAL dal = new DanhSachLopDAL();

        public bool ThemLop(DanhSachLopDTO lop)
        {
            return dal.ThemLop(lop);
        }
        public DataTable LayTatCaLopHoc()
        {
            return dal.LayTatCaLopHoc();
        }
        public bool ThemMonHocChoLop(MonHocDTO monHoc, DanhSachLopDTO danhSachLop)
        {
            return dal.ThemMonHocChoLop(monHoc, danhSachLop);
        }
        public bool KiemTraLopTonTai(string tenLop)
        {
            return dal.KiemTraLopTonTai(tenLop);
        }
        public DataTable LayDanhSachMonHoc()
        {
            return dal.LayDanhSachMonHoc();
        }
        public bool SuaLop(DanhSachLopDTO lop)
        {
            return dal.SuaLop(lop);
        }
    }
}
