using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace BTL_TEST
{
    public partial class MonHoc : Form
    {
        MonHocBLL monHocBLL = new MonHocBLL();
        public MonHoc()
        {
            InitializeComponent();
            LoadMonHoc();
        }
        private void LoadMonHoc()
        {
            listViewMonHoc.Items.Clear();
            DataTable dt = monHocBLL.LayTatCaMonHoc();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["MonHocID"].ToString());
                item.SubItems.Add(row["TenMon"].ToString());
                item.SubItems.Add(row["SoTinChi"].ToString());
                listViewMonHoc.Items.Add(item);
            }
        }
        private void btnThemMH_Click(object sender, EventArgs e)
        {
            MonHocDTO monHoc = new MonHocDTO
            {
                TenMon = txtTenMH.Text,
                SoTinChi = int.Parse(txtSoTin.Text)
            };

            if (monHocBLL.ThemMonHoc(monHoc))
            {
                MessageBox.Show("Thêm môn học thành công");
                LoadMonHoc();
            }
            else
            {
                MessageBox.Show("Thêm môn học thất bại");
            }
        }

        private void btnSuaMH_Click(object sender, EventArgs e)
        {
            if (listViewMonHoc.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewMonHoc.SelectedItems[0];
                MonHocDTO monHoc = new MonHocDTO
                {
                    MonHocID = int.Parse(item.SubItems[0].Text),
                    TenMon = txtTenMH.Text,
                    SoTinChi = int.Parse(txtSoTin.Text)
                };

                if (monHocBLL.SuaMonHoc(monHoc))
                {
                    MessageBox.Show("Sửa môn học thành công");
                    LoadMonHoc();
                }
                else
                {
                    MessageBox.Show("Sửa môn học thất bại");
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenMH_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoTin_TextChanged(object sender, EventArgs e)
        {

        }

        // Khi chọn mục trong ListView
        private void listViewMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewMonHoc.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewMonHoc.SelectedItems[0];

                // Đẩy dữ liệu lên các TextBox tương ứng
                txtTenMH.Text = item.SubItems[1].Text; // Tên môn học
                txtSoTin.Text = item.SubItems[2].Text; // Số tín chỉ
            }
        }
    }
}
