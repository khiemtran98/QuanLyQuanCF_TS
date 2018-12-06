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
    public partial class FrmThongKeHoaDon : MetroFramework.Forms.MetroForm
    {
        public FrmThongKeHoaDon()
        {
            InitializeComponent();

            #region
            this.Style = FrmMain.style;
            radScopeTime.Style = FrmMain.style;
            radTimeLine.Style = FrmMain.style;
            dateTimeStart.Style = FrmMain.style;
            dateTimeEnd.Style = FrmMain.style;
            dateTimePick.Style = FrmMain.style;
            #endregion
        }

        private static FrmThongKeHoaDon _Instance = null;

        public static FrmThongKeHoaDon Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FrmThongKeHoaDon();
                }
                return _Instance;
            }
        }

        private void FrmThongKeHoaDon_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void FrmThongKeHoaDon_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvCTHD.AutoGenerateColumns = false;

            //LoadHoaDon();

            radScopeTime.Checked = true;
            SetEnableRad(true);
        }

        //private void LoadHoaDon()
        //{
        //    List<HoaDonDTO> lsHoaDon = HoaDonBUS.GetEntireListBill();
        //    dgvHoaDon.DataSource = lsHoaDon;
        //}

        private void LoadCTHD(int maHoaDon)
        {
            List<rptMon_CTHDDTO> lsHoaDon = rptMon_CTHDBUS.DoiMaMonThanhTenMon(maHoaDon);
            dgvCTHD.DataSource = lsHoaDon;
        }

        private void SetEnableRad(bool enable)
        {
            dateTimePick.Enabled = !enable;
            dateTimeStart.Enabled = enable;
            dateTimeEnd.Enabled = enable;
        }

        private void radScopeTime_CheckedChanged(object sender, EventArgs e)
        {
            SetEnableRad(true);
            LoadHoaDonTheoKhoangThoiGian();
        }

        private void radTimeLine_CheckedChanged(object sender, EventArgs e)
        {
            SetEnableRad(false);
            LoadHoaDonTheoMocThoiGian();
        }
        
        private void LoadHoaDonTheoMocThoiGian()
        {
            DateTime dateSingle = dateTimePick.Value;
            List<HoaDonDTO> lsHoaDon = HoaDonBUS.GetListBillTimeline(dateSingle);
            dgvHoaDon.DataSource = lsHoaDon;
        }

        private void LoadHoaDonTheoKhoangThoiGian()
        {
            DateTime dateFrom = dateTimeStart.Value;
            DateTime dateEnd = dateTimeEnd.Value;
            List<HoaDonDTO> lsHoaDon = HoaDonBUS.GetListBillByTime(dateFrom, dateEnd);
            dgvHoaDon.DataSource = lsHoaDon;
        }

        private void dateTimeStart_ValueChanged(object sender, EventArgs e)
        {
            LoadHoaDonTheoKhoangThoiGian();
        }

        private void dateTimeEnd_ValueChanged(object sender, EventArgs e)
        {
            LoadHoaDonTheoKhoangThoiGian();
        }

        private void dateTimePick_ValueChanged(object sender, EventArgs e)
        {
            LoadHoaDonTheoMocThoiGian();
        }

        private void dgvHoaDon_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridViewComboBoxCell)dgvHoaDon.Rows[e.RowIndex].Cells["colNhanVienLap"]).DataSource = TaiKhoanBUS.LayDanhSachTaiKhoan();
            ((DataGridViewComboBoxCell)dgvHoaDon.Rows[e.RowIndex].Cells["colNhanVienLap"]).DisplayMember = "HoTen";
            ((DataGridViewComboBoxCell)dgvHoaDon.Rows[e.RowIndex].Cells["colNhanVienLap"]).ValueMember = "MaTaiKhoan";
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                LoadCTHD(Convert.ToInt32(dgvHoaDon.SelectedRows[0].Cells["colMaHoaDon"].Value));
            }
        }

        private void dgvHoaDon_DataSourceChanged(object sender, EventArgs e)
        {
            if (dgvHoaDon.Rows.Count > 0)
            {
                LoadCTHD(Convert.ToInt32(dgvHoaDon.Rows[0].Cells["colMaHoaDon"].Value));
            }
            else
            {
                dgvCTHD.DataSource = null;
            }
        }
    }
}
