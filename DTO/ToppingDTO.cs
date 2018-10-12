using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ToppingDTO
    {
        private int maTopping;
        private string tenTopping;
        private int loaiTopping;
        private double giaTien;
        private bool trangThai;

        public int MaTopping { get => maTopping; set => maTopping = value; }
        public string TenTopping { get => tenTopping; set => tenTopping = value; }
        public int LoaiTopping { get => loaiTopping; set => loaiTopping = value; }
        public double GiaTien { get => giaTien; set => giaTien = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
    }
}
