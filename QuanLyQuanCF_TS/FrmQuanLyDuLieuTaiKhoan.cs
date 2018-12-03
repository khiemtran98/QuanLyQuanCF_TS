using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using System.IO;
using DTO;
using BUS;
using System.Security.Cryptography;
using MetroFramework;

namespace QuanLyQuanCF_TS
{
    public partial class FrmQuanLyDuLieuTaiKhoan : MetroFramework.Forms.MetroForm
    {
        public FrmQuanLyDuLieuTaiKhoan()
        {
            InitializeComponent();

            #region
            this.Style = FrmMain.style;
            tbcQuanLyTaiKhoan.Style = FrmMain.style;
            txtTimKiemLoaiTaiKhoan.Style = FrmMain.style;
            btnTimKiemLoaiTaiKhoan.Style = FrmMain.style;
            lnkDSLoaiTaiKhoan.Style = FrmMain.style;
            txtMaLoaiTaiKhoan.Style = FrmMain.style;
            txtTenLoaiTaiKhoan.Style = FrmMain.style;
            chkQuanLyTaiKhoan.Style = FrmMain.style;
            chkQuanLyMon.Style = FrmMain.style;
            chkQuanLyKho.Style = FrmMain.style;
            chkThongKeHoaDon.Style = FrmMain.style;
            chkThongKeNhapHang.Style = FrmMain.style;
            chkThongKeDoanhThu.Style = FrmMain.style;
            chkNhapHang.Style = FrmMain.style;
            chkBanHang.Style = FrmMain.style;
            chkBaoCao.Style = FrmMain.style;
            chkCaiDat.Style = FrmMain.style;
            btnThemLoaiTaiKhoan.Style = FrmMain.style;
            btnXoaLoaiTaiKhoan.Style = FrmMain.style;
            btnSuaLoaiTaiKhoan.Style = FrmMain.style;
            btnKhoiPhucLoaiTaiKhoan.Style = FrmMain.style;
            
            txtTimKiemTaiKhoan.Style = FrmMain.style;
            btnTimKiemTaiKhoan.Style = FrmMain.style;
            lnkDSTaiKhoan.Style = FrmMain.style;
            txtMaTaiKhoan.Style = FrmMain.style;
            txtHoTen.Style = FrmMain.style;
            txtMatKhau.Style = FrmMain.style;
            dtpNgayBatDau.Style = FrmMain.style;
            cmbLoaiTaiKhoan.Style = FrmMain.style;
            btnThemTaiKhoan.Style = FrmMain.style;
            btnXoaTaiKhoan.Style = FrmMain.style;
            btnSuaTaiKhoan.Style = FrmMain.style;
            btnKhoiPhucTaiKhoan.Style = FrmMain.style;
            #endregion

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, picHinh.Width - 3, picHinh.Height - 3);
            Region rg = new Region(gp);
            picHinh.Region = rg;
            picHinh.BackColor = Color.WhiteSmoke;
        }

        private static FrmQuanLyDuLieuTaiKhoan _Instance = null;

