using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public static class CTPhieuNhapBUS
    {
        public static List<CTPhieuNhapDTO> GetListDetailMaterials(int maPhieuNhap)
        {
            return CTPhieuNhapDAO.GetListDetailMaterials(maPhieuNhap);
        }
    }
}
