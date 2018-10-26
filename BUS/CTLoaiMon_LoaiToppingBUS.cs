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
        public static bool ThemLoaiMon_LoaiTopping(List<CTLoaiMon_LoaiToppingDTO> loaiMon_LoaiTopping)
        {
            foreach(CTLoaiMon_LoaiToppingDTO loaiTopping in loaiMon_LoaiTopping)
            {
                if(!CTLoaiMon_LoaiToppingDAO.ThemLoaiMon_LoaiTopping(loaiTopping))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
