using MetroFramework;
using MetroFramework.Forms;
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

            #region
            this.Style = FrmMain.style;
            tglTopMost.Style = FrmMain.style;
            tglTopMost.Checked = FrmMain.topMost;
            #endregion
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

        private void FrmCaiDat_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void SetThemeColor()
        {
            tglTopMost.Style = FrmMain.style;
            
            FrmMain.Instance.Style = FrmMain.style;
            FrmMain.Instance.Refresh();
            foreach (MetroForm f in FrmMain.Instance.MdiChildren)
            {
                f.Style = FrmMain.style;
                f.Refresh();
            }
            
            this.Style = FrmMain.style;
            this.Refresh();
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            FrmMain.style = MetroColorStyle.Black;
            SetThemeColor();
        }

        private void btnWhite_Click(object sender, EventArgs e)
        {
            FrmMain.style = MetroColorStyle.White;
            SetThemeColor();
        }

        private void btnSliver_Click(object sender, EventArgs e)
        {
            FrmMain.style = MetroColorStyle.Silver;
            SetThemeColor();
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            FrmMain.style = MetroColorStyle.Blue;
            SetThemeColor();
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            FrmMain.style = MetroColorStyle.Green;
            SetThemeColor();
        }

        private void brnLime_Click(object sender, EventArgs e)
        {
            FrmMain.style = MetroColorStyle.Lime;
            SetThemeColor();
        }

        private void btnTeal_Click(object sender, EventArgs e)
        {
            FrmMain.style = MetroColorStyle.Teal;
            SetThemeColor();
        }

        private void btnOrange_Click(object sender, EventArgs e)
        {
            FrmMain.style = MetroColorStyle.Orange;
            SetThemeColor();
        }

        private void btnBrown_Click(object sender, EventArgs e)
        {
            FrmMain.style = MetroColorStyle.Brown;
            SetThemeColor();
        }

        private void btnPink_Click(object sender, EventArgs e)
        {
            FrmMain.style = MetroColorStyle.Pink;
            SetThemeColor();
        }

        private void btnMagenta_Click(object sender, EventArgs e)
        {
            FrmMain.style = MetroColorStyle.Magenta;
            SetThemeColor();
        }

        private void btnPurple_Click(object sender, EventArgs e)
        {
            FrmMain.style = MetroColorStyle.Purple;
            SetThemeColor();
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            FrmMain.style = MetroColorStyle.Red;
            SetThemeColor();
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            FrmMain.style = MetroColorStyle.Yellow;
            SetThemeColor();
        }

        private void tglTopMost_CheckedChanged(object sender, EventArgs e)
        {
            if (tglTopMost.Checked)
            {
                FrmMain.topMost = true;
                FrmMain.Instance.TopMost = true;
            }
            else
            {
                FrmMain.topMost = false;
                FrmMain.Instance.TopMost = false;
            }
        }
    }
}
