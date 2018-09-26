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

        private void LoadLayout()
        {
            lsvMon.Columns.Add("Tên món", 500);
            lsvMon.Columns.Add("Giá tiền", 200, HorizontalAlignment.Right);
            lsvMon.Groups.Add(new ListViewGroup("grpCaPhe", "Cà phê"));
            lsvMon.Groups.Add(new ListViewGroup("grpTraSua", "Trà sữa"));
            lsvMon.Font = new Font("Arial", 13F);
            lsvMon.GridLines = true;
            lsvMon.FullRowSelect = lsvCTHD.FullRowSelect = true;
            lsvMon.MultiSelect = lsvCTHD.MultiSelect = false;

            DataGridViewTextBoxColumn dgvtbcTenMon = new DataGridViewTextBoxColumn();
            dgvtbcTenMon.Name = "colTenMon";
            dgvtbcTenMon.HeaderText = "Tên món";
            dgvtbcTenMon.ReadOnly = true;
            dgvtbcTenMon.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn dgvtbcSoLuong = new DataGridViewTextBoxColumn();
            dgvtbcSoLuong.Name = "colSoLuong";
            dgvtbcSoLuong.HeaderText = "Số lượng";
            dgvtbcSoLuong.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewTextBoxColumn dgvtbcDonGia = new DataGridViewTextBoxColumn();
            dgvtbcDonGia.Name = "colDonGia";
            dgvtbcDonGia.HeaderText = "Đơn giá";
            dgvtbcDonGia.ReadOnly = true;
            dgvtbcDonGia.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;

            dgvHoaDon.Columns.AddRange(dgvtbcTenMon, dgvtbcSoLuong, dgvtbcDonGia);
            dgvHoaDon.Columns["colSoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHoaDon.Columns["colDonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvHoaDon.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 15.25F);
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvHoaDon.ColumnHeadersHeight = 80;
            dgvHoaDon.RowsDefaultCellStyle.Font = new Font("Arial", 11.25F);
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.RowHeadersVisible = false;

            txtTongTien.Enabled = false;
            txtTongTien.Text = soTien.ToString("#,##0 VND");
            lsvMon.View = lsvCTHD.View = View.Details;

            //lsvCTHD.Columns.Add("Tên món", 200);
            //lsvCTHD.Columns.Add("Số lượng", 100);
            //lsvCTHD.Columns.Add("Giá tiền", 100, HorizontalAlignment.Right);
        }

        private void lapHoaDon()
        {
            MessageBox.Show("Chức năng này đang được xây dựng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //private void CongTienHoaDon(double giaTien)
        //{
        //    soTien += giaTien;
        //    txtTongTien.Text = soTien.ToString("#,##0 VND");
        //}

        //private void TruTienHoaDon(double giaTien)
        //{
        //    soTien -= giaTien;
        //    txtTongTien.Text = soTien.ToString("#,##0 VND");
        //}

        private void TinhTienHoaDon()
        {
            double tongTien = 0;

            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                tongTien += Convert.ToDouble(row.Cells[2].Value);
            }

            txtTongTien.Text = tongTien.ToString("#,##0 VND");
        }

        private void CapNhatHoaDon()
        {
            DataGridViewRow row = dgvHoaDon.SelectedRows[0];

            int soLuong = Convert.ToInt32(row.Cells[1].Value);
            double DonGia = 0;

            foreach (ListViewItem lvi in lsvMon.Items)
            {
                if (lvi.SubItems[0].Text == row.Cells[0].Value.ToString())
                {
                    MonDTO mon = (MonDTO)lvi.Tag;
                    DonGia += mon.GiaTien;
                }
            }

            row.Cells[2].Value = (soLuong * DonGia).ToString("#,###");
            TinhTienHoaDon();
        }

        private void FrmBanHang_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = this.MinimizeBox = false;
            this.WindowState = FormWindowState.Maximized;

            LoadLayout();

            ImageList imlMon = new ImageList();
            imlMon.ColorDepth = ColorDepth.Depth32Bit;
            imlMon.ImageSize = new Size(64, 64);
            lsvMon.SmallImageList = imlMon;

            List<MonDTO> dsMon = MonBUS.layDanhSachMon();
            for (int i = 0; i < dsMon.Count; i++)
            {
                MonDTO mon = dsMon[i];
                ListViewItem lvi = new ListViewItem(mon.TenMon);
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
                    lvi.Group = lsvMon.Groups["grpCaPhe"];
                }
                else
                {
                    lvi.Group = lsvMon.Groups["grpTraSua"];
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
                if (dgvHoaDon.Rows.Count == 0)
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

                    //ListViewItem lvi = new ListViewItem(mon.TenMon);
                    //lvi.SubItems.Add(mon.LoaiMon.ToString());
                    //lvi.SubItems.Add(mon.GiaTien.ToString("#,##0 VND"));
                    //lvi.Tag = mon;
                    //lsvCTHD.Items.Add(lvi);

                    DataGridViewRow rowMon = new DataGridViewRow();
                    rowMon.Height = 50;
                    rowMon.Cells.Add(new DataGridViewTextBoxCell { Value = mon.TenMon });
                    rowMon.Cells.Add(new DataGridViewTextBoxCell { Value = 1 });
                    rowMon.Cells.Add(new DataGridViewTextBoxCell { Value = mon.GiaTien.ToString("#,###") });

                    if (dgvHoaDon.Rows.Count == 0)
                    {
                        dgvHoaDon.Rows.Add(rowMon);
                        //CongTienHoaDon(mon.GiaTien);
                        TinhTienHoaDon();
                        return;
                    }

                    foreach (DataGridViewRow row in dgvHoaDon.Rows)
                    {
                        if (row.Cells[0].Value == rowMon.Cells[0].Value)
                        {
                            int soLuong = Convert.ToInt32(row.Cells[1].Value);

                            double donGia = Convert.ToDouble(row.Cells[2].Value);
                            double donGiaCongThem = Convert.ToDouble(rowMon.Cells[2].Value);

                            row.Cells[1].Value = soLuong + 1;
                            row.Cells[2].Value = (donGia + donGiaCongThem).ToString("#,###");

                            //CongTienHoaDon(mon.GiaTien);
                            TinhTienHoaDon();

                            return;
                        }
                    }

                    dgvHoaDon.Rows.Add(rowMon);
                    //CongTienHoaDon(mon.GiaTien);
                    TinhTienHoaDon();
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

                    //TruTienHoaDon(mon.GiaTien);
                    TinhTienHoaDon();
                }
            }
        }

        private void dgvHoaDon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvHoaDon.SelectedRows[0];
            int soLuong;
            try
            {
                soLuong = Convert.ToInt32(row.Cells[1].Value);
                if (soLuong == 0)
                {
                    MessageBox.Show("Số lượng không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    row.Cells[1].Value = 1;
                }
                else
                {
                    CapNhatHoaDon();
                }
            }
            catch
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                row.Cells[1].Value = 1;
            }
        }
    }
}