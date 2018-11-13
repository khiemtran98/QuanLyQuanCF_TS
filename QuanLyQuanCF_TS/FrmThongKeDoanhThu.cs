using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyQuanCF_TS
{
    public partial class FrmThongKeDoanhThu : MetroFramework.Forms.MetroForm
    {
        public FrmThongKeDoanhThu()
        {
            InitializeComponent();
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

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            ((FrmMain)this.ParentForm).XuLyFormMain();
            this.Close();
        }

        private void FrmThongKeDoanhThu_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void FrmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
           

            // set title 
            this.chart1.Titles.Add("THỐNG KÊ DOANH THU");

            chart1.Series["Lãi"].Points.AddXY("1/10/2018", 1880);
            chart1.Series["Lãi"].Points.AddXY("2/10/2018", 0);
            chart1.Series["Lãi"].Points.AddXY("3/10/2018", 0);
            chart1.Series["Lãi"].Points.AddXY("4/10/2018", 1000);
            chart1.Series["Lãi"].Points.AddXY("5/10/2018", 1000);
            chart1.Series["Lãi"].Points.AddXY("6/10/2018", 1000);

            chart1.Series["Doanh thu"].Points.AddXY("1/10/2018", 5000);
            chart1.Series["Doanh thu"].Points.AddXY("2/10/2018", 4000);
            chart1.Series["Doanh thu"].Points.AddXY("3/10/2018", 4500);
            chart1.Series["Doanh thu"].Points.AddXY("4/10/2018", 3000);
            chart1.Series["Doanh thu"].Points.AddXY("5/10/2018", 3500);
            chart1.Series["Doanh thu"].Points.AddXY("6/10/2018", 2000);

            chart1.Series["Vốn"].Points.AddXY("1/10/2018", 1880);
            chart1.Series["Vốn"].Points.AddXY("2/10/2018", 2000);
            chart1.Series["Vốn"].Points.AddXY("3/10/2018", 1500);
            chart1.Series["Vốn"].Points.AddXY("4/10/2018", 2000);
            chart1.Series["Vốn"].Points.AddXY("5/10/2018", 2500);
            chart1.Series["Vốn"].Points.AddXY("6/10/2018", 1000);

            chart1.Series["Lỗ"].Points.AddXY("1/10/2018", 0);
            chart1.Series["Lỗ"].Points.AddXY("2/10/2018", -200);
            chart1.Series["Lỗ"].Points.AddXY("3/10/2018", -300);
            chart1.Series["Lỗ"].Points.AddXY("4/10/2018", 0);
            chart1.Series["Lỗ"].Points.AddXY("5/10/2018", 0);
            chart1.Series["Lỗ"].Points.AddXY("6/10/2018", 0);


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}
