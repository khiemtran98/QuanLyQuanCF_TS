using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietMonDTO
    {
        private int maCTHD;
        private int maTopping;
        private int soLuong;
        private double donGia;

        public int MaCTHD { get => maCTHD; set => maCTHD = value; }
        public int MaTopping { get => maTopping; set => maTopping = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double DonGia { get => donGia; set => donGia = value; }
    }
}
