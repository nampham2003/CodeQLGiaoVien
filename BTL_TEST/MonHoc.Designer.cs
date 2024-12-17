using System.Windows.Forms;

namespace BTL_TEST
{
    partial class MonHoc
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
            this.listViewMonHoc = new System.Windows.Forms.ListView();
            this.txtSoTin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThemMH = new System.Windows.Forms.Button();
            this.btnSuaMH = new System.Windows.Forms.Button();
            this.txtTenMH = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listViewMonHoc
            // 
            this.listViewMonHoc.HideSelection = false;
            this.listViewMonHoc.Location = new System.Drawing.Point(198, 185);
            this.listViewMonHoc.Name = "listViewMonHoc";
            this.listViewMonHoc.Size = new System.Drawing.Size(515, 187);
            this.listViewMonHoc.TabIndex = 0;
            this.listViewMonHoc.UseCompatibleStateImageBehavior = false;
            this.listViewMonHoc.SelectedIndexChanged += new System.EventHandler(this.listViewMonHoc_SelectedIndexChanged);
            // Cấu hình ListView để hiển thị chi tiết
            listViewMonHoc.View = View.Details;
            // Thêm các cột mới với tên và độ rộng cột
            listViewMonHoc.Columns.Add("MonHocID", 100);     
            listViewMonHoc.Columns.Add("TenMon", 150);    
            listViewMonHoc.Columns.Add("SoTinChi", 150);
            // 
            // txtSoTin
            // 
            this.txtSoTin.Location = new System.Drawing.Point(292, 108);
            this.txtSoTin.Name = "txtSoTin";
            this.txtSoTin.Size = new System.Drawing.Size(167, 22);
            this.txtSoTin.TabIndex = 1;
            this.txtSoTin.TextChanged += new System.EventHandler(this.txtSoTin_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tên Môn Học";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Số Tín Chỉ";
            // 
            // btnThemMH
            // 
            this.btnThemMH.Location = new System.Drawing.Point(560, 30);
            this.btnThemMH.Name = "btnThemMH";
            this.btnThemMH.Size = new System.Drawing.Size(75, 23);
            this.btnThemMH.TabIndex = 5;
            this.btnThemMH.Text = "Thêm ";
            this.btnThemMH.UseVisualStyleBackColor = true;
            this.btnThemMH.Click += new System.EventHandler(this.btnThemMH_Click);
            // 
            // btnSuaMH
            // 
            this.btnSuaMH.Location = new System.Drawing.Point(560, 107);
            this.btnSuaMH.Name = "btnSuaMH";
            this.btnSuaMH.Size = new System.Drawing.Size(75, 23);
            this.btnSuaMH.TabIndex = 6;
            this.btnSuaMH.Text = "Sửa";
            this.btnSuaMH.UseVisualStyleBackColor = true;
            this.btnSuaMH.Click += new System.EventHandler(this.btnSuaMH_Click);
            // 
            // txtTenMH
            // 
            this.txtTenMH.Location = new System.Drawing.Point(292, 31);
            this.txtTenMH.Name = "txtTenMH";
            this.txtTenMH.Size = new System.Drawing.Size(167, 22);
            this.txtTenMH.TabIndex = 7;
            this.txtTenMH.TextChanged += new System.EventHandler(this.txtTenMH_TextChanged);
            // 
            // MonHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 534);
            this.Controls.Add(this.txtTenMH);
            this.Controls.Add(this.btnSuaMH);
            this.Controls.Add(this.btnThemMH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSoTin);
            this.Controls.Add(this.listViewMonHoc);
            this.Name = "MonHoc";
            this.Text = "MonHoc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewMonHoc;
        private System.Windows.Forms.TextBox txtSoTin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThemMH;
        private System.Windows.Forms.Button btnSuaMH;
        private System.Windows.Forms.TextBox txtTenMH;
    }
}