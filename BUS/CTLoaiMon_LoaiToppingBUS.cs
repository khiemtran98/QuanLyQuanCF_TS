using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class CTLoaiMon_LoaiToppingBUS
    {
        public static bool ThemLoaiMon_LoaiTopping(List<CTLoaiMon_LoaiToppingDTO> lsLoaiMon_LoaiTopping)
        {
            foreach (CTLoaiMon_LoaiToppingDTO loaiMon_LoaiTopping in lsLoaiMon_LoaiTopping)
            {
                if (!CTLoaiMon_LoaiToppingDAO.ThemLoaiMon_LoaiTopping(loaiMon_LoaiTopping))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool XoaLoaiMon_LoaiToppingTheoLoaiMon(int maLoaiMon)
        {
            return CTLoaiMon_LoaiToppingDAO.XoaLoaiMon_LoaiToppingTheoLoaiMon(maLoaiMon);
        }

        public static bool XoaLoaiMon_LoaiToppingTheoLoaiTopping(int maLoaiTopping)
        {
            return CTLoaiMon_LoaiToppingDAO.XoaLoaiMon_LoaiToppingTheoLoaiTopping(maLoaiTopping);
        }

        public static bool SuaLoaiMon_LoaiTopping(int maLoaiMon, List<CTLoaiMon_LoaiToppingDTO> lsLoaiMon_LoaiTopping)
        {
            if (CTLoaiMon_LoaiToppingDAO.XoaLoaiMon_LoaiToppingTheoLoaiMon(maLoaiMon))
            {
                if (lsLoaiMon_LoaiTopping.Count > 0)
                {
                    foreach (CTLoaiMon_LoaiToppingDTO loaiMon_LoaiTopping in lsLoaiMon_LoaiTopping)
                    {
                        if (!CTLoaiMon_LoaiToppingDAO.ThemLoaiMon_LoaiTopping(loaiMon_LoaiTopping))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public static List<CTHoaDon_ToppingDTO> LayDanhSachTopping(int maHoaDon)
        {
            return CTHoaDon_ToppingDAO.LayDanhSachTopping(maHoaDon);
        }
    }
}
