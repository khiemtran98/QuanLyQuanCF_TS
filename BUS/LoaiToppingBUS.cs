using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class LoaiToppingBUS
    {
        public static List<LoaiToppingDTO> LayDanhSachLoaiTopping()
        {
            return LoaiToppingDAO.LayDanhSachLoaiTopping();
        }

        public static List<LoaiToppingDTO> LayDanhSachLoaiToppingTheoMon(int maLoaiMon = 0)
        {
            return LoaiToppingDAO.LayDanhSachLoaiToppingTheoMon(maLoaiMon);
        }
    }
}
