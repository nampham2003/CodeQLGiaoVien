using BLL;
using DTO;
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
    public partial class DanhSachLop : Form
    {
        private DanhSachLopBLL lopBLL = new DanhSachLopBLL();

        public DanhSachLop()
        {
            InitializeComponent();
            HienThiDanhSachLop();
            HienThiDanhSachMonHoc();
        }
        
        private void HienThiDanhSachLop()
        {
            listViewLop.Items.Clear();
            DataTable dtLopHoc = lopBLL.LayTatCaLopHoc();
            foreach (DataRow row in dtLopHoc.Rows)
            {
                ListViewItem item = new ListViewItem(row["IDLop"].ToString());
                item.SubItems.Add(row["TenLop"].ToString());
                item.SubItems.Add(row["SiSo"].ToString());
                item.SubItems.Add(row["TenMon"].ToString());
                item.SubItems.Add(row["SoTinChi"].ToString());
                item.Tag = row["IDLop"];  
                listViewLop.Items.Add(item);
            }
        }


        // Hàm thêm lớp học
        private void btnThemLop_Click(object sender, EventArgs e)
        {
            string tenLop = txtTenLop.Text;
            int siSo;
            if (!int.TryParse(txtSiSo.Text, out siSo))
            {
                MessageBox.Show("Sĩ số phải là số nguyên.");
                return;
            }

            // Kiểm tra lớp đã tồn tại trong cơ sở dữ liệu
            if (lopBLL.KiemTraLopTonTai(tenLop))
            {
                MessageBox.Show("Tên lớp đã tồn tại trong cơ sở dữ liệu.");
                return;
            }

            DanhSachLopDTO lop = new DanhSachLopDTO { TenLop = tenLop, SiSo = siSo };
            if (lopBLL.ThemLop(lop))
            {
                MessageBox.Show("Thêm lớp thành công!");
                HienThiDanhSachLop(); // Cập nhật danh sách lớp sau khi thêm
            }
            else
            {
                MessageBox.Show("Thêm lớp thất bại.");
            }
        }


        // Hàm sửa lớp học
        private void btnSuaLop_Click(object sender, EventArgs e)
        {
            if (selectedLopID == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp cần sửa.");
                return;
            }

            // Lấy dữ liệu từ TextBox
            string tenLop = txtTenLop.Text;
            int siSo;
            if (!int.TryParse(txtSiSo.Text, out siSo))
            {
                MessageBox.Show("Sĩ số phải là số nguyên.");
                return;
            }

            // Tạo đối tượng DTO với dữ liệu mới
            DanhSachLopDTO lop = new DanhSachLopDTO
            {
                LopID = selectedLopID,
                TenLop = tenLop,
                SiSo = siSo
            };

            // Gọi hàm sửa lớp
            if (lopBLL.SuaLop(lop))
            {
                MessageBox.Show("Cập nhật thông tin lớp thành công!");
                HienThiDanhSachLop(); // Cập nhật lại danh sách lớp sau khi sửa
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin lớp thất bại.");
            }
        }


        // Đẩy dữ liệu từ ListView lên TextBox và ComboBox khi chọn lớp
        private int selectedLopID = 0; // Biến lưu ID của lớp được chọn
        private void listViewLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewLop.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewLop.SelectedItems[0];
                txtTenLop.Text = selectedItem.SubItems[1].Text; // Tên lớp
                txtSiSo.Text = selectedItem.SubItems[2].Text;   // Sĩ số

                selectedLopID = (int)selectedItem.Tag; // Lưu ID của lớp được chọn
            }
        }



        private void txtTenLop_TextChanged(object sender, EventArgs e)
        {
            string tenLop = txtTenLop.Text;
            listViewLop.Items.Clear();
            DataTable dtLopHoc = lopBLL.LayTatCaLopHoc();

            foreach (DataRow row in dtLopHoc.Select($"TenLop LIKE '%{tenLop}%'"))
            {
                ListViewItem item = new ListViewItem(row["IDLop"].ToString());
                item.SubItems.Add(row["TenLop"].ToString());
                item.SubItems.Add(row["SiSo"].ToString());
                item.SubItems.Add(row["TenMon"].ToString());
                item.SubItems.Add(row["SoTinChi"].ToString());
                listViewLop.Items.Add(item);
            }
        }

        private void txtSiSo_TextChanged(object sender, EventArgs e)
        {

        }
        // Hiển thị danh sách môn học trong ComboBox
        private void HienThiDanhSachMonHoc()
        {
            cbbMonHoc.Items.Clear();
            DataTable dtMonHoc = lopBLL.LayDanhSachMonHoc();
            foreach (DataRow row in dtMonHoc.Rows)
            {
                // Thêm tên môn học vào ComboBox, lưu MonHocID trong Tag để dùng sau
                cbbMonHoc.Items.Add(new { Text = row["TenMon"].ToString(), Value = (int)row["MonHocID"] });
            }

            cbbMonHoc.DisplayMember = "Text";
            cbbMonHoc.ValueMember = "Value";
        }


        private void btnThemMonHoc_Click(object sender, EventArgs e)
        {
            if (cbbMonHoc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn môn học.");
                return;
            }

            if (selectedLopID == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp.");
                return;
            }

            // Lấy MonHocID từ ComboBox
            var selectedMonHoc = (dynamic)cbbMonHoc.SelectedItem;
            int monHocID = selectedMonHoc.Value;

            // Tạo đối tượng DTO để truyền vào hàm
            MonHocDTO monHoc = new MonHocDTO { MonHocID = monHocID };
            DanhSachLopDTO lop = new DanhSachLopDTO { LopID = selectedLopID };

            if (lopBLL.ThemMonHocChoLop(monHoc, lop))
            {
                MessageBox.Show("Thêm môn học vào lớp thành công!");
                HienThiDanhSachLop(); // Cập nhật lại danh sách lớp và môn học sau khi thêm
            }
            else
            {
                MessageBox.Show("Thêm môn học vào lớp thất bại.");
            }
        }


        private void cbbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnXoaLop_Click(object sender, EventArgs e)
        {

        }

        private void DanhSachLop_Load(object sender, EventArgs e)
        {

        }
    }
}
