﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using MaterialSkin.Controls;
using DTO;
using BUS;

namespace QuanLyQuanCF_TS
{
    public partial class FrmMain : MetroFramework.Forms.MetroForm
    {
        public FrmMain()
        {
            InitializeComponent();
            _Instance = this;

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, picHinh.Width - 3, picHinh.Height - 3);
            Region rg = new Region(gp);
            picHinh.Region = rg;
            picHinh.BackColor = Color.WhiteSmoke;
        }

        private static FrmMain _Instance;

        public static FrmMain Instance
        {
            get
            {
                return _Instance;
            }
        }

        bool panelThongTinState = true;

        private Form f;

        DateTime startTime = DateTime.Now;

        public static MetroColorStyle style = MetroColorStyle.Default;
        public static bool topMost = false;

        private void MoFormDangNhap()
        {
            metroPanel5.Visible = metroPanel6.Visible = metroPanel7.Visible = metroPanel8.Visible = metroPanel10.Visible = metroPanel11.Visible = metroPanel13.Visible = metroPanel14.Visible = metroPanel15.Visible = metroPanel16.Visible = false;
            metroPanel1.Visible = metroPanel2.Visible = true;

            panelTaiKhoan.Visible = false;
            this.WindowState = FormWindowState.Normal;
            this.Size = new Size(853, 650);

            FrmDangNhap m_frmDangNhap = FrmDangNhap.Instance;
            m_frmDangNhap.MdiParent = this;
            m_frmDangNhap.Dock = DockStyle.Fill;
            m_frmDangNhap.Style = style;
            m_frmDangNhap.Show();
        }

