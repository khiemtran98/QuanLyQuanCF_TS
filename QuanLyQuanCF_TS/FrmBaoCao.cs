using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using BUS;
using DTO;

namespace QuanLyQuanCF_TS
{
    public partial class FrmBaoCao : MetroFramework.Forms.MetroForm
    {
        public FrmBaoCao()
        {
            InitializeComponent();
        }

        private static FrmBaoCao _Instance = null;

        public static FrmBaoCao Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FrmBaoCao();
                }
                return _Instance;
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            ((FrmMain)this.ParentForm).XuLyFormMain();
            this.Close();
        }

        private void FrmBaoCao_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
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
