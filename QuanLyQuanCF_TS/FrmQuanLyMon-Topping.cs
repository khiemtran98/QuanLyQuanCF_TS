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
using MaterialSkin.Controls;

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
            dgvQuanLyLoaiTopping.AutoGenerateColumns = false;

            LoadDanhSachLoaiMon();
            LoadDachSachLoaiTopping();
            LayDanhSachCTLoaiMon_Topping();
        }

        private void LoadDanhSachLoaiMon(string timKiem = "")
        {
            List<LoaiMonDTO> lstLoaiMon = LoaiMonBUS.LayDanhSachTatCaLoaiMon(timKiem);
            dgvLoaiMon.DataSource = lstLoaiMon;
        }

        private void LoadDachSachLoaiTopping(string timKiem = "")
        {
            List<LoaiToppingDTO> lstLoaiTopping = LoaiToppingBUS.LayDanhSachTatCaLoaiTopping(timKiem);
            dgvQuanLyLoaiTopping.DataSource = lstLoaiTopping;

            LoadLoaiMonTrongLoaiTopping();
        }

        private void LoadLoaiMonTrongLoaiTopping()
        {
            // Load du lieu cho combobox LoaiTopping
            List<LoaiMonDTO> lstLoaiMon = LoaiMonBUS.LayDanhSachLoaiMon();
            //cmbLoaiMonTopping.DataSource = lstLoaiMon;
            //cmbLoaiMonTopping.DisplayMember = "TenLoaiMon";
            //cmbLoaiMonTopping.ValueMember = "MaLoaiMon";

            // Load du lieu cho combobox trong DataGridView LoaiTopping
            //cmbLoaiMonTrongLoaiTopping.DisplayMember = "TenLoaiMon";
            //cmbLoaiMonTrongLoaiTopping.ValueMember = "MaLoaiMon";
            //cmbLoaiMonTrongLoaiTopping.DataSource = lstLoaiMon;
        }

        private void btnThemLoaiMon_Click(object sender, EventArgs e)
        {
            LoaiMonDTO loaiMon = new LoaiMonDTO();
            loaiMon.TenLoaiMon = txtTenLoaiMon.Text;
            loaiMon.TrangThai = chkDangSuDung.Checked;
            loaiMon.LaDoUong = chkThucUong.Checked;
            if (LoaiMonBUS.ThemLoaiMon(loaiMon))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiLoaiMon();
                LoadDanhSachLoaiMon();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loaiMon = null;
            }
        }

        private void btnXoaLoaiMon_Click(object sender, EventArgs e)
        {
            if (LoaiMonBUS.XoaLoaiMon(Convert.ToInt32(txtMaLoaiMon.Text)))
            {
                MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiLoaiMon();
                LoadDanhSachLoaiMon();
            }
            else
            {
                MessageBox.Show("Xoá thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaLoaiMon_Click(object sender, EventArgs e)
        {
            LoaiMonDTO loaiMon = new LoaiMonDTO();
            loaiMon.MaLoaiMon = Convert.ToInt32(txtMaLoaiMon.Text);
            loaiMon.TenLoaiMon = txtTenLoaiMon.Text;
            loaiMon.TrangThai = chkDangSuDung.Checked;
            loaiMon.LaDoUong = chkThucUong.Checked;

            if (LoaiMonBUS.SuaLoaiMon(loaiMon))
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiLoaiMon();
                LoadDanhSachLoaiMon();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loaiMon = null;
            }
        }

        private void LamMoiLoaiMon()
        {
            txtMaLoaiMon.Text = txtTenLoaiMon.Text = string.Empty;
            chkDangSuDung.Checked = chkThucUong.Checked = false;
        }

        private void btnLamMoiLoaiMon_Click(object sender, EventArgs e)
        {
            LamMoiLoaiMon();
        }

        private void dgvQuanLyMonVaTopping_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLoaiMon.SelectedRows.Count > 0)
            {
                txtMaLoaiMon.Text = dgvLoaiMon.SelectedRows[0].Cells["colMaLoaiMon"].Value.ToString();
                txtTenLoaiMon.Text = dgvLoaiMon.SelectedRows[0].Cells["colTenLoaiMon"].Value.ToString();
                chkThucUong.Checked = Convert.ToBoolean(dgvLoaiMon.SelectedRows[0].Cells["colLaDoUong"].Value);
                chkDangSuDung.Checked = Convert.ToBoolean(dgvLoaiMon.SelectedRows[0].Cells["colDangSuDung"].Value);

                List<LoaiToppingDTO> lstLoaiTopping = LoaiToppingBUS.LayDanhSachLoaiToppingTheoLoaiMon(Convert.ToInt32(txtMaLoaiMon.Text));
                
                //Cua may do Khiem
                foreach (Control ctrl in groupBox1.Controls)
                {
                    if (ctrl.GetType() == typeof(MaterialCheckBox))
                    {
                        ((MaterialCheckBox)ctrl).Checked = false;
                    }
                }

                //Cua may do Khiem
                foreach (Control ctrl in groupBox1.Controls)
                {
                    foreach (LoaiToppingDTO loaiTopping in lstLoaiTopping)
                    {
                        if (ctrl.GetType() == typeof(MaterialCheckBox))
                        {
                            if (ctrl.Name == loaiTopping.MaLoaiTopping.ToString())
                            {
                                ((MaterialCheckBox)ctrl).Checked = true;
                            }
                            else
                            {
                                
                            }
                        }

                    }
                }
            }
        }

        private void LayDanhSachCTLoaiMon_Topping()
        {
            // Nhuc dau vl  
            List<LoaiToppingDTO> lst = LoaiToppingBUS.LayDanhSachLoaiTopping();
            foreach (LoaiToppingDTO loaiTopping in lst)
            {
                MaterialCheckBox checkBox = new MaterialCheckBox();
                checkBox.Name = loaiTopping.MaLoaiTopping.ToString();
                checkBox.Text = loaiTopping.TenLoaiTopping;
                checkBox.Dock = DockStyle.Top;
                groupBox1.Controls.Add(checkBox);
                checkBox.BringToFront();
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

        private void btnThemLoaiTopping_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaLoaiTopping_Click(object sender, EventArgs e)
        {

        }

        private void btnSuaLoaiTopping_Click(object sender, EventArgs e)
        {

        }

        private void btnLamMoiLoaiTopping_Click(object sender, EventArgs e)
        {
            LamMoi_LoaiTopping();
        }

        private void LamMoi_LoaiTopping()
        {
            txtMaLoaiTopping.Text = txtTenLoaiTopping.Text = "";
            chkTrangThaiTopping.Checked = false;
        }
    }
}
