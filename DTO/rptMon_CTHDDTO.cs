using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class rptMon_CTHDDTO
    {
        int maCTHD;
        string tenMon;
        double donGia;
        int soLuong;
        string ghiChu;

        public int MaCTHD { get => maCTHD; set => maCTHD = value; }
        public string TenMon { get => tenMon; set => tenMon = value; }
        public double DonGia { get => donGia; set => donGia = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
