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
using System.Security.Cryptography;

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

        private void KiemTraDangNhap()
        {
            if (TaiKhoanBUS.KiemTraDangNhap((int)cmbTaiKhoan.SelectedValue, MaHoaMatKhau(txtMatKhau.Text)))
            {
                ((FrmMain)this.ParentForm).XuLyDangNhapThanhCong((int)cmbTaiKhoan.SelectedValue);
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
