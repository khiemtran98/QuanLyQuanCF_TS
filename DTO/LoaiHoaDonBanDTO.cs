using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiHoaDonBanDTO
    {
        private int maLoaiHoaDon;
        private string tenLoaiHoaDon;

        public int MaLoaiHoaDon { get => maLoaiHoaDon; set => maLoaiHoaDon = value; }
        public string TenLoaiHoaDon { get => tenLoaiHoaDon; set => tenLoaiHoaDon = value; }
    }
}
