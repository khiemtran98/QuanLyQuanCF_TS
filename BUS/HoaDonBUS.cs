using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public static class HoaDonBUS
    {
        public static int LayMaHoaDonMoiNhat()
        {
            return HoaDonDAO.LayMaHoaDonMoiNhat();
        }

        public static bool LuuHoaDon(HoaDonDTO hoaDon, List<ChiTietHoaDonDTO> lsCTHD, List<ChiTietMonDTO> lsCTM)
        {
            if (!HoaDonDAO.LuuHoaDon(hoaDon))
            {
                return false;
            }

            foreach (ChiTietHoaDonDTO cthd in lsCTHD)
            {
                if (!ChiTietHoaDonDAO.LuuChiTietHoaDon(cthd))
                {
                    return false;
                }
            }

            foreach (ChiTietMonDTO ctm in lsCTM)
            {
                if (!ChiTietMonDAO.LuuChiTietMon(ctm))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
