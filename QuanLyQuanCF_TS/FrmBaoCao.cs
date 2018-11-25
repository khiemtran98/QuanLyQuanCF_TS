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

            #region
            this.Style = FrmMain.style;
            cmbLoaiMon.Style = FrmMain.style;
            radTatCaMon.Style = FrmMain.style;
            radTheoLoaiMon.Style = FrmMain.style;
            radGomNhomMon.Style = FrmMain.style;

            dtpHoaDonTheoThang.Style = FrmMain.style;
            radTatCaHoaDon.Style = FrmMain.style;
            radHoaDonTheoThang.Style = FrmMain.style;

            dtpDoanhThu.Style = FrmMain.style;
            radDoanhThuTheoTuan.Style = FrmMain.style;
            radDoanhThuTheoThang.Style = FrmMain.style;

            radTatCaNguyenLieu.Style = FrmMain.style;

            dtpPhieuNhapTheoThang.Style = FrmMain.style;
            radTatCaPhieuNhap.Style = FrmMain.style;
            radPhieuNhapTheoThang.Style = FrmMain.style;

            btnBaoCao.Style = FrmMain.style;
            #endregion
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

        private void FrmBaoCao_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            cmbLoaiMon.DisplayMember = "TenLoaiMon";
            cmbLoaiMon.ValueMember = "MaLoaiMon";
            cmbLoaiMon.DataSource = LoaiMonBUS.LayDanhSachLoaiMon();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            FrmMain.Instance.TopMost = false;
            FrmHienThiBaoCao frm = new FrmHienThiBaoCao();

            if (radTatCaMon.Checked)
            {
                frm.HienTatCaMon();
            }
            else if (radTheoLoaiMon.Checked)
            {
                frm.HienMonTheoLoai((int)cmbLoaiMon.SelectedValue);
            }
            else if (radGomNhomMon.Checked)
            {
                frm.HienThiMonTheoNhom();
            }
            else if (radTatCaHoaDon.Checked)
            {
                frm.HienThiTatCacHoaDon();
            }
            else if (radHoaDonTheoThang.Checked)
            {
                frm.HienThiTatCacHoaDonTheoThang((DateTime)dtpHoaDonTheoThang.Value);
            }
            else if (radTatCaNguyenLieu.Checked)
            {
                frm.HienTatCaNguyenLieu();
            }
            else if (radTatCaPhieuNhap.Checked)
            {
                frm.HienTatCaPhieuNhap();
            }
            else if (radPhieuNhapTheoThang.Checked)
            {
                frm.HienThiTatCacPhieuNhapTheoThang((DateTime)dtpPhieuNhapTheoThang.Value);
            }

            frm.Show();
        }
    }
}
