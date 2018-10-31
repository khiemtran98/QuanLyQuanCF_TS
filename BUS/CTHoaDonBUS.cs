using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public static class CTHoaDonBUS
    {
        public static int LayMaCTHoaDonMoiNhat()
        {
            return CTHoaDon.LayMaCTHoaDonMoiNhat();
        }

        public static List<CTHoaDonDTO> LayDanhSachCTHD(int maHoaDon)
        {
            return CTHoaDon.LayDanhSachCTHD(maHoaDon);
        }
    }
}
