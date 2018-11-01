using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
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

            QLLTK_LoadDanhSachLoaiTaiKhoan();

            QLTK_LoadDanhSachTaiKhoan();
            QLTK_LoadLoaiTaiKhoan();

            LamMoiLoaiTaiKhoan();
            LamMoiTaiKhoan();

            tbcQuanLyTaiKhoan.SelectedTab = tbpLoaiTaiKhoan;
        }

        private void tbcQuanLyTaiKhoan_Selecting(object sender, TabControlCancelEventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;

            if (current.Name == "tbpTaiKhoan")
            {
                QLTK_LoadLoaiTaiKhoan();
                QLTK_LoadDanhSachTaiKhoan();
            }
        }

        // Bắt đầu khu vực chức năng Quản lý tài khoản

        private void QLLTK_LoadDanhSachLoaiTaiKhoan(string timKiem = "")
        {
            List<LoaiTaiKhoanDTO> lsLoaiTaiKhoan = LoaiTaiKhoanBUS.LayDanhSachLoaiTaiKhoan(timKiem);
            dgvLoaiTaiKhoan.DataSource = lsLoaiTaiKhoan;
        }

        private void dgvLoaiTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLoaiTaiKhoan.SelectedRows.Count > 0)
            {
                LamMoiLoaiTaiKhoan(false);
                txtMaLoaiTaiKhoan.Text = dgvLoaiTaiKhoan.SelectedRows[0].Cells["colMaLoaiTaiKhoan"].Value.ToString();
                txtTenLoaiTaiKhoan.Text = dgvLoaiTaiKhoan.SelectedRows[0].Cells["colTenLoaiTaiKhoan"].Value.ToString();
                chkQLLTK_TrangThai.Checked = Convert.ToBoolean(dgvLoaiTaiKhoan.SelectedRows[0].Cells["colQLLTK_TrangThai"].Value);
            }
        }

        private void LamMoiLoaiTaiKhoan(bool state = true)
        {
            txtMaLoaiTaiKhoan.Text = txtTenLoaiTaiKhoan.Text = string.Empty;
            chkQLLTK_TrangThai.Checked = false;
            btnThemLoaiTaiKhoan.Enabled = state;
            btnXoaLoaiTaiKhoan.Enabled = !state;
            btnSuaLoaiTaiKhoan.Enabled = !state;
        }

        private void btnThemLoaiTaiKhoan_Click(object sender, EventArgs e)
        {
            LoaiTaiKhoanDTO loaiTaiKhoan = new LoaiTaiKhoanDTO();
            loaiTaiKhoan.TenLoaiTaiKhoan = txtTenLoaiTaiKhoan.Text;
            loaiTaiKhoan.TrangThai = chkQLLTK_TrangThai.Checked;

            if (LoaiTaiKhoanBUS.ThemLoaiTaiKhoan(loaiTaiKhoan))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiLoaiTaiKhoan();
                QLLTK_LoadDanhSachLoaiTaiKhoan();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loaiTaiKhoan = null;
            }
        }

        private void btnXoaLoaiTaiKhoan_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Xoá loại tài khoản sẽ đồng thời xoá tất cả tài khoản thuộc loại tài khoản đó. Nếu muốn tạm thời ẩn loại tài khoản này hãy thay đổi trạng thái hoạt động.\n\nBạn có chắc chắn muốn xoá loại tài khoản này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (LoaiTaiKhoanBUS.XoaLoaiTaiKhoan(Convert.ToInt32(txtMaLoaiTaiKhoan.Text)))
                {
                    MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiLoaiTaiKhoan();
                    QLLTK_LoadDanhSachLoaiTaiKhoan();
                }
                else
                {
                    MessageBox.Show("Xoá thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaLoaiTaiKhoan_Click(object sender, EventArgs e)
        {
            LoaiTaiKhoanDTO loaiTaiKhoan = new LoaiTaiKhoanDTO();
            loaiTaiKhoan.MaLoaiTaiKhoan = Convert.ToInt32(txtMaLoaiTaiKhoan.Text);
            loaiTaiKhoan.TenLoaiTaiKhoan = txtTenLoaiTaiKhoan.Text;
            loaiTaiKhoan.TrangThai = chkQLLTK_TrangThai.Checked;

            if (LoaiTaiKhoanBUS.SuaLoaiTaiKhoan(loaiTaiKhoan))
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiLoaiTaiKhoan();
                QLLTK_LoadDanhSachLoaiTaiKhoan();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loaiTaiKhoan = null;
            }
        }

        private void btnLamMoiLoaiTaiKhoan_Click(object sender, EventArgs e)
        {
            LamMoiLoaiTaiKhoan();
        }

        private void btnTimKiemLoaiTaiKhoan_Click(object sender, EventArgs e)
        {
            TimKiemLoaiTaiKhoan();
        }

        private void txtTimKiemLoaiTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TimKiemLoaiTaiKhoan();
            }
        }

        private void TimKiemLoaiTaiKhoan()
        {
            QLLTK_LoadDanhSachLoaiTaiKhoan(txtTimKiemLoaiTaiKhoan.Text);
        }

        private void txtTimKiemLoaiTaiKhoan_Enter(object sender, EventArgs e)
        {
            if (txtTimKiemLoaiTaiKhoan.Text == "Tìm kiếm tên loại tài khoản")
            {
                txtTimKiemLoaiTaiKhoan.Text = string.Empty;
            }
        }

        private void txtTimKiemLoaiTaiKhoan_Leave(object sender, EventArgs e)
        {
            if (txtTimKiemLoaiTaiKhoan.Text == string.Empty)
            {
                txtTimKiemLoaiTaiKhoan.Text = "Tìm kiếm tên loại tài khoản";
            }
        }

        // Kết thúc Khu vực chức năng Quản lý loại tài khoản

        // ----------------------------------------------

        // Bắt đầu khu vực chức năng Quản lý tài khoản

        private void QLTK_LoadDanhSachTaiKhoan(string timKiem = "")
        {
            List<TaiKhoanDTO> lsTaiKhoan = TaiKhoanBUS.LayDanhSachTaiKhoan(timKiem);
            dgvTaiKhoan.DataSource = lsTaiKhoan;
        }

        private void QLTK_LoadLoaiTaiKhoan()
        {
            List<LoaiTaiKhoanDTO> lsLoaiTaiKhoan = LoaiTaiKhoanBUS.LayDanhSachLoaiTaiKhoan();
            cmbLoaiTaiKhoan.DataSource = lsLoaiTaiKhoan;
            cmbLoaiTaiKhoan.DisplayMember = "TenLoaiTaiKhoan";
            cmbLoaiTaiKhoan.ValueMember = "MaLoaiTaiKhoan";
        }

        private void dgvTaiKhoan_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridViewComboBoxCell)dgvTaiKhoan.Rows[e.RowIndex].Cells["colLoaiTaiKhoan"]).DataSource = LoaiTaiKhoanBUS.LayDanhSachLoaiTaiKhoan();
            ((DataGridViewComboBoxCell)dgvTaiKhoan.Rows[e.RowIndex].Cells["colLoaiTaiKhoan"]).DisplayMember = "TenLoaiTaiKhoan";
            ((DataGridViewComboBoxCell)dgvTaiKhoan.Rows[e.RowIndex].Cells["colLoaiTaiKhoan"]).ValueMember = "MaLoaiTaiKhoan";
        }

        private void picHinh_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            picHinh.ImageLocation = openFileDialog1.FileName;
        }

        private void dgvTaiKhoan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTaiKhoan.Columns[e.ColumnIndex].Name == "colHinh")
            {
                e.Value = new Bitmap("img\\accounts\\" + e.Value.ToString());
            }
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTaiKhoan.SelectedRows.Count > 0)
            {
                LamMoiTaiKhoan(false);
                txtMaTaiKhoan.Text = dgvTaiKhoan.SelectedRows[0].Cells["colMaTaiKhoan"].Value.ToString();
                txtHoTen.Text = dgvTaiKhoan.SelectedRows[0].Cells["colHoTen"].Value.ToString();
                dtpNgayBatDau.Value = Convert.ToDateTime(dgvTaiKhoan.SelectedRows[0].Cells["colNgayBatDau"].Value);
                cmbLoaiTaiKhoan.SelectedValue = Convert.ToInt32(dgvTaiKhoan.SelectedRows[0].Cells["colLoaiTaiKhoan"].Value);
                picHinh.Image = (Bitmap)dgvTaiKhoan.SelectedRows[0].Cells["colHinh"].FormattedValue;
                chkQLTK_TrangThai.Checked = Convert.ToBoolean(dgvTaiKhoan.SelectedRows[0].Cells["colQLTK_TrangThai"].Value);
            }
        }

        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO taiKhoan = new TaiKhoanDTO();
            taiKhoan.HoTen = txtHoTen.Text;
            taiKhoan.MatKhau = txtMatKhau.Text;
            taiKhoan.NgayBatDau = dtpNgayBatDau.Value;
            taiKhoan.LoaiTaiKhoan = Convert.ToInt32(cmbLoaiTaiKhoan.SelectedValue);
            if (openFileDialog1.FileName != "")
            {
                string tenFile = DateTime.Now.ToFileTime() + "_" + (TaiKhoanBUS.LayMaTaiKhoanMoiNhat() + 1).ToString();
                string extension = Path.GetExtension(openFileDialog1.SafeFileName);
                taiKhoan.Hinh = tenFile + extension;
                File.Copy(openFileDialog1.FileName, "img\\accounts\\" + tenFile + extension, true);
            }
            taiKhoan.TrangThai = chkQLTK_TrangThai.Checked;

            if (TaiKhoanBUS.ThemTaiKhoan(taiKhoan))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiTaiKhoan();
                QLTK_LoadDanhSachTaiKhoan();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                taiKhoan = null;
            }
        }

        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn xoá tài khoản này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (TaiKhoanBUS.XoaTaiKhoan(Convert.ToInt32(txtMaTaiKhoan.Text)))
                {
                    MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiTaiKhoan();
                    QLTK_LoadDanhSachTaiKhoan();
                }
                else
                {
                    MessageBox.Show("Xoá thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaTaiKhoan_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO taiKhoan = new TaiKhoanDTO();
            taiKhoan.MaTaiKhoan = Convert.ToInt32(txtMaTaiKhoan.Text);
            taiKhoan.HoTen = txtHoTen.Text;
            taiKhoan.MatKhau = txtMatKhau.Text;
            taiKhoan.NgayBatDau = dtpNgayBatDau.Value;
            taiKhoan.LoaiTaiKhoan = Convert.ToInt32(cmbLoaiTaiKhoan.SelectedValue);
            if (openFileDialog1.FileName != "")
            {
                string tenFile = DateTime.Now.ToFileTime() + "_" + taiKhoan.MaTaiKhoan;
                string extension = Path.GetExtension(openFileDialog1.SafeFileName);
                taiKhoan.Hinh = tenFile + extension;
                File.Copy(openFileDialog1.FileName, "img\\accounts\\" + tenFile + extension);
            }
            else
            {
                if (picHinh.Image != Properties.Resources.user_account)
                {
                    taiKhoan.Hinh = dgvTaiKhoan.CurrentRow.Cells["colHinh"].Value.ToString();
                }
            }
            taiKhoan.TrangThai = chkQLTK_TrangThai.Checked;

            if (TaiKhoanBUS.SuaTaiKhoan(taiKhoan))
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiTaiKhoan();
                QLTK_LoadDanhSachTaiKhoan();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                taiKhoan = null;
            }
        }
        
        private void LamMoiTaiKhoan(bool state = true)
        {
            txtMaTaiKhoan.Text = txtHoTen.Text = txtMatKhau.Text = string.Empty;
            dtpNgayBatDau.Value = DateTime.Now;
            cmbLoaiTaiKhoan.SelectedIndex = 0;
            chkQLTK_TrangThai.Checked = false;
            picHinh.Image = Properties.Resources.default_account;
            btnThemTaiKhoan.Enabled = state;
            btnXoaTaiKhoan.Enabled = !state;
            btnSuaTaiKhoan.Enabled = !state;
            openFileDialog1.FileName = "";
        }

        private void btnLamMoiTaiKhoan_Click(object sender, EventArgs e)
        {
            LamMoiTaiKhoan();
        }

        private void btnTimKiemTaiKhoan_Click(object sender, EventArgs e)
        {
            TimKiemTaiKhoan();
        }

        private void txtTimKiemTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TimKiemTaiKhoan();
            }
        }

        private void TimKiemTaiKhoan()
        {
            QLTK_LoadDanhSachTaiKhoan(txtTimKiemTaiKhoan.Text);
        }   

        private void txtTimKiemTaiKhoan_Enter(object sender, EventArgs e)
        {
            if (txtTimKiemTaiKhoan.Text == "Tìm kiếm tên tài khoản")
            {
                txtTimKiemTaiKhoan.Text = string.Empty;
            }
        }

        private void txtTimKiemTaiKhoan_Leave(object sender, EventArgs e)
        {
            if (txtTimKiemTaiKhoan.Text == string.Empty)
            {
                txtTimKiemTaiKhoan.Text = "Tìm kiếm tên tài khoản";
            }
        }

        // Kết thúc Khu vực chức năng Quản lý tài khoản

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
