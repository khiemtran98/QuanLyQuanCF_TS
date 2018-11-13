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

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            ((FrmMain)this.ParentForm).XuLyFormMain();
            this.Close();
        }

        private void FrmQuanLyKho_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void FrmQuanLyKho_Load(object sender, EventArgs e)
        {
            tbcQuanLyKho.SelectedTab = tbpNguyenLieu;

            //Load du lieu cho dgvNguyenLieu
            dgvNguyenLieu.AutoGenerateColumns = false;
            QLK_LoadDanhSachNguyenLieu();
        }

        private void QLK_LoadDanhSachNguyenLieu(string timKiem="")
        {
            List<NguyenLieuDTO> lsNL = NguyenLieuBUS.LoadDanhSachNguyenLieu(timKiem);
            dgvNguyenLieu.DataSource = lsNL;
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDonViTinh_KeyPress(object sender, KeyPressEventArgs e)
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
                chkQLNL_TrangThai.Checked = Convert.ToBoolean(dgvNguyenLieu.SelectedRows[0].Cells["colNL_TrangThai"].Value);
            }
        }
        private void LamMoiNguyenLieu(bool state = true)
        {
            txtMaNguyenLieu.Text = txtTenNguyenLieu.Text = txtSoLuong.Text = txtDonViTinh.Text = string.Empty;
            chkQLNL_TrangThai.Checked = false;
            btnThemNguyenLieu.Enabled = state;
            btnXoaNguyenLieu.Enabled = !state;
            btnSuaNguyenLieu.Enabled = !state;
        }

        private void btnThemNguyenLieu_Click(object sender, EventArgs e)
        {
            NguyenLieuDTO nl = new NguyenLieuDTO();
            nl.TenNguyenLieu = txtTenNguyenLieu.Text;
            if (txtSoLuong.Text != "")
            {
                nl.SoLuong = Convert.ToInt32(txtSoLuong.Text);
            }
            else
            {
                nl.SoLuong = 0;
            }
            nl.DonViTinh = txtDonViTinh.Text;
            nl.TrangThai = chkQLNL_TrangThai.Checked;
            if (NguyenLieuBUS.ThemNguyenLieu(nl))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiNguyenLieu();
                QLK_LoadDanhSachNguyenLieu();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nl = null;
            }
        }

        private void btnXoaNguyenLieu_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn xoá món này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (NguyenLieuBUS.XoaNguyenLieu(Convert.ToInt32(txtMaNguyenLieu.Text)))
                {
                    MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiNguyenLieu();
                    QLK_LoadDanhSachNguyenLieu();
                }
                else
                {
                    MessageBox.Show("Xoá thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaNguyenLieu_Click(object sender, EventArgs e)
        {
            NguyenLieuDTO nl = new NguyenLieuDTO();
            nl.MaNguyenLieu = Convert.ToInt32(txtMaNguyenLieu.Text);
            nl.TenNguyenLieu = txtTenNguyenLieu.Text;
            if (txtSoLuong.Text != "")
            {
                nl.SoLuong = Convert.ToInt32(txtSoLuong.Text);
            }
            else
            {
                nl.SoLuong = 0;
            }
            nl.DonViTinh = txtDonViTinh.Text;
            nl.TrangThai = chkQLNL_TrangThai.Checked;
            if (NguyenLieuBUS.SuaNguyenLieu(nl))
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiNguyenLieu();
                QLK_LoadDanhSachNguyenLieu();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nl = null;
            }
        }

        private void btnLamMoiNguyenLieu_Click(object sender, EventArgs e)
        {
            LamMoiNguyenLieu();
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
            QLK_LoadDanhSachNguyenLieu(txtTimKiemNguyenLieu.Text);
        }

        private void btnTimKiemCuaNguyenLieu_Click(object sender, EventArgs e)
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
    }
}
