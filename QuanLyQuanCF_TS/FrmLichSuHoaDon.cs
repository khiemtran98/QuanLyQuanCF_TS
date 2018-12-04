using MetroFramework.Forms;
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
    public partial class FrmLichSuHoaDon : MetroForm
    {
        public FrmLichSuHoaDon()
        {
            InitializeComponent();

            #region
            this.Style = FrmMain.style;
            lnkDSHoaDon.Style = FrmMain.style;
            btnXoaHoaDon.Style = FrmMain.style;
            btnKhoiPhucHoaDon.Style = FrmMain.style;
            #endregion
        }

        private static FrmLichSuHoaDon _Instance = null;

        public static FrmLichSuHoaDon Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FrmLichSuHoaDon();
                }
                return _Instance;
            }
        }

        private void FrmLichSuHoaDon_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMain.Instance.TopMost = FrmMain.topMost;
            _Instance = null;
        }

        private void FrmLichSuHoaDon_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvCTHoaDon.AutoGenerateColumns = false;

            lblNhanVienLap.Text += TaiKhoanBUS.LayThongTinTaiKhoan(TaiKhoanBUS.LayTaiKhoanDangNhap()).HoTen;
            lblNgayLap.Text += DateTime.Now.ToShortDateString();

            LoadDanhSachHoaDon();
        }

        private void LoadDanhSachHoaDon()
        {
            dgvHoaDon.DataSource = HoaDonBUS.LayLichSuHoaDon(TaiKhoanBUS.LayTaiKhoanDangNhap());

            if (dgvHoaDon.Rows.Count > 0)
            {
                LoadDanhSachCTHoaDon(Convert.ToInt32(dgvHoaDon.Rows[0].Cells["colMaHoaDon"].Value));
            }
        }

        private void LoadDanhSachCTHoaDon(int maHoaDon)
        {
            dgvCTHoaDon.DataSource = rptMon_CTHDBUS.DoiMaMonThanhTenMon(maHoaDon);
        }

        private void LoadDanhSachHoaDonDaXoa()
        {
            dgvHoaDon.DataSource = HoaDonBUS.LayLichSuHoaDon(TaiKhoanBUS.LayTaiKhoanDangNhap(), false);
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                LoadDanhSachCTHoaDon(Convert.ToInt32(dgvHoaDon.SelectedRows[0].Cells["colMaHoaDon"].Value));
                btnXoaHoaDon.Enabled = true;
                btnKhoiPhucHoaDon.Enabled = true;
            }
        }

        private void lnkDSHoaDon_Click(object sender, EventArgs e)
        {
            if (lnkDSHoaDon.AccessibleName == "DSHoaDon")
            {
                lnkDSHoaDon.Text = "Hiện danh sách hoá đơn đang có";
                LoadDanhSachHoaDonDaXoa();
                lnkDSHoaDon.AccessibleName = "DSHoaDonDaXoa";
                btnXoaHoaDon.Visible = false;
                btnKhoiPhucHoaDon.Visible = true;
            }
            else
            {
                lnkDSHoaDon.Text = "Hiện danh sách hoá đơn đã xoá";
                LoadDanhSachHoaDon();
                lnkDSHoaDon.AccessibleName = "DSHoaDon";
                btnXoaHoaDon.Visible = true;
                btnKhoiPhucHoaDon.Visible = false;
            }
        }

        private void btnXoaHoaDon_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn xoá phiếu nhập này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (HoaDonBUS.XoaHoaDon(Convert.ToInt32(dgvHoaDon.SelectedRows[0].Cells["colMaHoaDon"].Value)))
                {
                    MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachHoaDon();
                    dgvCTHoaDon.DataSource = null;
                    dgvHoaDon.ClearSelection();
                    btnXoaHoaDon.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Xoá thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnKhoiPhucHoaDon_Click(object sender, EventArgs e)
        {
            if (HoaDonBUS.KhoiPhucHoaDon(Convert.ToInt32(dgvHoaDon.SelectedRows[0].Cells["colMaHoaDon"].Value)))
            {
                MessageBox.Show("Khôi phục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachHoaDonDaXoa();
                dgvCTHoaDon.DataSource = null;
                dgvHoaDon.ClearSelection();
                btnKhoiPhucHoaDon.Enabled = false;
            }
            else
            {
                MessageBox.Show("Khôi phục thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHoaDon_DataSourceChanged(object sender, EventArgs e)
        {
            if (dgvHoaDon.Rows.Count > 0)
            {
                btnXoaHoaDon.Enabled = true;
                btnKhoiPhucHoaDon.Enabled = true;
            }
            else
            {
                btnXoaHoaDon.Enabled = false;
                btnKhoiPhucHoaDon.Enabled = false;
            }
        }
    }
}
