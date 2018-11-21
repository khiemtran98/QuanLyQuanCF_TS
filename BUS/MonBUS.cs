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
        public static List<MonDTO> LayDanhSachMon(int maLoaiMon = 0, string timkiem = "", bool trangThai = true)
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

        public static int LayMaMonMoiNhat()
        {
            return MonDAO.LayMaMonMoiNhat();
        }

        public static bool ThemMon(MonDTO mon)
        {
            return MonDAO.ThemMon(mon);
        }

        public static bool XoaMon(int maMon)
        {
            return MonDAO.XoaMon(maMon);
        }

        public static bool SuaMon(MonDTO mon)
        {
            return MonDAO.SuaMon(mon);
        }

        public static bool KhoiPhucMon(int maMon)
        {
            return MonDAO.KhoiPhucMon(maMon);
        }
    }
}
