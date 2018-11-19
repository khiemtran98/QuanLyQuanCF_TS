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
    public partial class FrmChonBaoCao : MetroFramework.Forms.MetroForm
    {
        public FrmChonBaoCao()
        {
            InitializeComponent();
        }

        private static FrmChonBaoCao _Instance = null;

        public static FrmChonBaoCao Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FrmChonBaoCao();
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
            //rpvReport.LocalReport.ReportEmbeddedResource = "QuanLyQuanCF_TS.rptGroupDanhSachMon.rdlc";
            //rpvReport.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;
            //List<LoaiMonDTO> lstLoaiMon = LoaiMonBUS.LayDanhSachLoaiMon();
            //rpvReport.LocalReport.DataSources.Add(new ReportDataSource("DSMON", lstLoaiMon));
            //this.rpvReport.RefreshReport();
        }

        private void LocalReport_SubreportProcessing(object sender,SubreportProcessingEventArgs e)
        {
            int maLoai =int.Parse(e.Parameters["paLoaiMon"].Values[0]);
            List<MonDTO> lstMon = MonBUS.LayDanhSachMon(maLoai);
            e.DataSources.Add(new ReportDataSource("DSMON", lstMon));
        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmBaoCao frm = new FrmBaoCao();

            if (radTatCaHoaDon.Checked)
            {
                frm.HienTatCaMon();
            }
            else if (radTheoLoaiMon.Checked)
            {
                //frm.HienMonTheoLoai((int)cmbLoaiSanPham.SelectedValue);
            }
            else if (radTheoNhomMon.Checked)
            {
                //frm.HienMonTheoNhom();
            }
            else if (radTheoNhomMon.Checked)
            {
                //frm.HienSanPhamTheoNhom();
            }


            frm.Show();
        }
    }
}
