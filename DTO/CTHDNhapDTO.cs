using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTHDNhapDTO
    {
        private int maHD;
        private int maNguyenLieu;
        private int soLuong;
        private double donGia;

        public int MaHD { get => maHD; set => maHD = value; }
        public int MaNguyenLieu { get => maNguyenLieu; set => maNguyenLieu = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double DonGia { get => donGia; set => donGia = value; }
    }
}
