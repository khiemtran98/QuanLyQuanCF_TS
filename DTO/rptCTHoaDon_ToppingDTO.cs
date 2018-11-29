using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class rptCTHoaDon_ToppingDTO
    {
        int maCTHD;
        string tenTopping;
        int soLuong;
        double donGia;
        string ghiChu;

        public int MaCTHD { get => maCTHD; set => maCTHD = value; }
        public string TenTopping { get => tenTopping; set => tenTopping = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double DonGia { get => donGia; set => donGia = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
