using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class HoaDonBUS
    {
        public static int LayMaHoaDonMoiNhat()
        {
            return HoaDonDAO.LayMaHoaDonMoiNhat();
        }

        public static bool LuuHoaDon(HoaDonDTO hoaDon, List<CTHoaDonDTO> lsCTHD, List<CTHoaDon_ToppingDTO> lsCTHD_Topping)
        {
            if (!HoaDonDAO.LuuHoaDon(hoaDon))
            {
                return false;
            }

            foreach (CTHoaDonDTO cthd in lsCTHD)
            {
                if (!CTHoaDonDAO.LuuCTHoaDon(cthd))
                {
                    return false;
                }
            }

            foreach (CTHoaDon_ToppingDTO cthd_topping in lsCTHD_Topping)
            {
                if (!CTHoaDon_ToppingDAO.LuuCTHoaDon_Topping(cthd_topping))
                {
                    return false;
                }
            }

            return true;
        }

        public static List<HoaDonDTO> LayDanhSachHoaDon()
        {
            return HoaDonDAO.LayDanhSachHoaDon();
        }

        // Lấy danh sách hóa đơn theo khoảng thời gian
        public static List<HoaDonDTO> GetListBillByTime(DateTime dateFrom, DateTime dateEnd)
        {
            return HoaDonDAO.GetListBillByTime(dateFrom, dateEnd);
        }

        // Lấy toàn bộ danh sách hóa đơn
        public static List<HoaDonDTO> GetEntireListBill()
        {
            return HoaDonDAO.LayDanhSachHoaDon();
        }

        // Lấy danh sách hóa đơn theo mốc thời gian 
        public static List<HoaDonDTO> GetListBillTimeline(DateTime dateTimeline)
        {
            return HoaDonDAO.GetListBillTimeline(dateTimeline);
        }
    }
}
