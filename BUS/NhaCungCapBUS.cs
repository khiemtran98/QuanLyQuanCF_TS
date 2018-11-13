using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public static class NhaCungCapBUS
    {
        public static List<NhaCungCapDTO> GetEntireProvider()
        {
            return NhaCungCapDAO.GetEntireProvider();
        }
    }
}
