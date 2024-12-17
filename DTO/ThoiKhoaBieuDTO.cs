using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThoiKhoaBieuDTO
    {
        public int TKBID { get; set; }
        public int LopID { get; set; }
        public int MonHocID { get; set; }
        public int GiangVienID { get; set; }
        public DateTime NgayHoc { get; set; }
        public int CaHoc { get; set; }

        // Thuộc tính mới
        public string TenLop { get; set; }
        public string TenMon { get; set; }
        public string HoTenGiangVien { get; set; }
    }


}

