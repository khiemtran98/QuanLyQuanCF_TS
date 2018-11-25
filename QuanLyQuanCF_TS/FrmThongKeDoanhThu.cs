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
using BUS;

namespace QuanLyQuanCF_TS
{
    public partial class FrmThongKeDoanhThu : MetroFramework.Forms.MetroForm
    {
        public FrmThongKeDoanhThu()
        {
            InitializeComponent();

            #region
            this.Style = FrmMain.style;
            tbcThongKeDoanhThu.Style = FrmMain.style;
            #endregion
        }

        private static FrmThongKeDoanhThu _Instance = null;

        public static FrmThongKeDoanhThu Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FrmThongKeDoanhThu();
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
            TongQuan();
            ChiPhi();
            DoanhThu();
        }

        private void TongQuan()
        {
            chartTongQuat.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Nhập hàng",
                    Values = new ChartValues<double> {}
                },
                new LineSeries
                {
                    Title = "Bán hàng",
                    Values = new ChartValues<double> {},
                },
            };

            for (int i = 1; i <= 12; i++)
            {
                chartTongQuat.Series[0].Values.Add(PhieuNhapBUS.LayDoanhSoPhieuNhapTheoThang(i));
            }

            for (int i = 1; i <= 12; i++)
            {
                chartTongQuat.Series[1].Values.Add(HoaDonBUS.LayDoanhSoHoaDonTheoThang(i));
            }

            chartTongQuat.AxisX.Add(new Axis
            {
                Labels = new[] { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" }
            });

            chartTongQuat.AxisY.Add(new Axis
            {
                Title = "Doanh số",
                LabelFormatter = value => value.ToString("C")
            });

            chartTongQuat.LegendLocation = LegendLocation.Right;

            lblMoTaTongQuat.Text += DateTime.Now.Year + "";
        }

        private void ChiPhi()
        {
            Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            chartChiPhi.Series = new SeriesCollection { };

            for (int i = 1; i <= 12; i++)
            {
                PieSeries pieSeries = new PieSeries();
                pieSeries.Title = "Tháng " + i;
                pieSeries.Values = new ChartValues<double> { PhieuNhapBUS.LayDoanhSoPhieuNhapTheoThang(i) };
                pieSeries.DataLabels = true;
                pieSeries.LabelPoint = labelPoint;
                chartChiPhi.Series.Add(pieSeries);
            }

            chartChiPhi.LegendLocation = LegendLocation.Bottom;

            lblMoTaChiPhi.Text += DateTime.Now.Year + "";
        }

        private void DoanhThu()
        {
            Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            chartDoanhThu.Series = new SeriesCollection{};

            for (int i = 1; i <= 12; i++)
            {
                PieSeries pieSeries = new PieSeries();
                pieSeries.Title = "Tháng " + i;
                pieSeries.Values = new ChartValues<double> { HoaDonBUS.LayDoanhSoHoaDonTheoThang(i) };
                pieSeries.DataLabels = true;
                pieSeries.LabelPoint = labelPoint;
                chartDoanhThu.Series.Add(pieSeries);
            }

            chartDoanhThu.LegendLocation = LegendLocation.Bottom;

            lblMoTaDoanhThu.Text += DateTime.Now.Year + "";
        }
    }
}
