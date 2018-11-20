using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTPhieuNhapDTO
    {
        private int maPhieuNhap;
        private int maNguyenLieu;
        private int soLuong;
        private string donVi;
        private double donGia;

        public int MaPhieuNhap { get => maPhieuNhap; set => maPhieuNhap = value; }
        public int MaNguyenLieu { get => maNguyenLieu; set => maNguyenLieu = value; }
        public double DonGia { get => donGia; set => donGia = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string DonVi { get => donVi; set => donVi = value; }
    }
}
