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
    public partial class FrmQuanLyHoaDon : Form
    {
        private static FrmQuanLyHoaDon _Instance = null;

        public FrmQuanLyHoaDon()
        {
            InitializeComponent();
        }

        public static FrmQuanLyHoaDon Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FrmQuanLyHoaDon();
                }
                return _Instance;
            }
        }

        private void FrmQuanLyHoaDon_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void FrmQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = this.MinimizeBox = false;
            this.WindowState = FormWindowState.Maximized;
        }

        private void FrmQuanLyHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn quay lại màn hình chính?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    ((FrmMain)this.ParentForm).xuLyFormMain();
                    this.Close();
                }
            }
        }
    }
}
