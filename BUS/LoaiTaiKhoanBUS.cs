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
        public static List<LoaiTaiKhoanDTO> LayDanhSachLoaiTaiKhoan(string timKiem = "", bool trangThai = false)
        {
            return LoaiTaiKhoanDAO.LayDanhSachLoaiTaiKhoan(timKiem, trangThai);
        }

        public static bool ThemLoaiTaiKhoan(LoaiTaiKhoanDTO loaiTaiKhoan)
        {
            return LoaiTaiKhoanDAO.ThemLoaiTaiKhoan(loaiTaiKhoan);
        }

        public static bool XoaLoaiTaiKhoan(int maLoaiTaiKhoan)
        {
            if (TaiKhoanBUS.XoaTaiKhoanTheoLoai(maLoaiTaiKhoan))
            {
                return LoaiTaiKhoanDAO.XoaLoaiTaiKhoan(maLoaiTaiKhoan);
            }
            return false;
        }

        public static bool SuaLoaiTaiKhoan(LoaiTaiKhoanDTO loaiTaiKhoan)
        {
            return LoaiTaiKhoanDAO.SuaLoaiTaiKhoan(loaiTaiKhoan);
        }
    }
}
