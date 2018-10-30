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
    public partial class FrmNhapHang : MetroFramework.Forms.MetroForm
    {
        public FrmNhapHang()
        {
            InitializeComponent();
        }

        private static FrmNhapHang _Instance = null;

        public static FrmNhapHang Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FrmNhapHang();
                }
                return _Instance;
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            ((FrmMain)this.ParentForm).XuLyFormMain();
            this.Close();
        }

        private void FrmNhapHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }
    }
}
