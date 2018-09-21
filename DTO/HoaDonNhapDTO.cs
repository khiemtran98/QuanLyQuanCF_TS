using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonNhapDTO
    {
        private int maHoaDon;
        private int nhaCungCap;
        private DateTime ngayLap;
        private double tongTien;

        public int MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public int NhaCungCap { get => nhaCungCap; set => nhaCungCap = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }
    }
}
