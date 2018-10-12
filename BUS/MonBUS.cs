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
        public static List<MonDTO> LayDanhSachMon(string timkiem = "")
        {
            return MonDAO.LayDanhSachMon(timkiem);
        }

        public static List<MonDTO> LayDanhSachMonTheoLoai(int maLoaiMon)
        {
            return MonDAO.LayDanhSachMonTheoLoai(maLoaiMon);
        }

        public static int LaySoLuongMonTheoLoai(int maLoaiMon)
        {
            return MonDAO.LaySoLuongMonTheoLoai(maLoaiMon);
        }
    }
}
