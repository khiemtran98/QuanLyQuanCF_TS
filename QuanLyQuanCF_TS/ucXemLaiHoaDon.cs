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

        private static ucXemLaiHoaDon _Instance = null;

        public static ucXemLaiHoaDon Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ucXemLaiHoaDon();
                }
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
            DataGridViewRowCollection collection = ((FrmBanHang)this.ParentForm).LayThongTinHoaDon();
            foreach (DataGridViewRow row in collection)
            {
                DataGridViewRow r = (DataGridViewRow)row.Clone();
                r.Cells[0].Value = row.Cells[0].Value;
                r.Cells[1].Value = row.Cells[1].Value;
                r.Cells[2].Value = row.Cells[2].Value;
                dgvHoaDon.Rows.Add(r);
            }
            lblTongLy.Text += soLuongMon + "";
            lblTongTien.Text += tongTien.ToString("#,##0đ");
            lblTongPhaiTra.Text += tongTien.ToString("#,##0đ");
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ((FrmBanHang)this.FindForm()).QuayLaiManHinhChonMon();
            _Instance = null;
        }

        private void txtTienMat_TextChanged(object sender, EventArgs e)
        {
            if (txtTienMat.Text != "")
            {
                txtTienMat.Text = string.Format("{0:#,###}", double.Parse(txtTienMat.Text));
            }
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
                double tienThoi = Convert.ToDouble(txtTienMat.Text) - ((FrmBanHang)this.ParentForm).TinhThanhTien();
                txtTienThoi.Text = tienThoi.ToString("#,###");
            }
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này đang được xây dựng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
