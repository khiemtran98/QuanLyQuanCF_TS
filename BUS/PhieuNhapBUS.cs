using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class PhieuNhapBUS
    {
        public static int LayMaPhieuNhapMoiNhat()
        {
            return PhieuNhapDAO.LayMaPhieuNhapMoiNhat();
        }

        public static bool LuuPhieuNhap(PhieuNhapDTO phieuNhap, List<CTPhieuNhapDTO> lsCTPhieuNhap)
        {
            if (!PhieuNhapDAO.LuuPhieuNhap(phieuNhap))
            {
                return false;
            }

            foreach (CTPhieuNhapDTO ctpn in lsCTPhieuNhap)
            {
                if (!CTPhieuNhapDAO.LuuCTPhieuNhap(ctpn))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
