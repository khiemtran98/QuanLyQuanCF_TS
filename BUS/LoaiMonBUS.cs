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
        public static int LayMaLoaiMonMoiNhat()
        {
            return LoaiMonDAO.LayMaLoaiMonMoiNhat();
        }

        public static List<LoaiMonDTO> LayDanhSachLoaiMon(string timKiem = "", bool trangThai = true)
        {
            return LoaiMonDAO.LayDanhSachLoaiMon(timKiem, trangThai);
        }

        public static List<LoaiMonDTO> LayDanhSachTatCaLoaiMon()
        {
            return LoaiMonDAO.LayDanhSachTatCaLoaiMon();
        }

        public static bool ThemLoaiMon(LoaiMonDTO loaiMon, List<CTLoaiMon_LoaiToppingDTO> lsLoaiMon_LoaiTopping)
        {
            if (LoaiMonDAO.ThemLoaiMon(loaiMon))
            {
                return CTLoaiMon_LoaiToppingBUS.ThemLoaiMon_LoaiTopping(lsLoaiMon_LoaiTopping);
            }
            return false;
        }

        public static bool XoaLoaiMon(int maLoaiMon)
        {
            if (MonBUS.XoaTatCaMonTheoLoai(maLoaiMon))
            {
                //if (CTLoaiMon_LoaiToppingBUS.XoaLoaiMon_LoaiToppingTheoLoaiMon(maLoaiMon))
                //{
                    return LoaiMonDAO.XoaLoaiMon(maLoaiMon);
                //}
            }
            return false;
        }

        public static bool SuaLoaiMon(LoaiMonDTO loaiMon, List<CTLoaiMon_LoaiToppingDTO> lsLoaiMon_LoaiTopping)
        {
            if (CTLoaiMon_LoaiToppingBUS.SuaLoaiMon_LoaiTopping(loaiMon.MaLoaiMon, lsLoaiMon_LoaiTopping))
            {
                return LoaiMonDAO.SuaLoaiMon(loaiMon);
            }
            return false;
        }

        public static bool KhoiPhucLoaiMon(int maLoaiMon)
        {
            if (LoaiMonDAO.KhoiPhucLoaiMon(maLoaiMon))
            {
                return MonDAO.KhoiPhucMonTheoLoai(maLoaiMon);
            }
            return false;
        }
    }
}
