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
    public partial class FrmDangNhap : MetroFramework.Forms.MetroForm
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private static FrmDangNhap _Instance = null;

        public static FrmDangNhap Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FrmDangNhap();
                }
                return _Instance;
            }
        }

        private void KiemTraDangNhap()
        {
            if (txtMatKhau.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TaiKhoanBUS.KiemTraDangNhap((int)cmbTaiKhoan.SelectedValue, txtMatKhau.Text))
            {
                ((FrmMain)this.ParentForm).XuLyDangNhapThanhCong((int)cmbTaiKhoan.SelectedValue);
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai mật khẩu", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            cmbTaiKhoan.DataSource = TaiKhoanBUS.LayDanhSachTaiKhoan();
            cmbTaiKhoan.DisplayMember = "HoTen";
            cmbTaiKhoan.ValueMember = "MaTaiKhoan";
        }

        private void FrmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            KiemTraDangNhap();
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                KiemTraDangNhap();
            }
        }
    }
}
