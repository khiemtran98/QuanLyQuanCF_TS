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
    }
}
