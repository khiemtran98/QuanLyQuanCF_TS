using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
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
            //metroPanel5.Visible = metroPanel6.Visible = metroPanel7.Visible = metroPanel8.Visible = metroPanel10.Visible = metroPanel11.Visible = metroPanel13.Visible = metroPanel14.Visible = metroPanel15.Visible = metroPanel16.Visible = false;
            //metroPanel1.Visible = metroPanel2.Visible = true;
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
            picHinh.ImageLocation = "img\\accounts\\" + taiKhoan.Hinh;

            List<ChucNang_LoaiTaiKhoanDTO> lsChucNang_LoaiTaiKhoan = ChucNang_LoaiTaiKhoanBUS.LayDanhSachChucNang_LoaiTaiKhoan(maTaiKhoan);
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
                metroPanel1.Visible = false ;
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

        public void XuLyChuyenForm()
        {
            mPanel.Visible = false;
            panelTaiKhoan.Visible = false;
            this.DisplayHeader = false;
        }

        public void XuLyFormMain()
        {
            mPanel.Visible = true;
            this.Movable = false;
            panelTaiKhoan.Visible = true;
            this.DisplayHeader = true;
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
            DangXuat();
        }

        public void DangXuat()
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
            XuLyChuyenForm();
            FrmThongKeHoaDon m_FrmThongKeHoaDon = FrmThongKeHoaDon.Instance;
            m_FrmThongKeHoaDon.MdiParent = this;
            m_FrmThongKeHoaDon.Dock = DockStyle.Fill;
            m_FrmThongKeHoaDon.Show();
        }

        private void mThongKeNhapHang_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            XuLyChuyenForm();
            FrmThongKeNhapHang m_FrmThongKeNhapHang = FrmThongKeNhapHang.Instance;
            m_FrmThongKeNhapHang.MdiParent = this;
            m_FrmThongKeNhapHang.Dock = DockStyle.Fill;
            m_FrmThongKeNhapHang.Show();
        }

        private void mQuanLyKho_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            XuLyChuyenForm();
            FrmQuanLyKho m_FrmQuanLyKho = FrmQuanLyKho.Instance;
            m_FrmQuanLyKho.MdiParent = this;
            m_FrmQuanLyKho.Dock = DockStyle.Fill;
            m_FrmQuanLyKho.Show();
        }

        private void mThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            XuLyChuyenForm();
            FrmThongKeDoanhThu m_FrmThongKeDoanhThu = FrmThongKeDoanhThu.Instance;
            m_FrmThongKeDoanhThu.MdiParent = this;
            m_FrmThongKeDoanhThu.Dock = DockStyle.Fill;
            m_FrmThongKeDoanhThu.Show();
        }

        private void mNhapHang_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            XuLyChuyenForm();
            FrmNhapHang m_frmNhapHang = FrmNhapHang.Instance;
            m_frmNhapHang.MdiParent = this;
            m_frmNhapHang.Dock = DockStyle.Fill;
            m_frmNhapHang.Show();
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

        private void mBaoCao_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            XuLyChuyenForm();
            FrmBaoCao m_frmBaoCao = FrmBaoCao.Instance;
            m_frmBaoCao.MdiParent = this;
            m_frmBaoCao.Dock = DockStyle.Fill;
            m_frmBaoCao.Show();
        }

        private void mCaiDat_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            XuLyChuyenForm();
            FrmCaiDat m_frmCaiDat = FrmCaiDat.Instance;
            m_frmCaiDat.MdiParent = this;
            m_frmCaiDat.Dock = DockStyle.Fill;
            m_frmCaiDat.Show();
        }
    }
}
