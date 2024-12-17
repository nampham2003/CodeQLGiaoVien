using System.Windows.Forms;

namespace BTL_TEST
{
    partial class ThoiKhoaBieu
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
            this.dateThoiGian = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewTKB = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbbMonHoc = new System.Windows.Forms.ComboBox();
            this.cbbGiangVien = new System.Windows.Forms.ComboBox();
            this.cbbLopHoc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSuaTKB = new System.Windows.Forms.Button();
            this.btnXoaTKB = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnThemTKB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateThoiGian
            // 
            this.dateThoiGian.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateThoiGian.Location = new System.Drawing.Point(440, 24);
            this.dateThoiGian.Name = "dateThoiGian";
            this.dateThoiGian.Size = new System.Drawing.Size(200, 22);
            this.dateThoiGian.TabIndex = 0;
            this.dateThoiGian.ValueChanged += new System.EventHandler(this.dateThoiGian_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(301, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thời Gian Bắt Đầu";
            // 
            // listViewTKB
            // 
            this.listViewTKB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewTKB.HideSelection = false;
            this.listViewTKB.Location = new System.Drawing.Point(110, 261);
            this.listViewTKB.Name = "listViewTKB";
            this.listViewTKB.Size = new System.Drawing.Size(794, 236);
            this.listViewTKB.TabIndex = 2;
            this.listViewTKB.UseCompatibleStateImageBehavior = false;
            this.listViewTKB.View = System.Windows.Forms.View.Details;
            this.listViewTKB.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "TKBID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên Lớp";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Môn Học";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Giảng Viên";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ngày Học";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Ca Học";
            // 
            // cbbMonHoc
            // 
            this.cbbMonHoc.FormattingEnabled = true;
            this.cbbMonHoc.Location = new System.Drawing.Point(440, 73);
            this.cbbMonHoc.Name = "cbbMonHoc";
            this.cbbMonHoc.Size = new System.Drawing.Size(200, 24);
            this.cbbMonHoc.TabIndex = 3;
            this.cbbMonHoc.SelectedIndexChanged += new System.EventHandler(this.cbbMonHoc_SelectedIndexChanged);
            // 
            // cbbGiangVien
            // 
            this.cbbGiangVien.FormattingEnabled = true;
            this.cbbGiangVien.Location = new System.Drawing.Point(241, 113);
            this.cbbGiangVien.Name = "cbbGiangVien";
            this.cbbGiangVien.Size = new System.Drawing.Size(121, 24);
            this.cbbGiangVien.TabIndex = 4;
            this.cbbGiangVien.SelectedIndexChanged += new System.EventHandler(this.cbbGiangVien_SelectedIndexChanged);
            // 
            // cbbLopHoc
            // 
            this.cbbLopHoc.FormattingEnabled = true;
            this.cbbLopHoc.Location = new System.Drawing.Point(700, 113);
            this.cbbLopHoc.Name = "cbbLopHoc";
            this.cbbLopHoc.Size = new System.Drawing.Size(121, 24);
            this.cbbLopHoc.TabIndex = 5;
            this.cbbLopHoc.SelectedIndexChanged += new System.EventHandler(this.cbbLopHoc_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(355, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Môn Học";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Giảng Viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(613, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Lớp Học";
            // 
            // btnSuaTKB
            // 
            this.btnSuaTKB.Location = new System.Drawing.Point(473, 193);
            this.btnSuaTKB.Name = "btnSuaTKB";
            this.btnSuaTKB.Size = new System.Drawing.Size(124, 52);
            this.btnSuaTKB.TabIndex = 10;
            this.btnSuaTKB.Text = "Sửa Thời Khóa Biểu";
            this.btnSuaTKB.UseVisualStyleBackColor = true;
            this.btnSuaTKB.Click += new System.EventHandler(this.btnSuaTKB_Click);
            // 
            // btnXoaTKB
            // 
            this.btnXoaTKB.Location = new System.Drawing.Point(708, 193);
            this.btnXoaTKB.Name = "btnXoaTKB";
            this.btnXoaTKB.Size = new System.Drawing.Size(113, 52);
            this.btnXoaTKB.TabIndex = 11;
            this.btnXoaTKB.Text = "Xóa Thời Biểu";
            this.btnXoaTKB.UseVisualStyleBackColor = true;
            this.btnXoaTKB.Click += new System.EventHandler(this.btnXoaTKB_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(169, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Ca Học";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(241, 156);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 22);
            this.textBox1.TabIndex = 13;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnThemTKB
            // 
            this.btnThemTKB.Location = new System.Drawing.Point(229, 193);
            this.btnThemTKB.Name = "btnThemTKB";
            this.btnThemTKB.Size = new System.Drawing.Size(133, 52);
            this.btnThemTKB.TabIndex = 14;
            this.btnThemTKB.Text = "Thêm Thời Khóa Biểu";
            this.btnThemTKB.UseVisualStyleBackColor = true;
            this.btnThemTKB.Click += new System.EventHandler(this.btnThemTKB_Click);
            // 
            // ThoiKhoaBieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 535);
            this.Controls.Add(this.btnThemTKB);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnXoaTKB);
            this.Controls.Add(this.btnSuaTKB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbLopHoc);
            this.Controls.Add(this.cbbGiangVien);
            this.Controls.Add(this.cbbMonHoc);
            this.Controls.Add(this.listViewTKB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateThoiGian);
            this.Name = "ThoiKhoaBieu";
            this.Text = "ThoiKhoaBieu";
            this.Load += new System.EventHandler(this.ThoiKhoaBieu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateThoiGian;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewTKB;
        private System.Windows.Forms.ComboBox cbbMonHoc;
        private System.Windows.Forms.ComboBox cbbGiangVien;
        private System.Windows.Forms.ComboBox cbbLopHoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSuaTKB;
        private System.Windows.Forms.Button btnXoaTKB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnThemTKB;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
    }
}