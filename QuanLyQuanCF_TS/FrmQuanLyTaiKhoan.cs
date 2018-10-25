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
            dgvTaiKhoan.AutoGenerateColumns = false;

            LoadDanhSachTaiKhoan();
            LoadLoaiTaiKhoan();
        }

        private void LoadDanhSachTaiKhoan(string timKiem = "")
        {
            List<TaiKhoanDTO> lsTaiKhoan = TaiKhoanBUS.LayDanhSachTaiKhoan(timKiem);
            dgvTaiKhoan.DataSource = lsTaiKhoan;
        }

        private void LoadLoaiTaiKhoan()
        {
            List<LoaiTaiKhoanDTO> lsLoaiTaiKhoan = LoaiTaiKhoanBUS.LayDanhSachLoaiTaiKhoan();
            cmbLoaiTaiKhoan.DataSource = lsLoaiTaiKhoan;
            cmbLoaiTaiKhoan.DisplayMember = "TenLoaiTaiKhoan";
            cmbLoaiTaiKhoan.ValueMember = "MaLoaiTaiKhoan";
        }

        private void dgvQuanLyTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTaiKhoan.SelectedRows.Count > 0)
            {
                txtMaTaiKhoan.Text = dgvTaiKhoan.SelectedRows[0].Cells["colMaTaiKhoan"].Value.ToString();
                txtHoTen.Text = dgvTaiKhoan.SelectedRows[0].Cells["colHoTen"].Value.ToString();
                dtpNgayBatDau.Value = Convert.ToDateTime(dgvTaiKhoan.SelectedRows[0].Cells["colNgayBatDau"].Value);
                cmbLoaiTaiKhoan.SelectedValue = Convert.ToInt32(dgvTaiKhoan.SelectedRows[0].Cells["colLoaiTaiKhoan"].Value);
                try
                {
                    picHinh.ImageLocation = "" + dgvTaiKhoan.SelectedRows[0].Cells["colHinh"].Value.ToString();
                }
                catch
                {
                    
                }
                chkTrangThai.Checked = Convert.ToBoolean(dgvTaiKhoan.SelectedRows[0].Cells["colTrangThai"].Value);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO taiKhoan = new TaiKhoanDTO();
            taiKhoan.HoTen = txtHoTen.Text;
            taiKhoan.MatKhau = txtMatKhau.Text;
            taiKhoan.NgayBatDau = DateTime.Now;
            taiKhoan.LoaiTaiKhoan = Convert.ToInt32(cmbLoaiTaiKhoan.SelectedValue);
            taiKhoan.TrangThai = chkTrangThai.Checked;

            if (TaiKhoanBUS.ThemTaiKhoan(taiKhoan))
            {
                MessageBox.Show("Thêm thành công!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
                LoadDanhSachTaiKhoan();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                taiKhoan = null;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(TaiKhoanBUS.XoaTaiKhoan(Convert.ToInt32(txtMaTaiKhoan.Text)))
            {
                MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
                LoadDanhSachTaiKhoan();
            }
            else
            {
                MessageBox.Show("Xoá thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO taiKhoan = new TaiKhoanDTO();
            taiKhoan.MaTaiKhoan = Convert.ToInt32(txtMaTaiKhoan.Text);
            taiKhoan.HoTen = txtHoTen.Text;
            taiKhoan.MatKhau = txtMatKhau.Text;
            taiKhoan.NgayBatDau = DateTime.Now;
            taiKhoan.LoaiTaiKhoan = Convert.ToInt32(cmbLoaiTaiKhoan.SelectedValue);
            taiKhoan.TrangThai = chkTrangThai.Checked;

            if (TaiKhoanBUS.SuaTaiKhoan(taiKhoan))
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
                LoadDanhSachTaiKhoan();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                taiKhoan = null;
            }
        }

        private void LamMoi()
        {
            txtMaTaiKhoan.Text = txtHoTen.Text = txtMatKhau.Text = string.Empty;
            dtpNgayBatDau.Value = DateTime.Now;
            chkTrangThai.Checked = false;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void TimKiem()
        {
            LoadDanhSachTaiKhoan(txtTimKiem.Text);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TimKiem();
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            ((FrmMain)this.ParentForm).XuLyFormMain();
            this.Close();
        }

        private void FrmQuanLyTaiKhoan_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }
    }
}
