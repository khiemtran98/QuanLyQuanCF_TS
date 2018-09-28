using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class MonBUS
    {
        public static List<MonDTO> layDanhSachMon()
        {
            return MonDAO.layDanhSachMon();
        }
    }
}
