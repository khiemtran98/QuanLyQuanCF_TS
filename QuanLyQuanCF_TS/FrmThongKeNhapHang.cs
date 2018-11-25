﻿using System;
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
    public partial class FrmThongKeNhapHang : MetroFramework.Forms.MetroForm
    {
        public FrmThongKeNhapHang()
        {
            InitializeComponent();
        }

        private static FrmThongKeNhapHang _Instance = null;

        public static FrmThongKeNhapHang Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FrmThongKeNhapHang();
                }
                return _Instance;
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            ((FrmMain)this.ParentForm).XuLyFormMain();
            this.Close();
        }

        private void FrmThongKeNhapHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void FrmThongKeNhapHang_Load(object sender, EventArgs e)
        {
            dgvPhieuNhap.AutoGenerateColumns = false;
            dgvCTPhieuNhap.AutoGenerateColumns = false;
            
            // Lấy toàn bộ phiếu nhập
            List<PhieuNhapDTO> lsPhieuNhap = PhieuNhapBUS.GetEntireInputMaterial();
            dgvPhieuNhap.DataSource = lsPhieuNhap;

            radKhoangThoiGian.Checked = true;
            SetEnableRad(true);
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvPhieuNhap.Columns.Count > 0)
            {
                List<CTPhieuNhapDTO> lsCTPhieuNhap = CTPhieuNhapBUS.GetListDetailMaterials(Convert.ToInt32(dgvPhieuNhap.SelectedRows[0].Cells["colMaPhieuNhap"].Value));
                dgvCTPhieuNhap.DataSource = lsCTPhieuNhap;
            }
        }
        //
        private void SetEnableRad(bool enable)
        {
            dateTimePick.Visible = !enable;
            dateTimeStart.Visible = enable;
            dateTimeEnd.Visible = enable;
        }

        // Đổi mã nhà cung cấp thành tên nhà cung cấp
        private void dgvPhieuNhap_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridViewComboBoxCell)dgvPhieuNhap.Rows[e.RowIndex].Cells["colNhaCungCap"]).DataSource = NhaCungCapBUS.GetEntireProvider();
            ((DataGridViewComboBoxCell)dgvPhieuNhap.Rows[e.RowIndex].Cells["colNhaCungCap"]).DisplayMember = "TenNhaCungCap";
            ((DataGridViewComboBoxCell)dgvPhieuNhap.Rows[e.RowIndex].Cells["colNhaCungCap"]).ValueMember = "MaNhaCungCap";
        }

        // Đổi mã nguyên liệu thành tên nguyên liệu
        private void dgvCTPhieuNhap_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridViewComboBoxCell)dgvCTPhieuNhap.Rows[e.RowIndex].Cells["colMaNguyenLieu"]).DataSource = NguyenLieuBUS.GetEntireMaterials();
            ((DataGridViewComboBoxCell)dgvCTPhieuNhap.Rows[e.RowIndex].Cells["colMaNguyenLieu"]).DisplayMember = "TenNguyenLieu";
            ((DataGridViewComboBoxCell)dgvCTPhieuNhap.Rows[e.RowIndex].Cells["colMaNguyenLieu"]).ValueMember = "MaNguyenLieu";
        }

        private void radKhoangThoiGian_CheckedChanged_1(object sender, EventArgs e)
        {
            SetEnableRad(true);
        }

        private void radMocThoiGian_CheckedChanged_1(object sender, EventArgs e)
        {
            SetEnableRad(false);
        }

        private void dateTimeEnd_ValueChanged_1(object sender, EventArgs e)
        {

            DateTime dateFrom = dateTimeStart.Value;
            DateTime dateEnd = dateTimeEnd.Value;
            dgvPhieuNhap.DataSource = PhieuNhapBUS.GetListInputByTime(dateFrom, dateEnd);
        }

        private void dateTimePick_ValueChanged_1(object sender, EventArgs e)
        {
            DateTime dateOnly = dateTimePick.Value;
            dgvPhieuNhap.DataSource = PhieuNhapBUS.GetListInputTimeline(dateOnly);
        }

        private void splitContainer4_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTrangThai_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.Columns.Count > 0)
            {
                if(PhieuNhapBUS.isActive(Convert.ToInt32(dgvPhieuNhap.SelectedRows[0].Cells["colMaPhieuNhap"].Value)))
                {
                    List<PhieuNhapDTO> lsPhieuNhap = PhieuNhapBUS.GetEntireInputMaterial();
                    dgvPhieuNhap.DataSource = lsPhieuNhap;
                    MessageBox.Show("Đổi trạng thái thành công!");
                }
                else
                    MessageBox.Show("Đổi trạng thái thất bại!");

            }
        }

        private void dateTimeStart_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateFrom = dateTimeStart.Value;
            DateTime dateEnd = dateTimeEnd.Value;
            dgvPhieuNhap.DataSource = PhieuNhapBUS.GetListInputByTime(dateFrom, dateEnd);
        }
    }
}
