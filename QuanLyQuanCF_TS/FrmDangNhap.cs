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
    public partial class FrmDangNhap : Form
    {
        private static FrmDangNhap _Instance = null;

        public FrmDangNhap()
        {
            InitializeComponent();
        }

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

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            this.Text = "Phần mềm quản lý quán cà phê - trà sữa";
            this.WindowState = FormWindowState.Maximized;
            
            cboNhanVien.DataSource = NhanVienBUS.layDanhSachNhanVien();
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNV";

            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DangNhap();
            }
        }

        private void FrmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void DangNhap()
        {
            if (txtMatKhau.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (NhanVienBUS.DangNhap((int)cboNhanVien.SelectedValue, txtMatKhau.Text))
            {
                MessageBox.Show("Đăng nhập thành công");
            }
            else {
                MessageBox.Show("Sai mật khẩu", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
