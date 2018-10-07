using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace QuanLyQuanCF_TS
{
    public partial class ucXemLaiHoaDon : MetroFramework.Controls.MetroUserControl
    {
        public ucXemLaiHoaDon()
        {
            InitializeComponent();
        }

        private static ucXemLaiHoaDon _Instance = null;

        public static ucXemLaiHoaDon Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ucXemLaiHoaDon();
                }
                return _Instance;
            }
        }

        private void ucXemLaiHoaDon_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này đang được xây dựng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ((FrmBanHang)this.FindForm()).QuayLaiManHinhChonMon();
            _Instance = null;
        }
    }
}
