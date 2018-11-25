using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class DoanhThuDTO
    {
        private string thoiGian;
        private double tongDoanhThu;
        private double tongVong;
        private double lai;
        private double lo;

        public string ThoiGian { get => thoiGian; set => thoiGian = value; }
        public double TongDoanhThu { get => tongDoanhThu; set => tongDoanhThu = value; }
        public double TongVong { get => tongVong; set => tongVong = value; }
        public double Lai { get => lai; set => lai = value; }
        public double Lo { get => lo; set => lo = value; }
    }
}
