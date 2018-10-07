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
        public static List<NhanVienDTO> layDanhSachNhanVien()
        {
            return NhanVienDAO.layDanhSachNhanVien();
        }

        public static bool KiemTraDangNhap(int maNV, string matKhau)
        {
            return NhanVienDAO.KiemTraDangNhap(maNV, matKhau);
        }

        public static NhanVienDTO layThongTinNhanVien(int maNV)
        {
            return NhanVienDAO.LayThongTinNhanVien(maNV);
        }
    }
}
