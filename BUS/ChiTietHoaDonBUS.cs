using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public static class ChiTietHoaDonBUS
    {
        public static int LayMaChiTietHoaDonMoiNhat()
        {
            return ChiTietHoaDonDAO.LayMaChiTietHoaDonMoiNhat();
        }
    }
}
