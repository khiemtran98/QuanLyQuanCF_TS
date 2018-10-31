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
    public partial class FrmQuanLyKho : MetroFramework.Forms.MetroForm
    {
        public FrmQuanLyKho()
        {
            InitializeComponent();
        }

        private static FrmQuanLyKho _Instance = null;

        public static FrmQuanLyKho Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FrmQuanLyKho();
                }
                return _Instance;
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            ((FrmMain)this.ParentForm).XuLyFormMain();
            this.Close();
        }

        private void FrmQuanLyKho_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }
    }
}
