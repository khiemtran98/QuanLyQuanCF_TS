using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTHDBanDTO
    {
        private int maHoaDonBan;
        private int maMon;
        private int soLuong;
        private double donGia;

        public int MaHD { get => maHoaDonBan; set => maHoaDonBan = value; }
        public int MaMon { get => maMon; set => maMon = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double DonGia { get => donGia; set => donGia = value; }
    }
}
