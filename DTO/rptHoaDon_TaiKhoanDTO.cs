using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class rptHoaDon_TaiKhoanDTO
    {
        int maHoaDon;
        DateTime ngayLap;
        string tenNhanVien;
        double tienMat;
        double tienThua;
        double tongTien;

        public int MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public double TienMat { get => tienMat; set => tienMat = value; }
        public double TienThua { get => tienThua; set => tienThua = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }
    }
}
