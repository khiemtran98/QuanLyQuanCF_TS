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
        public static List<LoaiToppingDTO> LayDanhSachLoaiTopping(int maLoaiMon)
        {
            return LoaiToppingDAO.LayDanhSachLoaiTopping(maLoaiMon);
        }
    }
}
