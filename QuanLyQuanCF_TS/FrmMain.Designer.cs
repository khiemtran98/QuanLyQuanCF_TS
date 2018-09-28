namespace QuanLyQuanCF_TS
{
    partial class FrmMain
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
            this.btnBanHang = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.tbcNhanVien = new System.Windows.Forms.TabControl();
            this.tbpThongTin = new System.Windows.Forms.TabPage();
            this.lblCapBac = new System.Windows.Forms.Label();
            this.lblCa = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.tbpQuanLy = new System.Windows.Forms.TabPage();
            this.lblTongSoHoaDonTrongNgay = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbcNhanVien.SuspendLayout();
            this.tbpThongTin.SuspendLayout();
            this.tbpQuanLy.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBanHang
            // 
            this.btnBanHang.BackColor = System.Drawing.Color.PaleGreen;
            this.btnBanHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBanHang.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBanHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.25F);
            this.btnBanHang.Location = new System.Drawing.Point(0, 0);
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Size = new System.Drawing.Size(800, 56);
            this.btnBanHang.TabIndex = 0;
            this.btnBanHang.Text = "Bán hàng";
            this.btnBanHang.UseVisualStyleBackColor = false;
            this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.LightGray;
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.25F);
            this.btnDangXuat.Location = new System.Drawing.Point(0, 56);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(800, 56);
            this.btnDangXuat.TabIndex = 1;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // tbcNhanVien
            // 
            this.tbcNhanVien.Controls.Add(this.tbpThongTin);
            this.tbcNhanVien.Controls.Add(this.tbpQuanLy);
            this.tbcNhanVien.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbcNhanVien.Location = new System.Drawing.Point(0, 321);
            this.tbcNhanVien.Name = "tbcNhanVien";
            this.tbcNhanVien.SelectedIndex = 0;
            this.tbcNhanVien.Size = new System.Drawing.Size(800, 129);
            this.tbcNhanVien.TabIndex = 2;
            // 
            // tbpThongTin
            // 
            this.tbpThongTin.Controls.Add(this.lblCapBac);
            this.tbpThongTin.Controls.Add(this.lblCa);
            this.tbpThongTin.Controls.Add(this.lblHoTen);
            this.tbpThongTin.Location = new System.Drawing.Point(4, 22);
            this.tbpThongTin.Name = "tbpThongTin";
            this.tbpThongTin.Padding = new System.Windows.Forms.Padding(3);
            this.tbpThongTin.Size = new System.Drawing.Size(792, 103);
            this.tbpThongTin.TabIndex = 0;
            this.tbpThongTin.Text = "Thông tin";
            this.tbpThongTin.UseVisualStyleBackColor = true;
            // 
            // lblCapBac
            // 
            this.lblCapBac.AutoSize = true;
            this.lblCapBac.Location = new System.Drawing.Point(22, 70);
            this.lblCapBac.Name = "lblCapBac";
            this.lblCapBac.Size = new System.Drawing.Size(53, 13);
            this.lblCapBac.TabIndex = 2;
            this.lblCapBac.Text = "Cấp bậc: ";
            // 
            // lblCa
            // 
            this.lblCa.AutoSize = true;
            this.lblCa.Location = new System.Drawing.Point(22, 47);
            this.lblCa.Name = "lblCa";
            this.lblCa.Size = new System.Drawing.Size(26, 13);
            this.lblCa.TabIndex = 1;
            this.lblCa.Text = "Ca: ";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(22, 25);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(45, 13);
            this.lblHoTen.TabIndex = 0;
            this.lblHoTen.Text = "Họ tên: ";
            // 
            // tbpQuanLy
            // 
            this.tbpQuanLy.Controls.Add(this.lblTongSoHoaDonTrongNgay);
            this.tbpQuanLy.Controls.Add(this.label1);
            this.tbpQuanLy.Location = new System.Drawing.Point(4, 22);
            this.tbpQuanLy.Name = "tbpQuanLy";
            this.tbpQuanLy.Padding = new System.Windows.Forms.Padding(3);
            this.tbpQuanLy.Size = new System.Drawing.Size(792, 103);
            this.tbpQuanLy.TabIndex = 1;
            this.tbpQuanLy.Text = "Quản lý";
            this.tbpQuanLy.UseVisualStyleBackColor = true;
            // 
            // lblTongSoHoaDonTrongNgay
            // 
            this.lblTongSoHoaDonTrongNgay.AutoSize = true;
            this.lblTongSoHoaDonTrongNgay.Location = new System.Drawing.Point(22, 47);
            this.lblTongSoHoaDonTrongNgay.Name = "lblTongSoHoaDonTrongNgay";
            this.lblTongSoHoaDonTrongNgay.Size = new System.Drawing.Size(151, 13);
            this.lblTongSoHoaDonTrongNgay.TabIndex = 1;
            this.lblTongSoHoaDonTrongNgay.Text = "Tổng số hoá đơn trong ngày:  ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thời gian làm việc:";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbcNhanVien);
            this.Controls.Add(this.btnDangXuat);
            this.Controls.Add(this.btnBanHang);
            this.Name = "FrmMain";
            this.Text = "Phần mềm quản lý quán cà phê - trà sữa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.tbcNhanVien.ResumeLayout(false);
            this.tbpThongTin.ResumeLayout(false);
            this.tbpThongTin.PerformLayout();
            this.tbpQuanLy.ResumeLayout(false);
            this.tbpQuanLy.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBanHang;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.TabControl tbcNhanVien;
        private System.Windows.Forms.TabPage tbpThongTin;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TabPage tbpQuanLy;
        private System.Windows.Forms.Label lblCa;
        private System.Windows.Forms.Label lblCapBac;
        private System.Windows.Forms.Label lblTongSoHoaDonTrongNgay;
        private System.Windows.Forms.Label label1;
    }
}