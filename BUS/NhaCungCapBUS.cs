using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class NhaCungCapBUS
    {
        public static List<NhaCungCapDTO> LayDanhSachNhaCungCap(string timKiem = "", bool trangThai = true)
        {
            return NhaCungCapDAO.LayDanhSachNhaCungCap(timKiem, trangThai);
        }

        public static bool ThemNhaCungCap(NhaCungCapDTO nhaCungCap)
        {
            return NhaCungCapDAO.ThemNhaCungCap(nhaCungCap);
        }

        public static bool XoaNhaCungCap(int maNhaCungCap)
        {
            return NhaCungCapDAO.XoaNhaCungCap(maNhaCungCap);
        }

        public static bool SuaNhaCungCap(NhaCungCapDTO nhaCungCap)
        {
            return NhaCungCapDAO.SuaNhaCungCap(nhaCungCap);
        }

        public static bool KhoiPhucNhaCungCap(int maNhaCungCap)
        {
            return NhaCungCapDAO.KhoiPhucLoaiMon(maNhaCungCap);
        }
    }
}
