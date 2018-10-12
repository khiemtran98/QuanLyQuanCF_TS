using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class NhanVienBUS
    {
        public static void LuuTaiKhoanDangNhap(int maNhanVien)
        {
            NhanVienDAO.LuuTaiKhoanDangNhap(maNhanVien);
        }

        public static int LayTaiKhoanDangNhap()
        {
            return NhanVienDAO.LayTaiKhoanDangNhap();
        }

        public static List<NhanVienDTO> LayDanhSachNhanVien()
        {
            return NhanVienDAO.LayDanhSachNhanVien();
        }

        public static bool KiemTraDangNhap(int maNV, string matKhau)
        {
            return NhanVienDAO.KiemTraDangNhap(maNV, matKhau);
        }

        public static NhanVienDTO LayThongTinNhanVien(int maNV)
        {
            return NhanVienDAO.LayThongTinNhanVien(maNV);
        }
    }
}
