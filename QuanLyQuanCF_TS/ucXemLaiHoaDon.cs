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
            int taiKhoan = NhanVienBUS.LayTaiKhoanDangNhap();
            NhanVienDTO nhanVien = NhanVienBUS.LayThongTinNhanVien(taiKhoan);
            lblTenNhanVien.Text = nhanVien.HoTen;
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
                dgvHoaDon.Rows.Add(r);
            }
            dgvHoaDon.ClearSelection();
            lblSoHoaDon.Text = "Số hoá đơn: " + (HoaDonBUS.LayMaHoaDonMoiNhat() + 1);
            lblSoLuongMon.Text = "Tổng món: " + soLuongMon + "";
            lblTongTien.Text = "Tổng tiền: " + tongTien.ToString("#,##0đ");
            lblTongPhaiTra.Text = "Tổng phải trả: " + tongTien.ToString("#,##0đ");
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            ((FrmBanHang)this.FindForm()).QuayLaiManHinhChonMon();
            ReseHoaDon();
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
            }
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            HoaDonDTO hoaDon = new HoaDonDTO();
            hoaDon.NhanVienLap = NhanVienBUS.LayTaiKhoanDangNhap();
            hoaDon.NgayLap = DateTime.Now;
            hoaDon.TongTien = ((FrmBanHang)this.FindForm()).TinhThanhTien();
            hoaDon.TrangThai = true;

            List<ChiTietHoaDonDTO> lsCTHD = new List<ChiTietHoaDonDTO>();
            List<ChiTietMonDTO> lsCTM = new List<ChiTietMonDTO>();
            int idCTHDMark = 0; // Đánh dấu topping thuộc CTHĐ nào
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.Tag.GetType() == typeof(MonDTO))
                {
                    ChiTietHoaDonDTO cthd = new ChiTietHoaDonDTO();
                    cthd.MaHoaDon = HoaDonBUS.LayMaHoaDonMoiNhat() + 1;
                    cthd.MaMon = ((MonDTO)row.Tag).MaMon;
                    cthd.SoLuong = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                    cthd.DonGia = Convert.ToDouble(row.Cells["colDonGia"].Value);
                    lsCTHD.Add(cthd);
                    idCTHDMark++;
                }
                else
                {
                    ChiTietMonDTO ctm = new ChiTietMonDTO();
                    ctm.MaCTHD = ChiTietHoaDonBUS.LayMaChiTietHoaDonMoiNhat() + idCTHDMark;
                    ctm.MaTopping = ((ToppingDTO)row.Tag).MaTopping;
                    ctm.SoLuong = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                    ctm.DonGia = Convert.ToDouble(row.Cells["colDonGia"].Value);
                    lsCTM.Add(ctm);
                }
            }

            if (HoaDonBUS.LuuHoaDon(hoaDon, lsCTHD, lsCTM))
            {
                MessageBox.Show("Tạo hoá đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((FrmBanHang)this.FindForm()).QuayLaiManHinhChonMon();
                ReseHoaDon();
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

        private void ReseHoaDon()
        {
            btnXuatHoaDon.Enabled = false;
            txtTienMat.Enabled = true;
            txtTienMat.Text = txtTienThua.Text = string.Empty;
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            ReseHoaDon();
        }
    }
}
