using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class PhieuNhapBUS
    {
        public static List<PhieuNhapDTO> LayDanhSachPhieuNhap(bool trangThai = true)
        {
            return PhieuNhapDAO.LayDanhSachPhieuNhap(trangThai);
        }

        public static List<PhieuNhapDTO> LayDanhSachPhieuNhapTheoNgay(DateTime ngayNhap, bool trangThai = true)
        {
            return PhieuNhapDAO.LayDanhSachPhieuNhapTheoNgay(ngayNhap, trangThai);
        }

        public static int LayMaPhieuNhapMoiNhat()
        {
            return PhieuNhapDAO.LayMaPhieuNhapMoiNhat();
        }

        public static bool LuuPhieuNhap(PhieuNhapDTO phieuNhap, List<CTPhieuNhapDTO> lsCTPhieuNhap)
        {
            if (!PhieuNhapDAO.LuuPhieuNhap(phieuNhap))
            {
                return false;
            }

            foreach (CTPhieuNhapDTO ctpn in lsCTPhieuNhap)
            {
                if (!CTPhieuNhapDAO.LuuCTPhieuNhap(ctpn))
                {
                    return false;
                }
                if (!NguyenLieuDAO.TangSoLuongTonKho(ctpn))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool XoaPhieuNhap(int maPhieuNhap, List<CTPhieuNhapDTO> lsCTPhieuNhap)
        {
            if (PhieuNhapDAO.XoaPhieuNhap(maPhieuNhap))
            {
                foreach (CTPhieuNhapDTO ctpn in lsCTPhieuNhap)
                {
                    if (!NguyenLieuDAO.GiamSoLuongTonKho(ctpn))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool KhoiPhucPhieuNhap(int maPhieuNhap, List<CTPhieuNhapDTO> lsCTPhieuNhap)
        {
            if (PhieuNhapDAO.KhoiPhucPhieuNhap(maPhieuNhap))
            {
                foreach (CTPhieuNhapDTO ctpn in lsCTPhieuNhap)
                {
                    if (!NguyenLieuDAO.TangSoLuongTonKho(ctpn))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static double LayDoanhSoPhieuNhapTheoThang(int thang)
        {
            return PhieuNhapDAO.LayDoanhSoPhieuNhapTheoThang(thang);
        }

        public static double LayDoanhSoPhieuNhapTheoNam(int nam)
        {
            return PhieuNhapDAO.LayDoanhSoPhieuNhapTheoNam(nam);
        }
    }
}
