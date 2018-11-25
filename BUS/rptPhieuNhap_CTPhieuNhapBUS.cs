using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public static class rptPhieuNhap_CTPhieuNhapBUS
    {
        public static List<rptPhieuNhap_CTPhieuNhapDTO> DoiMaNguyenLieuThanhTenNguyenLieu(int maPhieuNhap)
        {
            return rptPhieuNhap_CTPhieuNhapDAO.DoiMaNguyenLieuThanhTenNguyenLieu(maPhieuNhap);
        }
    }
}