        public static FrmQuanLyDuLieuTaiKhoan Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FrmQuanLyDuLieuTaiKhoan();
                }
                return _Instance;
            }
        }

        private void FrmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            dgvLoaiTaiKhoan.AutoGenerateColumns = false;
            dgvTaiKhoan.AutoGenerateColumns = false;

            QLLTK_LoadDanhSachLoaiTaiKhoan();

            //QLTK_LoadDanhSachTaiKhoan();
            //QLTK_LoadLoaiTaiKhoan();

            LamMoiLoaiTaiKhoan();
            LamMoiTaiKhoan();

            //tbcQuanLyTaiKhoan.SelectedTab = tbpLoaiTaiKhoan;
        }

        private void tbcQuanLyTaiKhoan_Selecting(object sender, TabControlCancelEventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;

            if (current.Name == "tbpLoaiTaiKhoan")
            {
                if (lnkDSLoaiTaiKhoan.AccessibleName == "DSLoaiTaiKhoan")
                {
                    QLLTK_LoadDanhSachLoaiTaiKhoan();
                }
                else
                {
                    QLLTK_LoadDanhSachLoaiTaiKhoanDaXoa();
                }
            }

            if (current.Name == "tbpTaiKhoan")
            {
                QLTK_LoadLoaiTaiKhoan();
                if (lnkDSTaiKhoan.AccessibleName == "DSTaiKhoan")
                {
                    QLTK_LoadDanhSachTaiKhoan();
                }
                else
                {
                    QLTK_LoadDanhSachTaiKhoanDaXoa();
                }
            }
        }

        // Bắt đầu khu vực chức năng Quản lý tài khoản

        private void QLLTK_LoadDanhSachLoaiTaiKhoan(string timKiem = "")
        {
            List<LoaiTaiKhoanDTO> lsLoaiTaiKhoan = LoaiTaiKhoanBUS.LayDanhSachLoaiTaiKhoan(timKiem);
            dgvLoaiTaiKhoan.DataSource = lsLoaiTaiKhoan;
        }

        private void QLLTK_LoadDanhSachLoaiTaiKhoanDaXoa(string timKiem = "")
        {
            List<LoaiTaiKhoanDTO> lsLoaiTaiKhoan = LoaiTaiKhoanBUS.LayDanhSachLoaiTaiKhoan(timKiem, false);
            dgvLoaiTaiKhoan.DataSource = lsLoaiTaiKhoan;
        }

        private void dgvLoaiTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLoaiTaiKhoan.SelectedRows.Count > 0)
            {
                LamMoiLoaiTaiKhoan(false);
                txtMaLoaiTaiKhoan.Text = dgvLoaiTaiKhoan.SelectedRows[0].Cells["colMaLoaiTaiKhoan"].Value.ToString();
                txtTenLoaiTaiKhoan.Text = dgvLoaiTaiKhoan.SelectedRows[0].Cells["colTenLoaiTaiKhoan"].Value.ToString();
                List<ChucNang_LoaiTaiKhoanDTO> lsChucNang_LoaiTaiKhoan = ChucNang_LoaiTaiKhoanBUS.LayDanhSachChucNang_LoaiTaiKhoanTheoMaLoaiTaiKhoan(Convert.ToInt32(txtMaLoaiTaiKhoan.Text));
                foreach (ChucNang_LoaiTaiKhoanDTO chucNang_LoaiTaiKhoan in lsChucNang_LoaiTaiKhoan)
                {
                    switch (chucNang_LoaiTaiKhoan.MaChucNang)
                    {
                        case 1:
                            chkQuanLyTaiKhoan.Checked = true;
                            break;
                        case 2:
                            chkQuanLyMon.Checked = true;
                            break;
                        case 3:
                            chkQuanLyKho.Checked = true;
                            break;
                        case 4:
                            chkThongKeHoaDon.Checked = true;
                            break;
                        case 5:
                            chkThongKeNhapHang.Checked = true;
                            break;
                        case 6:
                            chkThongKeDoanhThu.Checked = true;
                            break;
                        case 7:
                            chkNhapHang.Checked = true;
                            break;
                        case 8:
                            chkBanHang.Checked = true;
                            break;
                        case 9:
                            chkBaoCao.Checked = true;
                            break;
                        case 10:
                            chkCaiDat.Checked = true;
                            break;
                    }
                }

                if (txtMaLoaiTaiKhoan.Text == "1")
                {
                    gpbChucNang.Enabled = false;
                    btnSuaLoaiTaiKhoan.Enabled = false;
                    btnXoaLoaiTaiKhoan.Enabled = false;
                }
                else
                {
                    if (lnkDSLoaiTaiKhoan.AccessibleName == "DSLoaiTaiKhoan")
                    {
                        gpbChucNang.Enabled = true;
                    }
                }
            }
        }

        private void LamMoiLoaiTaiKhoan(bool state = true)
        {
            txtMaLoaiTaiKhoan.Text = txtTenLoaiTaiKhoan.Text = string.Empty;
            btnThemLoaiTaiKhoan.Enabled = state;
            btnXoaLoaiTaiKhoan.Enabled = !state;
            btnSuaLoaiTaiKhoan.Enabled = !state;
            btnKhoiPhucLoaiTaiKhoan.Enabled = !state;
            foreach (Control ctrl in gpbChucNang.Controls)
            {
                if (ctrl.GetType() == typeof(MetroCheckBox))
                {
                    ((MetroCheckBox)ctrl).Checked = false;
                }
            }
        }

        private List<ChucNang_LoaiTaiKhoanDTO> LayDanhSachCheckBoxChucNang(bool themLoaiTaiKhoan)
        {
            int maLoaiTaiKhoan;
            if (themLoaiTaiKhoan)
            {
                maLoaiTaiKhoan = LoaiTaiKhoanBUS.LayMaLoaiTaiKhoanMoiNhat() + 1;
            }
            else
            {
                maLoaiTaiKhoan = Convert.ToInt32(txtMaLoaiTaiKhoan.Text);
            }
            List<ChucNang_LoaiTaiKhoanDTO> lsChucNang_LoaiTaiKhoan = new List<ChucNang_LoaiTaiKhoanDTO>();
            foreach (Control ctrl in gpbChucNang.Controls)
            {
                if (ctrl.GetType() == typeof(MetroCheckBox))
                {
                    if (((MetroCheckBox)ctrl).Checked)
                    {
                        ChucNang_LoaiTaiKhoanDTO chucNang_LoaiTaiKhoan = new ChucNang_LoaiTaiKhoanDTO();
                        chucNang_LoaiTaiKhoan.MaChucNang = Convert.ToInt32(ctrl.AccessibleName);
                        chucNang_LoaiTaiKhoan.MaLoaiTaiKhoan = maLoaiTaiKhoan;
                        lsChucNang_LoaiTaiKhoan.Add(chucNang_LoaiTaiKhoan);
                    }
                }
            }
            return lsChucNang_LoaiTaiKhoan;
        }

        private void lnkDSLoaiTaiKhoan_Click(object sender, EventArgs e)
        {
            if (lnkDSLoaiTaiKhoan.AccessibleName == "DSLoaiTaiKhoan")
            {
                lnkDSLoaiTaiKhoan.Text = "Hiện danh sách loại tài khoản đang có";
                QLLTK_LoadDanhSachLoaiTaiKhoanDaXoa();
                lnkDSLoaiTaiKhoan.AccessibleName = "DSLoaiTaiKhoanDaXoa";
                panelChucNangDSLoaiTaiKhoan.Visible = false;
                panelChucNangDSLoaiTaiKhoanDaXoa.Visible = true;
                LamMoiLoaiTaiKhoan();
                txtTenLoaiTaiKhoan.Enabled = gpbChucNang.Enabled = false;
            }
            else
            {
                lnkDSLoaiTaiKhoan.Text = "Hiện danh sách loại tài khoản đã xoá";
                QLLTK_LoadDanhSachLoaiTaiKhoan();
                lnkDSLoaiTaiKhoan.AccessibleName = "DSLoaiTaiKhoan";
                panelChucNangDSLoaiTaiKhoan.Visible = true;
                panelChucNangDSLoaiTaiKhoanDaXoa.Visible = false;
                LamMoiLoaiTaiKhoan();
                txtTenLoaiTaiKhoan.Enabled = gpbChucNang.Enabled = true;
            }
        }

        private void btnThemLoaiTaiKhoan_Click(object sender, EventArgs e)
        {
            LoaiTaiKhoanDTO loaiTaiKhoan = new LoaiTaiKhoanDTO();
            loaiTaiKhoan.TenLoaiTaiKhoan = txtTenLoaiTaiKhoan.Text;
            loaiTaiKhoan.TrangThai = true;

            if (LoaiTaiKhoanBUS.ThemLoaiTaiKhoan(loaiTaiKhoan, LayDanhSachCheckBoxChucNang(true)))
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
            //if (txtMaLoaiTaiKhoan.Text == "1")
            //{
            //    MessageBox.Show("Đây là loại tài khoản mặc định và không thể xoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
            if (DialogResult.Yes == MessageBox.Show("Xoá loại tài khoản sẽ đồng thời xoá tất cả tài khoản thuộc loại tài khoản này.\n\nBạn có chắc chắn muốn xoá loại tài khoản này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (TaiKhoanBUS.LayThongTinTaiKhoan(TaiKhoanBUS.LayTaiKhoanDangNhap()).LoaiTaiKhoan == int.Parse(txtMaLoaiTaiKhoan.Text))
                {
                    MessageBox.Show("Tài khoản đang đang nhập thuộc loại tài khoản này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (LoaiTaiKhoanBUS.XoaLoaiTaiKhoan(Convert.ToInt32(txtMaLoaiTaiKhoan.Text)))
                {
                    MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiLoaiTaiKhoan();
                    QLLTK_LoadDanhSachLoaiTaiKhoan();
                    dgvLoaiTaiKhoan.ClearSelection();
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
            loaiTaiKhoan.TrangThai = true;

            //if (txtMaLoaiTaiKhoan.Text == "1")
            //{
            //    MessageBox.Show("Đây là loại tài khoản mặc định và không thể sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
            if (LoaiTaiKhoanBUS.SuaLoaiTaiKhoan(loaiTaiKhoan, LayDanhSachCheckBoxChucNang(false)))
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (TaiKhoanBUS.LayThongTinTaiKhoan(TaiKhoanBUS.LayTaiKhoanDangNhap()).LoaiTaiKhoan == int.Parse(txtMaLoaiTaiKhoan.Text))
                {
                    if (DialogResult.OK == MessageBox.Show("Vui lòng đăng nhập lại để cập nhật thay đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information))
                    {
                        ((FrmMain)this.ParentForm).DangXuat();
                        this.Close();
                    }
                }
                LamMoiLoaiTaiKhoan();
                QLLTK_LoadDanhSachLoaiTaiKhoan();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loaiTaiKhoan = null;
            }
        }

        private void btnKhoiPhucLoaiTaiKhoan_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Khôi phục loại tài khoản sẽ đồng thời Khôi phục tất cả tài khoản thuộc loại tài khoản này. Điều này có thể khôi phục lại các tài khoản bạn không mong muốn.\n\nBạn có chắc chắn muốn khôi phục loại tài khoản này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                if (LoaiTaiKhoanBUS.KhoiPhucLoaiTaiKhoan(Convert.ToInt32(txtMaLoaiTaiKhoan.Text)))
                {
                    MessageBox.Show("Khôi phục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    QLLTK_LoadDanhSachLoaiTaiKhoanDaXoa();
                    LamMoiLoaiTaiKhoan();
                    dgvLoaiTaiKhoan.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Khôi phục thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoiLoaiTaiKhoan_Click(object sender, EventArgs e)
        {
            LamMoiLoaiTaiKhoan();
            dgvLoaiTaiKhoan.ClearSelection();
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
            if (lnkDSLoaiTaiKhoan.AccessibleName == "DSLoaiTaiKhoan")
            {
                QLLTK_LoadDanhSachLoaiTaiKhoan(txtTimKiemLoaiTaiKhoan.Text);
            }
            else
            {
                QLLTK_LoadDanhSachLoaiTaiKhoanDaXoa(txtTimKiemLoaiTaiKhoan.Text);
            }
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

        private void QLTK_LoadDanhSachTaiKhoanDaXoa(string timKiem = "")
        {
            List<TaiKhoanDTO> lsTaiKhoan = TaiKhoanBUS.LayDanhSachTaiKhoan(timKiem, false);
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
            ((DataGridViewComboBoxCell)dgvTaiKhoan.Rows[e.RowIndex].Cells["colLoaiTaiKhoan"]).DataSource = LoaiTaiKhoanBUS.LayDanhSachTatCaLoaiTaiKhoan();
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

                if (txtMaTaiKhoan.Text == "1")
                {
                    cmbLoaiTaiKhoan.Enabled = false;
                    btnXoaTaiKhoan.Enabled = false;
                }
            }
        }

        private void lnkTaiKhoan_Click(object sender, EventArgs e)
        {
            if (lnkDSTaiKhoan.AccessibleName == "DSTaiKhoan")
            {
                lnkDSTaiKhoan.Text = "Hiện danh sách tài khoản đang có";
                QLTK_LoadDanhSachTaiKhoanDaXoa();
                lnkDSTaiKhoan.AccessibleName = "DSTaiKhoanDaXoa";
                panelChucNangDSTaiKhoan.Visible = false;
                panelChucNangDSTaiKhoanDaXoa.Visible = true;
                LamMoiTaiKhoan();
                txtHoTen.Enabled = txtMatKhau.Enabled = dtpNgayBatDau.Enabled = cmbLoaiTaiKhoan.Enabled = picHinh.Enabled = false;
            }
            else
            {
                lnkDSTaiKhoan.Text = "Hiện danh sách tài khoản đã xoá";
                QLTK_LoadDanhSachTaiKhoan();
                lnkDSTaiKhoan.AccessibleName = "DSTaiKhoan";
                panelChucNangDSTaiKhoan.Visible = true;
                panelChucNangDSTaiKhoanDaXoa.Visible = false;
                LamMoiTaiKhoan();
                txtHoTen.Enabled = txtMatKhau.Enabled = dtpNgayBatDau.Enabled = cmbLoaiTaiKhoan.Enabled = picHinh.Enabled = true;
            }
        }

        private string MaHoaMatKhau(string matKhau)
        {
            MD5 mh = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(matKhau);
            byte[] hash = mh.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }

            return sb.ToString();
        }

        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO taiKhoan = new TaiKhoanDTO();
            taiKhoan.HoTen = txtHoTen.Text;
            taiKhoan.MatKhau = MaHoaMatKhau(txtMatKhau.Text);
            taiKhoan.NgayBatDau = dtpNgayBatDau.Value;
            taiKhoan.LoaiTaiKhoan = Convert.ToInt32(cmbLoaiTaiKhoan.SelectedValue);
            if (openFileDialog1.FileName != "")
            {
                string tenFile = DateTime.Now.ToFileTime() + "_" + (TaiKhoanBUS.LayMaTaiKhoanMoiNhat() + 1).ToString();
                string extension = Path.GetExtension(openFileDialog1.SafeFileName);
                taiKhoan.Hinh = tenFile + extension;
                File.Copy(openFileDialog1.FileName, "img\\accounts\\" + tenFile + extension, true);
            }
            taiKhoan.TrangThai = true;

            if (TaiKhoanBUS.ThemTaiKhoan(taiKhoan))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiTaiKhoan();
                QLTK_LoadDanhSachTaiKhoan();
                dgvTaiKhoan.ClearSelection();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                taiKhoan = null;
            }
        }

        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            //if (int.Parse(txtMaTaiKhoan.Text) == 1)
            //{
            //    MessageBox.Show("Đây là tài khoản mặc định và không thể xoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
            if (int.Parse(txtMaTaiKhoan.Text) == TaiKhoanBUS.LayTaiKhoanDangNhap())
            {
                MessageBox.Show("Tài khoản này đang được dùng để đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn xoá tài khoản này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (TaiKhoanBUS.XoaTaiKhoan(Convert.ToInt32(txtMaTaiKhoan.Text)))
                {
                    MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiTaiKhoan();
                    QLTK_LoadDanhSachTaiKhoan();
                    dgvTaiKhoan.ClearSelection();
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
            taiKhoan.MatKhau = MaHoaMatKhau(txtMatKhau.Text);
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
            taiKhoan.TrangThai = true;

            if (TaiKhoanBUS.SuaTaiKhoan(taiKhoan))
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (int.Parse(txtMaTaiKhoan.Text) == TaiKhoanBUS.LayTaiKhoanDangNhap())
                {
                    if (DialogResult.OK == MessageBox.Show("Vui lòng đăng nhập lại để cập nhật thay đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information))
                    {
                        ((FrmMain)this.ParentForm).DangXuat();
                        this.Close();
                    }
                }
                else
                {
                    LamMoiTaiKhoan();
                    QLTK_LoadDanhSachTaiKhoan();
                    dgvTaiKhoan.ClearSelection();
                }
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                taiKhoan = null;
            }
        }

        private void btnKhoiPhucTaiKhoan_Click(object sender, EventArgs e)
        {
            if (TaiKhoanBUS.KhoiPhucTaiKhoan(Convert.ToInt32(txtMaTaiKhoan.Text)))
            {
                MessageBox.Show("Khôi phục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QLTK_LoadDanhSachTaiKhoanDaXoa();
                LamMoiTaiKhoan();
                dgvLoaiTaiKhoan.ClearSelection();
            }
            else
            {
                MessageBox.Show("Khôi phục thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LamMoiTaiKhoan(bool state = true)
        {
            txtMaTaiKhoan.Text = txtHoTen.Text = txtMatKhau.Text = string.Empty;
            dtpNgayBatDau.Value = DateTime.Now;
            //cmbLoaiTaiKhoan.SelectedIndex = 0;
            cmbLoaiTaiKhoan.Enabled = true;
            picHinh.Image = Properties.Resources.default_account;
            btnThemTaiKhoan.Enabled = state;
            btnXoaTaiKhoan.Enabled = !state;
            btnSuaTaiKhoan.Enabled = !state;
            btnKhoiPhucTaiKhoan.Enabled = !state;
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
            if (lnkDSTaiKhoan.AccessibleName == "DSTaiKhoan")
            {
                QLTK_LoadDanhSachTaiKhoan(txtTimKiemTaiKhoan.Text);
            }
            else
            {
                QLTK_LoadDanhSachTaiKhoanDaXoa(txtTimKiemTaiKhoan.Text);
            }
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

        private void FrmQuanLyTaiKhoan_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }
    }
}
