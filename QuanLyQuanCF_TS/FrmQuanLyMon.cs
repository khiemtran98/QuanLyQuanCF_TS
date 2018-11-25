using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MaterialSkin.Controls;
using System.IO;
using DTO;
using BUS;

namespace QuanLyQuanCF_TS
{
    public partial class FrmQuanLyMon : MetroFramework.Forms.MetroForm
    {
        public FrmQuanLyMon()
        {
            InitializeComponent();

            #region
            this.Style = FrmMain.style;
            tbcQuanLyMon_Topping.Style = FrmMain.style;
            txtTimKiemLoaiMon.Style = FrmMain.style;
            btnTimKiemLoaiMon.Style = FrmMain.style;
            lnkDSLoaiMon.Style = FrmMain.style;
            txtMaLoaiMon.Style = FrmMain.style;
            txtTenLoaiMon.Style = FrmMain.style;
            chkDoUong.Style = FrmMain.style;
            btnThemLoaiMon.Style = FrmMain.style;
            btnSuaLoaiMon.Style = FrmMain.style;
            btnXoaLoaiMon.Style = FrmMain.style;
            btnLamMoiLoaiMon.Style = FrmMain.style;
            btnKhoiPhucLoaiMon.Style = FrmMain.style;

            txtTimKiemLoaiTopping.Style = FrmMain.style;
            btnTimKiemLoaiTopping.Style = FrmMain.style;
            lnkDSLoaiTopping.Style = FrmMain.style;
            txtMaLoaiTopping.Style = FrmMain.style;
            txtTenLoaiTopping.Style = FrmMain.style;
            btnThemLoaiTopping.Style = FrmMain.style;
            btnSuaLoaiTopping.Style = FrmMain.style;
            btnXoaLoaiTopping.Style = FrmMain.style;
            btnLamMoiLoaiTopping.Style = FrmMain.style;
            btnKhoiPhucLoaiTopping.Style = FrmMain.style;

            txtTimKiemMon.Style = FrmMain.style;
            btnTimKiemMon.Style = FrmMain.style;
            lnkDSMon.Style = FrmMain.style;
            txtMaMon.Style = FrmMain.style;
            txtTenMon.Style = FrmMain.style;
            cmbLoaiMon.Style = FrmMain.style;
            txtGiaTienMon.Style = FrmMain.style;
            btnThemMon.Style = FrmMain.style;
            btnSuaMon.Style = FrmMain.style;
            btnXoaMon.Style = FrmMain.style;
            btnLamMoiMon.Style = FrmMain.style;
            btnKhoiPhucMon.Style = FrmMain.style;

            txtTimKiemTopping.Style = FrmMain.style;
            btnTimKiemTopping.Style = FrmMain.style;
            lnkDSTopping.Style = FrmMain.style;
            txtMaTopping.Style = FrmMain.style;
            txtTenTopping.Style = FrmMain.style;
            cmbLoaiTopping.Style = FrmMain.style;
            txtGiaTienTopping.Style = FrmMain.style;
            btnThemTopping.Style = FrmMain.style;
            btnSuaTopping.Style = FrmMain.style;
            btnXoaTopping.Style = FrmMain.style;
            btnLamMoiTopping.Style = FrmMain.style;
            btnKhoiPhucTopping.Style = FrmMain.style;
            #endregion
        }

        private static FrmQuanLyMon _Instance = null;

