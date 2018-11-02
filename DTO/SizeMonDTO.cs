using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SizeMonDTO
    {
        private string size;
        private int maMon;
        private double giaTien;
        private bool trangThai;

        public string Size { get => size; set => size = value; }
        public int MaMon { get => maMon; set => maMon = value; }
        public double GiaTien { get => giaTien; set => giaTien = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
    }
}
