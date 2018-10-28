using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTLoaiMon_LoaiToppingDTO
    {
        private int maLoaiMon;
        private int maLoaiTopping;

        public int MaLoaiMon { get => maLoaiMon; set => maLoaiMon = value; }
        public int MaLoaiTopping { get => maLoaiTopping; set => maLoaiTopping = value; }
    }
}
