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
            this.Size = new Size(800, 458);
            FrmDangNhap m_frmDangNhap = FrmDangNhap.Instance;
            m_frmDangNhap.MdiParent = this;
            m_frmDangNhap.Dock = DockStyle.Fill;
            m_frmDangNhap.Show();
        }

        public void XuLyDangNhapThanhCong(int maTaiKhoan)
        {
            this.WindowState = FormWindowState.Maximized;
            XuLyFormMain();
            TaiKhoanBUS.LuuTaiKhoanDangNhap(maTaiKhoan);
            TaiKhoanDTO taiKhoan = TaiKhoanBUS.LayThongTinTaiKhoan(maTaiKhoan);
            lblHoTen.Text = taiKhoan.HoTen;
            lblCapBac.Text = TaiKhoanBUS.LayTenLoaiTaiKhoan(taiKhoan.LoaiTaiKhoan);
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
            TaiKhoanBUS.LuuTaiKhoanDangNhap(-1);
            MoFormDangNhap();
        }

        private void mtQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            XuLyChuyenForm();
            FrmQuanLyTaiKhoan m_FrmQuanLyTaiKhoan = FrmQuanLyTaiKhoan.Instance;
            m_FrmQuanLyTaiKhoan.MdiParent = this;
            m_FrmQuanLyTaiKhoan.Dock = DockStyle.Fill;
            m_FrmQuanLyTaiKhoan.Show();
        }

        private void mQuanLyMon_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            XuLyChuyenForm();
            FrmQuanLyMon_Topping m_FrmQuanLyMonVaTopping = FrmQuanLyMon_Topping.Instance;
            m_FrmQuanLyMonVaTopping.MdiParent = this;
            m_FrmQuanLyMonVaTopping.Dock = DockStyle.Fill;
            m_FrmQuanLyMonVaTopping.Show();
        }

        private void mThongKeHoaDon_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        private void mThongKeNhapHang_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        private void mQuanLyKho_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        private void mThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        private void mNhapHang_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        private void mBanHang_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            XuLyChuyenForm();
            FrmBanHang m_frmBanHang = FrmBanHang.Instance;
            m_frmBanHang.MdiParent = this;
            m_frmBanHang.Dock = DockStyle.Fill;
            m_frmBanHang.Show();
        }
    }
}
