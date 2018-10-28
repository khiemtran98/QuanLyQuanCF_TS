using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class MonBUS
    {
        public static List<MonDTO> LayDanhSachMon(int maLoaiMon = 0, string timkiem = "", bool trangThai = false)
        {
            return MonDAO.LayDanhSachMon(maLoaiMon, timkiem, trangThai);
        }

        public static int LaySoLuongMonTheoLoai(int maLoaiMon)
        {
            return MonDAO.LaySoLuongMonTheoLoai(maLoaiMon);
        }

        public static bool KiemTraMonLaNuocUong(int maLoaiMon)
        {
            return MonDAO.KiemTraMonLaNuocUong(maLoaiMon);
        }

        public static bool XoaTatCaMonTheoLoai(int maLoaiMon)
        {
            return MonDAO.XoaTatCaMonTheoLoai(maLoaiMon);
        }
    }
}
