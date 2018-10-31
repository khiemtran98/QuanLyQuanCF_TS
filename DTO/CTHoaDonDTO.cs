using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTHoaDonDTO
    {
        private int maCTHD;
        private int hoaDon;
        private int mon;
        private int soLuong;
        private double donGia;
        private string ghiChu;

        public int MaCTHD { get => maCTHD; set => maCTHD = value; }
        public int MaHoaDon { get => hoaDon; set => hoaDon = value; }
        public int MaMon { get => mon; set => mon = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double DonGia { get => donGia; set => donGia = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }

      
    }
}
