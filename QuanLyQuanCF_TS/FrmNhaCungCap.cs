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
    public partial class FrmNhaCungCap : MetroFramework.Forms.MetroForm
    {
        public FrmNhaCungCap()
        {
            InitializeComponent();

            #region
            this.Style = FrmMain.style;
            txtMaNhaCungCap.Style = FrmMain.style;
            txtTenNhaCungCap.Style = FrmMain.style;
            btnThem.Style = FrmMain.style;
            btnXoa.Style = FrmMain.style;
            btnSua.Style = FrmMain.style;
            btnLamMoi.Style = FrmMain.style;
            lnkDSNhaCungCap.Style = FrmMain.style;
            #endregion
        }

        private static FrmNhaCungCap _Instance = null;

        public static FrmNhaCungCap Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FrmNhaCungCap();
                }
                return _Instance;
            }
        }

        private void FrmNhaCungCap_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void FrmNhaCungCap_Load(object sender, EventArgs e)
        {
            dgvNhaCungCap.AutoGenerateColumns = false;

            LoadDanhSachNhaCungCap();
            LamMoiNhaCungCap();
        }

        private void LoadDanhSachNhaCungCap(string timKiem = "")
        {
            List<NhaCungCapDTO> lsNhaCungCap = NhaCungCapBUS.LayDanhSachNhaCungCap(timKiem);
            dgvNhaCungCap.DataSource = lsNhaCungCap;
        }

        private void LoadDanhSachNhaCungCapDaXoa(string timKiem = "")
        {
            List<NhaCungCapDTO> lsNhaCungCap = NhaCungCapBUS.LayDanhSachNhaCungCap(timKiem, false);
            dgvNhaCungCap.DataSource = lsNhaCungCap;
        }

        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNhaCungCap.SelectedRows.Count > 0)
            {
                LamMoiNhaCungCap(false);
                txtMaNhaCungCap.Text = dgvNhaCungCap.SelectedRows[0].Cells["colMaNhaCungCap"].Value.ToString();
                txtTenNhaCungCap.Text = dgvNhaCungCap.SelectedRows[0].Cells["colTenNhaCungCap"].Value.ToString();
            }
        }

        private void LamMoiNhaCungCap(bool state = true)
        {
            txtMaNhaCungCap.Text = txtTenNhaCungCap.Text = string.Empty;
            btnThem.Enabled = state;
            btnXoa.Enabled = btnSua.Enabled = btnLamMoi.Enabled = btnKhoiPhuc.Enabled = !state;
        }

        private void lnkDSNhaCungCap_Click(object sender, EventArgs e)
        {
            if (lnkDSNhaCungCap.AccessibleName == "DSNhaCungCap")
            {
                lnkDSNhaCungCap.Text = "Hiện danh sách nhà cung cấp đang có";
                LoadDanhSachNhaCungCapDaXoa();
                lnkDSNhaCungCap.AccessibleName = "DSNhaCungCapDaXoa";
                panelDSChucNangNhaCungCapDaXoa.Visible = true;
                LamMoiNhaCungCap();
                txtTenNhaCungCap.Enabled = false;
            }
            else
            {
                lnkDSNhaCungCap.Text = "Hiện danh sách nhà cung cấp đã xoá";
                LoadDanhSachNhaCungCap();
                lnkDSNhaCungCap.AccessibleName = "DSNhaCungCap";
                panelDSChucNangNhaCungCapDaXoa.Visible = false;
                LamMoiNhaCungCap();
                txtTenNhaCungCap.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhaCungCapDTO nhaCungCap = new NhaCungCapDTO();
            nhaCungCap.TenNhaCungCap = txtTenNhaCungCap.Text;
            nhaCungCap.TrangThai = true;

            if (NhaCungCapBUS.ThemNhaCungCap(nhaCungCap))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiNhaCungCap();
                LoadDanhSachNhaCungCap();
                dgvNhaCungCap.ClearSelection();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nhaCungCap = null;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn xoá nhà cung cấp này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (NhaCungCapBUS.XoaNhaCungCap(Convert.ToInt32(txtMaNhaCungCap.Text)))
                {
                    MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiNhaCungCap();
                    LoadDanhSachNhaCungCap();
                    dgvNhaCungCap.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Xoá thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NhaCungCapDTO nhaCungCap = new NhaCungCapDTO();
            nhaCungCap.MaNhaCungCap = Convert.ToInt32(txtMaNhaCungCap.Text);
            nhaCungCap.TenNhaCungCap = txtTenNhaCungCap.Text;
            nhaCungCap.TrangThai = true;

            if (NhaCungCapBUS.SuaNhaCungCap(nhaCungCap))
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiNhaCungCap();
                LoadDanhSachNhaCungCap();
                dgvNhaCungCap.ClearSelection();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nhaCungCap = null;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiNhaCungCap();
        }

        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            if (NhaCungCapBUS.KhoiPhucNhaCungCap(Convert.ToInt32(txtMaNhaCungCap.Text)))
            {
                MessageBox.Show("Khôi phục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiNhaCungCap();
                LoadDanhSachNhaCungCapDaXoa();
                dgvNhaCungCap.ClearSelection();
            }
            else
            {
                MessageBox.Show("Khôi phục thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
