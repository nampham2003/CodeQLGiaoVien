using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_TEST
{
    public partial class TrangChuAD : Form
    {
        bool isThoat = true;
        public string TenDangNhap { get; set; } // Thuộc tính nhận tên đăng nhập
        public TrangChuAD()
        {
            InitializeComponent();
        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(childForm);
            panel_Body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void TrangChuAD_Load(object sender, EventArgs e)
        {
            labadmin.Text = TenDangNhap; // Hiển thị tên đăng nhập trên textbox txtTen

        }

        private void DangXuat_Click(object sender, EventArgs e)
        {
            isThoat = false;
            this.Close();
            DangNhap f = new DangNhap();
            f.Show();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
                label1.Text = "Trang Chủ Admin";
            }
        }

        private void btnQuanLyTK_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLyTaiKhoan());
            label1.Text = "Quản Lý Tài Khoản";
        }

        private void btnDanhSachGiangVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DanhSachGiangVien());
            label1.Text = "Danh Sách Giang Viên";
        }

        private void btnDanhSachLop_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DanhSachLop());
            label1.Text = "Danh sách lớp";
        }

        private void btnThoiKhoaBieu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThoiKhoaBieu());
            label1.Text = "Thời Khóa Biểu";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (isThoat)
                Application.Exit();
        }

        private void btnMonHoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MonHoc());
            label1.Text = "Môn Học";
        }

        private void btnLuongUng_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UngLuong());
            label1.Text = "Ứng Lương";
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Luong());
            label1.Text = "Lương";
        }
    }
}
