using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class CTHoaDonBUS
    {
        public static int LayMaCTHoaDonMoiNhat()
        {
            return CTHoaDonDAO.LayMaCTHoaDonMoiNhat();
        }

        //public static List<CTHoaDonDTO> LayDanhSachCTHD(int maHoaDon)
        //{
        //    return CTHoaDonDAO.LayDanhSachCTHD(maHoaDon);
        //}

        //public static List<CTHoaDonDTO> LayDanhSachCTHD_Report(int maHD)
        //{
        //    return CTHoaDonDAO.LayDanhSachCTHD_Report(maHD);
        //}
    }
}
