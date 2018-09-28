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

        public static bool DangNhap(int maNV, string matKhau)
        {
            return NhanVienDAO.DangNhap(maNV, matKhau);
        }

        public static NhanVienDTO layThongTinNhanVien(int maNV)
        {
            return NhanVienDAO.layThongTinNhanVien(maNV);
        }
    }
}
