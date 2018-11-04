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

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            ((FrmMain)this.ParentForm).XuLyFormMain();
            this.Close();
        }

        private void FrmThongKeHoaDon_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void FrmThongKeHoaDon_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvCTHD.AutoGenerateColumns = false;
            dgvTopping.AutoGenerateColumns = false;

            LoadHoaDon();
        }

        private void LoadHoaDon()
        {
            List<HoaDonDTO> lsHoaDon = HoaDonBUS.LayDanhSachHoaDon();
            dgvHoaDon.DataSource = lsHoaDon;
        }

        private void LoadCTHD(int maHoaDon)
        {
            List<CTHoaDonDTO> lsHoaDon = CTHoaDonBUS.LayDanhSachCTHD(maHoaDon);
            dgvCTHD.DataSource = lsHoaDon;

            if (dgvCTHD.Rows.Count > 0)
            {
                LoadCTHD_Topping(Convert.ToInt32(dgvCTHD.Rows[0].Cells["colMaCTHD"].Value));
            }
        }

        private void LoadCTHD_Topping(int maCTHD)
        {
            List<CTHoaDon_ToppingDTO> lsTopping = CTHoaDon_ToppingBUS.LayDanhSachCTHD_Topping(maCTHD);
            dgvTopping.DataSource = lsTopping;
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                LoadCTHD(Convert.ToInt32(dgvHoaDon.SelectedRows[0].Cells["colMaHoaDon"].Value));
            }
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "colNhanVienLap")
            {
                TaiKhoanDTO taiKhoan = TaiKhoanBUS.LayThongTinTaiKhoan(Convert.ToInt32(e.Value));
                e.Value = taiKhoan.HoTen;
            }
        }

        private void dgvCTHD_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridViewComboBoxCell)dgvCTHD.Rows[e.RowIndex].Cells["colMaMon"]).DataSource = MonBUS.LayDanhSachMon();
            ((DataGridViewComboBoxCell)dgvCTHD.Rows[e.RowIndex].Cells["colMaMon"]).DisplayMember = "TenMon";
            ((DataGridViewComboBoxCell)dgvCTHD.Rows[e.RowIndex].Cells["colMaMon"]).ValueMember = "MaMon";
        }

        private void dgvCTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                LoadCTHD_Topping(Convert.ToInt32(dgvCTHD.SelectedRows[0].Cells["colMaCTHD"].Value));
            }
        }

        private void dgvTopping_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridViewComboBoxCell)dgvTopping.Rows[e.RowIndex].Cells["colMaTopping"]).DataSource = ToppingBUS.LayDanhSachTopping();
            ((DataGridViewComboBoxCell)dgvTopping.Rows[e.RowIndex].Cells["colMaTopping"]).DisplayMember = "TenTopping";
            ((DataGridViewComboBoxCell)dgvTopping.Rows[e.RowIndex].Cells["colMaTopping"]).ValueMember = "MaTopping";
        }
    }
}
