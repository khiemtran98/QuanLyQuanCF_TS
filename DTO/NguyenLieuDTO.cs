using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguyenLieuDTO
    {
        private int maNguyenLieu;
        private string tenNguyenLieu;
        private int soLuong;
        private string donVi;

        public int MaNguyenLieu { get => maNguyenLieu; set => maNguyenLieu = value; }
        public string TenNguyenLieu { get => tenNguyenLieu; set => tenNguyenLieu = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string DonVi { get => donVi; set => donVi = value; }
    }
}
