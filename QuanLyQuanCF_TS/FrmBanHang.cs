using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;
using BUS;
using DTO;

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

        private void FrmBanHang_Load(object sender, EventArgs e)
        {
            LayDanhSachLoaiMon();
            TaiDuLieu();
        }

        private int loaiDangChon = 0;

        public DataGridViewRowCollection LayThongTinHoaDon()
        {
            return dgvHoaDon.Rows;
        }

        private void LayDanhSachLoaiMon()
        {
            List<LoaiMonDTO> dsLoaiMon = LoaiMonBUS.LayDanhSachLoaiMon();
            foreach (LoaiMonDTO loaiMon in dsLoaiMon)
            {
                MaterialFlatButton btn = new MaterialFlatButton();
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

            MaterialFlatButton btnTatCa = new MaterialFlatButton();
            btnTatCa.Text = "Tất cả" + " (" + MonBUS.LaySoLuongMonTheoLoai(0) + ")"; ;
            btnTatCa.Name = "0";
            btnTatCa.AutoSize = false;
            btnTatCa.Size = new Size(140, 60);
            btnTatCa.Dock = DockStyle.Left;
            btnTatCa.Tag = new LoaiMonDTO();
            btnTatCa.Click += new EventHandler(ChonLoai);
            panelLoai.Controls.Add(btnTatCa);
        }

        private void TaiDuLieu()
        {
            for (int i = 0; i < panelLoai.Controls.Count; i++)
            {
                Control ctrl = panelLoai.Controls[i];
                if (ctrl.GetType() == typeof(MaterialFlatButton))
                {
                    if (ctrl.Tag.GetType() == typeof(LoaiMonDTO))
                    {
                        ImageList iml = new ImageList();
                        iml.ColorDepth = ColorDepth.Depth32Bit;
                        iml.ImageSize = new Size(64, 64);

                        ListView lsv = new ListView();
                        lsv.Tag = ctrl.Tag;
                        lsv.LargeImageList = iml;
                        lsv.Name = ctrl.Name;
                        lsv.ShowGroups = true;
                        lsv.TileSize = new Size(230, 100);
                        lsv.GridLines = true;
                        lsv.FullRowSelect = true;
                        lsv.View = View.Tile;
                        lsv.Dock = DockStyle.Fill;
                        lsv.Font = new Font("Segoe UI", 14.25F);
                        TaoGroupMon(lsv);
                        lsv.Columns.Add("Tên món");
                        lsv.Columns.Add("Đơn giá");

                        lsv.Click += new EventHandler(ThemMon);

                        List<MonDTO> lsMon = MonBUS.LayDanhSachMon(Convert.ToInt32(lsv.Name));
                        LayDanhSachMon(lsv, lsMon);
                        panelMenu.Controls.Add(lsv);
                    }
                }
            }

            List<LoaiToppingDTO> lsLoaiTopping = LoaiToppingBUS.LayDanhSachLoaiTopping();
            foreach (LoaiToppingDTO loaiTopping in lsLoaiTopping)
            {
                ImageList iml = new ImageList();
                iml.ColorDepth = ColorDepth.Depth32Bit;
                iml.ImageSize = new Size(80, 80);

                ListView lsv = new ListView();
                lsv.Tag = loaiTopping;
                lsv.LargeImageList = iml;
                lsv.Name = loaiTopping.MaLoaiTopping + "";
                lsv.ShowGroups = true;
                lsv.TileSize = new Size(230, 100);
                lsv.GridLines = true;
                lsv.FullRowSelect = true;
                lsv.View = View.Tile;
                lsv.Dock = DockStyle.Fill;
                lsv.Font = new Font("Segoe UI", 14.25F);
                TaoGroupTopping(lsv);
                lsv.Columns.Add("Tên món");
                lsv.Columns.Add("Đơn giá");

                lsv.Click += new EventHandler(ThemTopping);

                List<ToppingDTO> lsTopping = ToppingBUS.LayDanhSachTopping(loaiTopping.MaLoaiTopping);
                LayDanhSachTopping(lsv, lsTopping);
                panelMenu.Controls.Add(lsv);
            }

            panelMenu.Controls["0"].Visible = true;
            panelMenu.Controls["0"].BringToFront();
        }

        private void ChonLoai(object sender, EventArgs e)
        {
            loaiDangChon = Convert.ToInt32(((MaterialFlatButton)sender).Name);
            foreach (Control ctrl in panelMenu.Controls)
            {
                if (ctrl.GetType() == typeof(ListView))
                {
                    if (ctrl.Tag.GetType() == ((MaterialFlatButton)sender).Tag.GetType())
                    {
                        if (ctrl.Name == ((MaterialFlatButton)sender).Name)
                        {
                            ctrl.Visible = true;
                        }
                        else
                        {
                            ctrl.Visible = false;
                        }
                    }
                    else
                    {
                        ctrl.Visible = false;
                    }
                }
            }
        }

        private void LayDanhSachMon(ListView lsv, List<MonDTO> dsMon)
        {
            for (int i = 0; i < dsMon.Count; i++)
            {
                MonDTO mon = dsMon[i];
                ListViewItem lvi = new ListViewItem(mon.TenMon);
                lvi.SubItems.Add(mon.GiaTien.ToString("#,##0đ"));
                lsv.LargeImageList.Images.Add(Image.FromFile("img\\products\\" + mon.Hinh));
                lvi.Group = lsv.Groups[mon.LoaiMon + ""];
                lvi.ImageIndex = i;
                lvi.Tag = mon;
                lsv.Items.Add(lvi);
            }
        }

        private void LayDanhSachLoaiTopping(int maLoaiMon)
        {
            List<LoaiToppingDTO> dsLoaiTopping = LoaiToppingBUS.LayDanhSachCTLoaiMon_LoaiTopping(maLoaiMon);
            foreach (LoaiToppingDTO loaiTopping in dsLoaiTopping)
            {
                MaterialFlatButton btn = new MaterialFlatButton();
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

        private void LayDanhSachTopping(ListView lsv, List<ToppingDTO> dsTopping)
        {
            for (int i = 0; i < dsTopping.Count; i++)
            {
                ToppingDTO topping = dsTopping[i];
                ListViewItem lvi = new ListViewItem(topping.TenTopping);
                lvi.SubItems.Add(topping.GiaTien.ToString("#,##0đ"));
                lsv.LargeImageList.Images.Add(Image.FromFile("img\\products\\" + topping.Hinh));
                lvi.Group = lsv.Groups[topping.LoaiTopping + ""];
                lvi.ImageIndex = i;
                lvi.Tag = topping;
                lsv.Items.Add(lvi);
            }
        }

        private ListView LayMenuMon()
        {
            foreach (Control ctrl in panelMenu.Controls)
            {
                if (ctrl.GetType() == typeof(ListView))
                {
                    if (ctrl.Visible)
                        return (ListView)ctrl;
                }
            }
            return null;
        }

        private void ThemMon(object sender, EventArgs e)
        {
            ListView lsv = LayMenuMon();
            if (radMenuMon.Checked)
            {
                if (lsv.SelectedItems.Count == 1)
                {
                    MonDTO mon = (MonDTO)lsv.SelectedItems[0].Tag;

                    DataGridViewRow rowMon = new DataGridViewRow();
                    rowMon.DefaultCellStyle.BackColor = Color.AliceBlue;
                    rowMon.Height = 50;
                    rowMon.Tag = mon;
                    rowMon.Cells.Add(new DataGridViewTextBoxCell { Value = mon.TenMon });
                    rowMon.Cells.Add(new DataGridViewTextBoxCell { Value = 1 });
                    rowMon.Cells.Add(new DataGridViewTextBoxCell { Value = mon.GiaTien.ToString("#,###đ") });

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
        }

        private void ThemTopping(object sender, EventArgs e)
        {
            ListView lsv = LayMenuMon();
            if (radMenuTopping.Checked)
            {
                if (lsv.SelectedItems.Count == 1)
                {
                    ToppingDTO topping = (ToppingDTO)lsv.SelectedItems[0].Tag;

                    DataGridViewRow rowTopping = new DataGridViewRow();
                    rowTopping.DefaultCellStyle.BackColor = Color.Beige;
                    rowTopping.Height = 25;
                    rowTopping.Tag = topping;
                    rowTopping.Cells.Add(new DataGridViewTextBoxCell { Value = topping.TenTopping });
                    rowTopping.Cells.Add(new DataGridViewTextBoxCell { Value = 1 });
                    rowTopping.Cells.Add(new DataGridViewTextBoxCell { Value = topping.GiaTien.ToString("#,##0đ") });
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

        private void TaoGroupMon(ListView lsv)
        {
            foreach (LoaiMonDTO loaiMon in LoaiMonBUS.LayDanhSachLoaiMon())
            {
                lsv.Groups.Add(loaiMon.MaLoaiMon + "", loaiMon.TenLoaiMon);
            }
        }

        private void TaoGroupTopping(ListView lsv)
        {
            foreach (LoaiToppingDTO loaiTopping in LoaiToppingBUS.LayDanhSachLoaiTopping())
            {
                lsv.Groups.Add(loaiTopping.MaLoaiTopping + "", loaiTopping.TenLoaiTopping);
            }
        }

        private void XoaMenu()
        {
            foreach (Control ctrl in panelMenu.Controls)
            {
                if (ctrl.GetType() == typeof(ListView))
                {
                    ctrl.Visible = false;
                }
            }
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

            ListView lsv = LayMenuMon();

            // Nếu hoá đơn đang chọn món thì menu hiện topping tương ứng
            if (dgvHoaDon.SelectedRows[0].Tag.GetType() == typeof(MonDTO) && radMenuTopping.Checked)
            {
                panelLoai.Controls.Clear();
                LayDanhSachLoaiTopping(((MonDTO)dgvHoaDon.SelectedRows[0].Tag).LoaiMon);

                if (lsv == null)
                {
                    HienLuaChonDauTien();
                    return;
                }

                // Kiểm tra màn hình topping hiện đúng với món đang chọn
                if (lsv.Items.Count > 0)
                {
                    bool toppingCheck = false;
                    foreach (MaterialFlatButton btn in panelLoai.Controls)
                    {
                        if (((LoaiToppingDTO)btn.Tag).MaLoaiTopping == ((ToppingDTO)lsv.Items[0].Tag).LoaiTopping)
                        {
                            toppingCheck = true;
                            break;
                        }
                    }
                    if (!toppingCheck)
                    {
                        loaiDangChon = 0;
                        lsv.Visible = false;
                    }
                }
                return;
            }

            // Nếu hoá đơn đang chọn topping thì menu không hiện gì hết
            if (dgvHoaDon.SelectedRows[0].Tag.GetType() == typeof(ToppingDTO) && radMenuTopping.Checked)
            {
                loaiDangChon = 0;
                panelLoai.Controls.Clear();

                if (lsv != null)
                {
                    lsv.Visible = false;
                }
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

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ListView lsv = LayMenuMon();
                if (lsv == null)
                {
                    return;
                }
                lsv.Items.Clear();
                lsv.LargeImageList.Images.Clear();

                // Tìm kiếm món
                if (radMenuMon.Checked)
                {
                    List<MonDTO> dsMon = MonBUS.LayDanhSachMon(loaiDangChon, txtTimKiem.Text);
                    LayDanhSachMon(lsv, dsMon);
                }

                // Tìm kiếm topping
                else
                {
                    List<ToppingDTO> dsTopping = ToppingBUS.LayDanhSachTopping(loaiDangChon);
                    LayDanhSachTopping(lsv, dsTopping);
                }
            }
        }

        private void radMenuMon_CheckedChanged(object sender, EventArgs e)
        {
            if (radMenuMon.Checked)
            {
                loaiDangChon = 0;
                panelLoai.Controls.Clear();
                XoaMenu();
                LayDanhSachLoaiMon();
                HienLuaChonDauTien();
            }
        }

        private void radMenuTopping_CheckedChanged(object sender, EventArgs e)
        {
            if (radMenuTopping.Checked)
            {
                loaiDangChon = 0;
                panelLoai.Controls.Clear();
                XoaMenu();

                // Nếu hoá đơn đang chọn món thì menu mới hiện topping tương ứng
                if (dgvHoaDon.SelectedRows[0].Tag.GetType() == typeof(MonDTO))
                {
                    LayDanhSachLoaiTopping(((MonDTO)dgvHoaDon.SelectedRows[0].Tag).LoaiMon);
                }

                HienLuaChonDauTien();
            }
        }

        private void HienLuaChonDauTien()
        {
            foreach (Control ctrl in panelLoai.Controls)
            {
                if (ctrl.GetType() == typeof(MaterialFlatButton))
                {
                    ((MaterialFlatButton)ctrl).PerformClick();
                }
            }
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

        private void LapHoaDon()
        {
            panelHoaDon.Visible = panelLoai.Visible = panelMain.Visible = panelThanhToan.Visible = false;
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

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            LapHoaDon();
        }

        public double TinhThanhTien()
        {
            double tongTien = 0;
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.Tag.GetType() == typeof(MonDTO))
                {
                    tongTien += Convert.ToDouble(row.Cells["colSoLuong"].Value) * ((MonDTO)row.Tag).GiaTien;
                }
                else
                {
                    tongTien += Convert.ToDouble(row.Cells["colSoLuong"].Value) * ((ToppingDTO)row.Tag).GiaTien;
                }
            }
            return tongTien;
        }

        public void QuayLaiManHinhChonMon(bool luuThanhCong = false)
        {
            panelHoaDon.Visible = panelLoai.Visible = panelMain.Visible = panelThanhToan.Visible = true;
            splitContainer1.Visible = true;
            if (luuThanhCong) // Clear bảng hoá đơn nếu đã thanh toán
            {
                dgvHoaDon.Rows.Clear();
            }
        }

        private void QuayLaiManHinhChinh()
        {
            // Xoá bộ nhớ ucXemLaiHoaDon
            panelLayout.Controls.Clear();
            ((FrmMain)this.ParentForm).XuLyFormMain();
            this.Close();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            QuayLaiManHinhChinh();
        }

        private void FrmBanHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }
    }
}
