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
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = this.MinimizeBox = false;

            cboNhanVien.DataSource = NhanVienBUS.layDanhSachNhanVien();
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNV";

            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            dangNhap();
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dangNhap();
            }
        }

        private void FrmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void dangNhap()
        {
            if (txtMatKhau.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (NhanVienBUS.DangNhap((int)cboNhanVien.SelectedValue, txtMatKhau.Text))
            {
                ((FrmMain)this.ParentForm).xuLyDangNhapThanhCong(cboNhanVien.SelectedValue.ToString());
                this.Close();
            }
            else {
                MessageBox.Show("Sai mật khẩu", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
