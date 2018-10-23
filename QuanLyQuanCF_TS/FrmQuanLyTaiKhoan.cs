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
    public partial class FrmQuanLyTaiKhoan : MetroFramework.Forms.MetroForm
    {
        public FrmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private static FrmQuanLyTaiKhoan _Instance = null;

        public static FrmQuanLyTaiKhoan Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FrmQuanLyTaiKhoan();
                }
                return _Instance;
            }
        }

        private void FrmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            dgvQuanLyTaiKhoan.AutoGenerateColumns = false;

            LoadDanhSachNhanVien();
        }

        private void LoadDanhSachNhanVien()
        {
            List<NhanVienDTO> lstNV = NhanVienBUS.LayDanhSachNhanVien();
            dgvQuanLyTaiKhoan.DataSource = lstNV;
        }

        private void dgvQuanLyTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvQuanLyTaiKhoan.SelectedRows.Count > 0)
            {
                txtMaNhanVien.Text = dgvQuanLyTaiKhoan.SelectedRows[0].Cells["colMaNhanVien"].Value.ToString();
                txtHoTen.Text = dgvQuanLyTaiKhoan.SelectedRows[0].Cells["colHoTen"].Value.ToString();
                dtpNgayBatDau.Value = Convert.ToDateTime(dgvQuanLyTaiKhoan.SelectedRows[0].Cells["colNgayBatDau"].Value);
                chkLaAdmin.Checked = Convert.ToBoolean(dgvQuanLyTaiKhoan.SelectedRows[0].Cells["colLaAdmin"].Value);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanVienDTO nhanVien = new NhanVienDTO();
            nhanVien.HoTen = txtHoTen.Text;
            nhanVien.MatKhau = txtMatKhau.Text;
            nhanVien.NgayBatDau = DateTime.Now;
            nhanVien.LaAdmin = chkLaAdmin.Checked;

            if (NhanVienBUS.ThemNhanVien(nhanVien))
            {
                MessageBox.Show("Thêm thành công!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
                LoadDanhSachNhanVien();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nhanVien = null;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(NhanVienBUS.XoaNhanVien(Convert.ToInt32(txtMaNhanVien.Text)))
            {
                MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
                LoadDanhSachNhanVien();
            }
            else
            {
                MessageBox.Show("Xoá thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            NhanVienDTO nhanVien = new NhanVienDTO();
            nhanVien.MaNhanVien = Convert.ToInt32(txtMaNhanVien.Text);
            nhanVien.HoTen = txtHoTen.Text;
            nhanVien.MatKhau = txtMatKhau.Text;
            nhanVien.NgayBatDau = DateTime.Now;
            nhanVien.LaAdmin = chkLaAdmin.Checked;

            if (NhanVienBUS.SuaThongTinNhanVien(nhanVien))
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
                LoadDanhSachNhanVien();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nhanVien = null;
            }
        }

        private void LamMoi()
        {
            txtMaNhanVien.Text = txtHoTen.Text = txtMatKhau.Text = string.Empty;
            dtpNgayBatDau.Value = DateTime.Now;
            chkLaAdmin.Checked = false;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn quay lại màn hình chính?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                ((FrmMain)this.ParentForm).XuLyFormMain();
                this.Close();
            }
        }

        private void FrmQuanLyTaiKhoan_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }
    }
}
