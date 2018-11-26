using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TrendingMonDTO
    {
        private string tenMon;
        private int soLuong;

        public string TenMon { get => tenMon; set => tenMon = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}
