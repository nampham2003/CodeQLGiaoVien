using System;
using System.Data;
using System.Windows.Forms;
using BTL_TEST.BLL;
using BTL_TEST.DTO;

namespace BTL_TEST
{
    public partial class QuanLyTaiKhoan : Form
    {
        TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();

        public QuanLyTaiKhoan()
        {
            InitializeComponent();
            LoadTaiKhoan();
        }

        private void LoadTaiKhoan()
        {
            listview_TaiKhoan.Items.Clear();
            DataTable dt = taiKhoanBLL.LayTatCaTaiKhoan();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["TaiKhoanID"].ToString());
                item.SubItems.Add(row["TenDangNhap"].ToString());
                item.SubItems.Add(row["MatKhau"].ToString());
                item.SubItems.Add(row["VaiTro"].ToString());
                item.SubItems.Add(row["GiangVienID"].ToString());
                listview_TaiKhoan.Items.Add(item);
            }
        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO taiKhoan = new TaiKhoanDTO
            {
                TenDangNhap = txtTaiKhoan.Text,
                MatKhau = txtPass.Text,
                VaiTro = txtVaitro.Text,
            };

            if (!string.IsNullOrEmpty(txtGiangVienID.Text))
            {
                taiKhoan.GiangVienID = int.Parse(txtGiangVienID.Text);
            }
            else
            {
                taiKhoan.GiangVienID = 0; // GiangVienID là NULL
            }

            if (taiKhoanBLL.ThemTaiKhoan(taiKhoan))
            {
                MessageBox.Show("Thêm tài khoản thành công");
                LoadTaiKhoan();
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
        }

        private void btnSuaTK_Click(object sender, EventArgs e)
        {
            if (listview_TaiKhoan.SelectedItems.Count > 0)
            {
                ListViewItem item = listview_TaiKhoan.SelectedItems[0];
                int taiKhoanID;
                int giangVienID = 0;

                // Kiểm tra và chuyển đổi TaiKhoanID
                if (!int.TryParse(item.SubItems[0].Text, out taiKhoanID))
                {
                    MessageBox.Show("ID tài khoản không hợp lệ.");
                    return;
                }

                // Kiểm tra và chuyển đổi GiangVienID (nếu có)
                if (!string.IsNullOrEmpty(txtGiangVienID.Text))
                {
                    if (!int.TryParse(txtGiangVienID.Text, out giangVienID))
                    {
                        MessageBox.Show("ID giảng viên không hợp lệ.");
                        return;
                    }
                }

                // Tạo đối tượng TaiKhoanDTO
                TaiKhoanDTO taiKhoan = new TaiKhoanDTO
                {
                    TaiKhoanID = taiKhoanID,
                    TenDangNhap = txtTaiKhoan.Text,
                    MatKhau = txtPass.Text,
                    VaiTro = txtVaitro.Text,
                    GiangVienID = giangVienID
                };

                // Gọi phương thức sửa tài khoản
                if (taiKhoanBLL.SuaTaiKhoan(taiKhoan))
                {
                    MessageBox.Show("Sửa tài khoản thành công");
                    LoadTaiKhoan();
                }
                else
                {
                    MessageBox.Show("Sửa tài khoản thất bại");
                }
            }
        }


        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            if (listview_TaiKhoan.SelectedItems.Count > 0)
            {
                int taiKhoanID = int.Parse(listview_TaiKhoan.SelectedItems[0].SubItems[0].Text);

                if (taiKhoanBLL.XoaTaiKhoan(taiKhoanID))
                {
                    MessageBox.Show("Xóa tài khoản thành công");
                    LoadTaiKhoan();
                }
                else
                {
                    MessageBox.Show("Xóa tài khoản thất bại");
                }
            }
        }

        private void listview_TaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listview_TaiKhoan.SelectedItems.Count > 0)
            {
                // Lấy thông tin từ dòng được chọn
                ListViewItem selectedItem = listview_TaiKhoan.SelectedItems[0];

                // Hiển thị thông tin lên các TextBox tương ứng
                txtTaiKhoan.Text = selectedItem.SubItems[1].Text;  // Tên đăng nhập
                txtPass.Text = selectedItem.SubItems[2].Text;      // Mật khẩu
                txtVaitro.Text = selectedItem.SubItems[3].Text;    // Vai trò
                txtGiangVienID.Text = selectedItem.SubItems[4].Text; // Giảng viên ID
            }
        }
    }
}
