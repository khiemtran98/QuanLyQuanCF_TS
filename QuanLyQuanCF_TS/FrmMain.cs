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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void moFormDangNhap()
        {
            FrmDangNhap m_frmDangNhap = FrmDangNhap.Instance;
            m_frmDangNhap.MdiParent = this;
            m_frmDangNhap.Dock = DockStyle.Fill;
            m_frmDangNhap.Show();
        }

        public void xuLyDangNhapThanhCong(int maNV)
        {
            xuLyFormMain();
            NhanVienDTO nv = NhanVienBUS.layThongTinNhanVien(maNV);
            lblHoTen.Text = "Họ tên: " + nv.HoTen;
            lblCa.Text = "Ca: " + nv.Ca;
            if (!nv.LaAdmin)
            {
                lblCapBac.Text = "Cấp bậc: nhân viên";
            }
            else
            {
                lblCapBac.Text = "Cấp bậc: quản lý";
            }
        }

        public void xuLyChuyenForm()
        {
            btnBanHang.Visible = btnDangXuat.Visible = tbcNhanVien.Visible = false;
        }

        public void xuLyFormMain()
        {
            btnBanHang.Visible = btnDangXuat.Visible = tbcNhanVien.Visible = true;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;
            xuLyChuyenForm();
            moFormDangNhap();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                e.Cancel = true;
            }
        }
        
        private void btnBanHang_Click(object sender, EventArgs e)
        {
            xuLyChuyenForm();
            FrmBanHang frmBanHang = FrmBanHang.Instance;
            frmBanHang.MdiParent = this;
            frmBanHang.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            xuLyChuyenForm();
            moFormDangNhap();
        }
    }
}
