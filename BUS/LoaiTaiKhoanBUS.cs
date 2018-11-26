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
        public static int LayMaLoaiTaiKhoanMoiNhat()
        {
            return LoaiTaiKhoanDAO.LayMaLoaiTaiKhoanMoiNhat();
        }

        public static List<LoaiTaiKhoanDTO> LayDanhSachLoaiTaiKhoan(string timKiem = "", bool trangThai = true)
        {
            return LoaiTaiKhoanDAO.LayDanhSachLoaiTaiKhoan(timKiem, trangThai);
        }

        public static List<LoaiTaiKhoanDTO> LayDanhSachTatCaLoaiTaiKhoan()
        {
            return LoaiTaiKhoanDAO.LayDanhSachTatCaLoaiTaiKhoan();
        }

        public static bool ThemLoaiTaiKhoan(LoaiTaiKhoanDTO loaiTaiKhoan, List<ChucNang_LoaiTaiKhoanDTO> lsChucNang_LoaiTaiKhoan)
        {
            if (LoaiTaiKhoanDAO.ThemLoaiTaiKhoan(loaiTaiKhoan))
            {
                return ChucNang_LoaiTaiKhoanBUS.ThemChucNang_LoaiTaiKhoan(lsChucNang_LoaiTaiKhoan);
            }
            return false;
        }

        public static bool XoaLoaiTaiKhoan(int maLoaiTaiKhoan)
        {
            if (TaiKhoanBUS.XoaTaiKhoanTheoLoai(maLoaiTaiKhoan))
            {
                if (ChucNang_LoaiTaiKhoanBUS.XoaChucNang_LoaiTaiKhoan(maLoaiTaiKhoan))
                {
                    return LoaiTaiKhoanDAO.XoaLoaiTaiKhoan(maLoaiTaiKhoan);
                }
            }
            return false;
        }

        public static bool SuaLoaiTaiKhoan(LoaiTaiKhoanDTO loaiTaiKhoan, List<ChucNang_LoaiTaiKhoanDTO> lsChucNang_LoaiTaiKhoan)
        {
            if (ChucNang_LoaiTaiKhoanBUS.SuaChucNang_LoaiTaiKhoan(loaiTaiKhoan.MaLoaiTaiKhoan, lsChucNang_LoaiTaiKhoan))
            {
                return LoaiTaiKhoanDAO.SuaLoaiTaiKhoan(loaiTaiKhoan);
            }
            return false;
        }

        public static bool KhoiPhucLoaiTaiKhoan(int maLoaiTaiKhoan)
        {
            return LoaiTaiKhoanDAO.KhoiPhucLoaiTaiKhoan(maLoaiTaiKhoan);
        }
    }
}
