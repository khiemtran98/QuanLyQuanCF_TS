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

        public static List<rptNhaCungCap_PhieuNhapDTO> DoiMaNhaCungCapThanhTenNhaCungCap(DateTime timeLine)
        {
            return rptNhaCungCap_PhieuNhapDAO.DoiMaNhaCungCapThanhTenNhaCungCap(timeLine);
        }
    }
}
