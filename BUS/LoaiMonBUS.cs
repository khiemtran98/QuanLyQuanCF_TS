using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class LoaiMonBUS
    {
        public static List<LoaiMonDTO> LayDanhSachLoaiMon(string timKiem = "")
        {
            return LoaiMonDAO.LayDanhSachLoaiMon(timKiem);
        }

        public static List<LoaiMonDTO> LayDanhSachTatCaLoaiMon(string timKiem = "")
        {
            return LoaiMonDAO.LayDanhSachTatCaLoaiMon(timKiem);
        }

        public static bool ThemLoaiMon(LoaiMonDTO loaiMon)
        {
            return LoaiMonDAO.ThemLoaiMon(loaiMon);
        }

        public static bool XoaLoaiMon(int maLoaiMon)
        {
            return LoaiMonDAO.XoaLoaiMon(maLoaiMon);
        }

        public static bool SuaLoaiMon(LoaiMonDTO loaiMon)
        {
            return LoaiMonDAO.SuaLoaiMon(loaiMon);
        }

        public static int LayMaLoaiMonMoiNhat()
        {
            return LoaiMonDAO.LayMaLoaiMonMoiNhat();
        }
    }
}
