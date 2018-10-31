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
    public partial class FrmCaiDat : MetroFramework.Forms.MetroForm
    {
        public FrmCaiDat()
        {
            InitializeComponent();
        }

        private static FrmCaiDat _Instance = null;

        public static FrmCaiDat Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FrmCaiDat();
                }
                return _Instance;
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            ((FrmMain)this.ParentForm).XuLyFormMain();
            this.Close();
        }

        private void FrmCaiDat_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }
    }
}
