using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class ToppingBUS
    {
        public static List<ToppingDTO> LayDanhSachTopping(int maLoaiTopping = 0, string timkiem = "", bool trangThai = false)
        {
            return ToppingDAO.LayDanhSachTopping(maLoaiTopping, timkiem, trangThai);
        }

        public static int LaySoLuongToppingTheoLoai(int maLoaiMon)
        {
            return ToppingDAO.LaySoLuongToppingTheoLoai(maLoaiMon);
        }

        public static bool XoaToppingTheoLoai(int maLoaiTopping)
        {
            return ToppingDAO.XoaToppingTheoLoai(maLoaiTopping);
        }

        public static bool SuaTopping(ToppingDTO topping)
        {
            return ToppingDAO.SuaTopping(topping);
        }

        public static bool XoaTopping(int maTopping)
        {
            return ToppingDAO.XoaTopping(maTopping);
        }

        public static bool ThemTopping(ToppingDTO topping)
        {
            return ToppingDAO.ThemTopping(topping);
        }

        public static int LayMaToppingMoiNhat()
        {
            return ToppingDAO.LayMaToppingMoiNhat();
        }
    }
}