        public void XuLyDangNhapThanhCong(int maTaiKhoan)
        {
            startTime = DateTime.Now;
            timer1.Start();

            panelTaiKhoan.Visible = true;
            this.WindowState = FormWindowState.Maximized;
            XuLyFormMain();
            TaiKhoanBUS.LuuTaiKhoanDangNhap(maTaiKhoan);
            TaiKhoanDTO taiKhoan = TaiKhoanBUS.LayThongTinTaiKhoan(maTaiKhoan);
            lblHoTen.Text = taiKhoan.HoTen;
            lblCapBac.Text = TaiKhoanBUS.LayTenLoaiTaiKhoan(taiKhoan.LoaiTaiKhoan);
            picHinh.ImageLocation = "img\\accounts\\" + taiKhoan.Hinh;

            List<ChucNang_LoaiTaiKhoanDTO> lsChucNang_LoaiTaiKhoan = ChucNang_LoaiTaiKhoanBUS.LayDanhSachChucNang_LoaiTaiKhoanTheoMaTaiKhoan(maTaiKhoan);
            foreach (ChucNang_LoaiTaiKhoanDTO chucNang_LoaiTaiKhoan in lsChucNang_LoaiTaiKhoan)
            {
                switch (chucNang_LoaiTaiKhoan.MaChucNang)
                {
                    case 1:
                        metroPanel5.Visible = true;
                        metroPanel5.BringToFront();
                        break;
                    case 2:
                        metroPanel6.Visible = true;
                        metroPanel6.BringToFront();
                        break;
                    case 3:
                        metroPanel10.Visible = true;
                        metroPanel10.BringToFront();
                        break;
                    case 4:
                        metroPanel7.Visible = true;
                        metroPanel7.BringToFront();
                        break;
                    case 5:
                        metroPanel8.Visible = true;
                        metroPanel8.BringToFront();
                        break;
                    case 6:
                        metroPanel11.Visible = true;
                        metroPanel11.BringToFront();
                        break;
                    case 7:
                        metroPanel13.Visible = true;
                        metroPanel13.BringToFront();
                        break;
                    case 8:
                        metroPanel14.Visible = true;
                        metroPanel14.BringToFront();
                        break;
                    case 9:
                        metroPanel15.Visible = true;
                        metroPanel15.BringToFront();
                        break;
                    case 10:
                        metroPanel16.Visible = true;
                        metroPanel16.BringToFront();
                        break;
                }
            }
            if (metroPanel5.Visible || metroPanel6.Visible || metroPanel7.Visible || metroPanel8.Visible)
            {
                metroPanel1.Visible = true;
            }
            else
            {
                metroPanel1.Visible = false;
            }
            if (metroPanel10.Visible || metroPanel11.Visible)
            {
                metroPanel2.Visible = true;
            }
            else
            {
                metroPanel2.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime passTime = DateTime.Parse((DateTime.Now - startTime).ToString());
            lblActiveTime.Text = passTime.ToLongTimeString();
            lblSystemTime.Text = DateTime.Now.ToLongTimeString();
        }

        public void XuLyChuyenForm()
        {
            mPanel.Visible = false;
            //panelTaiKhoan.Visible = false;
            //this.DisplayHeader = false;
            lblTieuDe.Location = new Point(26, 4);
            btnQuayLai.Visible = true;
        }

        public void XuLyFormMain()
        {
            lblTieuDe.Text = "Phần mềm quản lý quán cà phê - trà sữa";
            lblTieuDe.Location = new Point(0, 4);
            mPanel.Visible = true;
            //this.Movable = false;
            panelTaiKhoan.Visible = true;
            //this.DisplayHeader = true;
            btnQuayLai.Visible = false;

            panelBaoCao.Controls.Clear();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            XuLyChuyenForm();
            MoFormDangNhap();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (DialogResult.No == MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            if (DialogResult.No == MetroMessageBox.Show(this, "Bạn có muốn thoát chương trình?", "Thoát chương trình", MessageBoxButtons.YesNo, MessageBoxIcon.Information, 120))
            {
                e.Cancel = true;
            }
        }

        public void DangXuat()
        {
            DongFormCon();
            XuLyChuyenForm();
            TaiKhoanBUS.LuuTaiKhoanDangNhap(-1);
            timer1.Stop();
            MoFormDangNhap();
        }

        private void mtQuanLyDuLieuTaiKhoan_Click(object sender, EventArgs e)
        {
            lblTieuDe.Text = "Quản lý dữ liệu tài khoản";
            Cursor.Current = Cursors.WaitCursor;
            XuLyChuyenForm();
            FrmQuanLyDuLieuTaiKhoan m_FrmQuanLyDuLieuTaiKhoan = FrmQuanLyDuLieuTaiKhoan.Instance;
            f = m_FrmQuanLyDuLieuTaiKhoan;
            m_FrmQuanLyDuLieuTaiKhoan.MdiParent = this;
            m_FrmQuanLyDuLieuTaiKhoan.Dock = DockStyle.Fill;
            m_FrmQuanLyDuLieuTaiKhoan.Show();
        }

        private void mQuanLyDuLieuMon_Click(object sender, EventArgs e)
        {
            lblTieuDe.Text = "Quản lý dữ liệu món";
            Cursor.Current = Cursors.WaitCursor;
            XuLyChuyenForm();
            FrmQuanLyDuLieuMon m_FrmQuanLyDuLieuMon = FrmQuanLyDuLieuMon.Instance;
            f = m_FrmQuanLyDuLieuMon;
            m_FrmQuanLyDuLieuMon.MdiParent = this;
            m_FrmQuanLyDuLieuMon.Dock = DockStyle.Fill;
            m_FrmQuanLyDuLieuMon.Show();

            Label lbl = new Label();
            lbl.Dock = DockStyle.Left;
            lbl.Text = "Lập báo cáo nhanh";
            lbl.ForeColor = Color.CadetBlue;
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.Font = new Font("SegoeUI", 11, FontStyle.Bold);
            panelBaoCao.Controls.Add(lbl);
            lbl.BringToFront();

            MaterialFlatButton btnTatCaMon = new MaterialFlatButton();
            btnTatCaMon.Dock = DockStyle.Left;
            btnTatCaMon.Text = "Tất cả món";
            btnTatCaMon.Name = "TatCaMon";
            btnTatCaMon.Click += btn_Click;
            panelBaoCao.Controls.Add(btnTatCaMon);
            btnTatCaMon.BringToFront();

            MaterialFlatButton btn = new MaterialFlatButton();
            btn.Dock = DockStyle.Left;
            btn.Text = "Món theo nhóm";
            btn.Name = "MonGomNhom";
            btn.Click += btn_Click;
            panelBaoCao.Controls.Add(btn);
            btn.BringToFront();
        }

        private void mThongKeHoaDon_Click(object sender, EventArgs e)
        {
            lblTieuDe.Text = "Thống kê hoá đơn";
            Cursor.Current = Cursors.WaitCursor;
            XuLyChuyenForm();
            FrmThongKeHoaDon m_FrmThongKeHoaDon = FrmThongKeHoaDon.Instance;
            f = m_FrmThongKeHoaDon;
            m_FrmThongKeHoaDon.MdiParent = this;
            m_FrmThongKeHoaDon.Dock = DockStyle.Fill;
            m_FrmThongKeHoaDon.Show();

            Label lbl = new Label();
            lbl.Dock = DockStyle.Left;
            lbl.Text = "Lập báo cáo nhanh";
            lbl.ForeColor = Color.CadetBlue;
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.Font = new Font("SegoeUI", 11, FontStyle.Bold);
            panelBaoCao.Controls.Add(lbl);
            lbl.BringToFront();

            MaterialFlatButton btnTatCaHoaDon = new MaterialFlatButton();
            btnTatCaHoaDon.Dock = DockStyle.Left;
            btnTatCaHoaDon.Text = "Tất cả hoá đơn";
            btnTatCaHoaDon.Name = "TatCaHoaDon";
            btnTatCaHoaDon.Click += btn_Click;
            panelBaoCao.Controls.Add(btnTatCaHoaDon);
            btnTatCaHoaDon.BringToFront();
        }

        private void mThongKeNhapHang_Click(object sender, EventArgs e)
        {
            lblTieuDe.Text = "Thống kê nhập hàng";
            Cursor.Current = Cursors.WaitCursor;
            XuLyChuyenForm();
            FrmThongKeNhapHang m_FrmThongKeNhapHang = FrmThongKeNhapHang.Instance;
            f = m_FrmThongKeNhapHang;
            m_FrmThongKeNhapHang.MdiParent = this;
            m_FrmThongKeNhapHang.Dock = DockStyle.Fill;
            m_FrmThongKeNhapHang.Show();

            Label lbl = new Label();
            lbl.Dock = DockStyle.Left;
            lbl.Text = "Lập báo cáo nhanh";
            lbl.ForeColor = Color.CadetBlue;
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.Font = new Font("SegoeUI", 11, FontStyle.Bold);
            panelBaoCao.Controls.Add(lbl);
            lbl.BringToFront();

            MaterialFlatButton btnTatCaPhieuNhap = new MaterialFlatButton();
            btnTatCaPhieuNhap.Dock = DockStyle.Left;
            btnTatCaPhieuNhap.Text = "Tất cả phiếu nhập";
            btnTatCaPhieuNhap.Name = "TatCaPhieuNhap";
            btnTatCaPhieuNhap.Click += btn_Click;
            panelBaoCao.Controls.Add(btnTatCaPhieuNhap);
            btnTatCaPhieuNhap.BringToFront();
        }

        private void mQuanLyKho_Click(object sender, EventArgs e)
        {
            lblTieuDe.Text = "Quản lý kho";
            Cursor.Current = Cursors.WaitCursor;
            XuLyChuyenForm();
            FrmQuanLyKho m_FrmQuanLyKho = FrmQuanLyKho.Instance;
            f = m_FrmQuanLyKho;
            m_FrmQuanLyKho.MdiParent = this;
            m_FrmQuanLyKho.Dock = DockStyle.Fill;
            m_FrmQuanLyKho.Show();

            Label lbl = new Label();
            lbl.Dock = DockStyle.Left;
            lbl.Text = "Lập báo cáo nhanh";
            lbl.ForeColor = Color.CadetBlue;
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.Font = new Font("SegoeUI", 11, FontStyle.Bold);
            panelBaoCao.Controls.Add(lbl);
            lbl.BringToFront();

            MaterialFlatButton btnTatCaNguyenLieu = new MaterialFlatButton();
            btnTatCaNguyenLieu.Dock = DockStyle.Left;
            btnTatCaNguyenLieu.Text = "Tất cả nguyên liệu";
            btnTatCaNguyenLieu.Name = "TatCaNguyenLieu";
            btnTatCaNguyenLieu.Click += btn_Click;
            panelBaoCao.Controls.Add(btnTatCaNguyenLieu);
            btnTatCaNguyenLieu.BringToFront();
        }

        private void mThongKeDoanhSo_Click(object sender, EventArgs e)
        {
            lblTieuDe.Text = "Thống kê doanh số";
            Cursor.Current = Cursors.WaitCursor;
            XuLyChuyenForm();
            FrmThongKeDoanhSo m_FrmThongKeDoanhThu = FrmThongKeDoanhSo.Instance;
            f = m_FrmThongKeDoanhThu;
            m_FrmThongKeDoanhThu.MdiParent = this;
            m_FrmThongKeDoanhThu.Dock = DockStyle.Fill;
            m_FrmThongKeDoanhThu.Show();
        }

        private void mNhapHang_Click(object sender, EventArgs e)
        {
            lblTieuDe.Text = "Nhập hàng";
            Cursor.Current = Cursors.WaitCursor;
            XuLyChuyenForm();
            FrmNhapHang m_frmNhapHang = FrmNhapHang.Instance;
            f = m_frmNhapHang;
            m_frmNhapHang.MdiParent = this;
            m_frmNhapHang.Dock = DockStyle.Fill;
            m_frmNhapHang.Show();

            Label lbl = new Label();
            lbl.Dock = DockStyle.Left;
            lbl.Text = "Lập báo cáo nhanh";
            lbl.ForeColor = Color.CadetBlue;
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.Font = new Font("SegoeUI", 11, FontStyle.Bold);
            panelBaoCao.Controls.Add(lbl);
            lbl.BringToFront();

            MaterialFlatButton btnPhieuNhapMoiNhat = new MaterialFlatButton();
            btnPhieuNhapMoiNhat.Dock = DockStyle.Left;
            btnPhieuNhapMoiNhat.Text = "Phiếu nhập mới nhất";
            btnPhieuNhapMoiNhat.Name = "PhieuNhapMoiNhat";
            btnPhieuNhapMoiNhat.Click += btn_Click;
            panelBaoCao.Controls.Add(btnPhieuNhapMoiNhat);
            btnPhieuNhapMoiNhat.BringToFront();

            MaterialFlatButton btnPhieuNhapTrongNgay = new MaterialFlatButton();
            btnPhieuNhapTrongNgay.Dock = DockStyle.Left;
            btnPhieuNhapTrongNgay.Text = "Phiếu nhập trong ngày";
            btnPhieuNhapTrongNgay.Name = "PhieuNhapTrongNgay";
            btnPhieuNhapTrongNgay.Click += btn_Click;
            panelBaoCao.Controls.Add(btnPhieuNhapTrongNgay);
            btnPhieuNhapTrongNgay.BringToFront();
        }

        private void mBanHang_Click(object sender, EventArgs e)
        {
            lblTieuDe.Text = "Bán hàng";
            Cursor.Current = Cursors.WaitCursor;
            XuLyChuyenForm();
            FrmBanHang m_frmBanHang = FrmBanHang.Instance;
            f = m_frmBanHang;
            m_frmBanHang.MdiParent = this;
            m_frmBanHang.Dock = DockStyle.Fill;
            m_frmBanHang.Show();

            Label lbl = new Label();
            lbl.Dock = DockStyle.Left;
            lbl.Text = "Tùy chọn nhanh";
            lbl.ForeColor = Color.CadetBlue;
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.Font = new Font("SegoeUI", 11, FontStyle.Bold);
            panelBaoCao.Controls.Add(lbl);
            lbl.BringToFront();

            MaterialFlatButton btnLichSuHoaDon = new MaterialFlatButton();
            btnLichSuHoaDon.Dock = DockStyle.Left;
            btnLichSuHoaDon.Text = "Lịch sử hoá đơn";
            btnLichSuHoaDon.Name = "LichSuHoaDon";
            btnLichSuHoaDon.Click += btn_Click;
            panelBaoCao.Controls.Add(btnLichSuHoaDon);
            btnLichSuHoaDon.BringToFront();

            MaterialFlatButton btnHoaDonMoiNhat = new MaterialFlatButton();
            btnHoaDonMoiNhat.Dock = DockStyle.Left;
            btnHoaDonMoiNhat.Text = "Hóa đơn mới nhất";
            btnHoaDonMoiNhat.Name = "HoaDonMoiNhat";
            btnHoaDonMoiNhat.Click += btn_Click;
            panelBaoCao.Controls.Add(btnHoaDonMoiNhat);
            btnHoaDonMoiNhat.BringToFront();

            MaterialFlatButton btnHoaDonTrongNgay = new MaterialFlatButton();
            btnHoaDonTrongNgay.Dock = DockStyle.Left;
            btnHoaDonTrongNgay.Text = "Hóa đơn trong ngày";
            btnHoaDonTrongNgay.Name = "HoaDonTrongNgay";
            btnHoaDonTrongNgay.Click += btn_Click;
            panelBaoCao.Controls.Add(btnHoaDonTrongNgay);
            btnHoaDonTrongNgay.BringToFront();
        }

        private void mBaoCao_Click(object sender, EventArgs e)
        {
            lblTieuDe.Text = "Báo cáo";
            Cursor.Current = Cursors.WaitCursor;
            XuLyChuyenForm();
            FrmBaoCao m_frmBaoCao = FrmBaoCao.Instance;
            f = m_frmBaoCao;
            m_frmBaoCao.MdiParent = this;
            m_frmBaoCao.Dock = DockStyle.Fill;
            m_frmBaoCao.Show();
        }

        private void mCaiDat_Click(object sender, EventArgs e)
        {
            lblTieuDe.Text = "Cài đặt";
            Cursor.Current = Cursors.WaitCursor;
            XuLyChuyenForm();
            FrmCaiDat m_frmCaiDat = FrmCaiDat.Instance;
            f = m_frmCaiDat;
            m_frmCaiDat.MdiParent = this;
            m_frmCaiDat.Dock = DockStyle.Fill;
            m_frmCaiDat.Show();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            string btnName = ((MaterialFlatButton)sender).Name;

            if (btnName == "LichSuHoaDon")
            {
                FrmLichSuHoaDon frmLichSuHoaDon = FrmLichSuHoaDon.Instance;
                frmLichSuHoaDon.MinimizeBox = false;

                FrmMain.Instance.TopMost = false;
                frmLichSuHoaDon.ShowDialog();
                return;
            }

            FrmHienThiBaoCao frm = new FrmHienThiBaoCao();
            if (btnName == "TatCaMon")
            {
                frm.HienTatCaMon();
            }
            else if (btnName == "MonGomNhom")
            {
                frm.HienThiMonTheoNhom();
            }
            else if (btnName == "TatCaHoaDon")
            {
                frm.HienThiTatCacHoaDon();
            }
            else if (btnName == "TatCaPhieuNhap")
            {
                frm.HienTatCaPhieuNhap();
            }
            else if (btnName == "TatCaNguyenLieu")
            {
                frm.HienTatCaNguyenLieu();
            }
            else if(btnName == "HoaDonMoiNhat")
            {
                frm.HienThiHoaDonMoiNhat();
            }
            else if (btnName == "HoaDonTrongNgay")
            {
                frm.HienThiTatHoaDonLapTrongNgay();
            }
            else if (btnName == "PhieuNhapMoiNhat")
            {
                frm.HienThiPhieuNhapMoiNhat();
            }
            else if (btnName == "PhieuNhapTrongNgay")
            {
                frm.TatCaPhieuNhapLapTrongNgay();
            }
            this.TopMost = false;
            frm.Show();
        }

        private void btnAnHien_Click(object sender, EventArgs e)
        {
            if (panelThongTinState)
            {
                panelThongTin.Visible = false;
                panelTaiKhoan.Size = new Size(1319, 30);
            }
            else
            {
                panelThongTin.Visible = true;
                panelTaiKhoan.Size = new Size(1319, 90);
            }
            panelThongTinState = !panelThongTinState;
        }

        private void DongFormCon()
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
        }

        public void SetTieuDe(string ten)
        {
            lblTieuDe.Text = ten;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            if (this.HasChildren)
            {
                if (this.MdiChildren[0].Name == "FrmBanHang")
                {
                    if (((MetroPanel)(this.MdiChildren[0].Controls["panelLayout"])).Controls["ucXemLaiHoaDon"] != null)
                    {
                        if (((MetroPanel)(this.MdiChildren[0].Controls["panelLayout"])).Controls["splitContainer1"].Visible)
                        {
                            f.Close();
                            XuLyFormMain();
                        }
                        else
                        {
                            ((FrmBanHang)this.MdiChildren[0]).QuayLaiManHinhChonMon();
                        }
                    }
                    else
                    {
                        f.Close();
                        XuLyFormMain();
                    }
                }
                else
                {
                    f.Close();
                    XuLyFormMain();
                }
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DangXuat();
        }
    }
}
