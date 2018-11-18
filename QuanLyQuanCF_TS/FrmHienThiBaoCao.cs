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
using Microsoft.Reporting.WinForms;

namespace QuanLyQuanCF_TS
{
    public partial class FrmHienThiBaoCao : MetroFramework.Forms.MetroForm
    {
        public FrmHienThiBaoCao()
        {
            InitializeComponent();
        }

        internal void HienTatCaMon()
        {
            List<MonDTO> lsMon = MonBUS.LayDanhSachMon();
            rpvBaoCao.LocalReport.ReportEmbeddedResource = "QuanLyQuanCF_TS.Reports.rptTatCaMon.rdlc";
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DSMON", lsMon));
            rpvBaoCao.RefreshReport();
        }

        internal void HienMonTheoLoai(int maMon)
        {
            List<MonDTO> lsMon = MonBUS.LayDanhSachMon(maMon);
            rpvBaoCao.LocalReport.ReportEmbeddedResource = "QuanLyQuanCF_TS.Reports.rptMonTheoLoai.rdlc";
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DSMONTHEOLOAI", lsMon));
            rpvBaoCao.RefreshReport();
        }
    }
}
