using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class LoaiTaiKhoanBUS
    {
        public static List<LoaiTaiKhoanDTO> LayDanhSachLoaiTaiKhoan(string timKiem = "")
        {
            return LoaiTaiKhoanDAO.LayDanhSachLoaiTaiKhoan(timKiem);
        }
    }
}
