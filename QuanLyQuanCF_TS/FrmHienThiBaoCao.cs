﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using DTO;
using BUS;

namespace QuanLyQuanCF_TS
{
    public partial class FrmHienThiBaoCao : MetroFramework.Forms.MetroForm
    {
        public FrmHienThiBaoCao()
        {
            InitializeComponent();

            #region
            this.Style = FrmMain.style;
            #endregion
        }

        string path = "QuanLyQuanCF_TS.Reports.";

        public void HienTatCaMon()
        {
            List<rptMon_LoaiMonDTO> lsMon = rptMon_LoaiMonBUS.DoiMaLoaiMonThanhTenLoaiMon();
            rpvBaoCao.LocalReport.ReportEmbeddedResource = path + "rptTatCaMon.rdlc";
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DSMON", lsMon));
            rpvBaoCao.RefreshReport();
        }

        public void HienMonTheoLoai(int maMon)
        {
            List<MonDTO> lsMon = MonBUS.LayDanhSachMon(maMon);
            rpvBaoCao.LocalReport.ReportEmbeddedResource = path + "rptMonTheoLoai.rdlc";
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DSMON", lsMon));
            rpvBaoCao.RefreshReport();
        }

        public void HienTatCaNguyenLieu()
        {
            List<NguyenLieuDTO> lsNguyenLieu = NguyenLieuBUS.LayDanhSachNguyenLieu();
            rpvBaoCao.LocalReport.ReportEmbeddedResource = path + "rptTatCaNguyenLieu.rdlc";
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DSNGUYENLIEU", lsNguyenLieu));
            rpvBaoCao.RefreshReport();
        }

        public void HienThiTatCacHoaDon()
        {
            List<rptHoaDon_TaiKhoanDTO> lsHoaDon_TK = rptHoaDon_TaiKhoanBUS.DoiMaNhanVienThanhTenNhanVien();
            rpvBaoCao.LocalReport.ReportEmbeddedResource = path + "rptTatCaHoaDon.rdlc";
            rpvBaoCao.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing1);
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DSHOADON", lsHoaDon_TK));
            rpvBaoCao.RefreshReport();
        }

        private void LocalReport_SubreportProcessing1(object sender, SubreportProcessingEventArgs e)
        {
            //Lấy mã loại truyền từ report cha
            int maHD = int.Parse(e.Parameters["paMaHoaDon"].Values[0]);
            //Lấy dữ liệu cho report con
            List<rptMon_CTHDDTO> lsCTHD = rptMon_CTHDBUS.DoiMaMonThanhTenMon(maHD);
            //Đỗ dữ liệu cho report con
            e.DataSources.Add(new ReportDataSource("DSCHITIETHD", lsCTHD));
        }

