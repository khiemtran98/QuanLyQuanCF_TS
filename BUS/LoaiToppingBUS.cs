using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class LoaiToppingBUS
    {
        public static List<LoaiToppingDTO> LayDanhSachLoaiTopping(string timKiem = "", bool trangThai = true)
        {
            return LoaiToppingDAO.LayDanhSachLoaiTopping(timKiem, trangThai);
        }

        public static List<LoaiToppingDTO> LayDanhSachTatCaLoaiTopping()
        {
            return LoaiToppingDAO.LayDanhSachTatCaLoaiTopping();
        }

        public static List<LoaiToppingDTO> LayDanhSachCTLoaiMon_LoaiTopping(int maLoaiMon)
        {
            return LoaiToppingDAO.LayDanhSachCTLoaiMon_LoaiTopping(maLoaiMon);
        }

        public static bool ThemLoaiTopping(LoaiToppingDTO loaiTopping)
        {
            return LoaiToppingDAO.ThemLoaiTopping(loaiTopping);
        }

        public static bool XoaLoaiTopping(int maLoaiTopping)
        {
            //if (CTLoaiMon_LoaiToppingBUS.XoaLoaiMon_LoaiToppingTheoLoaiTopping(maLoaiTopping))
            //{
                if (ToppingBUS.XoaToppingTheoLoai(maLoaiTopping))
                {
                    return LoaiToppingDAO.XoaLoaiTopping(maLoaiTopping);
                }
            //}
            return false;
        }

        public static bool SuaLoaiTopping(LoaiToppingDTO loaiTopping)
        {
            return LoaiToppingDAO.SuaLoaiTopping(loaiTopping);
        }

        public static bool KhoiPhucLoaiTopping(int maLoaiTopping)
        {
            if (LoaiToppingDAO.KhoiPhucLoaiTopping(maLoaiTopping))
            {
                return ToppingDAO.KhoiPhucToppingTheoLoai(maLoaiTopping);
            }
            return false;
        }
    }
}
