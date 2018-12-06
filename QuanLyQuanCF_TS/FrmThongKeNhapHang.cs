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
    public partial class FrmThongKeNhapHang : MetroFramework.Forms.MetroForm
    {
        public FrmThongKeNhapHang()
        {
            InitializeComponent();

            #region
            this.Style = FrmMain.style;
            radHienThiTatCa.Style = FrmMain.style;
            radHienThiTheoNgay.Style = FrmMain.style;
            dtpNgayNhap.Style = FrmMain.style;
            #endregion
        }

        private static FrmThongKeNhapHang _Instance = null;

        public static FrmThongKeNhapHang Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FrmThongKeNhapHang();
                }
                return _Instance;
            }
        }

        private void FrmThongKeNhapHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void FrmThongKeNhapHang_Load(object sender, EventArgs e)
        {
            dgvPhieuNhap.AutoGenerateColumns = false;
            dgvCTPhieuNhap.AutoGenerateColumns = false;

            radHienThiTatCa.Checked = true;
        }

        private void LSPN_LoadDanhSachPhieuNhap()
        {
            List<PhieuNhapDTO> lsPhieuNhap = PhieuNhapBUS.LayDanhSachPhieuNhap();
            dgvPhieuNhap.DataSource = lsPhieuNhap;

            if (dgvPhieuNhap.Rows.Count > 0)
            {
                LoadCTPhieuNhap(Convert.ToInt32(dgvPhieuNhap.Rows[0].Cells["colPN_MaPhieuNhap"].Value));
            }
        }

        private void LSPN_LoadDanhSachPhieuNhapDaXoa()
        {
            List<PhieuNhapDTO> lsPhieuNhap = PhieuNhapBUS.LayDanhSachPhieuNhap(false);
            dgvPhieuNhap.DataSource = lsPhieuNhap;

            if (dgvPhieuNhap.Rows.Count > 0)
            {
                LoadCTPhieuNhap(Convert.ToInt32(dgvPhieuNhap.Rows[0].Cells["colPN_MaPhieuNhap"].Value));
            }
        }

        private void LSPN_LoadDanhSachPhieuNhapTheoNgay()
        {
            List<PhieuNhapDTO> lsPhieuNhap = PhieuNhapBUS.LayDanhSachPhieuNhapTheoNgay(dtpNgayNhap.Value);
            dgvPhieuNhap.DataSource = lsPhieuNhap;

            if (dgvPhieuNhap.Rows.Count > 0)
            {
                LoadCTPhieuNhap(Convert.ToInt32(dgvPhieuNhap.Rows[0].Cells["colPN_MaPhieuNhap"].Value));
            }
        }

        private void LSPN_LoadDanhSachPhieuNhapTheoNgayDaXoa()
        {
            List<PhieuNhapDTO> lsPhieuNhap = PhieuNhapBUS.LayDanhSachPhieuNhapTheoNgay(dtpNgayNhap.Value, false);
            dgvPhieuNhap.DataSource = lsPhieuNhap;

            if (dgvPhieuNhap.Rows.Count > 0)
            {
                LoadCTPhieuNhap(Convert.ToInt32(dgvPhieuNhap.Rows[0].Cells["colPN_MaPhieuNhap"].Value));
            }
        }

        private void radHienThiTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (radHienThiTatCa.Checked)
            {
                dgvCTPhieuNhap.DataSource = null;
                dtpNgayNhap.Enabled = false;
                LSPN_LoadDanhSachPhieuNhap();
            }
        }

        private void radHienThiTheoNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (radHienThiTheoNgay.Checked)
            {
                dgvCTPhieuNhap.DataSource = null;
                dtpNgayNhap.Enabled = true;
                LSPN_LoadDanhSachPhieuNhapTheoNgay();
            }
        }

        private void dtpNgayNhap_ValueChanged(object sender, EventArgs e)
        {
            dgvCTPhieuNhap.DataSource = null;
            LSPN_LoadDanhSachPhieuNhapTheoNgay();
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPhieuNhap.SelectedRows.Count > 0)
            {
                LoadCTPhieuNhap(Convert.ToInt32(dgvPhieuNhap.SelectedRows[0].Cells["colPN_MaPhieuNhap"].Value));
            }
        }

        private void dgvPhieuNhap_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridViewComboBoxCell)dgvPhieuNhap.Rows[e.RowIndex].Cells["colPN_NhaCungCap"]).DataSource = NhaCungCapBUS.LayDanhSachNhaCungCap();
            ((DataGridViewComboBoxCell)dgvPhieuNhap.Rows[e.RowIndex].Cells["colPN_NhaCungCap"]).DisplayMember = "TenNhaCungCap";
            ((DataGridViewComboBoxCell)dgvPhieuNhap.Rows[e.RowIndex].Cells["colPN_NhaCungCap"]).ValueMember = "MaNhaCungCap";
        }

        private void dgvCTPhieuNhap_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridViewComboBoxCell)dgvCTPhieuNhap.Rows[e.RowIndex].Cells["colCTPN_MaNguyenLieu"]).DataSource = NguyenLieuBUS.LayDanhSachTatCaNguyenLieu();
            ((DataGridViewComboBoxCell)dgvCTPhieuNhap.Rows[e.RowIndex].Cells["colCTPN_MaNguyenLieu"]).DisplayMember = "TenNguyenLieu";
            ((DataGridViewComboBoxCell)dgvCTPhieuNhap.Rows[e.RowIndex].Cells["colCTPN_MaNguyenLieu"]).ValueMember = "MaNguyenLieu";
        }

        private void LoadCTPhieuNhap(int maPhieuNhap)
        {
            List<CTPhieuNhapDTO> lsCTPhieuNhap = CTPhieuNhapBUS.LayDanhSachCTPhieuNhap(maPhieuNhap);
            dgvCTPhieuNhap.DataSource = lsCTPhieuNhap;
        }
    }
}
