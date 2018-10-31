using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using DTO;
using BUS;
using System.IO;

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

        private void FrmQuanLyMon_Load(object sender, EventArgs e)
        {
            // Khong cho tao cot trong dataGridView
            dgvLoaiMon.AutoGenerateColumns = false;
            dgvLoaiTopping.AutoGenerateColumns = false;

            QLLM_LoadDanhSachLoaiMon();
            QLLM_LoadDanhSachLoaiTopping();

            QLLT_LoadDachSachLoaiTopping();

            QLM_LoadDanhSachMon();
            QLM_LoadLoaiMon();

            LamMoiLoaiMon();
            LamMoiLoaiTopping();
            LamMoiMon();

            tbcQuanLyMon_Topping.SelectedTab = tbpLoaiMon;
        }

        private void tbcQuanLyMon_Topping_Selecting(object sender, TabControlCancelEventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;

            if (current.Name == "tbpLoaiMon")
            {
                gpbLoaiTopping.Controls.Clear();
                QLLM_LoadDanhSachLoaiTopping();
            }
        }

        // Bắt đầu khu vực chức năng Quản lý loại món

        private void QLLM_LoadDanhSachLoaiMon(string timKiem = "")
        {
            List<LoaiMonDTO> lsLoaiMon = LoaiMonBUS.LayDanhSachLoaiMon(timKiem);
            dgvLoaiMon.DataSource = lsLoaiMon;
        }

        private void QLLM_LoadDanhSachLoaiTopping()
        {
            List<LoaiToppingDTO> lsLoaiTopping = LoaiToppingBUS.LayDanhSachLoaiTopping("", true);
            foreach (LoaiToppingDTO loaiTopping in lsLoaiTopping)
            {
                MaterialCheckBox checkBox = new MaterialCheckBox();
                checkBox.Name = loaiTopping.MaLoaiTopping.ToString();
                checkBox.Text = loaiTopping.TenLoaiTopping;
                checkBox.Dock = DockStyle.Top;
                checkBox.Tag = loaiTopping;
                gpbLoaiTopping.Controls.Add(checkBox);
                checkBox.BringToFront();
            }
        }

        private List<CTLoaiMon_LoaiToppingDTO> LayDanhSachCheckBoxLoaiTopping(bool themLoaiMon)
        {
            int maLoaiMon;
            if (themLoaiMon)
            {
                maLoaiMon = LoaiMonBUS.LayMaLoaiMonMoiNhat() + 1;
            }
            else
            {
                maLoaiMon = Convert.ToInt32(txtMaLoaiMon.Text);
            }
            List<CTLoaiMon_LoaiToppingDTO> lsLoaiMon_LoaiTopping = new List<CTLoaiMon_LoaiToppingDTO>();
            foreach (Control ctrl in gpbLoaiTopping.Controls)
            {
                if (ctrl.GetType() == typeof(MaterialCheckBox))
                {
                    if (((MaterialCheckBox)ctrl).Checked)
                    {
                        CTLoaiMon_LoaiToppingDTO loaiMon_LoaiTopping = new CTLoaiMon_LoaiToppingDTO();
                        LoaiToppingDTO loaiTopping = (LoaiToppingDTO)ctrl.Tag;
                        loaiMon_LoaiTopping.MaLoaiMon = maLoaiMon;
                        loaiMon_LoaiTopping.MaLoaiTopping = loaiTopping.MaLoaiTopping;
                        lsLoaiMon_LoaiTopping.Add(loaiMon_LoaiTopping);
                    }
                }
            }
            return lsLoaiMon_LoaiTopping;
        }

        private void btnThemLoaiMon_Click(object sender, EventArgs e)
        {
            LoaiMonDTO loaiMon = new LoaiMonDTO();
            loaiMon.TenLoaiMon = txtTenLoaiMon.Text;
            loaiMon.TrangThai = chkQLLM_TrangThai.Checked;
            loaiMon.LaDoUong = chkDoUong.Checked;

            if (LoaiMonBUS.ThemLoaiMon(loaiMon, LayDanhSachCheckBoxLoaiTopping(true)))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiLoaiMon();
                QLLM_LoadDanhSachLoaiMon();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loaiMon = null;
            }
        }

        private void btnXoaLoaiMon_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Xoá loại món sẽ đồng thời xoá tất cả món thuộc loại món đó. Nếu muốn tạm thời ẩn loại món này hãy thay đổi trạng thái sử dụng.\n\nBạn có chắc chắn muốn xoá loại món này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (LoaiMonBUS.XoaLoaiMon(Convert.ToInt32(txtMaLoaiMon.Text)))
                {
                    MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiLoaiMon();
                    QLLM_LoadDanhSachLoaiMon();
                }
                else
                {
                    MessageBox.Show("Xoá thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaLoaiMon_Click(object sender, EventArgs e)
        {
            LoaiMonDTO loaiMon = new LoaiMonDTO();
            loaiMon.MaLoaiMon = Convert.ToInt32(txtMaLoaiMon.Text);
            loaiMon.TenLoaiMon = txtTenLoaiMon.Text;
            loaiMon.TrangThai = chkQLLM_TrangThai.Checked;
            loaiMon.LaDoUong = chkDoUong.Checked;

            if (LoaiMonBUS.SuaLoaiMon(loaiMon, LayDanhSachCheckBoxLoaiTopping(false)))
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiLoaiMon();
                QLLM_LoadDanhSachLoaiMon();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loaiMon = null;
            }
        }

        private void btnLamMoiLoaiMon_Click(object sender, EventArgs e)
        {
            LamMoiLoaiMon();
        }

        private void btnTimKiemTenLoaiMon_Click(object sender, EventArgs e)
        {
            TimKiemLoaiMon();
        }

        private void txtTimKiemLoaiMon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TimKiemLoaiMon();
            }
        }

        private void TimKiemLoaiMon()
        {
            QLLM_LoadDanhSachLoaiMon(txtTimKiemLoaiMon.Text);
        }

        private void txtTimKiemLoaiMon_Enter(object sender, EventArgs e)
        {
            if (txtTimKiemLoaiMon.Text == "Tìm kiếm tên loại món")
            {
                txtTimKiemLoaiMon.Text = string.Empty;
            }
        }

        private void txtTimKiemLoaiMon_Leave(object sender, EventArgs e)
        {
            if (txtTimKiemLoaiMon.Text == string.Empty)
            {
                txtTimKiemLoaiMon.Text = "Tìm kiếm tên loại món";
            }
        }

        private void LamMoiLoaiMon(bool state = true)
        {
            txtMaLoaiMon.Text = txtTenLoaiMon.Text = string.Empty;
            chkDoUong.Checked = chkQLLM_TrangThai.Checked = false;
            foreach (Control ctrl in gpbLoaiTopping.Controls)
            {
                if (ctrl.GetType() == typeof(MaterialCheckBox))
                {
                    ((MaterialCheckBox)ctrl).Checked = false;
                }
            }
            btnThemLoaiMon.Enabled = state;
            btnXoaLoaiMon.Enabled = !state;
            btnSuaLoaiMon.Enabled = !state;
        }

        private void dgvLoaiMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLoaiMon.SelectedRows.Count > 0)
            {
                LamMoiLoaiMon(false);

                txtMaLoaiMon.Text = dgvLoaiMon.SelectedRows[0].Cells["colMaLoaiMon"].Value.ToString();
                txtTenLoaiMon.Text = dgvLoaiMon.SelectedRows[0].Cells["colTenLoaiMon"].Value.ToString();
                chkDoUong.Checked = Convert.ToBoolean(dgvLoaiMon.SelectedRows[0].Cells["colLaDoUong"].Value);
                chkQLLM_TrangThai.Checked = Convert.ToBoolean(dgvLoaiMon.SelectedRows[0].Cells["colQLLM_TrangThai"].Value);

                List<LoaiToppingDTO> lsLoaiTopping = LoaiToppingBUS.LayDanhSachCTLoaiMon_LoaiTopping(Convert.ToInt32(txtMaLoaiMon.Text));

                foreach (Control ctrl in gpbLoaiTopping.Controls)
                {
                    if (ctrl.GetType() == typeof(MaterialCheckBox))
                    {
                        foreach (LoaiToppingDTO loaiTopping in lsLoaiTopping)
                        {
                            if (ctrl.Name == loaiTopping.MaLoaiTopping.ToString())
                            {
                                ((MaterialCheckBox)ctrl).Checked = true;
                            }
                        }

                    }
                }
            }
        }

        // Kết thúc Khu vực chức năng Quản lý loại món

        // ----------------------------------------------
        
        // Bắt đầu Khu vực chức năng Quản lý loại topping

        private void QLLT_LoadDachSachLoaiTopping(string timKiem = "")
        {
            List<LoaiToppingDTO> lsLoaiTopping = LoaiToppingBUS.LayDanhSachLoaiTopping(timKiem);
            dgvLoaiTopping.DataSource = lsLoaiTopping;
        }

        private void btnThemLoaiTopping_Click(object sender, EventArgs e)
        {
            LoaiToppingDTO loaiTopping = new LoaiToppingDTO();
            loaiTopping.TenLoaiTopping = txtTenLoaiTopping.Text;
            loaiTopping.TrangThai = chkQLLT_TrangThai.Checked;

            if (LoaiToppingBUS.ThemLoaiTopping(loaiTopping))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiLoaiTopping();
                QLLT_LoadDachSachLoaiTopping();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loaiTopping = null;
            }
        }

        private void btnXoaLoaiTopping_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Xoá loại topping sẽ đồng thời xoá tất cả topping thuộc loại topping đó. Các loại món sử dụng loại topping này cũng không thể sử dụng nữa. Nếu muốn tạm thời ẩn loại topping này hãy thay đổi trạng thái sử dụng.\n\nBạn có chắc chắn muốn xoá loại topping này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (LoaiToppingBUS.XoaLoaiTopping(Convert.ToInt32(txtMaLoaiTopping.Text)))
                {
                    MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiLoaiTopping();
                    QLLT_LoadDachSachLoaiTopping();
                }
                else
                {
                    MessageBox.Show("Xoá thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaLoaiTopping_Click(object sender, EventArgs e)
        {
            LoaiToppingDTO loaiTopping = new LoaiToppingDTO();
            loaiTopping.MaLoaiTopping = Convert.ToInt32(txtMaLoaiTopping.Text);
            loaiTopping.TenLoaiTopping = txtTenLoaiTopping.Text;
            loaiTopping.TrangThai = chkQLLT_TrangThai.Checked;

            if (LoaiToppingBUS.SuaLoaiTopping(loaiTopping))
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiLoaiTopping();
                QLLT_LoadDachSachLoaiTopping();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loaiTopping = null;
            }
        }

        private void btnLamMoiLoaiTopping_Click(object sender, EventArgs e)
        {
            LamMoiLoaiTopping();
        }

        private void btnTimKiemLoaiTopping_Click(object sender, EventArgs e)
        {
            TimKiemLoaiTopping();
        }

        private void txtTimKiemLoaiTopping_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TimKiemLoaiTopping();
            }
        }

        private void TimKiemLoaiTopping()
        {
            QLLT_LoadDachSachLoaiTopping(txtTimKiemLoaiTopping.Text);
        }

        private void txtTimKiemLoaiTopping_Enter(object sender, EventArgs e)
        {
            if (txtTimKiemLoaiTopping.Text == "Tìm kiếm tên loại topping")
            {
                txtTimKiemLoaiTopping.Text = string.Empty;
            }
        }

        private void txtTimKiemLoaiTopping_Leave(object sender, EventArgs e)
        {
            if (txtTimKiemLoaiTopping.Text == string.Empty)
            {
                txtTimKiemLoaiTopping.Text = "Tìm kiếm tên loại topping";
            }
        }

        private void LamMoiLoaiTopping(bool state = true)
        {
            txtMaLoaiTopping.Text = txtTenLoaiTopping.Text = "";
            chkQLLT_TrangThai.Checked = false;
            btnThemLoaiTopping.Enabled = state;
            btnXoaLoaiTopping.Enabled = !state;
            btnSuaLoaiTopping.Enabled = !state;
        }

        private void dgvLoaiTopping_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLoaiMon.SelectedRows.Count > 0)
            {
                LamMoiLoaiTopping(false);

                txtMaLoaiTopping.Text = dgvLoaiTopping.SelectedRows[0].Cells["colMaLoaiTopping"].Value.ToString();
                txtTenLoaiTopping.Text = dgvLoaiTopping.SelectedRows[0].Cells["colTenLoaiTopping"].Value.ToString();
                chkQLLT_TrangThai.Checked = Convert.ToBoolean(dgvLoaiTopping.SelectedRows[0].Cells["colQLLT_TrangThai"].Value);
            }
        }

        // Kết thúc Khu vực chức năng Quản lý loại topping

        // ----------------------------------------------

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            ((FrmMain)this.ParentForm).XuLyFormMain();
            this.Close();
        }

        private void FrmQuanLyMon_Topping_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        //Quan ly Mon

        private void QLM_LoadDanhSachMon(string timKiem = "")
        {
            List<MonDTO> lsMon = MonBUS.LayDanhSachMon(0,timKiem);
            dgvMon.DataSource = lsMon;
        }

        private void dgvMon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMon.Columns[e.ColumnIndex].Name == "colHinh")
            {
                e.Value = new Bitmap("img\\products\\" + e.Value.ToString());
            }
        }

        private void QLM_LoadLoaiMon(string timKiem = "")
        {
            List<LoaiMonDTO> lsLoaiMon = LoaiMonBUS.LayDanhSachLoaiMon("", true);
            cmbLoaiMon.DataSource = lsLoaiMon;
            cmbLoaiMon.DisplayMember = "TenLoaiMon";
            cmbLoaiMon.ValueMember = "MaLoaiMon";
        }

        private void dgvMon_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridViewComboBoxCell)dgvMon.Rows[e.RowIndex].Cells["colLoaiMon"]).DataSource = LoaiMonBUS.LayDanhSachLoaiMon();
            ((DataGridViewComboBoxCell)dgvMon.Rows[e.RowIndex].Cells["colLoaiMon"]).DisplayMember = "TenLoaiMon";
            ((DataGridViewComboBoxCell)dgvMon.Rows[e.RowIndex].Cells["colLoaiMon"]).ValueMember = "MaLoaiMon";
        }

        private void dgvMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMon.SelectedRows.Count > 0)
            {
                LamMoiMon(false);
                txtMaMon.Text = dgvMon.SelectedRows[0].Cells["colMaMon"].Value.ToString();
                txtTenMon.Text = dgvMon.SelectedRows[0].Cells["colTenMon"].Value.ToString();
                cmbLoaiMon.SelectedValue = Convert.ToInt32(dgvMon.SelectedRows[0].Cells["colLoaiMon"].Value);
                picHinh.Image = (Bitmap)dgvMon.SelectedRows[0].Cells["colHinh"].FormattedValue;
                txtGiaTien.Text = dgvMon.SelectedRows[0].Cells["colGiaTien"].Value.ToString();
                chkQLM_TrangThai.Checked = Convert.ToBoolean(dgvMon.SelectedRows[0].Cells["colQLM_TrangThai"].Value);
            }
        }

        private void LamMoiMon(bool state = true)
        {
            txtMaMon.Text = txtTenMon.Text = txtGiaTien.Text = string.Empty;
            cmbLoaiMon.SelectedIndex = 0;
            chkQLM_TrangThai.Checked = false;
            picHinh.Image = Properties.Resources.default_product;
            btnThemMon.Enabled = state;
            btnXoaMon.Enabled = !state;
            btnSuaMon.Enabled = !state;
            openFileDialog1.FileName = "";
        }

        private void btnLamMoiMon_Click(object sender, EventArgs e)
        {
            LamMoiMon();
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            MonDTO mon = new MonDTO();
            mon.TenMon = txtTenMon.Text;
            mon.LoaiMon = Convert.ToInt32(cmbLoaiMon.SelectedValue);
            if (openFileDialog1.FileName != "")
            {
                string tenFile = DateTime.Now.ToFileTime() + "_" + (MonBUS.LayMaMonMoiNhat() + 1).ToString();
                string extension = Path.GetExtension(openFileDialog1.SafeFileName);
                mon.Hinh = tenFile + extension;
                File.Copy(openFileDialog1.FileName, "img\\products\\" + tenFile + extension, true);
            }
            mon.GiaTien = Convert.ToDouble(txtGiaTien.Text);
            mon.TrangThai = chkQLM_TrangThai.Checked;

            if (MonBUS.ThemMon(mon))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiMon();
                QLM_LoadDanhSachMon();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mon = null;
            }
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn xoá món này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (MonBUS.XoaMon(Convert.ToInt32(txtMaMon.Text)))
                {
                    MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiMon();
                    QLM_LoadDanhSachMon();
                }
                else
                {
                    MessageBox.Show("Xoá thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaMon_Click(object sender, EventArgs e)
        {
            MonDTO mon = new MonDTO();
            mon.MaMon = Convert.ToInt32(txtMaMon.Text);
            mon.TenMon = txtTenMon.Text;
            mon.LoaiMon = Convert.ToInt32(cmbLoaiMon.SelectedValue);
            if (openFileDialog1.FileName != "")
            {
                string tenFile = DateTime.Now.ToFileTime() + "_" + mon.MaMon;
                string extension = Path.GetExtension(openFileDialog1.SafeFileName);
                mon.Hinh = tenFile + extension;
                File.Copy(openFileDialog1.FileName, "img\\products\\" + tenFile + extension);
            }
            else
            {
                if (picHinh.Image != Properties.Resources.user_account)
                {
                    mon.Hinh = dgvMon.CurrentRow.Cells["colHinh"].Value.ToString();
                }
            }
            mon.GiaTien = Convert.ToInt32(txtGiaTien.Text);
            mon.TrangThai = chkQLM_TrangThai.Checked;

            if (MonBUS.SuaMon(mon))
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiMon();
                QLM_LoadDanhSachMon();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mon = null;
            }
        }

        private void picHinh_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            picHinh.ImageLocation = openFileDialog1.FileName;
        }

        private void txtTimKiemMon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TimKiemMon();
            }
        }
        private void TimKiemMon()
        {
            QLM_LoadDanhSachMon(txtTimKiemMon.Text);
        }

        private void txtTimKiemMon_Enter(object sender, EventArgs e)
        {
            if (txtTimKiemMon.Text == "Tìm kiếm tên món")
            {
                txtTimKiemMon.Text = string.Empty;
            }
        }

        private void txtTimKiemMon_Leave(object sender, EventArgs e)
        {
            if (txtTimKiemMon.Text == string.Empty)
            {
                txtTimKiemMon.Text = "Tìm kiếm tên món";
            }
        }

        private void btnTimKiemCuaMon_Click(object sender, EventArgs e)
        {
            TimKiemMon();
        }

        private void btnTimKiemCuaTopping_Click(object sender, EventArgs e)
        {

        }

        // FrmQuanLyMon_Load
    }
}
