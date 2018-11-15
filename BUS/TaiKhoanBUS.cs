using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class TaiKhoanBUS
    {
        public static void LuuTaiKhoanDangNhap(int maTaiKhoan)
        {
            TaiKhoanDAO.LuuTaiKhoanDangNhap(maTaiKhoan);
        }

        public static int LayTaiKhoanDangNhap()
        {
            return TaiKhoanDAO.LayTaiKhoanDangNhap();
        }

        public static int LayMaTaiKhoanMoiNhat()
        {
            return TaiKhoanDAO.LayMaTaiKhoanMoiNhat();
        }

        public static List<TaiKhoanDTO> LayDanhSachTaiKhoan(string timKiem = "", bool trangThai = true)
        {
            return TaiKhoanDAO.LayDanhSachTaiKhoan(timKiem, trangThai);
        }

        public static bool KiemTraDangNhap(int maTaiKhoan, string matKhau)
        {
            return TaiKhoanDAO.KiemTraDangNhap(maTaiKhoan, matKhau);
        }

        public static TaiKhoanDTO LayThongTinTaiKhoan(int maTaiKhoan)
        {
            return TaiKhoanDAO.LayThongTinTaiKhoan(maTaiKhoan);
        }

        public static string LayTenLoaiTaiKhoan(int loaiTaiKhoan)
        {
            return TaiKhoanDAO.LayTenLoaiTaiKhoan(loaiTaiKhoan);
        }

        public static bool ThemTaiKhoan(TaiKhoanDTO taiKhoan)
        {
            return TaiKhoanDAO.ThemTaiKhoan(taiKhoan);
        }

        public static bool XoaTaiKhoan(int maTaiKhoan)
        {
            return TaiKhoanDAO.XoaTaiKhoan(maTaiKhoan);
        }

        public static bool SuaTaiKhoan(TaiKhoanDTO taiKhoan)
        {
            return TaiKhoanDAO.SuaTaiKhoan(taiKhoan);
        }

        public static bool XoaTaiKhoanTheoLoai(int maLoaiTaiKhoan)
        {
            return TaiKhoanDAO.XoaTaiKhoanTheoLoai(maLoaiTaiKhoan);
        }

        public static bool KhoiPhucTaiKhoan(int maTaiKhoan)
        {
            return TaiKhoanDAO.KhoiPhucTaiKhoan(maTaiKhoan);
        }
    }
}
