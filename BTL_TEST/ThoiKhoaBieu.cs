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
    public partial class ThoiKhoaBieu : Form
    {
        private ThoiKhoaBieuBLL bll = new ThoiKhoaBieuBLL();
        public ThoiKhoaBieu()
        {
            InitializeComponent();
        }

        private void ThoiKhoaBieu_Load(object sender, EventArgs e)
        {
            LoadMonHoc();
            LoadThoiKhoaBieu();
        }


        private void LoadMonHoc()
        {
            List<MonHocDTO> monHocs = bll.GetMonHoc();
            monHocs.Insert(0, new MonHocDTO { MonHocID = 0, TenMon = "" });
            cbbMonHoc.DataSource = monHocs;
            cbbMonHoc.DisplayMember = "TenMon";
            cbbMonHoc.ValueMember = "MonHocID";
            cbbMonHoc.SelectedIndex = 0;
        }


        private void LoadGiangVienByMonHoc(int monHocID)
        {
            List<GiangVienDTO> giangViens = bll.GetGiangVienByMonHoc(monHocID);
            cbbGiangVien.DataSource = giangViens;
            cbbGiangVien.DisplayMember = "HoTen";
            cbbGiangVien.ValueMember = "GiangVienID";
        }

        private void LoadLopHocByMonHoc(int monHocID)
        {
            DateTime ngayBatDau = dateThoiGian.Value;

            // Lấy danh sách các lớp chưa có môn học này vào ngày bắt đầu.
            List<DanhSachLopDTO> lopHocs = bll.GetAvailableLopHocForMonHoc(monHocID, ngayBatDau);
            cbbLopHoc.DataSource = lopHocs;
            cbbLopHoc.DisplayMember = "TenLop";
            cbbLopHoc.ValueMember = "LopID";
        }

        private void cbbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMonHoc.SelectedValue is int monHocID)
            {
                LoadGiangVienByMonHoc(monHocID);
                LoadLopHocByMonHoc(monHocID);
            }
        }

        private void dateThoiGian_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbbGiangVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThemTKB_Click(object sender, EventArgs e)
        {
            try
            {
                int monHocID = (int)cbbMonHoc.SelectedValue;
                int giangVienID = (int)cbbGiangVien.SelectedValue;
                int lopID = (int)cbbLopHoc.SelectedValue;
                DateTime ngayBatDau = dateThoiGian.Value;

                MonHocDTO selectedMonHoc = bll.GetMonHoc().Find(m => m.MonHocID == monHocID);
                if (selectedMonHoc == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin môn học.");
                    return;
                }

                int soBuoiHoc = selectedMonHoc.SoTinChi * 5;
                List<ThoiKhoaBieuDTO> thoiKhoaBieus = new List<ThoiKhoaBieuDTO>();
                DateTime currentNgayHoc = ngayBatDau;
                int caHoc = 1;

                for (int buoiDaThem = 0; buoiDaThem < soBuoiHoc;)
                {
                    // Gọi hàm fnKiemTraLopTrungLich từ SQL để kiểm tra trùng lịch
                    bool isTrungLich = bll.KiemTraLopTrungLich(lopID, monHocID, ngayBatDau, caHoc);

                    if (isTrungLich)
                    {
                        MessageBox.Show("Lịch học bị trùng.");
                        return;
                    }

                    thoiKhoaBieus.Add(new ThoiKhoaBieuDTO
                    {
                        LopID = lopID,
                        MonHocID = monHocID,
                        GiangVienID = giangVienID,
                        NgayHoc = currentNgayHoc,
                        CaHoc = caHoc
                    });
                    buoiDaThem++;

                    if (++caHoc > 4)
                    {
                        caHoc = 1;
                        currentNgayHoc = currentNgayHoc.AddDays(1);
                    }
                }

                foreach (var tkb in thoiKhoaBieus)
                {
                    bll.AddThoiKhoaBieu(tkb);
                }

                MessageBox.Show("Thời khóa biểu đã được tạo thành công!");
                LoadThoiKhoaBieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm thời khóa biểu: " + ex.Message);
            }
        }




        private void btnSuaTKB_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaTKB_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadThoiKhoaBieu()
        {
            // Lấy dữ liệu từ BLL
            List<ThoiKhoaBieuDTO> thoiKhoaBieus = bll.GetThoiKhoaBieu();

            // Xóa các mục cũ trong ListView
            listViewTKB.Items.Clear();

            // Hiển thị thông tin thời khóa biểu
            foreach (var tkb in thoiKhoaBieus)
            {
                ListViewItem item = new ListViewItem(tkb.TKBID.ToString());
                item.SubItems.Add(tkb.TenLop);
                item.SubItems.Add(tkb.TenMon);
                item.SubItems.Add(tkb.HoTenGiangVien);
                item.SubItems.Add(tkb.NgayHoc.ToString("dd/MM/yyyy"));
                item.SubItems.Add(tkb.CaHoc.ToString());

                listViewTKB.Items.Add(item);
            }
        }



    }
}
