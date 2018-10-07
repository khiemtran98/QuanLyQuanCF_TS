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
    public partial class FrmBanHang : MetroFramework.Forms.MetroForm
    {
        public FrmBanHang()
        {
            InitializeComponent();
        }

        private static FrmBanHang _Instance = null;

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

        private void LayDanhSachLoaiMon()
        {
            List<LoaiMonDTO> dsLoaiMon = LoaiMonBUS.LayDanhSachLoaiMon();
            foreach (LoaiMonDTO loaiMon in dsLoaiMon)
            {
                MaterialSkin.Controls.MaterialFlatButton btn = new MaterialSkin.Controls.MaterialFlatButton();
                btn.Text = loaiMon.TenLoaiMon;
                btn.AutoSize = false;
                btn.Size = new Size(140, 60);
                btn.Dock = DockStyle.Left;
                btn.Click += new EventHandler(ChonLoaiMon);
                panelLoaiMon.Controls.Add(btn);
                btn.BringToFront();
            }
        }

        private void LayDanhSachMon(List<MonDTO> dsMon)
        {
            for (int i = 0; i < dsMon.Count; i++)
            {
                MonDTO mon = dsMon[i];
                ListViewItem lvi = new ListViewItem(mon.TenMon);
                lvi.SubItems.Add(mon.GiaTien.ToString("#,##0 VND"));
                lsvMon.LargeImageList.Images.Add(Image.FromFile("img\\" + mon.Hinh));
                lvi.ImageIndex = i;
                lvi.Tag = mon;
                lsvMon.Items.Add(lvi);
            }
        }

        private void LapHoaDon()
        {
            panelHoaDon.Visible = panelLoaiMon.Visible = panelMenu.Visible = panelThanhToan.Visible = false;
            splitContainer1.Visible = false;
            ucXemLaiHoaDon uc = ucXemLaiHoaDon.Instance;
            uc.Dock = DockStyle.Fill;
            panelLayout.Controls.Add(uc);
        }

        private void TinhThanhTien()
        {
            double tongTien = 0;
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                tongTien += Convert.ToDouble(row.Cells[1].Value);
            }
            lblThanhTien.Text = tongTien.ToString("#,##0đ");
        }

        public void QuayLaiManHinhChonMon()
        {
            panelHoaDon.Visible = panelLoaiMon.Visible = panelMenu.Visible = panelThanhToan.Visible = true;
            splitContainer1.Visible = true;
        }

        private void QuayLaiManHinhChinh()
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn quay lại màn hình chính?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                ((FrmMain)this.ParentForm).XuLyFormMain();
                this.Close();
            }
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Tìm kiếm tên món")
            {
                txtTimKiem.Text = string.Empty;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == string.Empty)
            {
                txtTimKiem.Text = "Tìm kiếm tên món";
            }
        }

        private void FrmBanHang_Load(object sender, EventArgs e)
        {
            LayDanhSachLoaiMon();
        }

        private void ChonLoaiMon(object sender, EventArgs e)
        {
            lsvMon.Items.Clear();
            lsvMon.LargeImageList.Images.Clear();
            List<MonDTO> dsMon = MonBUS.LayDanhSachMonTheoLoai(((Button)sender).Text);
            for (int i = 0; i < dsMon.Count; i++)
            {
                MonDTO mon = dsMon[i];
                ListViewItem lvi = new ListViewItem(mon.TenMon);
                lvi.SubItems.Add(mon.GiaTien.ToString("#,##0 VND"));
                lsvMon.LargeImageList.Images.Add(Image.FromFile("img\\" + mon.Hinh));
                lvi.ImageIndex = i;
                lvi.Group = lsvMon.Groups[mon.LoaiMon.ToString()];
                lvi.Tag = mon;
                lsvMon.Items.Add(lvi);
            }
        }

        private void FrmBanHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void lsvMon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                if (lsvMon.SelectedItems.Count == 1)
                {
                    MonDTO mon = (MonDTO)lsvMon.SelectedItems[0].Tag;

                    DataGridViewRow rowMon = new DataGridViewRow();
                    rowMon.Height = 50;
                    rowMon.Cells.Add(new DataGridViewTextBoxCell { Value = mon.TenMon });
                    rowMon.Cells.Add(new DataGridViewTextBoxCell { Value = mon.GiaTien.ToString("#,###") });

                    dgvHoaDon.Rows.Add(rowMon);
                    TinhThanhTien();
                }
            }
        }

        private void dgvHoaDon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 1)
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
                        TinhThanhTien();
                    }
                }
                catch
                {
                    MessageBox.Show("Số lượng không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    row.Cells[1].Value = 1;
                }
            }
        }

        private void dgvHoaDon_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            TinhThanhTien();
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                lsvMon.Items.Clear();
                lsvMon.LargeImageList.Images.Clear();
                List<MonDTO> dsMon = MonBUS.LayDanhSachMon(txtTimKiem.Text);
                for (int i = 0; i < dsMon.Count; i++)
                {
                    MonDTO mon = dsMon[i];
                    ListViewItem lvi = new ListViewItem(mon.TenMon);
                    lvi.SubItems.Add(mon.GiaTien.ToString("#,##0 VND"));
                    lsvMon.LargeImageList.Images.Add(Image.FromFile("img\\" + mon.Hinh));
                    lvi.ImageIndex = i;
                    lvi.Group = lsvMon.Groups[mon.LoaiMon.ToString()];
                    lvi.Tag = mon;
                    lsvMon.Items.Add(lvi);
                }
            }
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            LapHoaDon();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            QuayLaiManHinhChinh();
        }
    }
}
