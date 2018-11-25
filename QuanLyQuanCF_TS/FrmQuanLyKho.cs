using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
namespace QuanLyQuanCF_TS
{
    public partial class FrmQuanLyKho : MetroFramework.Forms.MetroForm
    {
        public FrmQuanLyKho()
        {
            InitializeComponent();

            #region
            this.Style = FrmMain.style;
            tbcQuanLyKho.Style = FrmMain.style;
            txtTimKiemNguyenLieu.Style = FrmMain.style;
            btnTimKiemNguyenLieu.Style = FrmMain.style;
            lnkDSNguyenLieu.Style = FrmMain.style;
            txtMaNguyenLieu.Style = FrmMain.style;
            txtTenNguyenLieu.Style = FrmMain.style;
            txtSoLuong.Style = FrmMain.style;
            txtDonViTinh.Style = FrmMain.style;
            btnThemNguyenLieu.Style = FrmMain.style;
            btnXoaNguyenLieu.Style = FrmMain.style;
            btnSuaNguyenLieu.Style = FrmMain.style;
            btnKhoiPhucNguyenLieu.Style = FrmMain.style;

            radHienThiTatCa.Style = FrmMain.style;
            radHienThiTheoNgay.Style = FrmMain.style;
            dtpNgayNhap.Style = FrmMain.style;
            lnkDSPhieuNhap.Style = FrmMain.style;
            btnXoaPhieuNhap.Style = FrmMain.style;
            btnKhoiPhucPhieuNhap.Style = FrmMain.style;
            #endregion
        }

        private static FrmQuanLyKho _Instance = null;

