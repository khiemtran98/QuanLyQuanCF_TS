using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class rptMon_LoaiMonBUS
    {
        public static List<rptMon_LoaiMonDTO> DoiMaLoaiMonThanhTenLoaiMon()
        {
            return rptMon_LoaiMonDAO.DoiMaLoaiMonThanhLoaiMon();
        }
        public static List<rptMon_LoaiMonDTO> DoiMaLoaiMonThanhTenLoaiMon(int maMon)
        {
            return rptMon_LoaiMonDAO.DoiMaLoaiMonThanhLoaiMon(maMon);
        }
    }
}
