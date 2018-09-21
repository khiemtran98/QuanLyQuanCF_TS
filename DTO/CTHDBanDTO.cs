using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTHDBanDTO
    {
        private int maCTHDBan;
        private int maHD;
        private int maMon;
        private int combo;
        private int soLuong;
        private double donGia;

        public int MaCTHDBan { get => maCTHDBan; set => maCTHDBan = value; }
        public int MaHD { get => maHD; set => maHD = value; }
        public int MaMon { get => maMon; set => maMon = value; }
        public int Combo { get => combo; set => combo = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double DonGia { get => donGia; set => donGia = value; }
    }
}
