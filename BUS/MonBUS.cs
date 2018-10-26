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
        public static List<MonDTO> LayDanhSachMonTheoLoai(int maLoaiMon, string timkiem = "")
        {
            return MonDAO.LayDanhSachMonTheoLoai(maLoaiMon, timkiem);
        }

        public static int LaySoLuongMonTheoLoai(int maLoaiMon)
        {
            return MonDAO.LaySoLuongMonTheoLoai(maLoaiMon);
        }

        public static bool KiemTraMonLaNuocUong(int maLoaiMon)
        {
            return MonDAO.KiemTraMonLaNuocUong(maLoaiMon);
        }
    }
}
