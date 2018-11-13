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
        public static List<NhaCungCapDTO> LayDanhSachNhaCungCap(string timKiem = "", bool trangThai = false)
        {
            return NhaCungCapDAO.LayDanhSachNhaCungCap(timKiem, trangThai);
        }
    }
}
