using BTL_TEST.DAL;
using DTO;
using System.Data;

namespace BLL
{
    public class MonHocBLL
    {
        MonHocDAL monHocDAL = new MonHocDAL();

        // Thêm môn học
        public bool ThemMonHoc(MonHocDTO monHoc)
        {
            return monHocDAL.ThemMonHoc(monHoc);
        }

        // Sửa môn học
        public bool SuaMonHoc(MonHocDTO monHoc)
        {
            return monHocDAL.SuaMonHoc(monHoc);
        }

        // Lấy tất cả môn học
        public DataTable LayTatCaMonHoc()
        {
            return monHocDAL.LayTatCaMonHoc();
        }
    }
}
