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

        public static List<LoaiMonDTO> LayDanhSachLoaiMon(string timKiem = "", bool trangThai = false)
        {
            return LoaiMonDAO.LayDanhSachLoaiMon(timKiem, trangThai);
        }

        public static bool ThemLoaiMon(LoaiMonDTO loaiMon, List<CTLoaiMon_LoaiToppingDTO> lsLoaiMon_LoaiTopping)
        {
            if (LoaiMonDAO.ThemLoaiMon(loaiMon))
            {
                if (CTLoaiMon_LoaiToppingBUS.ThemLoaiMon_LoaiTopping(lsLoaiMon_LoaiTopping))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool XoaLoaiMon(int maLoaiMon)
        {
            if (MonBUS.XoaTatCaMonTheoLoai(maLoaiMon))
            {
                if (CTLoaiMon_LoaiToppingBUS.XoaLoaiMon_LoaiToppingTheoLoaiMon(maLoaiMon))
                {
                    if (LoaiMonDAO.XoaLoaiMon(maLoaiMon))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool SuaLoaiMon(LoaiMonDTO loaiMon, List<CTLoaiMon_LoaiToppingDTO> lsLoaiMon_LoaiTopping)
        {
            if (CTLoaiMon_LoaiToppingBUS.SuaLoaiMon_LoaiTopping(loaiMon.MaLoaiMon, lsLoaiMon_LoaiTopping))
            {
                if (LoaiMonDAO.SuaLoaiMon(loaiMon))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
