using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using MetroFramework;
using MetroFramework.Controls;
using DTO;
using BUS;

namespace QuanLyQuanCF_TS
{
    public partial class FrmThongKeDoanhSo : MetroFramework.Forms.MetroForm
    {
        public FrmThongKeDoanhSo()
        {
            InitializeComponent();

            #region
            this.Style = FrmMain.style;
            tbcThongKeDoanhThu.Style = FrmMain.style;
            chkTQ_ChiPhi.Style = FrmMain.style;
            chkTQ_DoanhThu.Style = FrmMain.style;
            chkTQ_LoiNhuan.Style = FrmMain.style;
            #endregion
        }

        private static FrmThongKeDoanhSo _Instance = null;

        public static FrmThongKeDoanhSo Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FrmThongKeDoanhSo();
                }
                return _Instance;
            }
        }

        private void FrmThongKeDoanhThu_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void FrmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            TongQuat();
            ChiPhi();
            DoanhThu();
            Trending();
        }

        // Bắt đầu khu vực Tổng quát

        private void TongQuat()
        {
            chartTongQuat.AxisX.Add(new Axis
            {
                Labels = new[] { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" }
            });
            chartTongQuat.AxisY.Add(new Axis
            {
                Title = "Doanh số",
                LabelFormatter = value => value.ToString("#,##0đ")
            });
            chartTongQuat.LegendLocation = LegendLocation.Right;
            lblTQ_MoTa.Text += DateTime.Now.Year + "";
            lblTQ_TongChiPhi.Text += PhieuNhapBUS.LayDoanhSoPhieuNhapTheoNam(DateTime.Now.Year).ToString("#,##0đ");
            lblTQ_TongDoanhThu.Text += HoaDonBUS.LayDoanhSoHoaDonTheoNam(DateTime.Now.Year).ToString("#,##0đ");
            double loiNhuan = (HoaDonBUS.LayDoanhSoHoaDonTheoNam(DateTime.Now.Year) - PhieuNhapBUS.LayDoanhSoPhieuNhapTheoNam(DateTime.Now.Year));
            if (loiNhuan < 0)
            {
                lblTQ_LoiNhuan.ForeColor = MetroColors.Red;
            }
            else
            {
                lblTQ_LoiNhuan.ForeColor = MetroColors.Green;
            }
            lblTQ_LoiNhuan.Text += loiNhuan.ToString("#,##0đ");
            chkTQ_ChiPhi.Checked = chkTQ_DoanhThu.Checked = chkTQ_LoiNhuan.Checked = true;
        }

        private void chkChiPhi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTQ_ChiPhi.Checked)
            {
                LineSeries lineNhapHang = new LineSeries();
                lineNhapHang.Name = "lineChiPhi";
                lineNhapHang.Title = "Chi phí";
                lineNhapHang.Values = new ChartValues<double> { };
                for (int i = 1; i <= 12; i++)
                {
                    lineNhapHang.Values.Add(PhieuNhapBUS.LayDoanhSoPhieuNhapTheoThang(i));
                }
                chartTongQuat.Series.Add(lineNhapHang);
            }
            else
            {
                LineSeries line = null;
                foreach (LineSeries ls in chartTongQuat.Series)
                {
                    if (ls.Name == "lineChiPhi")
                    {
                        line = ls;
                    }
                }
                chartTongQuat.Series.Remove(line);
            }
        }

        private void chkDoanhThu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTQ_DoanhThu.Checked)
            {
                LineSeries lineBanHang = new LineSeries();
                lineBanHang.Name = "lineDoanhThu";
                lineBanHang.Title = "Doanh thu";
                lineBanHang.Values = new ChartValues<double> { };
                for (int i = 1; i <= 12; i++)
                {
                    lineBanHang.Values.Add(HoaDonBUS.LayDoanhSoHoaDonTheoThang(i));
                }
                chartTongQuat.Series.Add(lineBanHang);
            }
            else
            {
                LineSeries line = null;
                foreach (LineSeries ls in chartTongQuat.Series)
                {
                    if (ls.Name == "lineDoanhThu")
                    {
                        line = ls;
                    }
                }
                chartTongQuat.Series.Remove(line);
            }
        }

        private void chkTQ_LoiNhuan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTQ_LoiNhuan.Checked)
            {
                LineSeries lineLoiNhuan = new LineSeries();
                lineLoiNhuan.Name = "lineLoiNhuan";
                lineLoiNhuan.Title = "Lợi nhuận";
                lineLoiNhuan.Values = new ChartValues<double> { };
                for (int i = 1; i <= 12; i++)
                {
                    lineLoiNhuan.Values.Add(HoaDonBUS.LayDoanhSoHoaDonTheoThang(i) - PhieuNhapBUS.LayDoanhSoPhieuNhapTheoThang(i));
                }
                chartTongQuat.Series.Add(lineLoiNhuan);
            }
            else
            {
                LineSeries line = null;
                foreach (LineSeries ls in chartTongQuat.Series)
                {
                    if (ls.Name == "lineLoiNhuan")
                    {
                        line = ls;
                    }
                }
                chartTongQuat.Series.Remove(line);
            }
        }

        // Kết thúc Khu vực Tổng quát

        // ----------------------------------------------

        // Bắt đầu khu vực Chi phí

        private void ChiPhi()
        {
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0:#,##0đ} ({1:P})", chartPoint.Y, chartPoint.Participation);
            chartChiPhi.Series = new SeriesCollection { };
            //for (int i = 1; i <= 12; i++)
            //{
            //    double value = PhieuNhapBUS.LayDoanhSoPhieuNhapTheoThang(i);
            //    if (value != 0)
            //    {
            //        PieSeries pieSeries = new PieSeries();
            //        pieSeries.Title = "Tháng " + i;
            //        pieSeries.Values = new ChartValues<double> { value };
            //        pieSeries.DataLabels = true;
            //        pieSeries.LabelPoint = labelPoint;
            //        pieSeries.PushOut = 5;
            //        if (i == DateTime.Now.Month)
            //        {
            //            pieSeries.PushOut = 15;
            //        }
            //        chartChiPhi.Series.Add(pieSeries);
            //    }
            //}

            List<ChiPhiDTO> lsChiPhi = PhieuNhapBUS.LayChiPhiPhieuNhap();
            for (int i = 0; i < lsChiPhi.Count; i++)
            {
                PieSeries pieSeries = new PieSeries();
                pieSeries.Title = "Tháng " + lsChiPhi[i].Thang;
                pieSeries.Values = new ChartValues<double> { lsChiPhi[i].ChiPhi };
                pieSeries.DataLabels = true;
                pieSeries.LabelPoint = labelPoint;
                if (i == DateTime.Now.Month)
                {
                    pieSeries.PushOut = 15;
                }
                else
                {
                    pieSeries.PushOut = 5;
                }
                chartChiPhi.Series.Add(pieSeries);
            }

            if (chartChiPhi.Series.Count == 0)
            {
                MetroLabel lblThongBao = new MetroLabel();
                lblThongBao.Text = "Không có dữ liệu thống kê";
                lblThongBao.FontSize = MetroFramework.MetroLabelSize.Tall;
                lblThongBao.TextAlign = ContentAlignment.MiddleCenter;
                lblThongBao.Dock = DockStyle.Fill;
                panelChiPhi.Controls.Add(lblThongBao);
                lblThongBao.BringToFront();
            }
            chartChiPhi.LegendLocation = LegendLocation.Right;
            lblCP_MoTa.Text += DateTime.Now.Year + "";
            lblCP_TongChiPhi.Text += PhieuNhapBUS.LayDoanhSoPhieuNhapTheoNam(DateTime.Now.Year).ToString("#,##0đ");
        }

        // Kết thúc Khu vực Chi phí

        // ----------------------------------------------

        // Bắt đầu khu vực Doanh thu

        private void DoanhThu()
        {
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0:#,##0đ} ({1:P})", chartPoint.Y, chartPoint.Participation);
            chartDoanhThu.Series = new SeriesCollection { };
            //for (int i = 1; i <= 12; i++)
            //{
            //    double value = HoaDonBUS.LayDoanhSoHoaDonTheoThang(i);
            //    if (value != 0)
            //    {
            //        PieSeries pieSeries = new PieSeries();
            //        pieSeries.Title = "Tháng " + i;
            //        pieSeries.Values = new ChartValues<double> { value };
            //        pieSeries.DataLabels = true;
            //        pieSeries.LabelPoint = labelPoint;
            //        pieSeries.PushOut = 5;
            //        if (i == DateTime.Now.Month)
            //        {
            //            pieSeries.PushOut = 15;
            //        }
            //        chartDoanhThu.Series.Add(pieSeries);
            //    }
            //}

            List<DoanhThuDTO> lsDoanhThu = HoaDonBUS.LayDoanhThuHoaDon();
            for (int i = 0; i < lsDoanhThu.Count; i++)
            {
                PieSeries pieSeries = new PieSeries();
                pieSeries.Title = "Tháng " + lsDoanhThu[i].Thang;
                pieSeries.Values = new ChartValues<double> { lsDoanhThu[i].DoanhThu };
                pieSeries.DataLabels = true;
                pieSeries.LabelPoint = labelPoint;
                if (i == DateTime.Now.Month)
                {
                    pieSeries.PushOut = 15;
                }
                else
                {
                    pieSeries.PushOut = 5;
                }
                chartDoanhThu.Series.Add(pieSeries);
            }
            
            if (chartDoanhThu.Series.Count == 0)
            {
                MetroLabel lblThongBao = new MetroLabel();
                lblThongBao.Text = "Không có dữ liệu thống kê";
                lblThongBao.FontSize = MetroFramework.MetroLabelSize.Tall;
                lblThongBao.TextAlign = ContentAlignment.MiddleCenter;
                lblThongBao.Dock = DockStyle.Fill;
                panelDoanhThu.Controls.Add(lblThongBao);
                lblThongBao.BringToFront();
            }
            chartDoanhThu.LegendLocation = LegendLocation.Right;
            lblDT_MoTa.Text += DateTime.Now.Year + "";
            lblDT_TongDoanhThu.Text += HoaDonBUS.LayDoanhSoHoaDonTheoNam(DateTime.Now.Year).ToString("#,##0đ");
        }

        // Kết thúc Khu vực Doanh thu

        // ----------------------------------------------

        // Bắt đầu khu vực Trending

        private void Trending()
        {
            //Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0:#,##0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            //chartTrending.Series = new SeriesCollection { };
            //List<TrendingMonDTO> lsTrendingMon = TrendingMonBUS.LayDanhSachMonDaBan();

            //foreach (TrendingMonDTO trendingMon in lsTrendingMon)
            //{
            //    PieSeries pieSeries = new PieSeries();
            //    pieSeries.Title = trendingMon.TenMon;
            //    pieSeries.Values = new ChartValues<int> { trendingMon.SoLuong };
            //    pieSeries.DataLabels = true;
            //    pieSeries.LabelPoint = labelPoint;
            //    pieSeries.PushOut = 5;
            //    chartTrending.Series.Add(pieSeries);
            //}
            //if (chartTrending.Series.Count == 0)
            //{
            //    MetroLabel lblThongBao = new MetroLabel();
            //    lblThongBao.Text = "Không có dữ liệu thống kê";
            //    lblThongBao.FontSize = MetroFramework.MetroLabelSize.Tall;
            //    lblThongBao.TextAlign = ContentAlignment.MiddleCenter;
            //    lblThongBao.Dock = DockStyle.Fill;
            //    panelLoiNhuan.Controls.Add(lblThongBao);
            //    lblThongBao.BringToFront();
            //    lblT_MonBanChayNhat.Text += "không có";
            //}
            //else
            //{
            //    int index = 0;
            //    int max = Convert.ToInt32(chartTrending.Series[index].Values[0]);
            //    for (int i = 1; i < chartTrending.Series.Count; i++)
            //    {
            //        if (Convert.ToInt32(chartTrending.Series[i].Values[0]) >= max)
            //        {
            //            index = i;
            //            max = Convert.ToInt32(chartTrending.Series[i].Values[0]);
            //        }
            //    }
            //    lblT_MonBanChayNhat.Text += chartTrending.Series[index].Title; ;
            //}
            chartTrending.LegendLocation = LegendLocation.Right;
            lblT_MoTa.Text += DateTime.Now.Year + "";

            radTrendingTop5.Checked = true;
        }

        private void radTop5_CheckedChanged(object sender, EventArgs e)
        {
            if (radTrendingTop5.Checked)
            {
                chartTrending.Series.Clear();

                Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0:#,##0} ({1:P})", chartPoint.Y, chartPoint.Participation);
                chartTrending.Series = new SeriesCollection { };

                List<TrendingMonDTO> lsTrendingMon = TrendingMonBUS.LayDanhSachTop10MonDaBan();
                
                if (lsTrendingMon.Count > 0)
                {
                    int index;
                    if (lsTrendingMon.Count < 5)
                    {
                        index = lsTrendingMon.Count;
                    }
                    else
                    {
                        index = 5;
                    }

                    for (int i = 0; i < 5; i++)
                    {
                        TrendingMonDTO trendingMon = lsTrendingMon[i];
                        PieSeries pieSeries = new PieSeries();
                        pieSeries.Title = trendingMon.TenMon;
                        pieSeries.Values = new ChartValues<int> { trendingMon.SoLuong };
                        pieSeries.DataLabels = true;
                        pieSeries.LabelPoint = labelPoint;
                        pieSeries.PushOut = 5;
                        chartTrending.Series.Add(pieSeries);
                    }
                }
                
                if (chartTrending.Series.Count == 0)
                {
                    MetroLabel lblThongBao = new MetroLabel();
                    lblThongBao.Text = "Không có dữ liệu thống kê";
                    lblThongBao.FontSize = MetroFramework.MetroLabelSize.Tall;
                    lblThongBao.TextAlign = ContentAlignment.MiddleCenter;
                    lblThongBao.Dock = DockStyle.Fill;
                    panelLoiNhuan.Controls.Add(lblThongBao);
                    lblThongBao.BringToFront();
                    lblT_MonBanChayNhat.Text = "Món bán chạy nhất: không có";
                }
                else
                {
                    lblT_MonBanChayNhat.Text = "Món bán chạy nhất: " + chartTrending.Series[0].Title;
                }
            }
        }

        private void radTop10_CheckedChanged(object sender, EventArgs e)
        {
            if (radTrendingTop10.Checked)
            {
                chartTrending.Series.Clear();

                Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0:#,##0} ({1:P})", chartPoint.Y, chartPoint.Participation);
                chartTrending.Series = new SeriesCollection { };

                List<TrendingMonDTO> lsTrendingMon = TrendingMonBUS.LayDanhSachTop10MonDaBan();
                
                if (lsTrendingMon.Count > 0)
                {
                    int index;
                    if (lsTrendingMon.Count < 10)
                    {
                        index = lsTrendingMon.Count;
                    }
                    else
                    {
                        index = 10;
                    }

                    for (int i = 0; i < index; i++)
                    {
                        TrendingMonDTO trendingMon = lsTrendingMon[i];
                        PieSeries pieSeries = new PieSeries();
                        pieSeries.Title = trendingMon.TenMon;
                        pieSeries.Values = new ChartValues<int> { trendingMon.SoLuong };
                        pieSeries.DataLabels = true;
                        pieSeries.LabelPoint = labelPoint;
                        pieSeries.PushOut = 5;
                        chartTrending.Series.Add(pieSeries);
                    }
                }
                
                if (chartTrending.Series.Count == 0)
                {
                    MetroLabel lblThongBao = new MetroLabel();
                    lblThongBao.Text = "Không có dữ liệu thống kê";
                    lblThongBao.FontSize = MetroFramework.MetroLabelSize.Tall;
                    lblThongBao.TextAlign = ContentAlignment.MiddleCenter;
                    lblThongBao.Dock = DockStyle.Fill;
                    panelLoiNhuan.Controls.Add(lblThongBao);
                    lblThongBao.BringToFront();
                    lblT_MonBanChayNhat.Text = "Món bán chạy nhất: không có";
                }
                else
                {
                    lblT_MonBanChayNhat.Text = "Món bán chạy nhất: " + chartTrending.Series[0].Title;
                }
            }
        }

        // Kết thúc Khu vực Trending
    }
}
