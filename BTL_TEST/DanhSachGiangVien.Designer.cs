namespace BTL_TEST
{
    partial class DanhSachGiangVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnThem = new System.Windows.Forms.Button();
            this.txtHoTenGV = new System.Windows.Forms.TextBox();
            this.listViewGianngVien = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.cbbMonDay = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnThemMonDay = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbHocHam = new System.Windows.Forms.ComboBox();
            this.cbbHocVi = new System.Windows.Forms.ComboBox();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(66, 209);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(134, 40);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm Giáo Viên";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtHoTenGV
            // 
            this.txtHoTenGV.Location = new System.Drawing.Point(127, 31);
            this.txtHoTenGV.Name = "txtHoTenGV";
            this.txtHoTenGV.Size = new System.Drawing.Size(213, 22);
            this.txtHoTenGV.TabIndex = 2;
            this.txtHoTenGV.TextChanged += new System.EventHandler(this.txtHoTenGV_TextChanged);
            // 
            // listViewGianngVien
            // 
            this.listViewGianngVien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader1});
            this.listViewGianngVien.HideSelection = false;
            this.listViewGianngVien.Location = new System.Drawing.Point(63, 281);
            this.listViewGianngVien.Name = "listViewGianngVien";
            this.listViewGianngVien.Size = new System.Drawing.Size(706, 213);
            this.listViewGianngVien.TabIndex = 3;
            this.listViewGianngVien.UseCompatibleStateImageBehavior = false;
            this.listViewGianngVien.View = System.Windows.Forms.View.Details;
            this.listViewGianngVien.SelectedIndexChanged += new System.EventHandler(this.listViewGianngVien_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Họ Tên ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(491, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "SDT";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(127, 92);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(213, 22);
            this.txtEmail.TabIndex = 8;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(551, 34);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(218, 22);
            this.txtSDT.TabIndex = 10;
            this.txtSDT.TextChanged += new System.EventHandler(this.txtSDT_TextChanged);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(265, 209);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(132, 40);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa Giáo Viên";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(451, 209);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(124, 40);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xoá Thông Tin";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // cbbMonDay
            // 
            this.cbbMonDay.FormattingEnabled = true;
            this.cbbMonDay.Location = new System.Drawing.Point(551, 92);
            this.cbbMonDay.Name = "cbbMonDay";
            this.cbbMonDay.Size = new System.Drawing.Size(218, 24);
            this.cbbMonDay.TabIndex = 13;
            this.cbbMonDay.SelectedIndexChanged += new System.EventHandler(this.cbbMonDay_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(465, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Môn Dạy";
            // 
            // btnThemMonDay
            // 
            this.btnThemMonDay.Location = new System.Drawing.Point(645, 209);
            this.btnThemMonDay.Name = "btnThemMonDay";
            this.btnThemMonDay.Size = new System.Drawing.Size(124, 40);
            this.btnThemMonDay.TabIndex = 15;
            this.btnThemMonDay.Text = "Thêm Môn Dạy";
            this.btnThemMonDay.UseVisualStyleBackColor = true;
            this.btnThemMonDay.Click += new System.EventHandler(this.btnThemMonDay_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Học Hàm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(479, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Học Vị";
            // 
            // cbbHocHam
            // 
            this.cbbHocHam.FormattingEnabled = true;
            this.cbbHocHam.Location = new System.Drawing.Point(127, 147);
            this.cbbHocHam.Name = "cbbHocHam";
            this.cbbHocHam.Size = new System.Drawing.Size(213, 24);
            this.cbbHocHam.TabIndex = 18;
            this.cbbHocHam.SelectedIndexChanged += new System.EventHandler(this.cbbHocHam_SelectedIndexChanged);
            // 
            // cbbHocVi
            // 
            this.cbbHocVi.FormattingEnabled = true;
            this.cbbHocVi.Location = new System.Drawing.Point(551, 148);
            this.cbbHocVi.Name = "cbbHocVi";
            this.cbbHocVi.Size = new System.Drawing.Size(218, 24);
            this.cbbHocVi.TabIndex = 19;
            this.cbbHocVi.SelectedIndexChanged += new System.EventHandler(this.cbbHocVi_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ID";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Họ Tên";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "SDT";
            this.columnHeader9.Width = 80;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Email";
            this.columnHeader10.Width = 80;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Họ Hàm";
            this.columnHeader11.Width = 80;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Học Vị ";
            this.columnHeader12.Width = 80;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Môn Dạy";
            this.columnHeader1.Width = 100;
            // 
            // DanhSachGiangVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 532);
            this.Controls.Add(this.cbbHocVi);
            this.Controls.Add(this.cbbHocHam);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnThemMonDay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbbMonDay);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewGianngVien);
            this.Controls.Add(this.txtHoTenGV);
            this.Controls.Add(this.btnThem);
            this.Name = "DanhSachGiangVien";
            this.Text = "DanhSachGiangVien";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtHoTenGV;
        private System.Windows.Forms.ListView listViewGianngVien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.ComboBox cbbMonDay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnThemMonDay;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbHocHam;
        private System.Windows.Forms.ComboBox cbbHocVi;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}