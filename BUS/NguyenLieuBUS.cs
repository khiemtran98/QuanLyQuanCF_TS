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
        public static List<NguyenLieuDTO> LoadDanhSachNguyenLieu(string timKiem = "")
        {
            return NguyenLieuDAO.LayDanhSachNguyenLieu(timKiem);
        }

        public static bool ThemNguyenLieu(NguyenLieuDTO nl)
        {
            return NguyenLieuDAO.ThemNguyenLieu(nl);
        }

        public static bool XoaNguyenLieu(int maNguyenLieu)
        {
            return NguyenLieuDAO.XoaNguyenLieu(maNguyenLieu);
        }

        public static bool SuaNguyenLieu(NguyenLieuDTO nl)
        {
            return NguyenLieuDAO.SuaNguyenLieu(nl);
        }
    }
}
