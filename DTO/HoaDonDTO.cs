using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonDTO
    {
        private int maHoaDon;
        private int nhanVienLap;
        private DateTime ngayLap;
        private double tongTien;
        private bool trangThai;

        public int MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public int NhanVienLap { get => nhanVienLap; set => nhanVienLap = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
    }
}
