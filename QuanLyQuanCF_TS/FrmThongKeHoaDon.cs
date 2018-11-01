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
        }

        private void LoadCTHD_Topping(int maHoaDon)
        {
            List<CTHoaDon_ToppingDTO> lsTopping = CTHoaDon_ToppingBUS.LayDanhSachCTHD_Topping(maHoaDon);
            dgvTopping.DataSource = lsTopping;
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
