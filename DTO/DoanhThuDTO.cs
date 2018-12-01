using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DoanhThuDTO
    {
        private int thang;
        private double doanhThu;

        public int Thang { get => thang; set => thang = value; }
        public double DoanhThu { get => doanhThu; set => doanhThu = value; }
    }
}
