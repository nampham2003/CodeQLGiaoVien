using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class ThoiKhoaBieuBLL
    {
        private ThoiKhoaBieuDAL dal = new ThoiKhoaBieuDAL();

        public List<MonHocDTO> GetMonHoc() => dal.GetMonHoc();

        public List<GiangVienDTO> GetGiangVienByMonHoc(int monHocID) => dal.GetGiangVienByMonHoc(monHocID);

        public List<DanhSachLopDTO> GetLopHocByMonHoc(int monHocID) => dal.GetLopHocByMonHoc(monHocID);
        public List<ThoiKhoaBieuDTO> GetThoiKhoaBieu()
        {
            return dal.GetThoiKhoaBieu();
        }
        public void AddThoiKhoaBieu(ThoiKhoaBieuDTO tkb)
        {
            dal.AddThoiKhoaBieu(tkb);
        }
        public List<DanhSachLopDTO> GetAvailableLopHocForMonHoc(int monHocID, DateTime ngayBatDau)
        {
            return dal.GetAvailableLopHocForMonHoc(monHocID, ngayBatDau);
        }
        public bool KiemTraLopTrungLich(int lopID, int monHocID, DateTime ngayHoc, int caHoc)
        {
            return dal.KiemTraLopTrungLich(lopID, monHocID, ngayHoc, caHoc);
        }
    }
}

