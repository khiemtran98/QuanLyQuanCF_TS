using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCF_TS
{
    public partial class FrmThongKeDoanhThu : MetroFramework.Forms.MetroForm
    {
        public FrmThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private static FrmThongKeDoanhThu _Instance = null;

        public static FrmThongKeDoanhThu Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FrmThongKeDoanhThu();
                }
                return _Instance;
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            ((FrmMain)this.ParentForm).XuLyFormMain();
            this.Close();
        }

        private void FrmThongKeDoanhThu_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void FrmThongKeDoanhThu_Load(object sender, EventArgs e)
        {

           // this.reportViewer1.RefreshReport();
        }
    }
}
