using System.Windows.Forms;

namespace BTL_TEST
{
    partial class QuanLyTaiKhoan
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listview_TaiKhoan = new System.Windows.Forms.ListView();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtVaitro = new System.Windows.Forms.TextBox();
            this.txtGiangVienID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnThemTK = new System.Windows.Forms.Button();
            this.btnSuaTK = new System.Windows.Forms.Button();
            this.btnXoaTK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tài Khoản :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vai Trò :";
            // 
            // listview_TaiKhoan
            // 
            this.listview_TaiKhoan.HideSelection = false;
            this.listview_TaiKhoan.Location = new System.Drawing.Point(60, 221);
            this.listview_TaiKhoan.Name = "listview_TaiKhoan";
            this.listview_TaiKhoan.Size = new System.Drawing.Size(974, 268);
            this.listview_TaiKhoan.TabIndex = 3;
            this.listview_TaiKhoan.UseCompatibleStateImageBehavior = false;
            this.listview_TaiKhoan.View = System.Windows.Forms.View.Details;
            this.listview_TaiKhoan.SelectedIndexChanged += new System.EventHandler(this.listview_TaiKhoan_SelectedIndexChanged);
            // Thêm các cột mới với tên và độ rộng cột
            listview_TaiKhoan.Columns.Add("TaiKhoanID", 100);     // Cột ID tài khoản
            listview_TaiKhoan.Columns.Add("TenDangNhap", 150);    // Cột Tên đăng nhập
            listview_TaiKhoan.Columns.Add("MatKhau", 150);        // Cột Mật khẩu
            listview_TaiKhoan.Columns.Add("VaiTro", 100);         // Cột Vai trò
            listview_TaiKhoan.Columns.Add("GiangVienID", 100);    // Cột Giảng viên ID
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(150, 13);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(214, 22);
            this.txtTaiKhoan.TabIndex = 4;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(150, 63);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(214, 22);
            this.txtPass.TabIndex = 5;
            // 
            // txtVaitro
            // 
            this.txtVaitro.Location = new System.Drawing.Point(150, 121);
            this.txtVaitro.Name = "txtVaitro";
            this.txtVaitro.Size = new System.Drawing.Size(214, 22);
            this.txtVaitro.TabIndex = 6;
            // 
            // txtGiangVienID
            // 
            this.txtGiangVienID.Location = new System.Drawing.Point(150, 182);
            this.txtGiangVienID.Name = "txtGiangVienID";
            this.txtGiangVienID.Size = new System.Drawing.Size(214, 22);
            this.txtGiangVienID.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "GiangVienID";
            // 
            // btnThemTK
            // 
            this.btnThemTK.Location = new System.Drawing.Point(597, 19);
            this.btnThemTK.Name = "btnThemTK";
            this.btnThemTK.Size = new System.Drawing.Size(124, 39);
            this.btnThemTK.TabIndex = 9;
            this.btnThemTK.Text = "Thêm Tài Khoản";
            this.btnThemTK.UseVisualStyleBackColor = true;
            this.btnThemTK.Click += new System.EventHandler(this.btnThemTK_Click);
            // 
            // btnSuaTK
            // 
            this.btnSuaTK.Location = new System.Drawing.Point(597, 91);
            this.btnSuaTK.Name = "btnSuaTK";
            this.btnSuaTK.Size = new System.Drawing.Size(124, 37);
            this.btnSuaTK.TabIndex = 10;
            this.btnSuaTK.Text = "Sửa Tài Khoản";
            this.btnSuaTK.UseVisualStyleBackColor = true;
            this.btnSuaTK.Click += new System.EventHandler(this.btnSuaTK_Click);
            // 
            // btnXoaTK
            // 
            this.btnXoaTK.Location = new System.Drawing.Point(597, 159);
            this.btnXoaTK.Name = "btnXoaTK";
            this.btnXoaTK.Size = new System.Drawing.Size(124, 39);
            this.btnXoaTK.TabIndex = 11;
            this.btnXoaTK.Text = "Xóa Tài Khoản";
            this.btnXoaTK.UseVisualStyleBackColor = true;
            this.btnXoaTK.Click += new System.EventHandler(this.btnXoaTK_Click);
            // 
            // QuanLyTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 532);
            this.Controls.Add(this.btnXoaTK);
            this.Controls.Add(this.btnSuaTK);
            this.Controls.Add(this.btnThemTK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGiangVienID);
            this.Controls.Add(this.txtVaitro);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtTaiKhoan);
            this.Controls.Add(this.listview_TaiKhoan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "QuanLyTaiKhoan";
            this.Text = "QuanLyTaiKhoan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listview_TaiKhoan;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtVaitro;
        private System.Windows.Forms.TextBox txtGiangVienID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnThemTK;
        private System.Windows.Forms.Button btnSuaTK;
        private System.Windows.Forms.Button btnXoaTK;
    }
}