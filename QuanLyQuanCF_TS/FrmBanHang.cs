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

        private void ThemLuaChonTatCa()
        {
            MaterialSkin.Controls.MaterialFlatButton btnTatCa = new MaterialSkin.Controls.MaterialFlatButton();
            btnTatCa.Text = "Tất cả" + " (" + MonBUS.LaySoLuongMonTheoLoai(0) + ")"; ;
            btnTatCa.Name = "0";
            btnTatCa.AutoSize = false;
            btnTatCa.Size = new Size(140, 60);
            btnTatCa.Dock = DockStyle.Left;
            btnTatCa.Click += new EventHandler(ChonLoai);
            panelLoai.Controls.Add(btnTatCa);
        }

        private void LayDanhSachLoaiMon()
        {
            List<LoaiMonDTO> dsLoaiMon = LoaiMonBUS.LayDanhSachLoaiMon();
            foreach (LoaiMonDTO loaiMon in dsLoaiMon)
            {
                MaterialSkin.Controls.MaterialFlatButton btn = new MaterialSkin.Controls.MaterialFlatButton();
                btn.Text = loaiMon.TenLoaiMon + " (" + MonBUS.LaySoLuongMonTheoLoai(loaiMon.MaLoaiMon) + ")";
                btn.Name = loaiMon.MaLoaiMon.ToString();
                btn.AutoSize = false;
                btn.Size = new Size(140, 60);
                btn.Dock = DockStyle.Left;
                btn.Tag = loaiMon;
                btn.Click += new EventHandler(ChonLoai);
                panelLoai.Controls.Add(btn);
                btn.BringToFront();
            }
            ThemLuaChonTatCa();
        }

        private void LayDanhSachMon(List<MonDTO> dsMon)
        {
            for (int i = 0; i < dsMon.Count; i++)
            {
                MonDTO mon = dsMon[i];
                ListViewItem lvi = new ListViewItem(mon.TenMon);
                lvi.SubItems.Add(mon.GiaTien.ToString("#,##0 VND"));
                lsvMenu.LargeImageList.Images.Add(Image.FromFile("img\\" + mon.Hinh));
                lvi.Group = lsvMenu.Groups[mon.LoaiMon.ToString()];
                lvi.ImageIndex = i;
                lvi.Tag = mon;
                lsvMenu.Items.Add(lvi);
            }
        }

        private void LayDanhSachLoaiTopping(int maLoaiMon)
        {
            List<LoaiToppingDTO> dsLoaiTopping = LoaiToppingBUS.LayDanhSachLoaiTopping(maLoaiMon);
            foreach (LoaiToppingDTO loaiTopping in dsLoaiTopping)
            {
                MaterialSkin.Controls.MaterialFlatButton btn = new MaterialSkin.Controls.MaterialFlatButton();
                btn.Text = loaiTopping.TenLoaiTopping + " (" + ToppingBUS.LaySoLuongToppingTheoLoai(loaiTopping.MaLoaiTopping) + ")";
                btn.Name = loaiTopping.MaLoaiTopping.ToString();
                btn.AutoSize = false;
                btn.Size = new Size(140, 60);
                btn.Dock = DockStyle.Left;
                btn.Tag = loaiTopping;
                btn.Click += new EventHandler(ChonLoai);
                panelLoai.Controls.Add(btn);
                btn.BringToFront();
            }
        }

        private void LayDanhSachTopping(List<ToppingDTO> dsTopping)
        {
            for (int i = 0; i < dsTopping.Count; i++)
            {
                ToppingDTO topping = dsTopping[i];
                ListViewItem lvi = new ListViewItem(topping.TenTopping);
                lvi.SubItems.Add(topping.GiaTien.ToString("#,##0 VND"));
                lvi.Tag = topping;
                lsvMenu.Items.Add(lvi);
            }
        }

        public DataGridViewRowCollection LayThongTinHoaDon()
        {
            return dgvHoaDon.Rows;
        }

        private void LapHoaDon()
        {
            panelHoaDon.Visible = panelLoai.Visible = panelMenu.Visible = panelThanhToan.Visible = false;
            splitContainer1.Visible = false;
            ucXemLaiHoaDon uc = ucXemLaiHoaDon.Instance;
            uc.Dock = DockStyle.Fill;
            panelLayout.Controls.Add(uc);

            int soLuongMon = 0;
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.Tag.GetType() == typeof(MonDTO))
                {
                    soLuongMon += Convert.ToInt32(row.Cells["colSoLuong"].Value);
                }
            }
            uc.LoadThongTinHoaDon(soLuongMon, TinhThanhTien());
        }

        public double TinhThanhTien()
        {
            double tongTien = 0;
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                tongTien += Convert.ToDouble(row.Cells["colSoLuong"].Value) * Convert.ToDouble(row.Cells["colDonGia"].Value);
            }
            return tongTien;
        }

        public void QuayLaiManHinhChonMon(bool luuThanhCong = false)
        {
            panelHoaDon.Visible = panelLoai.Visible = panelMenu.Visible = panelThanhToan.Visible = true;
            splitContainer1.Visible = true;
            if (luuThanhCong) // Clear bảng hoá đơn nếu đã thanh toán
            {
                dgvHoaDon.Rows.Clear();
            }
        }

        private void QuayLaiManHinhChinh()
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn quay lại màn hình chính?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                // Xoá bộ nhớ ucXemLaiHoaDon
                panelLayout.Controls.Clear();
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
            TaoGroup();
        }

        private void TaoGroup()
        {
            foreach (LoaiMonDTO loaiMon in LoaiMonBUS.LayDanhSachLoaiMon())
            {
                lsvMenu.Groups.Add(loaiMon.MaLoaiMon.ToString(), loaiMon.TenLoaiMon);
            }
        }

        private int loaiDangChon = -1;

        private void ChonLoai(object sender, EventArgs e)
        {
            loaiDangChon = (Convert.ToInt32(((Button)sender).Name));
            lsvMenu.Items.Clear();
            lsvMenu.LargeImageList.Images.Clear();
            if (radMenuMon.Checked)
            {
                List<MonDTO> dsMon = MonBUS.LayDanhSachMonTheoLoai((Convert.ToInt32(((Button)sender).Name)));
                LayDanhSachMon(dsMon);
            }
            else
            {
                List<ToppingDTO> dsTopping = ToppingBUS.LayDanhSachToppingTheoLoai((Convert.ToInt32(((Button)sender).Name)));
                LayDanhSachTopping(dsTopping);
            }

        }

        private void FrmBanHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private int LayThuTuToppingCuoiCungCuaMon()
        {
            int toppingRangeIndex = dgvHoaDon.SelectedRows[0].Index;
            for (int i = dgvHoaDon.SelectedRows[0].Index + 1; i < dgvHoaDon.Rows.Count; i++)
            {
                DataGridViewRow row = dgvHoaDon.Rows[i];
                if (row.Tag.GetType() == typeof(ToppingDTO))
                {
                    toppingRangeIndex = row.Index;
                }
                else
                {
                    toppingRangeIndex = row.Index - 1;
                    break;
                }
            }
            return toppingRangeIndex;
        }

        private int TongSoLuongToppingCuaMonDangChon(int toppingRangeIndex)
        {
            int result = 0;
            for (int i = dgvHoaDon.SelectedRows[0].Index + 1; i <= toppingRangeIndex; i++)
            {
                result += Convert.ToInt32(dgvHoaDon.Rows[i].Cells["colSoLuong"].Value);
            }
            return result;
        }

        private void lsvMon_Click(object sender, EventArgs e)
        {
            if (radMenuMon.Checked)
            {
                if (lsvMenu.SelectedItems.Count == 1)
                {
                    MonDTO mon = (MonDTO)lsvMenu.SelectedItems[0].Tag;

                    DataGridViewRow rowMon = new DataGridViewRow();
                    rowMon.DefaultCellStyle.BackColor = Color.AliceBlue;
                    rowMon.Height = 50;
                    rowMon.Tag = mon;
                    rowMon.Cells.Add(new DataGridViewTextBoxCell { Value = mon.TenMon });
                    rowMon.Cells.Add(new DataGridViewTextBoxCell { Value = 1 });
                    rowMon.Cells.Add(new DataGridViewTextBoxCell { Value = mon.GiaTien.ToString("#,###") });

                    if (MonBUS.KiemTraMonLaNuocUong(mon.LoaiMon))
                    {
                        rowMon.Cells.Add(new DataGridViewTextBoxCell { Value = "Đá: 100%\n Đường: 100%" });
                    }

                    // Thêm món vào hoá đơn nếu hoá đơn chưa có món nào
                    if (dgvHoaDon.Rows.Count == 0)
                    {
                        dgvHoaDon.Rows.Add(rowMon);
                        TinhThanhTien();
                        lblThanhTien.Text = TinhThanhTien().ToString("#,##0đ");
                        btnThanhToan.Enabled = true;
                        btnThanhToan.BackColor = Color.LimeGreen;
                        return;
                    }

                    // Duyệt qua toàn bộ danh sách hoá đơn
                    foreach (DataGridViewRow rowHD in dgvHoaDon.Rows)
                    {
                        if (rowHD.Tag.GetType() == typeof(MonDTO))
                        {
                            // Tăng số lương món trong hoá đơn nếu hoá đơn đã có món đó
                            if (((MonDTO)rowHD.Tag).MaMon == mon.MaMon)
                            {
                                int soLuong = Convert.ToInt32(rowHD.Cells["colSoLuong"].Value);
                                rowHD.Cells["colSoLuong"].Value = soLuong + 1;
                                TinhThanhTien();
                                return;
                            }
                        }
                    }

                    // Thêm món vào hoá đơn nếu hoá đơn chưa có món đó
                    dgvHoaDon.Rows.Add(rowMon);
                    lblThanhTien.Text = TinhThanhTien().ToString("#,##0đ");
                }
            }
            else
            {
                if (lsvMenu.SelectedItems.Count == 1)
                {
                    ToppingDTO topping = (ToppingDTO)lsvMenu.SelectedItems[0].Tag;

                    DataGridViewRow rowTopping = new DataGridViewRow();
                    rowTopping.DefaultCellStyle.BackColor = Color.Beige;
                    rowTopping.Height = 25;
                    rowTopping.Tag = topping;
                    rowTopping.Cells.Add(new DataGridViewTextBoxCell { Value = topping.TenTopping });
                    rowTopping.Cells.Add(new DataGridViewTextBoxCell { Value = 1 });
                    rowTopping.Cells.Add(new DataGridViewTextBoxCell { Value = topping.GiaTien.ToString("#,###") });
                    rowTopping.Cells.Add(new DataGridViewTextBoxCell { Value = string.Empty });

                    // Lấy thứ tự topping cuối cùng của món đang chọn trong hoá đon
                    int toppingRangeIndex = LayThuTuToppingCuoiCungCuaMon();

                    // Duyệt qua toàn bộ các topping của món đang chọn
                    for (int i = dgvHoaDon.SelectedRows[0].Index + 1; i <= toppingRangeIndex; i++)
                    {
                        if (dgvHoaDon.Rows[i].Tag.GetType() == typeof(ToppingDTO))
                        {
                            // Tăng số lượng topping
                            if (((ToppingDTO)dgvHoaDon.Rows[i].Tag).MaTopping == topping.MaTopping)
                            {
                                // Chỉ tăng khi tổng số topping ít hơn số lượng món
                                if (Convert.ToInt32(dgvHoaDon.SelectedRows[0].Cells["colSoLuong"].Value) > TongSoLuongToppingCuaMonDangChon(toppingRangeIndex))
                                {
                                    int soLuong = Convert.ToInt32(dgvHoaDon.Rows[i].Cells["colSoLuong"].Value);
                                    dgvHoaDon.Rows[i].Cells["colSoLuong"].Value = soLuong + 1;
                                    TinhThanhTien();
                                    return;
                                }
                            }
                        }
                    }

                    // Thêm topping vào món nếu chưa có
                    // Chỉ thêm khi tổng số topping ít hơn số lượng món
                    if (Convert.ToInt32(dgvHoaDon.SelectedRows[0].Cells["colSoLuong"].Value) > TongSoLuongToppingCuaMonDangChon(toppingRangeIndex))
                    {
                        dgvHoaDon.Rows.Insert(dgvHoaDon.SelectedRows[0].Index + 1, rowTopping);
                        TinhThanhTien();
                        lblThanhTien.Text = TinhThanhTien().ToString("#,##0đ");
                    }
                }
            }
        }

        private void dgvHoaDon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgvHoaDon.SelectedRows[0];
                try
                {
                    int soLuong = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                    if (soLuong == 0)
                    {
                        MessageBox.Show("Số lượng không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        row.Cells["colSoLuong"].Value = 1;
                    }
                    else
                    {
                        lblThanhTien.Text = TinhThanhTien().ToString("#,##0đ");
                    }
                }
                catch
                {
                    MessageBox.Show("Số lượng không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    row.Cells["colSoLuong"].Value = 1;
                }
            }
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            // Nếu hoá đơn đang chọn món thì menu hiện topping tương ứng
            if (dgvHoaDon.SelectedRows[0].Tag.GetType() == typeof(MonDTO) && radMenuTopping.Checked)
            {
                panelLoai.Controls.Clear();
                LayDanhSachLoaiTopping(((MonDTO)dgvHoaDon.SelectedRows[0].Tag).LoaiMon);

                // Kiểm tra màn hình topping hiện đúng với món đang chọn
                if (lsvMenu.Items.Count > 0)
                {
                    bool toppingCheck = false;
                    foreach (MaterialSkin.Controls.MaterialFlatButton btn in panelLoai.Controls)
                    {
                        if (((LoaiToppingDTO)btn.Tag).MaLoaiTopping == ((ToppingDTO)lsvMenu.Items[0].Tag).LoaiTopping)
                        {
                            toppingCheck = true;
                            break;
                        }
                    }
                    if (!toppingCheck)
                    {
                        loaiDangChon = -1;
                        lsvMenu.Items.Clear();
                        lsvMenu.LargeImageList.Images.Clear();
                    }
                }

                return;
            }

            // Nếu hoá đơn đang chọn topping thì menu không hiện gì hết
            if (dgvHoaDon.SelectedRows[0].Tag.GetType() == typeof(ToppingDTO) && radMenuTopping.Checked)
            {
                loaiDangChon = -1;
                panelLoai.Controls.Clear();
                lsvMenu.Items.Clear();
                lsvMenu.LargeImageList.Images.Clear();
            }
        }

        private void dgvHoaDon_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            radMenuTopping.Enabled = true;
        }

        private void dgvHoaDon_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblThanhTien.Text = TinhThanhTien().ToString("#,##0đ");
            if (dgvHoaDon.Rows.Count == 0)
            {
                btnThanhToan.BackColor = Color.Gray;
                btnThanhToan.Enabled = false;
                radMenuMon.Checked = true;
                radMenuTopping.Enabled = false;
            }
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                lsvMenu.Items.Clear();
                lsvMenu.LargeImageList.Images.Clear();

                // Tìm kiếm món
                if (radMenuMon.Checked)
                {
                    List<MonDTO> dsMon = MonBUS.LayDanhSachMonTheoLoai(loaiDangChon, txtTimKiem.Text);
                    LayDanhSachMon(dsMon);
                }

                // Tìm kiếm topping
                else
                {
                    List<ToppingDTO> dsTopping = ToppingBUS.LayDanhSachToppingTheoLoai(loaiDangChon, txtTimKiem.Text);
                    LayDanhSachTopping(dsTopping);
                }
            }
        }

        private void radMenuMon_CheckedChanged(object sender, EventArgs e)
        {
            if (radMenuMon.Checked)
            {
                loaiDangChon = -1;
                lsvMenu.Items.Clear();
                lsvMenu.LargeImageList.Images.Clear();
                panelLoai.Controls.Clear();
                LayDanhSachLoaiMon();
            }
        }

        private void radMenuTopping_CheckedChanged(object sender, EventArgs e)
        {
            if (radMenuTopping.Checked)
            {
                loaiDangChon = -1;
                lsvMenu.Items.Clear();
                lsvMenu.LargeImageList.Images.Clear();
                panelLoai.Controls.Clear();

                // Nếu hoá đơn đang chọn món thì menu mới hiện topping tương ứng
                if (dgvHoaDon.SelectedRows[0].Tag.GetType() == typeof(MonDTO))
                {
                    LayDanhSachLoaiTopping(((MonDTO)dgvHoaDon.SelectedRows[0].Tag).LoaiMon);
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            LapHoaDon();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            QuayLaiManHinhChinh();
        }

        private void dgvHoaDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 1)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (dgvHoaDon.SelectedRows[0].Tag.GetType() == typeof(MonDTO))
                    {
                        // Lấy thứ tự topping cuối cùng của món đang chọn trong hoá đon
                        int toppingRangeIndex = LayThuTuToppingCuoiCungCuaMon();

                        if (toppingRangeIndex == dgvHoaDon.SelectedRows[0].Index)
                        {
                            dgvHoaDon.Rows.RemoveAt(dgvHoaDon.SelectedRows[0].Index);
                        }
                        else
                        {
                            // Xoá tuần tự topping và món
                            int i = dgvHoaDon.SelectedRows[0].Index;
                            while (toppingRangeIndex != i)
                            {
                                dgvHoaDon.Rows.RemoveAt(i);
                                toppingRangeIndex--;
                            }
                            dgvHoaDon.Rows.RemoveAt(i);
                        }
                    }
                    else
                    {
                        dgvHoaDon.Rows.RemoveAt(dgvHoaDon.SelectedRows[0].Index);
                    }
                }
            }
        }
    }
}
