using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class CTPhieuNhapBUS
    {
        public static List<CTPhieuNhapDTO> LayDanhSachCTPhieuNhap(int maPhieuNhap)
        {
            return CTPhieuNhapDAO.LayDanhSachCTPhieuNhap(maPhieuNhap);
        }
    }
}
