using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public static class NguyenLieuBUS
    {
        public static int LayMaNguyenLieuMoiNhat()
        {
            return NguyenLieuDAO.LayMaNguyenLieuMoiNhat();
        }

        public static List<NguyenLieuDTO> LayDanhSachNguyenLieu(string timKiem = "", bool trangThai = true)
        {
            return NguyenLieuDAO.LayDanhSachNguyenLieu(timKiem, trangThai);
        }

        public static List<NguyenLieuDTO> LayDanhSachTatCaNguyenLieu()
        {
            return NguyenLieuDAO.LayDanhSachTatCaNguyenLieu();
        }

        public static bool ThemNguyenLieu(NguyenLieuDTO nguyenLieu)
        {
            return NguyenLieuDAO.ThemNguyenLieu(nguyenLieu);
        }

        public static bool XoaNguyenLieu(int maNguyenLieu)
        {
            return NguyenLieuDAO.XoaNguyenLieu(maNguyenLieu);
        }

        public static bool SuaNguyenLieu(NguyenLieuDTO nguyenLieu)
        {
            return NguyenLieuDAO.SuaNguyenLieu(nguyenLieu);
        }

        public static bool KhoiPhucNguyenLieu(int maNguyenLieu)
        {
            return NguyenLieuDAO.KhoiPhucNguyenLieu(maNguyenLieu);
        }
    }
}