        public static FrmQuanLyMon Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FrmQuanLyMon();
                }
                return _Instance;
            }
        }

        private void FrmQuanLyMon_Load(object sender, EventArgs e)
        {
            dgvLoaiMon.AutoGenerateColumns = false;
            dgvLoaiTopping.AutoGenerateColumns = false;
            dgvMon.AutoGenerateColumns = false;
            dgvTopping.AutoGenerateColumns = false;

            QLLM_LoadDanhSachLoaiMon();
            QLLM_LoadDanhSachLoaiTopping();

            //QLLT_LoadDachSachLoaiTopping();

            //QLM_LoadDanhSachMon();
            QLM_LoadLoaiMon();

            //QLTP_LoadDanhSachTopping();
            QLTP_LoadDachSachLoaiTopping();

            LamMoiLoaiMon();
            LamMoiLoaiTopping();
            LamMoiMon();
            LamMoiTopping();

            //tbcQuanLyMon_Topping.SelectedTab = tbpLoaiMon;
        }

        private void tbcQuanLyMon_Topping_Selecting(object sender, TabControlCancelEventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;

            if (current.Name == "tbpLoaiMon")
            {
                gpbLoaiTopping.Controls.Clear();
                QLLM_LoadDanhSachLoaiTopping();
                if (lnkDSLoaiMon.AccessibleName == "DSLoaiMon")
                {
                    QLLM_LoadDanhSachLoaiMon();
                }
                else
                {
                    QLLM_LoadDanhSachLoaiMonDaXoa();
                }
                return;
            }

            if (current.Name == "tbpLoaiTopping")
            {
                if (lnkDSLoaiTopping.AccessibleName == "DSLoaiTopping")
                {
                    QLLT_LoadDachSachLoaiTopping();
                }
                else
                {
                    QLLT_LoadDachSachLoaiToppingDaXoa();
                }
                return;
            }

            if (current.Name == "tbpMon")
            {
                QLM_LoadLoaiMon();
                if (lnkDSMon.AccessibleName == "DSMon")
                {
                    QLM_LoadDanhSachMon();
                }
                else
                {
                    QLM_LoadDanhSachMonDaXoa();
                }
                return;
            }

            if (current.Name == "tbpTopping")
            {
                QLTP_LoadDachSachLoaiTopping();
                if (lnkDSTopping.AccessibleName == "DSTopping")
                {
                    QLTP_LoadDanhSachTopping();
                }
                else
                {
                    QLTP_LoadDanhSachToppingDaXoa(txtTimKiemTopping.Text);
                }
                return;
            }
        }

        // Bắt đầu khu vực chức năng Quản lý loại món

        private void QLLM_LoadDanhSachLoaiMon(string timKiem = "")
        {
            List<LoaiMonDTO> lsLoaiMon = LoaiMonBUS.LayDanhSachLoaiMon(timKiem);
            dgvLoaiMon.DataSource = lsLoaiMon;
        }

        private void QLLM_LoadDanhSachLoaiMonDaXoa(string timKiem = "")
        {
            List<LoaiMonDTO> lsLoaiMon = LoaiMonBUS.LayDanhSachLoaiMon(timKiem, false);
            dgvLoaiMon.DataSource = lsLoaiMon;
        }

        private void QLLM_LoadDanhSachLoaiTopping()
        {
            List<LoaiToppingDTO> lsLoaiTopping = LoaiToppingBUS.LayDanhSachLoaiTopping();
            foreach (LoaiToppingDTO loaiTopping in lsLoaiTopping)
            {
                //MaterialCheckBox checkBox = new MaterialCheckBox();
                //checkBox.Name = loaiTopping.MaLoaiTopping.ToString();
                //checkBox.Text = loaiTopping.TenLoaiTopping;
                //checkBox.Dock = DockStyle.Top;
                //checkBox.Tag = loaiTopping;
                //gpbLoaiTopping.Controls.Add(checkBox);
                //checkBox.BringToFront();

                MetroCheckBox checkBox = new MetroCheckBox();
                checkBox.Name = loaiTopping.MaLoaiTopping.ToString();
                checkBox.Text = loaiTopping.TenLoaiTopping;
                checkBox.Style = FrmMain.style;
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

        private void lnkDSLoaiMon_Click(object sender, EventArgs e)
        {
            if (lnkDSLoaiMon.AccessibleName == "DSLoaiMon")
            {
                lnkDSLoaiMon.Text = "Hiện danh sách loại món đang có";
                QLLM_LoadDanhSachLoaiMonDaXoa();
                lnkDSLoaiMon.AccessibleName = "DSLoaiMonDaXoa";
                panelChucNangDSLoaiMon.Visible = false;
                panelChucNangDSLoaiMonDaXoa.Visible = true;
                LamMoiLoaiMon();
                txtTenLoaiMon.Enabled = chkDoUong.Enabled = gpbLoaiTopping.Enabled = false;
            }
            else
            {
                lnkDSLoaiMon.Text = "Hiện danh sách loại món đã xoá";
                QLLM_LoadDanhSachLoaiMon();
                lnkDSLoaiMon.AccessibleName = "DSLoaiMon";
                panelChucNangDSLoaiMon.Visible = true;
                panelChucNangDSLoaiMonDaXoa.Visible = false;
                LamMoiLoaiMon();
                txtTenLoaiMon.Enabled = chkDoUong.Enabled = gpbLoaiTopping.Enabled = true;
            }
        }

        private void btnThemLoaiMon_Click(object sender, EventArgs e)
        {
            LoaiMonDTO loaiMon = new LoaiMonDTO();
            loaiMon.TenLoaiMon = txtTenLoaiMon.Text;
            loaiMon.LaDoUong = chkDoUong.Checked;
            loaiMon.TrangThai = true;

            if (LoaiMonBUS.ThemLoaiMon(loaiMon, LayDanhSachCheckBoxLoaiTopping(true)))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiLoaiMon();
                QLLM_LoadDanhSachLoaiMon();
                dgvLoaiMon.ClearSelection();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loaiMon = null;
            }
        }

        private void btnXoaLoaiMon_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Xoá loại món sẽ đồng thời xoá tất cả món thuộc loại món này.\n\nBạn có chắc chắn muốn xoá loại món này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (LoaiMonBUS.XoaLoaiMon(Convert.ToInt32(txtMaLoaiMon.Text)))
                {
                    MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiLoaiMon();
                    QLLM_LoadDanhSachLoaiMon();
                    dgvLoaiMon.ClearSelection();
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
            loaiMon.LaDoUong = chkDoUong.Checked;
            loaiMon.TrangThai = true;

            if (LoaiMonBUS.SuaLoaiMon(loaiMon, LayDanhSachCheckBoxLoaiTopping(false)))
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiLoaiMon();
                QLLM_LoadDanhSachLoaiMon();
                dgvLoaiMon.ClearSelection();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loaiMon = null;
            }
        }

        private void btnKhoiPhucLoaiMon_Click(object sender, EventArgs e)
        {
            if (LoaiMonBUS.KhoiPhucLoaiMon(Convert.ToInt32(txtMaLoaiMon.Text)))
            {
                MessageBox.Show("Khôi phục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QLLM_LoadDanhSachLoaiMonDaXoa();
                LamMoiLoaiMon();
                dgvLoaiMon.ClearSelection();
            }
            else
            {
                MessageBox.Show("Khôi phục thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoiLoaiMon_Click(object sender, EventArgs e)
        {
            LamMoiLoaiMon();
            dgvLoaiMon.ClearSelection();
        }

        private void btnTimKiemLoaiMon_Click(object sender, EventArgs e)
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
            if (lnkDSLoaiMon.AccessibleName == "DSLoaiMon")
            {
                QLLM_LoadDanhSachLoaiMon(txtTimKiemLoaiMon.Text);
            }
            else
            {
                QLLM_LoadDanhSachLoaiMonDaXoa(txtTimKiemLoaiMon.Text);
            }
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
            chkDoUong.Checked = false;
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
            btnKhoiPhucLoaiMon.Enabled = !state;
        }

        private void dgvLoaiMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLoaiMon.SelectedRows.Count > 0)
            {
                LamMoiLoaiMon(false);

                txtMaLoaiMon.Text = dgvLoaiMon.SelectedRows[0].Cells["colMaLoaiMon"].Value.ToString();
                txtTenLoaiMon.Text = dgvLoaiMon.SelectedRows[0].Cells["colTenLoaiMon"].Value.ToString();
                chkDoUong.Checked = Convert.ToBoolean(dgvLoaiMon.SelectedRows[0].Cells["colLaDoUong"].Value);

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

        private void QLLT_LoadDachSachLoaiToppingDaXoa(string timKiem = "")
        {
            List<LoaiToppingDTO> lsLoaiTopping = LoaiToppingBUS.LayDanhSachLoaiTopping(timKiem, false);
            dgvLoaiTopping.DataSource = lsLoaiTopping;
        }

        private void lnkDSLoaiTopping_Click(object sender, EventArgs e)
        {
            if (lnkDSLoaiTopping.AccessibleName == "DSLoaiTopping")
            {
                lnkDSLoaiTopping.Text = "Hiện danh sách loại topping đang có";
                QLLT_LoadDachSachLoaiToppingDaXoa();
                lnkDSLoaiTopping.AccessibleName = "DSLoaiToppingDaXoa";
                panelChucNangDSLoaiTopping.Visible = false;
                panelChucNangDSLoaiToppingDaXoa.Visible = true;
                LamMoiLoaiTopping();
                txtTenLoaiTopping.Enabled = false;
            }
            else
            {
                lnkDSLoaiTopping.Text = "Hiện danh sách loại topping đã xoá";
                QLLT_LoadDachSachLoaiTopping();
                lnkDSLoaiTopping.AccessibleName = "DSLoaiTopping";
                panelChucNangDSLoaiTopping.Visible = true;
                panelChucNangDSLoaiToppingDaXoa.Visible = false;
                LamMoiLoaiTopping();
                txtTenLoaiTopping.Enabled = true;
            }
        }

        private void btnThemLoaiTopping_Click(object sender, EventArgs e)
        {
            LoaiToppingDTO loaiTopping = new LoaiToppingDTO();
            loaiTopping.TenLoaiTopping = txtTenLoaiTopping.Text;
            loaiTopping.TrangThai = true;

            if (LoaiToppingBUS.ThemLoaiTopping(loaiTopping))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiLoaiTopping();
                QLLT_LoadDachSachLoaiTopping();
                dgvLoaiTopping.ClearSelection();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loaiTopping = null;
            }
        }

        private void btnXoaLoaiTopping_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Xoá loại topping sẽ đồng thời xoá tất cả topping thuộc loại topping này. Các loại món sử dụng loại topping này cũng không thể sử dụng nữa.\n\nBạn có chắc chắn muốn xoá loại topping này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (LoaiToppingBUS.XoaLoaiTopping(Convert.ToInt32(txtMaLoaiTopping.Text)))
                {
                    MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiLoaiTopping();
                    QLLT_LoadDachSachLoaiTopping();
                    dgvLoaiTopping.ClearSelection();
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
            loaiTopping.TrangThai = true;

            if (LoaiToppingBUS.SuaLoaiTopping(loaiTopping))
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiLoaiTopping();
                QLLT_LoadDachSachLoaiTopping();
                dgvLoaiTopping.ClearSelection();
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
            dgvLoaiTopping.ClearSelection();
        }

        private void btnKhoiPhucLoaiTopping_Click(object sender, EventArgs e)
        {
            if (LoaiToppingBUS.KhoiPhucLoaiTopping(Convert.ToInt32(txtMaLoaiTopping.Text)))
            {
                MessageBox.Show("Khôi phục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QLLT_LoadDachSachLoaiToppingDaXoa();
                LamMoiLoaiTopping();
                dgvLoaiTopping.ClearSelection();
            }
            else
            {
                MessageBox.Show("Khôi phục thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (lnkDSLoaiTopping.AccessibleName == "DSLoaiTopping")
            {
                QLLT_LoadDachSachLoaiTopping(txtTimKiemLoaiTopping.Text);
            }
            else
            {
                QLLT_LoadDachSachLoaiToppingDaXoa(txtTimKiemLoaiTopping.Text);
            }
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
            btnThemLoaiTopping.Enabled = state;
            btnXoaLoaiTopping.Enabled = !state;
            btnSuaLoaiTopping.Enabled = !state;
            btnKhoiPhucLoaiTopping.Enabled = !state;
        }

        private void dgvLoaiTopping_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLoaiMon.SelectedRows.Count > 0)
            {
                LamMoiLoaiTopping(false);

                txtMaLoaiTopping.Text = dgvLoaiTopping.SelectedRows[0].Cells["colMaLoaiTopping"].Value.ToString();
                txtTenLoaiTopping.Text = dgvLoaiTopping.SelectedRows[0].Cells["colTenLoaiTopping"].Value.ToString();
            }
        }

        // Kết thúc Khu vực chức năng Quản lý loại topping

        // ----------------------------------------------

        // Bắt đầu Khu vực chức năng Quản lý món

        private void QLM_LoadDanhSachMon(string timKiem = "")
        {
            List<MonDTO> lsMon = MonBUS.LayDanhSachMon(0, timKiem);
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
            List<LoaiMonDTO> lsLoaiMon = LoaiMonBUS.LayDanhSachLoaiMon();
            cmbLoaiMon.DataSource = lsLoaiMon;
            cmbLoaiMon.DisplayMember = "TenLoaiMon";
            cmbLoaiMon.ValueMember = "MaLoaiMon";
        }

        private void txtGiaTienMon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void QLM_LoadDanhSachMonDaXoa(string timKiem = "")
        {
            dgvMon.DataSource = MonBUS.LayDanhSachMon(0, timKiem, false);
        }

        private void lnkDSMon_Click(object sender, EventArgs e)
        {
            if (lnkDSMon.AccessibleName == "DSMon")
            {
                lnkDSMon.Text = "Hiện danh sách món đang có";
                QLM_LoadDanhSachMonDaXoa();
                lnkDSMon.AccessibleName = "DSMonDaXoa";
                panelChucNangDSMon.Visible = false;
                panelChucNangDSMonDaXoa.Visible = true;
                LamMoiMon();
                txtTenMon.Enabled = txtGiaTienMon.Enabled = cmbLoaiMon.Enabled = picHinhMon.Enabled = false;
            }
            else
            {
                lnkDSMon.Text = "Hiện danh sách món đã xoá";
                QLM_LoadDanhSachMon();
                lnkDSMon.AccessibleName = "DSMon";
                panelChucNangDSMon.Visible = true;
                panelChucNangDSMonDaXoa.Visible = false;
                LamMoiMon();
                txtTenMon.Enabled = txtGiaTienMon.Enabled = cmbLoaiMon.Enabled = picHinhMon.Enabled = true;
            }
        }

        private void dgvMon_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridViewComboBoxCell)dgvMon.Rows[e.RowIndex].Cells["colLoaiMon"]).DataSource = LoaiMonBUS.LayDanhSachTatCaLoaiMon();
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
                picHinhMon.Image = (Bitmap)dgvMon.SelectedRows[0].Cells["colHinh"].FormattedValue;
                txtGiaTienMon.Text = dgvMon.SelectedRows[0].Cells["colGiaTien"].Value.ToString();
            }
        }

        private void LamMoiMon(bool state = true)
        {
            txtMaMon.Text = txtTenMon.Text = txtGiaTienMon.Text = string.Empty;
            cmbLoaiMon.SelectedIndex = 0;
            picHinhMon.Image = Properties.Resources.default_product;
            btnThemMon.Enabled = state;
            btnXoaMon.Enabled = !state;
            btnSuaMon.Enabled = !state;
            btnKhoiPhucMon.Enabled = !state;
            openFileDialog1.FileName = "";
        }

        private void btnLamMoiMon_Click(object sender, EventArgs e)
        {
            LamMoiMon();
            dgvMon.ClearSelection();
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
            if (txtGiaTienMon.Text != "")
            {
                mon.GiaTien = Convert.ToDouble(txtGiaTienMon.Text);
            }
            else
            {
                mon.GiaTien = 0;
            }
            mon.TrangThai = true;

            if (MonBUS.ThemMon(mon))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiMon();
                QLM_LoadDanhSachMon();
                dgvMon.ClearSelection();
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
                    dgvMon.ClearSelection();
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
                if (picHinhMon.Image != Properties.Resources.user_account)
                {
                    mon.Hinh = dgvMon.CurrentRow.Cells["colHinh"].Value.ToString();
                }
            }
            if (txtGiaTienMon.Text != "")
            {
                mon.GiaTien = Convert.ToDouble(txtGiaTienMon.Text);
            }
            else
            {
                mon.GiaTien = 0;
            }
            mon.TrangThai = true;

            if (MonBUS.SuaMon(mon))
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiMon();
                QLM_LoadDanhSachMon();
                dgvMon.ClearSelection();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mon = null;
            }
        }

        private void btnKhoiPhucMon_Click(object sender, EventArgs e)
        {
            if (MonBUS.KhoiPhucMon(Convert.ToInt32(txtMaMon.Text)))
            {
                MessageBox.Show("Khôi phục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QLM_LoadDanhSachMonDaXoa();
                LamMoiMon();
                dgvMon.ClearSelection();
            }
            else
            {
                MessageBox.Show("Khôi phục thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picHinhMon_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            picHinhMon.ImageLocation = openFileDialog1.FileName;
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
            if (lnkDSMon.AccessibleName == "DSMon")
            {
                QLM_LoadDanhSachMon(txtTimKiemMon.Text);
            }
            else
            {
                QLM_LoadDanhSachMonDaXoa(txtTimKiemMon.Text);
            }
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

        private void btnTimKiemMon_Click(object sender, EventArgs e)
        {
            TimKiemMon();
        }

        // Kết thúc Khu vực chức năng Quản lý món

        // ----------------------------------------------

        // Bắt đầu Khu vực chức năng Quản lý topping

        private void QLTP_LoadDanhSachTopping(string timKiem = "")
        {
            List<ToppingDTO> lsTopping = ToppingBUS.LayDanhSachTopping(0, timKiem);
            dgvTopping.DataSource = lsTopping;
        }

        private void QLTP_LoadDachSachLoaiTopping()
        {
            List<LoaiToppingDTO> lsLoaiTopping = LoaiToppingBUS.LayDanhSachLoaiTopping();
            cmbLoaiTopping.DataSource = lsLoaiTopping;
            cmbLoaiTopping.DisplayMember = "TenLoaiTopping";
            cmbLoaiTopping.ValueMember = "MaLoaiTopping";
        }

        private void dgvTopping_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridViewComboBoxCell)dgvTopping.Rows[e.RowIndex].Cells["colLoaiTopping"]).DataSource = LoaiToppingBUS.LayDanhSachTatCaLoaiTopping();
            ((DataGridViewComboBoxCell)dgvTopping.Rows[e.RowIndex].Cells["colLoaiTopping"]).DisplayMember = "TenLoaiTopping";
            ((DataGridViewComboBoxCell)dgvTopping.Rows[e.RowIndex].Cells["colLoaiTopping"]).ValueMember = "MaLoaiTopping";
        }

        private void dgvTopping_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTopping.Columns[e.ColumnIndex].Name == "colHinhTopping")
            {
                e.Value = new Bitmap("img\\products\\" + e.Value.ToString());
            }
        }

        private void dgvTopping_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTopping.SelectedRows.Count > 0)
            {
                LamMoiTopping(false);
                txtMaTopping.Text = dgvTopping.SelectedRows[0].Cells["colMaTopping"].Value.ToString();
                txtTenTopping.Text = dgvTopping.SelectedRows[0].Cells["colTenTopping"].Value.ToString();
                cmbLoaiTopping.SelectedValue = Convert.ToInt32(dgvTopping.SelectedRows[0].Cells["colLoaiTopping"].Value);
                picHinhTopping.Image = (Bitmap)dgvTopping.SelectedRows[0].Cells["colHinhTopping"].FormattedValue;
                txtGiaTienTopping.Text = dgvTopping.SelectedRows[0].Cells["colGiaTienTopping"].Value.ToString();
            }
        }

        private void LamMoiTopping(bool state = true)
        {
            txtMaTopping.Text = txtTenTopping.Text = txtGiaTienTopping.Text = string.Empty;
            cmbLoaiTopping.SelectedIndex = 0;
            picHinhTopping.Image = Properties.Resources.default_product;
            btnThemTopping.Enabled = state;
            btnXoaTopping.Enabled = !state;
            btnSuaTopping.Enabled = !state;
            btnKhoiPhucTopping.Enabled = !state;
            openFileDialog2.FileName = "";
        }

        private void txtGiaTienTopping_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void picHinhTopping_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            picHinhTopping.ImageLocation = openFileDialog2.FileName;
        }

        private void btnThemTopping_Click(object sender, EventArgs e)
        {
            ToppingDTO topping = new ToppingDTO();
            topping.TenTopping = txtTenTopping.Text;
            topping.LoaiTopping = Convert.ToInt32(cmbLoaiTopping.SelectedValue);
            if (txtGiaTienTopping.Text != "")
            {
                topping.GiaTien = Convert.ToDouble(txtGiaTienTopping.Text);
            }
            else
            {
                topping.GiaTien = 0;
            }
            if (openFileDialog2.FileName != "")
            {
                string tenFile = DateTime.Now.ToFileTime() + "_" + (ToppingBUS.LayMaToppingMoiNhat() + 1).ToString();
                string extension = Path.GetExtension(openFileDialog2.SafeFileName);
                topping.Hinh = tenFile + extension;
                File.Copy(openFileDialog2.FileName, "img\\products\\" + tenFile + extension, true);
            }
            topping.TrangThai = true;

            if (ToppingBUS.ThemTopping(topping))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiTopping();
                QLTP_LoadDanhSachTopping();
                dgvTopping.ClearSelection();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                topping = null;
            }
        }

        private void btnXoaTopping_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn xoá topping này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (ToppingBUS.XoaTopping(Convert.ToInt32(txtMaTopping.Text)))
                {
                    MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiTopping();
                    QLTP_LoadDanhSachTopping();
                    dgvTopping.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Xoá thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaTopping_Click(object sender, EventArgs e)
        {
            ToppingDTO topping = new ToppingDTO();
            topping.MaTopping = Convert.ToInt32(txtMaTopping.Text);
            topping.TenTopping = txtTenTopping.Text;
            topping.LoaiTopping = Convert.ToInt32(cmbLoaiTopping.SelectedValue);
            if (txtGiaTienTopping.Text != "")
            {
                topping.GiaTien = Convert.ToDouble(txtGiaTienTopping.Text);
            }
            else
            {
                topping.GiaTien = 0;
            }
            if (openFileDialog2.FileName != "")
            {
                string tenFile = DateTime.Now.ToFileTime() + "_" + topping.MaTopping;
                string extension = Path.GetExtension(openFileDialog2.SafeFileName);
                topping.Hinh = tenFile + extension;
                File.Copy(openFileDialog2.FileName, "img\\products\\" + tenFile + extension);
            }
            else
            {
                if (picHinhTopping.Image != Properties.Resources.default_product)
                {
                    topping.Hinh = dgvTopping.CurrentRow.Cells["colHinhTopping"].Value.ToString();
                }
            }
            topping.TrangThai = true;

            if (ToppingBUS.SuaTopping(topping))
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiTopping();
                QLTP_LoadDanhSachTopping();
                dgvTopping.ClearSelection();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                topping = null;
            }
        }

        private void btnKhoiPhucTopping_Click(object sender, EventArgs e)
        {
            if (ToppingBUS.KhoiPhucTopping(Convert.ToInt32(txtMaTopping.Text)))
            {
                MessageBox.Show("Khôi phục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QLTP_LoadDanhSachToppingDaXoa();
                LamMoiTopping();
                dgvTopping.ClearSelection();
            }
            else
            {
                MessageBox.Show("Khôi phục thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QLTP_LoadDanhSachToppingDaXoa(string timKiem = "")
        {
            dgvTopping.DataSource = ToppingBUS.LayDanhSachTopping(0, timKiem, false);
        }

        private void lnkDSTopping_Click(object sender, EventArgs e)
        {
            if (lnkDSTopping.AccessibleName == "DSTopping")
            {
                lnkDSTopping.Text = "Hiện danh sách topping đang có";
                QLTP_LoadDanhSachToppingDaXoa();
                lnkDSTopping.AccessibleName = "DSToppingDaXoa";
                panelChucNangDSTopping.Visible = false;
                panelChucNangDSToppingDaXoa.Visible = true;
                LamMoiTopping();
                txtTenTopping.Enabled = txtGiaTienTopping.Enabled = cmbLoaiTopping.Enabled = picHinhTopping.Enabled = false;
            }
            else
            {
                lnkDSTopping.Text = "Hiện danh sách topping đã xoá";
                QLTP_LoadDanhSachTopping();
                lnkDSTopping.AccessibleName = "DSTopping";
                panelChucNangDSTopping.Visible = true;
                panelChucNangDSToppingDaXoa.Visible = false;
                LamMoiTopping();
                txtTenTopping.Enabled = txtGiaTienTopping.Enabled = cmbLoaiTopping.Enabled = picHinhTopping.Enabled = true;
            }
        }

        private void btnLamMoiTopping_Click(object sender, EventArgs e)
        {
            LamMoiTopping();
            dgvTopping.ClearSelection();
        }

        private void txtTimKiemTopping_Enter(object sender, EventArgs e)
        {
            if (txtTimKiemTopping.Text == "Tìm kiếm tên topping")
            {
                txtTimKiemTopping.Text = string.Empty;
            }
        }

        private void txtTimKiemTopping_Leave(object sender, EventArgs e)
        {
            if (txtTimKiemTopping.Text == string.Empty)
            {
                txtTimKiemTopping.Text = "Tìm kiếm tên topping";
            }
        }

        private void txtTimKiemTopping_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TimKiemTopping();
            }
        }
        private void btnTimKiemCuaTopping_Click(object sender, EventArgs e)
        {
            TimKiemTopping();
        }

        private void TimKiemTopping()
        {
            if (lnkDSTopping.AccessibleName == "DSTopping")
            {
                QLTP_LoadDanhSachTopping(txtTimKiemTopping.Text);
            }
            else
            {
                QLTP_LoadDanhSachToppingDaXoa(txtTimKiemTopping.Text);
            }
        }

        // Kết thúc Khu vực chức năng Quản lý topping

        private void FrmQuanLyMon_Topping_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }
    }
}