        public static FrmQuanLyKho Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FrmQuanLyKho();
                }
                return _Instance;
            }
        }

        private void FrmQuanLyKho_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void FrmQuanLyKho_Load(object sender, EventArgs e)
        {
            dgvNguyenLieu.AutoGenerateColumns = false;
            dgvPhieuNhap.AutoGenerateColumns = false;
            dgvCTPhieuNhap.AutoGenerateColumns = false;

            NL_LoadDanhSachNguyenLieu();
            LSPN_LoadDanhSachPhieuNhap();

            //tbcQuanLyKho.SelectedTab = tbpNguyenLieu;
        }

        private void tbcQuanLyKho_Selecting(object sender, TabControlCancelEventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;

            if (current.Name == "tbpNguyenLieu")
            {
                if (lnkDSNguyenLieu.AccessibleName == "DSNguyenLieu")
                {
                    NL_LoadDanhSachNguyenLieu();
                }
                else
                {
                    NL_LoadDanhSachNguyenLieuDaXoa();
                }
            }
        }

        // Bắt đầu khu vực chức năng Quản lý nguyên liệu

        private void NL_LoadDanhSachNguyenLieu(string timKiem = "")
        {
            List<NguyenLieuDTO> lsNguyenLieu = NguyenLieuBUS.LayDanhSachNguyenLieu(timKiem);
            dgvNguyenLieu.DataSource = lsNguyenLieu;
        }

        private void NL_LoadDanhSachNguyenLieuDaXoa(string timKiem = "")
        {
            List<NguyenLieuDTO> lsNguyenLieu = NguyenLieuBUS.LayDanhSachNguyenLieu(timKiem, false);
            dgvNguyenLieu.DataSource = lsNguyenLieu;
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvNguyenLieu.SelectedRows.Count > 0)
            {
                LamMoiNguyenLieu(false);
                txtMaNguyenLieu.Text = dgvNguyenLieu.SelectedRows[0].Cells["colMaNguyenLieu"].Value.ToString();
                txtTenNguyenLieu.Text = dgvNguyenLieu.SelectedRows[0].Cells["colTenNguyenLieu"].Value.ToString();
                txtSoLuong.Text = dgvNguyenLieu.SelectedRows[0].Cells["colSoLuong"].Value.ToString();
                txtDonViTinh.Text = dgvNguyenLieu.SelectedRows[0].Cells["colDonViTinh"].Value.ToString();
            }
        }

        private void lnkDSNguyenLieu_Click(object sender, EventArgs e)
        {
            if (lnkDSNguyenLieu.AccessibleName == "DSNguyenLieu")
            {
                lnkDSNguyenLieu.Text = "Hiện danh sách nguyên liệu đang có";
                NL_LoadDanhSachNguyenLieuDaXoa();
                lnkDSNguyenLieu.AccessibleName = "DSNguyenLieuDaXoa";
                panelChucNangDSNguyenLieu.Visible = false;
                panelChucNangDSNguyenLieuDaXoa.Visible = true;
                LamMoiNguyenLieu();
                txtTenNguyenLieu.Enabled = txtSoLuong.Enabled = txtDonViTinh.Enabled = false;
            }
            else
            {
                lnkDSNguyenLieu.Text = "Hiện danh sách nguyên liệu đã xoá";
                NL_LoadDanhSachNguyenLieu();
                lnkDSNguyenLieu.AccessibleName = "DSNguyenLieu";
                panelChucNangDSNguyenLieu.Visible = true;
                panelChucNangDSNguyenLieuDaXoa.Visible = false;
                LamMoiNguyenLieu();
                txtTenNguyenLieu.Enabled = txtSoLuong.Enabled = txtDonViTinh.Enabled = true;
            }
        }

        private void LamMoiNguyenLieu(bool state = true)
        {
            txtMaNguyenLieu.Text = txtTenNguyenLieu.Text = txtSoLuong.Text = txtDonViTinh.Text = string.Empty;
            btnThemNguyenLieu.Enabled = state;
            btnXoaNguyenLieu.Enabled = !state;
            btnSuaNguyenLieu.Enabled = !state;
            btnKhoiPhucNguyenLieu.Enabled = !state;
        }

        private void btnThemNguyenLieu_Click(object sender, EventArgs e)
        {
            NguyenLieuDTO nguyenLieu = new NguyenLieuDTO();
            nguyenLieu.TenNguyenLieu = txtTenNguyenLieu.Text;
            if (txtSoLuong.Text != "")
            {
                nguyenLieu.SoLuong = Convert.ToInt32(txtSoLuong.Text);
            }
            else
            {
                nguyenLieu.SoLuong = 0;
            }
            nguyenLieu.DonViTinh = txtDonViTinh.Text;
            nguyenLieu.TrangThai = true;

            if (NguyenLieuBUS.ThemNguyenLieu(nguyenLieu))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiNguyenLieu();
                NL_LoadDanhSachNguyenLieu();
                dgvNguyenLieu.ClearSelection();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nguyenLieu = null;
            }
        }

        private void btnXoaNguyenLieu_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn xoá nguyên liệu này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (NguyenLieuBUS.XoaNguyenLieu(Convert.ToInt32(txtMaNguyenLieu.Text)))
                {
                    MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiNguyenLieu();
                    NL_LoadDanhSachNguyenLieu();
                    dgvNguyenLieu.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Xoá thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaNguyenLieu_Click(object sender, EventArgs e)
        {
            NguyenLieuDTO nguyenLieu = new NguyenLieuDTO();
            nguyenLieu.MaNguyenLieu = Convert.ToInt32(txtMaNguyenLieu.Text);
            nguyenLieu.TenNguyenLieu = txtTenNguyenLieu.Text;
            if (txtSoLuong.Text != "")
            {
                nguyenLieu.SoLuong = Convert.ToInt32(txtSoLuong.Text);
            }
            else
            {
                nguyenLieu.SoLuong = 0;
            }
            nguyenLieu.DonViTinh = txtDonViTinh.Text;
            nguyenLieu.TrangThai = true;
            if (NguyenLieuBUS.SuaNguyenLieu(nguyenLieu))
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiNguyenLieu();
                NL_LoadDanhSachNguyenLieu();
                dgvNguyenLieu.ClearSelection();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nguyenLieu = null;
            }
        }

        private void btnLamMoiNguyenLieu_Click(object sender, EventArgs e)
        {
            LamMoiNguyenLieu();
        }

        private void btnKhoiPhucNguyenLieu_Click(object sender, EventArgs e)
        {
            if (NguyenLieuBUS.KhoiPhucNguyenLieu(Convert.ToInt32(txtMaNguyenLieu.Text)))
            {
                MessageBox.Show("Khôi phục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NL_LoadDanhSachNguyenLieuDaXoa();
                LamMoiNguyenLieu();
                dgvNguyenLieu.ClearSelection();
            }
            else
            {
                MessageBox.Show("Khôi phục thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiemNguyenLieu_Leave(object sender, EventArgs e)
        {
            if (txtTimKiemNguyenLieu.Text == string.Empty)
            {
                txtTimKiemNguyenLieu.Text = "Tìm kiếm tên nguyên liệu";
            }
        }

        private void txtTimKiemNguyenLieu_Enter(object sender, EventArgs e)
        {
            if (txtTimKiemNguyenLieu.Text == "Tìm kiếm tên nguyên liệu")
            {
                txtTimKiemNguyenLieu.Text = string.Empty;
            }
        }

        private void TimKiemNguyenLieu()
        {
            if (lnkDSNguyenLieu.AccessibleName == "DSNguyenLieu")
            {
                NL_LoadDanhSachNguyenLieu(txtTimKiemNguyenLieu.Text);
            }
            else
            {
                NL_LoadDanhSachNguyenLieuDaXoa(txtTimKiemNguyenLieu.Text);
            }
        }

        private void btnTimKiemNguyenLieu_Click(object sender, EventArgs e)
        {
            TimKiemNguyenLieu();
        }

        private void txtTimKiemNguyenLieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TimKiemNguyenLieu();
            }
        }

        // Kết thúc Khu vực chức năng Quản lý nguyên liệu

        // ----------------------------------------------

        // Bắt đầu khu vực chức năng Xem lịch sử phiếu nhập

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
                if (lnkDSPhieuNhap.AccessibleName == "DSPhieuNhap")
                {
                    LSPN_LoadDanhSachPhieuNhap();
                }
                else
                {
                    LSPN_LoadDanhSachPhieuNhapDaXoa();
                }
            }
        }

        private void radHienThiTheoNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (radHienThiTheoNgay.Checked)
            {
                dgvCTPhieuNhap.DataSource = null;
                dtpNgayNhap.Enabled = true;
                if (lnkDSPhieuNhap.AccessibleName == "DSPhieuNhap")
                {
                    LSPN_LoadDanhSachPhieuNhapTheoNgay();
                }
                else
                {
                    LSPN_LoadDanhSachPhieuNhapTheoNgayDaXoa();
                }
            }
        }

        private void dtpNgayNhap_ValueChanged(object sender, EventArgs e)
        {
            LSPN_LoadDanhSachPhieuNhapTheoNgay();
            dgvCTPhieuNhap.DataSource = null;
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvPhieuNhap.SelectedRows.Count > 0)
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

        private void lnkDSPhieuNhap_Click(object sender, EventArgs e)
        {
            if (lnkDSPhieuNhap.AccessibleName == "DSPhieuNhap")
            {
                lnkDSPhieuNhap.Text = "Hiện danh sách phiếu nhập đang có";
                LSPN_LoadDanhSachPhieuNhapDaXoa();
                lnkDSPhieuNhap.AccessibleName = "DSPhieuNhapDaXoa";
                btnXoaPhieuNhap.Visible = false;
                btnKhoiPhucPhieuNhap.Visible = true;
            }
            else
            {
                lnkDSPhieuNhap.Text = "Hiện danh sách phiếu nhập đã xoá";
                LSPN_LoadDanhSachPhieuNhap();
                lnkDSPhieuNhap.AccessibleName = "DSPhieuNhap";
                btnXoaPhieuNhap.Visible = true;
                btnKhoiPhucPhieuNhap.Visible = false;
            }
        }

        private void btnXoaPhieuNhap_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Xoá phiếu nhập sẽ đồng thời trừ đi số lượng tồn kho của các nguyên liệu có trong danh sách phiếu.\n\nBạn có chắc chắn muốn xoá phiếu nhập này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                List<CTPhieuNhapDTO> lsCTPhieuNhap = new List<CTPhieuNhapDTO>();
                foreach (DataGridViewRow row in dgvCTPhieuNhap.Rows)
                {
                    CTPhieuNhapDTO ctPhieuNhap = new CTPhieuNhapDTO();
                    ctPhieuNhap.MaNguyenLieu = Convert.ToInt32(row.Cells["colCTPN_MaNguyenLieu"].Value);
                    ctPhieuNhap.SoLuong = Convert.ToInt32(row.Cells["colCTPN_SoLuong"].Value);

                    lsCTPhieuNhap.Add(ctPhieuNhap);
                }
                if (PhieuNhapBUS.XoaPhieuNhap(Convert.ToInt32(dgvPhieuNhap.SelectedRows[0].Cells["colPN_MaPhieuNhap"].Value), lsCTPhieuNhap))
                {
                    MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LSPN_LoadDanhSachPhieuNhap();
                    dgvCTPhieuNhap.DataSource = null;
                    dgvPhieuNhap.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Xoá thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnKhoiPhucPhieuNhap_Click(object sender, EventArgs e)
        {
            List<CTPhieuNhapDTO> lsCTPhieuNhap = new List<CTPhieuNhapDTO>();
            foreach (DataGridViewRow row in dgvCTPhieuNhap.Rows)
            {
                CTPhieuNhapDTO ctPhieuNhap = new CTPhieuNhapDTO();
                ctPhieuNhap.MaNguyenLieu = Convert.ToInt32(row.Cells["colCTPN_MaNguyenLieu"].Value);
                ctPhieuNhap.SoLuong = Convert.ToInt32(row.Cells["colCTPN_SoLuong"].Value);

                lsCTPhieuNhap.Add(ctPhieuNhap);
            }
            if (PhieuNhapBUS.KhoiPhucPhieuNhap(Convert.ToInt32(dgvPhieuNhap.SelectedRows[0].Cells["colPN_MaPhieuNhap"].Value), lsCTPhieuNhap))
            {
                MessageBox.Show("Khôi phục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LSPN_LoadDanhSachPhieuNhapDaXoa();
                dgvCTPhieuNhap.DataSource = null;
                dgvPhieuNhap.ClearSelection();
            }
            else
            {
                MessageBox.Show("Khôi phục thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Kết thúc Khu vực chức năng Xem lịch sử phiếu nhập

        // ----------------------------------------------
    }
}
