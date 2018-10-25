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
    public partial class FrmQuanLyMon_Topping : MetroFramework.Forms.MetroForm
    {
        public FrmQuanLyMon_Topping()
        {
            InitializeComponent();
        }

        private static FrmQuanLyMon_Topping _Instance = null;

        public static FrmQuanLyMon_Topping Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FrmQuanLyMon_Topping();
                }
                return _Instance;
            }
        }

        private void FrmQuanLyMon_Topping_Load(object sender, EventArgs e)
        {
            dgvLoaiMon.AutoGenerateColumns = false;

            LoadDanhSachLoaiMon();
        }

        private void LoadDanhSachLoaiMon(string timKiem = "")
        {
            List<LoaiMonDTO> lstLoaiMon = LoaiMonBUS.LayDanhSachTatCaLoaiMon(timKiem);
            dgvLoaiMon.DataSource = lstLoaiMon;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LoaiMonDTO loaiMon = new LoaiMonDTO();
            loaiMon.TenLoaiMon = txtTenLoaiMon.Text;
            loaiMon.TrangThai = chkDangSuDung.Checked;
            loaiMon.LaDoUong = chkThucUong.Checked;
            if(LoaiMonBUS.ThemLoaiMon(loaiMon))
            {
                MessageBox.Show("Thêm thành công!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
                LoadDanhSachLoaiMon();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loaiMon = null;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (LoaiMonBUS.XoaLoaiMon(Convert.ToInt32(txtMaLoaiMon.Text)))
            {
                MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
                LoadDanhSachLoaiMon();
            }
            else
            {
                MessageBox.Show("Xoá thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LoaiMonDTO loaiMon = new LoaiMonDTO();
            loaiMon.MaLoaiMon = Convert.ToInt32(txtMaLoaiMon.Text);
            loaiMon.TenLoaiMon = txtTenLoaiMon.Text;
            loaiMon.TrangThai = chkDangSuDung.Checked;
            loaiMon.LaDoUong = chkThucUong.Checked;

            if (LoaiMonBUS.SuaLoaiMon(loaiMon))
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
                LoadDanhSachLoaiMon();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loaiMon = null;
            }
        }

        private void LamMoi()
        {
            txtMaLoaiMon.Text = txtTenLoaiMon.Text = string.Empty;
            chkDangSuDung.Checked = chkThucUong.Checked = false;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void dgvQuanLyMonVaTopping_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLoaiMon.SelectedRows.Count > 0)
            {
                txtMaLoaiMon.Text = dgvLoaiMon.SelectedRows[0].Cells["colMaLoaiMon"].Value.ToString();
                txtTenLoaiMon.Text = dgvLoaiMon.SelectedRows[0].Cells["colTenLoaiMon"].Value.ToString();
                chkThucUong.Checked = Convert.ToBoolean(dgvLoaiMon.SelectedRows[0].Cells["colLaDoUong"].Value);
                chkDangSuDung.Checked = Convert.ToBoolean(dgvLoaiMon.SelectedRows[0].Cells["colDangSuDung"].Value);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            ((FrmMain)this.ParentForm).XuLyFormMain();
            this.Close();
        }

        private void FrmQuanLyMon_Topping_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }
    }
}
