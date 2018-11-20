using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class rptHoaDon_TaiKhoanBUS
    {
        public static List<rptHoaDon_TaiKhoanDTO> DoiMaNhanVienThanhTenNhanVien()
        {
            return rptHoaDon_TaiKhoanDAO.DoiMaNhanVienThanhTenNhanVien();
        }

        public static List<rptHoaDon_TaiKhoanDTO> DoiMaNhanVienThanhTenNhanVien(DateTime timeLine)
        {
            return rptHoaDon_TaiKhoanDAO.DoiMaNhanVienThanhTenNhanVien(timeLine);
        }
    }
}