        public void HienThiTatCacHoaDonTheoThang(DateTime ngaylap)
        {
            List<rptHoaDon_TaiKhoanDTO> lsHoaDon = rptHoaDon_TaiKhoanBUS.DoiMaNhanVienThanhTenNhanVien(ngaylap);
            rpvBaoCao.LocalReport.ReportEmbeddedResource = path + "rptHoaDonTheoThang.rdlc";
            rpvBaoCao.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing2);
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DSHOADON", lsHoaDon));
            rpvBaoCao.RefreshReport();

        }

        private void LocalReport_SubreportProcessing2(object sender, SubreportProcessingEventArgs e)
        {
            //Lấy mã hóa đơn truyền từ report cha
            int maHD = int.Parse(e.Parameters["paMaHoaDon"].Values[0]);
            //Lấy dữ liệu cho report con
            List<rptMon_CTHDDTO> lsMon_CTHD = rptMon_CTHDBUS.DoiMaMonThanhTenMon(maHD);
            //Đỗ dữ liệu cho report con
            e.DataSources.Add(new ReportDataSource("DSCHITIETHD", lsMon_CTHD));
        }

        public void HienTatCaPhieuNhap()
        {
            List<rptNhaCungCap_PhieuNhapDTO> lsPhieuNhap_NCC = rptNhaCungCap_PhieuNhapBUS.DoiMaNhaCungCapThanhTenNhaCungCap();
            rpvBaoCao.LocalReport.ReportEmbeddedResource = path + "rptTatCaPhieuNhap.rdlc";
            rpvBaoCao.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing3);
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DSPHIEUNHAP_NCC", lsPhieuNhap_NCC));
            rpvBaoCao.RefreshReport();
        }

        private void LocalReport_SubreportProcessing3(object sender, SubreportProcessingEventArgs e)
        {
            //Lấy mã phiếu nhập truyền từ report cha
            int maPhieuNhap = int.Parse(e.Parameters["paMaPhieuNhap"].Values[0]);
            //Lấy dữ liệu cho report con
            List<rptPhieuNhap_CTPhieuNhapDTO> lsCTPN = rptPhieuNhap_CTPhieuNhapBUS.DoiMaNguyenLieuThanhTenNguyenLieu(maPhieuNhap);
            //Đỗ dữ liệu cho report con
            e.DataSources.Add(new ReportDataSource("DSCHITIETPHIEUNHAP", lsCTPN));
        }

        public void HienThiTatCacPhieuNhapTheoThang(DateTime ngaylap)
        {
            List<rptNhaCungCap_PhieuNhapDTO> lsPhieuNhap_NCC = rptNhaCungCap_PhieuNhapBUS.DoiMaNhaCungCapThanhTenNhaCungCap(ngaylap);
            rpvBaoCao.LocalReport.ReportEmbeddedResource = path + "rptPhieuNhapTheoThang.rdlc";
            rpvBaoCao.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing4);
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DSPHIEUNHAP", lsPhieuNhap_NCC));
            rpvBaoCao.RefreshReport();
        }

        private void LocalReport_SubreportProcessing4(object sender, SubreportProcessingEventArgs e)
        {
            // Lấy mã phiếu nhập truyền từ report cha
            int maPhieuNhap = int.Parse(e.Parameters["paMaPhieuNhap"].Values[0]);
            //Lấy dữ liệu cho report con
            List<rptPhieuNhap_CTPhieuNhapDTO> lsCTPN = rptPhieuNhap_CTPhieuNhapBUS.DoiMaNguyenLieuThanhTenNguyenLieu(maPhieuNhap);
            //Đỗ dữ liệu cho report con
            e.DataSources.Add(new ReportDataSource("DSCHITIETPHIEUNHAP", lsCTPN));
        }

        public void HienThiMonTheoNhom()
        {
            List<LoaiMonDTO> lsLoaiMon = LoaiMonBUS.LayDanhSachLoaiMon();
            rpvBaoCao.LocalReport.ReportEmbeddedResource = path + "rptMonTheoNhom.rdlc";
            rpvBaoCao.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DSMON", lsLoaiMon));

            rpvBaoCao.RefreshReport();
        }

        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            //Lấy mã loại truyền từ report cha
            int maLoai = int.Parse(e.Parameters["paMaLoai"].Values[0]);
            //Lấy dữ liệu cho report con
            List<MonDTO> lsMon = MonBUS.LayDanhSachMon(maLoai);
            //Đỗ dữ liệu cho report con
            e.DataSources.Add(new ReportDataSource("DSMON", lsMon));
        }

        public void HienThiThongTinHoaDonMoiNhat()
        {
            List<rptHoaDon_TaiKhoanDTO> lsHoaDon_TK = rptHoaDon_TaiKhoanBUS.LayHoaDonMaMoiNhat();
            rpvBaoCao.LocalReport.ReportEmbeddedResource = path + "rptHoaDonVuaLapMoiNhat.rdlc";
            rpvBaoCao.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing5);
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("HOADONMOINHAT", lsHoaDon_TK));
            rpvBaoCao.RefreshReport();
        }

        private void LocalReport_SubreportProcessing5(object sender, SubreportProcessingEventArgs e)
        {
            //Lấy mã hóa đơn truyền từ report cha
            int maHD = int.Parse(e.Parameters["paMaHoaDon"].Values[0]);
            //Lấy dữ liệu cho report con
            List<rptMon_CTHDDTO> lsMon_CTHD = rptMon_CTHDBUS.DoiMaMonThanhTenMon(maHD);
            //Đỗ dữ liệu cho report con
            e.DataSources.Add(new ReportDataSource("CHITIETHOADON", lsMon_CTHD));
        }

        private void FrmHienThiBaoCao_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMain.Instance.TopMost = FrmMain.topMost;
        }
    }
}
