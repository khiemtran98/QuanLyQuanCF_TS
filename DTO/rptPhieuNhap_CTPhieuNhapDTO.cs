using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class rptPhieuNhap_CTPhieuNhapDTO
    {
        int maCTPN;
        string tenNguyenLieu;
        double soLuong;
        string donViTinh;
        double donGia;

        public int MaCTPN { get => maCTPN; set => maCTPN = value; }
        public string TenNguyenLieu { get => tenNguyenLieu; set => tenNguyenLieu = value; }
        public double SoLuong { get => soLuong; set => soLuong = value; }
        public string DonViTinh { get => donViTinh; set => donViTinh = value; }
        public double DonGia { get => donGia; set => donGia = value; }
       
    }
}
