using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class rptPhieuNhap_CTPhieuNhapDTO
    {
        string tenNguyenLieu;
        double soLuong;
        string donViTinh;
        double donGia;

        public string TenNguyenLieu { get => tenNguyenLieu; set => tenNguyenLieu = value; }
        public double SoLuong { get => soLuong; set => soLuong = value; }
        public string DonViTinh { get => donViTinh; set => donViTinh = value; }
        public double DonGia { get => donGia; set => donGia = value; }
    }
}
