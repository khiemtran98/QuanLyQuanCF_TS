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
        public static List<ToppingDTO> LayDanhSachToppingTheoLoai(int maLoaiTopping, string timkiem = "")
        {
            return ToppingDAO.LayDanhSachToppingTheoLoai(maLoaiTopping, timkiem);
        }

        public static int LaySoLuongToppingTheoLoai(int maLoaiMon)
        {
            return ToppingDAO.LaySoLuongToppingTheoLoai(maLoaiMon);
        }
    }
}
