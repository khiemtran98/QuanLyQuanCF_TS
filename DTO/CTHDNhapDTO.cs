using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTHDNhapDTO
    {
        private int maHoaDonNhap;
        private int maNguyenLieu;
        private int khoiLuong;
        private double donGia;

        public int MaHoaDonNhap { get => maHoaDonNhap; set => maHoaDonNhap = value; }
        public int MaNguyenLieu { get => maNguyenLieu; set => maNguyenLieu = value; }
        public int KhoiLuong { get => khoiLuong; set => khoiLuong = value; }
        public double DonGia { get => donGia; set => donGia = value; }
    }
}
