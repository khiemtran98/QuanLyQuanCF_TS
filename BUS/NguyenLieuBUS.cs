using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public static class NguyenLieuBUS
    {
        public static List<NguyenLieuDTO> GetEntireMaterials()
        {
            return NguyenLieuDAO.GetEntireMaterials();
        }
    }
}
