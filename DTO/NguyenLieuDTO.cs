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
        private int nhaCungCap;
        private double giaNhap;

        public int MaNguyenLieu { get => maNguyenLieu; set => maNguyenLieu = value; }
        public string TenNguyenLieu { get => tenNguyenLieu; set => tenNguyenLieu = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int NhaCungCap { get => nhaCungCap; set => nhaCungCap = value; }
        public double GiaNhap { get => giaNhap; set => giaNhap = value; }
    }
}
