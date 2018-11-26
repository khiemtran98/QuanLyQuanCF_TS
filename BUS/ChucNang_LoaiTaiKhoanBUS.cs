using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class ChucNang_LoaiTaiKhoanBUS
    {
        public static bool ThemChucNang_LoaiTaiKhoan(List<ChucNang_LoaiTaiKhoanDTO> lsChucNang_LoaiTaiKhoan)
        {
            foreach (ChucNang_LoaiTaiKhoanDTO chucNang_LoaiTaiKhoan in lsChucNang_LoaiTaiKhoan)
            {
                if (!ChucNang_LoaiTaiKhoanDAO.ThemChucNang_LoaiTaiKhoan(chucNang_LoaiTaiKhoan))
                {
                    return false;
                }
            }
            return true;
        }

        internal static bool XoaChucNang_LoaiTaiKhoan(int maLoaiTaiKhoan)
        {
            return ChucNang_LoaiTaiKhoanDAO.XoaChucNang_LoaiTaiKhoan(maLoaiTaiKhoan);
        }

        internal static bool SuaChucNang_LoaiTaiKhoan(int maLoaiTaiKhoan, List<ChucNang_LoaiTaiKhoanDTO> lsChucNang_LoaiTaiKhoan)
        {
            if (ChucNang_LoaiTaiKhoanDAO.XoaChucNang_LoaiTaiKhoan(maLoaiTaiKhoan))
            {
                if (lsChucNang_LoaiTaiKhoan.Count > 0)
                {
                    foreach (ChucNang_LoaiTaiKhoanDTO chucNang_LoaiTaiKhoan in lsChucNang_LoaiTaiKhoan)
                    {
                        if (!ChucNang_LoaiTaiKhoanDAO.ThemChucNang_LoaiTaiKhoan(chucNang_LoaiTaiKhoan))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public static List<ChucNang_LoaiTaiKhoanDTO> LayDanhSachChucNang_LoaiTaiKhoanTheoMaTaiKhoan(int maTaiKhoan)
        {
            return ChucNang_LoaiTaiKhoanDAO.LayDanhSachChucNang_LoaiTaiKhoanTheoMaTaiKhoan(maTaiKhoan);
        }

        public static List<ChucNang_LoaiTaiKhoanDTO> LayDanhSachChucNang_LoaiTaiKhoanTheoMaLoaiTaiKhoan(int maLoaiTaiKhoan)
        {
            return ChucNang_LoaiTaiKhoanDAO.LayDanhSachChucNang_LoaiTaiKhoanTheoMaLoaiTaiKhoan(maLoaiTaiKhoan);
        }
    }
}
