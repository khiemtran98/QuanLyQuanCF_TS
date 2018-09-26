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
    public partial class FrmBanHang : Form
    {
        private double soTien = 0;

        private static FrmBanHang _Instance = null;

        public FrmBanHang()
        {
            InitializeComponent();
        }

        public static FrmBanHang Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FrmBanHang();
                }
                return _Instance;
            }
        }

        private void FrmBanHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void lapHoaDon()
        {
            MessageBox.Show("Chức năng này đang được xây dựng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CongTienHoaDon(double giaTien)
        {
            soTien += giaTien;
            txtTongTien.Text = soTien.ToString("#,##0 VND");
        }

        private void TruTienHoaDon(double giaTien)
        {
            soTien -= giaTien;
            txtTongTien.Text = soTien.ToString("#,##0 VND");
        }

        private void FrmBanHang_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = this.MinimizeBox = false;
            this.WindowState = FormWindowState.Maximized;

            txtTongTien.Enabled = false;
            txtTongTien.Text = soTien.ToString("#,##0 VND");
            lsvMon.View = lsvCTHD.View = View.Details;

            lsvMon.FullRowSelect = lsvCTHD.FullRowSelect = true;
            lsvMon.MultiSelect = lsvCTHD.MultiSelect = false;

            lsvMon.Columns.Add("Tên món", 300);
            lsvMon.Columns.Add("Loại món", 100);
            lsvMon.Columns.Add("Giá tiền", 100, HorizontalAlignment.Right);

            lsvCTHD.Columns.Add("Tên món", 200);
            lsvCTHD.Columns.Add("Loại món", 100);
            lsvCTHD.Columns.Add("Giá tiền", 100, HorizontalAlignment.Right);

            lsvMon.Groups.Add(new ListViewGroup("Cà phê", HorizontalAlignment.Left));
            lsvMon.Groups.Add(new ListViewGroup("Trà sữa", HorizontalAlignment.Left));

            ImageList imlMon = new ImageList();
            imlMon.ColorDepth = ColorDepth.Depth32Bit;
            imlMon.ImageSize = new Size(64, 64);
            lsvMon.SmallImageList = imlMon;

            List<MonDTO> dsMon = MonBUS.layDanhSachMon();
            for (int i = 0; i < dsMon.Count; i++)
            {
                MonDTO mon = dsMon[i];
                ListViewItem lvi = new ListViewItem(mon.TenMon);
                lvi.SubItems.Add(mon.LoaiMon.ToString());
                lvi.SubItems.Add(mon.GiaTien.ToString("#,##0 VND"));
                try
                {
                    imlMon.Images.Add(Image.FromFile("hinh\\" + mon.Hinh));
                }
                catch
                {
                    
                }
                lvi.ImageIndex = i;
                if (mon.LoaiMon == 1)
                {
                    lvi.Group = lsvMon.Groups[0];
                }
                else
                {
                    lvi.Group = lsvMon.Groups[1];
                };
                lvi.Tag = mon;
                lsvMon.Items.Add(lvi);
            }
        }

        private void FrmBanHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn quay lại màn hình chính?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    ((FrmMain)this.ParentForm).xuLyFormMain();
                    this.Close();
                }
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (lsvCTHD.Items.Count == 0)
                {
                    MessageBox.Show("Bạn chưa thêm món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    lapHoaDon();
                }
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            lapHoaDon();
        }

        private void lsvMon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                if (lsvMon.SelectedItems.Count == 1)
                {
                    MonDTO mon = (MonDTO)lsvMon.SelectedItems[0].Tag;
                    ListViewItem lvi = new ListViewItem(mon.TenMon);
                    lvi.SubItems.Add(mon.LoaiMon.ToString());
                    lvi.SubItems.Add(mon.GiaTien.ToString("#,##0 VND"));
                    lvi.Tag = mon;
                    lsvCTHD.Items.Add(lvi);

                    CongTienHoaDon(mon.GiaTien);
                }
            }
        }

        private void lsvCTHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                if (lsvCTHD.SelectedItems.Count == 1)
                {
                    MonDTO mon = (MonDTO)lsvCTHD.SelectedItems[0].Tag;
                    ListViewItem lvi = lsvCTHD.SelectedItems[0];
                    lsvCTHD.Items.Remove(lvi);

                    TruTienHoaDon(mon.GiaTien);
                }
            }
        }
    }
}
