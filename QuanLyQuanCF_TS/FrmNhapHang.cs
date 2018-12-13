using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyQuanCF_TS
{
    public partial class FrmNhapHang : MetroFramework.Forms.MetroForm
    {
        public FrmNhapHang()
        {
            InitializeComponent();

            #region
            this.Style = FrmMain.style;
            cmbNhaCungCap.Style = FrmMain.style;
            dtpNgayLap.Style = FrmMain.style;
            lnkHienBangChonNhanh.Style = FrmMain.style;
            btnNhapHang.Style = FrmMain.style;

            cmbNguyenLieu.Style = FrmMain.style;
            txtSoLuong.Style = FrmMain.style;
            txtDonGia.Style = FrmMain.style;
            txtGhiChu.Style = FrmMain.style;
            btnThem.Style = FrmMain.style;
            btnXoa.Style = FrmMain.style;
            btnSua.Style = FrmMain.style;
            btnLamMoi.Style = FrmMain.style;
            grvBangChonNhanh.Style = FrmMain.style;
            #endregion
        }

        private static FrmNhapHang _Instance = null;

        public static FrmNhapHang Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FrmNhapHang();
                }
                return _Instance;
            }
        }

        private void FrmNhapHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void FrmNhapHang_Load(object sender, EventArgs e)
        {
            grvBangChonNhanh.AutoGenerateColumns = false;

            List<NguyenLieuDTO> lsNguyenLieu = NguyenLieuBUS.LayDanhSachNguyenLieu();
            LoadBangChonNhanh(lsNguyenLieu);
            LoadDanhSachNguyenLieu(lsNguyenLieu);
            LoadNhaCungCap();

            lblMaPhieu.Text = PhieuNhapBUS.LayMaPhieuNhapMoiNhat() + 1 + "";
            dtpNgayLap.Value = DateTime.Now;

            LamMoi();

            if (cmbNguyenLieu.Items.Count > 0)
            {
                btnThem.Enabled = true;
            }
            else
            {
                btnThem.Enabled = false;
            }
        }

        private void LoadDanhSachNguyenLieu(List<NguyenLieuDTO> lsNguyenLieu)
        {
            cmbNguyenLieu.DataSource = lsNguyenLieu;
            cmbNguyenLieu.DisplayMember = "TenNguyenLieu";
            cmbNguyenLieu.ValueMember = "MaNguyenLieu";
        }

        private void LoadBangChonNhanh(List<NguyenLieuDTO> lsNguyenLieu)
        {
            grvBangChonNhanh.DataSource = lsNguyenLieu;
        }

        private void LoadNhaCungCap()
        {
            cmbNhaCungCap.DataSource = NhaCungCapBUS.LayDanhSachNhaCungCap("", true);
            cmbNhaCungCap.DisplayMember = "TenNhaCungCap";
            cmbNhaCungCap.ValueMember = "MaNhaCungCap";
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            string dika = txtSoLuong.Text;
            int countDot = 0;
            for (int i = 0; i < dika.Length; i++)
            {
                if (dika[i] == ',')
                {
                    countDot++;
                    if (countDot > 1)
                    {
                        dika = dika.Remove(i, 1);
                        i--;
                        countDot--;
                    }
                }
            }
            txtSoLuong.Text = dika;
            txtSoLuong.Select(dika.Length, 0);
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void lnkHienBangChonNhanh_Click(object sender, EventArgs e)
        {
            if (!grvBangChonNhanh.Visible)
            {
                lnkHienBangChonNhanh.Text = "Ẩn bảng chọn nhanh";
                grvBangChonNhanh.Visible = true;
            }
            else
            {
                lnkHienBangChonNhanh.Text = "Hiện bảng chọn nhanh";
                grvBangChonNhanh.Visible = false;
            }
        }

        private void grvBangChonNhanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grvBangChonNhanh.SelectedRows.Count > 0)
            {
                //btnThem.Enabled = true;
                //btnXoa.Enabled = btnSua.Enabled = btnLamMoi.Enabled = false;
                LamMoi();
                cmbNguyenLieu.SelectedValue = Convert.ToInt32(grvBangChonNhanh.SelectedRows[0].Cells["colQuickView_MaNguyenLieu"].Value);
                lblDonViTinh.Text = grvBangChonNhanh.SelectedRows[0].Cells["colQuickView_DonViTinh"].Value.ToString();
            }
        }

        private void LamMoi(bool state = true)
        {
            lblMaPhieu.Text = PhieuNhapBUS.LayMaPhieuNhapMoiNhat() + 1 + "";
            dtpNgayLap.Value = DateTime.Now;
            txtSoLuong.Text = txtDonGia.Text = string.Empty;
            btnThem.Enabled = state;
            btnXoa.Enabled = btnSua.Enabled = btnLamMoi.Enabled = !state;
        }

        private double TinhTongTien()
        {
            double tongTien = 0;
            foreach (DataGridViewRow row in dgvCTPhieuNhap.Rows)
            {
                string donGia = row.Cells["colDonGia"].Value.ToString();
                tongTien += Convert.ToDouble(row.Cells["colSoLuong"].Value) * Convert.ToDouble(donGia.Remove(donGia.Length - 1));
            }
            return tongTien;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Text == "" || Convert.ToInt32(txtSoLuong.Text) == 0)
            {
                MessageBox.Show("Bạn chưa nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtDonGia.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đơn giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow row = new DataGridViewRow();
            row.DefaultCellStyle.BackColor = Color.AliceBlue;
            row.Height = 50;
            row.Cells.Add(new DataGridViewComboBoxCell { DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing, Value = cmbNguyenLieu.SelectedValue });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = txtSoLuong.Text });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = Convert.ToDouble(txtDonGia.Text).ToString("#,###đ") });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = lblDonViTinh.Text });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = txtGhiChu.Text });
            dgvCTPhieuNhap.Rows.Add(row);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvCTPhieuNhap.SelectedRows[0];

            row.Cells["colMaNguyenLieu"].Value = cmbNguyenLieu.SelectedValue;
            row.Cells["colSoLuong"].Value = txtSoLuong.Text;
            if (txtDonGia.Text != "")
            {
                row.Cells["colDonGia"].Value = Convert.ToDouble(txtDonGia.Text).ToString("#,###đ");
            }
            else
            {
                row.Cells["colDonGia"].Value = "0đ";
            }
            row.Cells["colDonViTinh"].Value = lblDonViTinh.Text;
            row.Cells["colGhiChu"].Value = txtGhiChu.Text;

            lblTongTien.Text = TinhTongTien().ToString("#,##0đ");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvCTPhieuNhap.SelectedRows[0];
            dgvCTPhieuNhap.Rows.Remove(row);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void grvBangChonNhanh_SelectionChanged(object sender, EventArgs e)
        {
            if (grvBangChonNhanh.SelectedRows.Count > 0)
            {
                lblDonViTinh.Text = grvBangChonNhanh.SelectedRows[0].Cells["colQuickView_DonViTinh"].Value.ToString();
            }
        }

        private void dgvCTPhieuNhap_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridViewComboBoxCell)dgvCTPhieuNhap.Rows[e.RowIndex].Cells["colMaNguyenLieu"]).DataSource = NguyenLieuBUS.LayDanhSachNguyenLieu();
            ((DataGridViewComboBoxCell)dgvCTPhieuNhap.Rows[e.RowIndex].Cells["colMaNguyenLieu"]).DisplayMember = "TenNguyenLieu";
            ((DataGridViewComboBoxCell)dgvCTPhieuNhap.Rows[e.RowIndex].Cells["colMaNguyenLieu"]).ValueMember = "MaNguyenLieu";

            lblTongTien.Text = TinhTongTien().ToString("#,##0đ");
            btnNhapHang.Enabled = true;
        }

        private void dgvCTPhieuNhap_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgvCTPhieuNhap.Rows.Count > 0)
            {
                lblTongTien.Text = TinhTongTien().ToString("#,##0đ");
            }
            else
            {
                lblTongTien.Text = "0đ";
                LamMoi();
                btnNhapHang.Enabled = false;
            }
        }

        private void dgvCTPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCTPhieuNhap.SelectedRows.Count > 0)
            {
                LamMoi(false);
                string donGia = dgvCTPhieuNhap.SelectedRows[0].Cells["colDonGia"].Value.ToString();
                cmbNguyenLieu.SelectedValue = dgvCTPhieuNhap.SelectedRows[0].Cells["colMaNguyenLieu"].Value;
                txtSoLuong.Text = dgvCTPhieuNhap.SelectedRows[0].Cells["colSoLuong"].Value.ToString();
                txtDonGia.Text = donGia.Remove(donGia.Length - 1);
                txtGhiChu.Text = dgvCTPhieuNhap.SelectedRows[0].Cells["colGhiChu"].Value.ToString();
            }
        }

        private void dgvCTPhieuNhap_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCTPhieuNhap.SelectedRows.Count > 0)
            {
                string donGia = dgvCTPhieuNhap.SelectedRows[0].Cells["colDonGia"].Value.ToString();
                cmbNguyenLieu.SelectedValue = dgvCTPhieuNhap.SelectedRows[0].Cells["colMaNguyenLieu"].Value;
                txtSoLuong.Text = dgvCTPhieuNhap.SelectedRows[0].Cells["colSoLuong"].Value.ToString();
                txtDonGia.Text = donGia.Remove(donGia.Length - 1);
            }
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            PhieuNhapDTO phieuNhap = new PhieuNhapDTO();
            phieuNhap.NhaCungCap = (int)cmbNhaCungCap.SelectedValue;
            phieuNhap.NgayLap = DateTime.Now;
            phieuNhap.TongTien = Convert.ToDouble(lblTongTien.Text.Remove(lblTongTien.Text.Length - 1));
            phieuNhap.TrangThai = true;

            List<CTPhieuNhapDTO> lsCTPhieuNhap = new List<CTPhieuNhapDTO>();
            foreach (DataGridViewRow row in dgvCTPhieuNhap.Rows)
            {
                string donGia = row.Cells["colDonGia"].Value.ToString();

                CTPhieuNhapDTO ctPhieuNhap = new CTPhieuNhapDTO();
                ctPhieuNhap.MaPhieuNhap = Convert.ToInt32(lblMaPhieu.Text);
                ctPhieuNhap.MaNguyenLieu = Convert.ToInt32(row.Cells["colMaNguyenLieu"].Value);
                ctPhieuNhap.SoLuong = Convert.ToDouble(row.Cells["colSoLuong"].Value);
                ctPhieuNhap.DonViTinh = row.Cells["colDonViTinh"].Value.ToString();
                ctPhieuNhap.DonGia = Convert.ToDouble(donGia.Remove(donGia.Length - 1));
                if (row.Cells["colGhiChu"].Value != null)
                {
                    ctPhieuNhap.GhiChu = row.Cells["colGhiChu"].Value.ToString();
                }
                else
                {
                    ctPhieuNhap.GhiChu = string.Empty;
                }

                lsCTPhieuNhap.Add(ctPhieuNhap);
            }

            if (PhieuNhapBUS.LuuPhieuNhap(phieuNhap, lsCTPhieuNhap))
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn in phiếu nhập?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    FrmHienThiBaoCao frm = new FrmHienThiBaoCao();
                    frm.HienThiPhieuNhapMoiNhat();
                    FrmMain.Instance.TopMost = false;
                    frm.Show();
                }
                LamMoi();
                dgvCTPhieuNhap.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Lưu phiếu nhập thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemNguyenLieu_Click(object sender, EventArgs e)
        {
            bool allowAccess = false;
            List<ChucNang_LoaiTaiKhoanDTO> lsChucNang = ChucNang_LoaiTaiKhoanBUS.LayDanhSachChucNang_LoaiTaiKhoanTheoMaTaiKhoan(TaiKhoanBUS.LayTaiKhoanDangNhap());
            foreach(ChucNang_LoaiTaiKhoanDTO chucNang in lsChucNang)
            {
                if (chucNang.MaChucNang == 3)
                {
                    FrmQuanLyKho frmQuanLyKho = FrmQuanLyKho.Instance;
                    frmQuanLyKho.Resizable = true;
                    frmQuanLyKho.Movable = true;
                    frmQuanLyKho.ControlBox = true;
                    frmQuanLyKho.MaximizeBox = true;
                    frmQuanLyKho.Size = new Size(1250, 650);
                    frmQuanLyKho.FormClosed += FrmQuanLyKho_FormClosed;

                    ((FrmMain)this.ParentForm).TopMost = false;
                    frmQuanLyKho.ShowDialog();

                    return;
                }
            }
            if (!allowAccess)
            {
                MessageBox.Show("Bạn không có quyền truy cập mục này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnThemNhaCungCap_Click(object sender, EventArgs e)
        {
            FrmNhaCungCap frmNhaCungCap = FrmNhaCungCap.Instance;
            frmNhaCungCap.MinimizeBox = false;
            frmNhaCungCap.FormClosed += FrmNhaCungCap_FormClosed;

            ((FrmMain)this.ParentForm).TopMost = false;
            frmNhaCungCap.ShowDialog();
        }

        private void FrmNhaCungCap_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((FrmMain)this.ParentForm).TopMost = FrmMain.topMost;
            LoadNhaCungCap();
        }

        private void FrmQuanLyKho_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((FrmMain)this.ParentForm).TopMost = FrmMain.topMost;
            List<NguyenLieuDTO> lsNguyenLieu = NguyenLieuBUS.LayDanhSachNguyenLieu();
            LoadBangChonNhanh(lsNguyenLieu);
            LoadDanhSachNguyenLieu(lsNguyenLieu);

            if (cmbNguyenLieu.Items.Count > 0)
            {
                btnThem.Enabled = true;
            }
            else
            {
                btnThem.Enabled = false;
            }
        }
    }
}
