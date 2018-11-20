using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class rptMon_CTHDBUS
    {
        public static List<rptMon_CTHDDTO> DoiMaMonThanhTenMon(int maHD)
        {
            return rptMon_CTHDDAO.DoiMaMonThanhTenMon(maHD);
        }
    }
}
