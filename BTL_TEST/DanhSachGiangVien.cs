using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace BTL_TEST
{
    public partial class DanhSachGiangVien : Form
    {
        GiangVienBLL bll = new GiangVienBLL();
        private int selectedGiangVienID = 0; // ID của giảng viên được chọn
        public DanhSachGiangVien()
        {
            InitializeComponent();
            HienThiDanhSachMonDay();
            HienThiDanhSachHocHam();
            HienThiDanhSachHocVi();
            LoadGiangVienData();
        }

        private void LoadGiangVienData()
        {
            DataTable dt = bll.GetAllGiangVien();
            listViewGianngVien.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["GiangVienID"].ToString());
                item.SubItems.Add(row["TenGiangVien"].ToString());
                item.SubItems.Add(row["HocHam"].ToString());
                item.SubItems.Add(row["HocVi"].ToString());
                item.SubItems.Add(row["Email"].ToString());
                item.SubItems.Add(row["Phone"].ToString());
                item.SubItems.Add(row["TenMonHoc"].ToString());
                listViewGianngVien.Items.Add(item);
            }
        }
        private void HienThiDanhSachHocHam()
        {
            cbbHocHam.Items.Clear();
            DataTable dtHocHam = bll.LayDanhSachHocHam();
            foreach (DataRow row in dtHocHam.Rows)
            {
                cbbHocHam.Items.Add(row["TenChucDanh"].ToString());
            }
        }
        private void HienThiDanhSachHocVi()
        {
            cbbHocVi.Items.Clear();
            DataTable dtHocVi = bll.LayDanhSachHocVi();
            foreach (DataRow row in dtHocVi.Rows)
            {
                cbbHocVi.Items.Add(row["TenChucDanh"].ToString());
            }
        }
        private void HienThiDanhSachMonDay()
        {
            cbbMonDay.Items.Clear();
            DataTable dtMonDay = bll.LayDanhSachMonDay();
            foreach (DataRow row in dtMonDay.Rows)
            {
                cbbMonDay.Items.Add(new { Text = row["TenMon"].ToString(), Value = (int)row["MonHocID"] });
            }

            cbbMonDay.DisplayMember = "Text";
            cbbMonDay.ValueMember = "Value";
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập
            if (string.IsNullOrEmpty(txtHoTenGV.Text) || cbbHocHam.SelectedItem == null || cbbHocVi.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin giảng viên.");
                return;
            }

            // Tạo DTO cho giảng viên mới
            GiangVienDTO gv = new GiangVienDTO
            {
                HoTen = txtHoTenGV.Text,
                HocHam = cbbHocHam.SelectedItem.ToString(),
                HocVi = cbbHocVi.SelectedItem.ToString(),
                Email = txtEmail.Text,
                Phone = txtSDT.Text
            };

            // Thêm giảng viên
            if (bll.AddGiangVien(gv))
            {
                MessageBox.Show("Thêm giảng viên thành công.");
                LoadGiangVienData();
            }
            else
            {
                MessageBox.Show("Thêm giảng viên thất bại.");
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (listViewGianngVien.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewGianngVien.SelectedItems[0];
                GiangVienDTO gv = new GiangVienDTO
                {
                    GiangVienID = int.Parse(item.SubItems[0].Text),
                    HoTen = txtHoTenGV.Text,
                    //ChucDanh = txtChucDanhGV.Text,
                    Email = txtEmail.Text,
                    Phone = txtSDT.Text
                };

                if (bll.UpdateGiangVien(gv))
                {
                    MessageBox.Show("Sửa giảng viên thành công");
                    LoadGiangVienData();
                }
                else
                {
                    MessageBox.Show("Sửa giảng viên thất bại");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }
        private void listViewGianngVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewGianngVien.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewGianngVien.SelectedItems[0];

                // Đẩy dữ liệu lên TextBox
                txtHoTenGV.Text = item.SubItems[1].Text;
                txtEmail.Text = item.SubItems[4].Text;
                txtSDT.Text = item.SubItems[5].Text;

                // Đặt giá trị được chọn trong ComboBox
                cbbHocHam.SelectedItem = item.SubItems[2].Text;
                cbbHocVi.SelectedItem = item.SubItems[3].Text;

                // Lưu ID của giảng viên được chọn
                selectedGiangVienID = int.Parse(item.SubItems[0].Text);
            }
            else
            {
                cbbMonDay.SelectedIndex = -1;
            }
        }
      
        private void txtHoTenGV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbMonDay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThemMonDay_Click(object sender, EventArgs e)
        {
            if (selectedGiangVienID > 0 && cbbMonDay.SelectedItem != null)
            {
                var selectedMonHoc = (dynamic)cbbMonDay.SelectedItem;
                int monHocID = selectedMonHoc.Value;

                if (bll.ThemMonDayChoGiangVien(selectedGiangVienID, monHocID))
                {
                    MessageBox.Show("Thêm môn dạy thành công.");
                    LoadGiangVienData();
                }
                else
                {
                    MessageBox.Show("Thêm môn dạy thất bại.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn giảng viên và môn học.");
            }
        }

        private void cbbHocHam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbHocVi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
