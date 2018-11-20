﻿using System;
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
        string s = "QuanLyQuanCF_TS.Reports.";

        public void HienTatCaMon()
        {
            List<rptMon_LoaiMonDTO> lsMon = rptMon_LoaiMonBUS.DoiMaLoaiMonThanhTenLoaiMon();
            rpvBaoCao.LocalReport.ReportEmbeddedResource = s + "rptTatCaMon.rdlc";
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DSMON", lsMon));
            rpvBaoCao.RefreshReport();
        }
        

        public void HienMonTheoLoai(int maMon)
        {
            List<MonDTO> lsMon = MonBUS.LayDanhSachMon(maMon);
            rpvBaoCao.LocalReport.ReportEmbeddedResource = s + "rptMonTheoLoai.rdlc";
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DSMON", lsMon));
            rpvBaoCao.RefreshReport();
        }

        public void HienTatCaNguyenLieu()
        {
            List<NguyenLieuDTO> lsNguyenLieu = NguyenLieuBUS.LayDanhSachNguyenLieu();
            rpvBaoCao.LocalReport.ReportEmbeddedResource = s + "rptTatCaNguyenLieu.rdlc";
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DSNGUYENLIEU", lsNguyenLieu));
            rpvBaoCao.RefreshReport();
        }

        public void HienThiTatCacHoaDon()
        {
            List<rptHoaDon_TaiKhoanDTO> lsHoaDon_TK = rptHoaDon_TaiKhoanBUS.DoiMaNhanVienThanhTenNhanVien();
            rpvBaoCao.LocalReport.ReportEmbeddedResource = s + "rptTatCaHoaDon.rdlc";
            rpvBaoCao.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing1);
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DSHOADON", lsHoaDon_TK));
            rpvBaoCao.RefreshReport();
        }

        private void LocalReport_SubreportProcessing1(object sender, SubreportProcessingEventArgs e)
        {
            //Lấy mã loại truyền từ report cha
            int maHD = int.Parse(e.Parameters["paMaHoaDon"].Values[0]);
            //Lấy dữ liệu cho report con
            List<CTHoaDonDTO> lsCTHD = CTHoaDonBUS.LayDanhSachCTHD_Report(maHD);
            //Đỗ dữ liệu cho report con
            e.DataSources.Add(new ReportDataSource("DSCHITIETHD", lsCTHD));
        }

        public void HienThiTatCacHoaDonTheoThang(DateTime ngaylap)
        {
            List<rptHoaDon_TaiKhoanDTO> lsHoaDon = rptHoaDon_TaiKhoanBUS.DoiMaNhanVienThanhTenNhanVien(ngaylap);
            rpvBaoCao.LocalReport.ReportEmbeddedResource = s + "rptHoaDonTheoThang.rdlc";
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
            rpvBaoCao.LocalReport.ReportEmbeddedResource = s + "rptTatCaPhieuNhap.rdlc";
            rpvBaoCao.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing3);
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DSPHIEUNHAP_NCC", lsPhieuNhap_NCC));
            rpvBaoCao.RefreshReport();
        }

        private void LocalReport_SubreportProcessing3(object sender, SubreportProcessingEventArgs e)
        {
            //Lấy mã phiếu nhập truyền từ report cha
            int maPhieuNhap = int.Parse(e.Parameters["paMaPhieuNhap"].Values[0]);
            //Lấy dữ liệu cho report con
            List<CTPhieuNhapDTO> lsCTPN = CTPhieuNhapBUS.LayDanhSachCTPhieuNhap(maPhieuNhap);
            //Đỗ dữ liệu cho report con
            e.DataSources.Add(new ReportDataSource("DSCHITIETPHIEUNHAP", lsCTPN));
        }

        public void HienThiTatCacPhieuNhapTheoThang(DateTime ngaylap)
        {
            List<rptNhaCungCap_PhieuNhapDTO> lsPhieuNhap_NCC = rptNhaCungCap_PhieuNhapBUS.DoiMaNhaCungCapThanhTenNhaCungCap(ngaylap);
            rpvBaoCao.LocalReport.ReportEmbeddedResource = s + "rptPhieuNhapTheoThang.rdlc";
            rpvBaoCao.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing4);
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DSPHIEUNHAP", lsPhieuNhap_NCC));
            rpvBaoCao.RefreshReport();
        }

        private void LocalReport_SubreportProcessing4(object sender, SubreportProcessingEventArgs e)
        {
            // Lấy mã phiếu nhập truyền từ report cha
            int maPhieuNhap = int.Parse(e.Parameters["paMaPhieuNhap"].Values[0]);
            //Lấy dữ liệu cho report con
            List<CTPhieuNhapDTO> lsCTPN = CTPhieuNhapBUS.LayDanhSachCTPhieuNhap(maPhieuNhap);
            //Đỗ dữ liệu cho report con
            e.DataSources.Add(new ReportDataSource("DSCHITIETPHIEUNHAP", lsCTPN));
        }

        public void HienThiMonTheoNhom()
        {
            List<LoaiMonDTO> lsLoaiMon = LoaiMonBUS.LayDanhSachLoaiMon();
            rpvBaoCao.LocalReport.ReportEmbeddedResource = s + "rptMonTheoNhom.rdlc";
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

        
    }
}
