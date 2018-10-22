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
using BUS;

namespace QuanLyQuanCF_TS
{
    public partial class FrmMain : MetroFramework.Forms.MetroForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void MoFormDangNhap()
        {
            this.WindowState = FormWindowState.Normal;
            this.Movable = true;
            FrmDangNhap m_frmDangNhap = FrmDangNhap.Instance;
            m_frmDangNhap.MdiParent = this;
            m_frmDangNhap.Dock = DockStyle.Fill;
            m_frmDangNhap.Show();
        }

        public void XuLyDangNhapThanhCong(int maNhanVien)
        {
            this.WindowState = FormWindowState.Maximized;
            XuLyFormMain();
            NhanVienBUS.LuuTaiKhoanDangNhap(maNhanVien);
            NhanVienDTO nhanVien = NhanVienBUS.LayThongTinNhanVien(maNhanVien);
            lblHoTen.Text = nhanVien.HoTen;
            if (!nhanVien.LaAdmin)
            {
                lblCapBac.Text = "Nhân viên";
            }
            else
            {
                lblCapBac.Text = "Quản lý";
            }
        }

        public void XuLyChuyenForm()
        {
            mPanel.Visible = false;
            panelTaiKhoan.Visible = false;
            this.DisplayHeader = false;
        }

        public void XuLyFormMain()
        {
            mPanel.Visible = true;
            this.DisplayHeader = true;
            this.Movable = false;
            panelTaiKhoan.Visible = true;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            XuLyChuyenForm();
            MoFormDangNhap();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                e.Cancel = true;
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            XuLyChuyenForm();
            NhanVienBUS.LuuTaiKhoanDangNhap(-1);
            MoFormDangNhap();
        }

        private void mtQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void mQuanLyMon_Click(object sender, EventArgs e)
        {

        }

        private void mThongKeHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void mThongKeNhapHang_Click(object sender, EventArgs e)
        {

        }

        private void mQuanLyKho_Click(object sender, EventArgs e)
        {

        }

        private void mThongKeDoanhThu_Click(object sender, EventArgs e)
        {

        }

        private void mNhapHang_Click(object sender, EventArgs e)
        {

        }

        private void mBanHang_Click(object sender, EventArgs e)
        {
            XuLyChuyenForm();
            FrmBanHang m_frmBanHang = FrmBanHang.Instance;
            m_frmBanHang.MdiParent = this;
            m_frmBanHang.Dock = DockStyle.Fill;
            m_frmBanHang.Show();
        }
    }
}
