using System;
using System.Windows.Forms;
using BTL_TEST.BLL;
using BTL_TEST.DTO;

namespace BTL_TEST
{
    public partial class DangNhap : Form
    {
        private TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();

        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTaiKhoan.Text;
            string matKhau = txtPass.Text;

            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.");
                return;
            }

            TaiKhoanDTO taiKhoan = taiKhoanBLL.KiemTraDangNhap(tenDangNhap, matKhau);

            if (taiKhoan != null)
            {
                MessageBox.Show("Đăng nhập thành công với vai trò: " + taiKhoan.VaiTro);

                // Kiểm tra vai trò và mở form tương ứng
                if (taiKhoan.VaiTro == "Quản trị viên")
                {
                    TrangChuAD trangChuAD = new TrangChuAD();
                    trangChuAD.TenDangNhap = taiKhoan.TenDangNhap;  // Truyền tên đăng nhập
                    //trangChuAD.GiangVienID = taiKhoan.GiangVienID;
                    trangChuAD.Show();
                    this.Hide();
                }
                else if (taiKhoan.VaiTro == "Giáo viên")
                {
                    TrangChuGV trangchuGV = new TrangChuGV();
                    trangchuGV.TenDangNhap = taiKhoan.TenDangNhap;  // Truyền tên đăng nhập
                    trangchuGV.GiangVienID = taiKhoan.GiangVienID;
                    trangchuGV.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
