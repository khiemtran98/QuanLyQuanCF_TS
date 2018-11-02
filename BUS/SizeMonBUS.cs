using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class SizeMonBUS
    {
        public static List<SizeMonDTO> LaySizeMon(int maMon)
        {
            return SizeMonDAO.LaySizeMon(maMon);
        }

        public static double LayGiaTien(int maMon, string size)
        {
            return SizeMonDAO.LayGiaTien(maMon, size);
        }
    }
}
