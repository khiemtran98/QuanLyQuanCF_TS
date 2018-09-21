using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonBanDTO
    {
        private int maHoaDon;
        private int nhanVienLap;
        private DateTime ngayLap;
        private int voucher;
        private double tongTien;

        public int MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public int NhanVienLap { get => nhanVienLap; set => nhanVienLap = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public int Voucher { get => voucher; set => voucher = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }
    }
}
