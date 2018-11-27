using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace QuanLyQuanCF_TS
{
    public partial class ucXemLaiHoaDon : MetroFramework.Controls.MetroUserControl
    {
        public ucXemLaiHoaDon()
        {
            InitializeComponent();

            #region
            this.Style = FrmMain.style;
            txtTienMat.Style = FrmMain.style;
            txtTienThua.Style = FrmMain.style;
            #endregion
        }

        private static ucXemLaiHoaDon _Instance = new ucXemLaiHoaDon();

        public static ucXemLaiHoaDon Instance
        {
            get
            {
                return _Instance;
            }
        }

        private void ucXemLaiHoaDon_Load(object sender, EventArgs e)
        {
            int maTaiKhoan = TaiKhoanBUS.LayTaiKhoanDangNhap();
            TaiKhoanDTO taiKhoan = TaiKhoanBUS.LayThongTinTaiKhoan(maTaiKhoan);
            lblTenTaiKhoan.Text = taiKhoan.HoTen;
            lblNgayLap.Text = DateTime.Now + "";
        }

        public void LoadThongTinHoaDon(int soLuongMon, double tongTien)
        {
            dgvHoaDon.Rows.Clear();
            DataGridViewRowCollection collection = ((FrmBanHang)this.ParentForm).LayThongTinHoaDon();
            foreach (DataGridViewRow row in collection)
            {
                DataGridViewRow r = (DataGridViewRow)row.Clone();
                r.Cells[0].Value = row.Cells["colTenMon"].Value;
                r.Cells[1].Value = row.Cells["colSoLuong"].Value;
                r.Cells[2].Value = row.Cells["colDonGia"].Value;
                r.Cells[3].Value = row.Cells["colGhiChu"].Value;
                dgvHoaDon.Rows.Add(r);
            }
            dgvHoaDon.ClearSelection();
            lblSoHoaDon.Text = "Mã hoá đơn: " + (HoaDonBUS.LayMaHoaDonMoiNhat() + 1);
            lblSoLuongMon.Text = "Số lượng món: " + soLuongMon + "";
            lblTongTien.Text = "Tổng tiền: " + tongTien.ToString("#,##0đ");
        }

        private void txtTienMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtTienMat.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập số tiền mặt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                double tienThua = Convert.ToDouble(txtTienMat.Text) - ((FrmBanHang)this.ParentForm).TinhThanhTien();
                if (tienThua < 0)
                {
                    MessageBox.Show("Số tiền không đủ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                txtTienMat.Text = string.Format("{0:#,##0đ}", double.Parse(txtTienMat.Text));
                txtTienThua.Text = tienThua.ToString("#,##0đ");
                txtTienMat.Enabled = false;
                btnXuatHoaDon.Enabled = true;
                btnXuatHoaDon.BackColor = Color.LimeGreen;
            }
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            HoaDonDTO hoaDon = new HoaDonDTO();
            hoaDon.NhanVienLap = TaiKhoanBUS.LayTaiKhoanDangNhap();
            hoaDon.NgayLap = DateTime.Now;
            hoaDon.TongTien = ((FrmBanHang)this.FindForm()).TinhThanhTien();
            hoaDon.TienMat = Convert.ToDouble(txtTienMat.Text.Remove(txtTienMat.Text.Length - 1));
            hoaDon.TienThua = Convert.ToDouble(txtTienThua.Text.Remove(txtTienThua.Text.Length - 1));
            hoaDon.TrangThai = true;

            List<CTHoaDonDTO> lsCTHD = new List<CTHoaDonDTO>();
            List<CTHoaDon_ToppingDTO> lsCTHD_Topping = new List<CTHoaDon_ToppingDTO>();
            int idCTHDMark = 0; // Đánh dấu topping thuộc CTHĐ nào
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.Tag.GetType() == typeof(MonDTO))
                {
                    CTHoaDonDTO cthd = new CTHoaDonDTO();
                    cthd.MaHoaDon = HoaDonBUS.LayMaHoaDonMoiNhat() + 1;
                    cthd.MaMon = ((MonDTO)row.Tag).MaMon;
                    cthd.SoLuong = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                    cthd.DonGia = Convert.ToDouble(((MonDTO)row.Tag).GiaTien);
                    if (row.Cells["colGhiChu"].Value != null)
                    {
                        cthd.GhiChu = row.Cells["colGhiChu"].Value.ToString();
                    }
                    else
                    {
                        cthd.GhiChu = string.Empty;
                    }
                    lsCTHD.Add(cthd);
                    idCTHDMark++;
                }
                else
                {
                    CTHoaDon_ToppingDTO cthd_topping = new CTHoaDon_ToppingDTO();
                    cthd_topping.MaCTHD = CTHoaDonBUS.LayMaCTHoaDonMoiNhat() + idCTHDMark;
                    cthd_topping.MaTopping = ((ToppingDTO)row.Tag).MaTopping;
                    cthd_topping.SoLuong = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                    cthd_topping.DonGia = Convert.ToDouble(((ToppingDTO)row.Tag).GiaTien);
                    if (row.Cells["colGhiChu"].Value != null)
                    {
                        cthd_topping.GhiChu = row.Cells["colGhiChu"].Value.ToString();
                    }
                    else
                    {
                        cthd_topping.GhiChu = string.Empty;
                    }
                    lsCTHD_Topping.Add(cthd_topping);
                }
            }

            if (HoaDonBUS.LuuHoaDon(hoaDon, lsCTHD, lsCTHD_Topping))
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn in hoá đơn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    FrmHienThiBaoCao frm = new FrmHienThiBaoCao();
                    frm.HienThiThongTinHoaDonMoiNhat();
                    FrmMain.Instance.TopMost = false;
                    frm.Show();
                }
                ((FrmBanHang)this.FindForm()).QuayLaiManHinhChonMon(true);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi tạo hoá đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTienMat_Click(object sender, EventArgs e)
        {
            txtTienMat.Text = string.Empty;
        }

        public void ResetHoaDon()
        {
            btnXuatHoaDon.BackColor = Color.Gray;
            btnXuatHoaDon.Enabled = false;
            txtTienMat.Enabled = true;
            txtTienMat.Text = txtTienThua.Text = string.Empty;
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            ResetHoaDon();
        }
    }
}