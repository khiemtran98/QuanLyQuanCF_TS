using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ToppingDTO
    {
        public ToppingDTO()
        {
            hinh = "default-product.png";
        }

        private int maTopping;
        private string tenTopping;
        private int loaiTopping;
        private double giaTien;
        private string hinh;
        private bool trangThai;

        public int MaTopping { get => maTopping; set => maTopping = value; }
        public string TenTopping { get => tenTopping; set => tenTopping = value; }
        public int LoaiTopping { get => loaiTopping; set => loaiTopping = value; }
        public double GiaTien { get => giaTien; set => giaTien = value; }
        public string Hinh { get => hinh; set => hinh = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
    }
}
