using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTL_TEST.DAL;
using BTL_TEST.DTO;

namespace BTL_TEST.BLL
{
    public class TaiKhoanBLL
    {
        private TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();

        public TaiKhoanDTO KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            TaiKhoanDTO taiKhoan = taiKhoanDAL.DangNhap(tenDangNhap, matKhau);
            if (taiKhoan != null)
            {
                // Xử lý logic đăng nhập thành công
                return taiKhoan;
            }
            else
            {
                // Xử lý logic khi đăng nhập thất bại
                return null;
            }
        }
        // Thêm tài khoản
        public bool ThemTaiKhoan(TaiKhoanDTO taiKhoan)
        {
            return taiKhoanDAL.ThemTaiKhoan(taiKhoan);
        }

        // Sửa tài khoản
        public bool SuaTaiKhoan(TaiKhoanDTO taiKhoan)
        {
            return taiKhoanDAL.SuaTaiKhoan(taiKhoan);
        }

        // Xóa tài khoản
        public bool XoaTaiKhoan(int taiKhoanID)
        {
            return taiKhoanDAL.XoaTaiKhoan(taiKhoanID);
        }

        // Lấy tất cả tài khoản
        public DataTable LayTatCaTaiKhoan()
        {
            return taiKhoanDAL.LayTatCaTaiKhoan();
        }
    }
}

