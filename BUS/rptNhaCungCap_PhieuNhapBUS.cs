using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class rptNhaCungCap_PhieuNhapBUS
    {
        public static List<rptNhaCungCap_PhieuNhapDTO> DoiMaNhaCungCapThanhTenNhaCungCap()
        {
            return rptNhaCungCap_PhieuNhapDAO.DoiMaNhaCungCapThanhTenNhaCungCap();
        }

        public static List<rptNhaCungCap_PhieuNhapDTO> DoiMaNhaCungCapThanhTenNhaCungCap(DateTime ngay)
        {
            return rptNhaCungCap_PhieuNhapDAO.DoiMaNhaCungCapThanhTenNhaCungCap(ngay);
        }

        public static List<rptNhaCungCap_PhieuNhapDTO> DoiMaNhaCungCapThanhTenNhaCungCap(DateTime timeStart, DateTime timeEnd)
        {
            return rptNhaCungCap_PhieuNhapDAO.DoiMaNhaCungCapThanhTenNhaCungCap(timeStart, timeEnd);
        }

        public static List<rptNhaCungCap_PhieuNhapDTO> DoiMaNhaCungCapThanhTenNhaCungCapMaPhieuNhapMoiNhat()
        {
            return rptNhaCungCap_PhieuNhapDAO.DoiMaNhaCungCapThanhTenNhaCungCapMaPhieuNhapMoiNhat();
        }

        public static List<rptNhaCungCap_PhieuNhapDTO> TatCaPhieuNhapTrongNgay()
        {
            return rptNhaCungCap_PhieuNhapDAO.TatCaPhieuNhapTrongNgay();
        }

    }
}
