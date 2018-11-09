using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using Microsoft.Reporting.WinForms;

namespace QuanLyQuanCF_TS
{
    public partial class frmBaoCao : Form
    {
        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            rpvReport.LocalReport.ReportEmbeddedResource = "QuanLyQuanCF_TS.rptGroupDanhSachMon.rdlc";
            rpvReport.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;
            List<LoaiMonDTO> lstLoaiMon = LoaiMonBUS.LayDanhSachLoaiMon();
            rpvReport.LocalReport.DataSources.Add(new ReportDataSource("DSMON", lstLoaiMon));
            this.rpvReport.RefreshReport();
        }

        private void LocalReport_SubreportProcessing(object sender,SubreportProcessingEventArgs e)
        {
            int maLoai =int.Parse(e.Parameters["paLoaiMon"].Values[0]);
            List<MonDTO> lstMon = MonBUS.LayDanhSachMon(maLoai);
            e.DataSources.Add(new ReportDataSource("DSMON", lstMon));
        }
    }
}
